using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace TTTN_WEB_ASP.Models.EF
{
    [Table("tb_Sub")]
    public class Sub 
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [EmailAddress]
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}