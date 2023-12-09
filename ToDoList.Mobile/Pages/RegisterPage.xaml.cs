namespace ToDoList.Mobile.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }


    private async void ConfirmBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private void EmailEntry_Unfocused(object sender, FocusEventArgs e)
    {
        string emailValidator = string.Empty;
        if (EmailEntry.Text != null)
        {
            if (EmailEntry.Text.Length < 3)
            {
                emailValidator = emailValidator + "Email musi miec wiecej niz 3 znaki. ";
            }
            if (EmailEntry.Text.Contains("@") == false)
            {
                emailValidator = emailValidator + "Email musi zawierac znak malpy @.";
            }
        }
        EmailLabel.Text = emailValidator;
    }

    private void PasswordEntry_Unfocused(object sender, FocusEventArgs e)
    {
        string passwordValidator = string.Empty;
        if (PasswordEntry.Text != null && ConfirmPasswordEntry.Text != null)
        {
            if (ConfirmPasswordEntry.Text.Length > 0)
            {
                if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
                {
                    passwordValidator = passwordValidator + "Hasla nie sa takie same.";
                }
            }
        }
        PasswordLabel.Text = passwordValidator;
    }

    private void ConfirmPasswordEntry_Unfocused(object sender, FocusEventArgs e)
    {
        string passwordValidator = string.Empty;
        if (PasswordEntry.Text != null && ConfirmPasswordEntry.Text != null)
        {
            if (PasswordEntry.Text.Length > 0)
            {
                if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
                {
                    passwordValidator = passwordValidator + "Hasla nie sa takie same.";
                }
            }
        }
        PasswordLabel.Text = passwordValidator;
    }

    private async void LoginNavBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}