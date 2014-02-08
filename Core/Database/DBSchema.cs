//
//  DBSchema.cs
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

namespace de.dhoffmann.xamarin.adfcnewsapp.core.Database
{
	public class DBSchema : Database
	{
		private PCLBase pcl;
		private string dbFilename;

		public DBSchema (PCLBase pcl, string dbFilename = null) : base(pcl, dbFilename)
		{
			this.pcl = pcl;
			this.dbFilename = dbFilename;
		}


		public bool UpdateDBSchema()
		{
			bool ret = false;

			if (String.IsNullOrEmpty (dbFilename)) 
			{
				string docPath = pcl.DbDocPath;
				dbFilename = pcl.PathCombine (docPath, DATABASEFILENAME);
			}

			bool dbExists = pcl.FileExists (dbFilename);

			if (dbExists) 
			{
				if (pcl.FileInfoLength (dbFilename) == 0)
					pcl.FileDelete (dbFilename);

				dbExists = false;
			}

			try
			{
				SQLiteConnection conn = new SQLiteConnection (pcl.SqlitePlatform, dbFilename);

				if (!dbExists) 
				{
					Logging.Log (this, Logging.LogType.Debug, String.Format("Database {0} does not exists.", dbFilename));

					conn.CreateTable<Schema.Version>();
					Logging.Log (this, Logging.LogType.Debug, "Created new database.");

					conn.BeginTransaction();
					conn.Insert(new Schema.Version(){
						VersionID = 0,
						DateCreate = DateTime.UtcNow
					});
					conn.Commit();

					ret = true;

					Logging.Log(this, Logging.LogType.Debug, "initialized version");
				}
				else
					Logging.Log(this, Logging.LogType.Debug, "Database exists");
			}
			catch(Exception ex) 
			{
				Logging.Log (this, Logging.LogType.Error, String.Format("Could not create database {0}.", dbFilename), ex);
			}

			if (ret)
			{
				// update schema
				switch(GetDBVersion())
				{
				case 0:
					break;

				}
			}

			return ret;
		}
	}
}

