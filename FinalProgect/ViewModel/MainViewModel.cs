using FinalProgect.Infrastructure;
using FinalProgect.Interface;
using FinalProgect.Model;
using FinalProgect.View;
using FinalProject.Infrastructure;
using Infrastructure;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace FinalProgect.ViewModel
{
    class MainViewModel : BaseNotify
    {
        private ObservableCollection<Movie> movies = new ObservableCollection<Movie>();
        private Movie selectedMovie;
        private ISaver saver;
        private ILoader loader;
        private string _searchStringFilter;
        public MainViewModel(ISaver saver, ILoader loader)
        {
            this.saver = saver;
            this.loader = loader;

        }

        #region Property
        public ICollectionView MoviesView { get; set; }
        public string SearchMovie
        {
            get => _searchStringFilter;
            set
            {
                _searchStringFilter = value;
                Notify(nameof(SearchMovie));
                MoviesView.Refresh();
            }
        }

        public ObservableCollection<Movie> Movies
        {
            get => movies;
            set
            {
                movies = value;
                Notify();
            }
        }

        public Movie SelectedMovie
        {
            get => selectedMovie;
            set
            {
                selectedMovie = value;
                SingletonSelect.Movie = value;
                Notify();
            }
        }
        #endregion

        #region Command
        private RelayCommand exitCommand;
        private RelayCommand theme;
        private RelayCommand updateList;
        private RelayCommand removeCommand;
        private RelayCommand expand;
        private RelayCommand addCommand;
        private RelayCommand sortCommand;
        private RelayCommand openCommand;
        private RelayCommand closeCommand;
        private RelayCommand viewCommand;

        public ICommand ViewCommand
        {
            get
            {
                if (viewCommand == null)
                    viewCommand = new RelayCommand(x => { FindSelectedItem((string)x); OpenWatch(); });
                return viewCommand;
            }
        }

        public ICommand SortCommand
        {
            get
            {
                if (sortCommand == null)
                    sortCommand = new RelayCommand(SortMethod);
                return sortCommand;
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new RelayCommand(x => Movies.Add(new Movie
                    {
                        Title = "Null",
                        Actors = "Null",
                        Director = "Null",
                        Ganre = "Null",
                        Image = @"..\Images\3.jpg",
                        Rating = 0,
                        Year = 0000,
                        About = "Null"
                    }));
                return addCommand;
            }
        }

        public ICommand Expand
        {
            get
            {
                if (expand == null)
                    expand = new RelayCommand(x => FindSelectedItem((string)x));
                return expand;
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                if (removeCommand == null)
                    removeCommand = new RelayCommand(x => { FindSelectedItem((string)x); movies.Remove(SelectedMovie); });
                return removeCommand;
            }
        }
        public ICommand UpdateListCommand
        {
            get
            {
                if (updateList == null)
                    updateList = new RelayCommand(x => { FindSelectedItem((string)x); Movies = new ObservableCollection<Movie>(Movies); });
                return updateList;
            }
        }
        public ICommand ChTheme
        {
            get
            {
                if (theme == null)
                    theme = new RelayCommand(ChangeTheme);
                return theme;
            }
        }

        public ICommand ExitCommand
        {
            get
            {
                if (exitCommand == null)
                    exitCommand = new RelayCommand(x => ((Window)x).Close());
                return exitCommand;
            }
        }

        public ICommand OpendCommand
        {
            get
            {
                if (openCommand == null)
                    openCommand = new RelayCommand(x =>
                    {
                        loader.LoadMovies(out movies);
                        MoviesView = CollectionViewSource.GetDefaultView(Movies);
                        MoviesView.Filter = MoviesFilter;
                        Notify(nameof(MoviesView));
                    });
                return openCommand;
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                    closeCommand = new RelayCommand(x => saver.SaveMovies(Movies));
                return closeCommand;
            }
        }

        #endregion

        #region  Method
        private void ChangeTheme(object parameter)
        {
            ResourceDictionary[] dict = new ResourceDictionary[0];
            if ((parameter as ToggleButton).IsChecked == true)
                dict = Theme.GetDarkTheme();
            else
                dict = Theme.GetLightTheme();
            App.Current.Resources.MergedDictionaries.Clear();
            foreach (var elem in dict)
                App.Current.Resources.MergedDictionaries.Add(elem);
        }
        private void FindSelectedItem(object parametr)
        {
            foreach (var i in Movies)
            {
                if (parametr as string == i.Title)
                {
                    SelectedMovie = i;
                    SingletonSelect.Movie = i;
                    break;
                }
            }
        }
        private void SortMethod(object param)
        {
            string sortParam = param.ToString();
            switch (sortParam)
            {
                case "Title":
                    Movies = new ObservableCollection<Movie>(Movies.OrderBy(x => x.Title));
                    break;
                case "Ganre":
                    Movies = new ObservableCollection<Movie>(Movies.OrderBy(x => x.Ganre));
                    break;
                case "Year":
                    Movies = new ObservableCollection<Movie>(Movies.OrderByDescending(x => x.Year));
                    break;
                case "Rating":
                    Movies = new ObservableCollection<Movie>(Movies.OrderByDescending(x => x.Rating));
                    break;
                case "Director":
                    Movies = new ObservableCollection<Movie>(Movies.OrderBy(x => x.Director));
                    break;
            }
        }

        private void OpenWatch()
        {
            Window1 win2 = new Window1();
            win2.ShowDialog();
        }

        private bool MoviesFilter(object o)
        {
            var movieInfo = o as Movie;
            bool isCintainsTitle = true;
            if (!string.IsNullOrWhiteSpace(_searchStringFilter) && !string.IsNullOrEmpty(_searchStringFilter))
            {
                isCintainsTitle = movieInfo.Title.Contains(_searchStringFilter);
            }
            return isCintainsTitle;
            #endregion
        }
    }
}
