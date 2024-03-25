namespace ToDoList.Mobile.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }


    private async void ConfirmBtn_Clicked(object sender, EventArgs e)
    {
        Preferences.Set("FirstName", "Dan");

        await Navigation.PushAsync(new MyIssuesPage());
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



        //System.Text.StringBuilder sb = new System.Text.StringBuilder();

        //sb.AppendLine($"Pixel width: {DeviceDisplay.Current.MainDisplayInfo.Width} / Pixel Height: {DeviceDisplay.Current.MainDisplayInfo.Height}");
        //sb.AppendLine($"Density: {DeviceDisplay.Current.MainDisplayInfo.Density}");
        //sb.AppendLine($"Orientation: {DeviceDisplay.Current.MainDisplayInfo.Orientation}");
        //sb.AppendLine($"Rotation: {DeviceDisplay.Current.MainDisplayInfo.Rotation}");
        //sb.AppendLine($"Refresh Rate: {DeviceDisplay.Current.MainDisplayInfo.RefreshRate}");
        //var temp = sb.ToString();


        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.AppendLine($"Model: {DeviceInfo.Current.Model}");
        sb.AppendLine($"Manufacturer: {DeviceInfo.Current.Manufacturer}");
        sb.AppendLine($"Name: {DeviceInfo.Current.Name}");
        sb.AppendLine($"OS Version: {DeviceInfo.Current.VersionString}");
        sb.AppendLine($"Idiom: {DeviceInfo.Current.Idiom}");
        sb.AppendLine($"Platform: {DeviceInfo.Current.Platform}");

        bool isVirtual = DeviceInfo.Current.DeviceType switch
        {
            DeviceType.Physical => false,
            DeviceType.Virtual => true,
            _ => false
        };

        sb.AppendLine($"Virtual device? {isVirtual}");
        //// Set a string value:
        //Preferences.Default.Set("first_name", "John");

        //// Set an numerical value:
        //Preferences.Default.Set("age", 28);

        //// Set a boolean value:
        //Preferences.Default.Set("has_pets", true);

        string firstName = Preferences.Default.Get("first_name", "Unknown");
        int age = Preferences.Default.Get("age", -1);
        bool hasPets = Preferences.Default.Get("has_pets", false);


        var temp = sb.ToString();
        //DisplayDeviceLabel.Text = sb.ToString();

        //DisplayDetailsLabel.Text = sb.ToString();
        await Navigation.PushAsync(new LoginPage());
    }
}