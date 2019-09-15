using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHBL.SPT.Model.Word
{
    public class CFTypeSpeaker
    {
        public CFTypeSpeaker()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CFTypeId { get; set; }

        [Required]
        public int SpeakerId { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName1 { get; set; }

        [StringLength(50)]
        public string FileName2 { get; set; }

        [ForeignKey("CFTypeId")]
        public virtual CFType CFType { get; set; }

        [ForeignKey("SpeakerId")]
        public virtual Speaker Speaker { get; set; }
    }
}
