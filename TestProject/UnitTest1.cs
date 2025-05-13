using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeapSolution;

namespace UnitTest1
{
    //[TestClass]
    //public class UnitTest1
    //{
    //    [TestMethod]
    //    public void TestStringHeap()
    //    {
    //        var heap = new ArrayHeap<string>();

    //        // Добавление элементов
    //        heap.Add("banana");
    //        heap.Add("apple");
    //        heap.Add("cherry");
    //        heap.Add("mango");
    //        heap.Add("pear");

    //        // Проверка наличия элементов
    //        Assert.IsTrue(heap.Contains("apple"));
    //        Assert.IsFalse(heap.Contains("grape"));

    //        // Проверка максимального элемента
    //        Assert.AreEqual("pear", heap.nodes.First());

    //        // Удаление и проверка
    //        Assert.IsTrue(heap.Remove("pear"));
    //        Assert.AreEqual("mango", heap.nodes.First());
    //    }

    //    [TestMethod]
    //    public void TestPersonHeapWithComparer()
    //    {
    //        var comparer = Comparer<Person>.Create((x, y) => x.Age.CompareTo(y.Age));
    //        var heap = new LinkedHeap<Person>(comparer);

    //        var people = new List<Person>
    //        {
    //            new Person("Alice", 25),
    //            new Person("Bob", 30),
    //            new Person("Charlie", 20),
    //            new Person("David", 35),
    //            new Person("Eve", 28)
    //        };

    //        // Добавление в кучу
    //        foreach (var person in people)
    //            heap.Add(person);

    //        // Проверка порядка (по возрасту)
    //        Assert.AreEqual("David : 35", heap.nodes.First().ToString());

    //        // Проверка удаления
    //        Assert.IsTrue(heap.Remove(new Person("David", 35)));
    //        Assert.AreEqual("Bob : 30", heap.nodes.First().ToString());
    //    }

    //    [TestMethod]
    //    public void TestPersonHeapWithIComparable()
    //    {
    //        var heap = new ArrayHeap<Person>();

    //        var people = new List<Person>
    //        {
    //            new Person("Alice", 25),
    //            new Person("Bob", 30),
    //            new Person("alice", 26), // Проверка регистронезависимого сравнения
    //            new Person("Charlie", 20)
    //        };

    //        foreach (var person in people)
    //            heap.Add(person);

    //        // Проверка порядка (по имени, затем по возрасту)
    //        var sorted = new List<Person>(heap.nodes);
    //        Assert.AreEqual("alice : 26", sorted[0].ToString());
    //        Assert.AreEqual("Alice : 25", sorted[1].ToString());
    //        Assert.AreEqual("Bob : 30", sorted[2].ToString());
    //        Assert.AreEqual("Charlie : 20", sorted[3].ToString());

    //        // Проверка удаления
    //        Assert.IsTrue(heap.Remove(new Person("alice", 26)));
    //        Assert.AreEqual(3, heap.Count);
    //    }

    //    [TestMethod]
    //    public void TestHeapOperations()
    //    {
    //        var heap = new ArrayHeap<int>();

    //        // Добавление и проверка размера
    //        heap.Add(5);
    //        heap.Add(3);
    //        heap.Add(8);
    //        Assert.AreEqual(3, heap.Count);

    //        // Проверка максимального элемента
    //        Assert.AreEqual(8, heap.nodes.First());

    //        // Удаление и проверка
    //        Assert.IsTrue(heap.Remove(8));
    //        Assert.AreEqual(5, heap.nodes.First());

    //        // Очистка
    //        heap.Clear();
    //        Assert.IsTrue(heap.isEmpty);
    //    }

    //    [TestMethod]
    //    public void TestEdgeCases()
    //    {
    //        var heap = new LinkedHeap<string>();

    //        // Пустая куча
    //        Assert.IsFalse(heap.Remove("none"));
    //        Assert.IsFalse(heap.Contains(""));

