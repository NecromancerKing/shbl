using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHBL.SPT.Model.Word
{
    public class Word
    {
        public Word()
        {
            this.WordSpeakers = new HashSet<WordSpeaker>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string WordEntry { get; set; }

        public Nullable<int> PairId { get; set; }

        [Required]
        public SoundGroupEnum SoundGroup { get; set; }

        [Required]
        public bool TestOnly { get; set; }

        [ForeignKey("PairId")]
        public virtual Word Pair { get; set; }

        public virtual ICollection<WordSpeaker> WordSpeakers { get; set; }


        // Enums

        public enum SoundGroupEnum : byte
        {
            Set1 = 1,
            Set2 = 2,
            Set3 = 3,
            Set4 = 4
        }

    }
}
