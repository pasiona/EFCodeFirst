using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FinalSi.Tablas;

namespace final
{
    class Program
    {
        static void Main(string[] args)
        {
            Program enterprise = new Program();
            enterprise.Controller();


        }

        private void Controller()
        {
            int menu;


            using (var db = new DBEnterprise())
            {

                menu = SelectOption();

                do
                {

                    switch (menu)
                    {
                        case 1:
                            db.Product.Add(Product());
                            db.SaveChanges();
                            break;
                        case 2:
                            db.Customer.Add(Client());
                            db.SaveChanges();
                            break;
                        case 3:

                            db.Manufacturer.Add(Manufacturer());
                            db.SaveChanges();
                            break;
                        case 4:
                            ShowProducts();
                            break;
                        case 5:
                            ShowCustomers();
                            break;
                        case 6:
                            ShowManufacturers();
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Key error, introduce 1/2/3/4/5/6/7");
                            break;
                    }
                    menu = SelectOption();
                } while (menu != 7);

            }

        }
        private int SelectOption()
        {
            int menu = 0;

            Console.WriteLine("Select: ");
            Console.WriteLine("1) Add product");
            Console.WriteLine("2) Add client");
            Console.WriteLine("3) Add manufacturer");
            Console.WriteLine("4) Show product");
            Console.WriteLine("5) Show customers");
            Console.WriteLine("6) Show manufacturers"
                );
            Console.WriteLine("7) Exit");

            try
            {
                menu = Convert.ToInt16(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Key error, introduce 1/2/3/4/5/6/7");
                System.Threading.Thread.Sleep(1200);
                Console.Clear();
                SelectOption();
            }
            Console.Clear();

            return menu;
        }
        private static Products Product()
        {
            String titleV = "a";
            int manufacturerV = 0;
            decimal priceV = 0;

            try
            {
                Console.WriteLine("Introduce the product title");
                titleV = EmptyOrNull();
                Console.WriteLine("Introduce the product manufacturer");
                manufacturerV = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Introduce the product price");
                priceV = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Incorrect value");
                System.Threading.Thread.Sleep(1200);
                Console.Clear();
                Product();
            }
            Console.Clear();
            Console.WriteLine("Added succesfully");
            System.Threading.Thread.Sleep(600);
            Console.Clear();

            return new Products
            {
                Title = titleV,
                ManufacturerID = manufacturerV,
                Price = (decimal)priceV
            };
        }
        private static Customer Client()
        {
            String nifV = "";
            String nameV = "";
            String surnameV = "";
            DateTime birth_dateV = Convert.ToDateTime("01/01/2000");
            String genderV = "";
            String emailV = "";
            String phoneV;
            String credit_cardV;
            Boolean date = false;

            Console.WriteLine("Introduce the client NIF");
            nifV = EmptyOrNull();
            Console.WriteLine("Introduce the client name");
            nameV = EmptyOrNull();
            Console.WriteLine("Introduce the client surname");
            surnameV = EmptyOrNull();
            Console.WriteLine("Introduce the client birth_date");
            try
            {
                birth_dateV = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Incorrect date");
                System.Threading.Thread.Sleep(1200);
                Console.Clear();
                Client();
            }
            Console.WriteLine("Introduce the client gender");
            genderV = EmptyOrNull();
            Console.WriteLine("Introduce the client email");
            emailV = EmptyOrNull();
            Console.WriteLine("Introduce the client phone");
            phoneV = EmptyOrNull();
            Console.WriteLine("Introduce the client credit_card");
            credit_cardV = EmptyOrNull();
            Console.Clear();
            Console.WriteLine("Added succesfully");
            System.Threading.Thread.Sleep(600);
            Console.Clear();

            return new Customer
            {
                NIF = nifV,
                Name = nameV,
                Surname = surnameV,
                Birth_Date = birth_dateV,
                Gender = genderV,
                Email = emailV,
                Phone_number = phoneV,
                Credit_Card = credit_cardV
            };
        }
        private static Manufacturer Manufacturer()
        {
            String nameV = " ";
            String municipalityV = " ";

            Console.WriteLine("Introduce the manufacturer name");
            nameV = EmptyOrNull();
            Console.WriteLine("Introduce the manufacturer municipality");
            municipalityV = EmptyOrNull();
            Console.WriteLine("Added succesfully");
            System.Threading.Thread.Sleep(600);
            Console.Clear();

            return new Manufacturer
            {
                Name = nameV,
                Municipality = municipalityV
            };
        }
        private static Buy Buy()
        {
            int productV = 0;
            int customerV = 0;
            DateTime buyDateV = Convert.ToDateTime(Console.ReadLine());
            int unitsV = 0;
            Console.WriteLine("Introduce the manufacturer name");
            productV = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduce the manufacturer municipality");
            customerV = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduce the manufacturer name");
            buyDateV = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Introduce the manufacturer municipality");
            unitsV = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Added succesfully");
            System.Threading.Thread.Sleep(600);
            Console.Clear();
            return new Buy
            {
                ProductID = productV,
                CustomerID = customerV,
                Buy_Date = buyDateV,
                Units = unitsV

            };
        }
            private void ShowProducts()
        {
            using (var db = new DBEnterprise())
            {
                var query = from product in db.Product
                            select product;

                foreach (Products product in query)

                {

                    Console.Write(product.ID + " " + product.Title + " " + product.ManufacturerID + " " + product.Price);

                    Console.WriteLine();

                }

                Console.Write("Press any key to return menu: ");
                Console.ReadKey();

                Console.Clear();

            }
        }
        private void ShowCustomers()
        {
            using (var db = new DBEnterprise())
            {
                var query = from customers in db.Customer
                            select customers;

                foreach (Customer customers in query)

                {

                    Console.Write(customers.ID + " " + customers.NIF + " " + customers.Name + " " + customers.Surname +
                        " " + customers.Birth_Date + " " + customers.Gender + " " + customers.Email + " " + customers.Phone_number
                        + " " + customers.Credit_Card);

                    Console.WriteLine();

                }

                Console.Write("Press any key to return menu: ");
                Console.ReadKey();

                Console.Clear();

            }
        }
        private void ShowManufacturers()
        {
            using (var db = new DBEnterprise())
            {
                var query = from manufacturers in db.Manufacturer
                            select manufacturers;

                foreach (Manufacturer manufacturers in query)

                {

                    Console.Write(manufacturers.ID + " " + manufacturers.Name + " " + manufacturers.Municipality);

                    Console.WriteLine();

                }

                Console.Write("Press any key to return menu: ");
                Console.ReadKey();

                Console.Clear();

            }
        }
        private static string EmptyOrNull()
        {
            Boolean EmptyNullCheck;
            string word;

            word = Console.ReadLine();
            do {
                if (String.IsNullOrEmpty(word))
                {
                    EmptyNullCheck = false;
                    Console.WriteLine("Empty value, not allowed, introduce some value: ");
                    word = Console.ReadLine();
                }
                else
                {
                    EmptyNullCheck = true;
                }
            } while (false);
            return word;
        }
    }
}
