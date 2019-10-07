using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();


        }





        private static double Operar(string numero1, string numero2, string operador)
        {
            // En este caso no pude reutilizar codigo porque no sabia como llamar al metodo Operar de la clase Calculadora desde este
            double num1 = double.Parse(numero1);
            double num2 = double.Parse(numero2);
            double result = 0;
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
            else if (operador == "/")
            {
                result = num1 / num2;
            }
            else if (operador == "/" && num2 == 0)
            {
                result = double.MinValue;
            }
            return result;

            
        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Convert.ToString(Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text));

        }


        private void ConvertirABinario_Click(object sender, EventArgs e)
        {
            int result = lblResultado.Text.Length > 0 ? int.Parse(lblResultado.Text) : 0;
            string bin = "";
            if (lblResultado.Text != "")
            {
                result = Convert.ToInt32(lblResultado.Text);
                while (result > 0)
                {
                    bin = result % 2 + bin;
                    result = result / 2;
                }
                lblResultado.Text = bin;
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void ConvertirADecimal_Click(object sender, EventArgs e)
        {
            bool aux;
            foreach (var c in lblResultado.Text)
            {
                if (c != '0' && c != '1')
                    aux = false;
            }
            aux = true;

            if (aux && lblResultado.Text != "")
            {
                lblResultado.Text = Convert.ToInt32(lblResultado.Text, 2).ToString();
            }

            else lblResultado.Text = "Error";
        }

        public void  Limpiar()
        {
            lblResultado.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            
        }
    }

}
