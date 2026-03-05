using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMROOM_emproj.Models;

[Table("EMROOM_Users")]
public class EMROOM_User
{
    [Key]
    public int EMROOM_User_Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string EMROOM_Name { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string EMROOM_Email { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(255)]
    public string EMROOM_Password { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(50)]
    public string EMROOM_Role { get; set; } = string.Empty;
    
    public virtual ICollection<EMROOM_Treatment> EMROOM_Treatments { get; set; } = new List<EMROOM_Treatment>();
}
