using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace RippleRenderer
{
	public class RippleRendererViewModel : INotifyPropertyChanged
    {
        public RippleRendererViewModel()
        {
			Button1ClickCommand = new Command(() => Button1ClickCount++);
            Button2ClickCommand = new Command(() => Button2ClickCount++);
        }

		private int _button1ClickCount = 0;
        public int Button1ClickCount
		{
			get => _button1ClickCount;
			set 
			{
				_button1ClickCount = value;
				OnPropertyChanged(); 
			}
		}

        private int _button2ClickCount = 0;
        public int Button2ClickCount
        {
            get => _button2ClickCount;
            set
            {
                _button2ClickCount = value;
                OnPropertyChanged();
            }
        }

		public Command Button1ClickCommand { get; set; }
		public Command Button2ClickCommand { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
