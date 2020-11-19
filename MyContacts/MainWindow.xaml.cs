using System;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using MyContacts.Model;
using MyContacts.Data;
using System.Collections.Generic;

namespace MyContacts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListView contactsList;

        private User user;

        private static bool isCarouselOn;
        public MainWindow(User currentUser)
        {
            user = currentUser;
            InitializeComponent();
            DataContext = DatabaseHelper.GetInstance().GetContactsByUser(user);
            //this.DataContextChanged += onchangedContext;
        }

        public override void EndInit()
        {
            middleContainer.DataContext = user.Contacts;
            TextBlock currentIp = new TextBlock()
            {
                Text = $"آی پی شما \n {this.GetLocalIPAddress()}",
                Foreground = Brushes.White,
                FontSize = 22,
                TextAlignment = TextAlignment.Center,
                FontFamily = new FontFamily("Arial"),
                Padding = new Thickness(0, 10, 0, 0)
            };
            carouselMenu.Children.Add(currentIp);
            Grid.SetRow(currentIp, 1);

            var itemsBinding = new Binding("Contacts") { Source = DataContext };


            contactsList = new ListView()
            {
                ItemsSource = (System.Collections.IEnumerable)itemsBinding.Source,
                Margin = new Thickness(5),
                Background = (Brush)new BrushConverter().ConvertFrom("#1f2936"),
            };
            Grid.SetRow(contactsList, 1); Grid.SetColumnSpan(contactsList, 2);
            foreach (var item in user.Contacts)
            {
                Border border = new Border() { BorderThickness = new Thickness(0), Width = 80, Height = 80, CornerRadius = new CornerRadius(12) };
                StackPanel container = new StackPanel()
                {
                    Height = 100,
                    Orientation = Orientation.Horizontal
                };
                Image image = new Image() { Source = new BitmapImage(new Uri($"{AppDomain.CurrentDomain.BaseDirectory}/Images/{user.Id}_{item.Id}.jpg")) };
                TextBlock textBlock = new TextBlock()
                {
                    Text = $"{item.FullName}",
                    Padding = new Thickness(5),
                    Foreground = Brushes.White,
                    VerticalAlignment = VerticalAlignment.Center
                ,
                    FontSize = 19,
                    FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./resources/#B Nazanin")
                };
                border.Child = image;
                container.Children.Add(border);
                container.Children.Add(textBlock);
                contactsList.Items.Add(container);
            }
            middleContainer.Children.Add(contactsList);
            base.EndInit();
        }



        public void manageOutCarousel()
        {
            if (isCarouselOn)
            {
                middleContainer.Opacity = 1;
                toolbarMenu.Opacity = 1;
                conversationBox.Opacity = 1;

            }
            else
            {
                middleContainer.Opacity = 0.3;
                toolbarMenu.Opacity = 0.3;
                conversationBox.Opacity = 0.3;
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "جستجو")
            {
                txtSearch.Text = "";
            }

        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = "جستجو";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            isCarouselOn = false;
            manageOutCarousel();
        }

        private void outCarouselZone_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isCarouselOn = true;
            manageOutCarousel();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!double.IsNaN(this.Width))
            {
                btnShowCarousel.FontSize = this.Width / 35;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //AddContact form = new AddContact(user);
            //this.IsEnabled = true;
            //form.ShowDialog();
            //BeginInit();
            //EndInit();
        }

        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "No network adapters with an IPv4 address in the system!";
        }

        private void txtSearch_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var updatedContacts = (List<Contact>)DataContext;
            if (!string.IsNullOrEmpty(txtSearch.Text) || txtSearch.Text != "جستجو")
            {
                updatedContacts = Utilities.Utilities.FilterByFullName(txtSearch.Text,(List<Contact>)DataContext);
            }
            contactsList.Items.Clear();
            foreach (var item in updatedContacts)
            {
                Border border = new Border() { BorderThickness = new Thickness(0), Width = 80, Height = 80, CornerRadius = new CornerRadius(12) };
                StackPanel container = new StackPanel()
                {
                    Height = 100,
                    Orientation = Orientation.Horizontal
                };
                Image image = new Image() { Source = new BitmapImage(new Uri($"{AppDomain.CurrentDomain.BaseDirectory}/Images/{user.Id}_{item.Id}.jpg"))};
                TextBlock textBlock = new TextBlock()
                {
                    Text = $"{item.FullName}",
                    Padding = new Thickness(5),
                    Foreground = Brushes.White,
                    VerticalAlignment = VerticalAlignment.Center
                ,
                    FontSize = 19,
                    FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./resources/#B Nazanin")
                };
                border.Child = image;
                container.Children.Add(border);
                container.Children.Add(textBlock);
                contactsList.Items.Add(container);
            }

        }
    }
}
