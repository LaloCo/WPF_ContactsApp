using DesktopContactsApp.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        Contact selectedContact;
        public ContactDetailsWindow(Contact selectedContact)
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            this.selectedContact = selectedContact;
            nameTextBox.Text = this.selectedContact.Name;
            emailTextBox.Text = this.selectedContact.Email;
            phoneTextBox.Text = this.selectedContact.Phone;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            selectedContact.Name = nameTextBox.Text;
            selectedContact.Phone = phoneTextBox.Text;
            selectedContact.Email = emailTextBox.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                conn.Update(selectedContact);
            }

            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                conn.Delete(selectedContact);
            }

            Close();
        }
    }
}
