using Xamarin.Forms;

namespace RippleRenderer
{
	public class IncrementingButton : View
    {
		public static readonly BindableProperty TitleProperty = 
			BindableProperty.Create("Title", typeof(string), typeof(IncrementingButton), string.Empty);
		public string Title
        {
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
        }
        
        public static readonly BindableProperty ClickCountProperty =
            BindableProperty.Create("ClickCount", typeof(int), typeof(IncrementingButton), 0);
		public int ClickCount
        {
			get { return (int)GetValue(ClickCountProperty); }
			set { SetValue(ClickCountProperty, value); }
        }

        public Command Command
        {
			get => (Command)GetValue(CommandProperty);
			set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty CommandProperty =
			BindableProperty.Create("Command", typeof(Command), typeof(IncrementingButton), null);
    }
}
