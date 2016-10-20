namespace AzureBugRepro
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MyObject
    {
        public string Name { get; set; }

        public ICollection<Guid> ValueCollection { get; set; }

        public ICollection<MyObjectDetail> ObjectCollection { get; set; }

        public DateTime? LastModified { get; set; }

        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
        public string PropertyC { get; set; }

        public Option? Option { get; set; }
    }
}
