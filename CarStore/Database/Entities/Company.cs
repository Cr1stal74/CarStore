using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarStore.Database.Entities;

[Table("companies")]
public class Company
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("description")]
    public string Description { get; set; }

    [Column("logo_picture_id")]
    public long LogoPictureId { get; set; }

    [ForeignKey("LogoPictureId")]
    public Image LogoPicture { get; set; }

    public virtual List<Car> Cars { get; set; }
}
