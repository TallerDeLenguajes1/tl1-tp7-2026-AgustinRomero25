namespace EspacioCalculos
{
    public class Empleado
    {
        private string Nombre;
        private string Apellido;
        private DateTime FecNac;
        private char EstCivil;
        private DateTime FechaIngreso;
        private double SueldoBasico;

        public enum Cargos
        {
            Auxiliar,
            Administrativo,
            Ingeniero,
            Especialista,
            Investigador
        }

        private Cargos Cargo;

        public string IngresaNombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string IngresaApellido
        {
            get { return Apellido; }
            set { Apellido = value; }
        }

        public DateTime IngresaFecNac
        {
            get { return FecNac; }
            set { FecNac = value; }
        }

        public char IngresaEstCivil
        {
            get { return EstCivil; }
            set { EstCivil = value; }
        }

        public DateTime IngresaFechaIngreso
        {
            get { return FechaIngreso; }
            set { FechaIngreso = value; }
        }

        public Cargos IngresaCargo
        {
            get { return Cargo; }
            set { Cargo = value; }
        }

        public double IngresaSueldoBasico
        {
            get { return SueldoBasico; }
            set { SueldoBasico = value; }
        }

        public int Edad
        {
            get
            {
                int edad = DateTime.Today.Year - FecNac.Year;

                if (FecNac.Date > DateTime.Today.AddYears(-edad))
                {
                    edad--;
                }

                return edad;
            }
        }

        public int Antiguedad
        {
            get
            {
                int antiguedad = DateTime.Today.Year - FechaIngreso.Year;

                if (FechaIngreso.Date > DateTime.Today.AddYears(-antiguedad))
                {
                    antiguedad--;
                }

                return antiguedad;
            }
        }

        public int AniosParaJubilarse
        {
            get
            {
                if (Edad >= 65)
                {
                    return 0;
                }

                return 65 - Edad;
            }
        }

        public double Salario
        {
            get
            {
                double adicional;

                if (Antiguedad <= 20)
                {
                    adicional = SueldoBasico * (Antiguedad * 0.01);
                }
                else
                {
                    adicional = SueldoBasico * 0.25;
                }

                if (Cargo == Cargos.Ingeniero ||
                    Cargo == Cargos.Especialista)
                {
                    adicional *= 1.5;
                }

                if (EstCivil == 'C')
                {
                    adicional += 150000;
                }

                return SueldoBasico + adicional;
            }
        }
    }
}