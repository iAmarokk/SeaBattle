namespace SeaBattle
{
    partial class FormGame
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.grid_user = new System.Windows.Forms.DataGridView();
            this.grid_comp = new System.Windows.Forms.DataGridView();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grid_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_comp)).BeginInit();
            this.SuspendLayout();
            // 
            // grid_user
            // 
            this.grid_user.AllowUserToAddRows = false;
            this.grid_user.AllowUserToDeleteRows = false;
            this.grid_user.AllowUserToResizeColumns = false;
            this.grid_user.AllowUserToResizeRows = false;
            this.grid_user.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_user.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_user.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grid_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_user.Location = new System.Drawing.Point(38, 33);
            this.grid_user.Name = "grid_user";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_user.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grid_user.RowHeadersWidth = 55;
            this.grid_user.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid_user.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grid_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid_user.ShowCellErrors = false;
            this.grid_user.ShowCellToolTips = false;
            this.grid_user.ShowEditingIcon = false;
            this.grid_user.ShowRowErrors = false;
            this.grid_user.Size = new System.Drawing.Size(298, 261);
            this.grid_user.TabIndex = 0;
            this.grid_user.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_user_KeyDown);
            this.grid_user.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grid_user_MouseUp);
            // 
            // grid_comp
            // 
            this.grid_comp.AllowUserToAddRows = false;
            this.grid_comp.AllowUserToDeleteRows = false;
            this.grid_comp.AllowUserToResizeColumns = false;
            this.grid_comp.AllowUserToResizeRows = false;
            this.grid_comp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_comp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_comp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grid_comp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_comp.Location = new System.Drawing.Point(386, 33);
            this.grid_comp.Name = "grid_comp";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_comp.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grid_comp.RowHeadersWidth = 55;
            this.grid_comp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid_comp.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grid_comp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid_comp.ShowCellErrors = false;
            this.grid_comp.ShowCellToolTips = false;
            this.grid_comp.ShowEditingIcon = false;
            this.grid_comp.ShowRowErrors = false;
            this.grid_comp.Size = new System.Drawing.Size(298, 261);
            this.grid_comp.TabIndex = 1;
            this.grid_comp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_comp_CellClick);
            // 
            // buttonRandom
            // 
            this.buttonRandom.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRandom.Location = new System.Drawing.Point(38, 312);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(143, 57);
            this.buttonRandom.TabIndex = 3;
            this.buttonRandom.Text = "Расположить случайно";
            this.buttonRandom.UseVisualStyleBackColor = true;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClear.Location = new System.Drawing.Point(199, 312);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(137, 57);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Очистить море";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.Location = new System.Drawing.Point(386, 312);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(298, 117);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Старт игры";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRestart.Location = new System.Drawing.Point(38, 375);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(298, 57);
            this.buttonRestart.TabIndex = 6;
            this.buttonRestart.Text = "Начать игру заново";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 457);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonRandom);
            this.Controls.Add(this.grid_comp);
            this.Controls.Add(this.grid_user);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Морской Бой";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormGame_MouseDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.grid_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_comp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_user;
        private System.Windows.Forms.DataGridView grid_comp;
        private System.Windows.Forms.Button buttonRandom;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Timer timer1;
    }
}

