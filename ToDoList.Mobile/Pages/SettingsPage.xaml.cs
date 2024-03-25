namespace ToDoList.Mobile.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();


        var manufacturer = DeviceInfo.Current.Manufacturer;
        var name = DeviceInfo.Current.Name;
        var version = DeviceInfo.Current.Version;
        var deviceType = DeviceInfo.Current.DeviceType;
        var platform = DeviceInfo.Current.Platform;
        var idiom = DeviceInfo.Current.Idiom;

        var temporary = Preferences.Get("FirstName", "Unknown");

        DarkModeView.IsToggled = Preferences.Get("DarkMode", false);
    }

    private void DarkModeView_PropertyChanged(
        object sender, 
        System.ComponentModel.PropertyChangedEventArgs e)
    {
        var temp = (Switch)sender;

        if (e.PropertyName == "IsToggled")
        {
            var currentStateOfSwitch = DarkModeView.IsToggled;
            Preferences.Set("DarkMode", currentStateOfSwitch);
        }
    }
}