namespace LevelEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnlSurface = new System.Windows.Forms.Panel();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.pnlPalette = new System.Windows.Forms.Panel();
            this.pb_palette = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadTilemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTilemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setToCurrentTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTileDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foregroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pb_selected = new System.Windows.Forms.PictureBox();
            this.lblSelected = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTileUpdate = new System.Windows.Forms.Button();
            this.txtCodeValue = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.chk_portal = new System.Windows.Forms.CheckBox();
            this.rdo_edit = new System.Windows.Forms.RadioButton();
            this.rad_draw = new System.Windows.Forms.RadioButton();
            this.chk_collidable = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tmr_update = new System.Windows.Forms.Timer(this.components);
            this.groundToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlPalette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_palette)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_selected)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSurface
            // 
            this.pnlSurface.AutoScroll = true;
            this.pnlSurface.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSurface.Location = new System.Drawing.Point(535, 34);
            this.pnlSurface.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSurface.Name = "pnlSurface";
            this.pnlSurface.Size = new System.Drawing.Size(1322, 864);
            this.pnlSurface.TabIndex = 0;
            this.pnlSurface.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlSurface_MouseClick);
            this.pnlSurface.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlSurface_MouseMove);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(535, 901);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1327, 21);
            this.hScrollBar1.TabIndex = 1;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(1861, 34);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 788);
            this.vScrollBar1.TabIndex = 0;
            // 
            // pnlPalette
            // 
            this.pnlPalette.AutoScroll = true;
            this.pnlPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPalette.Controls.Add(this.pb_palette);
            this.pnlPalette.Location = new System.Drawing.Point(12, 33);
            this.pnlPalette.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPalette.Name = "pnlPalette";
            this.pnlPalette.Size = new System.Drawing.Size(517, 502);
            this.pnlPalette.TabIndex = 1;
            // 
            // pb_palette
            // 
            this.pb_palette.BackColor = System.Drawing.Color.Black;
            this.pb_palette.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_palette.Image = ((System.Drawing.Image)(resources.GetObject("pb_palette.Image")));
            this.pb_palette.Location = new System.Drawing.Point(0, 0);
            this.pb_palette.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb_palette.Name = "pb_palette";
            this.pb_palette.Size = new System.Drawing.Size(2048, 2048);
            this.pb_palette.TabIndex = 0;
            this.pb_palette.TabStop = false;
            this.pb_palette.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pb_palette_MouseClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1883, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadTilemapToolStripMenuItem,
            this.saveTilemapToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadTilemapToolStripMenuItem
            // 
            this.loadTilemapToolStripMenuItem.Name = "loadTilemapToolStripMenuItem";
            this.loadTilemapToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.loadTilemapToolStripMenuItem.Text = "Load Tilemap";
            this.loadTilemapToolStripMenuItem.Click += new System.EventHandler(this.loadTilemapToolStripMenuItem_Click);
            // 
            // saveTilemapToolStripMenuItem
            // 
            this.saveTilemapToolStripMenuItem.Name = "saveTilemapToolStripMenuItem";
            this.saveTilemapToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.saveTilemapToolStripMenuItem.Text = "SaveTilemap";
            this.saveTilemapToolStripMenuItem.Click += new System.EventHandler(this.saveTilemapToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearMapToolStripMenuItem,
            this.setToCurrentTileToolStripMenuItem,
            this.clearTileDataToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearMapToolStripMenuItem
            // 
            this.clearMapToolStripMenuItem.Name = "clearMapToolStripMenuItem";
            this.clearMapToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.clearMapToolStripMenuItem.Text = "Clear Map";
            this.clearMapToolStripMenuItem.Click += new System.EventHandler(this.clearMapToolStripMenuItem_Click);
            // 
            // setToCurrentTileToolStripMenuItem
            // 
            this.setToCurrentTileToolStripMenuItem.Name = "setToCurrentTileToolStripMenuItem";
            this.setToCurrentTileToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.setToCurrentTileToolStripMenuItem.Text = "Set Map to CurrentTile";
            this.setToCurrentTileToolStripMenuItem.Click += new System.EventHandler(this.setToCurrentTileToolStripMenuItem_Click);
            // 
            // clearTileDataToolStripMenuItem
            // 
            this.clearTileDataToolStripMenuItem.Name = "clearTileDataToolStripMenuItem";
            this.clearTileDataToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.clearTileDataToolStripMenuItem.Text = "Clear Tile Data";
            this.clearTileDataToolStripMenuItem.Click += new System.EventHandler(this.clearTileDataToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layersToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // layersToolStripMenuItem
            // 
            this.layersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.foregroundToolStripMenuItem,
            this.backgroundToolStripMenuItem,
            this.groundToolStripMenuItem,
            this.groundToolStripMenuItem1});
            this.layersToolStripMenuItem.Name = "layersToolStripMenuItem";
            this.layersToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.layersToolStripMenuItem.Text = "Layers";
            // 
            // foregroundToolStripMenuItem
            // 
            this.foregroundToolStripMenuItem.Name = "foregroundToolStripMenuItem";
            this.foregroundToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.foregroundToolStripMenuItem.Text = "Foreground";
            this.foregroundToolStripMenuItem.Click += new System.EventHandler(this.foregroundToolStripMenuItem_Click);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.backgroundToolStripMenuItem.Text = "Layer3";
            this.backgroundToolStripMenuItem.Click += new System.EventHandler(this.backgroundToolStripMenuItem_Click);
            // 
            // groundToolStripMenuItem
            // 
            this.groundToolStripMenuItem.Checked = true;
            this.groundToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.groundToolStripMenuItem.Name = "groundToolStripMenuItem";
            this.groundToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.groundToolStripMenuItem.Text = "Layer2";
            this.groundToolStripMenuItem.Click += new System.EventHandler(this.groundToolStripMenuItem_Click);
            // 
            // pb_selected
            // 
            this.pb_selected.BackColor = System.Drawing.Color.Black;
            this.pb_selected.Location = new System.Drawing.Point(272, 5);
            this.pb_selected.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pb_selected.Name = "pb_selected";
            this.pb_selected.Size = new System.Drawing.Size(64, 64);
            this.pb_selected.TabIndex = 3;
            this.pb_selected.TabStop = false;
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(108, 31);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(98, 17);
            this.lblSelected.TabIndex = 4;
            this.lblSelected.Text = "Current Tile: #";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblSelected);
            this.panel2.Controls.Add(this.pb_selected);
            this.panel2.Location = new System.Drawing.Point(13, 539);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(515, 75);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnTileUpdate);
            this.panel3.Controls.Add(this.txtCodeValue);
            this.panel3.Controls.Add(this.lblCode);
            this.panel3.Controls.Add(this.txtFilename);
            this.panel3.Controls.Add(this.lblFilename);
            this.panel3.Controls.Add(this.chk_portal);
            this.panel3.Controls.Add(this.rdo_edit);
            this.panel3.Controls.Add(this.rad_draw);
            this.panel3.Controls.Add(this.chk_collidable);
            this.panel3.Location = new System.Drawing.Point(12, 618);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(515, 304);
            this.panel3.TabIndex = 6;
            // 
            // btnTileUpdate
            // 
            this.btnTileUpdate.Location = new System.Drawing.Point(197, 240);
            this.btnTileUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTileUpdate.Name = "btnTileUpdate";
            this.btnTileUpdate.Size = new System.Drawing.Size(123, 31);
            this.btnTileUpdate.TabIndex = 8;
            this.btnTileUpdate.Text = "Update Tile";
            this.btnTileUpdate.UseVisualStyleBackColor = true;
            this.btnTileUpdate.Click += new System.EventHandler(this.btnTileUpdate_Click);
            // 
            // txtCodeValue
            // 
            this.txtCodeValue.Location = new System.Drawing.Point(359, 156);
            this.txtCodeValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodeValue.Name = "txtCodeValue";
            this.txtCodeValue.Size = new System.Drawing.Size(128, 22);
            this.txtCodeValue.TabIndex = 7;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(312, 159);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(41, 17);
            this.lblCode.TabIndex = 6;
            this.lblCode.Text = "Code";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(88, 156);
            this.txtFilename.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(128, 22);
            this.txtFilename.TabIndex = 5;
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(17, 159);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(65, 17);
            this.lblFilename.TabIndex = 4;
            this.lblFilename.Text = "Filename";
            // 
            // chk_portal
            // 
            this.chk_portal.AutoSize = true;
            this.chk_portal.Location = new System.Drawing.Point(20, 110);
            this.chk_portal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_portal.Name = "chk_portal";
            this.chk_portal.Size = new System.Drawing.Size(67, 21);
            this.chk_portal.TabIndex = 3;
            this.chk_portal.Text = "Portal";
            this.chk_portal.UseVisualStyleBackColor = true;
            // 
            // rdo_edit
            // 
            this.rdo_edit.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdo_edit.AutoSize = true;
            this.rdo_edit.Location = new System.Drawing.Point(272, 26);
            this.rdo_edit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdo_edit.Name = "rdo_edit";
            this.rdo_edit.Size = new System.Drawing.Size(81, 27);
            this.rdo_edit.TabIndex = 2;
            this.rdo_edit.Text = "Edit Mode";
            this.rdo_edit.UseVisualStyleBackColor = true;
            // 
            // rad_draw
            // 
            this.rad_draw.Appearance = System.Windows.Forms.Appearance.Button;
            this.rad_draw.AutoSize = true;
            this.rad_draw.Checked = true;
            this.rad_draw.Location = new System.Drawing.Point(169, 26);
            this.rad_draw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rad_draw.Name = "rad_draw";
            this.rad_draw.Size = new System.Drawing.Size(89, 27);
            this.rad_draw.TabIndex = 1;
            this.rad_draw.TabStop = true;
            this.rad_draw.Text = "Draw Mode";
            this.rad_draw.UseVisualStyleBackColor = true;
            // 
            // chk_collidable
            // 
            this.chk_collidable.AutoSize = true;
            this.chk_collidable.Location = new System.Drawing.Point(315, 110);
            this.chk_collidable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chk_collidable.Name = "chk_collidable";
            this.chk_collidable.Size = new System.Drawing.Size(91, 21);
            this.chk_collidable.TabIndex = 0;
            this.chk_collidable.Text = "Collidable";
            this.chk_collidable.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tmr_update
            // 
            this.tmr_update.Enabled = true;
            this.tmr_update.Interval = 16;
            this.tmr_update.Tick += new System.EventHandler(this.tmr_update_Tick);
            // 
            // groundToolStripMenuItem1
            // 
            this.groundToolStripMenuItem1.Name = "groundToolStripMenuItem1";
            this.groundToolStripMenuItem1.Size = new System.Drawing.Size(181, 26);
            this.groundToolStripMenuItem1.Text = "Ground";
            this.groundToolStripMenuItem1.Click += new System.EventHandler(this.groundToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1883, 933);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlPalette);
            this.Controls.Add(this.pnlSurface);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Level Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlPalette.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_palette)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_selected)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel pnlSurface;
        private System.Windows.Forms.Panel pnlPalette;
        private System.Windows.Forms.PictureBox pb_palette;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.PictureBox pb_selected;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtCodeValue;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.CheckBox chk_portal;
        public System.Windows.Forms.RadioButton rdo_edit;
        private System.Windows.Forms.RadioButton rad_draw;
        private System.Windows.Forms.CheckBox chk_collidable;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem loadTilemapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTilemapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setToCurrentTileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearTileDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foregroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groundToolStripMenuItem;
        public System.Windows.Forms.HScrollBar hScrollBar1;
        public System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer tmr_update;
        private System.Windows.Forms.Button btnTileUpdate;
        private System.Windows.Forms.ToolStripMenuItem groundToolStripMenuItem1;
    }
}