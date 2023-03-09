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
        await DisplayAlert("���API key", "��֤ͨ�� passed", "ȷ��");
    }
      private async void MyAlertFailed()
    {
        await DisplayAlert("���API key", "��֤ʧ�� Failed", "ȷ��");
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