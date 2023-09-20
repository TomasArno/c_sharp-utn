using System.Text;

namespace ClasesNegocio
{
    public class Compañia
    {
        private string razonSocial;
        private DateTime fechaApertura;
        private Stack<Celular> pilaCelulares;

        public Compañia(string razonSocial, Stack<Celular> Celulares):this()
        {
            this.razonSocial = razonSocial;
            this.pilaCelulares = Celulares;
        }

        Compañia()
        {
            fechaApertura = DateTime.Now;
        }

        public string MostrarCompañia()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Razón social: {this.razonSocial}, Fecha de apertura: {fechaApertura}, Celulares:");

            foreach(Celular celular in pilaCelulares) 
            {
                sb.AppendLine(celular.ToString());
                
            }
            return sb.ToString();
        }
    }
}
