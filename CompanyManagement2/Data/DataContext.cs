using System;
using CompanyManagement2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace CompanyManagement2.Data;

public class DataContext : IdentityDbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}
	public DbSet<Company> Companies { get; set; }
}


