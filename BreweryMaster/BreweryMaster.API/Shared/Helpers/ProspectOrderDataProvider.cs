﻿using BreweryMaster.API.OrderModule.Models;

namespace BreweryMaster.API.Shared.Helpers
{
    public static class ProspectOrderDataProvider
    {
        public static IEnumerable<ProspectIndyvidualClient> GetProspectIndyvidualClients()
        {
            return new List<ProspectIndyvidualClient>()
            {
                new()
                {
                    Id = 1,
                    Forename = "John",
                    Surname = "Doe",
                    Email = "client1@example.com",
                    Orders = null!,
                    PhoneNumber = "+48123456789"
                },
                new()
                {
                    Id = 2,
                    Forename = "Jane",
                    Surname = "Smith",
                    Email = "client2@example.com",
                    Orders = null!,
                    PhoneNumber = "+48987654321"
                },
                new()
                {
                    Id = 3,
                    Forename = "Alice",
                    Surname = "Brown",
                    Email = "client3@example.com",
                    Orders = null!,
                    PhoneNumber = "+48765432100"
                }
            };
        }

        public static IEnumerable<ProspectCompanyClient> GetProspectCompanyClients()
        {
            return new List<ProspectCompanyClient>()
            {
                new()
                {
                    Id = 4,
                    CompanyName = "John's Company",
                    Nip = 772777217,
                    Email = "client1@example.com",
                    Orders = null!,
                    PhoneNumber = "+48123456789"
                },
                new()
                {
                    Id = 5,
                    CompanyName = "Jane's Enterprises",
                    Nip = 882888218,
                    Email = "client2@example.com",
                    Orders = null!,
                    PhoneNumber = "+48987654321"
                },
                new()
                {
                    Id = 6,
                    CompanyName = "Alice's Solutions",
                    Nip = 993999319,
                    Email = "client3@example.com",
                    Orders = null!,
                    PhoneNumber = "+48765432100"
                }
            };

        }

        public static IEnumerable<ProspectOrder> GetProspectOrders()
        {
            return new List<ProspectOrder>()
            {
                new()
                {
                    Id=1,
                    BeerTypeId = 1,
                    ProspectClient = null!,
                    ProspectClientId = 1,
                    TargetDate = DateTime.Today,
                },
                new()
                {
                    Id=2,
                    BeerTypeId = 2,
                    ProspectClient = null!,
                    ProspectClientId = 3,
                    TargetDate = DateTime.Today,
                },
                new()
                {
                    Id=3,
                    BeerTypeId = 2,
                    ProspectClient = null!,
                    ProspectClientId = 2,
                    TargetDate = DateTime.Today,
                }
            };
        }
    }
}