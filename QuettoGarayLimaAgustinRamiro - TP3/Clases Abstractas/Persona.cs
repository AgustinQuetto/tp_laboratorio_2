using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        #region(Atributos)
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;
        #endregion

        public enum ENacionalidad { Argentino, Extranjero }

        #region(Propiedades)
        public string Apellido { get { return _apellido; } set { _apellido = ValidarNombreApellido(value); } }
        public int DNI { get { return _dni; } set { _dni = value; } }
        public ENacionalidad Nacionalidad { get { return _nacionalidad; } set { _nacionalidad = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = ValidarNombreApellido(value); } }
        public string StringToDNI { set { _dni = ValidarDni(value, this._nacionalidad); } }
        #endregion

        #region(Constructores)
        public Persona() : this(null, ENacionalidad.Extranjero, null)
        {
        }
        public Persona(string apellido, int dni, ENacionalidad nacionalidad, string nombre) : this(apellido, dni.ToString(), nacionalidad, nombre)
        {
        }
        public Persona(string apellido, ENacionalidad nacionalidad, string nombre) : this(apellido, 0, nacionalidad, nombre)
        {
        }
        public Persona(string apellido, string dni, ENacionalidad nacionalidad, string nombre)
        {
            Apellido = apellido;
            Nacionalidad = nacionalidad;
            StringToDNI = dni;
            Nombre = nombre;
        }
        #endregion

        #region(Metodos)
        public override string ToString()
        {
            return "NOMBRE COMPLETO: " + Apellido + ", " + Nombre + Environment.NewLine + "NACIONALIDAD: " + Nacionalidad;
        }
        private static int ValidarDni(string dato, ENacionalidad nacionalidad)
        {
            int a;
            if (int.TryParse(dato, out a))
            {
                return (ValidarDni(a, nacionalidad));
            }
            else
            {
                throw new DniInvalidoException("El DNI debe ser numérico");
            }
        }
        private static int ValidarDni(int dato, ENacionalidad nacionalidad)
        {
            if (nacionalidad == ENacionalidad.Argentino && (dato < 1 || dato > 89999999))
            {
                throw new DniInvalidoException("DNI fuera de rango", new NacionalidadInvalidaException("La nacionalidad no coincide con el número de DNI"));
            }
            else if (nacionalidad == ENacionalidad.Extranjero && dato < 90000000)
            {
                throw new NacionalidadInvalidaException("La nacionalidad no coincide con el número de DNI");
            }
            return dato;
        }
        private string ValidarNombreApellido(string dato)
        {
            foreach (char a in dato)
            {
                if (!char.IsLetter(a) && a != ' ')
                {
                    return null;
                }
            }
            return dato;
        }
        #endregion
    }
}
