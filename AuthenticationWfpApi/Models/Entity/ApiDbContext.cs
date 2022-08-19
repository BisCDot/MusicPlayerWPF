using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAuthenWpf.Models.Entity
{
    public class ApiDbContext : IdentityDbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}