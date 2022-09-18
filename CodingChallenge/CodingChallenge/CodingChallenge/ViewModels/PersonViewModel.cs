using CodingChallenge.Models;
using CodingChallenge.Services.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CodingChallenge.ViewModels
{
    public partial class PersonViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Person> persons;

        [ObservableProperty]
        ObservableCollection<Person> filteredPersons;

        public PersonViewModel()
        {
            IMockDataService mockDataService = DependencyService.Get<IMockDataService>();
            Persons = mockDataService.GetPersons();
            FilteredPersons = mockDataService.GetPersons();
        }
    }
}
