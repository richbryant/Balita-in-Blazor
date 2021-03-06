﻿namespace Balita.Shared.Models.Posts
{
    public class PostOutline : IPostOutline
    {
        public string LinkUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string PostedDate { get; set; }
        public int CommentCount { get; set; }
        public string PostHeadline { get; set; }
    }
}