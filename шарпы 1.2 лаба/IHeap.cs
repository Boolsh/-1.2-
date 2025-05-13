using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSolution
{
    internal interface IHeap<T> : IEnumerable<T>
    {
        int Count { get; }
        bool isEmpty { get; }
        IEnumerable<T> nodes { get; }
        void Add(T node);
        void Clear();
        bool Contains(T node);
        bool Remove(T node);
    }
}
