using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace B1Test.Business
{
    public partial class b1Context : DbContext
    {
        public b1Context()
        {
            this.Configuration.AutoDetectChangesEnabled = false;
        }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}

        //public virtual DbSet<ItemMaster> ItemMasters { get; set; }
        //public virtual DbSet<ItemSchema> ItemSchemas { get; set; }

    }
}
