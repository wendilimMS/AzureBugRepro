namespace AzureBugRepro
{
    using Microsoft.Extensions.Logging;

    public static class EventIds
    {
        public static readonly EventId MyObjectCreated = new EventId(1001, nameof(MyObjectCreated));
    }
}
