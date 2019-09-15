using SHBL.SPT.Model.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHBL.SPT.Model.Activities
{
    public class SptUserActivity
    {
        public SptUserActivity()
        {
            this.SptUserActivityDetails = new HashSet<SptUserActivityDetail>();
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

        public Nullable<DateTime> FinishDate { get; set; }

        [ForeignKey("SptUserId")]
        public virtual SptUser SptUser { get; set; }

        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; }

        public virtual ICollection<SptUserActivityDetail> SptUserActivityDetails { get; set; }
    }
}
