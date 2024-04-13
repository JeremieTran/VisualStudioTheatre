using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TPDemo
{
    public partial class Form1 : Form
    {
        const int NB_RANGS = 25;
        const int PLACES_PAR_RANG = 40;
        int[,] matricePlaces = new int[NB_RANGS, PLACES_PAR_RANG]; // Déclarer la matrice comme une variable de classe
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void VerifierDisponibilitePlaces(int n)
        {
            for (int rang = 0; rang < NB_RANGS; rang++)
            {
                for (int siege = 0; siege <= PLACES_PAR_RANG - n; siege++)
                {
                    bool disponible = true;
                    for (int i = 0; i < n; i++)
                    {
                        if (matricePlaces[rang, siege + i] == 1)
                        {
                            disponible = false;
                            break;
                        }
                    }
                    if (disponible)
                    {
                        MessageBox.Show($"Vous pouvez réserver les places suivantes : rang {rang + 1}, sièges {siege + 1} à {siege + n}");
                        return;
                    }
                }
            }
            MessageBox.Show($"Désolé, il n'y a pas de série de {n} places contiguës disponibles.");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Return) && String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Saisir un nombre place !");

            }
            else button1.Enabled = true;
            // Tester la touche backspace
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VerifierDisponibilitePlaces(Convert.ToInt32(textBox1.Text));
        }

        private void button1_DragLeave(object sender, EventArgs e)
        {

        }
    }
}
