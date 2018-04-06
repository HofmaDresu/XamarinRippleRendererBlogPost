﻿using RippleRenderer;
using RippleRenderer.iOS;
using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(IncrementingButton), typeof(IncrementingButtonRenderer_iOS))]
namespace RippleRenderer.iOS
{
    class IncrementingButtonRenderer_iOS : ViewRenderer<IncrementingButton, UIView>
    {
        private UILabel _buttonTitleLabel;
        private UILabel _clickCountLabel;

        protected override void OnElementChanged(ElementChangedEventArgs<IncrementingButton> e)
        {
            base.OnElementChanged(e);

            var rootView = CreateLayout();

            // Tell Xamarin to user our layout for the control
            SetNativeControl(rootView);
        }

        private UIButton CreateLayout()
        {
            var rootView = new UIButton
            {
                BackgroundColor = Element.BackgroundColor.ToUIColor(),                
                UserInteractionEnabled = true,
            };

            // Create button title label
            _buttonTitleLabel = new UILabel
            {
                Text = Element.Title,
                TextColor = UIColor.White,
                TranslatesAutoresizingMaskIntoConstraints = false,
            };
            rootView.AddSubview(_buttonTitleLabel);
            _buttonTitleLabel.TopAnchor.ConstraintEqualTo(rootView.TopAnchor).Active = true;
            _buttonTitleLabel.LeftAnchor.ConstraintEqualTo(rootView.LeftAnchor).Active = true;

            // Create Click Count label
            _clickCountLabel = new UILabel
            {
                Text = $"Clicked {Element.ClickCount} times",
                TextColor = UIColor.White,
                TranslatesAutoresizingMaskIntoConstraints = false,
            };
            rootView.AddSubview(_clickCountLabel);
            _clickCountLabel.TopAnchor.ConstraintEqualTo(_buttonTitleLabel.BottomAnchor).Active = true;
            _clickCountLabel.LeftAnchor.ConstraintEqualTo(rootView.LeftAnchor).Active = true;
            _clickCountLabel.BottomAnchor.ConstraintEqualTo(rootView.BottomAnchor).Active = true;

            return rootView;
        }
    }
}
