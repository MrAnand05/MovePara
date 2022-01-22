﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovePara.Model
{
    //TODO: Put paraleft and pararight in different files.
    public class Para
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName ="int", Order =1)]
        public int Id { get; set; }

        [Key]
        [Column(TypeName ="nvarchar(10)", Order =2)]
        public string ParaId { get; set; }
        [Column(TypeName ="nvarchar(50)", Order =3)]
        public string ParaText { get; set; }
    }

}
