using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tarea2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInsertInOrder()
        {
            ListaDoble lista = new ListaDoble();

            lista.InsertInOrder(5);
            lista.InsertInOrder(10);

            Assert.AreEqual(5, lista.GetFirst());
            Assert.AreEqual(10, lista.GetLast());
        }

        [TestMethod]
        public void TestMergeSortedAscending()
        {
            ListaDoble listA = new ListaDoble();
            ListaDoble listB = new ListaDoble();
            ListaDoble mergedList = new ListaDoble();

            listA.InsertInOrder(1);
            listA.InsertInOrder(3);
            listA.InsertInOrder(5);

            listB.InsertInOrder(2);
            listB.InsertInOrder(4);
            listB.InsertInOrder(6);

            mergedList.MergeSorted(listA, listB, mergedList, SortDirection.Asc);

            Assert.AreEqual(1, mergedList.GetFirst());
            Assert.AreEqual(6, mergedList.GetLast());
        }

        [TestMethod]
        public void TestMergeSortedDescending()
        {
            // Inicializamos las listas
            ListaDoble listA = new ListaDoble();
            ListaDoble listB = new ListaDoble();
            ListaDoble mergedList = new ListaDoble();

            // Insertamos valores en orden ascendente en las listas
            listA.InsertInOrder(1);
            listA.InsertInOrder(3);
            listA.InsertInOrder(5);

            listB.InsertInOrder(2);
            listB.InsertInOrder(4);

            // Realizamos la fusión en orden descendente
            mergedList.MergeSorted(listA, listB, mergedList, SortDirection.Desc);

            // Verificamos que la cabeza tenga el valor más alto (5) y la cola el más bajo (1)
            Assert.AreEqual(5, mergedList.cabeza.Valor); // La cabeza debe ser 5
            Assert.AreEqual(1, mergedList.cola.Valor);   // La cola debe ser 1

            // Verificamos todos los valores en orden descendente: 5, 4, 3, 2, 1
            Nodo actual = mergedList.cabeza;
            int[] valoresEsperados = { 5, 4, 3, 2, 1 };
            int indice = 0;

            while (actual != null)
            {
                Assert.AreEqual(valoresEsperados[indice], actual.Valor);
                actual = actual.Siguiente;
                indice++;
            }
        }



        [TestMethod]
        public void TestDeleteFirst()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(5);
            lista.InsertInOrder(10);

            lista.DeleteFirst();

            Assert.AreEqual(10, lista.GetFirst());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMergeSortedWithNullListA()
        {
            ListaDoble listB = new ListaDoble();
            listB.InsertInOrder(2);

            ListaDoble resultado = new ListaDoble();
            resultado.MergeSorted(null, listB, resultado, SortDirection.Asc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMergeSortedWithNullListB()
        {
            ListaDoble listA = new ListaDoble();
            listA.InsertInOrder(2);

            ListaDoble resultado = new ListaDoble();
            resultado.MergeSorted(listA, null, resultado, SortDirection.Asc);
        }

        [TestMethod]
        public void TestDeleteLast()
        {
            ListaDoble lista = new ListaDoble();
            lista.InsertInOrder(5);
            lista.InsertInOrder(10);

            lista.DeleteLast();

            Assert.AreEqual(5, lista.GetLast());
        }

        [TestMethod]
        public void TestInvert()
        {
            ListaDoble lista = new ListaDoble();

            lista.InsertInOrder(1);
            lista.InsertInOrder(3);
            lista.InsertInOrder(5);

            int cabeza = lista.GetFirst();

            lista.Invert(lista);

            Assert.AreEqual(cabeza, lista.GetLast());
        }

        [TestMethod]
        public void TestGetMiddleSingleNode()
        {
            ListaDoble lista = new ListaDoble();

            lista.InsertInOrder(5);

            Assert.AreEqual(5, lista.GetMiddle());
        }

        [TestMethod]
        public void TestGetMiddleEvenNodes()
        {
            ListaDoble lista = new ListaDoble();

            lista.InsertInOrder(1);
            lista.InsertInOrder(2);

            Assert.AreEqual(2, lista.GetMiddle());  // Cuando hay 2 elementos, el segundo debe ser el central
        }

        [TestMethod]
        public void TestGetMiddleImpares()
        {
            ListaDoble lista = new ListaDoble();

            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);

            Assert.AreEqual(2, lista.GetMiddle());  // En una lista de 3 elementos, el central es el segundo
        }

        [TestMethod]
        public void TestGetMiddlePares()
        {
            ListaDoble lista = new ListaDoble();

            lista.InsertInOrder(1);
            lista.InsertInOrder(2);
            lista.InsertInOrder(3);
            lista.InsertInOrder(4);
            lista.InsertInOrder(5);
            lista.InsertInOrder(6);

            Assert.AreEqual(3, lista.GetMiddle());  // En una lista de 3 elementos, el central es el segundo
        }


    }
    }
