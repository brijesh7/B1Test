using B1Test.Business.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B1Test.Business.Repository
{
    public class B1TestRepository : IDisposable
    {
        b1Context objContext = new b1Context ();
        public void Dispose()
        {
            objContext = null;
        }

        public IEnumerable<ItemMaster> GetAllItemMaster()
        {
            var result = objContext.Database.SqlQuery<ItemMaster>("GetAllItemMaster").ToList();
            return result;
        }

        public ItemMaster AddEditItemMaster(ItemMaster obj)
        {
            var itemIdPara = new SqlParameter { ParameterName = "@ItemID", Value = obj.ItemID };
            var amountPara = new SqlParameter { ParameterName = "@Amount", Value = obj.Amount };
            var result = objContext.Database.SqlQuery<ItemMaster>("AddEditItemMaster @ItemID,@Amount", itemIdPara, amountPara).FirstOrDefault();
            return result;

        }

        public int DeleteItemMaster(ItemMaster obj)
        {
            var itemIdPara = new SqlParameter { ParameterName = "@ItemID", Value = obj.ItemID };
            var result = objContext.Database.ExecuteSqlCommand("DeleteItemMaster @ItemID", itemIdPara);
            return result;
        }

        public ItemSchema AddEditItemSchema(ItemSchema obj)
        {
            var aliasPara = new SqlParameter { ParameterName = "@Alias", Value = obj.Alias };
            var schemaidPara = new SqlParameter { ParameterName = "@SchemaID", Value = obj.SchemaID };
            var formulaPara = new SqlParameter { ParameterName = "@Formula", Value = obj.Formula };
            var priorityPara = new SqlParameter { ParameterName = "@Priority", Value = obj.Priority };

            var result = objContext.Database.SqlQuery<ItemSchema>("AddEditItemSchema @Alias,@SchemaID,@Formula,@Priority", 
                aliasPara, schemaidPara,formulaPara,priorityPara).FirstOrDefault();
            return result;

        }

        public IEnumerable<ItemSchema> GetAllItemSchema()
        {
            var result = objContext.Database.SqlQuery<ItemSchema>("GetAllItemSchema").ToList();
            return result;

        }
        public int DeleteItemSchema(ItemSchema obj)
        {
            var schemaIDPara = new SqlParameter { ParameterName = "@SchemaID", Value = obj.SchemaID };
            var result = objContext.Database.ExecuteSqlCommand("DeleteItemSchema @SchemaID", schemaIDPara);
            return result;
        }
        public ItemSchema GetSchemaByID(ItemSchema obj)
        {
            var schemaIDPara = new SqlParameter { ParameterName = "@SchemaID", Value = obj.SchemaID };
            var result = objContext.Database.SqlQuery<ItemSchema>("GetSchemaByID @SchemaID", schemaIDPara).FirstOrDefault();
            return result;
        }

        public IEnumerable<ItemData> GetAllSchemaCalc()
        {
            return objContext.Database.SqlQuery<ItemData>("GetAllSchemaCalc").ToList();
        }

    }
}
