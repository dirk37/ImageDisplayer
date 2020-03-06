namespace ImageDisplayer
{
    partial class Form1
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.autoArrangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeImageToolStripMenuItem,
            this.sendToBackToolStripMenuItem,
            this.autoArrangeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // closeImageToolStripMenuItem
            // 
            this.closeImageToolStripMenuItem.Name = "closeImageToolStripMenuItem";
            this.closeImageToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.closeImageToolStripMenuItem.Text = "Close Image";
            this.closeImageToolStripMenuItem.Click += new System.EventHandler(this.closeImageToolStripMenuItem_Click);
            // 
            // sendToBackToolStripMenuItem
            // 
            this.sendToBackToolStripMenuItem.Name = "sendToBackToolStripMenuItem";
            this.sendToBackToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.sendToBackToolStripMenuItem.Text = "Send to Back";
            this.sendToBackToolStripMenuItem.Click += new System.EventHandler(this.sendToBackToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Double Click to bring to front";
            // 
            // autoArrangeToolStripMenuItem
            // 
            this.autoArrangeToolStripMenuItem.Name = "autoArrangeToolStripMenuItem";
            this.autoArrangeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.autoArrangeToolStripMenuItem.Text = "AutoArrange";
            this.autoArrangeToolStripMenuItem.Click += new System.EventHandler(this.autoArrangeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(971, 847);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Image Disp";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragDropHandler);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.DragOverHandler);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToBackToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem autoArrangeToolStripMenuItem;
    }
}

