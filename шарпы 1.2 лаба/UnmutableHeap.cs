using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeapSolution.Heap_Exception;

namespace HeapSolution
{
    internal class UnmutableHeap<T> : IHeap<T>
    {
        private readonly IHeap<T> _wrappedHeap;

        public UnmutableHeap(IHeap<T> heapToWrap)
        {
            _wrappedHeap = heapToWrap ?? throw new ArgumentNullException(nameof(heapToWrap));
        }

        public int Count => _wrappedHeap.Count;
        public bool isEmpty => _wrappedHeap.isEmpty;
        public IEnumerable<T> nodes => _wrappedHeap.nodes;

        public void Add(T node)
        {
            throw new UnmutableHeapException();
        }

        public void Clear()
        {
            throw new UnmutableHeapException();
        }

        public bool Contains(T node)
        {
            return _wrappedHeap.Contains(node);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _wrappedHeap.GetEnumerator();
        }

        public bool Remove(T node)
        {
            throw new UnmutableHeapException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Дополнительные методы для удобства
        public T PeekMax()
        {
            if (isEmpty)
                throw new InvalidOperationException("Heap is empty");
            return _wrappedHeap.nodes.First();
        }


    }
}
