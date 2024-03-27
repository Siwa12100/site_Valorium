using Microsoft.AspNetCore.Components;

namespace siteValorium.composants.navbar
{
    public partial class Navbar
    {
        private ElementReference elementRef;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await elementRef.FocusAsync();
            }
        }

    }
}
