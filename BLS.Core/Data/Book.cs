using System;

namespace BLS.Core.Data
{
    public class Book : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public string Edition { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
