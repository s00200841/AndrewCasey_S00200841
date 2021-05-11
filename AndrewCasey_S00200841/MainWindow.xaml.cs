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
    /// Name : Andrew Casey
    /// Student Number :S00200841
    /// GitHub : https://github.com/s00200841/AndrewCasey_S00200841
    /// Code Wise all is Complete up to Material Design, Reasons for not finishing that part was im worried that i may break my code 
    /// Since i had a few issues with it while practicing for the exam and i had no idea how to fix these
    /// Game Class is made to specifications
    /// DataBase is created and working to specifications 
    /// Testing has a case for both whole numbers and decimal places to two decimals as in how currency would expect 99.99
    /// Xaml is hand written
    /// filtered Genre could be improved upon in the future but for exam purposes it is more than adequate
    /// Data Templates are in place
    /// MetaCritic score is being show but could definitely be improved upon
    /// Image Size could be improved upon in the Listbox since some are bigger than others
    /// </summary>
    public partial class MainWindow : Window
    {
        // List of Games 
        List<Game> AllGames;
        public MainWindow()
        {
            InitializeComponent();
        }

        // When Window Gets Loaded 
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

        // Select item from Listbox and show the relevant Data
        private void lbx_Games_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game selectedGame = lbx_Games.SelectedItem as Game;
            if(selectedGame != null)
            {
                tbx_GamePrice.Text = $"{selectedGame.Price:C}";
                tblk_GameDetails.Text = $"{selectedGame.Description}";
            }
        }

        // Could say that a game that has more than one Genre will cause an issue in futre so would need fixing
        // Here I Just say if it is a specific Genre or if it is in all Genres then add it to the filtered list
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
                        if (game.Platform is "PC" ||game.Platform is "PC, Xbox, PS, Switch")
                            filterList.Add(game);
                    }
                    lbx_Games.ItemsSource = filterList;
                    break;

                case "Xbox":
                    foreach (Game game in AllGames)
                    {
                        if (game.Platform is "Xbox" || game.Platform is "PC, Xbox, PS, Switch")
                            filterList.Add(game);
                    }
                    lbx_Games.ItemsSource = filterList;
                    break;

                case "PS":
                    foreach (Game game in AllGames)
                    {
                        if (game.Platform is "PS" || game.Platform is "PC, Xbox, PS, Switch")
                            filterList.Add(game);
                    }
                    lbx_Games.ItemsSource = filterList;
                    break;

                case "Switch":
                    foreach (Game game in AllGames)
                    {
                        if (game.Platform is "Switch" || game.Platform is "PC, Xbox, PS, Switch")
                            filterList.Add(game);
                    }
                    lbx_Games.ItemsSource = filterList;
                    break;
            }
        }
    }
}