    //        // Один элемент
    //        heap.Add("single");
    //        Assert.IsTrue(heap.Contains("single"));
    //        Assert.IsTrue(heap.Remove("single"));
    //        Assert.IsTrue(heap.isEmpty);

    //        // Добавление дубликатов
    //        heap.Add("duplicate");
    //        heap.Add("duplicate");
    //        Assert.AreEqual(2, heap.Count);
    //        Assert.IsTrue(heap.Remove("duplicate"));
    //        Assert.AreEqual(1, heap.Count);
    //    }
    //}
    [TestClass]
    public class NumericHeapTests
    {
        [TestMethod]
        public void TestIntHeapOperations()
        {
            // 1. Инициализация и добавление элементов
            var heap = new ArrayHeap<int>();
            heap.Add(5);
            heap.Add(10);
            heap.Add(3);
            heap.Add(15);
            heap.Add(7);

            // 2. Проверка базовых свойств
            Assert.AreEqual(5, heap.Count);
            Assert.IsFalse(heap.isEmpty);
            Assert.AreEqual(15, heap.nodes.First()); // Максимальный элемент должен быть первым

            // 3. Проверка Contains
            Assert.IsTrue(heap.Contains(10));
            Assert.IsFalse(heap.Contains(99));

            // 4. Проверка правильности структуры кучи
            var expectedHeap = new List<int> { 15, 10, 3, 5, 7 };
            CollectionAssert.AreEqual(expectedHeap, heap.nodes.ToList());

            // 5. Тест удаления
            Assert.IsTrue(heap.Remove(15)); // Удаляем максимальный элемент
            Assert.AreEqual(10, heap.nodes.First()); // Новый максимум
            Assert.AreEqual(4, heap.Count);

            // 6. Проверка восстановления структуры после удаления
            var expectedAfterRemoval = new List<int> { 10, 7, 3, 5 };
            CollectionAssert.AreEqual(expectedAfterRemoval, heap.nodes.ToList());

            // 7. Тест очистки
            heap.Clear();
            Assert.AreEqual(0, heap.Count);
            Assert.IsTrue(heap.isEmpty);
        }

        [TestMethod]
        public void TestLinkedHeapWithNumbers()
        {
            var heap = new LinkedHeap<int>();

            // 1. Добавление в обратном порядке
            heap.Add(100);
            heap.Add(50);
            heap.Add(200);
            heap.Add(150);

            // 2. Проверка максимума
            Assert.AreEqual(200, heap.nodes.First());

            // 3. Последовательное извлечение (нестандартная операция, только для теста)
            var extracted = new List<int>();
            while (!heap.isEmpty)
            {
                var max = heap.nodes.First();
                heap.Remove(max);
                extracted.Add(max);
            }

            // 4. Проверка сортировки (должны извлекаться в убывающем порядке)
            var expectedOrder = new List<int> { 200, 150, 100, 50 };
            CollectionAssert.AreEqual(expectedOrder, extracted);
        }

        [TestMethod]
        public void TestHeapWithNegativeNumbers()
        {
            var heap = new ArrayHeap<int>();
            heap.Add(-5);
            heap.Add(-10);
            heap.Add(0);
            heap.Add(-20);
            heap.Add(5);

            // Проверка порядка
            var expectedOrder = new List<int> { 5, 0, -5, -10, -20 };
            CollectionAssert.AreEqual(expectedOrder, heap.nodes.ToList());

            // Проверка удаления
            Assert.IsTrue(heap.Remove(0));
            Assert.IsFalse(heap.Contains(0));
        }

        [TestMethod]
        public void TestDuplicateValues()
        {
            var heap = new LinkedHeap<int>();
            heap.Add(5);
            heap.Add(5);
            heap.Add(3);
            heap.Add(5);

            // Проверка количества
            Assert.AreEqual(4, heap.Count);

            // Удаление одного из дубликатов
            Assert.IsTrue(heap.Remove(5));
            Assert.AreEqual(3, heap.Count);
            Assert.IsTrue(heap.nodes.Contains(5)); // Должны остаться другие 5
        }
    }
}