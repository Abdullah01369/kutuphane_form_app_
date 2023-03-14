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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void admin_Load(object sender, EventArgs e)
        {
            DataSet ds = dbclass.yoneticigoster();

            gunaDataGridView1.DataSource = ds.Tables[0];

            dbclass db = new dbclass();
            int s = db.kacpersonelvar();
            TXTSAYİ.Text = s.ToString();
            txtsifre.Text = "";
            txtad.Text = "";
            gunaTextBox1.Text = "";
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (txtad.Text != "" && txtsifre.Text != "")
            {
                dbclass db = new dbclass();
                db.kaydetyonetici(txtad.Text, txtsifre.Text);
                MessageBox.Show("KAYDEDİLDİ...");
                txtsifre.Text = "";
                txtad.Text = "";
                DataSet ds = dbclass.yoneticigoster();
                int s = db.kacpersonelvar();
                TXTSAYİ.Text = s.ToString();


                gunaDataGridView1.DataSource = ds.Tables[0];
                txtsifre.Text = "";
                txtad.Text = "";
                gunaTextBox1.Text = "";

            }
            else
            {
                MessageBox.Show("BOŞ GEÇİLEMEZ", "UYARI");
            }

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            home hm = new home();
            hm.Show();
            this.Hide();

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            dbclass db = new dbclass();
            db.siladmin(Convert.ToInt32(gunaTextBox1.Text));

            DataSet ds = dbclass.yoneticigoster();

            gunaDataGridView1.DataSource = ds.Tables[0];


            int s = db.kacpersonelvar();
            TXTSAYİ.Text = s.ToString();
            txtad.Text = "";
            txtsifre.Text = "";
            gunaTextBox1.Text = "";


        }



        private void gunaDataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtad.Text = gunaDataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsifre.Text = gunaDataGridView1.CurrentRow.Cells[2].Value.ToString();
            gunaTextBox1.Text = gunaDataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void btngun_Click(object sender, EventArgs e)
        {
            dbclass db = new dbclass();
            db.adminguncelle(txtad.Text,txtsifre.Text,Convert.ToInt32(gunaTextBox1.Text));


            DataSet ds = dbclass.yoneticigoster();
            gunaDataGridView1.DataSource = ds.Tables[0];


            int s = db.kacpersonelvar();
            TXTSAYİ.Text = s.ToString();
            txtad.Text = "";
            txtsifre.Text = "";
            gunaTextBox1.Text = "";

            MessageBox.Show("GÜNCELLENDİ...");

        }
    }
}
