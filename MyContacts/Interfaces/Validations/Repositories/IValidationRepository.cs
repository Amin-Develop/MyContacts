namespace MyContacts.Interfaces.Validations.Repositories
{
    interface IValidationRepository
    {

        //check are register forms inputs valid (not empty , not exist same user , cofirm pwd is match)
        public bool IsRegisterFormValid(string username, string pwd, string confirmpwd);

        //return register form inputs errors where RegisterFormValidation() returned false 
        public string RegisterFormErrors(string username, string pwd, string confirmpwd);


        //check are login forms inputs valid (not empty , exist same user)
        public bool IsLoginFormValid(string username, string pwd);

        //return login form inputs errors where LoginFormValidation() returned false 
        public string LoginFormErrors(string username, string pwd);

        //check are new contact forms inputs valid
        public bool IsContactValid(string name, string ip, int Age);

        //return login form inputs errors where LoginFormValidation() returned false 
        public string ValidationContactError(string name, string ip, int Age);


        //example for validation :
        //!string.IsNullOrWhiteSpace(txtPsw.Text) && !string.Equals(txtPsw, "کلمه ی عبور") && !string.Equals(txtUsr.Text, "نام کاربری") && !string.IsNullOrWhiteSpace(txtUsr.Text)
    }
}
