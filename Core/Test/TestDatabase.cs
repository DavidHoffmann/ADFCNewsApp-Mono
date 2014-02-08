//
//  TestDatabase.cs
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
using SQLite.Net;
using de.dhoffmann.xamarin.adfcnewsapp.core.Database;

namespace de.dhoffmann.xamarin.adfcnewsapp.core.Test
{
	#if DEBUG
	public class TestDatabase : Database.Database
	{
		private PCLBase pcl;
		private string dbFilename;


		public TestDatabase (PCLBase pcl, string dbFilename) : base(pcl, dbFilename)
		{
			this.pcl = pcl;
			this.dbFilename = dbFilename;
		}


		public bool Test1()
		{
			bool ret = false;

			using (SQLiteConnection conn = GetConnection ()) 
			{
				if (conn == null)
					Logging.Log (this, Logging.LogType.Error, "TEST failed: conn == null");
				else
					ret = true;
			}

			return ret;
		}


		public bool Test2()
		{
			bool ret = false;

			if (GetDBVersion () >= 0)
				Logging.Log (this, Logging.LogType.Error, "Version failed: version !HasValue");
			else
				ret = true;

			return ret;
		}


		public bool Test3()
		{
			bool ret = false;

			if (!new DBSchema (pcl, dbFilename).UpdateDBSchema ())
				Logging.Log (this, Logging.LogType.Error, "TEST failed: UpdateDBSchema");
			else
				ret = true;

			return ret;
		}


		public bool Test4()
		{
			bool ret = false;
			int? version = GetDBVersion();

			if (!version.HasValue || version.Value == 0)
				Logging.Log (this, Logging.LogType.Error, "Version failed: version == 0");
			else
				ret = true;

			return ret;
		}


		public bool Test5()
		{
			bool ret = false;

			int oldVersion = GetDBVersion ();

			using (SQLiteConnection conn = GetConnection ()) 
			{
				conn.BeginTransaction ();

				conn.Insert(new Schema.Version(){
					DateCreate = DateTime.UtcNow
				});

				conn.Commit ();
			}

			if (oldVersion == GetDBVersion ())
				Logging.Log (this, Logging.LogType.Error, "Version failed: oldVersion == version");
			else
				ret = true;

			return ret;
		}


		public bool Test6()
		{
			bool ret = false;

			if (pcl.FileExists (dbFilename))
				pcl.FileDelete (dbFilename);

			// Create file with 0kb.
			using (System.IO.StreamWriter sw = pcl.FileCreateText (dbFilename)) {
				sw.Write("");
				sw.Flush ();
			}

			Logging.Log(this, Logging.LogType.Debug, "Filesize: " + pcl.FileInfoLength(dbFilename));

			if (!new DBSchema (pcl, dbFilename).UpdateDBSchema ())
				Logging.Log (this, Logging.LogType.Error, "TEST failed: UpdateDBSchema");
			else 
			{
				if (GetDBVersion () == 0)
					Logging.Log (this, Logging.LogType.Error, "Version failed: version == 0");
				else
					ret = true;
			}

			return ret;
		}
	}

	#endif
}

