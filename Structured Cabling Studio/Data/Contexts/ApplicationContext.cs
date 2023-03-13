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
		
		public DbSet<CableSelectionRecommendationEntity> CableSelectionRecommendations { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CablingConfigurationEntity>().Ignore(e => e.Recommendations);
		}
	}
}
