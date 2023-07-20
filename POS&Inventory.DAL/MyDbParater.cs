using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS_Inventory.DAL
{
    public class MyDbParater
    {
        private string _Name;
        private object _ParaValue;
        public string Name {  get {return _Name;} }
        public object ParaValue {get{return _ParaValue;}}
        public MyDbParater(string name, object value)
        {
            _Name = name;
            _ParaValue = value;
        }
    }
}
