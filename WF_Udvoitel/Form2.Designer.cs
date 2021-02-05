
namespace WF_Udvoitel
{
    partial class Form2
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
            this.btnStart = new System.Windows.Forms.Button();
            this.lblGame = new System.Windows.Forms.Label();
            this.tbGuess = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTest = new System.Windows.Forms.Label();
            this.lblNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStart.Location = new System.Drawing.Point(155, 392);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblGame
            // 
            this.lblGame.AutoSize = true;
            this.lblGame.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblGame.Location = new System.Drawing.Point(138, 23);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(35, 13);
            this.lblGame.TabIndex = 1;
            this.lblGame.Text = "Game";
            this.lblGame.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbGuess
            // 
            this.tbGuess.Location = new System.Drawing.Point(141, 195);
            this.tbGuess.Name = "tbGuess";
            this.tbGuess.Size = new System.Drawing.Size(100, 20);
            this.tbGuess.TabIndex = 2;
            this.tbGuess.TextChanged += new System.EventHandler(this.tbGuess_TextChanged);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(106, 79);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 13);
            this.lblResult.TabIndex = 3;
            this.lblResult.Text = "Result";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(155, 293);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(188, 131);
            this.lblCount.Name = "lblCount";
            this.lblCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCount.Size = new System.Drawing.Size(35, 13);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "Count";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(322, 167);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(28, 13);
            this.lblTest.TabIndex = 6;
            this.lblTest.Text = "Test";
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(321, 234);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(44, 13);
            this.lblNumber.TabIndex = 7;
            this.lblNumber.Text = "Number";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 450);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.tbGuess);
            this.Controls.Add(this.lblGame);
            this.Controls.Add(this.btnStart);
            this.MaximumSize = new System.Drawing.Size(426, 489);
            this.MinimumSize = new System.Drawing.Size(426, 489);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblGame;
        private System.Windows.Forms.TextBox tbGuess;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Label lblNumber;
    }
}