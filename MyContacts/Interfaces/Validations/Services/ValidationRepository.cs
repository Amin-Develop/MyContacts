using MyContacts.Data;
using MyContacts.Interfaces.Validations.Repositories;

namespace MyContacts.Interfaces.Validations.Services
{
	public class ValidationRepository : IValidationRepository
	{
		// error messages
		private const string NameFieldEmpty = "فیلد نام خالی است";
		private const string IpFieldEmpty = "فیلد آی پی خالی است";
		private const string AgeFieldEmpty = "فیلد سن خالی است";
		private const string UserNameFieldEmpty = "نام کاربری خالی است";
		private const string PassFieldEmpty = "رمز عبور خالی است";
		private const string ConfPassFieldEmpty = "تایید رمز عبور خالی است";
		private const string AgeNotValid = "سن وارد شده صحیح نمی باشد";
		private const string PassNoMatch = "رمز های وارد شده مطابقت ندارند";
		private const string ContactNameExist = "این نام از قبل وجود دارد";
		private const string ContactIpExist = "این آی پی از قبل وجود دارد";
		private const string UserNotExist = "این نام کاربری وجود ندارد";
		private const string UserExist = "این نام کاربری از قبل وجود دارد";
		private const string WrongLoginPass = "رمز وارد شده اشتباه است";

		private string _errorText;

		bool IValidationRepository.IsContactValid(string name, string ip, int Age)
		{
			if (string.IsNullOrEmpty(name.Trim()) || name.Equals(R.Strings.fullname_placeholder))
			{
				_errorText = NameFieldEmpty;
				return false;
			}

			if (string.IsNullOrEmpty(ip.Trim()) || ip.Equals(R.Strings.ip_placeholder))
			{
				_errorText = IpFieldEmpty;
				return false;
			}

			if (string.IsNullOrEmpty(Age.ToString().Trim()) || Age.ToString().Equals(R.Strings.age_placeholder))
			{
				_errorText = AgeFieldEmpty;
				return false;
			}

			if (Age > 99 || Age < 10)
			{
				_errorText = AgeNotValid;
				return false;
			}

			if (DatabaseHelper.GetInstance().ContactNameExist(name))
			{
				_errorText = ContactNameExist;
				return false;
			}

			if (DatabaseHelper.GetInstance().ContactIpExist(ip))
			{
				_errorText = ContactIpExist;
				return false;
			}

			return true;
		}

		bool IValidationRepository.IsLoginFormValid(string username, string pwd)
		{
			if (string.IsNullOrEmpty(username.Trim()) || username.Equals(R.Strings.username_placeholder))
			{
				_errorText = UserNameFieldEmpty;
				return false;
			}

			if (string.IsNullOrEmpty(pwd.Trim()) || pwd.Equals(R.Strings.password_placeholder))
			{
				_errorText = PassFieldEmpty;
				return false;
			}

			if (!DatabaseHelper.GetInstance().UserExist(username))
			{
				_errorText = UserNotExist;
				return false;
			}

			if (!DatabaseHelper.GetInstance().GetUserPassword(username).Equals(pwd))
			{
				_errorText = WrongLoginPass;
				return false;
			}

			return true;
		}

		bool IValidationRepository.IsRegisterFormValid(string username, string pwd, string confirmPwd)
		{
			if (string.IsNullOrEmpty(username.Trim()) || username.Equals(R.Strings.username_placeholder))
			{
				_errorText = UserNameFieldEmpty;
				return false;
			}

			if (string.IsNullOrEmpty(pwd.Trim()) || pwd.Equals(R.Strings.password_placeholder))
			{
				_errorText = PassFieldEmpty;
				return false;
			}

			if (string.IsNullOrEmpty(confirmPwd.Trim()) || confirmPwd.Equals(R.Strings.confirmpassword_placeholder))
			{
				_errorText = ConfPassFieldEmpty;
				return false;
			}

			if (!pwd.Equals(confirmPwd))
			{
				_errorText = PassNoMatch;
				return false;
			}

			if (DatabaseHelper.GetInstance().UserExist(username))
			{
				_errorText = UserExist;
				return false;
			}

			return true;
		}

		public string ReturnError()
		{
			return _errorText;
		}
	}
}