using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMROOM_emproj.Models;

[Table("EMROOM_Emergency_Cases")]
public class EMROOM_Emergency_Case
{
    [Key]
    public int EMROOM_Case_Id { get; set; }
    
    [Required]
    [ForeignKey("EMROOM_Patient")]
    public int EMROOM_Patient_Id { get; set; }
    
    [Required]
    [ForeignKey("EMROOM_Triage_Level")]
    public int EMROOM_Triage_Id { get; set; }
    
    [Required]
    [ForeignKey("EMROOM_Nurse")]
    public int EMROOM_Triaged_By_Nurse_Id { get; set; }
    
    [MaxLength(500)]
    public string EMROOM_Additional_Notes { get; set; } = string.Empty;
    
    [Required]
    public DateTime EMROOM_Arrival_Time { get; set; } = DateTime.UtcNow;
    
    [Required]
    public DateTime EMROOM_Triage_Time { get; set; } = DateTime.UtcNow;
    
    [Required]
    [MaxLength(50)]
    public string EMROOM_Status { get; set; } = "Waiting";
    
    [Range(1, 10)]
    public int EMROOM_Calculated_Priority { get; set; } = 1;
    
    public virtual EMROOM_Patient EMROOM_Patient { get; set; } = null!;
    public virtual EMROOM_Triage_Level EMROOM_Triage_Level { get; set; } = null!;
    public virtual EMROOM_User EMROOM_Nurse { get; set; } = null!;
    public virtual EMROOM_Treatment? EMROOM_Treatment { get; set; }
    public virtual ICollection<EMROOM_Case_Symptom> EMROOM_Case_Symptoms { get; set; } = new List<EMROOM_Case_Symptom>();
}
