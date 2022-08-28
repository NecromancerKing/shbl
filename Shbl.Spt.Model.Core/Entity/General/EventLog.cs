using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shbl.Spt.Model.Core.Entity.General
{
    public class EventLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string EventType { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public string MessageOne { get; set; }

        public string MessageTwo { get; set; }

        public string MessageThree { get; set; }

        public string StackTrace { get; set; }
    }
}
