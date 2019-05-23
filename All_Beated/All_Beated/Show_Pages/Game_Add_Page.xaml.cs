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
using All_Beated.Database_Class_Types;

namespace All_Beated.Show_Pages
{
    /// <summary>
    /// Interakční logika pro Game_Add_Page.xaml
    /// </summary>
    public partial class Game_Add_Page : Page
    {
        public string name;
        public int rating;
        public string review;
        public int playtime;
        public string positives;
        public string negatives;
        public string picturePath;

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

            picturePath = openFileDialog.FileName;
        }

        private async void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (OnlyNumberCheck(InputRating.Text) == false)
            {
                InputRating.Text = "Only numbers, got it?";
                InputRatingError.Visibility = Visibility.Visible;
            }
            if (OnlyNumberCheck(InputPlaytime.Text) == false)
            {
                InputPlaytime.Text = "Only numbers, got it?";
                InputPlaytimeError.Visibility = Visibility.Visible;
            }
            if (OnlyNumberCheck(InputRating.Text) == true && OnlyNumberCheck(InputPlaytime.Text) == true)
            {
                rating = Int32.Parse(InputRating.Text);
                playtime = Int32.Parse(InputPlaytime.Text);

                if (String.IsNullOrEmpty(InputName.Text) == true)
                {
                    InputName.Text = "You better fill this.";
                    InputNameError.Visibility = Visibility.Visible;
                }
                if (String.IsNullOrEmpty(InputName.Text) == false)
                {
                    InputNameError.Visibility = Visibility.Hidden;

                    name = InputName.Text;

                    if (string.IsNullOrEmpty(InputReview.Text) == true)
                    {
                        review = "Not written";
                    }
                    if (string.IsNullOrEmpty(InputReview.Text) == false)
                    {
                        review = InputReview.Text;
                    }


                    if (string.IsNullOrEmpty(InputPositives.Text) == true)
                    {
                        positives = "Not written";
                    }
                    if (string.IsNullOrEmpty(InputPositives.Text) == false)
                    {
                        positives = InputPositives.Text;
                    }


                    if (string.IsNullOrEmpty(InputNegatives.Text) == true)
                    {
                        negatives = "Not written";
                    }
                    if (string.IsNullOrEmpty(InputNegatives.Text) == false)
                    {
                        negatives = InputNegatives.Text;
                    }

                    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    File.Copy(picturePath, docPath + "\\MindRenixStudioData\\SavedPictures\\" + InputName.Text + ".jpg");

                    DatabaseConnection database = new DatabaseConnection(docPath + "\\MindRenixStudioData\\Data\\game_data.db3");

                    GameWriteType gameTypeWrite = new GameWriteType();

                    gameTypeWrite.Name = name;
                    gameTypeWrite.Rating = rating;
                    gameTypeWrite.Reviw = review;
                    gameTypeWrite.PlayTime = playtime;
                    gameTypeWrite.Positives = positives;
                    gameTypeWrite.Negatives = negatives;
                    gameTypeWrite.PicPath = picturePath;

                    await database.SaveGame(gameTypeWrite); 

                }
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
