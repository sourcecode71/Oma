using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Oma.Api.models.Common;
using Oma.Api.models.Vendor;
using System.Net.Http.Json;

namespace Oma.Client.Pages.Vendor
{
    public partial class Supplier
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string Id { get; set; }
        private string TitleText { get; set; }
        private string BtnText { get; set; }

        SupplierModel supplierModel = new SupplierModel();
        List<StatesModel> stateLists = new List<StatesModel>();


        protected override async Task OnInitializedAsync()
        {
            stateLists = await Http.GetFromJsonAsync<List<StatesModel>>("api/states").ConfigureAwait(false);
            if (string.IsNullOrEmpty(Id))
            {
                BtnText = "Save";
                TitleText = "Add";
            }
            else
            {
                BtnText = "Update";
                TitleText = "Update";
                supplierModel = await Http.GetFromJsonAsync<SupplierModel>("api/supplier/" + Id).ConfigureAwait(false);
            }
        }


        protected async Task ValidFormSubmitted()
        {
            if (supplierModel != null)
            {
                if (string.IsNullOrEmpty(Id))
                {
                    await Http.PostAsJsonAsync("api/supplier", supplierModel).ConfigureAwait(false);
                    this.ResetForm();
                }
                else
                {
                    await Http.PutAsJsonAsync("api/supplier/" + Id, supplierModel).ConfigureAwait(false);
                    NavigationManager.NavigateTo("");
                }
            }
        }

        protected void InvalidFormSubmitted(EditContext editContext)
        {

        }

        protected void ResetForm()
        {
            supplierModel = new SupplierModel();
        }
    }
}
