using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CustomerData
    {
        public List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();
            string connectionString = "Data Source=LAB1504-16\\SQLEXPRESS;Initial Catalog=master;User Id = user01;Password=12345678";
            string storedProcedureName = "SelectAllCustomers";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.CustomerID = Convert.ToInt32(reader["customer_id"]);
                        customer.CustomerName = Convert.ToString(reader["name"]);
                        customer.CustomerAddress = Convert.ToString(reader["adress"]);
                        customer.CustomerPhone = Convert.ToString(reader["phone"]);

                        customers.Add(customer);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return customers;
        }

        public void Insert()
        {

        }
        public void Update()
        {

        }
        public void Delete()
        {
        }
    }
}
