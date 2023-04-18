namespace AutonomousAgents
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
            components = new System.ComponentModel.Container();
            timer_1 = new System.Windows.Forms.Timer(components);
            btn_walls = new Button();
            btn_dev = new Button();
            cb = new ComboBox();
            tb_mouse = new TextBox();
            tb_input = new TextBox();
            panel1 = new Panel();
            btn_pause = new Button();
            btn_start = new Button();
            SuspendLayout();
            // 
            // timer_1
            // 
            timer_1.Interval = 10;
            timer_1.Tick += timer_1_Tick;
            // 
            // btn_walls
            // 
            btn_walls.Location = new Point(367, 16);
            btn_walls.Name = "btn_walls";
            btn_walls.Size = new Size(94, 29);
            btn_walls.TabIndex = 25;
            btn_walls.Text = "Walls";
            btn_walls.UseVisualStyleBackColor = true;
            btn_walls.Visible = false;
            btn_walls.Click += btn_walls_Click;
            // 
            // btn_dev
            // 
            btn_dev.Location = new Point(478, 16);
            btn_dev.Name = "btn_dev";
            btn_dev.Size = new Size(94, 29);
            btn_dev.TabIndex = 24;
            btn_dev.Text = "Dev";
            btn_dev.UseVisualStyleBackColor = true;
            btn_dev.Visible = false;
            btn_dev.Click += btn_dev_Click;
            // 
            // cb
            // 
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.FormattingEnabled = true;
            cb.Items.AddRange(new object[] { "SeekAndArrive", "Wander", "Seperate", "Seperate+Seek", "Seperate+Wander", "Flock" });
            cb.Location = new Point(1095, 16);
            cb.Name = "cb";
            cb.Size = new Size(151, 28);
            cb.TabIndex = 23;
            cb.SelectedIndexChanged += cb_SelectedIndexChanged;
            cb.Click += cb_Click;
            // 
            // tb_mouse
            // 
            tb_mouse.BackColor = SystemColors.Control;
            tb_mouse.Location = new Point(955, 16);
            tb_mouse.Name = "tb_mouse";
            tb_mouse.Size = new Size(125, 27);
            tb_mouse.TabIndex = 21;
            // 
            // tb_input
            // 
            tb_input.ForeColor = SystemColors.WindowText;
            tb_input.Location = new Point(8, 16);
            tb_input.Name = "tb_input";
            tb_input.Size = new Size(125, 27);
            tb_input.TabIndex = 18;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Dock = DockStyle.Bottom;
            panel1.ForeColor = SystemColors.ControlDarkDark;
            panel1.Location = new Point(0, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(1262, 850);
            panel1.TabIndex = 17;
            panel1.Paint += panel1_Paint;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // btn_pause
            // 
            btn_pause.BackColor = SystemColors.Control;
            btn_pause.ForeColor = SystemColors.ControlText;
            btn_pause.Location = new Point(259, 16);
            btn_pause.Name = "btn_pause";
            btn_pause.Size = new Size(94, 29);
            btn_pause.TabIndex = 20;
            btn_pause.Text = "Pause";
            btn_pause.UseVisualStyleBackColor = false;
            btn_pause.Click += btn_pause_Click;
            // 
            // btn_start
            // 
            btn_start.BackColor = SystemColors.Control;
            btn_start.ForeColor = SystemColors.ControlText;
            btn_start.Location = new Point(148, 16);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(94, 29);
            btn_start.TabIndex = 19;
            btn_start.Text = "Start";
            btn_start.UseVisualStyleBackColor = false;
            btn_start.Click += btn_start_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1262, 913);
            Controls.Add(btn_walls);
            Controls.Add(btn_dev);
            Controls.Add(cb);
            Controls.Add(tb_mouse);
            Controls.Add(tb_input);
            Controls.Add(panel1);
            Controls.Add(btn_pause);
            Controls.Add(btn_start);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timer_1;
        private Button btn_walls;
        private Button btn_dev;
        private ComboBox cb;
        private TextBox tb_mouse;
        private TextBox tb_input;
        private Panel panel1;
        private Button btn_pause;
        private Button btn_start;
    }
}