﻿using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<User> userService = new GenericDataService<User>(new SimpleTraderDbContextFactory());
            Console.WriteLine(userService.GetAll().Result.Count());
            Console.WriteLine(userService.Get(1).Result);
            Console.WriteLine(userService.Update(2, new User { Username = "Marshall" }).Result);
            Console.ReadLine();
            //userService.Create(new User { Username = "Test" }).Wait();
        }
    }
}
