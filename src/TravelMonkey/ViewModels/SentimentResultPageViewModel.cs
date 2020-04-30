using System;
using System.Collections.Generic;
using System.Text;
using TravelMonkey.Services;
using Xamarin.Forms;

namespace TravelMonkey.ViewModels
{
    public class SentimentResultPageViewModel : BaseViewModel
    {
        private readonly SentimentService sentimentService = new SentimentService();

        #region Fields
        string _emojiLabelText = string.Empty;
        string _userInputEntryText = string.Empty;
        Color _backgroundColor = ColorConstants.DefaultBackgroundColor;
        #endregion

        #region Properties
        public string EmojiLabelText
        {
            get => _emojiLabelText;
            set => Set(ref _emojiLabelText, value);
        }

        public string UserInputEntryText
        {
            get => _userInputEntryText;
            set
            {
                Set(ref _userInputEntryText, value);
                //GetSentiment();
            }
        }

        public Color BackgroundColor
        {
            get => _backgroundColor;
            set => Set(ref _backgroundColor, value);
        }
        #endregion


        public Command SentimentTextCommand => new Command(() =>
        {
            GetSentiment();
        });

        private async void GetSentiment()
        {
            var client = sentimentService.authenticateClient();
            var result = await sentimentService.sentimentAnalysis(client, UserInputEntryText.ToString());

            if (result.Score == null)
                MessagingCenter.Send(this, "Oops something went wrong here. :(");

            SetEmoji(result.Score);
            SetBackgroundColor(result.Score);
        }

        void SetEmoji(double? result) 
        {
            switch (result)
            {
                case double number when (number < 0.4):
                    EmojiLabelText = EmojiConstants.SadFaceEmoji;
                    break;
                case double number when (number >= 0.4 && number <= 0.6):
                    EmojiLabelText = EmojiConstants.NeutralFaceEmoji;
                    break;
                case double number when (number > 0.6):
                    EmojiLabelText = EmojiConstants.HappyFaceEmoji;
                    break;
            }
        }

        void SetBackgroundColor(double? result)
        {
            switch (result)
            {
                case double number when (number <= 0.1):
                    BackgroundColor = ColorConstants.EmotionColor1;
                    break;
                case double number when (number > 0.1 && number <= 0.2):
                    BackgroundColor = ColorConstants.EmotionColor2;
                    break;
                case double number when (number > 0.2 && number <= 0.3):
                    BackgroundColor = ColorConstants.EmotionColor3;
                    break;
                case double number when (number > 0.3 && number <= 0.4):
                    BackgroundColor = ColorConstants.EmotionColor4;
                    break;
                case double number when (number > 0.4 && number <= 0.6):
                    BackgroundColor = ColorConstants.EmotionColor5;
                    break;
                case double number when (number > 0.6 && number <= 0.7):
                    BackgroundColor = ColorConstants.EmotionColor6;
                    break;
                case double number when (number > 0.7 && number <= 0.8):
                    BackgroundColor = ColorConstants.EmotionColor7;
                    break;
                case double number when (number > 0.8 && number <= 0.9):
                    BackgroundColor = ColorConstants.EmotionColor8;
                    break;
                case double number when (number > 0.9):
                    BackgroundColor = ColorConstants.EmotionColor9;
                    break;
            }
        }
    }
}
