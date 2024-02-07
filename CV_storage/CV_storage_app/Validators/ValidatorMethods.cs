using System.Net.Mail;

namespace CV_storage_app.Validators
{
    public class ValidatorMethods
    {
        public static bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");

            return name.All(Char.IsLetter);
        }

        public static bool BeAValidNumber(string number)
        {
            number = number.Replace(" ", "");

            if (number.Contains('+') && number.LastIndexOf('+') > 0)
            {
                return false;
            }

            number = number.Replace("+", "");

            return number.All(Char.IsDigit);
        }

        public static bool BeAValidEmail(string email)
        {
            email = email.Trim();
            if (email.EndsWith('.') || !email.Contains('@'))
            {
                return false;
            }

            var mailAddress = new MailAddress(email);

            return email == mailAddress.Address;
        }

        public static bool BeAValidDate(DateTime date)
        {
            return DateTime.Now.Date >= date.Date;
        }
    }
}
