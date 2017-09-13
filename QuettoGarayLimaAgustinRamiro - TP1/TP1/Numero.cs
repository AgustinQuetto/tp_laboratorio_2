using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Numero
    {
        private double _numero;

        ///constructor de la clase - a.i
        public Numero():this(numero:0)
        {
        }

        ///constructor de la clase - a.i
        public Numero(string numeroString)
        {
            this.SetNumero(numeroString);
        }

        ///constructor de la clase - a.i
        public Numero(double numero) : this(numeroString: numero.ToString())
        {
        }

        public double GetNumero()
        {
            return this._numero;
        }

        ///a.ii
        static private double ValidarNumero(string numeroString)
        {
            if (double.TryParse(numeroString, out double valorRetorno))
            {
            }
            else
            {
                valorRetorno = 0;
            }
            return valorRetorno;
        }

        ///setter a.iii
        private void SetNumero(string numeroString)
        {
            this._numero = Numero.ValidarNumero(numeroString);
        }
    }
}
