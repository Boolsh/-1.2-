using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HeapSolution
{

    public class LinkedHeap<T> : IHeap<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public int Index { get; set; } 
            public Node Parent { get; set; } 

            public Node(T data, int index)
            {
                Data = data;
                Index = index;
            }
        }

        private Node _head, _tail;
        private readonly IComparer<T> _comparer;
        private int _size;

        public void CopyTo(IHeap<T> targetHeap)
        {
            if (targetHeap == null) throw new ArgumentNullException(nameof(targetHeap));

            targetHeap.Clear();
            Node current = _head;
            while (current != null)
            {
                targetHeap.Add(current.Data);
                current = current.Next;
            }
        }
        public void PrintSimple()
        {
            Node cur = _head;
            while (cur != null)
            {
                Console.Write(cur.Data + " ");
                cur = cur.Next;
            }
            Console.WriteLine();
            //Console.WriteLine(_head.Data);
            //Console.WriteLine(_size);
        }
        public void PrintHorizontal(TextBox textBox)
        {
            if (_head == null)
            {
                textBox.AppendText("Куча пуста" + Environment.NewLine);
                return;
            }

            List<T> elements = new List<T>();
            Node current = _head;
            while (current != null)
            {
                elements.Add(current.Data);
                current = current.Next;
            }

            PrintTree(textBox, elements, 0, 0);
        }

        private void PrintTree(TextBox textBox, List<T> elements, int index, int level)
        {
            if (index >= elements.Count) return;

            int rightChild = 2 * index + 2;
            PrintTree(textBox, elements, rightChild, level + 1);

            textBox.AppendText(new string(' ', level * 4) + elements[index] + Environment.NewLine);

            int leftChild = 2 * index + 1;
            PrintTree(textBox, elements, leftChild, level + 1);
        }

        public LinkedHeap(IComparer<T> comparer = null)
        {
            _comparer = comparer ?? Comparer<T>.Default;

        }
        public int Count => _size;

        public bool isEmpty => _size == 0;

        public IEnumerable<T> nodes
        {
            get
            {
                Node current = _head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }
        public void Add(T item)
        {
            var newNode = new Node(item, _size);

            if (_head == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }

            _size++;
            HeapifyUp(_tail);
        }

        public void Clear()
        {
            _head = _tail = null;
            _size = 0;
        }

        public bool Contains(T item)
        {
            Node current = _head;
            while (current != null) 
            {
                if (_comparer.Compare(current.Data, item) == 0)
                    return true;
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            if (_size == 0) return false;

            Node nodeToRemove = FindNode(item);
            if (nodeToRemove == null) return false;

            nodeToRemove.Data = _tail.Data;

            RemoveLastNode();

            HeapifyDown(nodeToRemove);

            return true;
        }

        private void HeapifyUp(Node node)
        {
            while (node.Index > 0)
            {
                int parentIndex = (node.Index - 1) / 2;
                Node parent = GetNodeAt(parentIndex);

                if (_comparer.Compare(node.Data, parent.Data) <= 0) break;

                SwapNodes(node, parent);
                node = parent;
            }
        }

        private void HeapifyDown(Node node)
    {
        while (true)
        {
            int leftChildIndex = 2 * node.Index + 1;
            int rightChildIndex = 2 * node.Index + 2;
            
            Node largest = node;
            
            if (leftChildIndex < _size)
            {
                Node leftChild = GetNodeAt(leftChildIndex);
                if (_comparer.Compare(leftChild.Data, largest.Data) > 0)
                    largest = leftChild;
            }
            
            if (rightChildIndex < _size)
            {
                Node rightChild = GetNodeAt(rightChildIndex);
                if (_comparer.Compare(rightChild.Data, largest.Data) > 0)
                    largest = rightChild;
            }
            
            if (largest == node) break;
            
            SwapNodes(node, largest);
            node = largest;
        }
    }

    private Node FindNode(T item)
    {
        Node current = _head;
        while (current != null)
        {
            if (_comparer.Compare(current.Data, item) == 0)
                return current;
            current = current.Next;
        }
        return null;
    }

    private void RemoveLastNode()
    {
        if (_size == 1)
        {
            _head = _tail = null;
        }
        else
        {
            Node newTail = GetNodeAt(_size - 2);
            newTail.Next = null;
            _tail = newTail;
        }
        _size--;
    }
    private Node GetNodeAt(int index)
    {
        if (index < 0 || index >= _size) return null;

        Node current = _head;
        while (current != null && current.Index != index)
        {
            current = current.Next;
        }
        return current;
    }
        private void SwapNodes(Node a, Node b)
    {
        T temp = a.Data;
        a.Data = b.Data;
        b.Data = temp;
    }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
