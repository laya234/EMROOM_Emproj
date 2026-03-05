using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMROOM_emproj.Models;

[Table("EMROOM_Patients")]
public class EMROOM_Patient
{
    [Key]
    public int EMROOM_Patient_Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string EMROOM_Name { get; set; } = string.Empty;
    
    [Required]
    public int EMROOM_Age { get; set; }
    
    [Required]
    [MaxLength(10)]
    public string EMROOM_Gender { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(20)]
    public string EMROOM_Phone { get; set; } = string.Empty;
    
    [Required]
    public DateTime EMROOM_Created_At { get; set; } = DateTime.UtcNow;
    
    public virtual ICollection<EMROOM_Emergency_Case> EMROOM_Emergency_Cases { get; set; } = new List<EMROOM_Emergency_Case>();
}
