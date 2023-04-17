using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B1Test.Business.Entity
{
    public class ItemMaster
    {
        public string ItemID { get; set; }
        public decimal Amount { get; set; }
    }

    public class ItemSchema
    {
        public string Alias { get; set; }
        public string SchemaID { get; set; }
        public string Formula { get; set; }
        public int? Priority { get; set; }
    }

    public class ItemData
    {
        public int AutoID { get; set; }
        public string Name { get; set; }
        public string Formula { get; set; }
    }

}
