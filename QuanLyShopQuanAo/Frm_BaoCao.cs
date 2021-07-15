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
    public partial class Frm_BaoCao : Form
    {
        string loaiBC = "";
        HangHoaDALBLL hh = new HangHoaDALBLL();
        NhapHangDALBLL nhaph = new NhapHangDALBLL();
        DoiTac doiTac = new DoiTac();
        KhoDALBLL kho = new KhoDALBLL();
        NhaCC nhacc = new NhaCC();
        public Frm_BaoCao()
        {
            InitializeComponent();
        }

        public Frm_BaoCao(string mess): this()
        {
            loaiBC = mess;
        }

        private void Frm_BaoCao_Load(object sender, EventArgs e)
        {
            loadData();
            dateEdit1.DateTime = dateEdit2.DateTime = DateTime.Now;
            dateEdit1.Text = dateEdit2.Text = DateTime.Now.ToString(Constants.DATE_PATTERN);
        }

        public void loadData()
        {
            switch(loaiBC)
            {
                case "nhapkho":
                    {
                        lbltenbaocao.Text = "Bảng kê Phiếu nhập kho";
                        dataGridView1.DataSource = nhaph.layPNK();
                        setupForm_NhapKho();
                    }
                    break;
                case "nhapkhochitiet":
                    {
                        lbltenbaocao.Text = "Bảng kê chi tiết Phiếu nhập kho";
                        dataGridView1.DataSource = nhaph.layCTPNK();
                        setupForm_NhapKho();
                    }
                    break;
                case "banle":
                    {

                    }break;
                case "banlechitiet":
                    {

                    }break;
                case "bansi":
                    {

                    }break;
                case "bansichitiet":
                    {

                    }break;
            }
        }

        private void setupForm_NhapKho()
        {
            lblDK1.Text = "NV lập phiếu";
            lblDK2.Text = "Lô";
            lblDK3.Text = "Nhà cung cấp";
        }

        private void lblFilter_Click(object sender, EventArgs e)
        {
            switch (loaiBC)
            {
                case "nhapkho":
                    {
                        LocDL_PhNhapKho();
                    }
                    break;
                case "nhapkhochitiet":
                    {
                        LocDL_PhNhapKhoCT();
                    }
                    break;
            }
            
        }

        private void LocDL_PhNhapKho()
        {
            int manv = 0;
            string malo = "";
            string mancc = "";
            if (comboBox1.SelectedItem != null)
            {
                manv = int.Parse(comboBox1.SelectedValue.ToString());
            }
            if (comboBox2.SelectedItem != null)
            {
                malo = comboBox2.SelectedValue.ToString();
            }
            if (comboBox3.SelectedItem != null)
            {
                mancc = comboBox3.SelectedValue.ToString();
            }
            dataGridView1.DataSource = nhaph.lay_PNK(manv, malo, mancc, dateEdit1.DateTime, dateEdit2.DateTime);
        }

        private void LocDL_PhNhapKhoCT()
        {
            int manv = 0;
            string malo = "";
            string mancc = "";
            if (comboBox1.SelectedItem != null)
            {
                manv = int.Parse(comboBox1.SelectedValue.ToString());
            }
            if (comboBox2.SelectedItem != null)
            {
                malo = comboBox2.SelectedValue.ToString();
            }
            if (comboBox3.SelectedItem != null)
            {
                mancc = comboBox3.SelectedValue.ToString();
            }
            dataGridView1.DataSource = nhaph.lay_CTPNK(manv, malo, mancc, dateEdit1.DateTime, dateEdit2.DateTime);
        }

        private void sbtExport_Click(object sender, EventArgs e)
        {
            ExcelExport export = new ExcelExport();
            switch (loaiBC)
            {
                case "nhapkho":
                    {
                        List<PhieuNhapKho> data = (List<PhieuNhapKho>)dataGridView1.DataSource;
                        string filename = "BK_PhieuNhapKho.xlsx";
                        bool kq = export.ExportPhieuNhapKho(data, dateEdit1.DateTime, dateEdit2.DateTime, ref filename, false);
                        if(kq)
                        {
                            MessageBox.Show("Xuất Excel thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Xuất Excel thất bại.");
                        }
                    }break;
                case "nhapkhochitiet":
                    {
                        List<ChiTiet_PhieuNhapKho> data = (List<ChiTiet_PhieuNhapKho>)dataGridView1.DataSource;
                    }break;
            }
            
        }

        private void sbtThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblDieuKien_Click(object sender, EventArgs e)
        {
            if(comboBox1.DataSource != null || comboBox2.DataSource != null || comboBox3.DataSource != null)
            {
                comboBox1.DataSource = null;
                comboBox2.DataSource = null;
                comboBox3.DataSource = null;
            }
        }

        private void lblFilter_MouseLeave(object sender, EventArgs e)
        {
            lblFilter.BackColor = Color.Transparent;
        }

        private void lblDieuKien_MouseLeave(object sender, EventArgs e)
        {
            lblDieuKien.BackColor = Color.Transparent;
        }

        private void lblFilter_MouseEnter(object sender, EventArgs e)
        {
            lblFilter.BackColor = Color.Aqua;
        }

        private void lblDieuKien_MouseEnter(object sender, EventArgs e)
        {
            lblDieuKien.BackColor = Color.Aqua;
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.DataSource = doiTac.loadNhanVien();
            comboBox1.DisplayMember = "TenNV";
            comboBox1.ValueMember = "MaNV";
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            comboBox2.DataSource = hh.loadLoHang();
            comboBox2.DisplayMember = "TenLo";
            comboBox2.ValueMember = "MaLo";
        }

        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            comboBox3.DataSource = nhacc.loadNCC();
            comboBox3.DisplayMember = "TenNCC";
            comboBox3.ValueMember = "MaNCC";
        }
    }
}
