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

        public string BinarioDecimal(string binario)
        {   
            bool aux;
            foreach (var c in binario)
            {
                if (c != '0' && c != '1')
                    aux = false;
            }
            aux = true;

            if (aux)
            {
                Convert.ToInt32(binario, 2).ToString();
                return binario;
            }

            else
                return "Valor inválido";
        }

        public string DecimalBinario(double numero)
        {
            if (numero < 0)
                numero = numero - numero - numero;

            numero = Convert.ToInt32(numero);

            string bin = "";

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
            bool succes = Int32.TryParse(numero, out numeroentero);

            if (succes)
            {
                string bin = "";

                if (numeroentero < 0)
                {
                    numeroentero = numeroentero - numeroentero - numeroentero;
                }
               
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
        public double Operar(Numero num1, Numero num2, string operador)
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

        private static string ValidarOperador(string operador)
        {
            if (operador == "+")
            {
                return "+";
            }
            else if (operador == "*")
            {
                return "*";

            }
            else if (operador == "-")
            {
                return "-";
            }
            else if (operador == "/")
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
