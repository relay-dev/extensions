using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace Extensions
{
    public static class ExceptionExtensions
    {
        public static string ToFormattedString(this ReflectionTypeLoadException e)
        {
            var stringBuilder = new StringBuilder();

            if (e.LoaderExceptions != null)
            {
                foreach (Exception loaderException in e.LoaderExceptions)
                {
                    if (loaderException != null)
                    {
                        stringBuilder.AppendLine(loaderException.Message);

                        if (loaderException is FileNotFoundException fileNotFoundException)
                        {
                            if (!string.IsNullOrEmpty(fileNotFoundException.FusionLog))
                            {
                                stringBuilder.AppendLine("Fusion Log:");
                                stringBuilder.AppendLine(fileNotFoundException.FusionLog);
                            }
                        }
                    }

                    stringBuilder.AppendLine();
                }
            }

            return stringBuilder.ToString();
        }

        public static string ToFormattedString(this WebException e)
        {
            using WebResponse response = e.Response;
            HttpWebResponse httpResponse = (HttpWebResponse)response;

            var errorCode = httpResponse.StatusCode.ToString();

            using Stream stream = response.GetResponseStream();
            using var reader = new StreamReader(stream!);

            string errorMessage = reader.ReadToEnd();

            return $"ErrorCode: {errorCode} ErrorMessage: {errorMessage}";
        }
    }
}
