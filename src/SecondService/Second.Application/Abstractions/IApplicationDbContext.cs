using Microsoft.EntityFrameworkCore;
using Second.Domain.Tables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        public DbSet<Video> Videos { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
