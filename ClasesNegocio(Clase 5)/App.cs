using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesNegocio
{
    public class App
    {
        private string _nombre;
        private double _size;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public double Size { get => _size; set => _size = value; }

        public App(string nombre, double size)
        {
            this._nombre = nombre;
            this._size = size;
        }

        // Sobrecarga del operador explícito para convertir App a string
        public static explicit operator string(App app)
        {
            return $"{app.Nombre} ({app.Size} GB)";
        }

        // Sobrecarga del operador explícito para convertir App a double
        public static implicit operator double(App app)
        {
            return app.Size;
        }

        public string GetString()
        {
            return $"{this.Nombre} ({this.Size} GB)";
        }


    }
}
