namespace Api.Helpers
{
    public static class HttpRequestExtension
    {
        public static string GetHeader(this HttpRequest request, string key)
        {
            return request.Headers.FirstOrDefault(x => x.Key == key).Value.FirstOrDefault();
        }

        public static string GetLanguage(this HttpRequest request)
        {
            return request.Headers.FirstOrDefault(x => x.Key == "language").Value.FirstOrDefault() ?? "ar";
        }
    }
}
