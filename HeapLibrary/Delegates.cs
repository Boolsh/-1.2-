using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapLibrary
{
    internal class Delegates
    {
        public delegate bool CheckDelegate<T>(T item);
        public delegate void ActionDelegate<T>(T item);
        public delegate Heap<T> HeapConstructorDelegate<T>();
    }
}
