namespace Client
{
    partial class connectorForm
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
            this.components = new System.ComponentModel.Container();
            this.endpointSelectorCtrlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.EndpointSelectorCtrl = new Opc.Ua.Client.Controls.EndpointSelectorCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.endpointSelectorCtrlBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // endpointSelectorCtrlBindingSource
            // 
            this.endpointSelectorCtrlBindingSource.DataSource = typeof(Opc.Ua.Client.Controls.EndpointSelectorCtrl);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 64);
            this.panel1.TabIndex = 0;
            // 
            // connectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 450);
            this.Controls.Add(this.panel1);
            this.Name = "connectorForm";
            this.Text = "connectorForm";
            ((System.ComponentModel.ISupportInitialize)(this.endpointSelectorCtrlBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Opc.Ua.Client.Controls.EndpointSelectorCtrl EndpointSelectorCtrl;
        private System.Windows.Forms.BindingSource endpointSelectorCtrlBindingSource;
        private System.Windows.Forms.Panel panel1;
    }
}