using Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgect.Model
{
    class Film : BaseNotify
    {
        private string title;
        private int year;
        private string ganre;
        private int rating;
        private string director;
        private string image;
        private string actors;
        private string about;

        #region Properties
        public string Image
        {
            get => image;
            set
            {
                image = value;
                Notify();
            }
        }

        public string About
        {
            get => about;
            set
            {
                about = value;
                Notify();
            }
        }

        public int Year
        {
            get => year;
            set
            {
                year = value;
                Notify();
            }
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                Notify();
            }
        }

        public string Ganre
        {
            get => ganre;
            set
            {
                ganre = value;
                Notify();
            }
        }

        public int Rating
        {
            get => rating;
            set
            {
                rating = value;
                Notify();
            }
        }

        public string Director
        {
            get => director;
            set
            {
                director = value;
                Notify();
            }
        }

        public string Actors
        {
            get => actors;
            set
            {
                actors = value;
                Notify();
            }
        }
        #endregion

        public static ObservableCollection<Film> GetFilms()
        {
            return new ObservableCollection<Film>
            {
                new Film {Title = "Богемская рапсодия", Year=2018, Ganre="биография", Rating=4, Director="Браян Сингер", Image=@"..\images\1.jpg",
                    Actors = "Рами Малек, Люси Бойнтон, Гвилим Ли", About="Чествование группы Queen, их музыки и их выдающегося вокалиста Фредди Меркьюри, " +
                    "который бросил вызов стереотипам и победил условности, чтобы стать одним из самых любимых артистов на планете. Фильм прослеживает головокружительный " +
                    "путь группы к успеху благодаря их культовым песням и революционному звуку, практически распад коллектива, поскольку образ жизни Меркьюри выходит из-под " +
                    "контроля, и их триумфальное воссоединение накануне концерта Live Aid, ставшим одним из величайших выступлений в истории рок-музыки." },
                    new Film {Title = "Хроники хищных городов", Year=2018, Ganre="стим-панк фантастика", Rating=3, Director="Кристиан Риверс", Image=@"..\images\2.jpg",
                    Actors ="Роберт Шиэн, Гера Хилмарсдоттир, Чихэ", About="Прошли тысячелетия после того, как мир настиг апокалипсис. Человечество адаптировалось и теперь живет по новым " +
                    "правилам. Гигантские движущиеся мегаполисы рассекают пустоши и поглощают маленькие города ради ресурсов. Том Нэтсуорти из нижнего уровня великого Лондона оказывается в " +
                    "смертельной опасности, когда на его пути появляется скрывающаяся от закона бунтарка Эстер Шоу. Они не должны были встретиться, но им суждено изменить будущее." }
            };
        }
    }
}
