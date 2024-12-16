using Microsoft.EntityFrameworkCore;
using products_manager.App_Data;
using products_manager.Control;
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
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly AppDataContext _context;
        private readonly DanhMucRepository _danhMucRepository;
        private readonly NhaCungCapRepository _nhaCungCapRepository;
        public SanPhamRepository(AppDataContext context)
        {
            _context = context;
            _danhMucRepository = new DanhMucRepository(context);
            _nhaCungCapRepository = new NhaCungCapRepository(context);
        }

        public async Task AddSanPhamToXml(string tenSanPham, string hinhAnh, float donGia, int soLuongCon, DanhMuc danhMuc, NhaCungCap nhaCungCap)
        {
            string filePath = "../Data/SanPham.xml";
            try
            {
                var sanPhams = ReadXmlSanPham(filePath);

                int newId = sanPhams.Count > 0 ? sanPhams.Max(s => s.Id) + 1 : 1;

                SanPham newSanPham = new SanPham
                {
                    Id = newId,
                    TenSanPham = tenSanPham,
                    HinhAnh = hinhAnh,
                    DonGia = donGia,
                    SoLuongCon = soLuongCon,
                    DanhMuc = danhMuc,
                    NhaCungCap = nhaCungCap
                };

                sanPhams.Add(newSanPham);

                var serializer = new XmlSerializer(typeof(List<SanPham>));
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    await Task.Run(() => serializer.Serialize(writer, sanPhams));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi thêm sản phẩm vào XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void CreateXmlSanPham()
        {
            string filePath = "../Data/SanPham.xml";
            try
            {
                var sanPhams = await GetAllSanPhamData();
                var sanPhamList = new List<SanPham>();

                foreach (DataRow row in sanPhams.Rows)
                {
                    var danhMuc = await _danhMucRepository.GetDanhMucById(Convert.ToInt32(row["DanhMuc"]));
                    var nhaCungCap = await _nhaCungCapRepository.GetNhaCungCapById(Convert.ToInt32(row["NhaCungCap"]));
                    var sanPham = new SanPham
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        TenSanPham = row["TenSanPham"].ToString(),
                        HinhAnh = row["HinhAnh"].ToString(),
                        DonGia = Convert.ToSingle(row["DonGia"]),
                        SoLuongCon = Convert.ToInt32(row["SoLuongCon"]),
                        DanhMuc = new DanhMuc
                        {
                            Id = Convert.ToInt32(row["DanhMuc"]),
                            TenDanhMuc = danhMuc.TenDanhMuc
                        },
                        NhaCungCap = new NhaCungCap
                        {
                            Id = Convert.ToInt32(row["NhaCungCap"]),
                            TenNhaCungCap = nhaCungCap.TenNhaCungCap
                        }
                    };
                    sanPhamList.Add(sanPham);
                }
                var serializer = new XmlSerializer(typeof(List<SanPham>));
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    serializer.Serialize(writer, sanPhamList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tạo tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task DeleteSanPham(int id)
        {
            string filePath = "../Data/SanPham.xml";

            try
            {
                var sanPhams = ReadXmlSanPham(filePath);
                var sanPhamToDelete = sanPhams.FirstOrDefault(sp => sp.Id == id);

                if (sanPhamToDelete != null)
                {
                    sanPhams.Remove(sanPhamToDelete);
                    var serializer = new XmlSerializer(typeof(List<SanPham>));
                    using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        await Task.Run(() => serializer.Serialize(writer, sanPhams));
                    }

                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm với ID đã cho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task<DataTable> GetAllSanPhamData()
        {
            var sanPhams = await _context.sanPhams
                    .Include(sp => sp.DanhMuc)
                    .Include(sp => sp.NhaCungCap)
                    .ToListAsync();
            return ToDataTable(sanPhams);
        }


        public List<SanPham> GetAllSanPhams()
        {
            return _context.sanPhams.ToList();
        }

        public SanPham GetSanPhamById(int idSanPham)
        {
            return _context
                .sanPhams
                .Find(idSanPham);
        }

        public List<SanPham> ReadXmlSanPham(string filePath)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<SanPham>));

                using (var reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    var sanPhamList = (List<SanPham>)serializer.Deserialize(reader);
                    return sanPhamList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi đọc tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public List<SanPhamItem> SanPhamsToControls()
        {
            var sanPhams = GetAllSanPhams();
            var items = new List<SanPhamItem>();
            foreach (var item in sanPhams)
            {
                items.Add(new SanPhamItem(item));
            }
            return items;
        }

        public DataTable ToDataTable(List<SanPham> sanPhams)
        {
            var dataTable = new DataTable();

            // Thêm các cột vào DataTable
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("TenSanPham", typeof(string));
            dataTable.Columns.Add("HinhAnh", typeof(string));
            dataTable.Columns.Add("DonGia", typeof(float));
            dataTable.Columns.Add("SoLuongCon", typeof(int));
            dataTable.Columns.Add("DanhMuc", typeof(int));
            dataTable.Columns.Add("NhaCungCap", typeof(int));

            // Thêm dữ liệu vào DataTable
            foreach (var sanPham in sanPhams)
            {
                dataTable.Rows.Add(
                    sanPham.Id,
                    sanPham.TenSanPham,
                    sanPham.HinhAnh,
                    sanPham.DonGia,
                    sanPham.SoLuongCon,
                    sanPham.DanhMuc?.Id,
                    sanPham.NhaCungCap?.Id
                );
            }

            return dataTable;
        }

        public async Task UpdateDatabaseFromXml(List<SanPham> sanPhams)
        {
            var existingSanPhams = await _context.sanPhams
                .Include(s => s.DanhMuc)
                .Include(s => s.NhaCungCap)
                .ToListAsync();

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Cập nhật hoặc thêm các sản phẩm mới
                foreach (var sanPham in sanPhams)
                {
                    var existingSanPham = await _context.sanPhams
                        .FirstOrDefaultAsync(s => s.Id == sanPham.Id);

                    if (existingSanPham != null)
                    {
                        // Nếu đã có, cập nhật thông tin
                        existingSanPham.TenSanPham = sanPham.TenSanPham;
                        existingSanPham.HinhAnh = sanPham.HinhAnh;
                        existingSanPham.DonGia = sanPham.DonGia;
                        existingSanPham.SoLuongCon = sanPham.SoLuongCon;
                        existingSanPham.DanhMuc.Id = sanPham.DanhMuc.Id;
                        existingSanPham.NhaCungCap.Id = sanPham.NhaCungCap.Id;

                        _context.Update(existingSanPham);
                    }
                    else
                    {
                        // Nếu chưa có, thêm mới
                        _context.sanPhams.Add(new SanPham
                        {
                            TenSanPham = sanPham.TenSanPham,
                            HinhAnh = sanPham.HinhAnh,
                            DonGia = sanPham.DonGia,
                            SoLuongCon = sanPham.SoLuongCon,
                            DanhMuc = sanPham.DanhMuc,
                            NhaCungCap = sanPham.NhaCungCap
                        });
                    }
                }

                foreach (var existingSanPham in existingSanPhams)
                {
                    var sanPhamFromXml = sanPhams.FirstOrDefault(s => s.Id == existingSanPham.Id);
                    if (sanPhamFromXml == null)
                    {
                        _context.sanPhams.Remove(existingSanPham);
                    }
                }

                // 3. Lưu các thay đổi
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

            }
            catch (Exception ex)
            {
                // Nếu có lỗi, rollback giao dịch và thông báo lỗi
                await transaction.RollbackAsync();
                MessageBox.Show($"Có lỗi khi cập nhật cơ sở dữ liệu sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async Task UpdateSanPham(SanPham sanPham)
        {
            string filePath = "../Data/SanPham.xml";

            try
            {
                var sanPhams = ReadXmlSanPham(filePath);

                var existingSanPham = sanPhams.FirstOrDefault(sp => sp.Id == sanPham.Id);
                if (existingSanPham != null)
                {
                    existingSanPham.TenSanPham = sanPham.TenSanPham;
                    existingSanPham.HinhAnh = sanPham.HinhAnh;
                    existingSanPham.DonGia = sanPham.DonGia;
                    existingSanPham.SoLuongCon = sanPham.SoLuongCon;
                    existingSanPham.DanhMuc = sanPham.DanhMuc;
                    existingSanPham.NhaCungCap = sanPham.NhaCungCap;

                    var serializer = new XmlSerializer(typeof(List<SanPham>));
                    using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        await Task.Run(() => serializer.Serialize(writer, sanPhams));
                    }

                }
                else
                {
                    MessageBox.Show("Sản phẩm không tồn tại trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi cập nhật sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
