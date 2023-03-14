using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOOKSTORE
{
    public partial class Form1 : Form
    {
        dbclass snf = new dbclass();

        public Form1()
        {
            InitializeComponent();
        }
        public void goster()
        {
            DataSet veri = dbclass.vericek();
            dataGridView1.DataSource = veri.Tables[0];
            dbclass snf = new dbclass();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            goster();

        }

        private void sil()
        {
            txtyazno.Text = "";
            txtsoyyaz.Text = "";
            txtadyazar.Text = "";

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                snf.kaydet(txtadyazar.Text, txtsoyyaz.Text);
                sil();
                goster();

            }
            catch (Exception)
            {

                MessageBox.Show("YAZAR ID FARKLI OLMAK ZORUNDA!","HATA!");
                sil();
            }
        }

        private void btngun_Click(object sender, EventArgs e)
        {
            snf.guncelle(txtadyazar.Text,txtsoyyaz.Text,Convert.ToInt32(txtyazno.Text));
            goster();
            sil();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtyazno.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtadyazar.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsoyyaz.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            home hm = new home();
            hm.Show();
            this.Hide();
        }
    }
}
