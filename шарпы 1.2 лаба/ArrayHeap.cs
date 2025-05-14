using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeapSolution
{
    public class ArrayHeap<T> : IHeap<T>
    {
        private T[] _heap;
        private int _capacity;
        private int _size = 0;
        private readonly IComparer<T> _comparer;
        public ArrayHeap(int capacity = 4, IComparer<T> comparer = null)
        {
            _comparer = comparer ?? Comparer<T>.Default;
            if (_comparer == null)
                throw new InvalidOperationException($"No default comparer for {typeof(T).Name}");

            _capacity = capacity > 0 ? capacity : 4;
            _heap = new T[_capacity];
            _size = 0;
        }

        //private int Compare(T a, T b) => _comparer.Compare(a, b);
        public void PrintHorizontal(TextBox textBox)
        {
            if (_size == 0)
            {
                textBox.AppendText("Куча пуста" + Environment.NewLine);
                return;
            }
            PrintTree(textBox, 0, 0);
        }

        private void PrintTree(TextBox textBox, int index, int level)
        {
            if (index >= _size) return;

            // Сначала правый потомок
            int rightChild = 2 * index + 2;
            PrintTree(textBox, rightChild, level + 1);

            // Текущий элемент с отступами
            textBox.AppendText(new string(' ', level * 4) + _heap[index] + Environment.NewLine);

            // Левый потомок
            int leftChild = 2 * index + 1;
            PrintTree(textBox, leftChild, level + 1);
        }

        public void print_to_console()
        {
            for (int i = 0; i < _size; ++i)
                Console.Write(_heap[i] + " ");
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
            foreach (T i in _heap)
                if (_comparer.Compare(node, i) == 0)
                    return true;
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
                yield return _heap[i];
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public bool Remove(T node)
        {
            for (int i = 0; i < _size; ++i )
                if (_comparer.Compare(node, _heap[i]) == 0)
                {
                    RemoveAt(i);
                    return true; 
                }
            return false;
        }
        private void Resize()
        {
            _capacity *= 2;  // Удваиваем ёмкость
            T[] newHeap = new T[_capacity];
            Array.Copy(_heap, newHeap, _heap.Length);
            _heap = newHeap;
        }
        private void RemoveAt(int index)
        {
            _size--;
            _heap[index] = _heap[_size];  // Заменяем удаляемый элемент последним
            _heap[_size] = default(T);    // Очищаем последнюю позицию
            HeapifyDown(index);           // Восстанавливаем свойства кучи
        }
        private void HeapifyDown(int index)
        {
            int leftChildIndex = get_lChild_index(index);
            int rightChildIndex = get_rChild_index(index);
            int largestIndex = index;  // Индекс максимального элемента

            // Сравниваем с левым потомком (должно быть < 0 для max-кучи)
            if (leftChildIndex < _size && _comparer.Compare(_heap[largestIndex], _heap[leftChildIndex]) < 0)
            {
                largestIndex = leftChildIndex;
            }

            // Сравниваем с правым потомком (должно быть < 0 для max-кучи)
            if (rightChildIndex < _size && _comparer.Compare(_heap[largestIndex], _heap[rightChildIndex]) < 0)
            {
                largestIndex = rightChildIndex;
            }

            // Если нашли большего потомка - меняем местами и продолжаем
            if (largestIndex != index)
            {
                Swap(index, largestIndex);
                HeapifyDown(largestIndex);
            }
        }

        private void HeapifyUp(int i)
        {
            int parentInd = get_parent_index(i);
            if (parentInd < 0) return;

            // Должно быть > 0 для max-кучи (текущий элемент больше родителя)
            if (_comparer.Compare(_heap[i], _heap[parentInd]) > 0)
            {
                Swap(i, parentInd);
                HeapifyUp(parentInd);
            }
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
