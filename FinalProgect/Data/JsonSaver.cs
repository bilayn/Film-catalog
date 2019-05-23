using FinalProgect.Interface;
using FinalProgect.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgect.Data
{
    class JsonSaver : ISaver
    {
        public void SaveMovies(IEnumerable<Movie> movies)
        {
            string moviesStr = JsonConvert.SerializeObject(movies);
            File.WriteAllText("movies.json", moviesStr);
        }
    }
}
