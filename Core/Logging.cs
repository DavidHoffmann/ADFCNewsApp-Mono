//
//  Logging.cs
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
using System.Diagnostics;

namespace de.dhoffmann.xamarin.adfcnewsapp.core
{
	public class Logging
	{
		public enum LogType : int
		{
			Verbose = 0,
			Debug,
			Info,
			Warn,
			Error,
			Fatal
		}

		public static void Log(object sender, LogType loggingType, string logMsg)
		{
			Log(sender, loggingType, logMsg, null);
		}

		public static void Log(object sender, LogType loggingType, string logMsg, Exception ex)
		{
			#if DEBUG
			bool debug = true;
			#else
			bool debug = false;
			#endif

			string loggingMessage = "Logging type: ";

			switch (loggingType)
			{
			case LogType.Verbose:
				loggingMessage += "VERBOSE";
				break;
			case LogType.Debug:
				loggingMessage += "DEBUG";
				break;
			case LogType.Info:
				loggingMessage += "INFO";
				break;
			case LogType.Warn:
				loggingMessage += "WARN";
				break;
			case LogType.Error:
				loggingMessage += "ERROR";
				break;
			case LogType.Fatal:
				loggingMessage += "FATAL";
				break;
			}

			if (sender != null)
				loggingMessage += " - Sender: " + sender.GetType().Name;

			if (logMsg != null)
				loggingMessage += " - LogMsg: " + logMsg;

			if (ex != null)
				loggingMessage += " - EXCEPTION: " + ex.ToString();

			if (!debug && loggingType <= LogType.Debug)
				return;

			#if __ANDROID__ || __IOS__
			Debug.WriteLine(loggingMessage);
			#else
			Console.WriteLine(loggingMessage);
			#endif
		}
	}
}

