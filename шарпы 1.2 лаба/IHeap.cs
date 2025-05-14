using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeapSolution
{
    public interface IHeap<T> : IEnumerable<T>
    {
        void PrintHorizontal(TextBox textBox);
        int Count { get; }
        bool isEmpty { get; }
        IEnumerable<T> nodes { get; }
        void Add(T node);
        void Clear();
        bool Contains(T node);
        bool Remove(T node);
        void CopyTo(IHeap<T> targetHeap);

    }
}
