using System.Globalization;
using EspacioCalculos;

Console.WriteLine("------------------------------- Sistema Personal para Empleados ---------------------------");

string s1;
bool SecCheck;

double sueldoBasico;
string cargo;
string estadoCivil;
char estadoCivilMinus;

DateTime fechaAux;

double totalSalarios = 0;

Empleado[] empleados = new Empleado[3];
Empleado proximoAJubilarse = null;

for(int j = 0; j < 3; j++)
{
    empleados[j] = new Empleado();

    Console.WriteLine($"========== EMPLEADO {j + 1} ==========");

    Console.WriteLine("Ingrese el nombre del empleado:");
    empleados[j].IngresaNombre = Console.ReadLine();

    Console.WriteLine("Ingrese el apellido del empleado:");
    empleados[j].IngresaApellido = Console.ReadLine();

    do
    {
        Console.WriteLine("Ingrese la fecha de nacimiento (dd/MM/yyyy):");
        s1 = Console.ReadLine();

        SecCheck = DateTime.TryParse(s1, out fechaAux);

        if(!SecCheck)
        {
            Console.WriteLine("Fecha inválida.");
        }
        else
        {
            empleados[j].IngresaFecNac = fechaAux;
        }

    } while(!SecCheck);

    do
    {
        Console.WriteLine("Ingrese la fecha de ingreso (dd/MM/yyyy):");
        s1 = Console.ReadLine();

        SecCheck = DateTime.TryParse(s1, out fechaAux);

        if(!SecCheck)
        {
            Console.WriteLine("Fecha inválida.");
        }
        else
        {
            empleados[j].IngresaFechaIngreso = fechaAux;
        }

    } while(!SecCheck);

    do
    {
        Console.WriteLine("Ingrese el sueldo básico:");
        s1 = Console.ReadLine();

        SecCheck = double.TryParse(
            s1,
            CultureInfo.InvariantCulture,
            out sueldoBasico);

        if(!SecCheck)
        {
            Console.WriteLine("Número inválido.");
        }

    } while(!SecCheck);

    empleados[j].IngresaSueldoBasico = sueldoBasico;

    do
    {
        Console.WriteLine("Ingrese el cargo:");
        Console.WriteLine("Auxiliar");
        Console.WriteLine("Administrativo");
        Console.WriteLine("Ingeniero");
        Console.WriteLine("Especialista");
        Console.WriteLine("Investigador");

        cargo = Console.ReadLine();

    } while(cargo != "Auxiliar" &&
            cargo != "Administrativo" &&
            cargo != "Ingeniero" &&
            cargo != "Especialista" &&
            cargo != "Investigador");

    empleados[j].IngresaCargo =
        Enum.Parse<Empleado.Cargos>(cargo);

    do
    {
        Console.WriteLine("Ingrese el estado civil:");
        Console.WriteLine("(c) Casado");
        Console.WriteLine("(s) Soltero");
        Console.WriteLine("(v) Viudo");

        estadoCivil = Console.ReadLine().ToLower();

        SecCheck = char.TryParse(
            estadoCivil,
            out estadoCivilMinus);

        if(!SecCheck ||
            (estadoCivilMinus != 'c' &&
            estadoCivilMinus != 's' &&
            estadoCivilMinus != 'v'))
        {
            Console.WriteLine("Opción inválida.");
        }

    } while(!SecCheck ||
            (estadoCivilMinus != 'c' &&
            estadoCivilMinus != 's' &&
            estadoCivilMinus != 'v'));

    switch(estadoCivilMinus)
    {
        case 'c':
            empleados[j].IngresaEstCivil = 'C';
            break;

        case 's':
            empleados[j].IngresaEstCivil = 'S';
            break;

        case 'v':
            empleados[j].IngresaEstCivil = 'V';
            break;
    }

    totalSalarios += empleados[j].Salario;

    if(proximoAJubilarse == null ||
        empleados[j].AniosParaJubilarse <
        proximoAJubilarse.AniosParaJubilarse)
    {
        proximoAJubilarse = empleados[j];
    }

    Console.WriteLine("----------------------------------------");
    Console.WriteLine($"Empleado: {empleados[j].IngresaNombre} {empleados[j].IngresaApellido}");
    Console.WriteLine($"Edad: {empleados[j].Edad}");
    Console.WriteLine($"Antigüedad: {empleados[j].Antiguedad}");
    Console.WriteLine($"Años para jubilarse: {empleados[j].AniosParaJubilarse}");
    Console.WriteLine($"Salario: ${empleados[j].Salario}");
    Console.WriteLine();
}

Console.WriteLine("========================================");
Console.WriteLine($"Monto total pagado en salarios: ${totalSalarios}");
Console.WriteLine();

Console.WriteLine("Empleado más próximo a jubilarse:");
Console.WriteLine($"{proximoAJubilarse.IngresaNombre} {proximoAJubilarse.IngresaApellido}");
Console.WriteLine($"Edad: {proximoAJubilarse.Edad}");
Console.WriteLine($"Antigüedad: {proximoAJubilarse.Antiguedad}");
Console.WriteLine($"Años para jubilarse: {proximoAJubilarse.AniosParaJubilarse}");
Console.WriteLine($"Salario: ${proximoAJubilarse.Salario}");