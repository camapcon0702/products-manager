using products_manager.App_Data;
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
    public partial class NhaCungCapControl : UserControl
    {
        private readonly NhaCungCapRepository _repository;
        public NhaCungCapControl()
        {
            InitializeComponent();
            _repository = new NhaCungCapRepository(new AppDataContext());
        }

        public void LoadNhaCungCap()
        {
            try
            {
                List<NhaCungCap> nhaCungCapList = _repository.ReadXmlNhaCungCap("../Data/NhaCungCap.xml");
                DataTable dataTable = _repository.ToDataTable(nhaCungCapList);
                dgvNhaCungCap.DataSource = dataTable;

                dgvNhaCungCap.Columns["Id"].HeaderText = "Mã nhà cung cấp";
                dgvNhaCungCap.Columns["TenNhaCungCap"].HeaderText = "Tên nhà cung cấp";
                dgvNhaCungCap.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dgvNhaCungCap.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi tải dữ liệu từ XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NhaCungCapControl_Load(object sender, EventArgs e)
        {
            LoadNhaCungCap();
        }

        private void dgvNhaCungCap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectRow = dgvNhaCungCap.Rows[e.RowIndex];
                string tenNhaCungCap = selectRow.Cells["TenNhaCungCap"].Value?.ToString();
                string diaChi = selectRow.Cells["DiaChi"].Value?.ToString();
                string soDienThoai = selectRow.Cells["SoDienThoai"].Value?.ToString();

                tbNhaCungCap.Text = tenNhaCungCap;
                tbDiaChi.Text = diaChi;
                tbSDT.Text = soDienThoai;
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            string tenNhaCungCap = tbNhaCungCap.Text.Trim();
            string diaChi = tbDiaChi.Text.Trim();
            string soDienThoai = tbSDT.Text.Trim();

            if (string.IsNullOrEmpty(tenNhaCungCap) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soDienThoai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _repository.AddNhaCungCapToXml(tenNhaCungCap, diaChi, soDienThoai);

                LoadNhaCungCap();

                MessageBox.Show("Nhà cung cấp đã được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi thêm nhà cung cấp vào XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvNhaCungCap.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            if (selectedRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            string tenNhaCungCap = tbNhaCungCap.Text.Trim();
            string diaChi = tbDiaChi.Text.Trim();
            string soDienThoai = tbSDT.Text.Trim();

            NhaCungCap nhaCungCapToUpdate = new NhaCungCap
            {
                Id = id,
                TenNhaCungCap = tenNhaCungCap,
                DiaChi = diaChi,
                SoDienThoai = soDienThoai
            };
            try
            {
                await _repository.UpdateNhaCungCap(nhaCungCapToUpdate);
                LoadNhaCungCap();

                MessageBox.Show("Nhà cung cấp đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi cập nhật nhà cung cấp vào XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvNhaCungCap.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            if (selectedRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

            try
            {
                await _repository.DeleteNhaCungCap(id);
                LoadNhaCungCap();
                MessageBox.Show("Nhà cung cấp đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi xóa nhà cung cấp vào XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
