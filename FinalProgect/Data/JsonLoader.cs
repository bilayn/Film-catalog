using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProgect.Model;
using FinalProgect.Interface;

namespace FinalProgect.Data
{
    class JsonLoader : ILoader
    {

        public void LoadMovies(out ObservableCollection<Movie> movies)
        {
            if (File.Exists("Movies.json"))
                movies = JsonConvert.DeserializeObject<ObservableCollection<Movie>>(File.ReadAllText("movies.json"));
            else
                movies = new ObservableCollection<Movie>();
        }
        
    }
}
