using Microsoft.AspNetCore.Components;
using CollegeEnrollment_Cllient.Service.IService;

namespace CollegeEnrollment_Cllient.Pages.Authentication
{
    public partial class Logout
    {
        [Inject]
        public IAuthenticationService _authSerivce { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await _authSerivce.Logout();
            _navigationManager.NavigateTo("/");
        }
    }
}