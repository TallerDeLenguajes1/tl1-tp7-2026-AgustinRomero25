using System.Globalization;
using System.Runtime.Intrinsics.Arm;
using EspacioCalculadora;

Console.WriteLine("============================== Calculadora .NET====================================");

bool SecCheck;
int Eleccion;
string s1;
double dato;
bool Escape = false;

while(!Escape)
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

    switch(Eleccion)
    {
        
    }
}