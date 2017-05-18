using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using BLS.Core.Data;

namespace BLS.Data.Mapping
{
    public class BookLibraryMap : EntityTypeConfiguration<Book>
    {
        public BookLibraryMap()
        {
            // Key
            HasKey(b => b.Id);

            // Properties
            Property(b => b.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(b => b.Title).HasMaxLength(200).HasColumnName("Title").IsRequired();
            Property(b => b.Author).HasMaxLength(500).HasColumnName("Author").IsRequired();
            Property(b => b.Edition).HasColumnName("Book Edition");
            Property(b => b.Isbn).HasColumnName("ISBN");
            Property(b => b.Publisher).HasColumnName("Publisher");
            Property(b => b.PublishedDate).HasColumnName("Publish Date");

            //To Table
            ToTable("Books");
        }
    }
}
