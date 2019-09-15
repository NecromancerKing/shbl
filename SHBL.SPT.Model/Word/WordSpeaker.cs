using SHBL.SPT.Model.Activities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHBL.SPT.Model.Word
{
    public class WordSpeaker
    {
        public WordSpeaker()
        {
            this.SptUserActivityDetail = new HashSet<SptUserActivityDetail>();
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
        public virtual Speaker Speaker { get; set; }


        public virtual ICollection<SptUserActivityDetail> SptUserActivityDetail { get; set; }
    }
}
