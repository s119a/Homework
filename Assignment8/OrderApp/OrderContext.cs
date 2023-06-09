using MySql.Data.EntityFramework;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class OrderContext : DbContext
    {
        public OrderContext() : base("OrderDataBase")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderContext>());
        }

        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Clients> Clients { get; set; }
    }
}
