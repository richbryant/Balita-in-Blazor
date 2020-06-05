using System.Collections.Generic;

namespace Balita.Shared.Models.Posts
{
    public interface IPost
    {
        public string Category { get; set; }
        public string PostedDate { get; set; }
        public int CommentCount { get; set; }
        public string PostHeadline { get; set; }
        public string PostText { get; set; }
    }
}