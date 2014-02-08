//
//  Author:
//       David Hoffmann <david@hoffmann-projects.de>
//
//  Copyright (c) 2014 David Hoffmann
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
using de.dhoffmann.xamarin.adfcnewsapp.core;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;

namespace de.dhoffmann.xamarin.adfcnewsapp.android.PCLHelper
{
	public class PCL : PCLBase
	{
		public PCL()
		{
			SqlitePlatform = new SQLitePlatformAndroid ();
			DbDocPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
		}

		public override bool FileExists(string path)
		{
			return File.Exists (path);
		}

		public override string PathCombine(string path1, string path2)
		{
			return Path.Combine (path1, path2);
		}

		public override long FileInfoLength (string fileName)
		{
			return new FileInfo (fileName).Length;
		}

		public override void FileDelete (string fileName)
		{
			File.Delete (fileName);
		}

		public override System.IO.StreamWriter FileCreateText (string fileName)
		{
			return File.CreateText (fileName);
		}
	}
}

