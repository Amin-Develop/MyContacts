using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using MyContacts.Data;
using MyContacts.Interfaces.Validations.Repositories;
using MyContacts.Interfaces.Validations.Services;
using MyContacts.Model;

namespace MyContacts.Account
{
	public partial class Register : Window
	{
		private IValidationRepository _validationRepository;

		public Register()
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
			Login account = new Login();
			this.Close();
			account.ShowDialog();
		}

		private void txtconfirmpwd_GotFocus(object sender, RoutedEventArgs e)
		{
			if (txtconfirmpwd.Text == "تکرار کلمه ی عبور")
			{
				txtconfirmpwd.Text = "";
				txtconfirmpwd.FlowDirection = FlowDirection.LeftToRight;
			}
		}

		private void txtconfirmpwd_LostFocus(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(txtconfirmpwd.Text))
			{
				txtconfirmpwd.FlowDirection = FlowDirection.RightToLeft;
				txtconfirmpwd.Text = "تکرار کلمه ی عبور";
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			//if (!string.IsNullOrWhiteSpace(txtUsr.Text) && !string.Equals("تکرار کلمه ی عبور", txtconfirmpwd.Text) &&
			//    !string.Equals("کلمه ی عبور", txtPsw.Text) && !string.Equals("نام کاربری", txtUsr.Text)
			//    && !string.IsNullOrWhiteSpace(txtPsw.Text) && !string.IsNullOrWhiteSpace(txtconfirmpwd.Text))
			//{
			//    if (string.Equals(txtconfirmpwd.Text, txtPsw.Text))
			//    {
			//        db = new AppContext();
			//        if (db.Users.AnyAsync(u => u.UserName == txtUsr.Text).Result)
			//        {
			//            txtRes.Text = "این کاربر قبلاً ثبت نام کرده است.";
			//        }
			//        else
			//        {

			//            User user = new User() { Password = txtPsw.Text, UserName = txtUsr.Text };
			//            db.Users.Add(user);
			//            await db.SaveChangesAsync();

			//            Login login = new Login();
			//            this.Close();
			//            login.ShowDialog();
			//        }
			//        db.Dispose();
			//    }
			//    else
			//    {
			//        txtRes.Text = "تایید رمز با رمز وارد شده مطابقت ندارد";
			//        e.Handled = false;
			//    }
			//}
			//else
			//{
			//    txtRes.Text = "لطفا موارد خواسته شده را وارد نمایید";
			//}


			if (!_validationRepository.IsRegisterFormValid(txtUsr.Text, txtPsw.Text, txtconfirmpwd.Text))
			{
				txtRes.Text = _validationRepository.ReturnError();
				return;
			}

			var _db = DatabaseHelper.GetInstance();
			User user = new User { Password = txtPsw.Text, UserName = txtUsr.Text };
			_db.Register(user);
			Login loginWindow = new Login();
			Close();
			loginWindow.Show();
		}
	}
}
