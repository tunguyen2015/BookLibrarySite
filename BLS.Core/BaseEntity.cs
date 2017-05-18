using System;

namespace BLS.Core
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ip { get; set; }
    }
}
