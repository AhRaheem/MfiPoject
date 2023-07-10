

namespace Infrastructure.Extensions
{
	public static class CollectionExtensions
	{
		public static IEnumerable<TSource> WhereIf<TSource>(
		this IQueryable<TSource> source,
		bool condition,
		Func<TSource, bool> predicate)
		{
			if (condition)
				return source.Where(predicate).AsQueryable();
			else
				return source;
		}
	}
}
