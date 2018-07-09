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
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 25);
            this.textBox1.TabIndex = 0;
            // 
            // Generater
            // 
            this.Generater.Location = new System.Drawing.Point(176, 12);
            this.Generater.Name = "Generater";
            this.Generater.Size = new System.Drawing.Size(94, 25);
            this.Generater.TabIndex = 1;
            this.Generater.Text = "생성";
            this.Generater.UseVisualStyleBackColor = true;
            this.Generater.Click += new System.EventHandler(this.Generater_Click);
            // 
            // SpeedCheck
            // 
            this.SpeedCheck.AutoSize = true;
            this.SpeedCheck.Location = new System.Drawing.Point(12, 43);
            this.SpeedCheck.Name = "SpeedCheck";
            this.SpeedCheck.Size = new System.Drawing.Size(89, 19);
            this.SpeedCheck.TabIndex = 2;
            this.SpeedCheck.Text = "속도분포";
            this.SpeedCheck.UseVisualStyleBackColor = true;
            // 
            // DistanceCheck
            // 
            this.DistanceCheck.AutoSize = true;
            this.DistanceCheck.Location = new System.Drawing.Point(12, 68);
            this.DistanceCheck.Name = "DistanceCheck";
            this.DistanceCheck.Size = new System.Drawing.Size(89, 19);
            this.DistanceCheck.TabIndex = 3;
            this.DistanceCheck.Text = "위빙거리";
            this.DistanceCheck.UseVisualStyleBackColor = true;
            // 
            // IntervalCheck
            // 
            this.IntervalCheck.AutoSize = true;
            this.IntervalCheck.Location = new System.Drawing.Point(12, 93);
            this.IntervalCheck.Name = "IntervalCheck";
            this.IntervalCheck.Size = new System.Drawing.Size(89, 19);
            this.IntervalCheck.TabIndex = 4;
            this.IntervalCheck.Text = "위빙간격";
            this.IntervalCheck.UseVisualStyleBackColor = true;
            // 
            // DataGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 124);
            this.Controls.Add(this.IntervalCheck);
            this.Controls.Add(this.DistanceCheck);
            this.Controls.Add(this.SpeedCheck);
            this.Controls.Add(this.Generater);
            this.Controls.Add(this.textBox1);
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
    }
}

