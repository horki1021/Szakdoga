namespace SzamitogepNyilvantarto.UI.MenuControls.Reports
{
    partial class IdoszakHibakForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerKezdet = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerVeg = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Időszak kezdete";
            // 
            // dateTimePickerKezdet
            // 
            this.dateTimePickerKezdet.Location = new System.Drawing.Point(32, 53);
            this.dateTimePickerKezdet.Name = "dateTimePickerKezdet";
            this.dateTimePickerKezdet.Size = new System.Drawing.Size(250, 27);
            this.dateTimePickerKezdet.TabIndex = 1;
            this.dateTimePickerKezdet.Leave += new System.EventHandler(this.OnKezdetLeave);
            // 
            // dateTimePickerVeg
            // 
            this.dateTimePickerVeg.Location = new System.Drawing.Point(32, 139);
            this.dateTimePickerVeg.Name = "dateTimePickerVeg";
            this.dateTimePickerVeg.Size = new System.Drawing.Size(250, 27);
            this.dateTimePickerVeg.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Időszak vége";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(32, 215);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(250, 29);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OnOKClick);
            // 
            // IdoszakHibakForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 261);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.dateTimePickerVeg);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerKezdet);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(341, 308);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(341, 308);
            this.Name = "IdoszakHibakForm";
            this.Text = "Időszak meghibásodásai";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private DateTimePicker dateTimePickerKezdet;
        private DateTimePicker dateTimePickerVeg;
        private Label label2;
        private Button buttonOK;
    }
}