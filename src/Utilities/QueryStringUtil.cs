namespace NasaConsumer.Utilities
{
    public static class QueryStringUtil
    {
        public static string ToQueryString(Dictionary<string, string> dicParams)
        {
            return string.Join('&',
                dicParams
                .Where(x => x.Value != null)
                .Select(x => $"{x.Key}={x.Value}"));
        }
    }
}