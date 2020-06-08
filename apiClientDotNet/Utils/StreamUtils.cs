namespace apiClientDotNet.Utils
{
    public class StreamUtils
    {
        public static string FixId(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return id;
            }

            return id.Replace('/', '_').Replace('+', '-').Replace("=", "");
        }
    }
}
