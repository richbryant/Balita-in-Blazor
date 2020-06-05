using Balita.Shared.Models.Posts;
using Microsoft.AspNetCore.Components;
using System;

namespace Balita.Client.Shared
{
    public partial class ReadPostSummary : IPostOutline
    {
        public string LinkUrl { get; set; }

        public string ImageUrl { get; set; }

        [Parameter]
        public string Category { get; set; }

        [Parameter]
        public string PostedDate { get; set; } = DateTime.Today.ToString("d MMMM yyyy");

        [Parameter]
        public int CommentCount { get; set; }

        [Parameter]
        public string PostHeadline { get; set; }
    }
}
