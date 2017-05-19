using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BLS.Core.Data;

namespace BLS.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            //Key
            HasKey(b => b.Id);

            //Properties
            Property(b => b.Username).HasMaxLength(250).HasColumnName("Username").IsRequired();
            Property(b => b.Email).HasColumnName("User Email").IsRequired();
            Property(b => b.Password).HasColumnName("Password").IsRequired();
            Property(b => b.AddedDate).IsRequired();
            Property(b => b.ModifiedDate).IsRequired();
            Property(b => b.Ip).IsRequired();

            //To Table
            ToTable("User");
        }
    }
}
