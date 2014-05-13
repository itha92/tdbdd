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

        public int[][] matriz;
        public List<string> entidades;

        private void button1_Click(object sender, EventArgs e)
        {
            txt_df1.Text += comboBox1.SelectedItem + ",";

            int size = txt_relacion.Text.Split(',').Length;
            matriz = new int[size][];

            for (int i = 0; i < matriz.Length; i++)
            {
                matriz[i] = new int[size];
            }
                        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_relacion.Text != "")
            {
                ComboboxItem i;
                List<string> l = new List<string>(txt_relacion.Text.Split(','));
                foreach (string str in l)
                {
                    i = new ComboboxItem();
                    i.text = str;
                    i.val = str;
                    comboBox1.Items.Add(i);
                    comboBox2.Items.Add(i);
                }

                this.button2.Enabled = false;
                entidades = new List<string>(txt_relacion.Text.Split(','));
                
                
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
            listBox1.Items.Add(txt_df1.Text + "->" + txt_df2.Text);

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

            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz.Length; j++)
                {
                    Console.Write("[" + matriz[i][j] + "]");
                }
                Console.WriteLine("");
            }

            txt_df1.Text = "";
            txt_df2.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {

           
        }
    }
}
