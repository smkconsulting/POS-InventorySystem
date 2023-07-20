using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace POS_Inventory.DAL
{
    interface ICrud<T>
    {        

        //finding objects
        T Get(string id);
        IEnumerable<T> GetAll();

        //adding Objects
        void Add(T entity);

        //Deleting objects
        void Delete(T entity);

        //counting objects 
        int Count();

        //updating an object
        void Update(T entity);
                
    }
}
