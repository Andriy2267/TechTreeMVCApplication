﻿using System.ComponentModel.DataAnnotations;

namespace TechTreeMVCApplication.Entities
{
    public class Content
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }

        [Display(Name = "HTML Content")]
        public string HTMLContent { get; set; }

        [Display(Name = "Video Link")]
        public string VideoLink { get; set; }

        public CategoryItem CategoryItem { get; set; }
    }
}