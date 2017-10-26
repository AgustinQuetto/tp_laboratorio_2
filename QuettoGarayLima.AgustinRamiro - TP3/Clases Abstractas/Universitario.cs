using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        #region(Constructores)
        public Universitario() : base()
        {
            _legajo = 0;
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(apellido, dni, nacionalidad, nombre)
        {
            _legajo = legajo;
        }
        #endregion

        #region(Metodos)
        public override bool Equals(object obj)
        {
            return obj is Universitario && (Universitario)obj == this;
        }
        protected virtual string MostrarDatos()
        {
            return base.ToString() + Environment.NewLine + Environment.NewLine + "Legajo: " + this._legajo;
        }
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1._legajo == pg2._legajo || pg1.DNI == pg2.DNI;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        protected abstract string ParticiparEnClase();
        #endregion
    }
}
