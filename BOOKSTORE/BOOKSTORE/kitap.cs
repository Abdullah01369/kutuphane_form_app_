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
    public partial class kitap : Form
    {
        public kitap()
        {
            InitializeComponent();
        }

        private void kitap_Load(object sender, EventArgs e)
        {
            DataSet veri = dbclass.vericekkitap();
            dataGridView1.DataSource = veri.Tables[0];
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsayfa.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtpuan.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtyazarno.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtturno.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            dbclass d = new dbclass();

            dbclass.kaydetkitap(Convert.ToString(txtad.Text), Convert.ToInt32(txtsayfa.Text), Convert.ToInt32(txtpuan.Text), Convert.ToInt32(txtyazarno.Text), Convert.ToInt32(txtturno.Text));
            DataSet veri = dbclass.vericekkitap();
            dataGridView1.DataSource = veri.Tables[0];
        }

        private void btngun_Click(object sender, EventArgs e)
        {
            dbclass d = new dbclass();
            d.kitapguncelle(txtad.Text, Convert.ToInt32(txtsayfa.Text), Convert.ToInt32(txtpuan.Text), Convert.ToInt32(txtyazarno.Text), Convert.ToInt32(txtturno.Text), Convert.ToInt32(textBox1.Text));
            DataSet veri = dbclass.vericekkitap();
            dataGridView1.DataSource = veri.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbclass d = new dbclass();

            d.sil(Convert.ToInt32(textBox1.Text));

            DataSet veri = dbclass.vericekkitap();
            dataGridView1.DataSource = veri.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            home hm = new home();
            hm.Show();
            this.Hide();

        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
