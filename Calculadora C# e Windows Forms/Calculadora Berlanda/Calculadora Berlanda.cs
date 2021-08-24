using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_Berlanda
{
    public partial class Form1 : Form
    {
        decimal valor1 = 0, valor2 = 0;
        string operacao = "";
        private NumberStyles cultureInfo;

        public Form1()
        {
            InitializeComponent();
        }

        private void texResultado_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            texResultado.Text += "4";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            texResultado.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            texResultado.Text += "6";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            texResultado.Text = "";
            labOperacao.Text = "";
            valor1 = 0;
            valor2 = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            texResultado.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            texResultado.Text += "0"; 
        }

        private void button12_Click(object sender, EventArgs e)
        {
            texResultado.Text += "1";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            texResultado.Text += "2";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            texResultado.Text += "3";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            texResultado.Text += "7";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            texResultado.Text += "8";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            texResultado.Text += "9";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            texResultado.Text += ".";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (texResultado.Text != "")
            {
                valor2 = decimal.Parse(texResultado.Text, CultureInfo.InvariantCulture);
                if (operacao == "SOMA")
                {
                    texResultado.Text = Convert.ToString(valor1 + valor2);
                }
                else if (operacao == "SUBTRACAO")
                {
                    texResultado.Text = Convert.ToString(valor1 - valor2);
                }
                else if (operacao == "MULTIPLICA")
                {
                    texResultado.Text = Convert.ToString(valor1 * valor2);
                }
                else if (operacao == "DIVISAO")
                {
                    texResultado.Text = Convert.ToString(valor1 / valor2);
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (texResultado.Text != "")
            {
                valor1 = decimal.Parse(texResultado.Text, CultureInfo.InvariantCulture);
                texResultado.Text = "";
                operacao = "SUBTRACAO";
                labOperacao.Text = "-";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (texResultado.Text != "")
            {

                valor1 = decimal.Parse(texResultado.Text, CultureInfo.InvariantCulture);
                texResultado.Text = "";
                operacao = "MULTIPLICA";
                labOperacao.Text = "X";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (texResultado.Text != "")
            {
                valor1 = decimal.Parse(texResultado.Text, CultureInfo.InvariantCulture);
                texResultado.Text = "";
                operacao = "DIVISAO";
                labOperacao.Text = "/";
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (texResultado.Text != "")
            {
                valor1 = decimal.Parse(texResultado.Text, CultureInfo.InvariantCulture);
                texResultado.Text = "";
                operacao = "SOMA";
                labOperacao.Text = "+";
            }
        }
    }
}
