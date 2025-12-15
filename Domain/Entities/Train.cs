using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelfLearning.Domain.Entities;

[Table("train_master")]
public class Train
{
    [Key]
    [Column("train_id")]
    public int TrainId { get; set; }

    [Required]
    [MaxLength(10)]
    [Column("train_no")]
    public string TrainNo { get; set; } = null!;

    [MaxLength(100)]
    [Column("train_name")]
    public string? TrainName { get; set; }

    [Column("last_updated")]
    public DateTime LastUpdated { get; set; }
}
