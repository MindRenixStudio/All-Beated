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
        }
    }
}
