using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelfHelp.PostgreSql.Tables
{
    [Table("user")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public required string UserName { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string Email { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        [Required]
        public required DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public bool IsActive { get; set; } = false;

    }
}
