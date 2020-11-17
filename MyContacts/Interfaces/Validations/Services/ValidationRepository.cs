using MyContacts.Interfaces.Validations.Repository;
using System;
using System.Collections.Generic;
using System.Text;

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

        string IValidationRepository.LoginFormErrors(string username, string pwd)
        {
            throw new NotImplementedException();
        }

        string IValidationRepository.RegisterFormErrors(string username, string pwd, string confirmpwd)
        {
            throw new NotImplementedException();
        }

        string IValidationRepository.ValidationContactError(string name, string ip, int Age)
        {
            throw new NotImplementedException();
        }
    }
}
