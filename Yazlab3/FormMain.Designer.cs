namespace Yazlab3
{
    partial class FormMain
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
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnGraphView = new System.Windows.Forms.Button();
            this.btnControlPnl = new System.Windows.Forms.Button();
            this.btnMaxFlow = new System.Windows.Forms.Button();
            this.inputControls = new Yazlab3.UserControls.InputControls();
            this.graphView = new Yazlab3.UserControls.GraphView();
            this.btnMaxFlowPaths = new System.Windows.Forms.Button();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.btnMaxFlowPaths);
            this.pnlLeft.Controls.Add(this.btnMaxFlow);
            this.pnlLeft.Controls.Add(this.btnGraphView);
            this.pnlLeft.Controls.Add(this.btnControlPnl);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(111, 355);
            this.pnlLeft.TabIndex = 0;
            // 
            // btnGraphView
            // 
            this.btnGraphView.Location = new System.Drawing.Point(12, 69);
            this.btnGraphView.Name = "btnGraphView";
            this.btnGraphView.Size = new System.Drawing.Size(84, 35);
            this.btnGraphView.TabIndex = 1;
            this.btnGraphView.Text = "Graph";
            this.btnGraphView.UseVisualStyleBackColor = true;
            this.btnGraphView.Click += new System.EventHandler(this.btnGraphView_Click);
            // 
            // btnControlPnl
            // 
            this.btnControlPnl.Location = new System.Drawing.Point(12, 28);
            this.btnControlPnl.Name = "btnControlPnl";
            this.btnControlPnl.Size = new System.Drawing.Size(84, 35);
            this.btnControlPnl.TabIndex = 0;
            this.btnControlPnl.Text = "Kontrol Paneli";
            this.btnControlPnl.UseVisualStyleBackColor = true;
            this.btnControlPnl.Click += new System.EventHandler(this.btnControlPnl_Click);
            // 
            // btnMaxFlow
            // 
            this.btnMaxFlow.Location = new System.Drawing.Point(12, 131);
            this.btnMaxFlow.Name = "btnMaxFlow";
            this.btnMaxFlow.Size = new System.Drawing.Size(84, 35);
            this.btnMaxFlow.TabIndex = 2;
            this.btnMaxFlow.Text = "Max Flow";
            this.btnMaxFlow.UseVisualStyleBackColor = true;
            this.btnMaxFlow.Click += new System.EventHandler(this.btnMaxFlow_Click);
            // 
            // inputControls
            // 
            this.inputControls.AutoScroll = true;
            this.inputControls.Location = new System.Drawing.Point(117, 12);
            this.inputControls.Name = "inputControls";
            this.inputControls.Size = new System.Drawing.Size(449, 331);
            this.inputControls.TabIndex = 3;
            // 
            // graphView
            // 
            this.graphView.Location = new System.Drawing.Point(117, 12);
            this.graphView.Name = "graphView";
            this.graphView.Size = new System.Drawing.Size(466, 343);
            this.graphView.TabIndex = 2;
            // 
            // btnMaxFlowPaths
            // 
            this.btnMaxFlowPaths.Location = new System.Drawing.Point(12, 172);
            this.btnMaxFlowPaths.Name = "btnMaxFlowPaths";
            this.btnMaxFlowPaths.Size = new System.Drawing.Size(84, 35);
            this.btnMaxFlowPaths.TabIndex = 3;
            this.btnMaxFlowPaths.Text = "Max Flow Paths";
            this.btnMaxFlowPaths.UseVisualStyleBackColor = true;
            this.btnMaxFlowPaths.Click += new System.EventHandler(this.btnMaxFlowPaths_Click);
            // 
            // FormMain
            // 
            this.ClientSize = new System.Drawing.Size(595, 355);
            this.Controls.Add(this.inputControls);
            this.Controls.Add(this.graphView);
            this.Controls.Add(this.pnlLeft);
            this.Name = "FormMain";
            this.Text = "Yazlab3";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnlLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Button btnGraphView;
        private System.Windows.Forms.Button btnControlPnl;
        private UserControls.GraphView graphView;
        private UserControls.InputControls inputControls;
        private System.Windows.Forms.Button btnMaxFlow;
        private System.Windows.Forms.Button btnMaxFlowPaths;
    }
}

