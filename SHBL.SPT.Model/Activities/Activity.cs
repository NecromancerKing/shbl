using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHBL.SPT.Model.Activities
{
    public class Activity
    {
        public Activity()
        {

        }

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
