using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tarea2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMergeWithListANull()
        {
            ListaDoble listA = null;
            ListaDoble listB = new ListaDoble();
            listB.InsertInOrder(3);
            ListaDoble mergedList = new ListaDoble();
            mergedList.MergeSorted(listA, listB, mergedList, SortDirection.Asc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMergeWithListBNull()
        {
            ListaDoble listA = new ListaDoble();
            ListaDoble listB = null;
            listA.InsertInOrder(10);
            ListaDoble mergedList = new ListaDoble();
            mergedList.MergeSorted(listA, listB, mergedList, SortDirection.Asc);
        }

        [TestMethod]
        public void TestMergeAscendingOrder()
        {
            ListaDoble listA = new ListaDoble();
            ListaDoble listB = new ListaDoble();
            ListaDoble mergedList = new ListaDoble();

            listA.InsertInOrder(0);
            listA.InsertInOrder(2);
            listA.InsertInOrder(6);
            listA.InsertInOrder(10);
            listA.InsertInOrder(25);

            listB.InsertInOrder(3);
            listB.InsertInOrder(7);
            listB.InsertInOrder(11);
            listB.InsertInOrder(40);
            listB.InsertInOrder(50);

            mergedList.MergeSorted(listA, listB, mergedList, SortDirection.Asc);

            int[] expectedValues = { 0, 2, 3, 6, 7, 10, 11, 25, 40, 50 };
            Nodo current = mergedList.GetFirstNode();
            foreach (int expected in expectedValues)
            {
                Assert.AreEqual(expected, current.Valor);
                current = current.Siguiente;
            }
        }

        [TestMethod]
        public void TestMergeDescendingOrder()
        {
            ListaDoble listA = new ListaDoble();
            ListaDoble listB = new ListaDoble();
            ListaDoble mergedList = new ListaDoble();

            listA.InsertInOrder(10);
            listA.InsertInOrder(15);

            listB.InsertInOrder(9);
            listB.InsertInOrder(40);
            listB.InsertInOrder(50);

            mergedList.MergeSorted(listA, listB, mergedList, SortDirection.Desc);

            int[] expectedValues = { 50, 40, 15, 10, 9 };
            Nodo current = mergedList.GetFirstNode();
            foreach (int expected in expectedValues)
            {
                Assert.AreEqual(expected, current.Valor);
                current = current.Siguiente;
            }
        }

        [TestMethod]
        public void TestMergeDescendingWithEmptyListA()
        {
            ListaDoble listA = new ListaDoble(); // Vacía
            ListaDoble listB = new ListaDoble();
            ListaDoble mergedList = new ListaDoble();

            listB.InsertInOrder(9);
            listB.InsertInOrder(40);
            listB.InsertInOrder(50);

            mergedList.MergeSorted(listA, listB, mergedList, SortDirection.Desc);

            int[] expectedValues = { 50, 40, 9 };
            Nodo current = mergedList.GetFirstNode();
            foreach (int expected in expectedValues)
            {
                Assert.AreEqual(expected, current.Valor);
                current = current.Siguiente;
            }
        }

        [TestMethod]
        public void TestMergeAscendingWithEmptyListB()
        {
            ListaDoble listA = new ListaDoble();
            ListaDoble listB = new ListaDoble(); // Vacía
            ListaDoble mergedList = new ListaDoble();

            listA.InsertInOrder(10);
            listA.InsertInOrder(15);

            mergedList.MergeSorted(listA, listB, mergedList, SortDirection.Asc);

            int[] expectedValues = { 10, 15 };
            Nodo current = mergedList.GetFirstNode();
            foreach (int expected in expectedValues)
            {
                Assert.AreEqual(expected, current.Valor);
                current = current.Siguiente;
            }
        }


        //PROPLEMA 2 INVERT


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestInvertNullList()
        {
            ListaDoble lista = new ListaDoble();
            lista.Invert(null);
        }


        [TestMethod]
        public void TestInvertList()
        {
            ListaDoble lista = new ListaDoble();
            lista.Insert(1);
            lista.Insert(0);
            lista.Insert(30);
            lista.Insert(50);
            lista.Insert(2);

            lista.Invert(lista);

            int[] expectedValues = { 2, 50, 30, 0, 1 };
            Nodo current = lista.GetFirstNode();
            foreach (int expected in expectedValues)
            {
                Assert.AreEqual(expected, current.Valor);
                current = current.Siguiente;
            }
        }

        [TestMethod]
        public void TestInvertSingleNodeList()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(2);

            lista.Invert(lista);

            Assert.AreEqual(2, lista.GetFirstNode().Valor);
        }




        // PROBLEMA 3 GET MIDDLE

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestGetMiddleWithNullList()
        {
            ListaDoble lista = null; 
            lista.GetMiddle(); 
        }



        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestGetMiddleWithEmptyList()
        {
            ListaDoble lista = new ListaDoble(); 
            lista.GetMiddle();
        }

        [TestMethod]
        public void TestGetMiddleWithSingleNode()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(1);

            Assert.AreEqual(1, lista.GetMiddle());
        }

        [TestMethod]
        public void TestGetMiddleWithTwoNodes()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);

            Assert.AreEqual(2, lista.GetMiddle());
        }

        [TestMethod]
        public void TestGetMiddleWithThreeNodes()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);

            Assert.AreEqual(2, lista.GetMiddle());
        }

        [TestMethod]
        public void TestGetMiddleWithFourNodes()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);
            lista.InsertInOrder(4);

            Assert.AreEqual(3, lista.GetMiddle());
        }

    }
    }
