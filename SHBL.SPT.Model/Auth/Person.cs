using SHBL.SPT.Model.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHBL.SPT.Model.Auth
{
    public class Person
    {
        public Person()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        public AgeGroupEnum AgeGroup { get; set; }

        [Required]
        public ProficiencyLevelEnum ProficiencyLevel { get; set; }

        [Required]
        public int CFTypeId { get; set; }

        [ForeignKey("CFTypeId")]
        public virtual CFType CFType { get; set; }


        // Enums

        public enum AgeGroupEnum : Byte
        {
            GrpUnder13 = 1,
            GrpAbove15 = 2
        }

        public enum ProficiencyLevelEnum : Byte
        {
            Beginner = 1,
            Intermediate = 2,
            Advanced = 3
        }
    }
}
