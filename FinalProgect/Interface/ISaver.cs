using FinalProgect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgect.Interface
{
    interface ISaver
    {
        void SaveMovies(IEnumerable<Movie> movies);
    }
}
