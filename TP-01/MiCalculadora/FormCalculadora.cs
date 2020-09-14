using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

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
            //Creo dos instancias de la clase Numero y las uso como paramrametros del metodo estatico Operar de la clase Calculadora
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            double result = Entidades.Calculadora.Operar(num1, num2, operador);

            return result;


        }
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string resultado = "";

            //Valido si alguno de los dos textbox les estan en blanco, de ser asi tomo como input lblResultado para el segundo valor
            if (txtNumero1.Text != "" && txtNumero2.Text != "")
                {
               resultado = Convert.ToString(Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text));
            }
            else if (txtNumero1.Text != "" && txtNumero2.Text == "" ) 
            { 
                resultado = Convert.ToString(Operar(lblResultado.Text, txtNumero1.Text, cmbOperador.Text));
            }
            else if (txtNumero1.Text == "" && txtNumero2.Text != "")
            {
                resultado = Convert.ToString(Operar(lblResultado.Text, txtNumero2.Text, cmbOperador.Text));
            }
            else 
            {
                MessageBox.Show("Valores ingresados incorrectos");
            }

            //Limpio y asigno el resultado
            Limpiar();
            lblResultado.Text = resultado;
        }


        private void ConvertirABinario_Click(object sender, EventArgs e)
        {
            //Creo un objeto de la clase Numero para usar el metodo de conversion y asignarle el resultado al label
            Numero result = new Numero(lblResultado.Text);
            lblResultado.Text = result.DecimalBinario(lblResultado.Text);
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
            //Creo un objeto de la clase Numero para usar el metodo de conversion y asignarle el resultado al label
            Numero result = new Numero(lblResultado.Text);
            lblResultado.Text = result.BinarioDecimal(lblResultado.Text);
        }

        public void Limpiar()
        {
            lblResultado.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";

        }
    }

}
