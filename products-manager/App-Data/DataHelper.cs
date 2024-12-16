using products_manager.DTOs;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace products_manager.App_Data
{
    public class DataHelper
    {
        public static DataTable ToDataTable<T>(IEnumerable<T> data)
        {
            var dataTable = new DataTable(typeof(T).Name);

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in data)
            {
                var values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static void WriteToXmlFile<T>(string filePath, List<T> list)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));

                using (var writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, list);
                }

                Console.WriteLine("Đã tạo file XML thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi ghi file XML: {ex.Message}");
            }
        }
        public static TaiKhoan ReadXmlTaiKhoan(string filePath)
        {
            try
            {
                XElement xml = XElement.Load(filePath);

                TaiKhoan taiKhoan = new TaiKhoan
                {
                    Id = int.Parse(xml.Element("Id")?.Value ?? "0"),
                    HoTen = xml.Element("HoTen")?.Value,
                    Email = xml.Element("Email")?.Value,
                    MatKhau = xml.Element("MatKhau")?.Value
                };

                return taiKhoan;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void DeleteGioHangDtoByIdSanPham(string filePath, int idSanPham)
        {
            try
            {
                // Deserialize file XML thành danh sách GioHangDTO
                var serializer = new XmlSerializer(typeof(List<GioHangDTO>));
                List<GioHangDTO> gioHangDTOs;

                using (var reader = new StreamReader(filePath))
                {
                    gioHangDTOs = (List<GioHangDTO>)serializer.Deserialize(reader);
                }

                // Tìm và xóa sản phẩm dựa trên IdSanPham
                var gioHangToRemove = gioHangDTOs.FirstOrDefault(g => g.IdSanPham == idSanPham);
                if (gioHangToRemove != null)
                {
                    gioHangDTOs.Remove(gioHangToRemove);
                }
                else
                {
                    throw new Exception("Không tìm thấy sản phẩm cần xóa trong danh sách.");
                }

                // Serialize lại danh sách và ghi vào file
                using (var writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, gioHangDTOs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteSanPhamFromGioHangXML(string filePath, int idSanPham)
        {
            XDocument doc = XDocument.Load(filePath);
            var productToDelete = doc.Descendants("GioHangDTO")
                          .FirstOrDefault(p => (int)p.Element("IdSanPham") == idSanPham);
            if (productToDelete != null)
            {
                productToDelete.Remove();
            }

            // Lưu file XML
            doc.Save(filePath);
        }

    }
}
