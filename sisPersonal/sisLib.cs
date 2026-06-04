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
            get {return Nombre;}
            set {Nombre = value;}
        }

        public string IngresaApellido
        {
            get {return Apellido;}
            set {Apellido = value;}
        }

        public DateTime IngresaFecNaC
        {
            get {return FecNac;}
            set {FecNac = value;}
        }
        public Char IngresaEstCivil
        {
            get {return EstCivil;}
            set {EstCivil = value;}
        } 

        public Cargos IngresaCargo
        {
            get {return Cargo;}
            set {Cargo = value;}
        }
    }
}