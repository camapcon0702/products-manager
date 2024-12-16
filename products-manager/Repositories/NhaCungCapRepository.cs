using Microsoft.EntityFrameworkCore;
using products_manager.App_Data;
using products_manager.Interfaces;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace products_manager.Repositories
{
    internal class NhaCungCapRepository : INhaCungCapRepository
    {
        private readonly AppDataContext _context;
        public NhaCungCapRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task AddNhaCungCapToXml(string nhaCungCap, string diaChi, string soDienThoai)
        {
            string filePath = "../Data/NhaCungCap.xml";

            try
            {
                var nhaCungCaps = ReadXmlNhaCungCap(filePath);

                int newId = nhaCungCaps.Count > 0 ? nhaCungCaps.Max(d => d.Id) + 1 : 1;

                NhaCungCap newNhaCungCap = new NhaCungCap
                {
                    Id = newId,
                    TenNhaCungCap = nhaCungCap,
                    DiaChi = diaChi,
                    SoDienThoai = soDienThoai
                };

                nhaCungCaps.Add(newNhaCungCap);

                var serializer = new XmlSerializer(typeof(List<NhaCungCap>));
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    await Task.Run(() => serializer.Serialize(writer, nhaCungCaps));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi thêm nhà cung cấp vào XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void CreateXmlNhaCungCap()
        {

            string filePath = "../Data/NhaCungCap.xml";

            try
            {
                var nhaCungCaps = await GetAllNhaCungCap();
                var nhaCungCapList = new List<NhaCungCap>();
                foreach (DataRow row in nhaCungCaps.Rows)
                {
                    var nhaCungCap = new NhaCungCap
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        TenNhaCungCap = row["TenNhaCungCap"].ToString(),
                        DiaChi = row["DiaChi"].ToString(),
                        SoDienThoai = row["SoDienThoai"].ToString()
                    };
                    nhaCungCapList.Add(nhaCungCap);
                }
                var serializer = new XmlSerializer(typeof(List<NhaCungCap>));
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    serializer.Serialize(writer, nhaCungCapList);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tạo tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task DeleteNhaCungCap(int id)
        {
            try
            {
                string filePath = "../Data/NhaCungCap.xml";
                var nhaCungCaps = ReadXmlNhaCungCap(filePath);
                var nhaCungCapToRemove = nhaCungCaps.FirstOrDefault(d => d.Id == id);
                if (nhaCungCapToRemove == null)
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp cần xóa trong tệp XML.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                nhaCungCaps.Remove(nhaCungCapToRemove);

                var serializer = new XmlSerializer(typeof(List<NhaCungCap>));
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    await Task.Run(() => serializer.Serialize(writer, nhaCungCaps));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xóa nhà cung cấp trong tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<DataTable> GetAllNhaCungCap()
        {
            var nhaCungCaps = await _context.nhaCungCaps.ToListAsync();
            DataTable dataTable = DataHelper.ToDataTable(nhaCungCaps);
            return dataTable;
        }

        public List<NhaCungCap> ReadXmlNhaCungCap(string filePath)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<NhaCungCap>));
                using (var reader = new StreamReader(filePath))
                {
                    return (List<NhaCungCap>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi đọc tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<NhaCungCap>();
            }
        }

        public DataTable ToDataTable(List<NhaCungCap> nhaCungCaps)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("TenNhaCungCap");
            dt.Columns.Add("DiaChi");
            dt.Columns.Add("SoDienThoai");

            foreach (var item in nhaCungCaps)
            {
                dt.Rows.Add(item.Id, item.TenNhaCungCap, item.DiaChi, item.SoDienThoai);
            }
            return dt;
        }

        public async Task UpdateDatabaseFromXml(List<NhaCungCap> nhaCungCaps)
        {
            var existingNhaCungCaps = await _context.nhaCungCaps.ToListAsync();

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (var nhaCungCap in nhaCungCaps)
                {
                    var existingNhaCungCap = await _context.nhaCungCaps
                        .FirstOrDefaultAsync(d => d.Id == nhaCungCap.Id);

                    if (existingNhaCungCap != null)
                    {
                        existingNhaCungCap.TenNhaCungCap = nhaCungCap.TenNhaCungCap;
                        existingNhaCungCap.DiaChi = nhaCungCap.DiaChi;
                        existingNhaCungCap.SoDienThoai = nhaCungCap.SoDienThoai;
                        _context.Update(existingNhaCungCap);
                    }
                    else
                    {
                        _context.nhaCungCaps.Add(new NhaCungCap
                        {
                            TenNhaCungCap = nhaCungCap.TenNhaCungCap,
                            DiaChi = nhaCungCap.DiaChi,
                            SoDienThoai = nhaCungCap.SoDienThoai
                        });
                    }
                }

                foreach (var existingNhaCungCap in existingNhaCungCaps)
                {
                    var nhaCungCapFromXml = nhaCungCaps.FirstOrDefault(d => d.Id == existingNhaCungCap.Id);
                    if (nhaCungCapFromXml == null)
                    {
                        _context.nhaCungCaps.Remove(existingNhaCungCap);
                    }
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi cập nhật cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task UpdateNhaCungCap(NhaCungCap nhaCungCap)
        {
            try
            {
                string filePath = "../Data/NhaCungCap.xml";
                var nhaCungCaps = ReadXmlNhaCungCap(filePath);
                var nhaCungCapToUpdate = nhaCungCaps.FirstOrDefault(d => d.Id == nhaCungCap.Id);
                if (nhaCungCapToUpdate == null)
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp cần cập nhật trong tệp XML.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                nhaCungCapToUpdate.TenNhaCungCap = nhaCungCap.TenNhaCungCap;
                nhaCungCapToUpdate.DiaChi = nhaCungCap.DiaChi;
                nhaCungCapToUpdate.SoDienThoai = nhaCungCap.SoDienThoai;

                var serializer = new XmlSerializer(typeof(List<NhaCungCap>));
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    await Task.Run(() => serializer.Serialize(writer, nhaCungCaps));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi cập nhật nhà cung cấp trong tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
