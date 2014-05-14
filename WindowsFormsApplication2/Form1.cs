using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Normalizar;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int contador_entidades = 0;
        public int[][] matriz;
        public List<string> entidades;
        public List<Nodo> relaciones = new List<Nodo>();
        public bool creada = false;

        private void button1_Click(object sender, EventArgs e)
        {
            txt_df1.Text += comboBox1.SelectedItem + ",";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_relacion.Text != "")
            {
                ComboboxItem i;
                entidades = new List<string>(txt_relacion.Text.Split(','));
                foreach (string str in entidades)
                {
                    i = new ComboboxItem();
                    i.text = str;
                    i.val = str;
                    comboBox1.Items.Add(i);
                    comboBox2.Items.Add(i);
                }

                comboBox1.SelectedIndex = 1;
                comboBox2.SelectedIndex = 1;
                
                this.button2.Enabled = false;
                
                
                
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if ( txt_df2.Text.Split(',').Length < 0 )
            {
                Console.WriteLine("solo hay una");
            }
            string tmp = txt_df2.Text;
            tmp = comboBox2.SelectedItem + ",";
            txt_df2.Text += tmp ;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(txt_df1.Text.Remove(txt_df1.Text.Length - 1, 1) + "->" + txt_df2.Text.Remove(txt_df2.Text.Length - 1, 1));

            contador_entidades++;

            Nodo n = new Nodo();
            n.l_izq = new List<string>(txt_df1.Text.Remove(txt_df1.Text.Length-1,1).Split(','));
            n.l_der = new List<string>(txt_df2.Text.Remove(txt_df2.Text.Length - 1, 1).Split(','));

            
            relaciones.Add(n);

            txt_df1.Text = "";
            txt_df2.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;


            if (!this.creada)
            {
                int size = entidades.Count;
                matriz = new int[size][];

                for (int k = 0; k < matriz.Length; k++)
                {
                    matriz[k] = new int[contador_entidades];
                }
            }
            this.creada = true;

            int index = entidades.IndexOf(txt_df1.Text.Split(',')[0]);
            int index2;
            string sin = txt_df2.Text;
            sin = sin.Remove(sin.Length - 1, 1);
            List<string> tmp = new List<string>(sin.Split(','));

            foreach (string el in tmp)
            {
                index2 = entidades.IndexOf(el);
                matriz[index][index] = 1;
                matriz[index][index2] = 1;
            }




            ImprimirMatriz(matriz);


        }

        public void ImprimirMatriz(int[][] m)
        {
            for (int i = 0; i < m.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write("[ ]");
                    foreach (string en in entidades)
                    {
                        Console.Write("["+en+"]");
                    }
                    Console.WriteLine();
                }
                for (int j = 0; j < m.Length; j++)
                {
                    if ( j == 0)
                    {
                        Console.Write("[" + entidades[i] + "]");
                    }
                    Console.Write("[" + m[i][j] + "]");
                }
                Console.WriteLine("");
            }
            Console.WriteLine();
        }
    }
}
