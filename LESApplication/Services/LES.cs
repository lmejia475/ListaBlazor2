using LESApplication.Models;

namespace LESApplication.Services
{
    public class LES
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }

        public LES()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }

        bool EstaVacia()
        {
            return PrimerNodo == null;
        }

        public string AgregarNodoFinal(Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.Referencia = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            return "Nodo agregado al final de la lista";
        }
        public string AgregarNodoInicio(Nodo nuevoNodo)
        {
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
            }
            return "Nodo agregado al final de la lista";
        }
        public Nodo? BuscarNodo(string x)
        {
            Nodo? actual = PrimerNodo;

            while (actual != null)
            {
                if (actual.Informacion == x)
                {
                    return actual;
                }
                actual = actual.Referencia;
            }

            Console.WriteLine("\nNodo no encontrado");
            return null;
        }


        public string AgregarNodoDespuesDeX(string x, String nuevoDato)
        {
            Nodo? nodoX = BuscarNodo(x);
            if (nodoX != null)
            {
                Nodo nuevoNodo = new Nodo(nuevoDato);
                nuevoNodo.Referencia = nodoX.Referencia;
                nodoX.Referencia = nuevoNodo;
                if (nodoX == UltimoNodo)
                {
                    UltimoNodo = nuevoNodo;
                }
            }
            else
            {
                return "Nodo X no encontrado";
            }
            return "Nodo agregado despues de x";
        }
        public string AgregarNodoAntesDeX(string x, String nuevoDato)
        {
            Nodo? nodoX = BuscarNodo(x);
            if (nodoX != null)
            {
                Nodo nuevoNodo = new Nodo(nuevoDato);
                if (nodoX == PrimerNodo)
                {
                    nuevoNodo.Referencia = PrimerNodo;
                    PrimerNodo = nuevoNodo;
                }
                else
                {
                    Nodo actual = PrimerNodo;
                    while (actual != null && actual.Referencia != nodoX)
                    {
                        actual = actual.Referencia;
                    }
                    if (actual != null)
                    {
                        nuevoNodo.Referencia = nodoX;
                        actual.Referencia = nuevoNodo;
                    }
                }
                return "Nodo Agregado antes de X";

            }
            else
            {
                return "Nodo X no encontrado";
            }

        }

        public string AgregarNodoDespuesDe5( String nuevoDato)
        {
            Nodo? nodoX = BuscarNodo("5");
            if (nodoX != null)
            {
                Nodo nuevoNodo = new Nodo(nuevoDato);
                nuevoNodo.Referencia = nodoX.Referencia;
                nodoX.Referencia = nuevoNodo;
                if (nodoX == UltimoNodo)
                {
                    UltimoNodo = nuevoNodo;
                }
            }
            else
            {
                return "Nodo X no encontrado";
            }
            return "Nodo agregado despues de x";
        }
        public string AgregarNodoAntesDe5(String nuevoDato)
        {
            Nodo? nodoX = BuscarNodo("5");
            if (nodoX != null)
            {
                Nodo nuevoNodo = new Nodo(nuevoDato);
                if (nodoX == PrimerNodo)
                {
                    nuevoNodo.Referencia = PrimerNodo;
                    PrimerNodo = nuevoNodo;
                }
                else
                {
                    Nodo actual = PrimerNodo;
                    while (actual != null && actual.Referencia != nodoX)
                    {
                        actual = actual.Referencia;
                    }
                    if (actual != null)
                    {
                        nuevoNodo.Referencia = nodoX;
                        actual.Referencia = nuevoNodo;
                    }
                }
                return "Nodo Agregado antes de X";

            }
            else
            {
                return "Nodo X no encontrado";
            }

        }
        public void OrdenarLista()
        {
            if (EstaVacia() || PrimerNodo.Referencia == null)
            {
                return; // La lista está vacía o tiene un solo elemento, ya está ordenada
            }

            Nodo listaOrdenada = null;
            Nodo actual = PrimerNodo;

            while (actual != null)
            {
                Nodo siguiente = actual.Referencia;

                if (listaOrdenada == null || Comparar(actual.Informacion, listaOrdenada.Informacion) <= 0)
                {
                    // Insertar al principio de la lista ordenada
                    actual.Referencia = listaOrdenada;
                    listaOrdenada = actual;
                }
                else
                {
                    // Buscar el punto de inserción en la lista ordenada
                    Nodo temp = listaOrdenada;
                    while (temp.Referencia != null && Comparar(actual.Informacion, temp.Referencia.Informacion) > 0)
                    {
                        temp = temp.Referencia;
                    }
                    actual.Referencia = temp.Referencia;
                    temp.Referencia = actual;
                }

                actual = siguiente;
            }

            // Actualizar PrimerNodo y UltimoNodo
            PrimerNodo = listaOrdenada;
            UltimoNodo = listaOrdenada;
            if (UltimoNodo != null)
            {
                while (UltimoNodo.Referencia != null)
                {
                    UltimoNodo = UltimoNodo.Referencia;
                }
            }
        }

        // Método auxiliar para comparar strings como números si es posible
        private int Comparar(string a, string b)
        {
            // Intentar convertir a números
            if (double.TryParse(a, out double numA) && double.TryParse(b, out double numB))
            {
                return numA.CompareTo(numB);
            }
            // Si no son números, comparar como strings
            return string.Compare(a, b, StringComparison.OrdinalIgnoreCase);
        }
    }
}
