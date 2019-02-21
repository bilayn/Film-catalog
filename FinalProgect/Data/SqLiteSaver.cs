using FinalProgect.Interface;
using FinalProgect.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgect.Data
{
    class SqLiteSaver : ISaver
    {
        public void SaveFilms(IEnumerable<Film> films)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source = Film.db"))
            {
                conn.Open();
                string query = @"delete from Film";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                foreach (var film in films)
                {
                    query = $@"insert into Film(Image, About, Year, Title, Ganre, Rating, Director, Actors) values ('{film.Image}', '{film.About}',
                                                                                                                            '{film.Year}', '{film.Title}',
                                                                                                                            '{film.Ganre}','{film.Rating}',
                                                                                                                            '{film.Director}','{film.Actors}');";
                    cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
