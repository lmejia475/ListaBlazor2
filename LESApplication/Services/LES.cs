﻿using LESApplication.Models;

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
            return "Nodo agregado al inicio de la lista";
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


        public string AgregarNodoDespuesDeX(string x, string nuevoDato)
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

                return "Nodo agregado después de X";
            }
            else
            {
                return "Nodo X no encontrado";
            }
        }
        public string AgregarNodoAntesDeX(string x, string nuevoDato)
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

                return "Nodo agregado antes de X";
            }
            else
            {
                return "Nodo X no encontrado";
            }
        }


        public int ObtenerLongitud()
        {
            int longitud = 0;
            Nodo? actual = PrimerNodo;
            while (actual != null)
            {
                longitud++;
                actual = actual.Referencia;
            }
            return longitud;
        }

        public void AgregarEnPosicion(int posicion, string dato)
        {
            int longitud = ObtenerLongitud();

            if (posicion < 1 || posicion > longitud + 1)
            {
                throw new ArgumentException("La posición está fuera del rango.");
            }

            Nodo nuevoNodo = new Nodo(dato);

            if (posicion == 1)
            {
                nuevoNodo.Referencia = PrimerNodo;
                PrimerNodo = nuevoNodo;
            }
            else
            {
                Nodo? actual = PrimerNodo;
                int contador = 1;

                while (actual != null && contador < posicion - 1)
                {
                    actual = actual.Referencia;
                    contador++;
                }

                nuevoNodo.Referencia = actual.Referencia;
                actual.Referencia = nuevoNodo;

                if (posicion == longitud + 1)

                {
                    UltimoNodo = nuevoNodo;
                }
            }

      
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
                return; 
            }

            Nodo listaOrdenada = null;
            Nodo actual = PrimerNodo;

            while (actual != null)
            {
                Nodo siguiente = actual.Referencia;

                if (listaOrdenada == null || Comparar(actual.Informacion, listaOrdenada.Informacion) <= 0)
                {
                    
                    actual.Referencia = listaOrdenada;
                    listaOrdenada = actual;
                }
                else
                {
                    
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

       
        private int Comparar(string a, string b)
        {
           
            if (double.TryParse(a, out double numA) && double.TryParse(b, out double numB))
            {
                return numA.CompareTo(numB);
            }
           
            return string.Compare(a, b, StringComparison.OrdinalIgnoreCase);
        }

      
        public void AgregarAntesDePosicion(int posicion, string dato)
        {
            if (posicion <= 1)
            {
                AgregarEnPosicion(1, dato); 
            }
            else
            {
                AgregarEnPosicion(posicion - 1, dato); 
            }
        }

        public void AgregarDespuesDePosicion(int posicion, string dato)
        {
            AgregarEnPosicion(posicion + 1, dato); 
        }

    }
}
