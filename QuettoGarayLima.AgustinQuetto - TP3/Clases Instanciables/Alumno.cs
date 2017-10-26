using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        public Alumno() : this(0, "", "", "", 0, 0)
        {
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma, 0)
        {
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
            this._estadoCuenta = estadoCuenta;
        }

        protected override string ParticiparEnClase()
        {
            return Environment.NewLine + "TOMA CLASE DE " + this._claseQueToma.ToString();
        }

        protected override string MostrarDatos()
        {
            string definirEstado = "";
            switch (_estadoCuenta)
            {
                case EEstadoCuenta.Becado:
                    definirEstado = "Becado";
                    break;
                case EEstadoCuenta.Deudor:
                    definirEstado = "Debe cuota/s";
                    break;
                case EEstadoCuenta.AlDia:
                    definirEstado = "Cuota al día";
                    break;
            }
            return base.MostrarDatos() + Environment.NewLine + "ESTADO DE CUENTA: " + definirEstado + Environment.NewLine;
        }

        public override string ToString()
        {
            return MostrarDatos();
        }
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor;
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a._claseQueToma != clase;
        }
    }
}
