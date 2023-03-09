using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiBatchChatGPT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiBatchChatGPT.ViewModels
{
    class HomeViewModel : ObservableObject
    {
        public HomeViewModel() {
            Messages = new ObservableCollection<Message>();
            SendMessageCommand = new RelayCommand(SendMessage);
            RetryCommand = new RelayCommand(Retry);
            for (int i = 0; i < 3; i++) {
                Message message = new Message();
                message.Text = "1231231123333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333333";
                message.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                message.BackgroundColor = Color.FromHex("#FFFFFF");
                message.HorizontalOptions = LayoutOptions.Start;
                messages.Add(message);
            }
        }  

        //public ICommand SendCommand { get; private set; }
		private bool isChatVisible=true;

		public bool IsChatVisible
        {
			get { return isChatVisible; }
            set { SetProperty(ref isChatVisible, value); }
        }
        private ObservableCollection<Message> messages;
        private string message;

        public ObservableCollection<Message> Messages
        {
            get { return messages; }
            set { SetProperty(ref messages, value); }
        }

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        public ICommand SendMessageCommand { get; }
        public ICommand RetryCommand { get; }


        private async void SendMessage()
        {
            Message message = new Message();
            message.Text = UserInputText;
            message.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            message.BackgroundColor = Color.FromHex("#FFFFFF");
            message.HorizontalOptions = LayoutOptions.Start;
            messages.Add(message);
            Console.WriteLine(UserInputText.ToString());
            UserInputText = "";
            
        }

        private void Retry()
        {
            // Implement retry logic
        }

        private String userInputText;

        public String UserInputText
        {
            get { return userInputText; }
            set { SetProperty(ref userInputText, value); }
        }

    }
}
