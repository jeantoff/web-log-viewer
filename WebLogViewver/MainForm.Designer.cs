﻿/*
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
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabConfig = new System.Windows.Forms.TabPage();
			this.cb_ConfirmDeletes = new System.Windows.Forms.CheckBox();
			this.gp_Files = new System.Windows.Forms.GroupBox();
			this.cb_Path = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.b_ChangeDir = new System.Windows.Forms.Button();
			this.tb_Filtre = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.gp_Timer = new System.Windows.Forms.GroupBox();
			this.num_Freq = new System.Windows.Forms.NumericUpDown();
			this.cb_AutoStart = new System.Windows.Forms.CheckBox();
			this.b_TimerButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.b_Apply = new System.Windows.Forms.Button();
			this.gb_WatchType = new System.Windows.Forms.GroupBox();
			this.rb_isFsWatch = new System.Windows.Forms.RadioButton();
			this.rb_isTimer = new System.Windows.Forms.RadioButton();
			this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.contextMenuStripFileTabs = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CloseAndDeleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CloseAndEmptyFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HtmlDisplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ouvrirDossierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStripConfigTab = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toutCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toutFermerEtSupprimerLesFichiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1.SuspendLayout();
			this.tabConfig.SuspendLayout();
			this.gp_Files.SuspendLayout();
			this.gp_Timer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_Freq)).BeginInit();
			this.gb_WatchType.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
			this.contextMenuStripFileTabs.SuspendLayout();
			this.contextMenuStripConfigTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.AllowDrop = true;
			this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
			this.tabControl1.Controls.Add(this.tabConfig);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.ShowToolTips = true;
			this.tabControl1.Size = new System.Drawing.Size(691, 475);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseUp);
			// 
			// tabConfig
			// 
			this.tabConfig.AutoScroll = true;
			this.tabConfig.Controls.Add(this.cb_ConfirmDeletes);
			this.tabConfig.Controls.Add(this.gp_Files);
			this.tabConfig.Controls.Add(this.gp_Timer);
			this.tabConfig.Controls.Add(this.b_Apply);
			this.tabConfig.Controls.Add(this.gb_WatchType);
			this.tabConfig.Location = new System.Drawing.Point(4, 25);
			this.tabConfig.Name = "tabConfig";
			this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
			this.tabConfig.Size = new System.Drawing.Size(683, 446);
			this.tabConfig.TabIndex = 0;
			this.tabConfig.Text = "Config";
			this.tabConfig.UseVisualStyleBackColor = true;
			this.tabConfig.Click += new System.EventHandler(this.TabConfigClick);
			// 
			// cb_ConfirmDeletes
			// 
			this.cb_ConfirmDeletes.Location = new System.Drawing.Point(14, 253);
			this.cb_ConfirmDeletes.Name = "cb_ConfirmDeletes";
			this.cb_ConfirmDeletes.Size = new System.Drawing.Size(212, 34);
			this.cb_ConfirmDeletes.TabIndex = 14;
			this.cb_ConfirmDeletes.Text = "Confirmer les suppressions et vidages de fichiers";
			this.cb_ConfirmDeletes.ThreeState = true;
			this.cb_ConfirmDeletes.UseVisualStyleBackColor = true;
			// 
			// gp_Files
			// 
			this.gp_Files.Controls.Add(this.cb_Path);
			this.gp_Files.Controls.Add(this.label1);
			this.gp_Files.Controls.Add(this.b_ChangeDir);
			this.gp_Files.Controls.Add(this.tb_Filtre);
			this.gp_Files.Controls.Add(this.label3);
			this.gp_Files.Location = new System.Drawing.Point(8, 6);
			this.gp_Files.Name = "gp_Files";
			this.gp_Files.Size = new System.Drawing.Size(579, 110);
			this.gp_Files.TabIndex = 13;
			this.gp_Files.TabStop = false;
			this.gp_Files.Text = "Fichiers";
			// 
			// cb_Path
			// 
			this.cb_Path.FormattingEnabled = true;
			this.cb_Path.Location = new System.Drawing.Point(137, 23);
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
			this.b_ChangeDir.Location = new System.Drawing.Point(509, 21);
			this.b_ChangeDir.Name = "b_ChangeDir";
			this.b_ChangeDir.Size = new System.Drawing.Size(35, 23);
			this.b_ChangeDir.TabIndex = 1;
			this.b_ChangeDir.Text = "...";
			this.b_ChangeDir.UseVisualStyleBackColor = true;
			this.b_ChangeDir.Click += new System.EventHandler(this.B_ChangeDirClick);
			// 
			// tb_Filtre
			// 
			this.tb_Filtre.Location = new System.Drawing.Point(137, 55);
			this.tb_Filtre.Name = "tb_Filtre";
			this.tb_Filtre.Size = new System.Drawing.Size(100, 20);
			this.tb_Filtre.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Filtre fichiers";
			// 
			// gp_Timer
			// 
			this.gp_Timer.Controls.Add(this.num_Freq);
			this.gp_Timer.Controls.Add(this.cb_AutoStart);
			this.gp_Timer.Controls.Add(this.b_TimerButton);
			this.gp_Timer.Controls.Add(this.label2);
			this.gp_Timer.Location = new System.Drawing.Point(8, 190);
			this.gp_Timer.Name = "gp_Timer";
			this.gp_Timer.Size = new System.Drawing.Size(579, 57);
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
			this.num_Freq.Location = new System.Drawing.Point(208, 14);
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
			this.cb_AutoStart.Location = new System.Drawing.Point(332, 11);
			this.cb_AutoStart.Name = "cb_AutoStart";
			this.cb_AutoStart.Size = new System.Drawing.Size(104, 24);
			this.cb_AutoStart.TabIndex = 11;
			this.cb_AutoStart.Text = "Auto start Timer";
			this.cb_AutoStart.UseVisualStyleBackColor = true;
			// 
			// b_TimerButton
			// 
			this.b_TimerButton.Location = new System.Drawing.Point(469, 14);
			this.b_TimerButton.Name = "b_TimerButton";
			this.b_TimerButton.Size = new System.Drawing.Size(75, 23);
			this.b_TimerButton.TabIndex = 9;
			this.b_TimerButton.Text = "Démarrer";
			this.b_TimerButton.UseVisualStyleBackColor = true;
			this.b_TimerButton.Click += new System.EventHandler(this.B_TimerButtonClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(161, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Fréquence (en secondes)";
			// 
			// b_Apply
			// 
			this.b_Apply.Location = new System.Drawing.Point(413, 264);
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
			this.gb_WatchType.Location = new System.Drawing.Point(8, 122);
			this.gb_WatchType.Name = "gb_WatchType";
			this.gb_WatchType.Size = new System.Drawing.Size(579, 62);
			this.gb_WatchType.TabIndex = 3;
			this.gb_WatchType.TabStop = false;
			this.gb_WatchType.Text = "Methode de Suivi";
			// 
			// rb_isFsWatch
			// 
			this.rb_isFsWatch.Location = new System.Drawing.Point(214, 30);
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
			// contextMenuStripFileTabs
			// 
			this.contextMenuStripFileTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.CloseToolStripMenuItem,
									this.CloseAndDeleteFileToolStripMenuItem,
									this.CloseAndEmptyFileToolStripMenuItem,
									this.HtmlDisplayToolStripMenuItem,
									this.ouvrirDossierToolStripMenuItem});
			this.contextMenuStripFileTabs.Name = "contextMenuStripFileTabs";
			this.contextMenuStripFileTabs.Size = new System.Drawing.Size(219, 136);
			// 
			// CloseToolStripMenuItem
			// 
			this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
			this.CloseToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.CloseToolStripMenuItem.Text = "&Fermer";
			this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
			// 
			// CloseAndDeleteFileToolStripMenuItem
			// 
			this.CloseAndDeleteFileToolStripMenuItem.Name = "CloseAndDeleteFileToolStripMenuItem";
			this.CloseAndDeleteFileToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.CloseAndDeleteFileToolStripMenuItem.Text = "Fermer et &Supprimer fichier";
			this.CloseAndDeleteFileToolStripMenuItem.Click += new System.EventHandler(this.CloseAndDeleteFileToolStripMenuItemClick);
			// 
			// CloseAndEmptyFileToolStripMenuItem
			// 
			this.CloseAndEmptyFileToolStripMenuItem.Name = "CloseAndEmptyFileToolStripMenuItem";
			this.CloseAndEmptyFileToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.CloseAndEmptyFileToolStripMenuItem.Text = "Fermer et &Vider Fichier";
			this.CloseAndEmptyFileToolStripMenuItem.Click += new System.EventHandler(this.CloseAndEmptyFileToolStripMenuItemClick);
			// 
			// HtmlDisplayToolStripMenuItem
			// 
			this.HtmlDisplayToolStripMenuItem.Enabled = false;
			this.HtmlDisplayToolStripMenuItem.Name = "HtmlDisplayToolStripMenuItem";
			this.HtmlDisplayToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.HtmlDisplayToolStripMenuItem.Text = "HTML Mode";
			this.HtmlDisplayToolStripMenuItem.CheckedChanged += new System.EventHandler(this.HtmlDisplayToolStripMenuItemCheckedChanged);
			this.HtmlDisplayToolStripMenuItem.Click += new System.EventHandler(this.HtmlDisplayToolStripMenuItemClick);
			// 
			// ouvrirDossierToolStripMenuItem
			// 
			this.ouvrirDossierToolStripMenuItem.Name = "ouvrirDossierToolStripMenuItem";
			this.ouvrirDossierToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
			this.ouvrirDossierToolStripMenuItem.Text = "Ouvrir Dossier";
			this.ouvrirDossierToolStripMenuItem.Click += new System.EventHandler(this.OuvrirDossierToolStripMenuItemClick);
			// 
			// contextMenuStripConfigTab
			// 
			this.contextMenuStripConfigTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toutCloseToolStripMenuItem,
									this.toutFermerEtSupprimerLesFichiersToolStripMenuItem});
			this.contextMenuStripConfigTab.Name = "contextMenuStrip2";
			this.contextMenuStripConfigTab.Size = new System.Drawing.Size(269, 70);
			// 
			// toutCloseToolStripMenuItem
			// 
			this.toutCloseToolStripMenuItem.Name = "toutCloseToolStripMenuItem";
			this.toutCloseToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
			this.toutCloseToolStripMenuItem.Text = "Tout Fermer";
			this.toutCloseToolStripMenuItem.Click += new System.EventHandler(this.ToutCloseToolStripMenuItemClick);
			// 
			// toutFermerEtSupprimerLesFichiersToolStripMenuItem
			// 
			this.toutFermerEtSupprimerLesFichiersToolStripMenuItem.Name = "toutFermerEtSupprimerLesFichiersToolStripMenuItem";
			this.toutFermerEtSupprimerLesFichiersToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
			this.toutFermerEtSupprimerLesFichiersToolStripMenuItem.Text = "Tout Fermer et Supprimer les fichiers";
			this.toutFermerEtSupprimerLesFichiersToolStripMenuItem.Click += new System.EventHandler(this.ToutFermerEtSupprimerLesFichiersToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(691, 475);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "WebLogViewver";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseUp);
			this.tabControl1.ResumeLayout(false);
			this.tabConfig.ResumeLayout(false);
			this.gp_Files.ResumeLayout(false);
			this.gp_Files.PerformLayout();
			this.gp_Timer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.num_Freq)).EndInit();
			this.gb_WatchType.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
			this.contextMenuStripFileTabs.ResumeLayout(false);
			this.contextMenuStripConfigTab.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripMenuItem ouvrirDossierToolStripMenuItem;
		private System.Windows.Forms.CheckBox cb_ConfirmDeletes;
		private System.Windows.Forms.ToolStripMenuItem toutFermerEtSupprimerLesFichiersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toutCloseToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripConfigTab;
		private System.Windows.Forms.ToolStripMenuItem HtmlDisplayToolStripMenuItem;
		private System.Windows.Forms.ComboBox cb_Path;
		private System.Windows.Forms.ToolStripMenuItem CloseAndEmptyFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem CloseAndDeleteFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripFileTabs;
		private System.Windows.Forms.GroupBox gp_Timer;
		private System.Windows.Forms.GroupBox gp_Files;
		private System.Windows.Forms.CheckBox cb_AutoStart;
		private System.Windows.Forms.Button b_TimerButton;
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
		private System.Windows.Forms.TabPage tabConfig;
		private System.Windows.Forms.TabControl tabControl1;
	}
}
