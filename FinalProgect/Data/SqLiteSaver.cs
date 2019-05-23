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
        public void SaveMovies(IEnumerable<Movie> movies)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source = Film.db"))
            {
                conn.Open();
                string query = @"delete from Movie";
                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.ExecuteNonQuery();
                foreach (var movie in movies)
                {
                    query = $@"insert into Movie(Image, About, Year, Title, Ganre, Rating, Director, Actors) values ('{movie.Image}', '{movie.About}',
                                                                                                                            '{movie.Year}', '{movie.Title}',
                                                                                                                            '{movie.Ganre}','{movie.Rating}',
                                                                                                                            '{movie.Director}','{movie.Actors}');";
                    cmd = new SQLiteCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
