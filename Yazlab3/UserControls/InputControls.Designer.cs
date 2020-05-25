namespace Yazlab3.UserControls
{
    partial class InputControls
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNodeCount = new System.Windows.Forms.Label();
            this.tbxNodeCount = new System.Windows.Forms.TextBox();
            this.btnNodeCount = new System.Windows.Forms.Button();
            this.pnlFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPipeCapacity = new System.Windows.Forms.Panel();
            this.btnPipeCapacity = new System.Windows.Forms.Button();
            this.lblPipeHeader = new System.Windows.Forms.Label();
            this.tbxPipe2Capacity = new System.Windows.Forms.TextBox();
            this.tbxPipe1Capacity = new System.Windows.Forms.TextBox();
            this.lblPipeName2 = new System.Windows.Forms.Label();
            this.lblPipeName1 = new System.Windows.Forms.Label();
            this.pnlSelectPoints = new System.Windows.Forms.Panel();
            this.btnSelectPoints = new System.Windows.Forms.Button();
            this.tbxEndPoint = new System.Windows.Forms.TextBox();
            this.tbxStartingPoint = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlPipeCapacity.SuspendLayout();
            this.pnlSelectPoints.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNodeCount
            // 
            this.lblNodeCount.AutoSize = true;
            this.lblNodeCount.Location = new System.Drawing.Point(42, 11);
            this.lblNodeCount.Name = "lblNodeCount";
            this.lblNodeCount.Size = new System.Drawing.Size(69, 13);
            this.lblNodeCount.TabIndex = 0;
            this.lblNodeCount.Text = "Düğüm sayısı";
            // 
            // tbxNodeCount
            // 
            this.tbxNodeCount.Location = new System.Drawing.Point(118, 11);
            this.tbxNodeCount.Name = "tbxNodeCount";
            this.tbxNodeCount.Size = new System.Drawing.Size(100, 20);
            this.tbxNodeCount.TabIndex = 1;
            this.tbxNodeCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxNodeCount_KeyDown);
            // 
            // btnNodeCount
            // 
            this.btnNodeCount.Location = new System.Drawing.Point(235, 7);
            this.btnNodeCount.Name = "btnNodeCount";
            this.btnNodeCount.Size = new System.Drawing.Size(75, 23);
            this.btnNodeCount.TabIndex = 2;
            this.btnNodeCount.Text = "Tamam";
            this.btnNodeCount.UseVisualStyleBackColor = true;
            this.btnNodeCount.Click += new System.EventHandler(this.btnNodeCount_Click);
            // 
            // pnlFlowLayout
            // 
            this.pnlFlowLayout.AutoScroll = true;
            this.pnlFlowLayout.Location = new System.Drawing.Point(45, 50);
            this.pnlFlowLayout.Name = "pnlFlowLayout";
            this.pnlFlowLayout.Size = new System.Drawing.Size(135, 298);
            this.pnlFlowLayout.TabIndex = 3;
            // 
            // pnlPipeCapacity
            // 
            this.pnlPipeCapacity.Controls.Add(this.btnPipeCapacity);
            this.pnlPipeCapacity.Controls.Add(this.lblPipeHeader);
            this.pnlPipeCapacity.Controls.Add(this.tbxPipe2Capacity);
            this.pnlPipeCapacity.Controls.Add(this.tbxPipe1Capacity);
            this.pnlPipeCapacity.Controls.Add(this.lblPipeName2);
            this.pnlPipeCapacity.Controls.Add(this.lblPipeName1);
            this.pnlPipeCapacity.Location = new System.Drawing.Point(209, 192);
            this.pnlPipeCapacity.Name = "pnlPipeCapacity";
            this.pnlPipeCapacity.Size = new System.Drawing.Size(163, 156);
            this.pnlPipeCapacity.TabIndex = 4;
            // 
            // btnPipeCapacity
            // 
            this.btnPipeCapacity.Location = new System.Drawing.Point(61, 108);
            this.btnPipeCapacity.Name = "btnPipeCapacity";
            this.btnPipeCapacity.Size = new System.Drawing.Size(75, 23);
            this.btnPipeCapacity.TabIndex = 5;
            this.btnPipeCapacity.Text = "Tamam";
            this.btnPipeCapacity.UseVisualStyleBackColor = true;
            this.btnPipeCapacity.Click += new System.EventHandler(this.btnPipeCapacity_Click);
            // 
            // lblPipeHeader
            // 
            this.lblPipeHeader.AutoSize = true;
            this.lblPipeHeader.Location = new System.Drawing.Point(25, 0);
            this.lblPipeHeader.Name = "lblPipeHeader";
            this.lblPipeHeader.Size = new System.Drawing.Size(79, 13);
            this.lblPipeHeader.TabIndex = 4;
            this.lblPipeHeader.Text = "Boru kapasitesi";
            // 
            // tbxPipe2Capacity
            // 
            this.tbxPipe2Capacity.Location = new System.Drawing.Point(29, 77);
            this.tbxPipe2Capacity.Name = "tbxPipe2Capacity";
            this.tbxPipe2Capacity.Size = new System.Drawing.Size(100, 20);
            this.tbxPipe2Capacity.TabIndex = 3;
            // 
            // tbxPipe1Capacity
            // 
            this.tbxPipe1Capacity.Location = new System.Drawing.Point(29, 38);
            this.tbxPipe1Capacity.Name = "tbxPipe1Capacity";
            this.tbxPipe1Capacity.Size = new System.Drawing.Size(100, 20);
            this.tbxPipe1Capacity.TabIndex = 2;
            // 
            // lblPipeName2
            // 
            this.lblPipeName2.AutoSize = true;
            this.lblPipeName2.Location = new System.Drawing.Point(26, 61);
            this.lblPipeName2.Name = "lblPipeName2";
            this.lblPipeName2.Size = new System.Drawing.Size(35, 13);
            this.lblPipeName2.TabIndex = 1;
            this.lblPipeName2.Text = "label2";
            // 
            // lblPipeName1
            // 
            this.lblPipeName1.AutoSize = true;
            this.lblPipeName1.Location = new System.Drawing.Point(26, 22);
            this.lblPipeName1.Name = "lblPipeName1";
            this.lblPipeName1.Size = new System.Drawing.Size(35, 13);
            this.lblPipeName1.TabIndex = 0;
            this.lblPipeName1.Text = "label1";
            // 
            // pnlSelectPoints
            // 
            this.pnlSelectPoints.Controls.Add(this.btnSelectPoints);
            this.pnlSelectPoints.Controls.Add(this.tbxEndPoint);
            this.pnlSelectPoints.Controls.Add(this.tbxStartingPoint);
            this.pnlSelectPoints.Controls.Add(this.label2);
            this.pnlSelectPoints.Controls.Add(this.label3);
            this.pnlSelectPoints.Location = new System.Drawing.Point(217, 50);
            this.pnlSelectPoints.Name = "pnlSelectPoints";
            this.pnlSelectPoints.Size = new System.Drawing.Size(155, 136);
            this.pnlSelectPoints.TabIndex = 6;
            // 
            // btnSelectPoints
            // 
            this.btnSelectPoints.Location = new System.Drawing.Point(45, 101);
            this.btnSelectPoints.Name = "btnSelectPoints";
            this.btnSelectPoints.Size = new System.Drawing.Size(75, 23);
            this.btnSelectPoints.TabIndex = 5;
            this.btnSelectPoints.Text = "Tamam";
            this.btnSelectPoints.UseVisualStyleBackColor = true;
            this.btnSelectPoints.Click += new System.EventHandler(this.btnSelectPoints_Click);
            // 
            // tbxEndPoint
            // 
            this.tbxEndPoint.Location = new System.Drawing.Point(20, 75);
            this.tbxEndPoint.Name = "tbxEndPoint";
            this.tbxEndPoint.Size = new System.Drawing.Size(100, 20);
            this.tbxEndPoint.TabIndex = 3;
            // 
            // tbxStartingPoint
            // 
            this.tbxStartingPoint.Location = new System.Drawing.Point(20, 23);
            this.tbxStartingPoint.Name = "tbxStartingPoint";
            this.tbxStartingPoint.Size = new System.Drawing.Size(100, 20);
            this.tbxStartingPoint.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bitiş noktası";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Başlangıç noktası";
            // 
            // InputControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlSelectPoints);
            this.Controls.Add(this.pnlPipeCapacity);
            this.Controls.Add(this.pnlFlowLayout);
            this.Controls.Add(this.btnNodeCount);
            this.Controls.Add(this.tbxNodeCount);
            this.Controls.Add(this.lblNodeCount);
            this.Name = "InputControls";
            this.Size = new System.Drawing.Size(449, 376);
            this.Load += new System.EventHandler(this.InputControls_Load);
            this.pnlPipeCapacity.ResumeLayout(false);
            this.pnlPipeCapacity.PerformLayout();
            this.pnlSelectPoints.ResumeLayout(false);
            this.pnlSelectPoints.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNodeCount;
        public System.Windows.Forms.TextBox tbxNodeCount;
        public System.Windows.Forms.Button btnNodeCount;
        public System.Windows.Forms.FlowLayoutPanel pnlFlowLayout;
        private System.Windows.Forms.TextBox tbxPipe2Capacity;
        private System.Windows.Forms.TextBox tbxPipe1Capacity;
        private System.Windows.Forms.Label lblPipeName2;
        private System.Windows.Forms.Label lblPipeName1;
        public System.Windows.Forms.Panel pnlPipeCapacity;
        private System.Windows.Forms.Label lblPipeHeader;
        private System.Windows.Forms.Button btnPipeCapacity;
        public System.Windows.Forms.Panel pnlSelectPoints;
        private System.Windows.Forms.Button btnSelectPoints;
        private System.Windows.Forms.TextBox tbxEndPoint;
        private System.Windows.Forms.TextBox tbxStartingPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
