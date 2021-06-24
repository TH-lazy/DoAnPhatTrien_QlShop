using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;

namespace QuanLyShopQuanAo
{
    public partial class Frm_Kho : DevExpress.XtraEditors.XtraForm
    {
        KhoDALBLL kho = new KhoDALBLL();
        public Frm_Kho()
        {
            InitializeComponent();
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void Frm_Kho_Load(object sender, EventArgs e)
        {
            grv_dsKho.DataSource = kho.LoadKho();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //int r = this.grv_dsKho.CurrentCell.RowIndex;
            //int c = this.grv_dsKho.CurrentCell.ColumnIndex;

            /* string makho = grv_dsKho.Rows[r].Cells[0].Value.ToString();
             string tenkho = grv_dsKho.Rows[r].Cells[1].Value.ToString();
             string nhomkho = grv_dsKho.Rows[r].Cells[2].Value.ToString();
             bool trangthai = grv_dsKho.Rows[r].Cells[3].Value.ToString();
             string diadiem = grv_dsKho.Rows[r].Cells[4].Value.ToString();*/
            string makho = "";
            string tenkho = "";
            string nhomkho = "";
            bool trangthai = true;
            string diadiem = "";
            foreach (DataGridViewRow row in grv_dsKho.SelectedRows)
            {
                 makho = row.Cells[0].Value.ToString();
                 tenkho = row.Cells[1].Value.ToString();
                 nhomkho = row.Cells[2].Value.ToString();
                 trangthai = bool.Parse(row.Cells[3].Value.ToString());
                 diadiem = row.Cells[4].Value.ToString();
            }

            if (kho.Them(makho,tenkho,nhomkho,trangthai,diadiem))
            {
                MessageBox.Show("Thành công");
                grv_dsKho.DataSource = kho.LoadKho();
            }
            else
            {
                MessageBox.Show("Thất Bại");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            int r = this.grv_dsKho.CurrentCell.RowIndex;
            //bool trangthai = bool.Parse(grv_dsKho.Rows[r].Cells[3].Value.ToString());
            string makho = "";
            string tenkho = "";
            string nhomkho = "";
            bool trangthai = true;
            string diadiem = "";
            foreach (DataGridViewRow row in grv_dsKho.SelectedRows)
            {
                makho = row.Cells[0].Value.ToString();
                tenkho = row.Cells[1].Value.ToString();
                nhomkho = row.Cells[2].Value.ToString();
                trangthai = bool.Parse(row.Cells[3].Value.ToString());
                diadiem = row.Cells[4].Value.ToString();
            }
            if (kho.xoaKho(makho))
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void searchControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            grv_dsKho.DataSource = kho.TimKho(txtTimKiem.Text);
        }
    }
}