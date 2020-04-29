namespace AStar
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
            this.RunBtn = new System.Windows.Forms.Button();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.sx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ex = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.width = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.length = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.density = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(96, 508);
            this.RunBtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(168, 44);
            this.RunBtn.TabIndex = 2;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // ImageBox
            // 
            this.ImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ImageBox.Location = new System.Drawing.Point(308, 50);
            this.ImageBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(2000, 2000);
            this.ImageBox.TabIndex = 4;
            this.ImageBox.TabStop = false;
            // 
            // sx
            // 
            this.sx.Location = new System.Drawing.Point(96, 375);
            this.sx.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.sx.Name = "sx";
            this.sx.Size = new System.Drawing.Size(74, 31);
            this.sx.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 338);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Start X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 338);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Start Y";
            // 
            // sy
            // 
            this.sy.Location = new System.Drawing.Point(186, 375);
            this.sy.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.sy.Name = "sy";
            this.sy.Size = new System.Drawing.Size(74, 31);
            this.sy.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 421);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "End Y";
            // 
            // ey
            // 
            this.ey.Location = new System.Drawing.Point(186, 458);
            this.ey.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ey.Name = "ey";
            this.ey.Size = new System.Drawing.Size(74, 31);
            this.ey.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 421);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "End X";
            // 
            // ex
            // 
            this.ex.Location = new System.Drawing.Point(96, 458);
            this.ex.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ex.Name = "ex";
            this.ex.Size = new System.Drawing.Size(74, 31);
            this.ex.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 258);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Width";
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(186, 294);
            this.width.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(74, 31);
            this.width.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(96, 258);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "Height";
            // 
            // length
            // 
            this.length.Location = new System.Drawing.Point(96, 294);
            this.length.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.length.Name = "length";
            this.length.Size = new System.Drawing.Size(74, 31);
            this.length.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(142, 177);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Density";
            // 
            // density
            // 
            this.density.Location = new System.Drawing.Point(142, 213);
            this.density.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.density.Name = "density";
            this.density.Size = new System.Drawing.Size(80, 31);
            this.density.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2160, 1421);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.density);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.width);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.length);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sx);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.RunBtn);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button RunBtn;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.TextBox sx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox width;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox length;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox density;
    }
}

