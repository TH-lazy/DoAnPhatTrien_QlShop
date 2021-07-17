using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;


namespace QuanLyShopQuanAo
{
    public partial class Frm_Qrcode : Form
    {
        public string formchucnang = "";
        List<string> mahh = new List<string>();
        Frm_HangHoa formcha;
        Frm_ManHinhBanLe formcha2;
        string m = "";
        public Frm_Qrcode(Frm_HangHoa f1, string mess)
        {
            InitializeComponent();
            formcha = f1;
            m = mess;
        }

        public Frm_Qrcode(Frm_ManHinhBanLe f2, string mess)
        {
            InitializeComponent();
            formcha2 = f2;
            m = mess;
        }

        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        private void btnNhap_Click(object sender, EventArgs e)
        {
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[cboCamera.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += FinalFrame_NewFrame;
            videoCaptureDevice.Start();
            timer1.Start();

        }

        private void Frm_Qrcode_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo Device in filterInfoCollection)
            {
                cboCamera.Items.Add(Device.Name);
            }
            cboCamera.SelectedIndex = 0;
            //videoCaptureDevice = new VideoCaptureDevice();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void Frm_Qrcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            //đây nè đóng lại
            //if (videoCaptureDevice.IsRunning == true)
            //videoCaptureDevice.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //string chuoima = "";
            //string chuoicu = txtMabc.Text;
            if (pictureBox1.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                if (result != null)
                {
                    txtMabc.Text = result.ToString();
                    //chuoima = result.ToString();
                    //mahh.Add(chuoima);
                    //txtMabc.Text = chuoicu + " " + chuoima;
                    //timer1.Stop();
                    if (videoCaptureDevice.IsRunning == true)
                        videoCaptureDevice.Stop();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //foreach (var item in mahh)
            //{
            //    formcha.maqr = item;
            //   
            //}    
            //this.Close();
            if (m == "f1")
            {
                formcha.maqr = txtMabc.Text;
                formcha.capnhat();
            }
            else
            {
                formcha2.maqr = txtMabc.Text;
                formcha2.capnhat();
            }



            this.Close();
        }

        private void txtMabc_TextChanged(object sender, EventArgs e)
        {
            if (m == "f1")
            {
                formcha.maqr = txtMabc.Text;
                formcha.capnhat();
            }
            else
            {
                formcha2.maqr = txtMabc.Text;
                formcha2.capnhat();
            }

            // txtMabc.Text = "";
        }
    }
}
