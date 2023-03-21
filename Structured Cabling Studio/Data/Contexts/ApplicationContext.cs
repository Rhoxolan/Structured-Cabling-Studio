using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StructuredCablingStudio.Data.Entities;
using System.Text.Json;

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
				.HasConversion(
					v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
					v => JsonSerializer.Deserialize<Dictionary<string, string>>(v, (JsonSerializerOptions)null!)!,
					new ValueComparer<Dictionary<string, string>>(
						(c1, c2) => c1!.SequenceEqual(c2!),
						c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
						c => c.ToDictionary(k => k.Key, v => v.Value)
						));
		}
	}
}
