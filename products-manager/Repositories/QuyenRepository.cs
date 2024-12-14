using products_manager.App_Data;
using products_manager.Interfaces;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Repositories
{
    public class QuyenRepository : IQuyenRepository
    {
        private readonly AppDataContext _context;
        public QuyenRepository(AppDataContext context)
        {
            _context = context;
        }

        public async Task<Quyen> FindQuyenById(int id)
        {
            return await _context.quyens.FindAsync(id);
        }
    }
}
