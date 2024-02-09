namespace countersystemV1
{
    partial class splashFRM
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
            this.BTN_TRIGGER = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // BTN_TRIGGER
            // 
            this.BTN_TRIGGER.Location = new System.Drawing.Point(540, 315);
            this.BTN_TRIGGER.Name = "BTN_TRIGGER";
            this.BTN_TRIGGER.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.BTN_TRIGGER.Size = new System.Drawing.Size(301, 75);
            this.BTN_TRIGGER.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BTN_TRIGGER.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BTN_TRIGGER.StateCommon.Border.Color1 = System.Drawing.Color.Silver;
            this.BTN_TRIGGER.StateCommon.Border.Color2 = System.Drawing.Color.Silver;
            this.BTN_TRIGGER.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.BTN_TRIGGER.StateCommon.Border.Rounding = 4;
            this.BTN_TRIGGER.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.BTN_TRIGGER.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.BTN_TRIGGER.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_TRIGGER.StatePressed.Back.Color1 = System.Drawing.Color.Lime;
            this.BTN_TRIGGER.StatePressed.Back.Color2 = System.Drawing.Color.Lime;
            this.BTN_TRIGGER.TabIndex = 8;
            this.BTN_TRIGGER.Values.Text = "RESUME";
            this.BTN_TRIGGER.Click += new System.EventHandler(this.BTN_TRIGGER_Click);
            // 
            // splashFRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.BTN_TRIGGER);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "splashFRM";
            this.Opacity = 0.78D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "splashFRM";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton BTN_TRIGGER;
    }
}