using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataA.Models;

namespace DataA.Data
{
    public class DataAContext : DbContext
    {
        public DataAContext (DbContextOptions<DataAContext> options)
            : base(options)
        {
        }

        public DbSet<DataA.Models.Items> Items { get; set; } = default!;
        public DbSet<DataA.Models.AddedItems> AddedItems { get; set; } = default!;
        public DbSet<DataA.Models.OurTables> OurTables { get; set; } = default!;
    }
}
