using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalSi
{
    class Tablas
    {

        public class Manufacturer
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Municipality { get; set; }

            public ICollection<Products> Product { get; set; }
            //El objecte es la forana, quan es la pare es declara el ICollection
        }

        public class Products
        { 
            public int ID { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
            public int ManufacturerID { get; set; }

            public Manufacturer Manufacturer { get; set; }
            public ICollection<Buy> Buy { get; set; }
        }
        public class Customer
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Gender { get; set; }
            public DateTime Birth_Date { get; set; }
            public string NIF { get; set; }
            public string Email { get; set; }
            public string Phone_number { get; set; }
            public string Credit_Card { get; set; }

            public ICollection<Buy> Buy { get; set; }
        }

        public class Buy
        {
            public int ID { get; set; }
            public int ProductID { get; set; }
            public int CustomerID { get; set; }
            public DateTime Buy_Date { get; set; }
            public int Units { get; set; }

            public Products Products { get; set; }
            public Customer Customer { get; set; }
        }

        public class DBEnterprise : DbContext
        {
            public DbSet<Manufacturer> Manufacturer { get; set; }
            public DbSet<Products> Product { get; set; }
            public DbSet<Customer> Customer { get; set; }
            public DbSet<Buy> Buy { get; set; }
        }

    }
}
