using BookWebStore.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookWebStore.Domain.Entities
{

    [Table("Images")]
    public class Image : DbEntity
    {
        public Guid Id { get; set; }

        public string PublicId { get; set; }

        public string Url { get; set; }

        public Product Product { get; set; }
    }
}
