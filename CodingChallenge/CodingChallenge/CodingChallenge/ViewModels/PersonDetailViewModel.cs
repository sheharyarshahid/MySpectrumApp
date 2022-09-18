using System;
using System.IO;
using System.Threading.Tasks;
using CodingChallenge.Models;
using CodingChallenge.Services.Contracts;
using CodingChallenge.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Xamarin.Forms;

namespace CodingChallenge.ViewModels
{
    public partial class PersonDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        Person person;

        [ObservableProperty]
        string plantDesc;

        [ObservableProperty]
        string plantImg;

        public PersonDetailViewModel(Person person)
        {
            this.Person = person;
            this.PlantImg = Constants.PlantImg;
            this.plantDesc = Constants.PlantDesc;
        }

        [RelayCommand]
        public void PlantTree() =>
            person.IsPlantVisible = true;

        [RelayCommand]
        public void IncrementPlant() =>
            person.PlantationCount++;
    }
}
