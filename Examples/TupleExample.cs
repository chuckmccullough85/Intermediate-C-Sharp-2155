using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class TupleExample
    {
        public static (string name, DateTime start, DateTime end) GetInfo(int id)
        {
            var anon = new { Name = "Terry", Start = DateTime.Parse("1-1-1970") };


            return ("Terry Bradshaw", DateTime.Parse("1-1-1970"), DateTime.Parse("12-31-1983"));
        }
    }
}
