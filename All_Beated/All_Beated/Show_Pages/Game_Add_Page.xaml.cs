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
using System.IO;
using System.Text.RegularExpressions;

namespace All_Beated.Show_Pages
{
    /// <summary>
    /// Interakční logika pro Game_Add_Page.xaml
    /// </summary>
    public partial class Game_Add_Page : Page
    {
        public Game_Add_Page()
        {
            InitializeComponent();
        }

        private void SelectPicBTN(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.FileName = "picture.jpg";
            openFileDialog.DefaultExt = ".jpg";
            openFileDialog.Filter = "Pictures (.jpg)|*.jpg";

            Nullable<bool> result = openFileDialog.ShowDialog();

            SelectedPath.Text = openFileDialog.FileName;

            string picturePath = openFileDialog.FileName;

            //File.Copy(picturePath, docPath + "\\MindRenixStudioData\\" + InputName.Text + ".jpg");
            //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (OnlyNumberCheck(InputReview.Text) == false)
            {
                InputRating.Text = "Only numbers, got it?";
                InputRatingError.Visibility = Visibility.Visible;
            }
            if (OnlyNumberCheck(InputReview.Text) == true)
            {

            }
        }

        private bool OnlyNumberCheck(string textToCheck)
        {
            if (Regex.IsMatch(textToCheck, @"^\d+$") == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
