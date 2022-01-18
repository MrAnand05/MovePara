using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovePara.Model
{
    public class Para
    {
       [Key]
        [Column(TypeName ="nvarchar(10)")]
        public string ParaId { get; set; }
        public string ParaText { get; set; }
    }
    public class ParaLeft
    {
        [ForeignKey("Para")]

        [Column(TypeName = "nvarchar(10)")]
        public string ParaId { get; set; }

        public Para Para { get; set; }
    }
    public class ParaRight
    {

        [ForeignKey("Para")]

        [Column(TypeName = "nvarchar(10)")]
        public string ParaId { get; set; }

        public Para Para { get; set; }
    }
}
