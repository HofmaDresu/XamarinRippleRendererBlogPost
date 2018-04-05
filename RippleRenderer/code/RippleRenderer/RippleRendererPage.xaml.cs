using Xamarin.Forms;

namespace RippleRenderer
{
    public partial class RippleRendererPage : ContentPage
    {
        public RippleRendererPage()
        {
            InitializeComponent();
			BindingContext = new RippleRendererViewModel();
        }
    }
}
