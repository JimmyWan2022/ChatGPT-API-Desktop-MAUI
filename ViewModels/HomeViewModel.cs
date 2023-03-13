using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiBatchChatGPT.Models;
using MauiBatchChatGPT.Utils;
using Newtonsoft.Json;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using OpenAI_API.Completions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OpenAI_API;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Maui.Controls;
using Markdig;

namespace MauiBatchChatGPT.ViewModels
{
    class HomeViewModel : ObservableObject
    {

   
        private String homeViewSource;

        public String HomeViewSource    
        {
            get { return homeViewSource; }
            set { SetProperty(ref homeViewSource, value); }
        }


        public HomeViewModel() {
            Messages = new ObservableCollection<Message>();
            SendMessageCommand = new RelayCommand(SendMessage);


           
            
        }  

        //public ICommand SendCommand { get; private set; }
		private bool isChatVisible=true;

		public bool IsChatVisible
        {
			get { return isChatVisible; }
            set { SetProperty(ref isChatVisible, value); }
        }

        private ObservableCollection<Message> messages;
      

        public ObservableCollection<Message> Messages
        {
            get { return messages; }
            set { SetProperty(ref messages, value); }
        }
      

        public ICommand SendMessageCommand { get; }
        public ICommand RetryCommand { get; }
        

        private async void SendMessage()
        {
            if (!App.apiKeyIsChecked)
            {

                //HtmlWebViewSource htmlSource = new HtmlWebViewSource();
                //htmlSource.Html = Markdown.ToHtml("Api Key 无效，请设置Api Key");
                //Message message = new Message();
                //message.MarkdownSource = htmlSource;
                //message.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                //message.BackgroundColor = Color.FromHex("#FFFFFF");
                //message.HorizontalOptions = LayoutOptions.Start;
                //messages.Add(message);
                HtmlWebViewSource htmlSource = new HtmlWebViewSource();
                htmlSource.Html = Markdown.ToHtml("This is a text with some *emphasis*");
                Message message = new Message();
                message.MarkdownSource = htmlSource;
                message.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                message.BackgroundColor = Color.FromHex("#FFFFFF");
                message.HorizontalOptions = LayoutOptions.Start;
                messages.Add(message);

            }
            else {
                if (!(string.IsNullOrEmpty(UserInputText) || UserInputText.Length < 2 || UserInputText.Equals("Paste or write here")))
                {
                    Message message = new Message();
                    //message.Text = UserInputText;
                    message.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    message.BackgroundColor = Color.FromHex("#FFFFFF");
                    message.HorizontalOptions = LayoutOptions.Start;
                    messages.Add(message);
                    Console.WriteLine(UserInputText.ToString());
                    UserInputText = "";

                    //var response = await CommunicateUtil.GetResponse(UserInputText, App.APIKEY);
                    //if (response == null)
                    //    return;
                    //string messageContent="";
                    //// Parse JSON response
                    //try
                    //{
                    //    dynamic jsonResponse = JsonConvert.DeserializeObject(response);
                    //    if (checkResponse(jsonResponse))
                    //    {
                    //         messageContent = jsonResponse.choices[0].message.content;
                    //        //resultbox.Text = messageContent;
                    //    }
                    //}
                    //catch (JsonException ex)
                    //{
                    //    string errorMessage = "Failed to parse JSON response: " + ex.Message;
                    //    //MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                    Message receiveMessage = new Message();
                    //if (!String.IsNullOrEmpty(messageContent))
                    //{
                    //    receiveMessage.Text = messageContent;
                    //}
                    //else {
                    //    receiveMessage.Text = "Failed to parse JSON response: "+ messageContent;
                    //}

                    receiveMessage.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    receiveMessage.BackgroundColor = Color.FromHex("#FFFFFF");
                    receiveMessage.HorizontalOptions = LayoutOptions.Start;
                    //messages.Add(receiveMessage);
                    //var lastMessage =messages.Last();
                    OpenAIAPI api = new OpenAIAPI(App.APIKEY);
                    // for example
                    //await api.Completions.StreamCompletionAsync(
                    //    new CompletionRequest("My name is Roger and I am a principal software engineer at Salesforce.  This is my resume:", Model.DavinciText, 200, 0.5, presencePenalty: 0.1, frequencyPenalty: 0.1),
                    //    res => receiveMessage.Text += res.ToString());

                    messages.Add(receiveMessage);
                }
                bool checkResponse(dynamic response)
                {
                    if (response.choices == null || response.choices.Count == 0)
                    {
                        string errorMessage = "API response did not contain any choices.";
                        //MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // Check if the first choice contains a message
                    if (response.choices[0].message == null || response.choices[0].message.content == null)
                    {
                        string errorMessage = "API response did not contain a valid message.";
                        //MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    return true;
                }
            }
         


        }

        private String userInputText;

        public String UserInputText
        {
            get { return userInputText; }
            set { SetProperty(ref userInputText, value); }
        }

    }
}
