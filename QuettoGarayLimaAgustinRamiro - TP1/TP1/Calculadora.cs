using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Calculadora
    {
        ///b.i
        static public double Operar(Numero numero1, Numero numero2, string operador)
        {
            operador = Calculadora.ValidarOperador(operador);
            switch (operador)
            {
                case "+":
                    return numero1.GetNumero() + numero2.GetNumero();
                case "-":
                    return numero1.GetNumero() - numero2.GetNumero();
                case "*":
                    return numero1.GetNumero() * numero2.GetNumero();
                case "/":
                    if (numero2.GetNumero() != 0)
                    {
                        return numero1.GetNumero() / numero2.GetNumero();
                    }
                    else
                    {
                        return 0;
                    }
                default:
                    return 0;
            }
        }

        ///b.ii
        static public string ValidarOperador(string operador)
        {
            switch (operador)
            {
                case "+":
                    return "+";
                case "-":
                    return "-";
                case "*":
                    return "*";
                case "/":
                    return "/";
                default:
                    return "+";
            }
        }
    }
}
