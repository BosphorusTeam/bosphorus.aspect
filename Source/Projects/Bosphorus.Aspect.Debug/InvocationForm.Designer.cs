namespace Bosphorus.Aspect.Debug
{
    partial class InvocationForm
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
            this.pnlControl = new System.Windows.Forms.Panel();
            this.pgInvocationOwner = new System.Windows.Forms.PropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnRevert = new System.Windows.Forms.Button();
            this.btnProceed = new System.Windows.Forms.Button();
            this.tcArguments = new System.Windows.Forms.TabControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.pgInvocationOwner);
            this.pnlControl.Controls.Add(this.panel1);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlControl.Location = new System.Drawing.Point(0, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(264, 514);
            this.pnlControl.TabIndex = 1;
            // 
            // pgInvocationOwner
            // 
            this.pgInvocationOwner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgInvocationOwner.Location = new System.Drawing.Point(0, 0);
            this.pgInvocationOwner.Name = "pgInvocationOwner";
            this.pgInvocationOwner.Size = new System.Drawing.Size(264, 462);
            this.pgInvocationOwner.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnContinue);
            this.panel1.Controls.Add(this.btnRevert);
            this.panel1.Controls.Add(this.btnProceed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 462);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 52);
            this.panel1.TabIndex = 3;
            // 
            // btnContinue
            // 
            this.btnContinue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnContinue.Enabled = false;
            this.btnContinue.Location = new System.Drawing.Point(174, 15);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 6;
            this.btnContinue.Text = "Continue";
            this.btnContinue.UseVisualStyleBackColor = true;
            // 
            // btnRevert
            // 
            this.btnRevert.Enabled = false;
            this.btnRevert.Location = new System.Drawing.Point(93, 15);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(75, 23);
            this.btnRevert.TabIndex = 5;
            this.btnRevert.Text = "Revert";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // btnProceed
            // 
            this.btnProceed.Location = new System.Drawing.Point(12, 15);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(75, 23);
            this.btnProceed.TabIndex = 2;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // tcArguments
            // 
            this.tcArguments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcArguments.Location = new System.Drawing.Point(264, 0);
            this.tcArguments.Name = "tcArguments";
            this.tcArguments.SelectedIndex = 0;
            this.tcArguments.Size = new System.Drawing.Size(764, 514);
            this.tcArguments.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(264, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 514);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // InvocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 514);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tcArguments);
            this.Controls.Add(this.pnlControl);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Name = "InvocationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InvocationForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlControl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.TabControl tcArguments;
        private System.Windows.Forms.PropertyGrid pgInvocationOwner;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.Button btnContinue;
    }
}