
namespace CompareFilesDiffInFolder
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCompare = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSetSourceFolder = new System.Windows.Forms.Button();
            this.labSource = new System.Windows.Forms.Label();
            this.labTarget = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(916, 440);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(108, 42);
            this.btnCompare.TabIndex = 0;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 143);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(898, 339);
            this.txtLog.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(24, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 36);
            this.button2.TabIndex = 5;
            this.button2.Text = "SetTargetFolder";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSetSourceFolder
            // 
            this.btnSetSourceFolder.Location = new System.Drawing.Point(24, 27);
            this.btnSetSourceFolder.Name = "btnSetSourceFolder";
            this.btnSetSourceFolder.Size = new System.Drawing.Size(140, 34);
            this.btnSetSourceFolder.TabIndex = 4;
            this.btnSetSourceFolder.Text = "SetSourceFolder";
            this.btnSetSourceFolder.UseVisualStyleBackColor = true;
            this.btnSetSourceFolder.Click += new System.EventHandler(this.btnSetSourceFolder_Click);
            // 
            // labSource
            // 
            this.labSource.AutoSize = true;
            this.labSource.Location = new System.Drawing.Point(189, 43);
            this.labSource.Name = "labSource";
            this.labSource.Size = new System.Drawing.Size(153, 18);
            this.labSource.TabIndex = 6;
            this.labSource.Text = "Please Select Source";
            // 
            // labTarget
            // 
            this.labTarget.AutoSize = true;
            this.labTarget.Location = new System.Drawing.Point(189, 96);
            this.labTarget.Name = "labTarget";
            this.labTarget.Size = new System.Drawing.Size(151, 18);
            this.labTarget.TabIndex = 7;
            this.labTarget.Text = "Please Select Target";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 512);
            this.Controls.Add(this.labTarget);
            this.Controls.Add(this.labSource);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSetSourceFolder);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnCompare);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSetSourceFolder;
        private System.Windows.Forms.Label labSource;
        private System.Windows.Forms.Label labTarget;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

