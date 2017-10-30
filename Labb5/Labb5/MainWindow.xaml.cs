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

        private void ButtonSkapa_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNamn.Text != "" && TextBoxEpost.Text != "")
            {
                normalUsersListbox.Items.Add(new User(TextBoxNamn.Text, TextBoxEpost.Text));
                TextBoxNamn.Clear();
                TextBoxEpost.Clear();
            }
        }

        private void buttonTaBort_Click_1(object sender, RoutedEventArgs e)
        {
            if (normalUsersListbox.SelectedIndex >= 0)
                normalUsersListbox.Items.Remove(normalUsersListbox.Items[normalUsersListbox.SelectedIndex]);
            else if (AdminListBox.SelectedIndex >= 0)
                AdminListBox.Items.Remove(AdminListBox.Items[AdminListBox.SelectedIndex]);

            ChangeUser.IsEnabled = false;
            ButtonChangeToAdmin.IsEnabled = false;
            buttonTaBort.IsEnabled = false;
            ButtonChangeToUser.IsEnabled = false;
        }

        private void normalUsersListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (normalUsersListbox.SelectedIndex >= 0)
            {
                ChangeUser.IsEnabled = true;
                ButtonChangeToAdmin.IsEnabled = true;
                buttonTaBort.IsEnabled = true;
                ButtonChangeToUser.IsEnabled = true;
            }
        }

        private void ButtonChangeToUser_Click(object sender, RoutedEventArgs e)
        {
            normalUsersListbox.Items.Add(AdminListBox.SelectedItem);
            AdminListBox.Items.Remove(AdminListBox.SelectedItem);
            ChangeUser.IsEnabled = false;
            ButtonChangeToAdmin.IsEnabled = false;
            buttonTaBort.IsEnabled = false;
            ButtonChangeToUser.IsEnabled = false;
        }
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
            else {
                labelUserInfo.Content = "Du måste skapa en ny \vanvändare eller välja en \vexisterande";
            }
        }

        private void ButtonChangeToAdmin_Click_1(object sender, RoutedEventArgs e)
        {
            AdminListBox.Items.Add(normalUsersListbox.SelectedItem);
            normalUsersListbox.Items.Remove(normalUsersListbox.SelectedItem);
            ChangeUser.IsEnabled = false;
            ButtonChangeToAdmin.IsEnabled = false;
            buttonTaBort.IsEnabled = false;
            ButtonChangeToUser.IsEnabled = false;
        }

        private void AdminListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AdminListBox.SelectedIndex >= 0)
            {
                ChangeUser.IsEnabled = true;
                ButtonChangeToAdmin.IsEnabled = true;
                buttonTaBort.IsEnabled = true;
                ButtonChangeToUser.IsEnabled = true;
            }
        }

        private void ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (normalUsersListbox.SelectedIndex >= 0)
            {
                normalUsersListbox.Items.Remove(normalUsersListbox.Items[normalUsersListbox.SelectedIndex]);
                normalUsersListbox.Items.Add(new User(TextBoxNamn.Text, TextBoxEpost.Text));
                TextBoxNamn.Clear();
                TextBoxEpost.Clear();
            }
            else if (AdminListBox.SelectedIndex >= 0)
            {
                AdminListBox.Items.Remove(AdminListBox.Items[AdminListBox.SelectedIndex]);
                AdminListBox.Items.Add(new User(TextBoxNamn.Text, TextBoxEpost.Text));
                TextBoxNamn.Clear();
                TextBoxEpost.Clear();
            }
        }
    }
}
