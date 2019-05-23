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

namespace All_Beated.Show_Pages
{
    /// <summary>
    /// Interakční logika pro Main_List_Page.xaml
    /// </summary>
    public partial class Main_List_Page : Page
    {
        //public string dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "\\MindRenixStudioData\\Data\\game_data.db3");
        //třeba zde vytvořit databázi 
        public Main_List_Page()
        {
            InitializeComponent();

            string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MindRenixStudioData\\Data\\game_data.db3";

            DBFileCreate(dbPath);
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

        private void DBFileCreate(string dbPath)
        {
            if (File.Exists(dbPath) == false)
            {
                File.Create(dbPath + "\\MindRenixStudioData\\Data\\game_data.db3");
            }
        }
    }
}
