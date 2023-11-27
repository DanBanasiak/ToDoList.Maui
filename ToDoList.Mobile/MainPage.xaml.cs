using System.Collections.ObjectModel;
using ToDoList.Mobile.Models;
using ToDoList.Mobile.Services;

namespace ToDoList.Mobile
{
    public partial class MainPage : ContentPage
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
        public MainPage()
        {
            InitializeComponent();
            GetIssueList = new ObservableCollection<GetIssueDto>()
            {
                new GetIssueDto()
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
                new GetIssueDto()
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
            IssuesListView.ItemsSource = GetIssueList;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            List<GetIssueDto> items = new();
            Device.BeginInvokeOnMainThread(async () =>
            {
                items = await _itemsService.GetItemsAsync();
                GetIssueList = new ObservableCollection<GetIssueDto>(items.ToList());
                IssuesListView.ItemsSource = GetIssueList;
            });
        }
    }
}