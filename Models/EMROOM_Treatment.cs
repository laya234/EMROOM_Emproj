using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMROOM_emproj.Models;

[Table("EMROOM_Treatments")]
public class EMROOM_Treatment
{
    [Key]
    public int EMROOM_Treatment_Id { get; set; }
    
    [Required]
    [ForeignKey("EMROOM_Emergency_Case")]
    public int EMROOM_Case_Id { get; set; }
    
    [Required]
    [ForeignKey("EMROOM_User")]
    public int EMROOM_Physician_Id { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string EMROOM_Diagnosis { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string EMROOM_Treatment_Notes { get; set; } = string.Empty;
    
    [Required]
    public DateTime EMROOM_Treated_At { get; set; } = DateTime.UtcNow;
    
    public virtual EMROOM_Emergency_Case EMROOM_Emergency_Case { get; set; } = null!;
    public virtual EMROOM_User EMROOM_User { get; set; } = null!;
}
