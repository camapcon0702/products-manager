using products_manager.App_Data;
using products_manager.Control;
using products_manager.DTOs;
using products_manager.Interfaces;
using products_manager.Models;
using products_manager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace products_manager
{
    public partial class FormKhachHang : Form
    {
        public static List<GioHangDTO> gioHangs;
        private IGioHangRepository _gioHangRepo;
        public FormKhachHang()
        {
            InitializeComponent();
            //gioHangs = new List<GioHangDTO>();
            _gioHangRepo = new GioHangRepository(new AppDataContext());
            _gioHangRepo.CreateXMLGioHang();
        }

        public void ShowControls(UserControl control)
        {
            pnKhachHang.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnKhachHang.Controls.Add(control);
        }

        private async void FormKhachHang_Load(object sender, EventArgs e)
        {
            
        }

        private void xemSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControls(new ListSanPhamControl());
            gioHangs = _gioHangRepo.GetGioHangDTOByUser();
            DataHelper.WriteToXmlFile("../Data/giohang.xml", gioHangs);
        }

        private void giỏHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowControls(new GioHangControl());
        }
    }
}
