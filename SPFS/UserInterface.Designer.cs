namespace SPFS
{
    partial class UserInterface
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelAuth = new System.Windows.Forms.Panel();
            this.TbLogin = new System.Windows.Forms.TextBox();
            this.TbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnEnter = new System.Windows.Forms.Button();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиСервераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TbFind = new System.Windows.Forms.ToolStripTextBox();
            this.MenuFind = new System.Windows.Forms.ToolStripMenuItem();
            this.DG1 = new System.Windows.Forms.DataGridView();
            this.BtnExpander = new System.Windows.Forms.Button();
            this.LbCriterion = new System.Windows.Forms.ListBox();
            this.Split = new System.Windows.Forms.SplitContainer();
            this.PanelAuth.SuspendLayout();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Split)).BeginInit();
            this.Split.Panel1.SuspendLayout();
            this.Split.Panel2.SuspendLayout();
            this.Split.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelAuth
            // 
            this.PanelAuth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelAuth.Controls.Add(this.TbLogin);
            this.PanelAuth.Controls.Add(this.TbPassword);
            this.PanelAuth.Controls.Add(this.label2);
            this.PanelAuth.Controls.Add(this.label1);
            this.PanelAuth.Controls.Add(this.BtnEnter);
            this.PanelAuth.Location = new System.Drawing.Point(459, 248);
            this.PanelAuth.Name = "PanelAuth";
            this.PanelAuth.Size = new System.Drawing.Size(181, 107);
            this.PanelAuth.TabIndex = 0;
            // 
            // TbLogin
            // 
            this.TbLogin.Location = new System.Drawing.Point(66, 11);
            this.TbLogin.Name = "TbLogin";
            this.TbLogin.Size = new System.Drawing.Size(100, 20);
            this.TbLogin.TabIndex = 0;
            // 
            // TbPassword
            // 
            this.TbPassword.Location = new System.Drawing.Point(66, 37);
            this.TbPassword.Name = "TbPassword";
            this.TbPassword.PasswordChar = '*';
            this.TbPassword.Size = new System.Drawing.Size(100, 20);
            this.TbPassword.TabIndex = 1;
            this.TbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbPassword_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Логин";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnEnter
            // 
            this.BtnEnter.Location = new System.Drawing.Point(18, 63);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(148, 31);
            this.BtnEnter.TabIndex = 2;
            this.BtnEnter.Text = "Войти";
            this.BtnEnter.UseVisualStyleBackColor = true;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // Menu
            // 
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.TbFind,
            this.MenuFind});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(1133, 27);
            this.Menu.TabIndex = 1;
            this.Menu.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.печатьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 23);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.печатьToolStripMenuItem.Text = "Печать...";
            this.печатьToolStripMenuItem.Click += new System.EventHandler(this.печатьToolStripMenuItem_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 23);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиСервераToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 23);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // настройкиСервераToolStripMenuItem
            // 
            this.настройкиСервераToolStripMenuItem.Name = "настройкиСервераToolStripMenuItem";
            this.настройкиСервераToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.настройкиСервераToolStripMenuItem.Text = "Настройки сервера";
            this.настройкиСервераToolStripMenuItem.Click += new System.EventHandler(this.настройкиСервераToolStripMenuItem_Click);
            // 
            // TbFind
            // 
            this.TbFind.Name = "TbFind";
            this.TbFind.Size = new System.Drawing.Size(100, 23);
            this.TbFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbFind_KeyDown);
            // 
            // MenuFind
            // 
            this.MenuFind.Name = "MenuFind";
            this.MenuFind.Size = new System.Drawing.Size(54, 23);
            this.MenuFind.Text = "Поиск";
            this.MenuFind.Click += new System.EventHandler(this.MenuFind_Click);
            // 
            // DG1
            // 
            this.DG1.AllowUserToAddRows = false;
            this.DG1.AllowUserToDeleteRows = false;
            this.DG1.AllowUserToOrderColumns = true;
            this.DG1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG1.Location = new System.Drawing.Point(0, 0);
            this.DG1.Name = "DG1";
            this.DG1.RowHeadersVisible = false;
            this.DG1.Size = new System.Drawing.Size(937, 703);
            this.DG1.TabIndex = 2;
            this.DG1.Visible = false;
            this.DG1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG1_CellEndEdit);
            // 
            // BtnExpander
            // 
            this.BtnExpander.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnExpander.Location = new System.Drawing.Point(937, 221);
            this.BtnExpander.Margin = new System.Windows.Forms.Padding(0);
            this.BtnExpander.Name = "BtnExpander";
            this.BtnExpander.Size = new System.Drawing.Size(10, 119);
            this.BtnExpander.TabIndex = 3;
            this.BtnExpander.Text = "&#9668";
            this.BtnExpander.UseVisualStyleBackColor = true;
            this.BtnExpander.Visible = false;
            this.BtnExpander.Click += new System.EventHandler(this.button1_Click);
            // 
            // LbCriterion
            // 
            this.LbCriterion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbCriterion.FormattingEnabled = true;
            this.LbCriterion.Location = new System.Drawing.Point(0, 0);
            this.LbCriterion.Name = "LbCriterion";
            this.LbCriterion.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.LbCriterion.Size = new System.Drawing.Size(192, 703);
            this.LbCriterion.TabIndex = 0;
            this.LbCriterion.Click += new System.EventHandler(this.LbCriterion_Click);
            this.LbCriterion.SelectedIndexChanged += new System.EventHandler(this.LbCriterion_SelectedIndexChanged);
            // 
            // Split
            // 
            this.Split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Split.Location = new System.Drawing.Point(0, 27);
            this.Split.Name = "Split";
            // 
            // Split.Panel1
            // 
            this.Split.Panel1.Controls.Add(this.DG1);
            this.Split.Panel1MinSize = 400;
            // 
            // Split.Panel2
            // 
            this.Split.Panel2.Controls.Add(this.LbCriterion);
            this.Split.Panel2MinSize = 0;
            this.Split.Size = new System.Drawing.Size(1133, 703);
            this.Split.SplitterDistance = 937;
            this.Split.TabIndex = 6;
            this.Split.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 730);
            this.Controls.Add(this.BtnExpander);
            this.Controls.Add(this.PanelAuth);
            this.Controls.Add(this.Split);
            this.Controls.Add(this.Menu);
            this.MainMenuStrip = this.Menu;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Экран состояния пассажирских обустройств";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.PanelAuth.ResumeLayout(false);
            this.PanelAuth.PerformLayout();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG1)).EndInit();
            this.Split.Panel1.ResumeLayout(false);
            this.Split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Split)).EndInit();
            this.Split.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelAuth;
        private System.Windows.Forms.TextBox TbLogin;
        private System.Windows.Forms.TextBox TbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnEnter;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиСервераToolStripMenuItem;
        private System.Windows.Forms.DataGridView DG1;
        private System.Windows.Forms.Button BtnExpander;
        private System.Windows.Forms.ListBox LbCriterion;
        private System.Windows.Forms.ToolStripTextBox TbFind;
        private System.Windows.Forms.ToolStripMenuItem MenuFind;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Windows.Forms.SplitContainer Split;
    }
}

