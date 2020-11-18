using System;
using System.Collections.Generic;
using System.Text;
using MyContacts.Data;
using MyContacts.Interfaces.Validations.Repositories;
using MyContacts.Properties;

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
			if (string.IsNullOrEmpty(name.Trim()))
			{
				_errorText = NameFieldEmpty;
				return false;
			}

			if (string.IsNullOrEmpty(ip.Trim()))
			{
				_errorText = IpFieldEmpty;
				return false;
			}

			if (string.IsNullOrEmpty(Age.ToString().Trim()))
			{
				_errorText = AgeFieldEmpty;
				return false;
			}

			if (Age > 99 || Age < 10)
			{
				_errorText = AgeNotValid;
				return false;
			}

			if (((DatabaseHelper) Singleton.GetInstance()).ContactNameExist(name))
			{
				_errorText = ContactNameExist;
				return false;
			}

			if (((DatabaseHelper) Singleton.GetInstance()).ContactIpExist(ip))
			{
				_errorText = ContactIpExist;
				return false;
			}

			return true;
		}

		bool IValidationRepository.IsLoginFormValid(string username, string pwd)
		{
			if (string.IsNullOrEmpty(username.Trim()))
			{
				_errorText = UserNameFieldEmpty;
				return false;
			}

			if (string.IsNullOrEmpty(pwd.Trim()))
			{
				_errorText = PassFieldEmpty;
				return false;
			}

			if (!((DatabaseHelper) Singleton.GetInstance()).UserExist(username))
			{
				_errorText = UserNotExist;
				return false;
			}

			if (!((DatabaseHelper) Singleton.GetInstance()).GetUserPassword(username).Equals(pwd))
			{
				_errorText = WrongLoginPass;
				return false;
			}

			return true;
		}

		bool IValidationRepository.IsRegisterFormValid(string username, string pwd, string confirmpwd)
		{
			if (string.IsNullOrEmpty(username.Trim()))
			{
				_errorText = UserNameFieldEmpty;
				return false;
			}

			if (string.IsNullOrEmpty(pwd.Trim()))
			{
				_errorText = PassFieldEmpty;
				return false;
			}

			if (string.IsNullOrEmpty(confirmpwd.Trim()))
			{
				_errorText = ConfPassFieldEmpty;
				return false;
			}

			if (!pwd.Equals(confirmpwd))
			{
				_errorText = PassNoMatch;
				return false;
			}

			if (((DatabaseHelper) Singleton.GetInstance()).UserExist(username))
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