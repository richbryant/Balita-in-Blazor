using System;
using Balita.Shared.Models.Posts;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Balita.Client.Shared
{
    public partial class CardOverlay : IPostOutline
    {
        [Parameter]
        public string LinkUrl { get; set; } = "/";

        [Parameter]
        public string ImageUrl { get; set; } = "images/img_1.jpg";

        [Parameter]
        public string Category { get; set; } = "Lifestyle";

        [Parameter]
        public string PostedDate { get; set; } = DateTime.Today.ToString("d MMMM yyyy");

        [Parameter]
        public int CommentCount { get; set; } = 0;

        [Parameter]
        public string PostHeadline { get; set; } = string.Empty;

        public string BackgroundStyle { get; private set; }
        
        protected override Task OnParametersSetAsync()
        {
            if (!string.IsNullOrWhiteSpace(ImageUrl)) BackgroundStyle = $"background-image:url('{ImageUrl}');";
            return base.OnParametersSetAsync();
        }
    }
}
