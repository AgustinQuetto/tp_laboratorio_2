using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region(Atributos)
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region(Propiedades)
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        public Jornada this[int indice]
        {
            get { return this.Jornadas[indice]; }
            set { this.Jornadas[indice] = value; }
        }
        #endregion

        #region(Constructor)
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region(Metodo)
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno p in g.alumnos)
            {
                if (p == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            for (int i = 0; i < g.jornada.Count; i++)
            {
                if (g.jornada[i].Clase == clase)
                    return g.jornada[i].Instructor;
            }
            throw new Excepciones.SinProfesorException();
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor p in g.profesores)
            {
                if (p == i)
                {
                    return true;
                }
            }
            Console.WriteLine("No hay profesor para la clase.");
            return false;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            for (int i = 0; i < g.jornada.Count; i++)
            {
                if (g.jornada[i].Clase != clase)
                    return g.jornada[i].Instructor;
            }
            throw new Excepciones.SinProfesorException();
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.alumnos.Add(a);
            }
            else
            {
                throw new Excepciones.AlumnoRepetidoException();
            }
            return g;
        }
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada unaJornada;
            foreach (Profesor unProfe in g.profesores)
            {
                if (unProfe == clase)
                {
                    unaJornada = new Jornada(clase, unProfe);
                    g.jornada.Add(unaJornada);
                    foreach (Alumno a in g.alumnos)
                    {
                        if (a == clase)
                        {
                            unaJornada += a;
                        }
                    }
                    break;
                }
            }
            return g;
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.profesores.Add(i);
            }
            else
            {
                throw new Excepciones.SinProfesorException();
            }
            return g;
        }
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");

            foreach (Jornada j in gim.jornada)
            {
                sb.AppendLine(j.ToString());
            }
            return sb.ToString();
        }
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> guardar = new Xml<Universidad>();
            guardar.Guardar("Universidad.xml", gim);
            return true;
        }
        #endregion
    }
}
