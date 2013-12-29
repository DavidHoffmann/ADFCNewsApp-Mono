//
//  TestLogging.cs
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
using NUnit.Framework;
using de.dhoffmann.xamarin.adfcnewsapp.core;

namespace de.dhoffmann.xamarin.adfcnewsapp.test
{
	[TestFixture ()]
	public class TestLogging
	{
		public TestLogging ()
		{
		}

		[Test ()]
		public void LoggingTest()
		{
			Logging.Log (this, Logging.LogType.Verbose, "Test log verbose");
			Logging.Log (this, Logging.LogType.Debug, "Test log debug");
			Logging.Log (this, Logging.LogType.Info, "Test log info");
			Logging.Log (this, Logging.LogType.Warn, "Test log warn");
			Logging.Log (this, Logging.LogType.Error, "Test log error");
			Logging.Log (this, Logging.LogType.Fatal, "Test log fatal");
		}
	}
}

