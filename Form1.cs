using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const bool V = true;
        public int tx = 0, ty = 0, dx = 0, dy = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            // Textboxlara girilen değerlerin numerik ve tam sayı olup olmadığı kontrol ediliyor.
            int sayi;
            bool sonucx = int.TryParse(textBox1.Text, out sayi); bool sonucy = int.TryParse(textBox2.Text, out sayi);
            if (!sonucx) {MessageBox.Show("The value of X should be a positive integer.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;}
            if (!sonucy) {MessageBox.Show("The value of Y should be a positive integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;}

            // Textboxlara girilen değerlerin geçerli bir değer olup olmadığı kontrol ediliyor. Textboxa girilen değer boş,0,negatif sayı olamaz.
            if (string.IsNullOrEmpty(textBox1.Text) || Convert.ToInt32(textBox1.Text) <= 0 || string.IsNullOrEmpty(textBox2.Text) || Convert.ToInt32(textBox2.Text) <= 0)
            {
                MessageBox.Show("Please enter a valid X or Y value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int x, y;
            x = Convert.ToInt32(textBox1.Text);
            y = Convert.ToInt32(textBox2.Text);

            if (dx == x && dy == y) { MessageBox.Show("These X and Y values are already calculated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            dx = x;
            dy = y;

            listBox1.Items.Clear();
            listBox2.Items.Clear();

            // Girilen x değeri çarpanlarına ayrılıyor ve çarpanlar listboxa ekleniyor. tx değeri ise X'in çarpanlarının toplamı.
            for (int i = 1; i < x; i++)
            {
                if (x % i == 0)
                {
                    tx = i + tx;
                    listBox1.Items.Add(i);
                }

            }

            // Girilen y değeri çarpanlarına ayrılıyor ve çarpanlar listboxa ekleniyor. ty değeri ise Y'nin çarpanlarının toplamı.
            for (int i = 1; i < y; i++)
            {
                if (y % i == 0)
                {
                    ty = i + ty;
                    listBox2.Items.Add(i);
                }

            }

            textBox3.Text = tx.ToString();
            textBox4.Text = ty.ToString();

            if(tx == y && ty == x) { label7.Text = "YES"; }
            else { label7.Text = "NO"; }

            tx = 0;
            ty = 0;
            }
        }
    }
