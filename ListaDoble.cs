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
        private Nodo cabeza;
        private Nodo cola;
        private int tamaño;
        public ListaDoble()
        {
            cabeza = null;
            cola = null;
            tamaño = 0;
        }
        public void InsertInOrder(int value)
        {
            Nodo nuevo = new Nodo(value);

            if (cabeza == null)
            {
                // Si la lista está vacía
                cabeza = nuevo;
                cola = nuevo;
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
                // Insertar en el medio
                Nodo temporal = cabeza;

                while (temporal != null && temporal.Valor < value)
                {
                    temporal = temporal.Siguiente;
                }

                // Insertar nuevo nodo antes de "temporal"
                nuevo.Siguiente = temporal;
                nuevo.Anterior = temporal.Anterior;
                temporal.Anterior.Siguiente = nuevo;
                temporal.Anterior = nuevo;
            }
            tamaño++;
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

        public int DeleteFirst()
        {
            VerifyList();
            if (cabeza == cola)
            {
                cabeza = null;
                cola = null;
            }
            cabeza = cabeza.Siguiente;
            cabeza.Anterior = null;
            return cabeza.Valor;
        }

        public int DeleteLast()
        {
            VerifyList();
            if (cabeza == cola)
            {
                cabeza = null;
                cola = null;
            }
            else
            {
                cola.Anterior = cola;
                cola.Siguiente = null;
            }

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
                while (temporal!= null &&temporal.Valor != value)
                {
                    temporal = temporal.Siguiente;
                }
                if (temporal == null)
                    return false;
                
                temporal.Anterior.Siguiente = temporal.Siguiente;
                temporal.Siguiente.Anterior = temporal.Anterior;
                return true;
            }

        }

        public bool VerifyList()
        {
            if (cola == null) { 
                throw new InvalidOperationException("La lista está vacía");
            }
            else
            {
                return true;
            }
        }

        public int GetMiddle()
        {
            if (cabeza == null)
                throw new InvalidOperationException("La lista está vacía");

            Nodo slow = cabeza;
            Nodo fast = cabeza;

            // El puntero rápido avanza dos pasos a la vez, y el lento avanza uno
            while (fast != null && fast.Siguiente != null)
            {
                slow = slow.Siguiente;
                fast = fast.Siguiente.Siguiente;
            }

            // Cuando fast alcanza el final, slow estará en el nodo del medio
            return slow.Valor;
        }
        

        public void MergeSorted(IList listA, IList listB, SortDirection direction)
        {
            if (listA == null)
            {
                throw new ArgumentNullException(nameof(listA), "La lista A no puede ser null.");
            }
            if (listB == null)
            {
                throw new ArgumentNullException(nameof(listB), "La lista B no puede ser null.");
            }

            ListaDoble resultado = new ListaDoble();
            Nodo cabezaA = listA.GetFirstNode();
            Nodo cabezaB = listB.GetFirstNode();
            int i = 0;  //para listA
            int j = 0;  // para list B

            while (cabezaA != null && cabezaB != null)
            {
                if (direction == SortDirection.Asc)
                {
                    if ( cabezaA.Valor <= cabezaB.Valor)
                    {
                        resultado.InsertInOrder(cabezaA.Valor);
                        cabezaA = cabezaA.Siguiente;
                    }
                    else
                    {
                        resultado.InsertInOrder(cabezaB.Valor);
                        cabezaB = cabezaB.Siguiente;
                    }
                }
                else
                {
                    if (cabezaA.Valor >= cabezaB.Valor)
                    {
                        resultado.InsertInOrder(cabezaA.Valor);
                        cabezaA = cabezaA.Siguiente;
                    }
                    else
                    {
                        resultado.InsertInOrder(cabezaB.Valor);
                        cabezaB = cabezaB.Siguiente;
                    }
                }
            }

            while (cabezaA != null)
            {
                resultado.InsertInOrder(cabezaA.Valor);
                cabezaA = cabezaA.Siguiente;
            }
            while (cabezaB != null)
            {
                resultado.InsertInOrder(cabezaB.Valor);
                cabezaB = cabezaB.Siguiente;
            }


        }

    }
}
