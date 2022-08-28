using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shbl.Spt.Model.Core.Entity.Word;

namespace Shbl.Spt.Model.Core.Entity.Auth
{
    public class Person
    {
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
        public string FullName => FirstName + " " + LastName;

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        public AgeGroupEnum AgeGroup { get; set; }

        [Required]
        public ProficiencyLevelEnum ProficiencyLevel { get; set; }

        [Required]
        public int CfTypeId { get; set; }

        [ForeignKey("CfTypeId")]
        public virtual CfType CfType { get; set; }


        // Enums

        public enum AgeGroupEnum : byte
        {
            GrpUnder13 = 1,
            GrpAbove15 = 2
        }

        public enum ProficiencyLevelEnum : byte
        {
            Beginner = 1,
            Intermediate = 2,
            Advanced = 3
        }
    }
}
