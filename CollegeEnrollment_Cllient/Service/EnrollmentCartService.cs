using Blazored.LocalStorage;
using CollegeEnrollment_Cllient.Service.IService;
using CollegeEnrollment_Cllient.ViewModels;
using CollegeEnrollment_Common;

namespace CollegeEnrollment_Cllient.Service
{
    public class EnrollmentCartService : IEnrollmentCartService
    {
        private readonly ILocalStorageService _localStorage;

        public EnrollmentCartService(ILocalStorageService localStorageService)
        {
            _localStorage = localStorageService;
        }

        public async Task IncrementEnrollmentCart(EnrollmentCart cartToAdd)
        {
            var cart = await _localStorage.GetItemAsync<List<EnrollmentCart>>(SD.EnrollmentCart);
            bool itemInCart = false;

            if(cart == null)
            {
                cart = new List<EnrollmentCart>();
            }
            foreach (var obj in cart)
            {
                if (obj.MajorId == cartToAdd.MajorId)
                {
                    itemInCart = true;
                    obj.Count = obj.Count+cartToAdd.Count;
                }
            }
            if (!itemInCart)
            {
                cart.Add(new EnrollmentCart()
                {
                    MajorId = cartToAdd.MajorId,
                    Count = cartToAdd.Count

                });
            }
            await _localStorage.SetItemAsync(SD.EnrollmentCart, cart);
        }

        public async Task DecrementEnrollmentCart(EnrollmentCart cartToDecrement)
        {
            var cart = await _localStorage.GetItemAsync<List<EnrollmentCart>>(SD.EnrollmentCart);

            // ako je broj 0 ili 1 onda je potrebno remove-ati
            for(int i=0; i<cart.Count; i++)
            {
                if (cart[i].MajorId == cartToDecrement.MajorId)
                {
                    if(cart[i].Count==1 || cart[i].Count == 0)
                    {
                        cart.Remove(cart[i]);
                    }
                    else
                    {
                        cart[i].Count -= cartToDecrement.Count;
                    }
                }
            }

          
            await _localStorage.SetItemAsync(SD.EnrollmentCart, cart);
        }
    }
}
