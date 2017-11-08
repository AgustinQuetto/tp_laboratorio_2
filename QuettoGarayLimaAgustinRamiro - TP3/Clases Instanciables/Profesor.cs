using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region(Atributos)
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;
        #endregion

        #region(Constructores)
        static Profesor()
        {
            _random = new Random();
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();

            this._randomClase();
            this._randomClase();
        }

        public Profesor() : this(0, "", "", "", 0)
        {

        }
        #endregion

        #region(Metodos)
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        private void _randomClase()
        {
            this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0, 4));
        }
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();
        }
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases a in i._clasesDelDia)
            {
                if (a == clase)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Environment.NewLine + "CLASES DEL DIA ");
            foreach (Universidad.EClases a in _clasesDelDia)
            {
                sb.AppendLine(a.ToString());
            }
            return sb.ToString();
        }
        #endregion
    }
}
