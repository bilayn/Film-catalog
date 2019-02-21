using FinalProgect.ViewModel;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgect.Infrastructure
{
    class ViewModelLocator
    {
        public ViewModelLocator() => MainViewModel = new StandardKernel(new ViewModelModule()).Get<MainViewModel>();
        public MainViewModel MainViewModel { get; }
    }
}
