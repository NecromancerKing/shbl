using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shbl.Spt.Model.Core.Entity.Word;

namespace Shbl.Spt.Model.Core.Entity.Activities
{
    public class SptUserActivityDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserActivityId { get; set; }

        [Required]
        public int WordSpeakerId { get; set; }

        public bool? Result { get; set; }

        [ForeignKey("UserActivityId")]
        public virtual SptUserActivity SptUserActivity { get; set; }

        [ForeignKey("WordSpeakerId")]
        public virtual WordSpeaker WordSpeaker { get; set; }
    }
}
