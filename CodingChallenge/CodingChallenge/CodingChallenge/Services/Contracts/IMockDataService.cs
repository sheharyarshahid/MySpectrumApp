using System;
using System.Collections.ObjectModel;
using CodingChallenge.Models;

namespace CodingChallenge.Services.Contracts
{
    public interface IMockDataService
    {
        ObservableCollection<Person> GetPersons();
    }
}

