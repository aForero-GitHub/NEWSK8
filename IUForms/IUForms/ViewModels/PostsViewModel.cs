namespace IUForms.ViewModels
{
    using NEWSK8.Commont.Models;
    using NEWSK8.Commont.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class PostsViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private ObservableCollection<Posts> posts;

        public ObservableCollection<Posts> Posts 
        { 
            get { return this.posts; }
            set { this.SetValue(ref this.posts, value); } 
        }

        public PostsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadPosts();
        }

        private async void LoadPosts()
        {
            var response = await this.apiService.GetListAsync<Posts>(
                "https:",
                "/api",
                "/Posts");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            var myPosts = (List<Posts>)response.Result;
            this.Posts = new ObservableCollection<Posts>(myPosts);
        }
    }
}
