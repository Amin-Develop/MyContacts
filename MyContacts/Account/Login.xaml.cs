using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using MyContacts.Interfaces.Validations.Repositories;
using MyContacts.Interfaces.Validations.Services;

namespace MyContacts.Account
{
	public partial class Login : Window
	{
		private IValidationRepository _validationRepository;

		public Login()
		{
			_validationRepository = new ValidationRepository();
			InitializeComponent();
		}

		private void TextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			if (txtPsw.Text == "کلمه ی عبور")
			{
				txtPsw.Text = "";
				txtPsw.FlowDirection = FlowDirection.LeftToRight;
			}
		}

		private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
		{
			if (txtUsr.Text == "نام کاربری")
			{
				txtUsr.Text = "";
				txtUsr.FlowDirection = FlowDirection.LeftToRight;
			}
		}

		private void txtPsw_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(txtPsw.Text))
			{
				txtPsw.FlowDirection = FlowDirection.RightToLeft;
				txtPsw.Text = "کلمه ی عبور";
			}
		}

		private void txtUsr_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(txtUsr.Text))
			{
				txtUsr.FlowDirection = FlowDirection.RightToLeft;
				txtUsr.Text = "نام کاربری";
			}
		}

		private void txt_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			var regex = new Regex("[a-zA-Z0-9]");
			if (!regex.IsMatch(e.Text)) e.Handled = true;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Register register = new Register();
			Close();
			register.ShowDialog();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			if (!_validationRepository.IsLoginFormValid(txtUsr.Text, txtPsw.Text))
			{
				txtRes.Text = _validationRepository.ReturnError();
			}
			else
			{
				MainWindow mainWindow = new MainWindow();
				Close();
				mainWindow.Show();
			}
		}
	}
}