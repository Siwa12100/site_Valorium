using Microsoft.AspNetCore.Components;

namespace siteValorium.composants.images.videos.videoBordsArrondis
{
    public partial class VideoBordsArrondis
    {

        [Parameter]
        public String IdVideo {  get; set; }

        private String LienVideo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            this.LienVideo = "https://www.youtube.com/embed/" + this.IdVideo + "?mute=1&controls=0&autoplay=1&start=60";
            Console.Write("Lien video : " + this.LienVideo);

            await base.OnInitializedAsync();
        }
    }
}
