using System;
using Android.Content;
using Xamarin.Forms.Platform.Android;

namespace RippleRenderer.Droid
{
	public class IncrementingButtonRenderer_Android : ViewRenderer<IncrementingButton, Android.Views.View>
    {
		private readonly Context _context;

		protected IncrementingButtonRenderer_Android(Context context) : base(context)
		{
			_context = context;
		}

		protected override void OnElementChanged(ElementChangedEventArgs<IncrementingButton> e)
		{
			base.OnElementChanged(e);
		}
	}
}
