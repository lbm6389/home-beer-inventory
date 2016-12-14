namespace HomeBeerInventory
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addBeerButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewBeerDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToExistingDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFromCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addBeerButton
            // 
            this.addBeerButton.Location = new System.Drawing.Point(88, 191);
            this.addBeerButton.Name = "addBeerButton";
            this.addBeerButton.Size = new System.Drawing.Size(75, 23);
            this.addBeerButton.TabIndex = 0;
            this.addBeerButton.Text = "Add Beer";
            this.addBeerButton.UseVisualStyleBackColor = true;
            this.addBeerButton.Click += new System.EventHandler(this.addBeerButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToExistingDatabaseToolStripMenuItem,
            this.createNewBeerDatabaseToolStripMenuItem,
            this.createFromCSVToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // createNewBeerDatabaseToolStripMenuItem
            // 
            this.createNewBeerDatabaseToolStripMenuItem.Name = "createNewBeerDatabaseToolStripMenuItem";
            this.createNewBeerDatabaseToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.createNewBeerDatabaseToolStripMenuItem.Text = "Create New Beer Database";
            this.createNewBeerDatabaseToolStripMenuItem.Click += new System.EventHandler(this.createNewBeerDatabaseToolStripMenuItem_Click);
            // 
            // connectToExistingDatabaseToolStripMenuItem
            // 
            this.connectToExistingDatabaseToolStripMenuItem.Name = "connectToExistingDatabaseToolStripMenuItem";
            this.connectToExistingDatabaseToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.connectToExistingDatabaseToolStripMenuItem.Text = "Connect to Existing Database";
            this.connectToExistingDatabaseToolStripMenuItem.Click += new System.EventHandler(this.connectToExistingDatabaseToolStripMenuItem_Click);
            // 
            // createFromCSVToolStripMenuItem
            // 
            this.createFromCSVToolStripMenuItem.Name = "createFromCSVToolStripMenuItem";
            this.createFromCSVToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.createFromCSVToolStripMenuItem.Text = "Create from CSV";
            this.createFromCSVToolStripMenuItem.Click += new System.EventHandler(this.createFromCSVToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.addBeerButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Home Beer Inventory";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addBeerButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewBeerDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToExistingDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFromCSVToolStripMenuItem;
    }
}

