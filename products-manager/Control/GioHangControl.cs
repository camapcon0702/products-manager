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
        List<GioHangItem> gioHangItems;
        public GioHangControl()
        {
            InitializeComponent();
            _gioHangRepo = new GioHangRepository(new AppDataContext());
        }

        private async void GioHangControl_Load(object sender, EventArgs e)
        {
            await _gioHangRepo.UpdateGioHangFromXml("../Data/giohang.xml");
            gioHangItems = _gioHangRepo.GioHangsToControls();
            foreach (var item in gioHangItems)
            {
                flowLayoutPanel.Controls.Add(item);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            for (int i = gioHangItems.Count - 1; i >= 0; i--)
            {
                var item = gioHangItems[i];
                CheckBox chkSelect = item.Controls.OfType<CheckBox>().FirstOrDefault();

                if (chkSelect != null && chkSelect.Checked)
                {
                    flowLayoutPanel.Controls.Remove(item);
                    gioHangItems.RemoveAt(i);
                    _gioHangRepo.DeleteSanPhamFromGioHang(item.sanPham.Id);
                    DataHelper.DeleteSanPhamFromGioHangXML("../Data/giohang.xml", item.sanPham.Id);
                }
            }
            //DataHelper.WriteToXmlFile("../Data/giohang.xml", FormKhachHang.gioHangs);
        }
    }
}
