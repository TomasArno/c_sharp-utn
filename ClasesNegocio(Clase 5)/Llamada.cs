using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesNegocio
{
    public class Llamada
    {
        private DateTime _fecha;
        private string _numeroDestino;
        private int _duracion;
        public Llamada(DateTime fecha, string numeroDestino, int duracion) 
        {
            this._fecha = fecha;
            this._numeroDestino = numeroDestino;
            this._duracion = duracion;
        }

    }
}
