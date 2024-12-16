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
    internal class DanhMucRepository : IDanhMucRepository
    {
        private readonly AppDataContext _context;

        public DanhMucRepository(AppDataContext context)
        {
            _context = context;
        }
        public async Task<DataTable> GetAllDanhMuc()
        {
            var danhMucs = await _context.danhMucs.ToListAsync();
            DataTable dataTable = DataHelper.ToDataTable(danhMucs);
            return dataTable;
        }

        public async void CreateXmlDanhMuc()
        {
            string filePath = "../Data/DanhMuc.xml";

            try
            {
                var danhMucs = await GetAllDanhMuc();
                var danhMucList = new List<DanhMuc>();
                foreach (DataRow row in danhMucs.Rows)
                {
                    var danhMuc = new DanhMuc
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        TenDanhMuc = row["TenDanhMuc"].ToString(),
                        MoTa = row["Mota"].ToString()
                    };
                    danhMucList.Add(danhMuc);
                }
                var serializer = new XmlSerializer(typeof(List<DanhMuc>));
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    serializer.Serialize(writer, danhMucList);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tạo tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<DanhMuc> ReadXmlDanhMuc(string filePath)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<DanhMuc>));
                using (var reader = new StreamReader(filePath))
                {
                    return (List<DanhMuc>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi đọc tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<DanhMuc>();
            }
        }

        public DataTable ToDataTable(List<DanhMuc> danhMucs)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("TenDanhMuc");
            dt.Columns.Add("MoTa");

            foreach (var item in danhMucs)
            {
                dt.Rows.Add(item.Id, item.TenDanhMuc, item.MoTa);
            }
            return dt;
        }

        public async Task UpdateDatabaseFromXml(List<DanhMuc> danhMucs)
        {
            var existingDanhMucs = await _context.danhMucs.ToListAsync();

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (var danhMuc in danhMucs)
                {
                    var existingDanhMuc = await _context.danhMucs
                        .FirstOrDefaultAsync(d => d.Id == danhMuc.Id);

                    if (existingDanhMuc != null)
                    {
                        existingDanhMuc.TenDanhMuc = danhMuc.TenDanhMuc;
                        existingDanhMuc.MoTa = danhMuc.MoTa;

                        _context.Update(existingDanhMuc);
                    }
                    else
                    {
                        _context.danhMucs.Add(new DanhMuc
                        {
                            TenDanhMuc = danhMuc.TenDanhMuc,
                            MoTa = danhMuc.MoTa
                        });
                    }
                }

                foreach (var existingDanhMuc in existingDanhMucs)
                {
                    var danhMucFromXml = danhMucs.FirstOrDefault(d => d.Id == existingDanhMuc.Id);
                    if (danhMucFromXml == null)
                    {
                        _context.danhMucs.Remove(existingDanhMuc);
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

        public async Task AddDanhMucToXml(string tenDanhMuc, string moTa)
        {
            string filePath = "../Data/DanhMuc.xml";

            try
            {
                var danhMucs = ReadXmlDanhMuc(filePath);

                int newId = danhMucs.Count > 0 ? danhMucs.Max(d => d.Id) + 1 : 1;

                DanhMuc newDanhMuc = new DanhMuc
                {
                    Id = newId,
                    TenDanhMuc = tenDanhMuc,
                    MoTa = moTa
                };

                danhMucs.Add(newDanhMuc);

                var serializer = new XmlSerializer(typeof(List<DanhMuc>));
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    await Task.Run(() => serializer.Serialize(writer, danhMucs));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi thêm danh mục vào XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task DeleteDanhMuc(int id)
        {
            try
            {
                string filePath = "../Data/DanhMuc.xml";
                var danhMucs = ReadXmlDanhMuc(filePath);
                var danhMucToRemove = danhMucs.FirstOrDefault(d => d.Id == id);
                if (danhMucToRemove == null)
                {
                    MessageBox.Show("Không tìm thấy danh mục cần xóa trong tệp XML.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                danhMucs.Remove(danhMucToRemove);

                var serializer = new XmlSerializer(typeof(List<DanhMuc>));
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    await Task.Run(() => serializer.Serialize(writer, danhMucs));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xóa danh mục trong tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task UpdateDanhMuc(DanhMuc danhMuc)
        {
            try
            {
                string filePath = "../Data/DanhMuc.xml";
                var danhMucs = ReadXmlDanhMuc(filePath);
                var danhMucToUpdate = danhMucs.FirstOrDefault(d => d.Id == danhMuc.Id);
                if (danhMucToUpdate == null)
                {
                    MessageBox.Show("Không tìm thấy danh mục cần cập nhật trong tệp XML.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                danhMucToUpdate.TenDanhMuc = danhMuc.TenDanhMuc;
                danhMucToUpdate.MoTa = danhMuc.MoTa;

                var serializer = new XmlSerializer(typeof(List<DanhMuc>));
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    await Task.Run(() => serializer.Serialize(writer, danhMucs));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi cập nhật danh mục trong tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
