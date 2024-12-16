using products_manager.Control;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Interfaces
{
    public interface ISanPhamRepository
    {
        public List<SanPham> GetAllSanPhams();
        public List<SanPhamItem> SanPhamsToControls();
        public SanPham GetSanPhamById(int idSanPham);
        public Task<DataTable> GetAllSanPhamData();
        public Task AddSanPhamToXml(string tenSanPham, string hinhAnh, float donGia, int soLuongCon, DanhMuc danhMuc, NhaCungCap nhaCungCap);
        public Task DeleteSanPham(int id);
        public Task UpdateSanPham(SanPham sanPham);
        public void CreateXmlSanPham();
        public List<SanPham> ReadXmlSanPham(string filePath);
        public DataTable ToDataTable(List<SanPham> sanPhams);
        public Task UpdateDatabaseFromXml(List<SanPham> sanPhams);
    }
}
