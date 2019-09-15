using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHBL.SPT.Model.General
{
    public class EventLog
    {
        public EventLog()
        {

        }

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
