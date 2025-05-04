using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace шарпы_1._2_лаба
{
    internal class HeapUtils<T>
    {

        public delegate bool CheckDelegate<T>(T date);
        public delegate IHeap<T> HeapConstructorDelegate<T>(IEnumerable<T> collection);
        public delegate void ActionDelegate<T>(T date);
        static bool Exists<T>(IHeap<T> heap, CheckDelegate<T> check) 
        {
            foreach (var i in heap)
                if (check(i)) return true;
            return false;

        }
        static IHeap<T> FindAll<T>(IHeap<T> heap, CheckDelegate<T> check, HeapConstructorDelegate<T> conDel) 
        {
            IHeap<T> res = conDel(null);
            foreach (var i in heap)
                if (check(i)) res.Add(i);
            return res; 
        }
        static void ForEach(IHeap<T> heap, ActionDelegate<T> actDel) 
        {
            foreach (var i in heap)
                actDel(i);
        }
        static bool CheckForAll<T>(IHeap<T> heap, CheckDelegate<T> check) 
        {
            foreach (var i in heap) 
                if (!check(i)) return false;
            return true;
        }
        //static readonly HeapConstructorDelegate<T> ArrayHeapConstructor = (collection) => 
        //{
        //    ArrayHeap<T> res = new ArrayHeap<T>();
        //    foreach (var i in collection)
        //        res.Add(i);
        //    return res;
        //};
        static readonly HeapConstructorDelegate<T> LinkedHeapConstructor = (collection) =>
        {
            LinkedHeap<T> res = new LinkedHeap<T>();
            foreach (var item in collection)
                res.Add(item);
            return res;
        };


    }
}

