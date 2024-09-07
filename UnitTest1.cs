using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            listA.InsertInOrder(1);
            listA.InsertInOrder(3);
            listA.InsertInOrder(5);

            listB.InsertInOrder(2);
            listB.InsertInOrder(4);
            listB.InsertInOrder(6);

            ListaDoble resultado = new ListaDoble();
            resultado.MergeSorted(listA, listB, SortDirection.Asc);

            Assert.AreEqual(1, resultado.GetFirst());
            Assert.AreEqual(6, resultado.GetLast());
        }

        [TestMethod]
        public void TestMergeSortedDescending()
        {
            ListaDoble listA = new ListaDoble();
            ListaDoble listB = new ListaDoble();

            listA.InsertInOrder(1);
            listA.InsertInOrder(3);
            listA.InsertInOrder(5);

            listB.InsertInOrder(2);
            listB.InsertInOrder(4);
            listB.InsertInOrder(6);

            ListaDoble resultadoDesc = new ListaDoble();
            resultadoDesc.MergeSorted(listA, listB, SortDirection.Desc);

            Assert.AreEqual(6, resultadoDesc.GetFirst());
            Assert.AreEqual(1, resultadoDesc.GetLast());
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
            resultado.MergeSorted(null, listB, SortDirection.Asc);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMergeSortedWithNullListB()
        {
            ListaDoble listA = new ListaDoble();
            listA.InsertInOrder(2);

            ListaDoble resultado = new ListaDoble();
            resultado.MergeSorted(listA, null, SortDirection.Asc);
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
    }
}
