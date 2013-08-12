/*
 * Crée par SharpDevelop.
 * Utilisateur: cbv
 * Date: 02/07/2013
 * Heure: 15:59
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
//using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection; 
using System.Resources;
using  Microsoft.CSharp;

using System.Security.Permissions  ;
using System.Security;


//using System.Security;
//using System.Security.Permissions;
//using System.Runtime.InteropServices;
//using System.Text;

[assembly:CLSCompliant(true)]


namespace WebLogViewver
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
[SecurityCritical]
	public partial class MainForm : Form
	{
		private string ConfigFileFullName;
		private Dictionary<string,WatchedFileInfo> WatchedFilesList;
		private WblvConfig CurrentConfig;
		private bool PathHasChanged;
		
		private Settings1 appsettings= new Settings1();
		//private ResourceManager Appresources=new ResourceManager(WebLogViewver.
 
		public MainForm()
		{
			InitializeComponent();
			this.PathHasChanged=false;

			ConfigFileFullName=Path.GetFullPath(Path.Combine(Application.StartupPath,  @"..\resources\config.csv")) ;
			
			try
			{
				this.CurrentConfig =new WblvConfig(ConfigFileFullName);				
			}
			catch(FileNotFoundException ex)
			{
				MessageBox.Show(ex.Message+"\nUne configuration par défaut va être générée.","Fichier introuvable",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1,MessageBoxOptions.DefaultDesktopOnly);
				this.CurrentConfig =new WblvConfig(5, appsettings.default_directory,"*.log",false);
				
				this.CurrentConfig.SaveToFile(ConfigFileFullName);
			}
			
			tabConfig.ToolTipText=ConfigFileFullName;
			
			this.WatchedFilesList = new Dictionary<string, WatchedFileInfo>();
			
			if(!this.CurrentConfig.StartTimerAuto || this.CurrentConfig.UseFileSystemWatcher )
				StopTimer();
			else
				StartTimer();
			
			ApplyConfig(null);
			
			UpdateFilesList();	
			if(cb_AutoStart.Checked)
					StartTimer();
			
		}//function
		
		//PRIVATE FUNCTIONS ----------------------------------------------------------------------
		#region "private"
		[SecurityCritical]
		private void  UpdateFilesList()
		{
			DirectoryInfo di = new DirectoryInfo(this.CurrentConfig.WatchedDirectory);
				
			    string[] searchPatterns = this.CurrentConfig.FileFilter.Split(',');
			    
			    List<FileInfo> files = new List<FileInfo>();
			    
			    foreach (string sp in searchPatterns)
			    {
			    	files.AddRange(di.GetFiles(sp));
			    }

			foreach(FileInfo finf in files)
			{
				if( !this.WatchedFilesList.ContainsKey(finf.FullName))
				{
					this.WatchedFilesList.Add(finf.FullName,new WatchedFileInfo(finf));
					this.UpdateTab(finf.FullName);
				}	
				else
				{
					if(this.WatchedFilesList[finf.FullName].Update())
					{
						this.UpdateTab(finf.FullName);
					}
				}
			}	//foreach
		}//function
	
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
		private void ApplyConfig(WblvConfig wlb)
		{
			StopTimer();

			if(wlb == null)
				wlb=this.CurrentConfig;

			fileSystemWatcher1.Path=wlb.WatchedDirectory;
			tb_Filtre.Text=wlb.FileFilter;
			num_Freq.Value = wlb.TimerFrequency;
			timer1.Interval =wlb.TimerFrequency * 1000;
			cb_Path.Items.Clear();
			
			cb_Path.Items.AddRange(wlb.WatchedDirList());
			cb_Path.Text=wlb.WatchedDirectory;
	
			if(this.CurrentConfig.StartTimerAuto)
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
				if(tpname != "tabConfig")
					tabControl1.TabPages.RemoveByKey(tpname);
		}
		
		/// <summary>
		/// synchronizes config tab control values with current configuration
		/// </summary>
		private void MapControlsInConfig()
		{
			this.CurrentConfig.StartTimerAuto=cb_AutoStart.Checked;
			this.CurrentConfig.WatchedDirectory=cb_Path.Text;
			this.CurrentConfig.FileFilter = tb_Filtre.Text;
			this.CurrentConfig.TimerFrequency =(int) num_Freq.Value;
			this.CurrentConfig.UseFileSystemWatcher = rb_isFsWatch.Checked;
		}
	
		
		[SecurityCritical]
		static string GetFileName(string FilePath)
		{
			FileInfo finf=new FileInfo(FilePath);
			return finf.Name;
		}
		
		[SecurityCritical]
		static string GetFileFullName(string FilePath)
		{
			FileInfo finf=new FileInfo(FilePath);
			return finf.FullName;
		}
		
		/// <summary>
		/// refresh tab webbrowser content with associated file content
		/// </summary>
		/// <param name="FilePath"></param>
	[PermissionSetAttribute(SecurityAction.LinkDemand, Name="FullTrust")]
	 void UpdateTab(string FilePath)
		{
			string basename=GetFileName( FilePath);
			TabPage tp;
			WebBrowser wb;
			//Panel pnl;
			int index=0;
						
			if(this.PathHasChanged)
			{
				DeletePreviousPathTabs();
				this.PathHasChanged=false;
			}
	
			index=SearchTabName(basename);

			if(index==-1)
			{
				tp= new TabPage(basename);
				tp.Name=basename;	
				tp.ToolTipText=GetFileFullName(FilePath);
				
				wb= new WebBrowser();
				wb.Name="wb_"+basename;
				tp.Controls.Add(wb);
				wb.Dock= DockStyle.Fill;	
				wb.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.WebBrowser1PreviewKeyDown);
				
				this.tabControl1.TabPages.Add(tp);
			}
			else
			{
				tp=tabControl1.TabPages[index];
				int widx=tp.Controls.IndexOfKey("wb_"+basename);
				wb=(WebBrowser) tp.Controls[widx];
			}
					
			if((this.WatchedFilesList[FilePath].DisplayType== DisplayTypeEnum.Undefined && !this.WatchedFilesList[FilePath].Content.StartsWith("<",StringComparison.CurrentCulture))
			   || this.WatchedFilesList[FilePath].DisplayType== DisplayTypeEnum.RawText)
			{
				wb.DocumentText="<pre>" + this.WatchedFilesList[FilePath].Content + "</pre>";
			}
			else
			{
				wb.DocumentText= this.WatchedFilesList[FilePath].Content ;
			}

			tabControl1.SelectedTab= tp;
			
			//System.Uri uri =new Uri(FilePath);
			//wb.Url=uri;
			//wb.Update();
			
       		Application.DoEvents();
	        if (wb.Document!=null  && wb.Document != null)
	        {
	            wb.Document.Window.ScrollTo(0, wb.Document.Body.ScrollRectangle.Height);
	        }                 
		}//function
		
		#endregion
		

		
		/// <summary>
		/// return a tab index according to his name
		/// </summary>
		/// <param name="tabName">Name of the searched tab</param>
		/// <returns>tab index if found, else -1</returns>
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
		
		/// <summary>
		/// starts the timer and changes button label
		/// </summary>
		private void StartTimer()
		{
			if(this.CurrentConfig.UseFileSystemWatcher)
				return;
			
			b_TimerButton.Text="Arrêter";			
			timer1.Start();
		}
		
		/// <summary>
		/// stops the timer and changes button label
		/// </summary>		
		private void StopTimer()
		{
			if(this.CurrentConfig.UseFileSystemWatcher)
				return;
						
			b_TimerButton.Text="Démarrer";
			timer1.Stop();
		}
		


		private void SelectTab(int tabindex)
		{
			tabControl1.SelectedTab=tabControl1.TabPages[tabindex];
			tabControl1.Refresh();
		}
		
		
		/// <summary>
		/// remove a tab from tab control
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions")]
		private bool RemoveTab(int index)
		{
		   if(index>0)
	       {
		   		DialogResult dres=DialogResult.No;
		  
		   		
		   		
		   		if(cb_ConfirmDeletes.Checked)
			   	{
		   			
			   		dres=MessageBox.Show("Confirmer la fermeture ?","Confirmation",MessageBoxButtons.YesNoCancel /*,MessageBoxIcon.Asterisk*/);
			   	}
			   	else
			   	{
			   		dres=DialogResult.Yes;
			   	}
		   	
	           	if(dres==DialogResult.Yes)
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
	
		/// <summary>
		/// Get tab index from under mouse location
		/// 
		/// </summary>
		/// <param name="location"></param>
		/// <returns></returns>
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
		#region "EVENTS FUNCTIONS"
	
		void B_ApplyClick(object sender, EventArgs e)
		{
			MapControlsInConfig();	
			
			
			this.CurrentConfig.SaveToFile(ConfigFileFullName);
			ApplyConfig(null);
			UpdateFilesList();
			if(!this.CurrentConfig.UseFileSystemWatcher)
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
				if(this.CurrentConfig.WatchedDirectory != folderBrowserDialog1.SelectedPath)
				{
					fileSystemWatcher1.Path=folderBrowserDialog1.SelectedPath;

					cb_Path.Text=folderBrowserDialog1.SelectedPath;
					this.PathHasChanged=true;
					MapControlsInConfig();
					ApplyConfig(null);
				}
			}
			
		}
		
		void FileSystemWatcher1Changed(object sender, FileSystemEventArgs e)
		{
			string filePath=e.FullPath;
			this.UpdateTab(filePath);
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
			int tabindex=GetTabIndexFromPos(e.Location);
			switch(tabindex)
			{	
				case -1:
					break;
					
				case 0:
					if(e.Button == MouseButtons.Right)
						OpenConfigContextMenu( e);
					
					break;
				
				default:
					if(e.Button == MouseButtons.Middle)
			    	{
						SelectTab(tabindex);
					}	
					else if(e.Button == MouseButtons.Right)
					{
						OpenFileTabContextMenu(e,tabindex);
					}	
					break;
					
			}//switch
			
		}//function
			
				
		void CloseToolStripMenuItemClick(object sender, EventArgs e)
		{
			int tabindex=(int) contextMenuStripFileTabs.Tag;
			
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

		void CloseAndDeleteFileToolStripMenuItemClick(object sender, EventArgs e)
		{
			bool timeron=timer1.Enabled;
			if(timeron)
				StopTimer();
			
			int tabindex=(int) contextMenuStripFileTabs.Tag;
			string path=this.CurrentConfig.WatchedDirectory + @"\"+tabControl1.TabPages[tabindex].Name;
			
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
			if(  this.CurrentConfig.UseFileSystemWatcher)
			{
				StopTimer();	
			}
			
			UpdateFilesList();
		}//function

		
		void HtmlDisplayToolStripMenuItemCheckedChanged(object sender, EventArgs e)
		{
			int tabindex=(int) contextMenuStripFileTabs.Tag;
			string path=this.CurrentConfig.WatchedDirectory + @"\"+tabControl1.TabPages[tabindex].Name;
			
			if(HtmlDisplayToolStripMenuItem.Checked)
			{
				this.WatchedFilesList[path].DisplayType=DisplayTypeEnum.Html;
				tabControl1.Refresh();
			}
			else
			{
				this.WatchedFilesList[path].DisplayType=DisplayTypeEnum.RawText;
				
				TabPage tabctrl=tabControl1.TabPages[tabindex];
				int widx=tabctrl.Controls.IndexOfKey("wb_"+tabctrl.Name);
				WebBrowser webros=(WebBrowser) tabctrl.Controls[widx];
				webros.DocumentText="<pre>" + this.WatchedFilesList[path].Content + "</pre>";
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
		
		void TabConfigClick(object sender, EventArgs e)
		{
			StopTimer();
		}
		
		void CloseAndEmptyFileToolStripMenuItemClick(object sender, EventArgs e)
		{
			bool timeron=timer1.Enabled;
			if(timeron)
				StopTimer();
			
			int tabindex=(int) contextMenuStripFileTabs.Tag;
			string path=this.CurrentConfig.WatchedDirectory + @"\"+tabControl1.TabPages[tabindex].Name;
			File.Delete(path);
			
			System.IO.FileStream fs= File.Create(path);
			fs.Close();
	
		if(timeron)
			StartTimer();
		}//function
		
		void MainFormLoad(object sender, EventArgs e)
		{
			this.SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
     		 this.BackColor = System.Drawing.Color.Transparent;
		}
		
		void OuvrirDossierToolStripMenuItemClick(object sender, EventArgs e)
		{
			bool timeron=timer1.Enabled;
			if(timeron)
				StopTimer();
			
			int tabindex=(int) contextMenuStripFileTabs.Tag;
			string path=this.CurrentConfig.WatchedDirectory ;

			Process.Start(path);
		}
		
		void WebBrowser1PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if(e.KeyCode == Keys.F5)
			{
				
				UpdateFilesList();				
				
			}
		}
		
		void OpenConfigContextMenu(MouseEventArgs e)
		{
			contextMenuStripConfigTab.Show(new Point(e.X+this.Location.X,e.Y+this.Location.Y+(this.contextMenuStripFileTabs.Height/2)));	
		}

		
		void OpenFileTabContextMenu(MouseEventArgs e,int tabindex)
		{
			contextMenuStripFileTabs.Tag=tabindex;
			string path=this.CurrentConfig.WatchedDirectory + @"\"+tabControl1.TabPages[tabindex].Name;
			
			if(this.WatchedFilesList[path].DisplayType==DisplayTypeEnum.Html)
				HtmlDisplayToolStripMenuItem.Checked=true;
			else
				HtmlDisplayToolStripMenuItem.Checked=false;
			
			
			switch(this.WatchedFilesList[path].DisplayType)
			{	
				case DisplayTypeEnum.Html:
					HtmlDisplayToolStripMenuItem.Checked=true;
					break;
					
				case DisplayTypeEnum.RawText:
					HtmlDisplayToolStripMenuItem.Checked=false;
					break;
					
				case DisplayTypeEnum.Undefined:
					if(this.WatchedFilesList[path].Content.StartsWith("<",StringComparison.CurrentCulture))
						HtmlDisplayToolStripMenuItem.Checked=true;
					else
						HtmlDisplayToolStripMenuItem.Checked=false;
					   
					break;
			}//switch
			
			contextMenuStripFileTabs.Show(new Point(e.X+this.Location.X,e.Y+this.Location.Y+(this.contextMenuStripFileTabs.Height/2)));
		}
		
		#endregion
	}//class
}//namespace
