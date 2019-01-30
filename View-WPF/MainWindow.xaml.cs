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
    public partial class MainWindow : Window, ISubscriber
    {
        Ex28_Rewriting.Control cont = new Ex28_Rewriting.Control();
        public MainWindow()
        {
            InitializeComponent();
            cont.RegisterSubscriber(this);
        }

        private void FindOwnerBut_Click(object sender, RoutedEventArgs e)
        {
            findOwnerBlock.Text = cont.FindOwnerByLastName(findOwerByLNTB.Text).LastName +  " " + cont.FindOwnerByLastName(findOwerByLNTB.Text).FirstName;
        }

        private void AllPetsBut_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < cont.ShowPets().Count; i++)
            {
                allPetsTB.Text += cont.ShowPets()[i].Name + cont.ShowPets()[i].Type + cont.ShowPets()[i].Breed + cont.ShowPets()[i].DOB + cont.ShowPets()[i].Weight + cont.ShowPets()[i].OwnerId + "\n";
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

        public void Update(IPublisher publisher, string message)
        {
            allPetsTB.Text += cont.ShowPets()[cont.ShowPets().Count - 1].Name + cont.ShowPets()[cont.ShowPets().Count - 1].Type + cont.ShowPets()[cont.ShowPets().Count - 1].Breed + cont.ShowPets()[cont.ShowPets().Count - 1].DOB + cont.ShowPets()[cont.ShowPets().Count - 1].Weight + cont.ShowPets()[cont.ShowPets().Count - 1].OwnerId + "\n";
        }
    }
}
