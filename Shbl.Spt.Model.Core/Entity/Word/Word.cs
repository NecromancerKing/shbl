using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shbl.Spt.Model.Core.Entity.Word
{
    public class Word
    {
        public Word()
        {
            WordSpeakers = new HashSet<WordSpeaker>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string WordEntry { get; set; }

        public int? PairId { get; set; }

        [Required]
        public SoundGroupEnum SoundGroup { get; set; }

        [Required]
        public bool TestOnly { get; set; }

        [ForeignKey("PairId")]
        public Word Pair { get; set; }

        public ICollection<WordSpeaker> WordSpeakers { get; set; }


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
