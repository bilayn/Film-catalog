using FinalProgect.Data;
using FinalProgect.Interface;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgect.Infrastructure
{
    class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILoader>().To<SqLiteLoader>();
            Bind<ISaver>().To<SqLiteSaver>();
        }
    }
}
