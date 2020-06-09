using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Balita.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int? ResponseTo { get; set; }
        public string Username { get; set; }
        public string UserId { get; set; }
        public string CommentText { get; set; }

        public ApplicationUser User {get;set;}
        public Post Post { get; set; }
        public Comment Parent { get; set; }
        public List<Comment> Children { get; set; }
    }
}