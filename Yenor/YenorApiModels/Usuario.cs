using System.ComponentModel.DataAnnotations.Schema;

namespace YenorApiModels
{
    [Table("users")]
    public class Usuario
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")] 
        public string? Name { get; set; }
        
        [Column("email")]
        public string? Email { get; set; }

        [Column("password")]
        public string? Password { get; set; }

        [Column("remember_me_token")]
        public string? RememberMeToken { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [Column("client_id")]
        public long ClientId { get; set; }

        [Column("master_user")]
        public bool MasterUser { get; set; }
    }
}
