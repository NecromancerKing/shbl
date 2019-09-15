using SHBL.SPT.Model.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHBL.SPT.Model.Activities
{
    public class SptUserActivityDetail
    {
        public SptUserActivityDetail()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserActivityId { get; set; }

        [Required]
        public int WordSpeakerId { get; set; }

        public Nullable<bool> Result { get; set; }

        [ForeignKey("UserActivityId")]
        public virtual SptUserActivity SptUserActivity { get; set; }

        [ForeignKey("WordSpeakerId")]
        public virtual WordSpeaker WordSpeaker { get; set; }
    }
}
