using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using All_Beated.Database_Class_Types;

namespace All_Beated.Show_Pages
{
    /// <summary>
    /// Interakční logika pro Game_Detail_Page.xaml
    /// </summary>
    public partial class Game_Detail_Page : Page
    {
        string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MindRenixStudioData\\Data\\game_data.db3";
        List<GameWriteType> gameDetailsList = new List<GameWriteType>();
        List<string> gameDetailsListFinished = new List<string>();

        public Game_Detail_Page(int index)
        {
            InitializeComponent();

            ShowGameDetails(index);
        }

        private void ShowGameDetails(int indexOfGame)
        {
            DatabaseConnection databaseConn = new DatabaseConnection(dbPath);

            gameDetailsList = databaseConn.GetGameDetail(indexOfGame).Result;

            foreach (GameWriteType data in gameDetailsList)
            {
                gameDetailsListFinished.Add(data.ID.ToString());
                gameDetailsListFinished.Add(data.Name);
                gameDetailsListFinished.Add(data.Rating.ToString());
                gameDetailsListFinished.Add(data.PlayTime.ToString());
                gameDetailsListFinished.Add(data.Reviw);
                gameDetailsListFinished.Add(data.Positives);
                gameDetailsListFinished.Add(data.Negatives);
                gameDetailsListFinished.Add(data.PicPath);
            }

            BackgroundPic.Source = new BitmapImage(new Uri(gameDetailsListFinished[7]));

            GameName.Content = gameDetailsListFinished[1];
            GameRating.Content = gameDetailsListFinished[2] + "%";
            GamePlaytime.Content = gameDetailsListFinished[3] + "H";
            GameReview.Text = gameDetailsListFinished[4];
            GamePositives.Text = gameDetailsListFinished[5];
            GameNegatives.Text = gameDetailsListFinished[6];
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            DetailPage.Content = new Main_List_Page();
        }
    }
}
