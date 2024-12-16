using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
    }
}
