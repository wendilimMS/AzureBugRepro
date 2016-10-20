namespace AzureBugRepro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public struct DiagnosticInfo<T>
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public string Message { get; set; }

        public T State { get; set; }
    }
}
