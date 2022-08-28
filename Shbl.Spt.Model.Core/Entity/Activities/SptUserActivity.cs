using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shbl.Spt.Model.Core.Entity.Auth;

namespace Shbl.Spt.Model.Core.Entity.Activities
{
    public class SptUserActivity
    {
        public SptUserActivity()
        {
            SptUserActivityDetails = new HashSet<SptUserActivityDetail>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int SptUserId { get; set; }

        [Required]
        public int ActivityId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        [ForeignKey("SptUserId")]
        public virtual SptUser SptUser { get; set; }

        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }

        public ICollection<SptUserActivityDetail> SptUserActivityDetails { get; set; }
    }
}
