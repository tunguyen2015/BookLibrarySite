using System;

namespace BLS.Core
{
    public abstract class BaseEntity<TK> : IEquatable<BaseEntity<TK>>
        where TK : IEquatable<TK>
    {
        public TK Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Ip { get; set; }

        public bool Equals(BaseEntity<TK> other)
        {
            return other != null && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            var entity = obj as BaseEntity<TK>;
            return entity != null && Equals(entity);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
