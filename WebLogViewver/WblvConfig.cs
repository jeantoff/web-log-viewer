/*
 * Utilisateur: cbv
 * Date: 03/07/2013
 * Heure: 09:43
 * 
 * copyright 2013 Jean-Christophe Bouvard
 *  Email : nekochat@gmail.com
* This file is part of WebLogViewer.

    WebLogViewer is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    WebLogViewer is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with WebLogViewer.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;//@todo : remove
using System.Globalization;//cast operations with current culture

namespace WebLogViewver
{
	/// <summary>
	/// WebloViewer Application parameters
	/// </summary>
	public class WblvConfig
	{
		private int _timerFreq;
		private string _watchedDirectory;
		private string _fileFilter;
		private bool _useFileSystemWatcher;
		private bool _startTimerAuto;
		private string _lastFileName;
		private List<string> _watchedDirList;
		
		public WblvConfig(string fullFileName)
		{
			LoadFromFile(fullFileName);

		}
		
		/// <summary>
		/// new instance of WblvConfig
		/// </summary>
		/// <param name="timerFreq">when timer option selected, frequency (in seconds) of watchedDirectory directory </param>
		/// <param name="watchedDirectory">Directory to watch</param>
		/// <param name="fileFilter">filter for files to watch</param>
		/// <param name="useFileSystemWatcher">false uses a timer, true : uses a FileSystemWatcher object</param></param>
		public WblvConfig(int timerFreq,string watchedDirectory,string fileFilter,bool useFileSystemWatcher)
		{
			_watchedDirList=new List<String>();
			TimerFrequency =timerFreq;
			WatchedDirectory =watchedDirectory;
			FileFilter =fileFilter;
			UseFileSystemWatcher =useFileSystemWatcher;
			_startTimerAuto=false;
		}
		
		/// <summary>
		/// if true the timer starts at application launch
		/// </summary>
		public bool StartTimerAuto
		{
			get{return _startTimerAuto;}
			set{_startTimerAuto=value;}		
		}
		
		/// <summary>
		/// when UseFileSystemWatcher=false setup the timer frequency (seconds)
		/// </summary>
		public int TimerFrequency
		{
			get{return _timerFreq;}
			set{_timerFreq=value;}		
		}
		
		/// <summary>
		/// get or set the directory to watch
		/// </summary>
		public string WatchedDirectory
		{
			get{return _watchedDirectory;}
			set{_watchedDirectory=value;
			
				if(! _watchedDirList.Contains(value))
				{
					Debug.WriteLine("ajout de " +value);
					_watchedDirList.Add(value);
				}
			}
		}
		
		/// <summary>
		/// List of last directory watched
		/// default : current WatchedDirectory property value
		/// </summary>
		public string[] WatchedDirList()
		{			
				string[] dirlist=new string[_watchedDirList.Count];
				for(int idx=0;idx< _watchedDirList.Count;idx++)
					dirlist[idx]=_watchedDirList[idx];
			
				return dirlist;	
		}
		
		/// <summary>
		/// get or set the file filter
		/// </summary>
		public string FileFilter
		{
			get{return _fileFilter;}
			set{
				if(value.Length==0)
					_fileFilter="*.*";
				else
					_fileFilter=value;
					
				_fileFilter=value;
			}
		}
		
		/// <summary>
		/// true : uses FileSystemWatcher, false :timer
		/// </summary>
		public bool UseFileSystemWatcher
		{
			get{return _useFileSystemWatcher;}
			set{_useFileSystemWatcher=value;}		
		}

		public string LastFileName
		{
			get{return _lastFileName;}
			set{_lastFileName=value;}		
		}
				
				
		/// <summary>
		/// save this configuration to a csv file
		/// </summary>
		/// <param name="fileFullPath"></param>
		public void SaveToFile(string fileFullPath)
		{
            // create a writer and open the file
            TextWriter tw = new StreamWriter(fileFullPath);
         
			string configline;
			
			string str_dirlist="";
			for(int idx=0;idx< _watchedDirList.Count;idx++)
				str_dirlist +='|'+ _watchedDirList[idx];
			
			str_dirlist=str_dirlist.TrimStart('|');

			configline= StartTimerAuto?"1":"0" +";" +
				TimerFrequency.ToString(CultureInfo.CurrentCulture) + ";" +
				WatchedDirectory +";"+
				FileFilter +";" +
				UseFileSystemWatcher.ToString(CultureInfo.CurrentCulture)  +";" +
				str_dirlist;
				
				 tw.WriteLine(configline);
            tw.Close();
            
            LastFileName=fileFullPath;
		}
		
		/// <summary>
		/// loads the configuration from a csv file
		/// </summary>
		/// <param name="fileFullPath"></param>
		public void LoadFromFile(string fileFullPath)
		{
			LastFileName=fileFullPath;
            TextReader tr = new StreamReader(fileFullPath);
            string configline=tr.ReadLine();
            tr.Close();
            
            string[]parms= configline.Split(';');

            StartTimerAuto = parms[0]=="0"?false:true;
            TimerFrequency = int.Parse(parms[1],CultureInfo.CurrentCulture );
           
            FileFilter= parms[3];
            UseFileSystemWatcher=bool.Parse( parms[4]);
            
            _watchedDirList=new List<string>();
            if(parms.Length==6)
            {
            string[] dirlist= parms[5].Split('|');
            
         
            _watchedDirList.AddRange(dirlist);
            }
            else
            {
            	_watchedDirList.Add(parms[2]);	
            }
            
             WatchedDirectory = parms[2];   
		}
		
		
	}//class
}//namespace
