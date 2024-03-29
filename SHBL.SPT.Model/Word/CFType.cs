﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHBL.SPT.Model.Word
{
    public class CFType
    {
        public CFType()
        {
            CFTypeSpeakers = new HashSet<CFTypeSpeaker>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string CFTypeName { get; set; }

        public virtual ICollection<CFTypeSpeaker> CFTypeSpeakers { get; set; }

    }
}
