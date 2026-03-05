using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMROOM_emproj.Models;

[Table("EMROOM_Symptoms")]
public class EMROOM_Symptom
{
    [Key]
    public int EMROOM_Symptom_Id { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string EMROOM_Symptom_Name { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string EMROOM_Category { get; set; } = string.Empty; // Cardiac, Respiratory, Neurological, etc.
    
    [Required]
    [Range(1, 10)]
    public int EMROOM_Base_Severity_Weight { get; set; } // Base severity for triage calculation
    
    [MaxLength(500)]
    public string EMROOM_Description { get; set; } = string.Empty;
    
    public virtual ICollection<EMROOM_Case_Symptom> EMROOM_Case_Symptoms { get; set; } = new List<EMROOM_Case_Symptom>();
}
