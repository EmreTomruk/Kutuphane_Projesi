using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApp.Interfaces
{
    public interface IDbContext : IDisposable
    {
        DbContext Instance { get; }
    }
}
