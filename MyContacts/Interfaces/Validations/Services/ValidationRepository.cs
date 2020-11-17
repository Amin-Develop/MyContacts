using System;
using MyContacts.Interfaces.Validations.Repositories;

namespace MyContacts.Interfaces.Validations.Services
{
	public class ValidationRepository : IValidationRepository
	{
		bool IValidationRepository.IsContactValid(string name, string ip, int Age)
		{
			throw new NotImplementedException();
		}

		bool IValidationRepository.IsLoginFormValid(string username, string pwd)
		{
			throw new NotImplementedException();
		}

		bool IValidationRepository.IsRegisterFormValid(string username, string pwd, string confirmpwd)
		{
			throw new NotImplementedException();
		}

		public string GetLastRegisterFormError()
		{
			throw new NotImplementedException();
		}

		public string GetLastLoginFormErrors()
		{
			throw new NotImplementedException();
		}

		public string GetLastValidationContactError()
		{
			throw new NotImplementedException();
		}
	}
}