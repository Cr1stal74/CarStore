using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarStore.Database.Entities;

[Table("images")]
public class Image
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("content")]
    public byte[] Content { get; set; }
}
