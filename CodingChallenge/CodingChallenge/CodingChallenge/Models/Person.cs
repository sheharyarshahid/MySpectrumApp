using CommunityToolkit.Mvvm.ComponentModel;

namespace CodingChallenge.Models
{
    public partial class Person : ObservableObject
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Avatar { get; set; }

        [ObservableProperty]
        bool isPlantVisible = false;

        [ObservableProperty]
        int plantationCount = 1;
    }
}
