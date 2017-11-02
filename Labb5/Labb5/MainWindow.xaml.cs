using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labb5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Bool som kollar om e-post addressen är valid
        public static bool IsValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        //Knapp för att skapa en ny användare
        private void ButtonSkapa_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNamn.Text != "" && IsValidEmail(TextBoxEpost.Text))  //If-sats för att kolla så att textboxarna inte är tomma
            {
                normalUsersListbox.Items.Add(new User(TextBoxNamn.Text, TextBoxEpost.Text));
                TextBoxNamn.Clear();
                TextBoxEpost.Clear();
            }
        }

        //Knapp för att ta bort en vald användare
        private void buttonTaBort_Click_1(object sender, RoutedEventArgs e)
        {
            //If-sats som kollar om man har valt en användare i listan med vanliga användare eller i Admin listan, tar sedan bort den valda användaren
            if (normalUsersListbox.SelectedIndex >= 0)
                normalUsersListbox.Items.Remove(normalUsersListbox.Items[normalUsersListbox.SelectedIndex]);
            else if (AdminListBox.SelectedIndex >= 0)
                AdminListBox.Items.Remove(AdminListBox.Items[AdminListBox.SelectedIndex]);
            //Sätter knapparna som ska vara disabled till disabled
            ChangeUser.IsEnabled = false;
            ButtonChangeToAdmin.IsEnabled = false;
            buttonTaBort.IsEnabled = false;
            ButtonChangeToUser.IsEnabled = false;
        }

        private void normalUsersListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //If-sats som kollar om man valt en användare i den normala listan och gör sedan rätt knappar enabled
            if (normalUsersListbox.SelectedIndex >= 0)
            {
                ChangeUser.IsEnabled = true;
                ButtonChangeToAdmin.IsEnabled = true;
                buttonTaBort.IsEnabled = true;
            }
        }

        //Knapp för att ändra en vald admin till normal användare
        private void ButtonChangeToUser_Click(object sender, RoutedEventArgs e)
        {
            //Lägger till den valda användaren till admin listan och tar bort från den gamla listan
            normalUsersListbox.Items.Add(AdminListBox.SelectedItem);
            AdminListBox.Items.Remove(AdminListBox.SelectedItem);

            //Sätter knapparna som ska vara disabled till disabled
            ChangeUser.IsEnabled = false;
            ButtonChangeToAdmin.IsEnabled = false;
            buttonTaBort.IsEnabled = false;
            ButtonChangeToUser.IsEnabled = false;
        }
        //Knapp för att få information om den valda användaren
        private void buttonInfo_Click(object sender, RoutedEventArgs e)
        {
            if (normalUsersListbox.SelectedIndex >= 0)
            {
                buttonInfo.IsEnabled = true;
                labelUserInfo.Content = $"Namn: {((User)normalUsersListbox.SelectedItem).Namn} \vEpost: {((User)normalUsersListbox.SelectedItem).Epost}";
            }
            else if (AdminListBox.SelectedIndex >= 0)
            {
                buttonInfo.IsEnabled = true;
                labelUserInfo.Content = $"Namn: {((User)AdminListBox.SelectedItem).Namn} \vEpost: {((User)AdminListBox.SelectedItem).Epost} ";
            }
            else
            {
                labelUserInfo.Content = "Du måste skapa en ny \vanvändare eller välja en \vexisterande";
            }
        }

        //Knapp för att ändra en normal användare till admin
        private void ButtonChangeToAdmin_Click_1(object sender, RoutedEventArgs e)
        {
            //Lägger till den valda adminen till användar listan och tar bort från den gamla listan
            AdminListBox.Items.Add(normalUsersListbox.SelectedItem);
            normalUsersListbox.Items.Remove(normalUsersListbox.SelectedItem);

            //Sätter knapparna som ska vara disabled till disabled
            ChangeUser.IsEnabled = false;
            ButtonChangeToAdmin.IsEnabled = false;
            buttonTaBort.IsEnabled = false;
            ButtonChangeToUser.IsEnabled = false;
        }

        private void AdminListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //If-sats som kollar om man valt en användare i admin listan och gör sedan rätt knappar enabled
            if (AdminListBox.SelectedIndex >= 0)
            {
                ChangeUser.IsEnabled = true;
                buttonTaBort.IsEnabled = true;
                ButtonChangeToUser.IsEnabled = true;
            }
        }

        //Knapp för att ändra en vald användare eller admin
        private void ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (normalUsersListbox.SelectedIndex >= 0)
            {
                if (TextBoxNamn.Text != "" && IsValidEmail(TextBoxEpost.Text))
                {
                    normalUsersListbox.Items.Remove(normalUsersListbox.Items[normalUsersListbox.SelectedIndex]);
                    normalUsersListbox.Items.Add(new User(TextBoxNamn.Text, TextBoxEpost.Text));
                    TextBoxNamn.Clear();
                    TextBoxEpost.Clear();
                }
            }
            else if (AdminListBox.SelectedIndex >= 0)
            {
                if (TextBoxNamn.Text != "" && IsValidEmail(TextBoxEpost.Text))
                {
                    AdminListBox.Items.Remove(AdminListBox.Items[AdminListBox.SelectedIndex]);
                    AdminListBox.Items.Add(new User(TextBoxNamn.Text, TextBoxEpost.Text));
                    TextBoxNamn.Clear();
                    TextBoxEpost.Clear();
                }
            }
        }
    }
}
