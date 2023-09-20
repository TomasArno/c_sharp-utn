using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace ClasesNegocio
{
    public class Celular
    {

        #region Atributos

        private EMarca marca;
        private string titular;
        private string numero;
        private string modelo;
        private int ram;
        private double almacenamiento;
        private double almacenamientoActual;
        private bool encendido;
        private Dictionary<Contacto, DateTime> agenda;
        private List<App> apps;
        private Stack<Llamada> llamadasRealizadas;
        #endregion


        #region Constructores
        public Celular(EMarca marca, string modelo, int ram, double almacenamiento, Dictionary<Contacto, DateTime> agenda):this(marca, modelo, ram,almacenamiento)
        {
            this.Agenda = agenda;
        }

        public Celular(EMarca marca, string modelo, int ram, double almacenamiento):this()
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Ram = ram;
            this.Almacenamiento = almacenamiento;
            this.Encendido = false;
            this.AlmacenamientoActual = 0;
        }

        public Celular()
        {
            this.Apps = new List<App>();
            this.Agenda = new Dictionary<Contacto, DateTime>();
            this.llamadasRealizadas = new Stack<Llamada>();
        }
        #endregion

        
        #region Propiedades

        public string Modelo {get => this.modelo;set=> this.modelo = value;}

        public EMarca Marca { get => marca; set => marca = value; }

        public int Ram { get => ram; set => ram = value; }
        public double Almacenamiento {get => almacenamiento; set => almacenamiento = value;}
        public double AlmacenamientoActual { get => almacenamientoActual; set => almacenamientoActual = value; }
        public bool Encendido { get => encendido; set => encendido = value; }
        public Dictionary<Contacto, DateTime> Agenda { get => agenda; set => agenda = value; }
        public List<App> Apps { get => apps; set => apps = value; }
        public string Titular { get => titular; set => titular = value; }
        public string Numero { get => numero; set => numero = value; }
        public Stack<Llamada> LlamadasRealizadas { get => llamadasRealizadas; set => llamadasRealizadas = value; }

        #endregion


        #region Metodos Instancia
        public string AlternarEncendido()
        {

            this.Encendido = !this.Encendido;

            return this.Encendido ? "Encendiendo..." : "Apagando...";
        }

        public void Llamar(string numero)
        {
            if (this.encendido)
            {
                if (BuscarEnAgenda(numero))
                {
                    llamadasRealizadas.Push( new Llamada(DateTime.Now, numero, new Random().Next(3,10)));
                    Console.WriteLine($"Llamando al numero: {numero}");
                }
                else
                {
                    Console.WriteLine("Numero no encontrado...");
                }
            }
            else
            {
                Console.WriteLine("El celular esta apagado");
            }
        }

        public void Llamar(Contacto unContacto)
        {
            if (this.encendido)
            {
                if (BuscarEnAgenda(unContacto))
                {
                    llamadasRealizadas.Push(new Llamada(DateTime.Now, numero, new Random().Next(3, 10)));
                    Console.WriteLine($"Llamando a: {unContacto.nombre}");
                }
                else
                {
                    Console.WriteLine("Contacto no encontrado...");
                }
            }
            else
            {
                Console.WriteLine("El celular esta apagado");
            }
        }

        private bool BuscarEnAgenda(string numeroBuscado)
        {
            bool estaEnAgenda;
            estaEnAgenda = false;

            foreach (KeyValuePair<Contacto, DateTime> contacto in this.agenda)
            { 
                if (numeroBuscado == contacto.Key.numero)
                {
                    estaEnAgenda = true;
                    break;
                }
            }

            return estaEnAgenda;
        }


        private bool BuscarEnAgenda(Contacto contactoBuscado)
        {
            bool estaEnAgenda;
            estaEnAgenda = false;

            foreach (KeyValuePair<Contacto, DateTime> contacto in this.agenda)
            {

                if (contactoBuscado == contacto.Key)
                {
                    estaEnAgenda = true;
                    break;
                }
            }

            return estaEnAgenda;
        }

        private bool InstalarApp(App aplicacion)
        {
            bool exito;
            exito = false;

            if (this.encendido && this != aplicacion && VerificarEspacio(aplicacion.Size))
            {
                exito = true;
                this.apps.Add(aplicacion);
                this.almacenamientoActual += aplicacion.Size;
            }

            return exito;
        }

        private bool VerificarEspacio(double nuevoSize)
        {
            return (this.almacenamientoActual + nuevoSize) < this.almacenamiento;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Marca: {this.marca}");
            sb.AppendLine($"Modelo: {this.modelo}");
            sb.AppendLine($"RAM: {this.ram}");
            sb.AppendLine($"Almacenamiento: {this.almacenamiento}");
            sb.AppendLine("Aplicaciones instaladas:");
            if (this.apps.Count > 0)
            {
                foreach (string aplicacion in apps)
                {
                    sb.AppendLine($"\t{aplicacion}");
                }
            }
            else
            {
                sb.AppendLine("No hay apps instaladas");
            }

            sb.AppendLine("Llamadas:");

            if (this.LlamadasRealizadas.Count > 0)
            {
                foreach (Llamada llamada in LlamadasRealizadas)
                {
                    sb.AppendLine($"\t{llamada}");
                }
            }
            else
            {
                sb.AppendLine("No se realizó ninguna llamada");
            }
            sb.AppendLine("*******************************************");

            return sb.ToString();
        }

        #endregion


        #region Sobrecarga de operadores
        public static bool operator ==(Celular miCelu, App miApp)
        {
            bool exito;
            exito = false;
            foreach (string aplicacion in miCelu.Apps)
            {
                if (aplicacion == miApp.Nombre)
                {
                    exito = true;
                    break;
                }
            }

            return exito;
        }
        public static bool operator !=(Celular miCelu, App miApp)
        {
            return !(miCelu == miApp);
        }

        public static bool operator +(Celular miCelu, App miApp)
        {
            return miCelu.InstalarApp(miApp);
        }
        #endregion

    }
}