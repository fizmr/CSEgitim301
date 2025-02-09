using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEgitim301_entityLayer.Concrete
{
    public class Category
    {
        public int CategoryID{ get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public List<Product> Products { get; set; } 


    }

    /*
     field -variable-property
    int x; -> field
    int y {get; set;} -> property
    void test(){
    int z; -> variable
    }
    */
     
    
}
