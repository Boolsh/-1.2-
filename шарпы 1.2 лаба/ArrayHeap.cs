using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace шарпы_1._2_лаба
{
    internal class ArrayHeap<T> : IHeap<T> where T : IComparable<T>
    {
        private T[] _heap;
        private int _capacity;
        private int _size = 0;

        public ArrayHeap() : this(4){}
        public ArrayHeap(int capacity)
        {
            _capacity = capacity;
            _heap = new T[capacity];
        }

        public void PrintHeapAsTree()
        {
            if (_size == 0)
            {
                Console.WriteLine("Heap is empty");
                return;
            }

            // Вычисляем максимальную глубину кучи
            int levels = (int)Math.Log(_size, 2) + 1;

            // Максимальная ширина последнего уровня (2^(levels-1) элементов)
            int lastLevelWidth = (int)Math.Pow(2, levels - 1);

            // Общая ширина для центрирования (умножаем на 3, так как каждый элемент занимает ~3 символа)
            int totalWidth = lastLevelWidth * 3;

            int currentIndex = 0;

            for (int level = 0; level < levels; level++)
            {
                int elementsOnLevel = (int)Math.Pow(2, level);
                int spacing = totalWidth / (elementsOnLevel + 1);

                for (int i = 0; i < elementsOnLevel && currentIndex < _size; i++, currentIndex++)
                {
                    // Центрируем каждый элемент на своем месте
                    Console.Write(new string(' ', spacing) + _heap[currentIndex]);
                }
                Console.WriteLine();

                // Рисуем соединительные линии между уровнями
                if (level < levels - 1 && currentIndex < _size)
                {
                    int nextLevelElements = (int)Math.Pow(2, level + 1);
                    int nextSpacing = totalWidth / (nextLevelElements + 1);

                    for (int i = 0; i < elementsOnLevel; i++)
                    {
                        int pos = spacing * (i + 1);
                        Console.Write(new string(' ', pos - 1) + "/\\");
                    }
                    Console.WriteLine();
                }
            }
        }
        public void print_to_console()
        {
            foreach (T i in _heap)
                Console.Write(i + " ");
            Console.WriteLine();
            
        }
        public int Count => _size;  // Текущее количество элементов

        public bool isEmpty => _size == 0;  // Проверка на пустоту

        public IEnumerable<T> nodes => _heap.Take(_size); // Перечисление элементов

        public void Add(T node)
        {
            if (_size == _capacity) Resize();

            _heap[_size] = node;
            HeapifyUp(_size);
            _size++;
        }

        public void Clear()
        {
            _size= 0;
            Array.Clear(_heap, 0, _capacity);
        }

        public bool Contains(T node)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T node)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void Resize()
        {
            _capacity *= 2;  // Удваиваем ёмкость
            T[] newHeap = new T[_capacity];
            Array.Copy(_heap, newHeap, _heap.Length);
            _heap = newHeap;
        }
        private void HeapifyUp(int i)
        {
            int parentInd = get_parent_index(i);
            if (parentInd < 0) return;
            
            if (_heap[i].CompareTo(_heap[parentInd]) > 0)
            {
                Swap(i, parentInd);
                HeapifyUp(parentInd);
            }
        }
        private void HeapifyDown() 
        {

        }
        private void Swap(int a, int b)
        {
            T tmp = _heap[a];
            _heap[a] = _heap[b];
            _heap[b] = tmp;
        }
        private int get_parent_index(int i) => (i - 1) / 2;
        private int get_lChild_index(int i) => 2 * i + 1;
        private int get_rChild_index(int i) => 2*i + 2;
    }
}
