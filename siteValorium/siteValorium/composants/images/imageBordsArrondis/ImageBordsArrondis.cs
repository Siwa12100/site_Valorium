using Microsoft.AspNetCore.Components;

namespace siteValorium.composants.images.imageBordsArrondis
{
    public partial class ImageBordsArrondis
    {

        [Parameter]
        public String EmplacementImage {  get; set; }

        [Parameter]
        public String DescriptionImage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (DescriptionImage == null)
            {
                DescriptionImage = "Pas de description pour cette image";
            }

            await base.OnInitializedAsync();   
        }
    }
}
