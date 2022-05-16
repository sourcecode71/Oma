using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Oma.Api.models.Vendor;
using System.Net.Http.Json;


namespace Oma.Client.Pages
{
    public partial class Index
    {
        private SupplierModel[]? suppliers;
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            suppliers = await Http.GetFromJsonAsync<SupplierModel[]>("api/supplier");
        }
        protected async Task DeleteSupplier(Guid Id)
        {
            bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure want to delete the supplier?");
            if (confirmed)
            {
                Console.WriteLine(Id);

                await Http.DeleteAsync("api/supplier/" + Id).ConfigureAwait(false);
                suppliers = await Http.GetFromJsonAsync<SupplierModel[]>("api/supplier");
            }
        }
        protected void UpdateSupplier(Guid Id)
        {
            NavigationManager.NavigateTo("/counter/" + Id);
        }
    }
}
