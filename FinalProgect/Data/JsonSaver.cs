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
        public void SaveFilms(IEnumerable<Film> films)
        {
            string filmsStr = JsonConvert.SerializeObject(films);
            File.WriteAllText("films.json", filmsStr);
        }
    }
}
