using System.Data.Entity.ModelConfiguration;
using BLS.Core.Data;

namespace BLS.Data.Mapping
{
    public class UserProfileMap : EntityTypeConfiguration<UserProfile>
    {
        public UserProfileMap()
        {
            //Key
            HasKey(b => b.Id);

            //Properties
            Property(b => b.FirstName).HasColumnName("First Name").HasMaxLength(200).IsRequired();
            Property(b => b.LastName).HasColumnName("Last Name").HasMaxLength(200).IsRequired();
            Property(b => b.Preference).HasColumnName("Book Preference").HasMaxLength(500).IsRequired();
            Property(b => b.Address).HasColumnName("User Address").HasMaxLength(200).IsRequired();
            Property(b => b.AddedDate).IsRequired();
            Property(b => b.ModifiedDate).IsRequired();
            Property(b => b.Ip).IsRequired();

            //To Table
            ToTable("UserProfile");

            //Set up Relationship
            HasRequired(b => b.Users).WithRequiredDependent(b => b.Profile);
        }
    }
}
