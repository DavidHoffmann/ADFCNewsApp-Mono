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
using de.dhoffmann.xamarin.adfcnewsapp.android.Base;

namespace de.dhoffmann.xamarin.adfcnewsapp.android.Activities
{
	[Activity (Label = "@string/app_name", Theme = "@style/Theme.Appadfc")]
	public class NewsActivity : BaseActionBarActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SupportRequestWindowFeature(WindowCompat.FeatureActionBar);

			ActionBar.SetHomeButtonEnabled (false);

			Logging.Log (this, Logging.LogType.Debug, "OnCreate");

			SetContentView (Resource.Layout.NewsMain);
		}
	}
}

