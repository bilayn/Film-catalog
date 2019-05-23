using FinalProgect.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgect.Interface
{
    interface ILoader
    {
        void LoadMovies(out ObservableCollection<Movie> movies);
    }
}
