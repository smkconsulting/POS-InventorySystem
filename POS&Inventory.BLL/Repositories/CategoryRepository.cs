using POS_Inventory.BO.Models;
using POS_Inventory.DAL.Entities;
using POS_Inventory.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory.BLL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDAL _context;
        public CategoryRepository()
        {
            _context = new CategoryDAL(DatabaseCreator.GetDatabase());
        }
        public void Add(CategoryBO entity)
        {
            _context.Add(entity);
        }

        public int Count()
        {
            return _context.Count();
        }

        public void Delete(CategoryBO entity)
        {
            _context.Delete(entity);
        }

        public CategoryBO Get(string id)
        {
            return _context.Get(id.ToString());
        }

        public IEnumerable<CategoryBO> GetAll()
        {
            return _context.GetAll();
        }

        public void Update(CategoryBO entity)
        {
            _context.Update(entity);
        }
    }
}
