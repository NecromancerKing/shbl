using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shbl.Spt.Model.Core.Entity.Activities
{
    public class Activity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public byte ActivityOrder { get; set; }

        [Required]
        [StringLength(50)]
        public string ActivityName { get; set; }

        [Required]
        public byte ActivitySession { get; set; }

        [Required]
        public bool IsTest { get; set; }

        [Required]
        public string ActivityTitle { get; set; }

        [Required]
        public string ActivityDesc { get; set; }
    }
}
