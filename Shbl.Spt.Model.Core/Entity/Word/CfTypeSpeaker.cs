using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shbl.Spt.Model.Core.Entity.Word
{
    public class CfTypeSpeaker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CfTypeId { get; set; }

        [Required]
        public int SpeakerId { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName1 { get; set; }

        [StringLength(50)]
        public string FileName2 { get; set; }

        [ForeignKey("CfTypeId")]
        public CfType CfType { get; set; }

        [ForeignKey("SpeakerId")]
        public Speaker Speaker { get; set; }
    }
}
