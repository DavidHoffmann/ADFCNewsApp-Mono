//
//  Database.cs
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
using SQLite.Net.Async;
using SQLite.Net;
using System.Threading.Tasks;

namespace de.dhoffmann.xamarin.adfcnewsapp.core.Database
{
	public abstract class Database : IDisposable
	{
		protected const string DATABASEFILENAME = "News.db";
		private PCLBase pcl;
		private string dbFilename;
		private SQLiteConnection dbConn;


		public Database (PCLBase pcl, string dbFilename = null)
		{
			this.pcl = pcl;
			this.dbFilename = dbFilename;
		}


		protected SQLiteConnection GetConnection()
		{
			if (dbConn == null || dbConn.Handle == null) 
			{
				if (String.IsNullOrEmpty (dbFilename)) 
				{
					string docPath = pcl.DbDocPath;
					dbFilename = pcl.PathCombine (docPath, DATABASEFILENAME);
				}

				try 
				{
					dbConn = new SQLiteConnection (pcl.SqlitePlatform, dbFilename);
				} 
				catch (Exception ex) 
				{
					Logging.Log (this, Logging.LogType.Error, String.Format ("Could not connect to database. - Filename:", dbFilename), ex);
				}
			}

			return dbConn;
		}


		protected void CloseConnection()
		{
			Logging.Log (this, Logging.LogType.Debug, "Close database connection");

			if (dbConn != null)
				dbConn.Close ();
		}


		protected int GetDBVersion()
		{
			int ret = -1;

			try
			{
				Schema.Version result = null;

				using (SQLiteConnection dbConnIntern = GetConnection ()) 
				{
					var query = from v in dbConnIntern.Table<Schema.Version> ()
					            orderby v.VersionID descending
					            select v;

					result = query.FirstOrDefault ();
					dbConnIntern.Close();
				}

				if (result != null) 
				{
					ret = result.VersionID;
					Logging.Log (this, Logging.LogType.Debug, String.Format( "Current db schema version: ", ret));
				}
			}
			catch(Exception ex)
			{
				Logging.Log (this, Logging.LogType.Error, "Cannot get db version", ex);

			}

			return ret;
		}


		#region IDisposable implementation

		public void Dispose ()
		{
			CloseConnection ();
		}

		#endregion
	}
}
