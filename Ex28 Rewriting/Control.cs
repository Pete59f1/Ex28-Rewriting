using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28_Rewriting
{
    public class Control
    {

        DBControl DBC = new DBControl();
        public void InsertPet(string name, string type, string breed, string dob, string weight, string ownerId)
        {
            Pet pet = new Pet { Name = name, Type = type, Breed = breed, DOB = dob, Weight = weight, OwnerId = ownerId };
            DBC.InsertPet(pet);
        }

        public void InsertOwner(string firstName, string lastName, string phone, string email)
        {
           Owner own = new Owner { FirstName = firstName, LastName = lastName, Phone = phone, Email = email };
           DBC.InsertOwner(own);
        }

        public List<Pet> ShowPets()
        {
            return DBC.ShowPets();
        }

        public Owner FindOwnerByLastName(string lastName)
        {
            return DBC.FindOwnerByLastName(lastName);
        }

        public Owner FindOwnerByEmail(string email, string name)
        {
            return DBC.FindOwnerByEmail(email, name);
        }
    }
}
