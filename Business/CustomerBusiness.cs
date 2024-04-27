using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CustomerBusiness
    {
        public List<Customer> AllCustomers() {
            List<Customer> customers = new List<Customer>();
            CustomerData customerData = new CustomerData();
            customers = customerData.GetCustomer();
            return customers;
        }

        public List<Customer> SearchByFirstLetter(string letra)
        {
            List<Customer> customers = new List<Customer>();
            CustomerData customerData = new CustomerData();
            customers = customerData.GetCustomer();
            var result = customers.Where(x => x.CustomerName.StartsWith(letra)).ToList();
            return result;
        }
    }
}
