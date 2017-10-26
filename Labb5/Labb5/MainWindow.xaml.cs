﻿using System;
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
            User user = new User();
            user.Namn = TextBoxNamn.Text;
            user.Epost = TextBoxEpost.Text;
            
            
            normalUsersListbox.Items.Add(user.Namn);


            //TextBox TextBoxItem = new TextBox();
            //normalUsersListbox.Items.Add(TextBoxNamn.Text);
        }
        private void ButtonÄndra_Click(object sender, RoutedEventArgs e)
        {
            /*
            if (normalUsersListbox.Items.Contains(normalUsersListbox.Items))
            {
                ButtonÄndra.IsEnabled = true;
            }

            
            ButtonÄndra.IsEnabled = false;
            if (normalUsersListbox.IsFocused)
            {
                ButtonÄndra.IsEnabled = true;
            }
            */
        }

        private void buttonTaBort_Click_1(object sender, RoutedEventArgs e)
        {
            normalUsersListbox.Items.Remove(normalUsersListbox.SelectedItem);
        }
    }
}
