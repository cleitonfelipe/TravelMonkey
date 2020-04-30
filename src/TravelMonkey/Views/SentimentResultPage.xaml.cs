using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelMonkey.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelMonkey.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SentimentResultPage : ContentPage
    {
        private readonly SentimentResultPageViewModel _sentimentResultPageViewModel =
           new SentimentResultPageViewModel();
        public SentimentResultPage()
        {
            InitializeComponent();

            //MessagingCenter.Subscribe<SentimentResultPageViewModel>(this,
            //    Constants.TranslationFailedMessage,
            //    async (s) =>
            //    {
            //        await DisplayAlert("Whoops!", "Oops something went wrong here", "OK");
            //    });

            //_sentimentResultPageViewModel.UserInputEntryText = inputText;

            BindingContext = _sentimentResultPageViewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}