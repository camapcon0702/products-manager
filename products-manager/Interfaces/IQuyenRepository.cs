using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Interfaces
{
    public interface IQuyenRepository
    {
        public Task<Quyen> FindQuyenById(int id);
    }
}
