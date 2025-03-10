﻿using BreweryMaster.API.OrderModule.Models;
using BreweryMaster.Tests.Models;

namespace BreweryMaster.Tests.Helpers
{
    public static class OrderDataProvider
    {
        public static List<Order> GetOrders()
        {
            return new List<Order>()
            {
                new Order()
                {
                    Id = 1,
                    ContainerId = 1,
                    TargetDate = DateTime.Today.AddDays(2),
                    Capacity = 1000,
                    CreatedOn = DateTime.Now,
                    Container = null!,
                    CreatedByUserId = TestConst.User1,
                    CreatedByUser = null!,
                    Recipe = null!,
                    RecipeId = 1,
                    Price = 1000,
                },
                new Order()
                {
                    Id = 2,
                    ContainerId = 1,
                    TargetDate = DateTime.Today.AddDays(3),
                    Capacity = 1200,
                    CreatedOn = DateTime.Now,
                    Container = null!,
                    CreatedByUserId = TestConst.User2,
                    CreatedByUser = null!,
                    Recipe = null!,
                    RecipeId = 1,
                    Price = 1300,
                }
            };
        }

        public static List<OrderStatusChange> GetOrderStatusChanges()
        {
            return new List<OrderStatusChange> {
            
                new OrderStatusChange()
                {
                    Id = 1,
                    OrderId = 1,
                    Order = null!,
                    OrderStatusId = 1,
                    OrderStatus = null!,
                },
                new OrderStatusChange()
                {
                    Id = 2,
                    OrderId = 2,
                    Order = null!,
                    OrderStatusId = 1,
                    OrderStatus = null!,
                },
                new OrderStatusChange()
                {
                    Id = 3,
                    OrderId = 1,
                    Order = null!,
                    OrderStatusId = 2,
                    OrderStatus = null!,
                },
            };
        }
    }
}