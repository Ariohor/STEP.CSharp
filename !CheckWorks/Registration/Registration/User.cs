using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork
{
    public class User
    {
        string _city;
        string _password;
        string _email;
        string _phoneNumber;
        int _age;

        public string GetPassword()
        {
            return _password;
        }
        public bool SetPassword(string password)
        {
            if (!string.IsNullOrWhiteSpace(password))
            {
                bool IsDigit = false;
                bool IsSymbol = false;
                bool IsUpper = false;
                bool IsLower = false;

                if (!string.IsNullOrWhiteSpace(password) && !password.Contains(" "))
                {
                    foreach (var simbol in password)
                    {
                        if (IsDigit && IsSymbol && IsUpper && IsLower)
                        {
                            _password = password;
                            return true;
                        }

                        if (char.IsDigit(simbol))
                        {
                            IsDigit = true;
                        }

                        if (char.IsPunctuation(simbol)|| char.IsSeparator(simbol))
                        {
                            IsSymbol = true;
                        }

                        if (char.IsUpper(simbol))
                        {
                            IsUpper = true;
                        }

                        if (char.IsLower(simbol))
                        {
                            IsLower = true;
                        }
                    }
                }
            }
            return false;
        }

        public string GetEmail()
        {
            return _email;
        }
        public bool SetEmail(string email)
        {
            email.Trim();
            if (!string.IsNullOrEmpty(email) && email.Contains(Constants.EMAIL_SIGN) && email.Contains(Constants.DOT))
            {
                if (email.Length - email.LastIndexOf(Constants.DOT) >= Constants.MIN_COUNT_LETTERS_AFTER_LAST_DOT
                 && email.Length - email.LastIndexOf(Constants.DOT) <= Constants.MAX_COUNT_LETTERS_AFTER_LAST_DOT)
                {
                    if (email.LastIndexOf(Constants.DOT) - email.IndexOf(Constants.EMAIL_SIGN) >= Constants.MIN_COUNT_LETTERS_BETWEEN_EMAIL_SIGN_LAST_DOT)
                    {
                        _email = email;
                        return true;
                    }
                }
            }
            return false;
        }
        public string GetPhoneNumber()
        {
            return _phoneNumber;
        }
        public bool SetPhoneNumber(string phoneNumber)
        {
            phoneNumber.Trim();
            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                if (phoneNumber.Length >= Constants.MIN_SIZE_PHONE_NUMBER && phoneNumber.Length <= Constants.MAX_SIZE_PHONE_NUMBER)
                {
                    bool isNumber = true;
                    foreach (var symbol in phoneNumber)
                    {
                        if (!char.IsDigit(symbol))
                        {
                            isNumber = false;
                        }
                    }
                    if (isNumber)
                    {
                        _phoneNumber = phoneNumber;
                        return true;
                    }
                }
            }
            return false;
        }

        public string GetCity()
        {
            return _city;
        }
        public bool SetCity(string city)
        {
            if (!string.IsNullOrWhiteSpace(city))
            {
                _city = city;
                return true;
            }
            return false;
        }

        public int GetAge()
        {
            return _age;
        }
        public bool SetAge(string age)
        {
            age.Trim();
            if (!string.IsNullOrWhiteSpace(age))
            {

                bool isNumber = true;
                foreach (var symbol in age)
                {
                    if (!char.IsDigit(symbol))
                    {
                        isNumber = false;
                    }
                }
                if (isNumber)
                {
                    var number = int.Parse(age);
                    if (number > 0 && number <= 120)
                    {
                        _age = number;
                        return true;
                    }
                }

            }
            return false;
        }
    }
}
