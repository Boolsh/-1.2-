using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapLibrary
{
    public class HeapException : Exception
    {
        public HeapException(string message) : base(message) { }
    }

    public class HeapModificationNotAllowedException : HeapException
    {
        public HeapModificationNotAllowedException()
            : base("Modification of unmutable heap is not allowed") { }
    }
}
