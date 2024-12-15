using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Interfaces
{
    public interface IDanhMucRepository
    {
        public Task<DataTable> GetAllDanhMuc();
        public Task AddDanhMucToXml(string tenDanhMuc, string moTa);
        public Task DeleteDanhMuc(int id);
        public Task UpdateDanhMuc(DanhMuc danhMuc);
        public void CreateXmlDanhMuc();
        public List<DanhMuc> ReadXmlDanhMuc(string filePath);
        public DataTable ToDataTable(List<DanhMuc> danhMucs);
        public Task UpdateDatabaseFromXml(List<DanhMuc> danhMucs);
    }
}
