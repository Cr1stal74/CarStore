using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarStore.Database.Entities;

[Table("cars")]
public class Car
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("model")]
    public string Model { get; set; }

    [Column("horse_powers")]
    public int HorsePowers { get; set; }

    [Column("engine_volume")]
    public double EngineVolume { get; set; }

    [Column("colors")]
    public string Colors { get; set; }

    [Column("release_year")]
    public int ReleaseYear { get; set; }

    [Column("doors_count")]
    public int DoorsCount { get; set; }

    [Column("image_ids")]
    public long[] ImageIds { get; set; }

    [ForeignKey("ImageIds")]
    public virtual Image[] Images { get; set; }

    [Column("start_price")]
    public int StartPrice { get; set; }

    [Column("company_id")]
    public long CompanyId { get; set; }

    [ForeignKey("CompanyId")]
    public virtual Company Company { get; set; }
}
