﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TTTN_WEB_ASP.Models.EF
{
    [Table("tb_Post")]
    public class Posts : CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Title { get; set; }
        [StringLength(150)]
        public string Alias { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        [StringLength(250)]
        public string Image { get; set; }
        public int CatagoryId { get; set; }
         [StringLength(250)]
        public string SeoTitle { get; set; }
         [StringLength(550)]
        public string SeoDescription { get; set; }
          [StringLength(250)]
        public string SeoKeywords { get; set; }
        public bool IsActive { get; set; }
        public virtual Category Category { get; set; }
    }
}