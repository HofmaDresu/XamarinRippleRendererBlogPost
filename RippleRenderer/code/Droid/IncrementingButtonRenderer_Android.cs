using System.ComponentModel;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using RippleRenderer;
using RippleRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IncrementingButton), typeof(IncrementingButtonRenderer_Android))]
namespace RippleRenderer.Droid
{
	public class IncrementingButtonRenderer_Android : ViewRenderer<IncrementingButton, Android.Views.View>
    {
		private readonly Context _context;

		public IncrementingButtonRenderer_Android(Context context) : base(context)
		{
			_context = context;
		}

        private TextView _buttonTitleView;
        private TextView _clickCountView;

        protected override void OnElementChanged(ElementChangedEventArgs<IncrementingButton> e)
		{
			base.OnElementChanged(e);

            if (Control == null)
            {
                // Inflate the IncrementingButton layout
                var inflater = _context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                var rootLayout = inflater.Inflate(Resource.Layout.IncrementingButton, null, false);

                // Set text on Textviews
                _buttonTitleView = rootLayout.FindViewById<TextView>(Resource.Id.ButtonTitle);
                _buttonTitleView.Text = Element.Title;
                _clickCountView = rootLayout.FindViewById<TextView>(Resource.Id.ClickCount);
                _clickCountView.Text = $"Clicked {Element.ClickCount} times";

                SetBackground(rootLayout);

                // Tell Xamarin to user our layout for the control
                SetNativeControl(rootLayout);

                // Execute the bound command on click
                rootLayout.Click += (s, a) => Element.Command?.Execute(null);
            }
        }

        private void SetBackground(Android.Views.View rootLayout)
        {
            // Get the background color from Forms element
            var backgroundColor = Element.BackgroundColor.ToAndroid();

            // Create statelist to handle ripple effect
            var enabledBackground = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new int[] { backgroundColor, backgroundColor });
            var stateList = new StateListDrawable();
            var rippleItem = new RippleDrawable(ColorStateList.ValueOf(Android.Graphics.Color.White),
                                                enabledBackground,
                                                null);
            stateList.AddState(new[] { Android.Resource.Attribute.StateEnabled }, rippleItem);

            // Assign background
            rootLayout.Background = stateList;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == IncrementingButton.ClickCountProperty.PropertyName)
            {
                _clickCountView.Text = $"Clicked {Element.ClickCount} times";
            }
        }
    }
}
