using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static HeapSolution.HeapUtils<T>;

namespace HeapSolution
{
    internal class HeapUtils<T>
    {

        public delegate bool CheckDelegate<T>(T date);
        public delegate IHeap<T> HeapConstructorDelegate<T>(IEnumerable<T> collection);
        public delegate void ActionDelegate<T>(T date);
        public delegate TO ConvertDelegate<TI, TO>(TI elem);
        public static bool Exists<T>(IHeap<T> heap, CheckDelegate<T> check) 
        {
            foreach (var i in heap)
                if (check(i)) return true;
            return false;

        }
        public static IHeap<T> FindAll(IHeap<T> heap, CheckDelegate<T> check, HeapConstructorDelegate<T> constructor)
        {
            if (heap == null || heap.isEmpty)
                return constructor(new List<T>()); // Возвращаем пустую кучу

            List<T> filteredItems = new List<T>();
            foreach (var item in heap)
            {
                if (check(item))
                    filteredItems.Add(item);
            }

            return constructor(filteredItems);
        }

        public static void ForEach(IHeap<T> heap, ActionDelegate<T> actDel) 
        {
            foreach (var i in heap)
                actDel(i);
        }
        //public static IList<TO> ConvertAll<TI, TO>(IList<TI> inputList, ConvertDelegate<TI, TO> converter, HeapConstructorDelegate<TO> constructor)
        //{
        //    LinkedList<TO> convertedList = new LinkedList<TO>();
        //    foreach (var item in inputList)
        //    {
        //        convertedList.Add(converter(item));
        //    }
        //    return constructor(convertedList);
        //}
        public static bool CheckForAll<T>(IHeap<T> heap, CheckDelegate<T> check) 
        {
            foreach (var i in heap) 
                if (!check(i)) return false;
            return true;
        }
        public static readonly HeapConstructorDelegate<T> ArrayHeapConstructor = collection =>
        {
            var heap = new ArrayHeap<T>();
            if (collection != null)
            {
                foreach (var item in collection)
                    heap.Add(item);
            }
            return heap;
        };

        public static readonly HeapConstructorDelegate<T> LinkedHeapConstructor = collection =>
        {
            var heap = new LinkedHeap<T>();
            if (collection != null)
            {
                foreach (var item in collection)
                    heap.Add(item);
            }
            return heap;
        };


    }
}

