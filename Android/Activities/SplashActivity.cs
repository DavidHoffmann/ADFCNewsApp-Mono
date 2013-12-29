//
//  Splash.cs
//
//  Author:
//       David Hoffmann <david@hoffmann-projects.de>
//
//  Copyright (c) 2013 David Hoffmann
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
//
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
using de.dhoffmann.xamarin.adfcnewsapp.core;
using System.Threading.Tasks;

namespace de.dhoffmann.xamarin.adfcnewsapp.android.Activities
{
	[Activity (Label = "@string/app_name", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash")]			
	public class SplashActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			Logging.Log (this, Logging.LogType.Debug, "OnCreate");

			AppInit appInit = new AppInit();
			appInit.AppStartAsync ().ContinueWith (t => {
				Logging.Log (this, Logging.LogType.Debug, "OnCreate(): Start activity NewsActivity");

				// redirect to NewsActivity
				StartActivity(typeof(NewsActivity));
			}, TaskScheduler.FromCurrentSynchronizationContext ());
		}
	}
}

