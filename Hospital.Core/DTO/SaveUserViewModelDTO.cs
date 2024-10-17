using Hospital.Core.Models.SaveViewModel;

namespace Hospital.Core.DTO
{
    public class SaveUserViewModelDTO:SaveUserViewModel
    {
        public string Token { get; set; }
    }
}
