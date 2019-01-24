using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex28_Rewriting
{
    public class Menu
    {
        Control cont = new Control();
        private void Show()
        {
            Console.WriteLine("YELLO");
            Console.WriteLine("1. Insert a Pet");
            Console.WriteLine("2. Show all pets");
            Console.WriteLine("3. Insert Owner");
            Console.WriteLine("4. Find owner by last name");
            Console.WriteLine("5. Find owner by email");
            Console.WriteLine("0. Exit");
        }

        string name;
        string type;
        string breed;
        string dob;
        string weight;
        string ownerId;
        string lastName;
        string phone;
        string email;

        public void RunMenu()
        {
            Show();
            string input = GetUserInput();
            switch (input)
            {
                case "1":
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Pet name?");
                        name = Console.ReadLine();
                        Console.WriteLine("Pet type?");
                        type = Console.ReadLine();
                        Console.WriteLine("Pet breed?");
                        breed = Console.ReadLine();
                        Console.WriteLine("Pet date of birth?");
                        dob = Console.ReadLine();
                        Console.WriteLine("Pet weight?");
                        weight = Console.ReadLine();
                        Console.WriteLine("Owner Id?");
                        ownerId = Console.ReadLine();

                        cont.InsertPet(name, type, breed, dob, weight, ownerId);
                        Console.Write("\n");
                        break;

                    } while (true);
                    RunMenu();
                    break;

                case "2":
                    do
                    {
                        Console.Clear();
                        List<Pet> pets = cont.ShowPets();
                        foreach (Pet pet in pets)
                        {
                            Console.WriteLine(pet.OwnerId +  " " + pet.Name + " " + pet.Type + " " + pet.Breed + " " + pet.DOB + " " + pet.Weight);
                        }
                        Console.Write("\n");
                        break;

                    } while (true);
                    RunMenu();
                    break;

                case "3":
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Owner first name?");
                        name = Console.ReadLine();
                        Console.WriteLine("Owner last name?");
                        lastName = Console.ReadLine();
                        Console.WriteLine("Owner phone?");
                        phone = Console.ReadLine();
                        Console.WriteLine("Owner email?");
                        email = Console.ReadLine();

                        cont.InsertOwner(name, lastName, phone, email);
                        Console.Write("\n");
                        break;

                    } while (true);
                    RunMenu();
                    break;

                case "4":
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Owner last name?");
                        lastName = Console.ReadLine();
                        Owner owner = cont.FindOwnerByLastName(lastName);

                        Console.WriteLine(owner.LastName + " " + owner.FirstName + " " + owner.Phone + " " + owner.Email);
                        Console.Write("\n");
                        break;

                    } while (true);
                    RunMenu();
                    break;

                case "5":
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Owner email?");
                        email = Console.ReadLine();
                        Console.WriteLine("Owner name?");
                        name = Console.ReadLine();
                        Owner owner = cont.FindOwnerByEmail(email, name);

                        Console.WriteLine(owner.Email + " " + owner.FirstName + " " + owner.LastName + " " + owner.Phone);
                        Console.Write("\n");
                        break;
                    } while (true);
                    RunMenu();
                    break;

                case "0":
                    break;

                default:
                    do
                    {
                        Console.WriteLine("??");
                        Console.Write("\n");
                        break;

                    } while (true);
                    RunMenu();
                    break;
            }
        }

        private string GetUserInput()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}
