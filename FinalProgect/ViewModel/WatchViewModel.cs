﻿using FinalProgect.Infrastructure;
using FinalProgect.Model;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FinalProgect.ViewModel
{
    class WatchViewModel
    {
        public Film SelectedFilm
        {
            get => SingletonSelect.Film;
            set
            {
                SingletonSelect.Film = value;
            }
        }
        private RelayCommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                    closeCommand = new RelayCommand(x => (x as Window).Close());
                return closeCommand;
            }
        }

    }
}