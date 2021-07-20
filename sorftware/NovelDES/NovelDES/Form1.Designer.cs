
namespace NovelDES
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_Select = new System.Windows.Forms.Button();
            this.button_jia = new System.Windows.Forms.Button();
            this.button_jie = new System.Windows.Forms.Button();
            this.textBox_mima = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(382, 23);
            this.textBox1.TabIndex = 0;
            // 
            // button_Select
            // 
            this.button_Select.Location = new System.Drawing.Point(403, 12);
            this.button_Select.Name = "button_Select";
            this.button_Select.Size = new System.Drawing.Size(75, 23);
            this.button_Select.TabIndex = 1;
            this.button_Select.Text = "选择";
            this.button_Select.UseVisualStyleBackColor = true;
            this.button_Select.Click += new System.EventHandler(this.button_Select_Click);
            // 
            // button_jia
            // 
            this.button_jia.Location = new System.Drawing.Point(319, 56);
            this.button_jia.Name = "button_jia";
            this.button_jia.Size = new System.Drawing.Size(75, 23);
            this.button_jia.TabIndex = 2;
            this.button_jia.Text = "加密";
            this.button_jia.UseVisualStyleBackColor = true;
            this.button_jia.Click += new System.EventHandler(this.button_jia_Click);
            // 
            // button_jie
            // 
            this.button_jie.Location = new System.Drawing.Point(403, 56);
            this.button_jie.Name = "button_jie";
            this.button_jie.Size = new System.Drawing.Size(75, 23);
            this.button_jie.TabIndex = 3;
            this.button_jie.Text = "解密";
            this.button_jie.UseVisualStyleBackColor = true;
            this.button_jie.Click += new System.EventHandler(this.button_jie_Click);
            // 
            // textBox_mima
            // 
            this.textBox_mima.Location = new System.Drawing.Point(130, 56);
            this.textBox_mima.Name = "textBox_mima";
            this.textBox_mima.Size = new System.Drawing.Size(169, 23);
            this.textBox_mima.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "密码:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 95);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_mima);
            this.Controls.Add(this.button_jie);
            this.Controls.Add(this.button_jia);
            this.Controls.Add(this.button_Select);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "加解密";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_Select;
        private System.Windows.Forms.Button button_jia;
        private System.Windows.Forms.Button button_jie;
        private System.Windows.Forms.TextBox textBox_mima;
        private System.Windows.Forms.Label label1;
    }
}

