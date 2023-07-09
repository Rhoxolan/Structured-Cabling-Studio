using StructuredCablingStudioCore;

namespace StructuredCablingStudio.Services.SaveToTXTService
{
	public interface ISaveToTXTService
	{
		byte[] SaveToTXT(CablingConfiguration cablingConfiguration);

		string GetFileName(CablingConfiguration cablingConfiguration);
	}
}
