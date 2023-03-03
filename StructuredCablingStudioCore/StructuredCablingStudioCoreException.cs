namespace StructuredCablingStudioCore
{
	// Exceptions in the StructuredCablingStudioCore application logic. As example - overflow of permissible permanent link length.
	//
	// Exceptions should not be handled in the app!

	/// <summary>
	/// Exceptions in the Structured Cabling Studio application logic
	/// </summary>
	public class StructuredCablingStudioCoreException : Exception
    {
        public StructuredCablingStudioCoreException()
        {
        }

        public StructuredCablingStudioCoreException(string message)
            : base(message)
        {
        }

        public StructuredCablingStudioCoreException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}