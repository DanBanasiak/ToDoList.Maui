namespace ToDoList.Mobile
{
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
        }
        private async void ConfirmBtn_Clicked(object sender, EventArgs e)
        {
            string validator = string.Empty;

            var isEmailCorrect = emailEntry.Text?.Contains("@");
            if (isEmailCorrect == false)
            {
                validator = "Email musi zawierac znak malpy @\n";
            }

            if (passwordEntry.Text != confirmPasswordEntry.Text)
            {
                // to jest komentarz ;)
                // validator = validator + "Hasla nie sa takie same\n";

                validator += "Hasla nie sa takie same\n";
            }

            ErrorsLabel.Text = validator;
            await Navigation.PushAsync(new MainPage());
        }
    }
}