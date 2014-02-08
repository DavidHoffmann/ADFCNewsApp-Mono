//
//  PCLBase.cs
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
using SQLite.Net.Interop;

namespace de.dhoffmann.xamarin.adfcnewsapp.core
{
	public abstract class PCLBase
	{
		public string DbDocPath { get; protected set; }
		public ISQLitePlatform SqlitePlatform { get; protected set; }

		public PCLBase ()
		{
		}

		public abstract bool FileExists(string path);
		public abstract string PathCombine(string path1, string path2);
		public abstract long FileInfoLength (string fileName);
		public abstract void FileDelete (string fileName);
		public abstract System.IO.StreamWriter FileCreateText (string fileName);
	}
}

