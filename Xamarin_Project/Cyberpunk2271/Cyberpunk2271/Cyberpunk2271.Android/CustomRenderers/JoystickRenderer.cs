﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Cyberpunk2271.CustomControls;
using Cyberpunk2271.Droid.JoystickAndroidCustomControl;
using Xamarin.Forms;
using Cyberpunk2271.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(JoystickControl), typeof(JoystickRenderer))]

namespace Cyberpunk2271.Droid.CustomRenderers
{
    class JoystickRenderer : ViewRenderer<JoystickControl, JoystickMainLayout>
    {
        private JoystickMainLayout _JoystickMainLayout;

        public JoystickRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<JoystickControl> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                // Instantiate the native control and assign it to the Control property with
                // the SetNativeControl method
                _JoystickMainLayout = new JoystickMainLayout(Context);
                SetNativeControl(_JoystickMainLayout);
            }

            if (e.OldElement != null)
            {
                // Unsubscribe from event handlers and cleanup any resources
                _JoystickMainLayout.RemoveTouchListener();
            }

            if (e.NewElement != null)
            {
                // Configure the control and subscribe to event handlers
                _JoystickMainLayout.AddTouchListener((xposition, yposition, distance, angle) =>
                {
                    Element.Xposition = xposition;
                    Element.Yposition = yposition;
                    Element.Distance = (int)distance;
                    Element.Angle = (int)angle;
                });
            }
        }
    }
}