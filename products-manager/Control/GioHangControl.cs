using products_manager.App_Data;
using products_manager.Interfaces;
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

namespace products_manager.Control
{
    public partial class GioHangControl : UserControl
    {
        private IGioHangRepository _gioHangRepo;
        public GioHangControl()
        {
            InitializeComponent();
            _gioHangRepo = new GioHangRepository(new AppDataContext());
        }

        private void GioHangControl_Load(object sender, EventArgs e)
        {
            _gioHangRepo.UpdateGioHangFromXml("../Data/giohang.xml");
        }
    }
}
