/*
 * Crée par SharpDevelop.
 * Utilisateur: cbv
 * Date: 02/07/2013
 * Heure: 15:59
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
namespace WebLogViewver
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.b_TimerButton = new System.Windows.Forms.Button();
			this.gp_Files = new System.Windows.Forms.GroupBox();
			this.lbl_Path = new System.Windows.Forms.Label();
			this.cb_Path = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.b_ChangeDir = new System.Windows.Forms.Button();
			this.tb_Filtre = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.gp_Timer = new System.Windows.Forms.GroupBox();
			this.num_Freq = new System.Windows.Forms.NumericUpDown();
			this.cb_AutoStart = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.b_Apply = new System.Windows.Forms.Button();
			this.gb_WatchType = new System.Windows.Forms.GroupBox();
			this.rb_isFsWatch = new System.Windows.Forms.RadioButton();
			this.rb_isTimer = new System.Windows.Forms.RadioButton();
			this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.fermerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fermerEtSupprimerFichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fermerEtViderFichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HtmlDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toutFermerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toutFermerEtSupprimerLesFichiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gp_Files.SuspendLayout();
			this.gp_Timer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_Freq)).BeginInit();
			this.gb_WatchType.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.contextMenuStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.AllowDrop = true;
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1256, 537);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseUp);
			// 
			// tabPage1
			// 
			this.tabPage1.AutoScroll = true;
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.b_TimerButton);
			this.tabPage1.Controls.Add(this.gp_Files);
			this.tabPage1.Controls.Add(this.gp_Timer);
			this.tabPage1.Controls.Add(this.b_Apply);
			this.tabPage1.Controls.Add(this.gb_WatchType);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1248, 508);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Config";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage1.Click += new System.EventHandler(this.TabPage1Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(288, 431);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 10;
			this.label4.Text = "Timer";
			// 
			// b_TimerButton
			// 
			this.b_TimerButton.Location = new System.Drawing.Point(346, 425);
			this.b_TimerButton.Name = "b_TimerButton";
			this.b_TimerButton.Size = new System.Drawing.Size(75, 23);
			this.b_TimerButton.TabIndex = 9;
			this.b_TimerButton.Text = "Démarrer";
			this.b_TimerButton.UseVisualStyleBackColor = true;
			this.b_TimerButton.Click += new System.EventHandler(this.B_TimerButtonClick);
			// 
			// gp_Files
			// 
			this.gp_Files.Controls.Add(this.lbl_Path);
			this.gp_Files.Controls.Add(this.cb_Path);
			this.gp_Files.Controls.Add(this.label1);
			this.gp_Files.Controls.Add(this.b_ChangeDir);
			this.gp_Files.Controls.Add(this.tb_Filtre);
			this.gp_Files.Controls.Add(this.label3);
			this.gp_Files.Location = new System.Drawing.Point(8, 15);
			this.gp_Files.Name = "gp_Files";
			this.gp_Files.Size = new System.Drawing.Size(453, 184);
			this.gp_Files.TabIndex = 13;
			this.gp_Files.TabStop = false;
			this.gp_Files.Text = "Fichiers";
			// 
			// lbl_Path
			// 
			this.lbl_Path.Location = new System.Drawing.Point(6, 58);
			this.lbl_Path.Name = "lbl_Path";
			this.lbl_Path.Size = new System.Drawing.Size(441, 23);
			this.lbl_Path.TabIndex = 14;
			// 
			// cb_Path
			// 
			this.cb_Path.FormattingEnabled = true;
			this.cb_Path.Location = new System.Drawing.Point(6, 84);
			this.cb_Path.Name = "cb_Path";
			this.cb_Path.Size = new System.Drawing.Size(366, 21);
			this.cb_Path.TabIndex = 14;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 26);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(385, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Répertoire de logs html";
			// 
			// b_ChangeDir
			// 
			this.b_ChangeDir.Location = new System.Drawing.Point(378, 82);
			this.b_ChangeDir.Name = "b_ChangeDir";
			this.b_ChangeDir.Size = new System.Drawing.Size(35, 23);
			this.b_ChangeDir.TabIndex = 1;
			this.b_ChangeDir.Text = "...";
			this.b_ChangeDir.UseVisualStyleBackColor = true;
			this.b_ChangeDir.Click += new System.EventHandler(this.B_ChangeDirClick);
			// 
			// tb_Filtre
			// 
			this.tb_Filtre.Location = new System.Drawing.Point(6, 148);
			this.tb_Filtre.Name = "tb_Filtre";
			this.tb_Filtre.Size = new System.Drawing.Size(100, 20);
			this.tb_Filtre.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 122);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Filtre fichiers";
			// 
			// gp_Timer
			// 
			this.gp_Timer.Controls.Add(this.num_Freq);
			this.gp_Timer.Controls.Add(this.cb_AutoStart);
			this.gp_Timer.Controls.Add(this.label2);
			this.gp_Timer.Location = new System.Drawing.Point(288, 234);
			this.gp_Timer.Name = "gp_Timer";
			this.gp_Timer.Size = new System.Drawing.Size(173, 136);
			this.gp_Timer.TabIndex = 12;
			this.gp_Timer.TabStop = false;
			this.gp_Timer.Text = "Timer";
			// 
			// num_Freq
			// 
			this.num_Freq.Increment = new decimal(new int[] {
									5,
									0,
									0,
									0});
			this.num_Freq.Location = new System.Drawing.Point(6, 50);
			this.num_Freq.Maximum = new decimal(new int[] {
									3600,
									0,
									0,
									0});
			this.num_Freq.Minimum = new decimal(new int[] {
									5,
									0,
									0,
									0});
			this.num_Freq.Name = "num_Freq";
			this.num_Freq.Size = new System.Drawing.Size(93, 20);
			this.num_Freq.TabIndex = 4;
			this.num_Freq.Value = new decimal(new int[] {
									10,
									0,
									0,
									0});
			// 
			// cb_AutoStart
			// 
			this.cb_AutoStart.Location = new System.Drawing.Point(13, 93);
			this.cb_AutoStart.Name = "cb_AutoStart";
			this.cb_AutoStart.Size = new System.Drawing.Size(104, 24);
			this.cb_AutoStart.TabIndex = 11;
			this.cb_AutoStart.Text = "Auto start Timer";
			this.cb_AutoStart.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(161, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Fréquence (en secondes)";
			// 
			// b_Apply
			// 
			this.b_Apply.Location = new System.Drawing.Point(288, 376);
			this.b_Apply.Name = "b_Apply";
			this.b_Apply.Size = new System.Drawing.Size(139, 23);
			this.b_Apply.TabIndex = 8;
			this.b_Apply.Text = "Appliquer";
			this.b_Apply.UseVisualStyleBackColor = true;
			this.b_Apply.Click += new System.EventHandler(this.B_ApplyClick);
			// 
			// gb_WatchType
			// 
			this.gb_WatchType.Controls.Add(this.rb_isFsWatch);
			this.gb_WatchType.Controls.Add(this.rb_isTimer);
			this.gb_WatchType.Location = new System.Drawing.Point(8, 234);
			this.gb_WatchType.Name = "gb_WatchType";
			this.gb_WatchType.Size = new System.Drawing.Size(212, 136);
			this.gb_WatchType.TabIndex = 3;
			this.gb_WatchType.TabStop = false;
			this.gb_WatchType.Text = "Methode de Suivi";
			// 
			// rb_isFsWatch
			// 
			this.rb_isFsWatch.Location = new System.Drawing.Point(34, 60);
			this.rb_isFsWatch.Name = "rb_isFsWatch";
			this.rb_isFsWatch.Size = new System.Drawing.Size(261, 24);
			this.rb_isFsWatch.TabIndex = 1;
			this.rb_isFsWatch.TabStop = true;
			this.rb_isFsWatch.Text = "FileSystemWatcher";
			this.rb_isFsWatch.UseVisualStyleBackColor = true;
			// 
			// rb_isTimer
			// 
			this.rb_isTimer.Location = new System.Drawing.Point(34, 30);
			this.rb_isTimer.Name = "rb_isTimer";
			this.rb_isTimer.Size = new System.Drawing.Size(284, 24);
			this.rb_isTimer.TabIndex = 0;
			this.rb_isTimer.TabStop = true;
			this.rb_isTimer.Text = "Timer (si disque réseau etc...)";
			this.rb_isTimer.UseVisualStyleBackColor = true;
			this.rb_isTimer.CheckedChanged += new System.EventHandler(this.Rb_isTimerCheckedChanged);
			// 
			// fileSystemWatcher1
			// 
			this.fileSystemWatcher1.EnableRaisingEvents = true;
			this.fileSystemWatcher1.SynchronizingObject = this;
			this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.FileSystemWatcher1Changed);
			this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.FileSystemWatcher1Deleted);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fermerToolStripMenuItem,
									this.fermerEtSupprimerFichierToolStripMenuItem,
									this.fermerEtViderFichierToolStripMenuItem,
									this.HtmlDisplayToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(219, 114);
			// 
			// fermerToolStripMenuItem
			// 
			this.fermerToolStripMenuItem.Name = "fermerToolStripMenuItem";
			this.fermerToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.fermerToolStripMenuItem.Text = "&Fermer";
			this.fermerToolStripMenuItem.Click += new System.EventHandler(this.FermerToolStripMenuItemClick);
			// 
			// fermerEtSupprimerFichierToolStripMenuItem
			// 
			this.fermerEtSupprimerFichierToolStripMenuItem.Name = "fermerEtSupprimerFichierToolStripMenuItem";
			this.fermerEtSupprimerFichierToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.fermerEtSupprimerFichierToolStripMenuItem.Text = "Fermer et &Supprimer fichier";
			this.fermerEtSupprimerFichierToolStripMenuItem.Click += new System.EventHandler(this.FermerEtSupprimerFichierToolStripMenuItemClick);
			// 
			// fermerEtViderFichierToolStripMenuItem
			// 
			this.fermerEtViderFichierToolStripMenuItem.Name = "fermerEtViderFichierToolStripMenuItem";
			this.fermerEtViderFichierToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.fermerEtViderFichierToolStripMenuItem.Text = "Fermer et &Vider Fichier";
			this.fermerEtViderFichierToolStripMenuItem.Click += new System.EventHandler(this.FermerEtViderFichierToolStripMenuItemClick);
			// 
			// HtmlDisplayToolStripMenuItem
			// 
			this.HtmlDisplayToolStripMenuItem.Name = "HtmlDisplayToolStripMenuItem";
			this.HtmlDisplayToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.HtmlDisplayToolStripMenuItem.Text = "HTML Mode";
			this.HtmlDisplayToolStripMenuItem.CheckedChanged += new System.EventHandler(this.HtmlDisplayToolStripMenuItemCheckedChanged);
			this.HtmlDisplayToolStripMenuItem.Click += new System.EventHandler(this.HtmlDisplayToolStripMenuItemClick);
			// 
			// contextMenuStrip2
			// 
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toutFermerToolStripMenuItem,
									this.toutFermerEtSupprimerLesFichiersToolStripMenuItem});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new System.Drawing.Size(269, 70);
			// 
			// toutFermerToolStripMenuItem
			// 
			this.toutFermerToolStripMenuItem.Name = "toutFermerToolStripMenuItem";
			this.toutFermerToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
			this.toutFermerToolStripMenuItem.Text = "Tout Fermer";
			// 
			// toutFermerEtSupprimerLesFichiersToolStripMenuItem
			// 
			this.toutFermerEtSupprimerLesFichiersToolStripMenuItem.Name = "toutFermerEtSupprimerLesFichiersToolStripMenuItem";
			this.toutFermerEtSupprimerLesFichiersToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
			this.toutFermerEtSupprimerLesFichiersToolStripMenuItem.Text = "Tout Fermer et Supprimer les fichiers";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1256, 537);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "WebLogViewver";
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseUp);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.gp_Files.ResumeLayout(false);
			this.gp_Files.PerformLayout();
			this.gp_Timer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.num_Freq)).EndInit();
			this.gb_WatchType.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.contextMenuStrip2.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripMenuItem toutFermerEtSupprimerLesFichiersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toutFermerToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
		private System.Windows.Forms.Label lbl_Path;
		private System.Windows.Forms.ToolStripMenuItem HtmlDisplayToolStripMenuItem;
		private System.Windows.Forms.ComboBox cb_Path;
		private System.Windows.Forms.ToolStripMenuItem fermerEtViderFichierToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fermerEtSupprimerFichierToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fermerToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.GroupBox gp_Timer;
		private System.Windows.Forms.GroupBox gp_Files;
		private System.Windows.Forms.CheckBox cb_AutoStart;
		private System.Windows.Forms.Button b_TimerButton;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button b_Apply;
		private System.Windows.Forms.TextBox tb_Filtre;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown num_Freq;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.RadioButton rb_isTimer;
		private System.Windows.Forms.RadioButton rb_isFsWatch;
		private System.Windows.Forms.GroupBox gb_WatchType;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.IO.FileSystemWatcher fileSystemWatcher1;
		private System.Windows.Forms.Button b_ChangeDir;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
	}
}
