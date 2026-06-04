using System.Globalization;
using EspacioCalculos;

Console.WriteLine("------------------------------- Sistema Personal para Empleados ---------------------------");
string s1;
bool SecCheck;
double antiguedad;
int edad;
int faltaParaJubilarseAños;
bool esJubilado;
double sueldoBasico;
string estadoCivil;
string cargo;


Empleado C = new Empleado ();

do
{
    Console.WriteLine("Ingrese la antiguedad del empleado:");
    s1 = Console.ReadLine();
    SecCheck = double.TryParse(s1, CultureInfo.InvariantCulture, out antiguedad);
    if(!SecCheck)
    {
        Console.WriteLine("Error. Numero invalido.");
    }
} while (!SecCheck);

do
{
    Console.WriteLine("Ahora ingrese la edad del empleado:");
    s1 = Console.ReadLine();
    SecCheck = int.TryParse(s1, CultureInfo.InvariantCulture, out edad);
    if(!SecCheck)
    {
        Console.WriteLine("Error. Numero invalido.");
    }
} while (!SecCheck && edad > 0);

do
{
    Console.WriteLine("Ahora ingrese cuanto tiempo falta para que el empleado se jubile:");
    s1 = Console.ReadLine();
    SecCheck = int.TryParse(s1, CultureInfo.InvariantCulture, out faltaParaJubilarseAños);
    if(!SecCheck)
    {
        Console.WriteLine("Error. Numero invalido.");
    }
} while (!SecCheck && edad >= 0);

if (edad > 64 && faltaParaJubilarseAños == 0)
{
    esJubilado = true;
} else {esJubilado = false;}

do
{
    Console.WriteLine("Ingrese el sueldo basico del empleado:");
    s1 = Console.ReadLine();
    SecCheck = double.TryParse(s1, CultureInfo.InvariantCulture, out sueldoBasico);
    if(!SecCheck)
    {
        Console.WriteLine("Error. Numero invalido.");
    }
} while (!SecCheck);

do
{
    Console.WriteLine("Ingrese el cargo del empleado (Palabra completa y primera letra con mayuscula):");
    cargo = Console.ReadLine();
} while(cargo != "Auxiliar" || cargo != "Ingeniero" || cargo != "Administrativo" || cargo != "Especialista" || cargo != "Investigador");

do
{
    Console.WriteLine("Ahora ingrese cuanto tiempo falta para que el empleado se jubile (si ya esta jubilado ingrese 0):");
    s1 = Console.ReadLine();
    SecCheck = int.TryParse(s1, CultureInfo.InvariantCulture, out faltaParaJubilarseAños);
    if(!SecCheck)
    {
        Console.WriteLine("Error. Numero invalido.");
    }
} while (!SecCheck && edad >= 0);

char estadoCivilMinus;

do
{
    Console.WriteLine("Ingrese el estado civil del empleado \n(c) Casado\n(s) Soltero\n(v) Viudo:");
    s1 = Console.ReadLine();
    estadoCivil = s1.ToLower();
    SecCheck = char.TryParse(estadoCivil, out estadoCivilMinus);
    if (!SecCheck || (estadoCivilMinus != 'c' && estadoCivilMinus != 's' && estadoCivilMinus != 'v'))
    {
        Console.WriteLine("Error. Opción inválida.");
    }
} while (!SecCheck || (estadoCivilMinus != 'c' && estadoCivilMinus != 's' && estadoCivilMinus != 'v'));

double adicional = 0;
double aumentadorPorAntiguedad = 0;
double salario = sueldoBasico;

if(antiguedad > 0 && antiguedad < 25)
{
    for(int i = 0; i < antiguedad; i++)
    {
        aumentadorPorAntiguedad += 0.1;
    }
} else if (antiguedad > 25)
{
    aumentadorPorAntiguedad = 0.25;
}

if (aumentadorPorAntiguedad > 0)
{
    adicional = sueldoBasico * aumentadorPorAntiguedad;
}

if(cargo == "Ingeniero" || cargo == "Especialista")
{
    adicional += 1.5;
}

if(estadoCivilMinus == 'c')
{
    adicional += 150000;
}