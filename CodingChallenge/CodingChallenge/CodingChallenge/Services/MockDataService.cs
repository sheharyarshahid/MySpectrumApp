using System;
using System.Collections.ObjectModel;
using CodingChallenge.Models;
using CodingChallenge.Services;
using CodingChallenge.Services.Contracts;
using Xamarin.Forms;

[assembly: Dependency(typeof(MockDataService))]
namespace CodingChallenge.Services
{
    public class MockDataService : IMockDataService
    {
        public ObservableCollection<Person> GetPersons()
        {
            return new ObservableCollection<Person>()
            {
                new Person
                {
                    Id = 1,
                    FirstName = "Adriaens",
                    LastName = "Franzonetti",
                    Email = "afranzonetti0@privacy.gov.au",
                    Gender = "Female",
                    Avatar = "https://robohash.org/natustemporibusomnis.png?size=100x100&set=set1"
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Lorne",
                    LastName = "Rayson",
                    Email = "lrayson1@jimdo.com",
                    Gender = "Female",
                    Avatar = "https://robohash.org/etanimiveniam.png?size=100x100&set=set1"
                },
                new Person
                {
                    Id = 3,
                    FirstName = "Marleah",
                    LastName = "Goschalk",
                    Email = "mgoschalk2@over-blog.com",
                    Gender = "Female",
                    Avatar = "https://robohash.org/quiarerumsed.png?size=100x100&set=set1"
                },
                new Person
                {
                    Id = 4,
                    FirstName = "Ramsey",
                    LastName = "Manwaring",
                    Email = "rmanwaring3@bluehost.com",
                    Gender = "Male",
                    Avatar = "https://robohash.org/exercitationemdignissimosratione.png?size=100x100&set=set1"
                },
                new Person
                {
                    Id = 5,
                    FirstName = "Matthaeus",
                    LastName = "Timewell",
                    Email = "mtimewell4@addthis.com",
                    Gender = "Male",
                    Avatar = "https://robohash.org/utnisivel.png?size=100x100&set=set1"
                },
                new Person
                {
                    Id = 6,
                    FirstName = "Sim",
                    LastName = "Cunah",
                    Email = "scunah5@barnesandnoble.com",
                    Gender = "Male",
                    Avatar = "https://robohash.org/evenietvoluptasquis.png?size=100x100&set=set1"
                },
                new Person
                {
                    Id = 7,
                    FirstName = "Adriaens",
                    LastName = "Franzonetti",
                    Email = "afranzonetti0@privacy.gov.au",
                    Gender = "Female",
                    Avatar = "https://robohash.org/natustemporibusomnis.png?size=100x100&set=set1"
                },
                new Person
                {
                    Id = 8,
                    FirstName = "Lorne",
                    LastName = "Rayson",
                    Email = "lrayson1@jimdo.com",
                    Gender = "Female",
                    Avatar = "https://robohash.org/etanimiveniam.png?size=100x100&set=set1"
                },
                new Person
                {
                    Id = 9,
                    FirstName = "Marleah",
                    LastName = "Goschalk",
                    Email = "mgoschalk2@over-blog.com",
                    Gender = "Female",
                    Avatar = "https://robohash.org/quiarerumsed.png?size=100x100&set=set1"
                },
                new Person
                {
                    Id = 10,
                    FirstName = "Ramsey",
                    LastName = "Manwaring",
                    Email = "rmanwaring3@bluehost.com",
                    Gender = "Male",
                    Avatar = "https://robohash.org/exercitationemdignissimosratione.png?size=100x100&set=set1"
                },
                new Person
                {
                    Id = 11,
                    FirstName = "Matthaeus",
                    LastName = "Timewell",
                    Email = "mtimewell4@addthis.com",
                    Gender = "Male",
                    Avatar = "https://robohash.org/utnisivel.png?size=100x100&set=set1"
                },
                new Person
                {
                    Id = 12,
                    FirstName = "Sim",
                    LastName = "Cunah",
                    Email = "scunah5@barnesandnoble.com",
                    Gender = "Male",
                    Avatar = "https://robohash.org/evenietvoluptasquis.png?size=100x100&set=set1"
                }
            };
        }
    }
}

