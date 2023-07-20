
using POS_Inventory.BO.Models;
using POS_Inventory.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Inventory.DAL.Entities
{
    public class BrandDAL : ICrud<BrandBO>, IBrandRepository
    {
        private readonly IDatabase _database;

        public BrandDAL(IDatabase database)
        {
            _database = database;
        }
        public void Add(BrandBO entity)
        {
            _database.CommandText = "insert into [Brands] ([Name]) values (@name)";
            _database.Parameters = new List<MyDbParater>();
            _database.ParameterList = new List<IDbDataParameter>();
            _database.Parameters.Add(new MyDbParater("@name", entity.Name));
            _database.ConvertParameters();
            _database.Execute();
        }
        public int Count()
        {
            _database.CommandText = "select count(*) from [Brands]";
            return _database.ExecuteInt();
        }
        public void Delete(BrandBO entity)
        {
            _database.CommandText = "delete from [Brands] where [BrandId] = @id";
            _database.Parameters = new List<MyDbParater>();
            _database.ParameterList = new List<IDbDataParameter>();
            _database.Parameters.Add(new MyDbParater("@id", entity.BrandId));
            _database.ConvertParameters();
            _database.Execute();
        }
        public BrandBO Get(string id)
        {
            _database.CommandText = "select * from [Brands] where [BrandId] = @id";
            _database.Parameters = new List<MyDbParater>();
            _database.ParameterList = new List<IDbDataParameter>();
            _database.Parameters.Add(new MyDbParater("@id", id));
            _database.ConvertParameters();
            var mytable = _database.SelectData();
            return Map(mytable);
        }
        public IEnumerable<BrandBO> GetAll()
        {
            _database.CommandText = "select * from [Brands]";
            var mytable = _database.SelectData();
            return MapAll(mytable);
        }
        public void Update(BrandBO entity)
        {
            _database.CommandText = "update [Brands] set[Name]= @name where [BrandId] = @id ";
            _database.Parameters = new List<MyDbParater>();
            _database.ParameterList = new List<IDbDataParameter>();
            _database.Parameters.Add(new MyDbParater("@name", entity.Name));
            _database.Parameters.Add(new MyDbParater("@id", entity.BrandId));
            _database.ConvertParameters();
            _database.Execute();
        }
        private BrandBO Map(DataTable mytable)
        {
            BrandBO brand = null;
            if (mytable.Rows.Count > 0)
            {
                brand = new BrandBO();
                brand.BrandId = int.Parse(mytable.Rows[0][0].ToString());
                brand.Name = mytable.Rows[0][1].ToString();
            }
            return brand;
        }
        private IEnumerable<BrandBO> MapAll(DataTable mytable)
        {
            List<BrandBO> brands = null;
            if (mytable.Rows.Count > 0)
            {
                brands = new List<BrandBO>();
                for (int i = 0; i < mytable.Rows.Count; i++)
                {
                    var brand = new BrandBO();
                    brand.BrandId = int.Parse(mytable.Rows[i][0].ToString());
                    brand.Name = mytable.Rows[i][1].ToString();
                    brands.Add(brand);
                }
            }
            return brands;
        }
    }
}
//#region copiedcode
//namespace CableManager.DAL.Entities
//{
//    public class CustomerDA : ICrud<CustomerBO>
//    {
//        private IDatabase _database;

