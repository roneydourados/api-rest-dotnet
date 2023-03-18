using System.ComponentModel.DataAnnotations.Schema;

namespace YenorApiModels
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
