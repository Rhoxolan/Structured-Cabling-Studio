using Microsoft.EntityFrameworkCore;
using StructuredCablingStudio.Data.Entities;

namespace StructuredCablingStudio.Data.Contexts
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<CablingConfigurationEntity> CablingConfigurations { get; set; }
	}
}
