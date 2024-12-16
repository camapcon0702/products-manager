using products_manager.App_Data;
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
    public partial class FormNhanVien : Form
    {
        private readonly DanhMucRepository _danhMucRepository;
        private readonly NhaCungCapRepository _nhaCungCapRepository;
        public FormNhanVien()
        {
            InitializeComponent();
            _danhMucRepository = new DanhMucRepository(new AppDataContext());
            _nhaCungCapRepository = new NhaCungCapRepository(new AppDataContext());
            _danhMucRepository.CreateXmlDanhMuc();
            _nhaCungCapRepository.CreateXmlNhaCungCap();
        }

        public void ShowControls(UserControl control)
        {
            pnNhanVien.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnNhanVien.Controls.Add(control);
        }

        private void menuQLDM_Click(object sender, EventArgs e)
        {
            ShowControls(new DanhMucControl());
        }

        private void menuQLNCC_Click(object sender, EventArgs e)
        {
            ShowControls(new NhaCungCapControl());
        }

        private void menuQLSP_Click(object sender, EventArgs e)
        {
            ShowControls(new SanPhamControl());
        }
        private async void menuXMLtoSQL_Click(object sender, EventArgs e)
        {
            try
            {
                string filePathDanhMuc = "../Data/DanhMuc.xml";
                var danhMucs = _danhMucRepository.ReadXmlDanhMuc(filePathDanhMuc);
                await _danhMucRepository.UpdateDatabaseFromXml(danhMucs);

                string filePathNhaCungCap = "../Data/NhaCungCap.xml";
                var nhaCungCaps = _nhaCungCapRepository.ReadXmlNhaCungCap(filePathNhaCungCap);
                await _nhaCungCapRepository.UpdateDatabaseFromXml(nhaCungCaps);

                MessageBox.Show("Dữ liệu đã được đồng bộ từ XML vào cơ sở dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi đồng bộ dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}
