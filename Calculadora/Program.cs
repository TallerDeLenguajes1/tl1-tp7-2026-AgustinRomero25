using System.Dynamic;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using EspacioCalculadora;

Console.WriteLine("============================== Calculadora .NET ====================================");

bool SecCheck;
int Eleccion;
string s1;
double dato;
bool Escape = false;
double result;
double datoInicial;

Calculadora C = new Calculadora ();

do
{
    Console.WriteLine("Ingrese el dato inicial:");
    s1 = Console.ReadLine();
    SecCheck = double.TryParse(s1, CultureInfo.InvariantCulture, out datoInicial);
    if(!SecCheck)
    {
        Console.WriteLine("Error. Ingrese un numero valido.");
    }
} while(!SecCheck);
C.Resultado = datoInicial;

while(!Escape)
{

    do
    {
        Console.WriteLine("¿Que operacion desea realizar?\n(1) Suma\n(2) Resta\n(3) Multiplicacion\n(4) Division\n(5) Limpiar\n(6) Terminar");
        s1 = Console.ReadLine();
        SecCheck = int.TryParse(s1, CultureInfo.InvariantCulture, out Eleccion);
        if(!SecCheck && Eleccion >= 0 && Eleccion <= 6)
        {
            Console.WriteLine("Error. Ingrese un numero valido.");
        }

    } while(!SecCheck && Eleccion >= 0 && Eleccion <= 6);

    if(Eleccion == 6)
    {
        Escape = true;
        Console.WriteLine("Procesamiento Terminado.");
    } else
    {  
        do
        {
            Console.WriteLine("Ingrese el numero a trabajar:");
            s1 = Console.ReadLine();
            SecCheck = double.TryParse(s1, CultureInfo.InvariantCulture, out dato);
            if(!SecCheck)
            {
                Console.WriteLine("Error. Ingrese un numero valido.");
            }
        } while(!SecCheck);


        switch(Eleccion)
        {
            case 1:
                result = C.Sumar(dato);
                Console.WriteLine($"El resultado es: {result}");
            break;

            case 2:
                result = C.Restar(dato);
                Console.WriteLine($"El resultado es: {result}");
            break;

            case 3:
                result = C.Multiplicar(dato);
                Console.WriteLine($"El resultado es: {result}");
            break;

            case 4:
                result = C.Dividir(dato);
                Console.WriteLine($"El resultado es: {result}");
            break;

            case 5:
                C.Limpiar();
                Console.WriteLine("El resultado es: 0");
            break;
        }
    }

}