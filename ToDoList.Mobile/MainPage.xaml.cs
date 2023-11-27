namespace ToDoList.Mobile
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            //if (count == 1)
            //    //CounterBtn.Text = $"Clicked {count} time";
            //else
            //    //CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void ConfirmBtn_Clicked(object sender, EventArgs e)
        {
            string validator = string.Empty;

            var isEmailCorrect = emailEntry.Text.Contains("@");
            if(isEmailCorrect == false)
            {
                validator = "Email musi zawierac znak malpy @\n";
            }

            if(passwordEntry.Text != confirmPasswordEntry.Text)
            {
                // to jest komentarz ;)
                // validator = validator + "Hasla nie sa takie same\n";
                
                validator += "Hasla nie sa takie same\n";
            }

            ErrorsLabel.Text = validator;

        }


        private void passwordEntry_Unfocused(object sender, FocusEventArgs e)
        {

        }

        private void emailEntry_Focused(object sender, FocusEventArgs e)
        {

        }

        private void emailEntry_Unfocused(object sender, FocusEventArgs e)
        {
        }
    }
}