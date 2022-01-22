using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovePara.Model
{
    public class ParaLeft
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column(TypeName = "int", Order = 1)]
        public int Id { get; set; }

        [Key]
        [Column(TypeName = "nvarchar(10)", Order =2)]
        public string ParaId { get; set; }

        [ForeignKey("ParaId")]
        public Para Para { get; set; }
    }
}
