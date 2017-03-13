namespace MainMenu
{
    partial class MainMenuForm
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
            this.toSaunaPr_btn = new System.Windows.Forms.Button();
            this.toGasStationPr_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // toSaunaPr_btn
            // 
            this.toSaunaPr_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toSaunaPr_btn.Location = new System.Drawing.Point(85, 39);
            this.toSaunaPr_btn.Name = "toSaunaPr_btn";
            this.toSaunaPr_btn.Size = new System.Drawing.Size(287, 61);
            this.toSaunaPr_btn.TabIndex = 0;
            this.toSaunaPr_btn.Text = "Bathhouse power consumption management";
            this.toSaunaPr_btn.UseVisualStyleBackColor = true;
            this.toSaunaPr_btn.Click += new System.EventHandler(this.toSaunaPr_btn_Click);
            // 
            // toGasStationPr_btn
            // 
            this.toGasStationPr_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toGasStationPr_btn.Location = new System.Drawing.Point(85, 124);
            this.toGasStationPr_btn.Name = "toGasStationPr_btn";
            this.toGasStationPr_btn.Size = new System.Drawing.Size(287, 44);
            this.toGasStationPr_btn.TabIndex = 1;
            this.toGasStationPr_btn.Text = "Gas station management";
            this.toGasStationPr_btn.UseVisualStyleBackColor = true;
            this.toGasStationPr_btn.Click += new System.EventHandler(this.toGasStationPr_btn_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 209);
            this.Controls.Add(this.toGasStationPr_btn);
            this.Controls.Add(this.toSaunaPr_btn);
            this.Name = "MainMenuForm";
            this.Text = "Practice 1 control panel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button toSaunaPr_btn;
        private System.Windows.Forms.Button toGasStationPr_btn;
    }
}

