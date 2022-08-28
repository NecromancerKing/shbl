using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shbl.Spt.Model.Core.Entity.Activities;

namespace Shbl.Spt.Model.Core.Entity.Word
{
    public class WordSpeaker
    {
        public WordSpeaker()
        {
            SptUserActivityDetail = new HashSet<SptUserActivityDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int WordId { get; set; }

        [Required]
        public int SpeakerId { get; set; }

        [Required]
        [StringLength(50)]
        public string FileName { get; set; }

        [ForeignKey("WordId")]
        public virtual Word Word { get; set; }

        [ForeignKey("SpeakerId")]
        public Speaker Speaker { get; set; }


        public ICollection<SptUserActivityDetail> SptUserActivityDetail { get; set; }
    }
}
