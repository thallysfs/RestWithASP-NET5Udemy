﻿using Microsoft.EntityFrameworkCore;

namespace RestWithASP.NET5Udemy.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<Person> Persons { get; set; }
    }
}
