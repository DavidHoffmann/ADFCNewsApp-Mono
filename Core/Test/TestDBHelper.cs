//
//  TestDBHelper.cs
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

namespace de.dhoffmann.xamarin.adfcnewsapp.core.Test
{
	#if DEBUG
	public class TestDBHelper : IDisposable
	{
		private PCLBase pcl;
		private string dbFilename;

		public TestDBHelper (PCLBase pcl)
		{
			this.pcl = pcl;
			dbFilename = pcl.PathCombine (pcl.DbDocPath, "TEST.DB");

			// cleanup
			if (pcl.FileExists (dbFilename))
				pcl.FileDelete (dbFilename);
		}


		public bool StartDatabaseTests()
		{
			bool ret = true;

			TestDatabase testDatabase = new TestDatabase (pcl, dbFilename);
			ret &= testDatabase.Test1 ();

			testDatabase = new TestDatabase (pcl, dbFilename);
			ret &= testDatabase.Test2 ();

			testDatabase = new TestDatabase (pcl, dbFilename);
			ret &= testDatabase.Test3 ();

			testDatabase = new TestDatabase (pcl, dbFilename);
			ret &= testDatabase.Test4 ();

			testDatabase = new TestDatabase (pcl, dbFilename);
			ret &= testDatabase.Test5 ();

			testDatabase = new TestDatabase (pcl, dbFilename);
			ret &= testDatabase.Test6 ();

			return ret;
		}

		#region IDisposable implementation

		public void Dispose ()
		{
			// cleanup
			if (pcl.FileExists (dbFilename))
				pcl.FileDelete (dbFilename);

			Logging.Log (this, Logging.LogType.Debug, "TestDatabase finished");
		}

		#endregion
	}
	#endif
}

