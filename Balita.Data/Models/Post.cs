using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Balita.Data.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public DateTime PostedDate { get; set; }
        public int CommentCount { get; set; }
        public string PostHeadline { get; set; }
        public string PostText { get; set; }
        public byte[] Image { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
    }
}