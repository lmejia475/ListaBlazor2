using LESApplication.Models;
using System.ComponentModel.Design;

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
        public string AgregarNodoAntesDePosicion(int posicion, string valor)
        {
            if (PrimerNodo == null)
                return "La lista está vacía.";

            if (posicion <= 1) //Si posicion es 1 insertar al inicio
            {
                AgregarNodoInicio(new Nodo(valor));
                return $"Nodo '{valor}' agregado al inicio.";
            }

            Nodo nodoTemporal = PrimerNodo;
            int contador = 1; 

            //recorrido de posiciones
            while (nodoTemporal.Referencia != null && contador < posicion - 1)
            {
                nodoTemporal = nodoTemporal.Referencia;
                contador++;
            }

            if (contador != posicion - 1 || nodoTemporal.Referencia == null)
                return "Posición fuera de rango.";

            Nodo nuevoNodo = new Nodo(valor);
            nuevoNodo.Referencia = nodoTemporal.Referencia;
            nodoTemporal.Referencia = nuevoNodo;

            return $"Nodo '{valor}' agregado antes de la posición {posicion}.";
        }

        public string InsertarEnPosicion(int posicion, Nodo nuevoNodo)
        {
            Nodo aux = new Nodo();
            aux = PrimerNodo;
            int contador = 1;
            while (aux != null)
            {
                if (contador == 1 && posicion == 1)
                {
                    nuevoNodo.Referencia = PrimerNodo.Referencia;
                    PrimerNodo = nuevoNodo;
                    return $"Se insertó el nodo en la posicion {posicion}";

                }

                if (PrimerNodo.Referencia == null)
                {
                    return $"No se puede insertar en la posicion {posicion}";
                }

                else if (contador == posicion - 1)
                {
                    nuevoNodo.Referencia = aux.Referencia.Referencia;
                    aux.Referencia = nuevoNodo;
                    return $"Se insertó el nodo en la posicion {posicion}";
                }
                aux = aux.Referencia;
                contador++;               
            }
            return "Error al insertar el nodo";
        }

    }
}
