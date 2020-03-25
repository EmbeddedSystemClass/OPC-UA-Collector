namespace ServerCollector.Forms
{
    partial class NodeSelector
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
            this.BrowseServerPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.serverBrowseNodeCTRL1 = new ServerCollector.Forms.ServerBrowseNodeCTRL();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.selected = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BrowseServerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BrowseServerPanel
            // 
            this.BrowseServerPanel.Controls.Add(this.splitContainer1);
            this.BrowseServerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BrowseServerPanel.Location = new System.Drawing.Point(0, 0);
            this.BrowseServerPanel.Name = "BrowseServerPanel";
            this.BrowseServerPanel.Size = new System.Drawing.Size(800, 335);
            this.BrowseServerPanel.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.serverBrowseNodeCTRL1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 335);
            this.splitContainer1.SplitterDistance = 485;
            this.splitContainer1.TabIndex = 5;
            // 
            // serverBrowseNodeCTRL1
            // 
            this.serverBrowseNodeCTRL1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverBrowseNodeCTRL1.Location = new System.Drawing.Point(0, 0);
            this.serverBrowseNodeCTRL1.Name = "serverBrowseNodeCTRL1";
            this.serverBrowseNodeCTRL1.Size = new System.Drawing.Size(485, 335);
            this.serverBrowseNodeCTRL1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // selected
            // 
            this.selected.Location = new System.Drawing.Point(683, 3);
            this.selected.Name = "selected";
            this.selected.Size = new System.Drawing.Size(114, 28);
            this.selected.TabIndex = 3;
            this.selected.Text = "select Node";
            this.selected.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.selected);
            this.panel2.Location = new System.Drawing.Point(0, 390);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 35);
            this.panel2.TabIndex = 4;
            // 
            // NodeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.BrowseServerPanel);
            this.Name = "NodeSelector";
            this.Text = "NodeSelector";
            this.BrowseServerPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel BrowseServerPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button selected;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ServerBrowseNodeCTRL serverBrowseNodeCTRL1;
    }
}