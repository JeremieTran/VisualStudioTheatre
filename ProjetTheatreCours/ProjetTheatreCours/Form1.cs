using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ProjetTheatreCours
{
    public partial class Form1 : Form
    {
        const int NB_RANGS = 25;
        const int PLACES_PAR_RANG = 40;
        int[,] matricePlaces = new int[NB_RANGS, PLACES_PAR_RANG]; // Déclarer la matrice comme une variable de classe

        public Form1()
        {
            InitializeComponent();
            SetupTableLayoutPanel();
            SetupCheckBoxes();
            MarquerPlacesPrises();
        }

        private void SetupTableLayoutPanel()
        {
            tableLayoutPanel1.ColumnCount = PLACES_PAR_RANG;
            tableLayoutPanel1.RowCount = NB_RANGS;

            // Ajoutez des colonnes et des lignes au TableLayoutPanel
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / tableLayoutPanel1.ColumnCount));
            }

            for (int i = 0; i < tableLayoutPanel1.RowCount; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / tableLayoutPanel1.RowCount));
            }
        }

        private void SetupCheckBoxes()
        {
            for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
            {
                for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
                {
                    CheckBox checkBox = new CheckBox();
                    tableLayoutPanel1.Controls.Add(checkBox, col, row);
                }
            }
        }

        private void MarquerPlacesPrises()
        {
            // Définir les places prises
            matricePlaces[14, 3] = 1; // Colonne 4, Ligne 15
            matricePlaces[14, 4] = 1; // Colonne 5, Ligne 15
            matricePlaces[14, 7] = 1; // Colonne 8, Ligne 15
            matricePlaces[15, 3] = 1; // Colonne 4, Ligne 16
            matricePlaces[15, 4] = 1; // Colonne 5, Ligne 16
            matricePlaces[15, 7] = 1; // Colonne 8, Ligne 16
            matricePlaces[16, 3] = 1; // Colonne 4, Ligne 17
            matricePlaces[16, 4] = 1; // Colonne 5, Ligne 17
            matricePlaces[16, 7] = 1; // Colonne 8, Ligne 17

            // Parcourir la matrice et définir la couleur de fond des cases prises en rouge
            for (int i = 0; i < NB_RANGS; i++)
            {
                for (int j = 0; j < PLACES_PAR_RANG; j++)
                {
                    if (matricePlaces[i, j] == 1) // Si la place est prise
                    {
                        // Trouver la case correspondante dans le TableLayoutPanel
                        Control control = tableLayoutPanel1.GetControlFromPosition(j, i);
                        if (control is CheckBox checkBox)
                        {
                            checkBox.BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Ce gestionnaire d'événements est appelé lorsqu'on clique sur label1
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ce gestionnaire d'événements est appelé lorsqu'on appuie sur une touche dans textBox1
            if ((e.KeyChar == (char)Keys.Return) && String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Saisir un nombre place !");
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ce gestionnaire d'événements est appelé lorsqu'on clique sur button1
            VerifierDisponibilitePlaces(Convert.ToInt32(textBox1.Text));
        }

        private void VerifierDisponibilitePlaces(int n)
        {
            // Ce méthode vérifie la disponibilité des places
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

        private void button1_DragLeave(object sender, EventArgs e)
        {
            // Ce gestionnaire d'événements est appelé lorsqu'on termine le glissement d'éléments au-dessus de button1
        }

        private void Form1_Validating(object sender, CancelEventArgs e)
        {
            // Ce gestionnaire d'événements est appelé lors de la validation du formulaire
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Ce gestionnaire d'événements est appelé lorsqu'on change l'état de checkBox1
        }
    }
}
