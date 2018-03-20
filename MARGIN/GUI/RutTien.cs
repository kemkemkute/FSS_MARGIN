using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using GUI.QLTienMatWS;

namespace GUI
{
    public partial class RutTien : Form
    {
        public QLTienMatDTO qLTienMat;
        public RutTien()
        {
            InitializeComponent();
            qLTienMat = new QLTienMatDTO();
        }

        private void RutTien_Load(object sender, EventArgs e)
        {
            txtHoTen.Text = qLTienMat.HoTen;
            txtSDT.Text = qLTienMat.SDT;
            txtSoTKLK.Text = qLTienMat.SoTKLK;
            txtSoCMND.Text = qLTienMat.SoCMND;
            txtSOTienRutToiDa.Text = qLTienMat.TienMat.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRut_Click(object sender, EventArgs e)
        {
            lblError.ForeColor = Color.Red;
            QLTienMatBUS qLTienMatBUS = new QLTienMatBUS();
            switch (qLTienMatBUS.KtraNopTien(txtSoTienRut.Text))
            {
                case 1:
                    {
                        lblError.Text = "Bạn chưa nhập số tiền rút";
                        break;
                    }
                case 2:
                    {
                        lblError.Text = "Số tiền phải là số";
                        break;
                    }
                case 3:
                    {
                        lblError.Text = "Số tiền rút không hợp lệ";
                        break;
                    }
                case 4:
                    {
                        lblError.Text = "Số tiền rút lớn hơn số tiền tối đa";
                        break;
                    }
                case 0:
                    {
                        lblError.Text = "";
                        qLTienMatBUS.rutTien(txtSoTKLK.Text, qLTienMat.TienMat, long.Parse(txtSoTienRut.Text));
                        MessageBox.Show("Rút tiền thành công");
                        Close();
                        Close();
                        break;
                    }
            }
        }
    }
}
