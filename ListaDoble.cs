using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using System.ComponentModel;

namespace Tarea2
{
    public class Nodo
    {
        public int Valor { get; set; }
        public Nodo Anterior { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(int valor)
        {
            Valor = valor;
            Anterior = null;
            Siguiente = null;
        }
    }

    public class ListaDoble : IList
    {
        public Nodo cabeza;
        public Nodo cola;
        private int tamaño;
        private Nodo nodoCentral;

        public ListaDoble()
        {
            cabeza = null;
            cola = null;
            tamaño = 0;
            nodoCentral = null;
        }

        public void InsertInOrder(int value)
        {
            Nodo nuevo = new Nodo(value);

            if (cabeza == null)
            {
                cabeza = nuevo;
                cola = nuevo;
                nodoCentral = nuevo;  
            }
            else if (value <= cabeza.Valor) //insertar al inicio
            {
                nuevo.Siguiente = cabeza;
                cabeza.Anterior = nuevo;
                cabeza = nuevo;
            }
            else if (value >= cola.Valor) // insertar al final
            {
                cola.Siguiente = nuevo;
                nuevo.Anterior = cola;
                cola = nuevo;
            }
            else
            {
                Nodo temporal = cabeza;

                while (temporal != null && temporal.Valor < value)
                {
                    temporal = temporal.Siguiente;
                }

                nuevo.Siguiente = temporal;
                nuevo.Anterior = temporal.Anterior;
                temporal.Anterior.Siguiente = nuevo;
                temporal.Anterior = nuevo;
            }

            tamaño++;

            // Ajustar nodo central
            if (tamaño % 2 == 0)
            {
                nodoCentral = nodoCentral.Siguiente; // Mueve hacia adelante en tamaño par
            }
        }

        public int GetMiddle()
        {
            if (cabeza == null)
                throw new InvalidOperationException("La lista está vacía");

            Nodo slow = cabeza;
            Nodo fast = cabeza;

            while (fast != null && fast.Siguiente != null)
            {
                slow = slow.Siguiente;
                fast = fast.Siguiente.Siguiente;
            }

            if (tamaño % 2 == 0)
            {
                slow = slow.Anterior;
            }

            return slow.Valor;
        }
        public int DeleteFirst()
        {
            if (cabeza == null)
                throw new InvalidOperationException("La lista está vacía");

            int valorEliminado = cabeza.Valor;

            if (cabeza == cola) // Si solo hay un nodo
            {
                cabeza = null;
                cola = null;
                nodoCentral = null;
            }
            else
            {
                cabeza = cabeza.Siguiente;
                cabeza.Anterior = null;
            }

            tamaño--;

            // Ajustar nodo central
            if (tamaño % 2 == 0 && nodoCentral != null)
            {
                nodoCentral = nodoCentral.Anterior;
            }

            return valorEliminado; // Retorna el valor eliminado
        }


        public int DeleteLast()
        {
            if (cabeza == null)
                throw new InvalidOperationException("La lista está vacía");

            int valorEliminado = cola.Valor;

            if (cabeza == cola) // Si solo hay un nodo
            {
                cabeza = null;
                cola = null;
                nodoCentral = null;
            }
            else
            {
                cola = cola.Anterior;
                cola.Siguiente = null;
            }

            tamaño--;

            // Ajustar nodo central
            if (tamaño % 2 == 0 && nodoCentral != null)
            {
                nodoCentral = nodoCentral.Anterior;
            }

            return valorEliminado; // Retorna el valor eliminado
        }


        public int GetFirst()
        {
            VerifyList();
            return cabeza.Valor;
        }

        public Nodo GetFirstNode()
        {
            VerifyList();
            return cabeza;
        }

        public int GetLast()
        {
            VerifyList();
            return cola.Valor;
        }

