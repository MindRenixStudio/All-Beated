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
using All_Beated;
using System.IO;
using All_Beated.Database_Class_Types;

namespace All_Beated.Show_Pages
{
    /// <summary>
    /// Interakční logika pro Main_List_Page.xaml
    /// </summary>
    public partial class Main_List_Page : Page
    {

        List<GameWriteType> gameWriteList = new List<GameWriteType>();

        string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MindRenixStudioData\\Data\\game_data.db3";

        public Main_List_Page()
        {
            InitializeComponent();

            DBFileCreate(dbPath);
            ShowGamesInList();
        }

        private async void ShowGamesInList()
        {
            DatabaseConnection database = new DatabaseConnection(dbPath);

            gameWriteList = await database.GetGamesList();

            GamesList.ItemsSource = gameWriteList;
        }
        private void DetailBTN(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            int index = GamesList.Items.IndexOf(item) + 1;

            //předání na konkrétní stránku s detaily včetně ID (index)
            FromMainListPage.Content = new Game_Detail_Page(index);
        }
        private void AddGame_Click(object sender, RoutedEventArgs e)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (!Directory.Exists(docPath + "\\MindRenixStudioData"))
            {
                Directory.CreateDirectory(docPath + "\\MindRenixStudioData");
                Directory.CreateDirectory(docPath + "\\MindRenixStudioData\\SavedPictures");
                Directory.CreateDirectory(docPath + "\\MindRenixStudioData\\Data");
            }

            FromMainListPage.Content = new Game_Add_Page();
        }
        private void DBFileCreate(string dbPathF)
        {
            if (File.Exists(dbPathF) == false)
            {
                File.Create(dbPathF);
            }
        }
    }
}
