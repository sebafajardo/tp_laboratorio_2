using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        public string setNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        private bool EsBinario(string binario)
        {
            bool es = true;
            foreach (char c in binario)
            {
                if (c != '0' && c != '1')
                    es = false;
            }
            return es;
        }
        public string BinarioDecimal(string binario)
        {
            //Valido si es binario, de ser asi lo paso a decimal y lo retorno
            if (EsBinario(binario))
            {
                
                return Convert.ToInt32(binario, 2).ToString();
            }

            else
                return "Valor inválido";
        }

        public string DecimalBinario(double numero)
        {

            // Si es negativo lo convierto en positivo
            if (numero < 0)
                numero = numero - numero - numero;

            string bin = "";

            // Lo paso a binario y lo retorno
            while (numero > 0)
            {
                bin = numero % 2 + bin;
                numero = numero / 2;
            }

            return bin;
        }

        public string DecimalBinario(string numero)
        {
            int numeroentero;

            //Para mi aca podria ser util llamar al metodo ValidarNumero en lugar de hacer esta conversion
            bool succes = Int32.TryParse(numero, out numeroentero);

            if (succes)
            {
                string bin = "";

                // Si es negativo lo convierto en positivo
                if (numeroentero < 0)
                {
                    numeroentero = numeroentero - numeroentero - numeroentero;
                }

                // Lo paso a binario y lo retorno
                while (numeroentero > 0)
                {
                    bin = numeroentero % 2 + bin;
                    numeroentero = numeroentero / 2;
                }

                return bin;
            }
            else
                return "Valor inválido";

        }

        public Numero()
        {
            numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string strNumero)
        {
            Double.TryParse(strNumero, out this.numero);
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }

        private double ValidarNumero(string strNumero)
        {
            double numero;
            bool succes = double.TryParse(strNumero, out numero);
            if (succes == true)
                return numero;
            else
                return 0;
        }
    }

    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double result;
            if (operador == "+")
            {
                result = num1 + num2;
            }
            else if (operador == "*")
            {
                result = num1 * num2;

            }
            else if (operador == "-")
            {
                result = num1 - num2;
            }
            else
            {
                result = num1 / num2;
            }

            return result;
        }

        private static string ValidarOperador(char operador)
        {
            if (operador.Equals('+'))
            {
                return "+";
            }
            else if (operador.Equals('*'))
            {
                return "*";

            }
            else if (operador.Equals('-'))
            {
                return "-";
            }
            else if (operador.Equals('/'))
            {
                return "/";
            }
            else
            {
                return "+";
            }

        }



    }
}
