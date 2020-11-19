using Microsoft.Win32;
using MyContacts.Data;
using MyContacts.Interfaces.Validations.Repositories;
using MyContacts.Interfaces.Validations.Services;
using MyContacts.Model;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace MyContacts.Contacts
{
    /// <summary>
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        private User _user;

        private static OpenFileDialog imgDialog;

        private IValidationRepository _vl;

        public AddContact(User user)
        {
            _user = user;
            _vl = new ValidationRepository();
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtAge.Text == "سن")
            {
                txtAge.Text = "";
                txtAge.FlowDirection = FlowDirection.LeftToRight;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAge.Text))
            {
                txtAge.FlowDirection = FlowDirection.RightToLeft;
                txtAge.Text = "سن";
            }
        }

        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (txtFullName.Text == "نام و نام خانوادگی")
            {
                txtFullName.Text = "";
                txtFullName.FlowDirection = FlowDirection.RightToLeft;
            }
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                txtFullName.FlowDirection = FlowDirection.RightToLeft;
                txtFullName.Text = "نام و نام خانوادگی";
            }
        }

        private void TextBox_GotFocus_2(object sender, RoutedEventArgs e)
        {
            if (txtIp.Text == "آی پی")
            {
                txtIp.Text = "";
                txtIp.FlowDirection = FlowDirection.LeftToRight;
            }
        }

        private void TextBox_LostFocus_2(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIp.Text))
            {
                txtIp.FlowDirection = FlowDirection.RightToLeft;
                txtIp.Text = "آی پی";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_vl.IsContactValid(txtFullName.Text, txtIp.Text, int.Parse(txtAge.Text)))
            {
                Contact contact = new Contact() { Age = int.Parse(txtAge.Text), FullName = txtFullName.Text, Ip = txtIp.Text};
                DatabaseHelper.GetInstance().InsertContact(contact);
                var id = contact.Id;
                if (!Directory.Exists($"{AppDomain.CurrentDomain.BaseDirectory}/Images"))
                {
                    Directory.CreateDirectory(($"{AppDomain.CurrentDomain.BaseDirectory}/Images"));
                }
                File.Copy(imgDialog.FileName, ($"{AppDomain.CurrentDomain.BaseDirectory}/Images/{_user.Id}_{contact.Id}.jpg"));
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                txtRes.Text = "لطفا موارد خواسته شده را وارد نمایید";
            }
        }

        private void txtAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"[0-9]");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }
        private void txtIp_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"[0-9.]");
            if (!regex.IsMatch(e.Text))
            {
                e.Handled = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            imgDialog = new OpenFileDialog();
            if (imgDialog.ShowDialog().Value)
            {
                e.Handled = true;
            }
        }
    }
}
