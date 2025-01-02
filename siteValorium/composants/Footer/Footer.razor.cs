using Microsoft.AspNetCore.Components;

namespace siteValorium.composants.Footer
{
    public partial class Footer
    {
        [Inject]
        protected NavigationManager? navigationManager {  get; set; }

        private ElementReference elementRef;

        protected void RedirectionValorium()
        {
            if (this.navigationManager == null) return;
            navigationManager.NavigateTo("https://discord.gg/dN2V7tn6gV");

        }

        protected void RedirectionAccueil()
        {
            if (this.navigationManager == null) return;
            navigationManager.NavigateTo("/");

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await elementRef.FocusAsync();
            }
        }

    }
}