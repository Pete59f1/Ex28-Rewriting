using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28_Rewriting
{
    public class Control : IPublisher
    {
        List<ISubscriber> subs = new List<ISubscriber>();
        DBControl DBC = new DBControl();
        public void InsertPet(string name, string type, string breed, string dob, string weight, string ownerId)
        {
            Pet pet = new Pet { Name = name, Type = type, Breed = breed, DOB = dob, Weight = weight, OwnerId = ownerId };
            DBC.InsertPet(pet);
            NotifySubscribers(name);
        }

        public void InsertOwner(string firstName, string lastName, string phone, string email)
        {
           Owner own = new Owner { FirstName = firstName, LastName = lastName, Phone = phone, Email = email };
           DBC.InsertOwner(own);
           NotifySubscribers(firstName);
        }

        public List<Pet> ShowPets()
        {
            return DBC.ShowPets();
        }

        public List<Owner> FindOwnerByLastName(string lastName)
        {
            return DBC.FindOwnerByLastName(lastName);
        }

        public Owner FindOwnerByEmail(string email, string name)
        {
            return DBC.FindOwnerByEmail(email, name);
        }

        public void RegisterSubscriber(ISubscriber observer)
        {
            subs.Add(observer);
        }

        public void RemoveSubscriber(ISubscriber observer)
        {
            subs.Remove(observer);
        }

        public void NotifySubscribers(string message)
        {
            foreach (ISubscriber sub in subs)
            {
                sub.Update(this, message);
            }
        }
    }
}
