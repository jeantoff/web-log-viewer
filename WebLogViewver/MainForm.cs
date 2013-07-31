﻿/*
 * Crée par SharpDevelop.
 * Utilisateur: cbv
 * Date: 02/07/2013
 * Heure: 15:59
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;
//using System.Text;

[assembly:CLSCompliant(true)]


namespace WebLogViewver
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
	
		Dictionary<string,WatchedFileInfo> WatchedFilesList;
		WblvConfig CurrentConfig;
		private bool PathHasChanged;
		
		private Settings1 appsettings= new Settings1();
/*		
	[DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);
 */   
		public MainForm()
		{
			InitializeComponent();
			
			PathHasChanged=false;
			try
			{
				CurrentConfig =new WblvConfig("config.csv");				
			}
			catch(FileNotFoundException ex)
			{
			
				MessageBox.Show(ex.Message+"\nUne configuration par défaut va être générée.","Fichier introuvable",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
				
				CurrentConfig =new WblvConfig(5, appsettings.default_directory,"*.*",false);
				
				CurrentConfig.SaveToFile(appsettings.default_configFileName);
			}
			
			WatchedFilesList = new Dictionary<string, WatchedFileInfo>();
			
			if(!CurrentConfig.StartTimerAuto || CurrentConfig.UseFileSystemWatcher )
				StopTimer();
			else
				StartTimer();
			
			ApplyConfig(null);
			
			UpdateFilesList();	
			if(cb_AutoStart.Checked)
					StartTimer();
			
		}//function
		
		
		//PRIVATE FUNCTIONS ----------------------------------------------------------------------
		private void  UpdateFilesList()
		{
		//	Debug.WriteLine("updating file list");
			DirectoryInfo di = new DirectoryInfo(CurrentConfig.WatchedDirectory);
			FileInfo[] fileslist= di.GetFiles(CurrentConfig.FileFilter);
			
			
			foreach(TabPage tp in tabControl1.TabPages)
			{
				
				tp.BackColor=Color.Transparent;
				
			}
			tabControl1.Refresh();
			
		
			foreach(FileInfo finf in fileslist)
			{
				
				if( !WatchedFilesList.ContainsKey(finf.FullName))
				{
					WatchedFilesList.Add(finf.FullName,new WatchedFileInfo(finf));
					UpdateTab(finf.FullName);
				}	
				else
				{
					if(WatchedFilesList[finf.FullName].Update())
					{
						
						UpdateTab(finf.FullName);
					}
				}
				
			}	//foreach
					
			
		}//function
	
		/*[SecuritySafeCritical]*/
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
		private void ApplyConfig(WblvConfig wlb)
		{
			StopTimer();
			

			if(wlb == null)
				wlb=CurrentConfig;
			
			//EnvironmentPermission envPermission = new EnvironmentPermission( EnvironmentPermissionAccess.Write,fileSystemWatcher1.Path);
         	//envPermission.Assert();
			fileSystemWatcher1.Path=wlb.WatchedDirectory;
			//tb_Path.Text=wlb.WatchedDirectory;
			tb_Filtre.Text=wlb.FileFilter;
			num_Freq.Value = wlb.TimerFrequency;
			timer1.Interval =wlb.TimerFrequency * 1000;
			cb_Path.Items.Clear();
			
			cb_Path.Items.AddRange(wlb.WatchedDirList);
			cb_Path.Text=wlb.WatchedDirectory;
			
			
			if(CurrentConfig.StartTimerAuto)
			{
				cb_AutoStart.Checked=true;
			}
			
			if(wlb.UseFileSystemWatcher)
			{			
				gp_Timer.Enabled=false;
				fileSystemWatcher1.EnableRaisingEvents=true;
				rb_isFsWatch.Checked=true;
				rb_isTimer.Checked=false;
				b_TimerButton.Enabled=false;
				
			}
			else
			{
				gp_Timer.Enabled=true;
				fileSystemWatcher1.EnableRaisingEvents=false;	
				rb_isFsWatch.Checked=false;	
				rb_isTimer.Checked=true;
				b_TimerButton.Enabled=true;
				
	
			}
				
		}
		
		private void DeletePreviousPathTabs()
		{
			List<string> oldtabskeys = new List<string>();
			
			foreach(TabPage tpage in tabControl1.TabPages)
				oldtabskeys.Add(tpage.Name);
			
			foreach(string tpname in oldtabskeys)
				if(tpname != "tabPage1")
					tabControl1.TabPages.RemoveByKey(tpname);
			
			
			Debug.WriteLine("ici");
			
		}
		
		
		private void MapControlsInConfig()
		{
			CurrentConfig.StartTimerAuto=cb_AutoStart.Checked;
			//CurrentConfig.WatchedDirectory = fileSystemWatcher1.Path;
			
			//CurrentConfig.WatchedDirectory = tb_Path.Text;
			CurrentConfig.WatchedDirectory=cb_Path.Text;
			
			CurrentConfig.FileFilter = tb_Filtre.Text;
			CurrentConfig.TimerFrequency =(int) num_Freq.Value;
			CurrentConfig.UseFileSystemWatcher = rb_isFsWatch.Checked;
		}

		
		private void UpdateTab(string FilePath)
		{
			FileInfo finf=new FileInfo(FilePath);
			string basename=finf.Name;
			TabPage tp;
			WebBrowser wb;
			//Panel pnl;
			int index=0;
						
			if(PathHasChanged)
			{
				DeletePreviousPathTabs();
				PathHasChanged=false;
			}
	
			index=SearchTabName(basename);

			if(index==-1)
			{
				tp= new TabPage(basename);
				tp.Name=basename;	
				
				wb= new WebBrowser();
				wb.Name="wb_"+basename;

				tp.Controls.Add(wb);
				wb.Dock= DockStyle.Fill;	

				this.tabControl1.TabPages.Add(tp);
				
			}
			else
			{
				tp=tabControl1.TabPages[index];
				int widx=tp.Controls.IndexOfKey("wb_"+basename);
				wb=(WebBrowser) tp.Controls[widx];
			}
					
			if((WatchedFilesList[FilePath].DisplayType== DisplayTypeEnum.Undefined && !WatchedFilesList[FilePath].Content.StartsWith("<",StringComparison.CurrentCulture))
			   || WatchedFilesList[FilePath].DisplayType== DisplayTypeEnum.RawText)
			{
				wb.DocumentText="<pre>" + WatchedFilesList[FilePath].Content + "</pre>";
			}
			else
			{
				wb.DocumentText= WatchedFilesList[FilePath].Content ;
			}
			  
			
			
			tabControl1.SelectedTab= tp;
			
			/*
			System.Uri uri =new Uri(FilePath);
			wb.Url=uri;
			wb.Update();
			*/

       		Application.DoEvents();

	        if (wb.Document!=null  && wb.Document != null)
	        {
	            wb.Document.Window.ScrollTo(0, wb.Document.Body.ScrollRectangle.Height);
	        }

			//SetToForeground();                 
		}//function
		
		/*
		private void SetToForeground()
		{
			  Process thisProcess = Process.GetCurrentProcess();
    			//Process[] peerProcesses = Process.GetProcessesByName(thisProcess.ProcessName.Replace(".vshost", string.Empty));

			   // Process[] processes = Process.GetProcessesByName(Application.ex);
			   SetForegroundWindow(thisProcess.MainWindowHandle);
			   this.BringToFront();
		}
		*/
		
		private int SearchTabName(string tabName)
		{
			int index=0;
			bool exists=false;
			foreach(TabPage ctrl in tabControl1.TabPages)
			{
				
				if(ctrl.Name == tabName)
				{
					exists=true;
					break;
				}
				
				index++;
			}
			
			if(! exists)
				return -1;
			
			return index;
		}//function
		
		private void StartTimer()
		{
			
			b_TimerButton.Text="Arrêter";			
			timer1.Start();
		}
		
		private void StopTimer()
		{
			b_TimerButton.Text="Démarrer";
			timer1.Stop();
		}
					
		
		private bool RemoveTab(int index)
		{
		   if(index>0)
	       {
	           	if(MessageBox.Show("Confirmer la fermeture ?","Confirmation",MessageBoxButtons.YesNoCancel /*,MessageBoxIcon.Asterisk*/)
	           	   == DialogResult.Yes)
	           	{
	               tabControl1.TabPages.RemoveAt(index);	 
	               return true;
	           	}
		   		else
		   		{
		   			return false;
		   		}
	       }
			return false;		               
		}
	
				
		private int GetTabIndexFromPos(Point location)
		{
				for(int i = 0; i < tabControl1.TabCount; i++)
		        {
		            // get their rectangle area and check if it contains the mouse cursor
		            Rectangle r = tabControl1.GetTabRect(i);
		            if (r.Contains(location))
		            {
		            	return i;
		            	//break;
		             }
		        }
				
				return -1;
		}//function
		
		
		//EVENTS FUNCTIONS ----------------------------------------------------------------------
		void B_ApplyClick(object sender, EventArgs e)
		{
			MapControlsInConfig();	
			ApplyConfig(null);
			
			CurrentConfig.SaveToFile("config.csv");
			
			if(!CurrentConfig.UseFileSystemWatcher)
			{
				StartTimer();
				
			}
		}
				
				
		void B_ChangeDirClick(object sender, EventArgs e)
		{		
			
			bool timeron=timer1.Enabled;
			
			folderBrowserDialog1.SelectedPath= cb_Path.Text.ToString();
			folderBrowserDialog1.ShowDialog();
			if(folderBrowserDialog1.SelectedPath.Length>0)
			{
				
				if(CurrentConfig.WatchedDirectory != folderBrowserDialog1.SelectedPath)
				{
					fileSystemWatcher1.Path=folderBrowserDialog1.SelectedPath;
					//tb_Path.Text=folderBrowserDialog1.SelectedPath;
					cb_Path.Text=folderBrowserDialog1.SelectedPath;
					//DeletePreviousPathTabs();
					PathHasChanged=true;
					MapControlsInConfig();
					ApplyConfig(null);
				}
			}
			
		}
		
		void FileSystemWatcher1Changed(object sender, FileSystemEventArgs e)
		{
			//this.WindowState= FormWindowState.Maximized;
			
			string filePath=e.FullPath;
			Debug.WriteLine(filePath);
			//Console.WriteLine(filePath);
			UpdateTab(filePath);
		}

		void FileSystemWatcher1Deleted(object sender, FileSystemEventArgs e)
		{
			FileInfo finf=new FileInfo(e.FullPath);
			string basename=finf.Name;
			int index=SearchTabName(basename);
			
			if(index>=0)
			{
				tabControl1.TabPages.RemoveAt(index);	
			}
		}//function
				
		void MainFormMouseUp(object sender, MouseEventArgs e)
		{
			
			//this.contextMenuStrip1.Show();
			/*
			if(e.Button==MouseButtons.Right)
				this.contextMenuStrip1.Show(new Point(e.X+this.Location.X,e.Y+this.Location.Y));
			
			*/
			int i=GetTabIndexFromPos(e.Location);
				
			if(i<0)
				return;
			
						
			if(i==0)
			{
				
				contextMenuStrip1.Show(new Point(e.X+this.Location.X,e.Y+this.Location.Y+(this.contextMenuStrip1.Height/2)));
			}
			else
			{
				
				tabControl1.SelectedTab=tabControl1.TabPages[i];
				
				//tabControl1.TabPages[i].Show();
				tabControl1.Refresh();
				if(e.Button == MouseButtons.Middle)
			    {
					RemoveTab(i);
			    }
				else if(	e.Button == MouseButtons.Right)
				{
					contextMenuStrip1.Tag=i;
					
					string path=CurrentConfig.WatchedDirectory + @"\"+tabControl1.TabPages[i].Name;
					
					if(WatchedFilesList[path].DisplayType==DisplayTypeEnum.Html)
						HtmlDisplayToolStripMenuItem.Checked=true;
					else
						HtmlDisplayToolStripMenuItem.Checked=false;
					
					
					switch(WatchedFilesList[path].DisplayType)
					{
							
						case DisplayTypeEnum.Html:
							HtmlDisplayToolStripMenuItem.Checked=true;
							break;
							
						case DisplayTypeEnum.RawText:
							HtmlDisplayToolStripMenuItem.Checked=false;
							break;
							
						case DisplayTypeEnum.Undefined:
							if(WatchedFilesList[path].Content.StartsWith("<",StringComparison.CurrentCulture))
								HtmlDisplayToolStripMenuItem.Checked=true;
							else
								HtmlDisplayToolStripMenuItem.Checked=false;
							   
							break;
					}//switch
						
					//if(HtmlDisplayToolStripMenuItem.ch
					
					contextMenuStrip1.Show(new Point(e.X+this.Location.X,e.Y+this.Location.Y+(this.contextMenuStrip1.Height/2)));
					
				}
			}
		}//function
			
				
		void FermerToolStripMenuItemClick(object sender, EventArgs e)
		{
			int tabindex=(int) contextMenuStrip1.Tag;
			
			if(RemoveTab(tabindex))
			{
				
				if(tabControl1.TabPages.Count>1)
				{
					if(tabindex==tabControl1.TabPages.Count)
						tabindex=tabControl1.TabPages.Count -1;
					
					tabControl1.SelectedTab=tabControl1.TabPages[tabindex];
					
				}
				
			}
		}

		void FermerEtSupprimerFichierToolStripMenuItemClick(object sender, EventArgs e)
		{
			bool timeron=timer1.Enabled;
			if(timeron)
				StopTimer();
			
			
			int tabindex=(int) contextMenuStrip1.Tag;
			string path=CurrentConfig.WatchedDirectory + @"\"+tabControl1.TabPages[tabindex].Name;
			
			if(RemoveTab(tabindex))
			{
				File.Delete(path);
				
				if(tabControl1.TabPages.Count>1)
				{
					if(tabindex==tabControl1.TabPages.Count)
						tabindex=tabControl1.TabPages.Count -1;
					
					tabControl1.SelectedTab=tabControl1.TabPages[tabindex];
					
				}
								
			}	
		if(timeron)
			StartTimer();
		}//function
		
		void B_TimerButtonClick(object sender, EventArgs e)
		{
			Control ctrl= (Control) sender;
			if(timer1.Enabled )
				StopTimer();
			else
				StartTimer();
		}
		
			
		void Rb_isTimerCheckedChanged(object sender, EventArgs e)
		{
			if(rb_isTimer.Checked)
			{
				b_TimerButton.Enabled=true;
				gp_Timer.Enabled=true;
			}
			else
			{
				b_TimerButton.Enabled=false;
				gp_Timer.Enabled=false;	
			}
		}//function
		
		
		void Timer1Tick(object sender, EventArgs e)
		{
			
			if(  CurrentConfig.UseFileSystemWatcher)
			{
				StopTimer();	
			}
			
			UpdateFilesList();
		}//function

		
		void HtmlDisplayToolStripMenuItemCheckedChanged(object sender, EventArgs e)
		{
			
			int tabindex=(int) contextMenuStrip1.Tag;
			string path=CurrentConfig.WatchedDirectory + @"\"+tabControl1.TabPages[tabindex].Name;
			
			if(HtmlDisplayToolStripMenuItem.Checked)
			{
				Debug.WriteLine("Mode html");
				WatchedFilesList[path].DisplayType=DisplayTypeEnum.Html;
				tabControl1.Refresh();
			}
			else
			{
				WatchedFilesList[path].DisplayType=DisplayTypeEnum.RawText;
				
				TabPage tabctrl=tabControl1.TabPages[tabindex];
				int widx=tabctrl.Controls.IndexOfKey("wb_"+tabctrl.Name);
				WebBrowser webros=(WebBrowser) tabctrl.Controls[widx];
				webros.DocumentText="<pre>" + WatchedFilesList[path].Content + "</pre>";
				tabControl1.Refresh();
			}

		}
		
		void HtmlDisplayToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(HtmlDisplayToolStripMenuItem.Checked)
				HtmlDisplayToolStripMenuItem.Checked=false;
			else
				HtmlDisplayToolStripMenuItem.Checked=true;
		}
		
		void TabPage1Click(object sender, EventArgs e)
		{
			StopTimer();
		}
		
		void FermerEtViderFichierToolStripMenuItemClick(object sender, EventArgs e)
		{
			bool timeron=timer1.Enabled;
			if(timeron)
				StopTimer();
			
			
			int tabindex=(int) contextMenuStrip1.Tag;
			string path=CurrentConfig.WatchedDirectory + @"\"+tabControl1.TabPages[tabindex].Name;
			File.Delete(path);
			
			System.IO.FileStream fs= File.Create(path);
			fs.Close();
	
		if(timeron)
			StartTimer();
		}//function
	}//class
}//namespace
