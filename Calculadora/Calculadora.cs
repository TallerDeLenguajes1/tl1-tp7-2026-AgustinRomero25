using System.Dynamic;

namespace EspacioCalculadora
{
    public class Calculadora
    {
        private double dato;
        public double Resultado
        {
            get {return dato;}
            set {dato = value;}
        }

        public double Sumar(double termino)
        {
            dato += termino;
            return dato;
        }
        public double Restar(double termino)
        {
            dato -= termino;
            return dato;
        }
        public double Multiplicar(double termino)
        {
            dato *= termino;
            return dato;
        }
        public double Dividir(double termino)
        {
            if(termino > 0)
            {
                dato /= termino;
                return dato;
            } else
            {
                Console.WriteLine("No se puede dividir en 0.");
                return 0;
            }
        }
        public void Limpiar()
        {
            dato = 0;
            Resultado = 0;
        }
    }
}