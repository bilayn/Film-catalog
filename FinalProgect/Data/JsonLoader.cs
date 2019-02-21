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

        public void LoadFilms(out ObservableCollection<Film> films)
        {
            if (File.Exists("films.json"))
                films = JsonConvert.DeserializeObject<ObservableCollection<Film>>(File.ReadAllText("films.json"));
            else
                films = new ObservableCollection<Film>();
        }
        
    }
}
