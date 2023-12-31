﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace TTTN_WEB_ASP.Models.EF
{
    [Table("tb_Contact")]
    public class Contact : CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được quá 150 ký tự")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [StringLength(12)]
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}