//        //constructor
//        public CustomerDA(IDatabase database)
//        {
//            _database = database;
//        }
//        public void Add(CustomerBO entity)
//        {
//            _database.CommandText = "insert into [Customer] ([customerId], [Firstname], [Lastname], [zone],[residence],[prepaid], [rate], [status], [telephone], [idcardnumber],[connectionDate]) values (@id,@FN,@ln,@zone,@residence,@prepaid,@rate,@status,@telephone,@idcardnumber,@connectionDate)";
//            _database.Parameters = new List<MyDbParater>();
//            _database.ParameterList = new List<IDbDataParameter>();
//            _database.Parameters.Add(new MyDbParater("@id", entity.CustomerId));
//            _database.Parameters.Add(new MyDbParater("@FN", entity.FirstName));
//            _database.Parameters.Add(new MyDbParater("@ln", entity.LastName));
//            _database.Parameters.Add(new MyDbParater("@zone", entity.Zone));
//            _database.Parameters.Add(new MyDbParater("@residence", entity.Residence));
//            _database.Parameters.Add(new MyDbParater("@prepaid", entity.Prepaid));
//            _database.Parameters.Add(new MyDbParater("@rate", entity.Rate));
//            _database.Parameters.Add(new MyDbParater("@status", "Active"));
//            _database.Parameters.Add(new MyDbParater("@telephone", int.Parse(entity.Telephone)));
//            _database.Parameters.Add(new MyDbParater("@idcardnumber", entity.IdCardNumber));
//            _database.Parameters.Add(new MyDbParater("@connectionDate", DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString()));
//            _database.ConvertParameters();
//            _database.Execute();
//        }
//        public int Count()
//        {
//            _database.CommandText = "select count(*) from [Customer]";
//            return _database.ExecuteInt();
//        }
//        public void DeleteRange(IEnumerable<CustomerBO> entities)
//        {
//            var entity = entities.ToList<CustomerBO>();

//            _database.CommandText = "DELETE Customer.Zone FROM Customer WHERE Customer.Zone = @zone";
//            _database.Parameters = new List<MyDbParater>();
//            _database.ParameterList = new List<IDbDataParameter>();
//            _database.Parameters.Add(new MyDbParater("@zone", entity[0].Zone));
//            _database.ConvertParameters();
//            _database.Execute();
//        }
//        public void Delete(CustomerBO entity)
//        {
//            _database.CommandText = "delete from [customer] where [customerID] = @id";
//            _database.Parameters = new List<MyDbParater>();
//            _database.ParameterList = new List<IDbDataParameter>();
//            _database.Parameters.Add(new MyDbParater("@id", entity.CustomerId));
//            _database.ConvertParameters();
//            _database.Execute();
//        }
//        public void DeleteByZone(string zone)
//        {
//            _database.CommandText = "DELETE Customer.Zone FROM Customer WHERE Customer.Zone = @zone";
//            _database.Parameters = new List<MyDbParater>();
//            _database.ParameterList = new List<IDbDataParameter>();
//            _database.Parameters.Add(new MyDbParater("@zone", zone));
//            _database.ConvertParameters();
//            _database.Execute();

//            //the following commented code works for a delete stored proced stored in the database
//            //*************************************************************************************

//            //_database.CommandText = "DeleteByZone";
//            //_database.Parameters = new List<MyDbParater>();
//            //_database.ParameterList = new List<IDbDataParameter>();
//            //_database.Parameters.Add(new MyDbParater("@shit", zone)); //since you are using a store procedure.
//            //_database.ConvertParameters();                          //u can call the parameter anything, @id, @shit
//            //_database.Execute();

