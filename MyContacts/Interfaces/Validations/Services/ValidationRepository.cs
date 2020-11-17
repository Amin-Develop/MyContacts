using System;
using System.Collections.Generic;
using System.Text;
using MyContacts.Data;
using MyContacts.Interfaces.Validations.Repositories;

namespace MyContacts.Interfaces.Validations.Services
{
	public class ValidationRepository : IValidationRepository
	{
		public static string _errorText;


        bool IValidationRepository.IsContactValid(string name, string ip, int Age)
		{
			if (string.IsNullOrEmpty(name.Trim())) return false;

			if (string.IsNullOrEmpty(ip.Trim())) return false;

			if (string.IsNullOrEmpty(Age.ToString().Trim())) return false;

			// todo: check from database

			if (Age > 99 || Age < 10) return false;

			return true;
		}
        public string ReturnError()
        {
			return _errorText;
        }

		bool IValidationRepository.IsLoginFormValid(string username, string pwd)
		{
			if (string.IsNullOrEmpty(username.Trim())) return false;

			if (string.IsNullOrEmpty(pwd.Trim())) return false;

			// todo: check from database

			return true;
		}

		bool IValidationRepository.IsRegisterFormValid(string username, string pwd, string confirmpwd)
		{
			if (string.IsNullOrEmpty(username.Trim())) return false;

			if (string.IsNullOrEmpty(pwd.Trim())) return false;

			if (string.IsNullOrEmpty(confirmpwd.Trim())) return false;

			if (!pwd.Equals(confirmpwd)) return false;

			// todo: check from database
			
			return true;
		}
	}
}