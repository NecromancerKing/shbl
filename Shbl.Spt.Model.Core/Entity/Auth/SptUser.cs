using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shbl.Spt.Model.Core.Entity.Activities;

namespace Shbl.Spt.Model.Core.Entity.Auth
{
    public class SptUser
    {
        public SptUser()
        {
            SptUserActivities = new HashSet<SptUserActivity>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [Required]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        public ICollection<SptUserActivity> SptUserActivities { get; set; }
    }
}
