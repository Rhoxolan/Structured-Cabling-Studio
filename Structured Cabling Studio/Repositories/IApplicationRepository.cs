using StructuredCablingStudioCore;

namespace StructuredCablingStudio.Repositories
{
	public interface IApplicationRepository<T> where T : CablingConfiguration
	{
		ICollection<T> GetAll();

		void Add(T сablingConfiguration);

		T? Get(uint id);

		bool Remove(uint id);
	}
}
