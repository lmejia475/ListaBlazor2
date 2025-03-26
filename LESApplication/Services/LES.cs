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


        public string InsertarDespuesDePosicion(int posicion, Nodo nuevoNodo)
        {
            Nodo aux = new Nodo();
            aux = PrimerNodo;
            int contador = 1;

            while (aux != null)
            {

                if (contador == posicion)
                {
                    nuevoNodo.Referencia = aux.Referencia;
                    aux.Referencia = nuevoNodo;
                    return $"Se insertó el nodo en la posicion {posicion}";
                }
                aux = aux.Referencia;
                contador++;
            }
            return "Error al insertar el nodo";
        }

        public string RecorrerRecursivo(Nodo? nodo)
        {
            if (nodo == null)
            {
                return "null";
            }

            return nodo.ToString() + RecorrerRecursivo(nodo.Referencia);
        }

        public string EliminarNodoDespuesDeX(string valorX)
        {
            if (PrimerNodo == null)
                return "La lista está vacía.";

            Nodo nodoTemporal = PrimerNodo;

            //buscar nodo para eliminarlo
            while (nodoTemporal != null && nodoTemporal.Informacion != valorX)
            {
                nodoTemporal = nodoTemporal.Referencia;
            }

            if (nodoTemporal == null)
                return $"Nodo '{valorX}' no encontrado.";

            if (nodoTemporal.Referencia == null)
                return $"No hay un nodo después de '{valorX}' para eliminar.";

            //eliminacion nodo
            Nodo nodoAEliminar = nodoTemporal.Referencia;
            nodoTemporal.Referencia = nodoAEliminar.Referencia; 

            return $"Nodo '{nodoAEliminar.Informacion}' eliminado después de '{valorX}'.";
        }

        public string EliminarNodoEnPosicion(int posicion)
        {
            if (PrimerNodo == null)
                return "La lista está vacía.";

            if (posicion <= 0)
                return "La posición debe ser mayor a 0.";

            if (posicion == 1)
            {
                PrimerNodo = PrimerNodo.Referencia;
                return "Primer nodo eliminado.";
            }

            Nodo nodoTemporal = PrimerNodo;
            int contador = 1;

            while (nodoTemporal.Referencia != null && contador < posicion - 1)
            {
                nodoTemporal = nodoTemporal.Referencia;
                contador++;
            }

            if (nodoTemporal.Referencia == null)
                return "Posición fuera de rango.";

            Nodo nodoAEliminar = nodoTemporal.Referencia;
            nodoTemporal.Referencia = nodoAEliminar.Referencia; 

            return $"Nodo en posición {posicion} eliminado.";
        }
    }
}
