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
    public partial class Frm_NhaCungCap : DevExpress.XtraEditors.XtraForm
    {
        NhaCC n = new NhaCC();
        public Frm_NhaCungCap()
        {
            InitializeComponent();
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (txtTenNCC.Text == "" || txtDiaChi.Text == "" || txtEmail.Text == "" || txtSoDienThoai.Text == "" || txtMoTa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.");
                return;
            }
            if (n.ThemNCC(txtMaNCC.Text,txtTenNCC.Text,txtDiaChi.Text,txtEmail.Text,txtSoDienThoai.Text,txtMoTa.Text))
            {
                cleartext();
                MessageBox.Show("Thêm thành công.");
                cleartext();
                dgv_DSNCC.DataSource = n.loadNCC();
            }
            else
            {
                MessageBox.Show("Thêm thất bại.");
            }
        }

        private void Frm_NhaCungCap_Load(object sender, EventArgs e)
        {
            dgv_DSNCC.DataSource = n.loadNCC();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa.");
                return;
            }
            if (n.xoaNCC(txtMaNCC.Text))
            {
                MessageBox.Show("Xóa thành công.");
                dgv_DSNCC.DataSource = n.loadNCC();
                cleartext();
            }
            else
            {
                MessageBox.Show("Xóa thất bại.");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        public void cleartext()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSoDienThoai.Text = "";
            txtMoTa.Text = "";
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
        }

        private void dgv_DSNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv_DSNCC_CurrentCellChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_DSNCC.SelectedRows)
            {
                    txtMaNCC.Text = row.Cells[0].Value.ToString();
                    txtTenNCC.Text = row.Cells[1].Value.ToString();
                    txtDiaChi.Text = row.Cells[2].Value.ToString();
                    txtEmail.Text = row.Cells[3].Value.ToString();
                    txtSoDienThoai.Text = row.Cells[4].Value.ToString();
                    txtMoTa.Text = row.Cells[5].Value.ToString();            
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (n.UpdateNCC(txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text, txtEmail.Text, txtSoDienThoai.Text, txtMoTa.Text))
            {
                MessageBox.Show("Sửa thành công.");
                dgv_DSNCC.DataSource = n.loadNCC();
                cleartext();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?","Thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}