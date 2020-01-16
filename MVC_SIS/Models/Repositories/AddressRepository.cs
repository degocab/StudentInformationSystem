using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercises.Models.Repositories
{
    public class AddressRepository
    {
        private static List<Address> _address;

        static void AddressRespository()
        {
            // sample data
            _address = new List<Address>()
            {
                new Address {AddressId=1, Street1="123 Main St", City="Akron", PostalCode = "44311"},
                new Address {AddressId=1, Street1="123 Main St", City="Akron", PostalCode = "44311"},
                new Address {AddressId=1, Street1="123 Main St", City="Akron", PostalCode = "44311"},


            };
        }

        public static IEnumerable<Address> GetAll()
        {
            return _address;
        }

        public static Address Get(int AddressId)
        {
            return _address.FirstOrDefault(c => c.AddressId == AddressId);
        }

        public static void Add(Address address)
        {
            _address.Add(address);
        }

        public static void Edit(Address address)
        {
            var selectedAddress = _address.FirstOrDefault(c => c.AddressId == address.AddressId);

            selectedAddress.AddressId = address.AddressId;
        }

        public static void Delete(int AddressId)
        {
            _address.RemoveAll(c => c.AddressId == AddressId);
        }
    }
}