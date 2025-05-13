using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSolution
{
    internal class Heap_Exception
    {
        internal class HeapException : Exception
        {
            public HeapException() { }
            public HeapException(string message) : base(message) { }
        }

        internal class UnmutableHeapException : HeapException
        {
            public UnmutableHeapException() : base("Изменение списка запрещено") { }
        }
    }
}
