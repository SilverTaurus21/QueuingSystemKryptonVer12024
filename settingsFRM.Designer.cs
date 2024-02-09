namespace countersystemV1
{
    partial class settingsFRM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsFRM));
            this.BTN_FIND = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.TXT_LOCATION = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // BTN_FIND
            // 
            this.BTN_FIND.Location = new System.Drawing.Point(295, 174);
            this.BTN_FIND.Name = "BTN_FIND";
            this.BTN_FIND.Size = new System.Drawing.Size(90, 33);
            this.BTN_FIND.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.BTN_FIND.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.BTN_FIND.TabIndex = 5;
            this.BTN_FIND.Values.Text = "Find";
            this.BTN_FIND.Click += new System.EventHandler(this.BTN_FIND_Click);
            // 
            // TXT_LOCATION
            // 
            this.TXT_LOCATION.Location = new System.Drawing.Point(29, 38);
            this.TXT_LOCATION.Name = "TXT_LOCATION";
            this.TXT_LOCATION.ReadOnly = true;
            this.TXT_LOCATION.Size = new System.Drawing.Size(356, 130);
            this.TXT_LOCATION.StateCommon.Content.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_LOCATION.TabIndex = 4;
            this.TXT_LOCATION.Text = "";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(29, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(57, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = "Location";
            // 
            // settingsFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(414, 219);
            this.Controls.Add(this.BTN_FIND);
            this.Controls.Add(this.TXT_LOCATION);
            this.Controls.Add(this.kryptonLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "settingsFRM";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Black;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings - Advertisement Location";
            this.Load += new System.EventHandler(this.settingsFRM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton BTN_FIND;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox TXT_LOCATION;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    }
}