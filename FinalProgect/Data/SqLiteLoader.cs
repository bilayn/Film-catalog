using FinalProgect.Interface;
using FinalProgect.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgect.Data
{
    class SqLiteLoader : ILoader
    {
        public void LoadFilms(out ObservableCollection<Film> films)
        {
            films = new ObservableCollection<Film>();

            using (SQLiteConnection conn = new SQLiteConnection("Data Source = Film.db"))
            {
                conn.Open();
                string query = "select * from Film;";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                SQLiteDataReader std = cmd.ExecuteReader();
                while (std.Read())
                {
                    films.Add(new Film
                    {
                        Image = $"{std["Image"]}",
                        About = $"{std["About"]}",
                        Year = Convert.ToInt32($"{std["Year"]}"),
                        Title = $"{std["Title"]}",
                        Ganre = $"{std["Ganre"]}",
                        Rating = Convert.ToInt32($"{std["Rating"]}"),
                        Director = $"{std["Director"]}",
                        Actors = $"{std["Actors"]}"
                    });
                }

            }
        }
    }
}
