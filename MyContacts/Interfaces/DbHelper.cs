using MyContacts.Data;

namespace MyContacts.Interfaces
{
    public abstract class DbHelper : Singleton
    {
        protected Database _database;

        protected DbHelper()
        {
            _database = (Database)GetInstance();
        }

        // put your methods here (must be public abstract)
        // GetUser()
        // SaveUser(User user)
        // ...


        //check are register forms inputs valid
        public abstract bool RegisterFormValidation(string username, string pwd, string confirmpwd);

        //return register form inputs errors where RegisterFormValidation() returned false 
        public abstract string RegisterFormErrors(string username, string pwd, string confirmpwd);


        //check are login forms inputs valid
        public abstract bool LoginFormValidation(string username, string pwd, string confirmpwd);

        //return login form inputs errors where LoginFormValidation() returned false 
        public abstract string LoginFormErrors(string username, string pwd, string confirmpwd);

        //if all things were valid the ShowContacts form must Show()
        public abstract void Login();

        //if all thing was valid the Login form must Show() after the user inserted
        public abstract void Register();

        //check are newcontact forms inputs valid
        public abstract bool IsValidContact(string name, string ip, int Age);

        //return login form inputs errors where LoginFormValidation() returned false 
        public abstract string ValidationContactError(string name, string ip, int Age);

        //if all things were valid the Contacts form must Show() after the contact inserted
        public abstract void InsertContact(string name, string ip, int Age);

    }
}