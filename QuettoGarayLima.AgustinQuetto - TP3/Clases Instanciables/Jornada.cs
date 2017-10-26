using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }
        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.Clase;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(a == j.Clase);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            int encontrado = 0;
            foreach (Alumno b in j.Alumnos)
            {
                if (b == a)
                {
                    encontrado = 1;
                }
            }
            if (encontrado == 0)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DE " + this._clase + " POR " + this._instructor + Environment.NewLine + "ALUMNOS: ");
            foreach (Alumno a in this._alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            sb.AppendLine("<------------------------------------------------>");

            return sb.ToString();
        }
        public static bool Guardar(Jornada jornada)
        {
            Texto unTexto = new Texto();
            unTexto.Guardar("jornada.txt", jornada.ToString());
            return true;
        }
        public string Leer()
        {
            string recuperar;
            Texto unTexto = new Texto();
            unTexto.Leer("jornada.txt", out recuperar);
            return recuperar;
        }
    }
}
