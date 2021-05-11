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

namespace AndrewCasey_S00200841
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Game> AllGames;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] genre = { "All", "PC", "Xbox", "PS", "Switch" };
            cbx_Genre.ItemsSource = genre;

            GameData db = new GameData();

            var query = from g in db.Games
                        select g;
            AllGames = query.ToList();
            lbx_Games.ItemsSource = AllGames;
        }

        private void lbx_Games_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game selectedGame = lbx_Games.SelectedItem as Game;
            if(selectedGame != null)
            {
                //img_GameImage.Source = new BitmapImage(new Uri(selectedGame.Game_Image, UriKind.Relative));               
                //tbx_GameDetails.Text = $"{selectedGame.Description}";
                tbx_GamePrice.Text = $"{selectedGame.Price:C}";
                tblk_GameDetails.Text = $"{selectedGame.Description}";
            }
        }

        // TODO : get working Correctly
        // Could say that a game that has more than one Genre will cause an issue in futre so would need fixing
        private void cxb_Genre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedGenre = cbx_Genre.SelectedItem as string;

            List<Game> filterList = new List<Game>();

            switch (selectedGenre)
            {
                case "All":
                    lbx_Games.ItemsSource = AllGames;
                    break;

                case "PC":
                    foreach(Game game in AllGames)
                    {
                        if (game.Platform is "PC, Xbox, PS, Switch")
                            filterList.Add(game);
                    }
                    lbx_Games.ItemsSource = filterList;
                    break;

                case "Xbox":
                    foreach (Game game in AllGames)
                    {
                        if (game.Platform is "Xbox")
                            filterList.Add(game);
                    }
                    lbx_Games.ItemsSource = filterList;
                    break;

                case "PS":
                    foreach (Game game in AllGames)
                    {
                        if (game.Platform is "PS")
                            filterList.Add(game);
                    }
                    lbx_Games.ItemsSource = filterList;
                    break;

                case "Switch":
                    foreach (Game game in AllGames)
                    {
                        if (game.Platform is "Switch")
                            filterList.Add(game);
                    }
                    lbx_Games.ItemsSource = filterList;
                    break;
            }
        }
    }
}
