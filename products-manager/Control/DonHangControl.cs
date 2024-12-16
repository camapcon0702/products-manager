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
    public partial class DonHangControl : UserControl
    {
        public readonly IDonHangRepository _donHangRepository;
        public readonly IChiTietDonHangRepository _chiTietDonHangRepository;
        public DonHangControl()
        {
            InitializeComponent();
            _donHangRepository = new DonHangRepository(new AppDataContext());
            _chiTietDonHangRepository = new ChiTietDonHangRepository(new AppDataContext());
        }

        private void DonHangControl_Load(object sender, EventArgs e)
        {
            dgvDonHang.DataSource = _donHangRepository.GetDonHangByUser();
        }

        private void dgvDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDonHang.Rows[e.RowIndex];

                int id = int.Parse(selectedRow.Cells["Id"].Value.ToString());
                dgvChiTietDonHang.DataSource = _chiTietDonHangRepository.GetChiTietDonHangAsDataTable(id);
            }
        }
    }
}
