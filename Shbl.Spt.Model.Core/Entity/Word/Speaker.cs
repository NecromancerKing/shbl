using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shbl.Spt.Model.Core.Entity.Word
{
    public class Speaker
    {
        public Speaker()
        {
            CfTypeSpeakers = new HashSet<CfTypeSpeaker>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string SpeakerName { get; set; }

        [Required]
        public bool TestOnly { get; set; }

        public ICollection<CfTypeSpeaker> CfTypeSpeakers { get; set; }

    }
}
