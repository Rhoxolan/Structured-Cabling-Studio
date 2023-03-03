using StructuredCablingStudio.Data.Contexts;
using StructuredCablingStudio.Data.Entities;

namespace StructuredCablingStudio.Repositories
{
	public class DbApplicationRepository : IApplicationRepository<CablingConfigurationEntity>
	{
		private ApplicationContext _context;

		public DbApplicationRepository(ApplicationContext context)
		{
			_context = context;
		}

		public void Add(CablingConfigurationEntity cablingConfiguration)
		{
			_context.CablingConfigurations.Add(cablingConfiguration);
			_context.SaveChanges();
		}

		public CablingConfigurationEntity? Get(uint id)
		{
			return _context.CablingConfigurations.ToList().Find(c => c.Id == id);
		}

		public ICollection<CablingConfigurationEntity> GetAll()
		{
			return _context.CablingConfigurations.ToList();
		}

		public bool Remove(uint id)
		{
			CablingConfigurationEntity? cablingConfiguration = _context.CablingConfigurations.Find(id);
			if (cablingConfiguration is null)
			{
				return false;
			}
			_context.CablingConfigurations.Remove(cablingConfiguration);
			_context.SaveChanges();
			return true;
		}
	}
}
