using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMROOM_emproj.Models;

[Table("EMROOM_Triage_Levels")]
public class EMROOM_Triage_Level
{
    [Key]
    public int EMROOM_Triage_Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string EMROOM_Level_Name { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(20)]
    public string EMROOM_Color_Code { get; set; } = string.Empty;
    
    [Required]
    public int EMROOM_Priority_Score { get; set; }
    
    [MaxLength(200)]
    public string EMROOM_Description { get; set; } = string.Empty;
    
    public virtual ICollection<EMROOM_Emergency_Case> EMROOM_Emergency_Cases { get; set; } = new List<EMROOM_Emergency_Case>();
}
