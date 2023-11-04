namespace LogMeIn.Models.ViewModels;

public class JsonVm
{
    public class Animal
    {
        public Animal(string name, string title, string ems, string breed, string color,
            string pedigreeNumber, string sex, string birthDate, bool neutered, ParentInfo mother, ParentInfo father,
            BreederInfo breeder)
        {
            Name = name;
            Title = title;
            Ems = ems;
            Breed = breed;
            Color = color;
            PedigreeNumber = pedigreeNumber;
            Sex = sex;
            BirthDate = birthDate;
            Neutered = neutered;
            Mother = mother;
            Father = father;
            Breeder = breeder;
        }

        public string Name { get; set; }
        public string Title { get; set; }
        public string Ems { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public string PedigreeNumber { get; set; }
        public string BirthDate { get; set; }
        public string Sex { get; set; }
        public bool Neutered { get; set; }
        public ParentInfo Mother { get; set; }
        public ParentInfo Father { get; set; }
        public BreederInfo Breeder { get; set; }
    }

    public class ParentInfo
    {
        public ParentInfo(string name, string title, string ems, string pedigreeNumber, string breed,
            string color)
        {
            Name = name;
            Title = title;
            Ems = ems;
            PedigreeNumber = pedigreeNumber;
            Breed = breed;
            Color = color;
        }

        public string Name { get; set; }
        public string Title { get; set; }
        public string Ems { get; set; }
        public string PedigreeNumber { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
    }

    public class BreederInfo
    {
        public BreederInfo(string firstName, string lastName, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            Country = country;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
    }

    public class ExhibitorInfo
    {
        public ExhibitorInfo(string firstName, string lastName, string phone, string email, string street,
            string houseNumber, string city, string zip, string country, string association, string memberNumber,
            bool youngExhibitor)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Street = street;
            HouseNumber = houseNumber;
            City = city;
            Zip = zip;
            Country = country;
            Association = association;
            MemberNumber = memberNumber;
            YoungExhibitor = youngExhibitor;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Association { get; set; }
        public string MemberNumber { get; set; }
        public bool YoungExhibitor { get; set; }
    }

    public class ShowInfo
    {
        public ShowInfo(string @class, int? group, string note, Animal animal, ExhibitorInfo exhibitor)
        {
            Class = @class;
            Group = group;
            Note = note;
            Animal = animal;
            Exhibitor = exhibitor;
        }

        public string Class { get; set; }
        public int? Group { get; set; }
        public string Note { get; set; }
        public Animal Animal { get; set; }
        public ExhibitorInfo Exhibitor { get; set; }
    }
}

public class RootObject
{
    public RootObject(List<JsonVm.ShowInfo> entries)
    {
        Entries = entries;
    }

    public List<JsonVm.ShowInfo> Entries { get; set; }
}