﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHGolfStore.Domain.Entities;
using System.Data.Entity;

namespace SHGolfStore.Domain.Concrete
{
    public class EFdbContext : DbContext 
    {
        public DbSet<Item> Items { get; set; }
    }
}
