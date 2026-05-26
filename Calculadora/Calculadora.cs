using System.Dynamic;

namespace EspacioCalculadora
{
    public class Calculadora
    {
        private double dato;
        double Resultado
        {
            get {return dato;}
        }

        void Set (double valor)
        {
            dato = valor;
        }
        void Sumar(double termino)
        {
            dato += termino;
        }
        void Restar(double termino)
        {
            dato -= termino;
        }
        void Multiplicar(double termino)
        {
            dato *= termino;
        }
        void Dividir(double termino)
        {
            if(termino > 0)
            {
                dato /= termino;
            } else
            {
                Console.WriteLine("No se puede dividir en 0.");
            }
        }
        void Limpiar()
        {
            dato = 0;
        }
    }
}