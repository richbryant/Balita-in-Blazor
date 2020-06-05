using System;

namespace Balita.Shared.Models.Posts
{
    public interface IPostOutline
    {
        string LinkUrl { get; set; }

        string ImageUrl { get; set; }

        string Category { get; set; } 

        string PostedDate { get; set; }

        int CommentCount { get; set; }
        
        string PostHeadline { get; set; }
    }
}