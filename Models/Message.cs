using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBatchChatGPT.Models
{
    // Message class
    public class Message
    {
        //public string Text { get; set; }
        public HtmlWebViewSource MarkdownSource { get; set; }
        public string Timestamp { get; set; }
        public Color BackgroundColor { get; set; }
        public LayoutOptions HorizontalOptions { get; set; }
    }
}
