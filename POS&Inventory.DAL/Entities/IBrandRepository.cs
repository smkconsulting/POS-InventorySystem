using POS_Inventory.BO.Models;
using System.Collections.Generic;

namespace POS_Inventory.DAL.Entities
{
    public interface IBrandRepository
    {
        void Add(BrandBO entity);
        int Count();
        void Delete(BrandBO entity);
        BrandBO Get(string id);
        IEnumerable<BrandBO> GetAll();
        void Update(BrandBO entity);
    }
}