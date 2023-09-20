using ClasesNegocio;


namespace Clase_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Contacto, DateTime> agenda1 = new Dictionary<Contacto, DateTime>();
            Dictionary<Contacto, DateTime> agenda2 = new Dictionary<Contacto, DateTime>();
            Dictionary<Contacto, DateTime> agenda3 = new Dictionary<Contacto, DateTime>();

            Contacto miContacto1 = new Contacto("Juan", "5555");
            Contacto miContacto2 = new Contacto("esteban", "6666");
            Contacto miContacto3 = new Contacto("Carlos", "7777");

            agenda1.Add(miContacto1, DateTime.Now); 

            agenda2.Add(miContacto1, DateTime.Now);
            agenda2.Add(miContacto2, DateTime.Now);

            agenda3.Add(miContacto2, DateTime.Now);
            agenda3.Add(miContacto3, DateTime.Now);

            Celular celular1 = new Celular(EMarca.Samsung, "J7", 4, 64, agenda1);
            Celular celular2= new Celular(EMarca.Apple,"10", 8, 64, agenda2);
            Celular celular3 = new Celular(EMarca.Apple, "14", 8, 128, agenda3);

            Console.WriteLine(celular1.AlternarEncendido());
            celular2.AlternarEncendido();
            celular3.AlternarEncendido();

            //Console.WriteLine("****************************************");

            App app1 = new App("Google", 10f);
            App app2 = new App("WhatsApp", 5f);
            App app3 = new App("Youtube", 15f);

            List<App> listaApps = new List<App>();

            listaApps.Add(app1);
            listaApps.Add(app2);
            listaApps.Add(app3);

            foreach (App aplicacion in listaApps)
            {
                bool exito = celular1 + aplicacion;
                bool exito2 = celular2 + aplicacion;
                bool exito3 = celular3 + aplicacion;
                if (exito && exito2 && exito3)
                {
                    Console.WriteLine($"Exito al instalar {aplicacion.Nombre}");
                }
                else
                {
                    Console.WriteLine($"No se pudo instalar {aplicacion.Nombre} por falta de memoria");

                }
            }

            //Console.WriteLine(celular1.ToString());

            Stack<Celular> celulares = new Stack<Celular>();

            celulares.Push(celular1);
            celulares.Push(celular2);
            celulares.Push(celular3);


            Compañia movistar = new Compañia("movistar", celulares);
            celular1.Llamar("5555");
            celular1.Llamar(miContacto3);

            celular2.Llamar("7777");
            celular2.Llamar(miContacto3);

            celular3.Llamar("6666");
            celular3.Llamar(miContacto3);

            Console.WriteLine(movistar.MostrarCompañia());


            //Console.WriteLine("*********************EXPLICIT e IMPLICIT*********************************");
            ////PRUEBA DE OPERADORES EXPLICITOS E IMPLICITOS DE LA CLASE APP

            //App unaApp = new App("Pokemon Go", 45f);

            //string appString;

            //appString = (string)unaApp;

            //Console.WriteLine(appString);

            //double capacidad;

            //capacidad = unaApp;

            //Console.WriteLine($"La capacidad del celular es: {capacidad}");















        }


    }
}