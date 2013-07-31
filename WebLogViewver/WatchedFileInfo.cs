/*
 * Crée par SharpDevelop.
 * Utilisateur: cbv
 * Date: 03/07/2013
 * Heure: 10:37
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

using System.Collections;
using System.Collections.Generic;

using System.Text;

namespace WebLogViewver
{
		public enum DisplayTypeEnum
		{
			Undefined,Html,RawText
		};
			
			
	/// <summary>
	/// Description of WatchedFileInfo.
	/// </summary>
	public class WatchedFileInfo
	{

		
		private FileInfo _informations;
		private byte[] currentMD5=null;
		
		
		private bool md5Changed;
		private string _content;
		private bool _keepFileContent;
		private DisplayTypeEnum _DisplayType;
		
		
		
		public WatchedFileInfo(FileInfo info)
		{
			Init( info,true);
		}

		public WatchedFileInfo(FileInfo info,bool keepFileContent)
		{
			Init( info, keepFileContent);
		}
		
		
		public void Init(FileInfo info,bool keepFileContent)
		{
			_content="";
			currentMD5 = new byte[16];
			_informations =info;
			md5Changed =false;
			
			if((_keepFileContent=keepFileContent))
			{
				//Content=new ArrayList();
				UpdateContent();
				
			}
			ComputeMd5(true);	
			
			_DisplayType= DisplayTypeEnum.Undefined;
		}

		public bool KeepFileContent{get{return _keepFileContent;}}
		
		public FileInfo Informations{get{return _informations;}}
				
		public bool Update()
		{
			ComputeMd5();
			if(md5Changed)
				UpdateContent();
			
			return md5Changed;
		}
		
		public string Content
		{
			get{
			if(KeepFileContent)
				return _content;
			else
				return UpdateContent();
			
			}
		}
		
		public DisplayTypeEnum DisplayType
		{
			
			get{
				
				return _DisplayType;
			}
			
			set{
				_DisplayType=value;
				
			}
			
		}
		
		
		
		private void ComputeMd5()
		{
			ComputeMd5(false);
		}
		
		private void ComputeMd5(bool init)
		{
			byte[] newmd5 ;
			using ( MD5 o_md5 = MD5.Create())
			{
				using (var stream = File.OpenRead(Informations.FullName))
				{
					newmd5= o_md5.ComputeHash(stream);		 
				}
			}	
			md5Changed=false;
			
			if(! init)
			{
				
				for(int i=0;i<newmd5.Length;i++)
				{
					if(currentMD5[i] != newmd5[i])
					{
						md5Changed=true;
						break;
					}
				}//for
				
			}
			currentMD5=newmd5;
		}//function
		
		public string UpdateContent()
		{
			
			string newcontent=GetFileContent(Informations.FullName);
			/*
			string newcontentspec=newcontent;
			//Formater le html pour masquer les parties enchangées
			if(_content.Length>0)
			{
				int identicpartlength=GetStringDiffPos(newcontent,_content);
				
				Debug.WriteLine(identicpartlength.ToString());
				
				newcontentspec="<a href='#' onclick='javascript:document.getElementById(\"oldcontent\" ).style.display = \"block\";'>old Content</a><div id=oldcontent style='display:none;'>";
				newcontentspec +=_content.Substring(0,identicpartlength)+"</div>";
				newcontentspec += newcontent.Substring(identicpartlength,newcontent.Length - identicpartlength);					
				
			}
			*/
			_content=newcontent;			
			return (_content);
		}
		
		/*
		static int GetStringDiffPos(string s1,string s2)
		{
			
			for(int i=0;i<s1.Length;i++)
			{
				if(i==s2.Length)
					return i;
				if(s1[i]!=s2[i])
					return i;	
			}
			
			
			return s1.Length;
		}
		*/
		
		static string GetFileContent(string fileFullName)
		{
			StringBuilder sb = new StringBuilder();
			
			using (StreamReader sr = new StreamReader(fileFullName,true)) 
			{
	   			 String line;
			    // Read and display lines from the file until the end of 
			    // the file is reached.
			    while ((line = sr.ReadLine()) != null) 
			    {
			        sb.AppendLine(line);
			    }
			}
		
			string alllines=sb.ToString();
			return alllines;
		}
		
		
	
	}//class
	
}//namespace
