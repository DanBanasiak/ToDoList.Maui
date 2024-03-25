using ToDoList.Mobile.Models;
using ToDoList.Mobile.Services;

namespace ToDoList.Mobile.Pages;

public partial class AddIssuePage : ContentPage
{
    private bool isValidate;
    private bool isTitleValidate;
    private bool isDescriptionValidate;

    private readonly IItemsService _itemsService = new ItemsService();
    public AddIssuePage()
	{
		InitializeComponent();
        isValidate = false;
        isTitleValidate = false;
        isDescriptionValidate = false;
	}

    private async void ConfirmBtn_Clicked(object sender, EventArgs e)
    {
        var dto = new CreateIssueDto
        {
            Title = TitleEntry?.Text,
            Description = DescriptionEntry?.Text
        };

        var id = await _itemsService.CreateItemAsync(dto);

        await Navigation.PushAsync(new MyIssuesPage());
    }

    private void DescriptionEntry_Unfocused(object sender, FocusEventArgs e)
    {
        
    }

    private void TitleEntry_Unfocused(object sender, FocusEventArgs e)
    {
    }

    private void TitleEntry_TextChanged(object sender, TextChangedEventArgs e)
    { 
        if (TitleEntry?.Text?.Length < 3)
        {
            TitleLabel.Text = "Title must be at least 3 characters long";
            isTitleValidate = false;
        }
        else
        {
            TitleLabel.Text = "";
            isTitleValidate = true;
        }

        isValidate = isTitleValidate && isDescriptionValidate;
        ConfirmBtn.IsEnabled = isValidate;
    }

    private void DescriptionEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        //to zamo znaczy if(DescriptionEntry !=null & & DescriptionEntry.Text != null)
        //co:
        //if(DescriptionEntry?.Text?...)

        if (DescriptionEntry?.Text?.Length < 3)
        {
            DescriptionLabel.Text = "Description must be at least 3 characters long";
            isDescriptionValidate = false;
        }
        else
        {
            DescriptionLabel.Text = "";
            isDescriptionValidate = true;
        }

        isValidate = isTitleValidate && isDescriptionValidate;
        ConfirmBtn.IsEnabled = isValidate;
    }
}