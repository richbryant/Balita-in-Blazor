using System;

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

        public Category Category { get; set; }
    }
}