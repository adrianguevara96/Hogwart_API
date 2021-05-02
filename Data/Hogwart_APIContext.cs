using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hogwart_API.Models;

namespace Hogwart_API.Data
{
    public class Hogwart_APIContext : DbContext
    {
        public Hogwart_APIContext (DbContextOptions<Hogwart_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Hogwart_API.Models.Request> Requests { get; set; }
    }
}
