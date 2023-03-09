using MauiBatchChatGPT.Utils;

namespace MauiBatchChatGPT.Views;

public partial class SettingView : ContentPage
{
    public SettingView()
    {
        InitializeComponent();
    }

    private void CheckApiKeyBtn_OnClicked(object sender, EventArgs e)
    {
        // Disable the button
        
        checkapi();
    }


    private async void MyAlertPassed()
    {
        await DisplayAlert("检测API key", "验证通过 passed", "确定");
    }
      private async void MyAlertFailed()
    {
        await DisplayAlert("检测API key", "验证失败 Failed", "确定");
    }

    private async void checkapi() {
        CheckApiKeyBtn.IsEnabled = false;

        bool isApiKeyValid = await CommunicateUtil.CheckApiKey(MyEntry.Text);
        if (isApiKeyValid)
        {
            MyAlertPassed();
            App.APIKEY = MyEntry.Text;
        }
        else
        {
            MyAlertFailed();
        }
        // Enable the button
        CheckApiKeyBtn.IsEnabled = true;

    }

}