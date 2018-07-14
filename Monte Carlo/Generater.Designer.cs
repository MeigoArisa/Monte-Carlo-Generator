namespace Monte_Carlo
{
    partial class DataGenerator
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Generater = new System.Windows.Forms.Button();
            this.SpeedCheck = new System.Windows.Forms.CheckBox();
            this.DistanceCheck = new System.Windows.Forms.CheckBox();
            this.IntervalCheck = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 10);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 21);
            this.textBox1.TabIndex = 0;
            // 
            // Generater
            // 
            this.Generater.Location = new System.Drawing.Point(140, 9);
            this.Generater.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Generater.Name = "Generater";
            this.Generater.Size = new System.Drawing.Size(42, 23);
            this.Generater.TabIndex = 1;
            this.Generater.Text = "생성";
            this.Generater.UseVisualStyleBackColor = true;
            this.Generater.Click += new System.EventHandler(this.Generater_Click);
            // 
            // SpeedCheck
            // 
            this.SpeedCheck.AutoSize = true;
            this.SpeedCheck.Checked = true;
            this.SpeedCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SpeedCheck.Location = new System.Drawing.Point(10, 34);
            this.SpeedCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SpeedCheck.Name = "SpeedCheck";
            this.SpeedCheck.Size = new System.Drawing.Size(72, 16);
            this.SpeedCheck.TabIndex = 2;
            this.SpeedCheck.Text = "속도분포";
            this.SpeedCheck.UseVisualStyleBackColor = true;
            // 
            // DistanceCheck
            // 
            this.DistanceCheck.AutoSize = true;
            this.DistanceCheck.Checked = true;
            this.DistanceCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DistanceCheck.Location = new System.Drawing.Point(10, 54);
            this.DistanceCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DistanceCheck.Name = "DistanceCheck";
            this.DistanceCheck.Size = new System.Drawing.Size(72, 16);
            this.DistanceCheck.TabIndex = 3;
            this.DistanceCheck.Text = "위빙거리";
            this.DistanceCheck.UseVisualStyleBackColor = true;
            // 
            // IntervalCheck
            // 
            this.IntervalCheck.AutoSize = true;
            this.IntervalCheck.Checked = true;
            this.IntervalCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IntervalCheck.Location = new System.Drawing.Point(10, 74);
            this.IntervalCheck.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IntervalCheck.Name = "IntervalCheck";
            this.IntervalCheck.Size = new System.Drawing.Size(72, 16);
            this.IntervalCheck.TabIndex = 4;
            this.IntervalCheck.Text = "위빙간격";
            this.IntervalCheck.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(188, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Info";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 8;
            // 
            // DataGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 102);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IntervalCheck);
            this.Controls.Add(this.DistanceCheck);
            this.Controls.Add(this.SpeedCheck);
            this.Controls.Add(this.Generater);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataGenerator";
            this.Text = "Monte Carlo Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Generater;
        private System.Windows.Forms.CheckBox SpeedCheck;
        private System.Windows.Forms.CheckBox DistanceCheck;
        private System.Windows.Forms.CheckBox IntervalCheck;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

