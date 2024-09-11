using System;

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
            else if (value <= cabeza.Valor)
            {
                nuevo.Siguiente = cabeza;
                cabeza.Anterior = nuevo;
                cabeza = nuevo;
            }
            else if (value >= cola.Valor)
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
            AdjustCentralNode();
        }

        public int GetMiddle()
        {
            if (cabeza == null)
            {
                throw new InvalidOperationException("La lista está vacía.");
            }

            return nodoCentral.Valor;
        }
        public void AdjustCentralNode()
        {
            if (tamaño == 0)
            {
                nodoCentral = null;
                return;
            }

            Nodo temporal = cabeza;
            int middleIndex = tamaño / 2;

            for (int i = 0; i < middleIndex; i++)
            {
                temporal = temporal.Siguiente;
            }

            nodoCentral = temporal;
        }
        public int DeleteFirst()
        {
            if (cabeza == null)
                throw new InvalidOperationException("La lista está vacía");

            int valorEliminado = cabeza.Valor;

            if (cabeza == cola)
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
            AdjustCentralNode();
            return valorEliminado;
        }

        public int DeleteLast()
        {
            if (cola == null)
                throw new InvalidOperationException("La lista está vacía");

            int valorEliminado = cola.Valor;

            if (cabeza == cola)
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
            AdjustCentralNode();
            return valorEliminado;
        }

        public bool DeleteValue(int value)
        {
            if (cabeza != null)
                return false;

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

                tamaño--;
                AdjustCentralNode();
                return true;
            }
        }

        public Nodo GetFirstNode()
        {
            return cabeza;
        }

        public void MergeSorted(IList listA, IList listB, ListaDoble mergedList, SortDirection direction)
        {
            if (direction == SortDirection.Asc)
            {
                MergeSortedAsceding(listA, listB, mergedList);
            }
            else if (direction == SortDirection.Desc)
            {
                MergeSortedAsceding(listA, listB, mergedList);
                Invert(mergedList);
            }
        }

        public void MergeSortedAsceding(IList listA, IList listB, ListaDoble mergedList)
        {
            if (listA == null || listB == null || mergedList == null)
                throw new ArgumentNullException("Las listas no pueden ser nulas.");

            Nodo nodoA = listA.GetFirstNode();
            Nodo nodoB = listB.GetFirstNode();

            mergedList.Clear(); 

            while (nodoA != null && nodoB != null)
            {
                if (nodoA.Valor <= nodoB.Valor)
                {
                    mergedList.InsertInOrder(nodoA.Valor);
                    nodoA = nodoA.Siguiente;
                }
                else
                {
                    mergedList.InsertInOrder(nodoB.Valor);
                    nodoB = nodoB.Siguiente;
                }
            }

            // Insertar nodos restantes de listA si quedan
            while (nodoA != null)
            {
                mergedList.InsertInOrder(nodoA.Valor);
                nodoA = nodoA.Siguiente;
            }

            // Insertar nodos restantes de listB si quedan
            while (nodoB != null)
            {
                mergedList.InsertInOrder(nodoB.Valor);
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
            if (lista == null)
            {
                throw new InvalidOperationException("No se puede invertir una lista nula.");
            }

            if (lista.cabeza == null)
            {
                return;
            }
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

        public void Insert(int value)
        {
            Nodo nuevo = new Nodo(value);

            if (cabeza == null)
            {
                cabeza = nuevo;
                cola = nuevo;
                nodoCentral = nuevo;
            }
            else
            {
                cola.Siguiente = nuevo;
                nuevo.Anterior = cola;
                cola = nuevo;
            }

            tamaño++;

            if (tamaño % 2 == 0)
            {
                nodoCentral = nodoCentral.Siguiente;
            }
        }
    }
}


