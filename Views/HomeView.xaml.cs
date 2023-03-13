using Markdig;
using MauiBatchChatGPT.Models;
using MauiBatchChatGPT.ViewModels;
using Microsoft.Maui.Controls.Internals;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MauiBatchChatGPT.Views;

public partial class HomeView : ContentPage
{
    HomeViewModel homeViewModel;
    public HomeView()
	{
		InitializeComponent();
        homeViewModel = new HomeViewModel();
        this.BindingContext = homeViewModel;
        //ChatCollectionView.SizeChanged += ChatCollectionView_SizeChanged;
       
      
    }


    private void Button_Clicked(object sender, EventArgs e)
    {
        //HtmlWebViewSource htmlSource = new HtmlWebViewSource();
        //htmlSource.Html = Markdown.ToHtml("This is a text with some *emphasis*");
        //Message message = new Message();
        //message.MarkdownSource = htmlSource;
        //message.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //message.BackgroundColor = Color.FromHex("#FFFFFF");
        //message.HorizontalOptions = LayoutOptions.Start;
        //homeViewModel.Messages.Add(message);


    }
    //private void ChatCollectionView_SizeChanged(object sender, EventArgs e)
    //{
    //    Console.WriteLine("123");
    //    //Device.BeginInvokeOnMainThread(() =>
    //    //{
    //    //    ChatCollectionView.ScrollToAsync(ChatCollectionView.ItemsSource[items.Count - 1], ScrollToPosition.End, false);
    //    //});
    //    var listMessage = homeViewModel.Messages;

    //    ChatCollectionView.ScrollTo(0, position: ScrollToPosition.Center, animate: true);
    //    _scrollTimer = new Timer(SCROLL_INTERVAL);
    //    _scrollTimer.Elapsed += ScrollTimer_Elapsed;
    //    _scrollTimer.AutoReset = true;
    //    _scrollTimer.Enabled = true;
    //}



}