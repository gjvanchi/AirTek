using AirTek.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTek
{
    internal interface IFileRead<T> where T: class, IFileRead<T>
    {
        void Read();
    }
}
