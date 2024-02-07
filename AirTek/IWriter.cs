using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTek
{
    internal interface IWriter<T> where T : class, IWriter<T>
    {
        void Write();
    }
}
