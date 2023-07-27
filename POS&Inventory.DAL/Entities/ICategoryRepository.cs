using POS_Inventory.BO.Models;
using System.Collections.Generic;

namespace POS_Inventory.DAL.Entities
{
    public interface ICategoryRepository
    {
        void Add(CategoryBO entity);
        int Count();
        void Delete(CategoryBO entity);
        CategoryBO Get(string id);
        IEnumerable<CategoryBO> GetAll();
        void Update(CategoryBO entity);
    }
}