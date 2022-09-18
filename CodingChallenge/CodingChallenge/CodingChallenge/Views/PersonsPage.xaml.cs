using System.Linq;
using System.Collections.ObjectModel;
using CodingChallenge.Models;
using CodingChallenge.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;

namespace CodingChallenge.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonsPage : ContentPage
    {
        public PersonViewModel ViewModel { get; private set; }

        public PersonsPage()
        {
            InitializeComponent();

            BindingContext = ViewModel = new PersonViewModel();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection[0] is Person selectedPerson)
            {
                await Navigation.PushAsync(new PersonDetailsPage(selectedPerson));
            }
        }

        void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchTerm = e.NewTextValue;

                if (PersonsCollectionView.BindingContext != ViewModel)
                {
                    PersonsCollectionView.BindingContext = ViewModel;
                }

                if (searchTerm?.Length >= 1)
                {
                    searchTerm = searchTerm.ToLowerInvariant();
                    PersonsCollectionView.SetBinding(CollectionView.ItemsSourceProperty, "FilteredPersons", BindingMode.OneWay);

                    var filteredPersons = ViewModel.Persons
                        .Where(x => x.FirstName.ToLowerInvariant().Contains(searchTerm))
                        .ToList();

                    for (int i = ViewModel.Persons.Count - 1; i >= 0; i--)
                    {
                        var person = ViewModel.Persons[i];

                        if (!filteredPersons.Any(x => x.Id == person.Id))
                        {
                            ViewModel.FilteredPersons.RemoveAt(person.Id - 1);
                        }
                        else if (!ViewModel.FilteredPersons.Any(x => x.Id == person.Id))
                        {
                            ViewModel.FilteredPersons.Insert(person.Id + 1, person);
                        }
                    }
                }
                else
                {
                    PersonsCollectionView.SetBinding(CollectionView.ItemsSourceProperty, "Persons", BindingMode.OneWay);
                }
            }
            catch (IndexOutOfRangeException) { }
            catch (ArgumentOutOfRangeException) { }
            catch (Exception) { }
        }
    }
}