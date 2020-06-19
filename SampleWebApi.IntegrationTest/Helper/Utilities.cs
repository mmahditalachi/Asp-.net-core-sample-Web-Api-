using SampleWebApi.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleWebApi.IntegrationTest.Helper
{
    public static class Utilities
    {
        #region snippet1
        public static void InitializeDbForTests(AppDbContext db)
        {
            db.Employees.AddRange(GetSeedingMessages());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(AppDbContext db)
        {
            db.Employees.RemoveRange(db.Employees);
            InitializeDbForTests(db);
        }

        public static List<Employee> GetSeedingMessages()
        {
            return new List<Employee>()
            {
                 new Employee() { FirstName = "Arya", LastName = "Goldmen"
                 , Email = "Arya@test.com",EmployeeId = 1 },

                 new Employee() { FirstName = "Jonathan", LastName = "Neron"
                 , Email = "Jonathan@test.com",EmployeeId = 2 }
            };
        }
        #endregion
    }
}
