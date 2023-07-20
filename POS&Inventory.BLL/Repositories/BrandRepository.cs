using POS_Inventory.BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_Inventory.DAL;
using POS_Inventory.DAL.Entities;

namespace POS_Inventory.BLL.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly BrandDAL _context;
        public BrandRepository()
        {
            _context = new BrandDAL(DatabaseCreator.GetDatabase());
        }
        public void Add(BrandBO entity)
        {
            _context.Add(entity);
        }

        public int Count()
        {
            return _context.Count();
        }

        public void Delete(BrandBO entity)
        {
            _context.Delete(entity);
        }

        public BrandBO Get(string id)
        {
            return _context.Get(id.ToString());
        }

        public IEnumerable<BrandBO> GetAll()
        {
            return _context.GetAll();
        }

        public void Update(BrandBO entity)
        {
            _context.Update(entity);
        }
    }
}
