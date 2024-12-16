using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Interfaces
{
    public interface INhaCungCapRepository
    {
        public Task<DataTable> GetAllNhaCungCap();
        public Task<NhaCungCap> GetNhaCungCapById(int id);
        public Task AddNhaCungCapToXml(string nhaCungCap, string diaChi, string soDienThoai);
        public Task DeleteNhaCungCap(int id);
        public Task UpdateNhaCungCap(NhaCungCap nhaCungCap);
        public void CreateXmlNhaCungCap();
        public List<NhaCungCap> ReadXmlNhaCungCap(string filePath);
        public DataTable ToDataTable(List<NhaCungCap> nhaCungCaps);
        public Task UpdateDatabaseFromXml(List<NhaCungCap> nhaCungCaps);
    }
}
