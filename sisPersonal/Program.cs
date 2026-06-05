using System.Globalization;
using System.Runtime.Serialization.Formatters;
using EspacioCalculos;

Console.WriteLine("------------------------------- Sistema Personal para Empleados ---------------------------");
string s1;
bool SecCheck;
double antiguedad;
int edad;
int faltaParaJubilarseAños;
bool esJubilado;
double sueldoBasico = 0;
string estadoCivil;
string cargo;
char estadoCivilMinus;
double adicional = 0;
double aumentadorPorAntiguedad = 0;
double salario = sueldoBasico;
double totalSalarios = 0;
int edadAnt = 0;
int proximoAJubilarse;

empleados[] empleados = null;
empleados proximoAJubilarse = null;

for(int j = 0; j < 3; j++)
{   
    empleados[j] = new Empleado[];
    Console.WriteLine("Ingrese el nombre del empleado:");
    empleados[j].Nombre = Console.ReadLine();

    Console.WriteLine("Ingrese el apellido del empleado:");
    empleados[j].Apellido = Console.ReadLine();

    do
    {
        Console.WriteLine("Ingrese la fecha de nacimiento (dd/MM/yyyy):");
        s1 = Console.ReadLine();
        SecCheck = DateTime.TryParse(s1, out empleados[j].FecNac);
        if (!SecCheck)
        {
            Console.WriteLine("Fecha inválida.");
        }
    } while (!SecCheck);

    do
    {
        Console.WriteLine("Ingrese la fecha de ingreso del empleado (dd/MM/yyyy):");
        s1 = Console.ReadLine();
        SecCheck = DateTime.TryParse(s1, out empleados[j].FechaIngreso);
        if (!SecCheck)
        {
            Console.WriteLine("Fecha inválida.");
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

    if (edad > edadAnt && edad < 65)
    {
        proximoAJubilarse = empleados[j];
    }

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

    antiguedad = DateTime.Today.Year - empleados[j].FechaIngreso.Year;
    
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
    } while(cargo != "Auxiliar" && cargo != "Ingeniero" && cargo != "Administrativo" && cargo != "Especialista" && cargo != "Investigador");

    for(int z = 0; z < 5; z++)
    {
        if(cargo == empleados[j].Cargo[z])
        {
            empleados[j].Cargo[z] = cargo;
        }
    }

    do
    {
        Console.WriteLine("Ahora ingrese cuanto tiempo falta para que el empleado se jubile (si ya esta jubilado ingrese 0):");
        s1 = Console.ReadLine();
        SecCheck = int.TryParse(s1, CultureInfo.InvariantCulture, out faltaParaJubilarseAños);
        if(!SecCheck)
        {
            Console.WriteLine("Error. Numero invalido.");
        }
    } while (!SecCheck || faltaParaJubilarseAños < 0);

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

    switch(estadoCivilMinus)
    {
        case 'c':
            empleados[j].EstCivil = 'C';
        break;

        case 's':
            empleados[j].EstCivil = 'S';
        break;

        case 'v':
            empleados[j].EstCivil = 'V';
        break;
    }

    if(antiguedad > 0 && antiguedad <= 20)
    {
        for(int i = 0; i < antiguedad; i++)
        {
            aumentadorPorAntiguedad += 0.01;
        }
    } else if (antiguedad > 20)
    {
        aumentadorPorAntiguedad = 0.25;
    }
    adicional = sueldoBasico * aumentadorPorAntiguedad;

    if(cargo == "Ingeniero" || cargo == "Especialista")
    {
        adicional *= 1.5;
    }

    if(estadoCivilMinus == 'c')
    {
        adicional += 150000;
    }

    edadAnt = edad;

    empleados[j].SueldoBasico = sueldoBasico;

    salario = sueldoBasico + adicional;

    if(esJubilado)
    {
        salario -= salario * 0.3;
    }

    totalSalarios += salario;
    
    salario = 0;
    adicional = 0;
    aumentadorPorAntiguedad = 0;

    Console.WriteLine("--------------------------------------------------------------------------");
    Console.WriteLine($"Empleado {j}: {empleados[j].Nombre} {empleados[j].Apellido}");
    Console.WriteLine($"Antiguedad: {antiguedad} años.");
    Console.WriteLine($"Edad: {edad} años:");
    Console.WriteLine($"Le faltan para jubilarse: {faltaParaJubilarseAños} años.");
}


Console.WriteLine("Datos del proximo a jubilarse: ");



