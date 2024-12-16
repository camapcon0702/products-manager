using products_manager.App_Data;
using products_manager.DTOs;
using products_manager.Interfaces;
using products_manager.Models;
using products_manager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace products_manager.Control
{
    public partial class ListSanPhamControl : UserControl
    {
        private readonly ISanPhamRepository _sanPhamRepository;
        //public static List<GioHangDTO> gioHangs;
        //private IGioHangRepository _gioHangRepo;
        public ListSanPhamControl()
        {
            InitializeComponent();
            _sanPhamRepository = new SanPhamRepository(new AppDataContext());
            //_gioHangRepo = new GioHangRepository(new AppDataContext());
        }

        private void ListSanPhamControl_Load(object sender, EventArgs e)
        {
            //gioHangs = _gioHangRepo.GetGioHangDTOByUser();
            //DataHelper.WriteToXmlFile("../Data/giohang.xml", gioHangs);
            var items = _sanPhamRepository.SanPhamsToControls();
            foreach (var item in items)
            {
                flowLayoutPanel1.Controls.Add(item);
            }

        }
    }
}
