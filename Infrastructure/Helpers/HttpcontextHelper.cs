using Microsoft.AspNetCore.Http;


namespace Infrastructure.Helpers
{
	public static class HttpcontextHelper
	{
		private static IHttpContextAccessor _context;
		public static void HttpcontextHelperConfigure(IHttpContextAccessor context)
		{
			_context = context;
		}
		public static IHttpContextAccessor GetHttpcontext() => _context;
	}
}
