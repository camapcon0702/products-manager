using Microsoft.EntityFrameworkCore;
using products_manager.App_Data;
using products_manager.Interfaces;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Repositories
{
    public class DonHangRepository : IDonHangRepository
    {
        public readonly AppDataContext _context;
        public readonly ITaiKhoanRepository _taiKhoanRepository;
        public DonHangRepository(AppDataContext context)
        {
            _context = context;
            _taiKhoanRepository = new TaiKhoanRepository(context);
        }

        public DataTable GetDonHangByUser()
        {
            var currentUser = _taiKhoanRepository.FindTaiKhoanByAuth();
            var donhangs = _context.donHangs
                .Include(d => d.TaiKhoan)
                .Include(d => d.chiTietDonHangs)
                .Where(d => d.TaiKhoan.Id ==  currentUser.Id)
                .ToList();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("NgayLapDon", typeof(DateOnly));
            dataTable.Columns.Add("TongTien", typeof(decimal));

            foreach (var donHang in donhangs)
            {
                decimal tongTien = donHang.chiTietDonHangs
                    .Sum(ct => ct.SoLuong * (decimal)ct.GiaBan);

                dataTable.Rows.Add(donHang.Id, donHang.NgayLapDon, tongTien);
            }

            return dataTable;
        }
    }
}
