using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace RetrieveDataFromSqlDapper
{
    public static class DataService
    {
        public static List<Category> GetAllCategory()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State==ConnectionState.Closed)
                {
                    db.Open();
                }
                return db.Query<Category>("SELECT CategoryID, CategoryName FROM Categories").ToList();
            }
        }

        public static List<Product> GetProductByCategoryID(int categoryid)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                return db.Query<Product>("GetProductByCategoryID", new { CategoryID = categoryid }, commandType:CommandType.StoredProcedure).ToList();
            }
        }
    }
}
