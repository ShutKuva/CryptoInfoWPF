using System.Text;

namespace BLL
{
    public static class QueryHandler
    {
        public static string GetQueriesFromDictionary(IDictionary<string, string> queries)
        {
            if (queries.Count == 0)
            {
                return "";
            }

            StringBuilder result = new StringBuilder();

            foreach (KeyValuePair<string, string> pair in queries)
            {
                result.Append($"{pair.Key}={pair.Value}&");
            }

            result.Remove(result.Length - 1, 1);

            return result.ToString();
        }
    }
}
