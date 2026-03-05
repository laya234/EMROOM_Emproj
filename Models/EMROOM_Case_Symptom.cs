using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMROOM_emproj.Models;

[Table("EMROOM_Case_Symptoms")]
public class EMROOM_Case_Symptom
{
    [Key]
    public int EMROOM_Case_Symptom_Id { get; set; }
    
    [Required]
    [ForeignKey("EMROOM_Emergency_Case")]
    public int EMROOM_Case_Id { get; set; }
    
    [Required]
    [ForeignKey("EMROOM_Symptom")]
    public int EMROOM_Symptom_Id { get; set; }
    
    [Required]
    [Range(1, 10)]
    public int EMROOM_Severity_Level { get; set; } // 1-10 scale
    
    [MaxLength(200)]
    public string EMROOM_Notes { get; set; } = string.Empty;
    
    public DateTime EMROOM_Recorded_At { get; set; } = DateTime.UtcNow;
    
    public virtual EMROOM_Emergency_Case EMROOM_Emergency_Case { get; set; } = null!;
    public virtual EMROOM_Symptom EMROOM_Symptom { get; set; } = null!;
}