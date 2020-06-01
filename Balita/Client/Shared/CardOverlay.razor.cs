using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Balita.Client.Shared
{
    public partial class CardOverlay
    {
        [Parameter]
        public string LinkUrl { get; set; } = "/";

        [Parameter]
        public string Image { get; set; } = "images/img_1.jpg";

        [Parameter]
        public string Category { get; set; } = "Lifestyle";

        [Parameter]
        public string PostDate { get; set; } = "June 1st 2020";

        [Parameter]
        public int CommentCount { get; set; } = 0;

        [Parameter]
        public string HeadingText { get; set; } = string.Empty;

        public string BackgroundStyle { get; private set; }

        protected override Task OnParametersSetAsync()
        {
            if (!string.IsNullOrWhiteSpace(Image)) BackgroundStyle = $"background-image:url('{Image}');";
            return base.OnParametersSetAsync();
        }
    }
}
