using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V4.View;
using de.dhoffmann.xamarin.adfcnewsapp.core;
using Google.Analytics.Tracking;

namespace de.dhoffmann.xamarin.adfcnewsapp.android.Activities
{
	[Activity (Label = "NewsActivity", Theme = "@style/Theme.AppCompat")]			
	public class NewsActivity : ActionBarActivity
	{
		protected override void OnStart ()
		{
			base.OnStart ();

			// Start Google Analytics Easy Tracker
			EasyTracker.GetInstance (this).ActivityStart (this);
		}


		protected override void OnStop ()
		{
			base.OnStop ();

			// Stop Google Analytics Easy Tracker
			EasyTracker.GetInstance (this).ActivityStop (this);
		}


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SupportRequestWindowFeature(WindowCompat.FeatureActionBar);

			Logging.Log (this, Logging.LogType.Debug, "OnCreate");
		}
	}
}

