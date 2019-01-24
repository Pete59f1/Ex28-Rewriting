using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ex28_Rewriting;

namespace View_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Ex28_Rewriting.Control cont = new Ex28_Rewriting.Control();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FindOwnerBut_Click(object sender, RoutedEventArgs e)
        {
            findOwnerBlock.Text = cont.FindOwnerByLastName(findOwerByLNTB.Text).LastName +  " " + cont.FindOwnerByLastName(findOwerByLNTB.Text).FirstName;
        }

        private void AllPetsBut_Click(object sender, RoutedEventArgs e)
        {
            foreach (Pet pet in cont.ShowPets())
            {
                allPetsTB.Text += pet.Name + pet.Type + pet.Breed + pet.DOB + pet.Weight + pet.OwnerId + "\n";
            }
        }

        private void InsertOwnerBut_Click(object sender, RoutedEventArgs e)
        {
            cont.InsertOwner(ownerFNTB.Text, ownerLNTB.Text, ownerTLFTB.Text, ownerEmailTB.Text);
        }

        private void InsertPetBut_Click(object sender, RoutedEventArgs e)
        {
            cont.InsertPet(petNameTB.Text, petTypeTB.Text, petBreedTB.Text, petDOBTB.Text, petWeightTB.Text, petOwnerIdTB.Text);
        }
    }
}
