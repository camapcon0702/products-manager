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
using System.Xml.Serialization;

namespace products_manager
{
    public partial class DanhMucControl : UserControl
    {
        private readonly DanhMucRepository _repository;
        public DanhMucControl()
        {
            InitializeComponent();
            _repository = new DanhMucRepository(new AppDataContext());
        }

        public void LoadDanhMuc()
        {
            try
            {
                List<DanhMuc> danhMucList = _repository.ReadXmlDanhMuc("../Data/DanhMuc.xml");
                DataTable dataTable = _repository.ToDataTable(danhMucList);
                dgvDanhMuc.DataSource = dataTable;

                dgvDanhMuc.Columns["Id"].HeaderText = "Mã danh mục";
                dgvDanhMuc.Columns["TenDanhMuc"].HeaderText = "Tên danh mục";
                dgvDanhMuc.Columns["MoTa"].HeaderText = "Mô tả";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi tải dữ liệu từ XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DanhMucControl_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
        }

        private void dgvDanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectRow = dgvDanhMuc.Rows[e.RowIndex];
                string tenDanhMuc = selectRow.Cells["TenDanhMuc"].Value?.ToString();
                string moTa = selectRow.Cells["MoTa"].Value?.ToString();

                tbDanhMuc.Text = tenDanhMuc;
                tbMoTa.Text = moTa;
            }
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            string tenDanhMuc = tbDanhMuc.Text.Trim();
            string moTa = tbMoTa.Text.Trim();

            if (string.IsNullOrEmpty(tenDanhMuc) || string.IsNullOrEmpty(moTa))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _repository.AddDanhMucToXml(tenDanhMuc, moTa);

                LoadDanhMuc();

                MessageBox.Show("Danh mục đã được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi thêm danh mục vào XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvDanhMuc.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            if (selectedRow == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
            string tenDanhMuc = tbDanhMuc.Text.Trim();
            string moTa = tbMoTa.Text.Trim();

            DanhMuc danhMucToUpdate = new DanhMuc
            {
                Id = id,
                TenDanhMuc = tenDanhMuc,
                MoTa = moTa
            };
            try
            {
                await _repository.UpdateDanhMuc(danhMucToUpdate);
                LoadDanhMuc();

                MessageBox.Show("Danh mục đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi cập nhật danh mục vào XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            var selectedRow = dgvDanhMuc.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();
            if (selectedRow == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);

            try
            {
                await _repository.DeleteDanhMuc(id);
                LoadDanhMuc();
                MessageBox.Show("Danh mục đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi xóa danh mục vào XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
