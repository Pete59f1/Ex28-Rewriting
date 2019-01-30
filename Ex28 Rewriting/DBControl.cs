using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ex28_Rewriting
{
    public class DBControl
    {
        private static string conntectionString =
        "Server = ealSQL1.eal.local; Database = A_DB26_2018; User Id = A_STUDENT26; Password = A_OPENDB26;";

        public void InsertPet(Pet pet)
        {
            using (SqlConnection con = new SqlConnection(conntectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("InsertPet", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    
                    cmd1.Parameters.Add(new SqlParameter("@PetName", pet.Name));
                    cmd1.Parameters.Add(new SqlParameter("@PetType", pet.Type));
                    cmd1.Parameters.Add(new SqlParameter("@PetBreed", pet.Breed));
                    cmd1.Parameters.Add(new SqlParameter("@PetDOB", pet.DOB));
                    cmd1.Parameters.Add(new SqlParameter("@PetWeight", pet.Weight));
                    cmd1.Parameters.Add(new SqlParameter("@OwnerID", pet.OwnerId));

                    cmd1.ExecuteNonQuery();
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Hovsa " + e.Message);
                }
            }
        }

        public void InsertOwner(Owner owner)
        {
            using (SqlConnection con = new SqlConnection(conntectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd1 = new SqlCommand("InsertPet_Owner", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    
                    cmd1.Parameters.Add(new SqlParameter("@OwnerFirstName", owner.FirstName));
                    cmd1.Parameters.Add(new SqlParameter("@OwnerLastName", owner.LastName));
                    cmd1.Parameters.Add(new SqlParameter("@OwnerPhone", owner.Phone));
                    cmd1.Parameters.Add(new SqlParameter("@OwnerEmail", owner.Email));

                    cmd1.ExecuteNonQuery();
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Hovsa " + e.Message);
                }
            }
        }

        public List<Pet> ShowPets()
        {
            List<Pet> pets = new List<Pet>();
            using (SqlConnection con = new SqlConnection(conntectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd2 = new SqlCommand("GetPets", con);
                    cmd2.CommandType = CommandType.StoredProcedure;

                    SqlDataReader read = cmd2.ExecuteReader();

                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            string name = read["PetName"].ToString();
                            string type = read["PetType"].ToString();
                            string breed = read["PetBreed"].ToString();
                            string DOB = read["PetDOB"].ToString();
                            string weight = read["PetWeight"].ToString();
                            string ownerid = read["OwnerID"].ToString();
                            pets.Add(new Pet { OwnerId = ownerid, Name = name, Type = type, Breed = breed, DOB = DOB, Weight = weight });
                        }
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Hovsa " + e.Message);
                }
                return pets;
            }
        }

        public List<Owner> FindOwnerByLastName(string lastName)
        {
            List<Owner> owners = new List<Owner>();
            using (SqlConnection con = new SqlConnection(conntectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd2 = new SqlCommand("GetOwnerByLastName", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@LastName", lastName));

                    SqlDataReader read = cmd2.ExecuteReader();

                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            string fname = read["OwnerFirstName"].ToString();
                            string lname = read["OwnerLastName"].ToString();
                            string phone = read["OwnerPhone"].ToString();
                            string email = read["OwnerEmail"].ToString();
                            owners.Add( new Owner { FirstName = fname, LastName = lname, Phone = phone, Email = email });
                        }
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Hovsa " + e.Message);
                }
                return owners;
            }
        }

        public Owner FindOwnerByEmail(string ownerEmail, string name)
        {
            Owner owner = null;
            using (SqlConnection con = new SqlConnection(conntectionString))
            {
                try
                {
                    con.Open();

                    SqlCommand cmd2 = new SqlCommand("GetOwnerByEmail", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@Name", name));
                    cmd2.Parameters.Add(new SqlParameter("@Email", ownerEmail));

                    SqlDataReader read = cmd2.ExecuteReader();

                    if (read.HasRows)
                    {
                        while (read.Read())
                        {
                            string fname = read["OwnerFirstName"].ToString();
                            string lname = read["OwnerLastName"].ToString();
                            string phone = read["OwnerPhone"].ToString();
                            string email = read["OwnerEmail"].ToString();
                            owner = new Owner { FirstName = fname, LastName = lname, Phone = phone, Email = email };
                        }
                    }
                }

                catch (SqlException e)
                {
                    Console.WriteLine("Hovsa " + e.Message);
                }
                return owner;
            }
        }
    }
}
