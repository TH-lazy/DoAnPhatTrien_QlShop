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
    public partial class Frm_ChiTietHangHoa : DevExpress.XtraEditors.XtraForm
    {
        HangHoaDALBLL hang = new HangHoaDALBLL();
        public Frm_ChiTietHangHoa()
        {
            InitializeComponent();
        }

        private void Frm_ChiTietHangHoa_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = hang.loadHangHoa();
            hang.capnhatkho();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = hang.loadHangHoa();
            hang.capnhatkho();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Frm_HangHoa f = new Frm_HangHoa();
            f.Show();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?","Thoát",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            gridControl2.DataSource = hang.loadChiTietHangHoa(gridView1.GetFocusedRowCellValue("MaHang").ToString());
        }
    }
}