//        }
//        public CustomerBO Get(string id)
//        {
//            _database.CommandText = "select * from [customer] where [customerID] = @id";
//            _database.Parameters = new List<MyDbParater>();
//            _database.ParameterList = new List<IDbDataParameter>();
//            _database.Parameters.Add(new MyDbParater("@id", id));
//            _database.ConvertParameters();
//            var mytable = _database.SelectData();
//            return Map(mytable);
//        }
//        public IEnumerable<CustomerBO> GetAll()
//        {
//            _database.CommandText = "select * from [customer]";
//            var mytable = _database.SelectData();
//            return MapAll(mytable);
//        }
//        public IEnumerable<CustomerBO> GetAllByZone(string zone)
//        {
//            _database.CommandText = "select * from [customer] where [zone] = @zone";
//            _database.Parameters = new List<MyDbParater>();
//            _database.ParameterList = new List<IDbDataParameter>();
//            _database.Parameters.Add(new MyDbParater("@zone", zone));
//            _database.ConvertParameters();
//            var mytable = _database.SelectData();
//            return MapAll(mytable);
//        }
//        public IEnumerable<CustomerBO> GetAllByStatus(string status)
//        {
//            _database.CommandText = "select * from [customer] where [Status] = @status";
//            _database.Parameters = new List<MyDbParater>();
//            _database.ParameterList = new List<IDbDataParameter>();
//            _database.Parameters.Add(new MyDbParater("@status", status));
//            _database.ConvertParameters();
//            var mytable = _database.SelectData();
//            return MapAll(mytable);
//        }
//        public void Update(CustomerBO entity)
//        {
//            _database.CommandText = "update [Customer] set[Firstname]= @FN, [Lastname]=@ln,[residence]=@residence,[zone]=@zone,[prepaid]=@prepaid, " +
//                                   "[rate]=@rate,[telephone]=@telephone,[idcardnumber]=@idcardnumber, [Status]=@status where [customerId] = @id ";
//            _database.Parameters = new List<MyDbParater>();
//            _database.ParameterList = new List<IDbDataParameter>();
//            _database.Parameters.Add(new MyDbParater("@FN", entity.FirstName));
//            _database.Parameters.Add(new MyDbParater("@ln", entity.LastName));
//            _database.Parameters.Add(new MyDbParater("@residence", entity.Residence));
//            _database.Parameters.Add(new MyDbParater("@zone", entity.Zone));
//            _database.Parameters.Add(new MyDbParater("@prepaid", entity.Prepaid));
//            _database.Parameters.Add(new MyDbParater("@rate", entity.Rate));
//            _database.Parameters.Add(new MyDbParater("@telephone", int.Parse(entity.Telephone)));
//            _database.Parameters.Add(new MyDbParater("@idcardnumber", entity.IdCardNumber));
//            _database.Parameters.Add(new MyDbParater("@status", entity.Status));
//            _database.Parameters.Add(new MyDbParater("@id", entity.CustomerId));
//            _database.ConvertParameters();
//            _database.Execute();
//        }
//        private CustomerBO Map(DataTable mytable)
//        {
//            CustomerBO customer = null;
//            if (mytable.Rows.Count > 0)
//            {
//                customer = new CustomerBO();
//                customer.CustomerId = mytable.Rows[0][0].ToString();
//                customer.FirstName = mytable.Rows[0][1].ToString();
//                customer.LastName = mytable.Rows[0][2].ToString();
//                customer.Zone = mytable.Rows[0][3].ToString();
//                customer.Residence = mytable.Rows[0][4].ToString();
//                customer.Prepaid = bool.Parse(mytable.Rows[0][5].ToString());
//                customer.Rate = int.Parse(mytable.Rows[0][6].ToString());
//                customer.Status = mytable.Rows[0][7].ToString();
//                customer.Telephone = mytable.Rows[0][8].ToString();
//                customer.IdCardNumber = mytable.Rows[0][9].ToString();
//                customer.ConnectionDate = DateTime.Parse(mytable.Rows[0][10].ToString());
//            }
//            return customer;
//        }
//        private IEnumerable<CustomerBO> MapAll(DataTable mytable)
//        {
//            List<CustomerBO> customers = null;
//            if (mytable.Rows.Count > 0)
//            {
//                customers = new List<CustomerBO>();
//                for (int i = 0; i < mytable.Rows.Count; i++)
//                {

//                    var customer = new CustomerBO();
//                    customer.CustomerId = mytable.Rows[i][0].ToString();
//                    customer.FirstName = mytable.Rows[i][1].ToString();
//                    customer.LastName = mytable.Rows[i][2].ToString();
//                    customer.Zone = mytable.Rows[i][3].ToString();
//                    customer.Residence = mytable.Rows[i][4].ToString();
//                    customer.Prepaid = bool.Parse(mytable.Rows[i][5].ToString());
//                    customer.Rate = int.Parse(mytable.Rows[i][6].ToString());
//                    customer.Status = mytable.Rows[i][7].ToString();
//                    customer.Telephone = mytable.Rows[i][8].ToString();
//                    customer.IdCardNumber = mytable.Rows[i][9].ToString();
//                    customer.ConnectionDate = DateTime.Parse(mytable.Rows[i][10].ToString());
//                    customers.Add(customer);

//                }
//            }
//            return customers;
//        }
//    }
//}

//#endregion
