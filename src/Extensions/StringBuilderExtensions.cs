using System.Text;

namespace Extensions
{
    public static class StringBuilderExtensions
    {
        public static string ToStringOrNull(this StringBuilder stringBuilder)
        {
            return stringBuilder?.ToString();
        }

        public static void AppendLineWithFormat(this StringBuilder stringBuilder, string str, params object[] args)
        {
            stringBuilder.AppendFormat(str, args);
            stringBuilder.AppendLine();
        }
    }
}
