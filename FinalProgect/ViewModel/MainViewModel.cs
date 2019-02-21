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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace FinalProgect.ViewModel
{
    class MainViewModel : BaseNotify
    {

        private ObservableCollection<Film> films = new ObservableCollection<Film>();
        private Film selectedFilm;
        private ISaver saver;
        private ILoader loader;
        private string searchFilm;
        private ObservableCollection<Film> buf = new ObservableCollection<Film>();
        public MainViewModel(ISaver saver, ILoader loader)
        {
            this.saver = saver;
            this.loader = loader;
        }

        #region Property
        public string SearchFilm
        {
            get => searchFilm;
            set
            {
                searchFilm = value;
                Notify();
                SearchingFilm();
            }
        }

        public ObservableCollection<Film> Films
        {
            get => films;
            set
            {
                films = value;
                Notify();
            }
        }

        public Film SelectedFilm
        {
            get => selectedFilm;
            set
            {
                selectedFilm = value;
                SingletonSelect.Film = value;
                Notify();
            }
        }
        #endregion

        #region Command
        private RelayCommand exit;
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
                    viewCommand = new RelayCommand(x=>{ FindSelectedItem((string)x); OpenWatch(); });
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
                    addCommand = new RelayCommand(x => Films.Add(new Film {
                        Title = "Null",
                        Actors = "Null",
                        Director = "Null",
                        Ganre = "Null",
                        Image = @"..\Images\3.jpg",
                        Rating = 0,
                        Year = 0000,
                        About="Null"
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
                    removeCommand = new RelayCommand(x => { FindSelectedItem((string)x); films.Remove(SelectedFilm); });
                return removeCommand;
            }
        }
        public ICommand UpdateListCommand
        {
            get
            {
                if (updateList == null)
                    updateList = new RelayCommand(x => { FindSelectedItem((string)x); Films = new ObservableCollection<Film>(Films); });
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

        public ICommand Exit
        {
            get
            {
                if (exit == null)
                    exit = new RelayCommand(x=>((Window)x).Close());
                return exit;
            }
        }

        public ICommand OpendCommand
        {
            get
            {
                if (openCommand == null)
                    openCommand = new RelayCommand(x =>
                    {
                        loader.LoadFilms(out films);
                        Notify("Films");
                    });
                return openCommand;
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                    closeCommand = new RelayCommand(x =>saver.SaveFilms(Films));
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
            foreach(var i in Films)
            {
                if (parametr as string == i.Title)
                { 
                    SelectedFilm = i;
                    SingletonSelect.Film = i;
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
                    Films = new ObservableCollection<Film>(Films.OrderBy(x => x.Title));
                    break;
                case "Ganre":
                    Films = new ObservableCollection<Film>(Films.OrderBy(x => x.Ganre));
                    break;
                case "Year":
                    Films = new ObservableCollection<Film>(Films.OrderByDescending(x => x.Year));
                    break;
                case "Rating":
                    Films = new ObservableCollection<Film>(Films.OrderByDescending(x => x.Rating));
                    break;
                case "Director":
                    Films = new ObservableCollection<Film>(Films.OrderBy(x => x.Director));
                    break;
            }
        }

        private void SearchingFilm()
        {
            if (searchFilm == string.Empty)
            {
                loader.LoadFilms(out films);
                Notify("Films");
                return;
            }

            var predicate = PredicateBuilder.New<Film>(true);
            predicate.And(x => x.Title.IndexOf(searchFilm) != -1);
            Films = new ObservableCollection<Film>(Films.Where(predicate));
        }

        private void OpenWatch()
        {
            Window1 win2 = new Window1();
            win2.ShowDialog();
        }

        #endregion
    }
}
