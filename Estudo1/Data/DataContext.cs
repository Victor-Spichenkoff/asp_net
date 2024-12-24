using System.Data.Common;
using Estudo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Estudo1.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    
}