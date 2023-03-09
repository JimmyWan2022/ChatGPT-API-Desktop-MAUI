using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiBatchChatGPT.Utils;

namespace MauiBatchChatGPT.ViewModels
{
    class SettingViewModel : ObservableObject
    {
       public SettingViewModel() {
            CheckApiKeyCommand = new AsyncRelayCommand(CheckApiKeyAsync);
        }

		private String apiKey;

		public String ApiKey
		{
			get { return apiKey; }
            set { SetProperty(ref apiKey, value); 
            Console.WriteLine(apiKey);
            }
        }
		private String checkResultData;

		public String CheckResultData
        {
			get { return checkResultData; }
            set { SetProperty(ref checkResultData, value); }
        }
        //CheckApiKeyCommand
        public AsyncRelayCommand CheckApiKeyCommand { get; }
        //private readonly AsyncCommand _checkApiKeyCommand;
        private async Task CheckApiKeyAsync()
        {
            //checkResultData = "";
            Console.WriteLine("CheckApiKeyAsync");
            //Boolean result = CommunicateUtil.CheckApiKey(ApiKey);
         
            bool isApiKeyValid = await CommunicateUtil.CheckApiKey(ApiKey);
            Console.WriteLine($"Is API key valid? {isApiKeyValid}");
            if (isApiKeyValid)
            {
                checkResultData = "api key passed 验证通过";
                Console.WriteLine("api key passed 验证通过");
      
            }
            else {
                checkResultData = "api key pass failed 验证失败";
                Console.WriteLine("api key passed 验证失败");
            }

        }


     

    }
}
