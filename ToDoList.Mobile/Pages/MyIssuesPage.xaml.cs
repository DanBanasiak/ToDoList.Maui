using System.Collections.ObjectModel;
using ToDoList.Mobile.Models;
using ToDoList.Mobile.Services;

namespace ToDoList.Mobile.Pages;

public partial class MyIssuesPage : ContentPage
{
    private ObservableCollection<GetIssueDto> getIssueList = new();
    public ObservableCollection<GetIssueDto> GetIssueList
    {
        get { return getIssueList; }
        set
        {
            getIssueList = value;
        }
    }


    private readonly IItemsService _itemsService = new ItemsService();
    public MyIssuesPage()
    {
        InitializeComponent();
        GetIssueList = new ObservableCollection<GetIssueDto>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Test",
                    Description = "Test",
                    IsCompleted = false,
                    UserId = "Test",
                    CreatedBy = "Test",
                    CreatedAt = DateTime.Now,
                    UpdatedBy = "Test",
                    UpdatedAt = DateTime.Now
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Test",
                    Description = "Test",
                    IsCompleted = false,
                    UserId = "Test",
                    CreatedBy = "Test",
                    CreatedAt = DateTime.Now,
                    UpdatedBy = "Test",
                    UpdatedAt = DateTime.Now
                },
            };
        //IssuesListView.ItemsSource = GetIssueList;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        List<GetIssueDto> items = new();
        Device.BeginInvokeOnMainThread(async () =>
        {
            await GetItemsAsync();
        });
    }

    private async Task GetItemsAsync()
    {
        var items = await _itemsService.GetItemsAsync();
        GetIssueList = new ObservableCollection<GetIssueDto>(items.ToList());
        IssuesListView.ItemsSource = GetIssueList;
    }

    private async void CreateIssueButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddIssuePage());
    }

    private async void IssuesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var issue = e.SelectedItem as GetIssueDto;
        if (issue != null)
        {
            await _itemsService.CompleteItemAsync(issue.Id);
        }

        await GetItemsAsync();
    }

    private async void GoToSettingsPageButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage());
    }
}