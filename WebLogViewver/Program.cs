/*
 * Crée par SharpDevelop.
 * Utilisateur: cbv
 * Date: 02/07/2013
 * Heure: 15:59
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Windows.Forms;
using System.Globalization;

namespace WebLogViewver
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			Application.Run(new MainForm());
		}
		
	}
}
