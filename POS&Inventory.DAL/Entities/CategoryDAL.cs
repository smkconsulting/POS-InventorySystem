using POS_Inventory.BO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory.DAL.Entities
{
    public class CategoryDAL : ICategoryRepository
    {
        private readonly IDatabase _database;

        public CategoryDAL(IDatabase database)
        {
            _database = database;
        }
        public void Add(CategoryBO entity)
        {
            _database.CommandText = "insert into [Categories] ([Name]) values (@name)";
            _database.Parameters = new List<MyDbParater>();
            _database.ParameterList = new List<IDbDataParameter>();
            _database.Parameters.Add(new MyDbParater("@name", entity.Name));
            _database.ConvertParameters();
            _database.Execute();
        }
        public int Count()
        {
            _database.CommandText = "select count(*) from [Categories]";
            return _database.ExecuteInt();
        }
        public void Delete(CategoryBO entity)
        {
            _database.CommandText = "delete from [Categories] where [CategoryId] = @id";
            _database.Parameters = new List<MyDbParater>();
            _database.ParameterList = new List<IDbDataParameter>();
            _database.Parameters.Add(new MyDbParater("@id", entity.CategoryId));
            _database.ConvertParameters();
            _database.Execute();
        }
        public CategoryBO Get(string id)
        {
            _database.CommandText = "select * from [Categories] where [CategoryId] = @id";
            _database.Parameters = new List<MyDbParater>();
            _database.ParameterList = new List<IDbDataParameter>();
            _database.Parameters.Add(new MyDbParater("@id", id));
            _database.ConvertParameters();
            var mytable = _database.SelectData();
            return Map(mytable);
        }
        public IEnumerable<CategoryBO> GetAll()
        {
            _database.CommandText = "select * from [Categories]";
            var mytable = _database.SelectData();
            return MapAll(mytable);
        }
        public void Update(CategoryBO entity)
        {
            _database.CommandText = "update [Categories] set[Name]= @name where [CategoryId] = @id ";
            _database.Parameters = new List<MyDbParater>();
            _database.ParameterList = new List<IDbDataParameter>();
            _database.Parameters.Add(new MyDbParater("@name", entity.Name));
            _database.Parameters.Add(new MyDbParater("@id", entity.CategoryId));
            _database.ConvertParameters();
            _database.Execute();
        }
        private CategoryBO Map(DataTable mytable)
        {
            CategoryBO brand = null;
            if (mytable.Rows.Count > 0)
            {
                brand = new CategoryBO();
                brand.CategoryId = int.Parse(mytable.Rows[0][0].ToString());
                brand.Name = mytable.Rows[0][1].ToString();
            }
            return brand;
        }
        private IEnumerable<CategoryBO> MapAll(DataTable mytable)
        {
            List<CategoryBO> categories = null;
            if (mytable.Rows.Count > 0)
            {
                categories = new List<CategoryBO>();
                for (int i = 0; i < mytable.Rows.Count; i++)
                {
                    var brand = new CategoryBO();
                    brand.CategoryId = int.Parse(mytable.Rows[i][0].ToString());
                    brand.Name = mytable.Rows[i][1].ToString();
                    categories.Add(brand);
                }
            }
            return categories;
        }
    }
}
