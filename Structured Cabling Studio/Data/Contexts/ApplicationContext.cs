using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CablingConfigurationEntity>()
				.Property(c => c.Recommendations)
				.HasConversion(d => JsonConvert.SerializeObject(d), s => JsonConvert.DeserializeObject<Dictionary<string, string>>(s)!);
		}
	}
}
