namespace AzureBugRepro
{
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System;

    public static class LoggerExtensions
    {
        public static JsonSerializerSettings JsonSerializerSettings { get; } = new JsonSerializerSettings { ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver() };

        public static void LogAzureDiagnostics(this ILogger logger, EventId eventId, string message)
        {
            LogAzureDiagnostics<object>(logger, eventId, message, null);
        }

        public static void LogAzureDiagnostics<T>(this ILogger logger, EventId eventId, string message, T state)
        {
            LogAzureDiagnostics(logger, new DiagnosticInfo<T>
            {
                EventId = eventId.Id,
                EventName = eventId.Name,
                Message = message,
                State = state
            });
        }

        public static void LogAzureDiagnostics<T>(this ILogger logger, DiagnosticInfo<T> info)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            string message = JsonConvert.SerializeObject(info, JsonSerializerSettings);
            logger.LogWarning(message);
        }
    }
}
