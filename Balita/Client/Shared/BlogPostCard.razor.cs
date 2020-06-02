using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Balita.Client.Shared
{
    public partial class BlogPostCard
    {
        [Parameter] 
        public string LinkUrl { get; set; } = "/";

        [Parameter] 
        public string ImageUrl { get; set; }

        [Parameter] 
        public string Category { get; set; } = "Lifestyle";

        [Parameter] 
        public string PostedDate { get; set; } = DateTime.Today.ToString("d MMMM yyyy");

        [Parameter] 
        public int CommentCount { get; set; } = 0;
        
        [Parameter] 
        public string PostHeadline { get; set; } = string.Empty;
    }
}