        public bool DeleteValue(int value)
        {
            VerifyList();
            if (cabeza.Valor == value)
            {
                DeleteFirst();
                return true;
            }
            else if (cola.Valor == value)
            {
                DeleteLast();
                return true;
            }
            else
            {
                Nodo temporal = cabeza.Siguiente;
                while (temporal != null && temporal.Valor != value)
                {
                    temporal = temporal.Siguiente;
                }
                if (temporal == null) return false;

                temporal.Anterior.Siguiente = temporal.Siguiente;
                if (temporal.Siguiente != null)
                {
                    temporal.Siguiente.Anterior = temporal.Anterior;
                }
                return true;
            }
        }

        public bool VerifyList()
        {
            return cabeza != null;
        }

        public void InsertAtEnd(int value)
        {
            Nodo nuevo = new Nodo(value);
            if (cabeza == null)
            {
                cabeza = nuevo;
                cola = nuevo;
            }
            else
            {
                cola.Siguiente = nuevo;
                nuevo.Anterior = cola;
                cola = nuevo;
            }
            tamaño++;
        }
        public void InsertAtStart(int value)
        {
            Nodo nuevo = new Nodo(value);
            if (cabeza == null)
            {
                cabeza = nuevo;
                cola = nuevo;
            }
            else
            {
                nuevo.Siguiente = cabeza;
                cabeza.Anterior = nuevo;
                cabeza = nuevo;
            }
            tamaño++;
        }
        public void MergeSorted(IList listA, IList listB, ListaDoble mergedList, SortDirection direction)
        {
            if (listA == null || listB == null || mergedList == null)
                throw new ArgumentNullException("Las listas no pueden ser nulas.");

            if (listA.GetFirstNode() == null && listB.GetFirstNode() == null)
                throw new InvalidOperationException("Ambas listas están vacías.");

            Nodo nodoA = listA.GetFirstNode();
            Nodo nodoB = listB.GetFirstNode();

            mergedList.Clear();

            while (nodoA != null && nodoB != null)
            {
                if (direction == SortDirection.Asc)
                {
                    // Orden ascendente: insertar al final
                    if (nodoA.Valor <= nodoB.Valor)
                    {
                        mergedList.InsertAtEnd(nodoA.Valor);
                        nodoA = nodoA.Siguiente;
                    }
                    else
                    {
                        mergedList.InsertAtEnd(nodoB.Valor);
                        nodoB = nodoB.Siguiente;
                    }
                }
                else
                {
                    // Orden descendente: insertar al inicio
                    if (nodoA.Valor >= nodoB.Valor)
                    {
                        mergedList.InsertAtStart(nodoA.Valor);
                        nodoA = nodoA.Siguiente;
                    }
                    else
                    {
                        mergedList.InsertAtStart(nodoB.Valor);
                        nodoB = nodoB.Siguiente;
                    }
                }
            }

            // Insertar los nodos restantes de listA en la lista fusionada
            while (nodoA != null)
            {
                if (direction == SortDirection.Asc)
                {
                    mergedList.InsertAtEnd(nodoA.Valor);
                }
                else
                {
                    mergedList.InsertAtStart(nodoA.Valor);  // Para orden descendente, insertar al inicio
                }
                nodoA = nodoA.Siguiente;
            }

            // Insertar los nodos restantes de listB en la lista fusionada
            while (nodoB != null)
            {
                if (direction == SortDirection.Asc)
                {
                    mergedList.InsertAtEnd(nodoB.Valor);
                }
                else
                {
                    mergedList.InsertAtStart(nodoB.Valor);  // Para orden descendente, insertar al inicio
                }
                nodoB = nodoB.Siguiente;
            }
        }





        public void Clear()
        {
            cabeza = null;
            cola = null;
            tamaño = 0;
        }

        public void Invert(ListaDoble lista)
        {
            if (cabeza == null) throw new InvalidOperationException("La lista está vacía");

            Nodo temporal = null;
            Nodo actual = lista.cabeza;
            while (actual != null)
            {
                temporal = actual.Anterior;
                actual.Anterior = actual.Siguiente;
                actual.Siguiente = temporal;
                actual = actual.Anterior;
            }

            if (temporal != null)
            {
                lista.cola = lista.cabeza;
                lista.cabeza = temporal.Anterior;
            }
        }


    }
}
