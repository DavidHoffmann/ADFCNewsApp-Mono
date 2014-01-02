//
//  BaseActionBarActivity.cs
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
using Google.Analytics.Tracking;
using Android.Support.V7.App;

namespace de.dhoffmann.xamarin.adfcnewsapp.android.Base
{
	[Activity]			
	public class BaseActionBarActivity : ActionBarActivity
	{
		protected override void OnStart ()
		{
			base.OnStart ();

			#if !DEBUG
			// Start Google Analytics Easy Tracker
			EasyTracker.GetInstance (this).ActivityStart (this);
			#endif
		}


		protected override void OnStop ()
		{
			base.OnStop ();

			#if !DEBUG
			// Stop Google Analytics Easy Tracker
			EasyTracker.GetInstance (this).ActivityStop (this);
			#endif
		}
	}
}

