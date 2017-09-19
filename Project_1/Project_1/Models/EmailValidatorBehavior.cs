using Xamarin.Forms;
using System.Text.RegularExpressions;

namespace Project_1.Models
{
    class EmailValidatorBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += BindableObjectChanged; //Event Subscriber
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
        }

        private void BindableObjectChanged(object sender, TextChangedEventArgs e)
        {
            var email = e.NewTextValue;
            var emailEntry = sender as Entry;

            const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

            if(Regex.IsMatch(email, emailRegex))
            {
                emailEntry.TextColor = Color.Green;
            }
            else
            {
                emailEntry.TextColor = Color.Red;
            }
        }

    }
}
