using products_manager.App_Data;
using products_manager.Models;
using products_manager.Repositories;
using System;
using System.Collections;
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
    public partial class SanPhamControl : UserControl
    {
        private readonly SanPhamRepository _sanPhamRepository;
        private readonly DanhMucRepository _danhMucRepository;
        private readonly NhaCungCapRepository _nhaCungCapRepository;
        public SanPhamControl()
        {
            InitializeComponent();
            _sanPhamRepository = new SanPhamRepository(new AppDataContext());
            _danhMucRepository = new DanhMucRepository(new AppDataContext());
            _nhaCungCapRepository = new NhaCungCapRepository(new AppDataContext());
        }



        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectRow = dgvSanPham.Rows[e.RowIndex];
                string tenSanPham = selectRow.Cells["TenSanPham"].Value?.ToString();
                string donGia = selectRow.Cells["DonGia"].Value?.ToString();
                string hinhAnh = selectRow.Cells["HinhAnh"].Value?.ToString();
                string soLuongCon = selectRow.Cells["SoLuongCon"].Value?.ToString();
                string idDanhMuc = selectRow.Cells["DanhMuc"].Value?.ToString();
                string idNhaCungCap = selectRow.Cells["NhaCungCap"].Value?.ToString();

                tbSanPham.Text = tenSanPham;
                tbDonGia.Text = donGia;
                tbSLC.Text = soLuongCon;

                cbHinhAnh.SelectedItem = hinhAnh;

                if (!string.IsNullOrEmpty(idDanhMuc))
                {
                    cbDanhMuc.SelectedValue = Convert.ToInt32(idDanhMuc);
                }

                if (!string.IsNullOrEmpty(idNhaCungCap))
                {
                    cbNhaCungCap.SelectedValue = Convert.ToInt32(idNhaCungCap);
                }

            }
        }

        private void SanPhamControl_Load(object sender, EventArgs e)
        {
            LoadSanPham();
            LoadDanhMuc();
            LoadNhaCungCap();
            LoadCbHinhAnh();
        }

        private void LoadSanPham()
        {
            try
            {
                if (dgvSanPham.Columns.Count == 0)
                {
                    dgvSanPham.Columns.Add("Id", "ID");
                    dgvSanPham.Columns.Add("TenSanPham", "Tên Sản Phẩm");
                    dgvSanPham.Columns.Add("HinhAnh", "Hình Ảnh");
                    dgvSanPham.Columns.Add("DonGia", "Đơn Giá");
                    dgvSanPham.Columns.Add("SoLuongCon", "Số Lượng Còn");
                    dgvSanPham.Columns.Add("DanhMuc", "Danh Mục");
                    dgvSanPham.Columns.Add("NhaCungCap", "Nhà Cung Cấp");
                }

                string filePath = "../Data/SanPham.xml";
                var sanPhamList = _sanPhamRepository.ReadXmlSanPham(filePath);
                if (sanPhamList != null && sanPhamList.Count > 0)
                {
                    dgvSanPham.Rows.Clear();
                    foreach (var sanPham in sanPhamList)
                    {
                        dgvSanPham.Rows.Add(
                            sanPham.Id,
                            sanPham.TenSanPham,
                            sanPham.HinhAnh,
                            sanPham.DonGia,
                            sanPham.SoLuongCon,
                            sanPham.DanhMuc.Id,
                            sanPham.NhaCungCap.Id
                        );
                    }
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tải sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadDanhMuc()
        {
            string filePath = "../Data/DanhMuc.xml";
            var danhMucs = _danhMucRepository.ReadXmlDanhMuc(filePath);
            if (danhMucs != null && danhMucs.Count > 0)
            {
                cbDanhMuc.Items.Clear();

                cbDanhMuc.DataSource = danhMucs;
                cbDanhMuc.DisplayMember = "TenDanhMuc";
                cbDanhMuc.ValueMember = "Id";
                cbDanhMuc.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu danh mục trong tệp XML.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void LoadNhaCungCap()
        {
            string filePath = "../Data/NhaCungCap.xml";
            var nhaCungCaps = _nhaCungCapRepository.ReadXmlNhaCungCap(filePath);
            if (nhaCungCaps != null && nhaCungCaps.Count > 0)
            {
                cbNhaCungCap.Items.Clear();

                cbNhaCungCap.DataSource = nhaCungCaps;
                cbNhaCungCap.DisplayMember = "TenNhaCungCap";
                cbNhaCungCap.ValueMember = "Id";
                cbNhaCungCap.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu nhà cung cấp trong tệp XML.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void LoadCbHinhAnh()
        {
            List<string> listAnh = new List<string>();
            listAnh.Add("laptop.jpg");
            listAnh.Add("iphone6splus.jpg");
            listAnh.Add("iphone7splus.jpg");
            listAnh.Add("iphone8splus.jpg");
            cbHinhAnh.DataSource = listAnh;
        }
        private async void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSanPham = tbSanPham.Text.Trim();
                string hinhAnh = cbHinhAnh.Text.Trim();
                float donGia = float.TryParse(tbDonGia.Text.Trim(), out float parsedDonGia) ? parsedDonGia : 0;
                int soLuongCon = int.TryParse(tbSLC.Text.Trim(), out int parsedSLC) ? parsedSLC : 0;

                if (string.IsNullOrEmpty(tenSanPham) || string.IsNullOrEmpty(hinhAnh) || donGia <= 0 || soLuongCon <= 0)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var danhMuc = cbDanhMuc.SelectedItem as DanhMuc;
                var nhaCungCap = cbNhaCungCap.SelectedItem as NhaCungCap;

                if (danhMuc == null || nhaCungCap == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục và nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await _sanPhamRepository.AddSanPhamToXml(tenSanPham, hinhAnh, donGia, soLuongCon, danhMuc, nhaCungCap);
                LoadSanPham();
                MessageBox.Show("Sản phẩm đã được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbSanPham.Clear();
                tbDonGia.Clear();
                tbSLC.Clear();
                cbDanhMuc.SelectedIndex = 0;
                cbNhaCungCap.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSanPham.Text) || string.IsNullOrEmpty(tbDonGia.Text) || string.IsNullOrEmpty(tbSLC.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int idSanPham = (int)dgvSanPham.SelectedRows[0].Cells["Id"].Value;  
                string tenSanPham = tbSanPham.Text.Trim();
                string hinhAnh = cbHinhAnh.Text.Trim();
                float donGia = float.Parse(tbDonGia.Text.Trim());
                int soLuongCon = int.Parse(tbSLC.Text.Trim());
                DanhMuc danhMuc = cbDanhMuc.SelectedItem as DanhMuc; 
                NhaCungCap nhaCungCap = cbNhaCungCap.SelectedItem as NhaCungCap;

                if (danhMuc == null || nhaCungCap == null)
                {
                    MessageBox.Show("Vui lòng chọn đúng Danh Mục và Nhà Cung Cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SanPham sanPham = new SanPham
                {
                    Id = idSanPham,
                    TenSanPham = tenSanPham,
                    HinhAnh = hinhAnh,
                    DonGia = donGia,
                    SoLuongCon = soLuongCon,
                    DanhMuc = danhMuc,
                    NhaCungCap = nhaCungCap
                };

                await _sanPhamRepository.UpdateSanPham(sanPham);

                LoadSanPham();  

                MessageBox.Show("Sản phẩm đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi cập nhật sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSanPham.SelectedRows.Count > 0)
                {
                    int idSanPham = Convert.ToInt32(dgvSanPham.SelectedRows[0].Cells["Id"].Value);

                    var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmResult == DialogResult.Yes)
                    {
                        await _sanPhamRepository.DeleteSanPham(idSanPham);
                        LoadSanPham();  
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
