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
            panel1 = new Panel();
            tb_input_1 = new TextBox();
            btn_start_1 = new Button();
            btn_pause_1 = new Button();
            timer_1 = new System.Windows.Forms.Timer(components);
            tb_mouse_1 = new TextBox();
            label1 = new Label();
            tc = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            btn_edges_2 = new Button();
            btn_dev_2 = new Button();
            panel2 = new Panel();
            tb_mouse_2 = new TextBox();
            label2 = new Label();
            btn_pause_2 = new Button();
            btn_start_2 = new Button();
            tb_input_2 = new TextBox();
            tabPage3 = new TabPage();
            label3 = new Label();
            tb_mouse_3 = new TextBox();
            panel3 = new Panel();
            btn_pause_3 = new Button();
            tb_input_3 = new TextBox();
            btn_start_3 = new Button();
            tabPage4 = new TabPage();
            btn_edges_4 = new Button();
            btn_dev_4 = new Button();
            label4 = new Label();
            tb_mouse_4 = new TextBox();
            panel4 = new Panel();
            btn_pause_4 = new Button();
            tb_input_4 = new TextBox();
            btn_start_4 = new Button();
            tabPage5 = new TabPage();
            timer_2 = new System.Windows.Forms.Timer(components);
            timer_3 = new System.Windows.Forms.Timer(components);
            timer_4 = new System.Windows.Forms.Timer(components);
            tc.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLightLight;
            panel1.Dock = DockStyle.Bottom;
            panel1.ForeColor = SystemColors.ControlDarkDark;
            panel1.Location = new Point(3, 54);
            panel1.Name = "panel1";
            panel1.Size = new Size(1248, 823);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // tb_input_1
            // 
            tb_input_1.ForeColor = SystemColors.WindowText;
            tb_input_1.Location = new Point(8, 17);
            tb_input_1.Name = "tb_input_1";
            tb_input_1.Size = new Size(125, 27);
            tb_input_1.TabIndex = 1;
            // 
            // btn_start_1
            // 
            btn_start_1.BackColor = SystemColors.Control;
            btn_start_1.ForeColor = SystemColors.ControlText;
            btn_start_1.Location = new Point(148, 17);
            btn_start_1.Name = "btn_start_1";
            btn_start_1.Size = new Size(94, 29);
            btn_start_1.TabIndex = 2;
            btn_start_1.Text = "Start";
            btn_start_1.UseVisualStyleBackColor = false;
            btn_start_1.Click += btn_start_1_Click;
            // 
            // btn_pause_1
            // 
            btn_pause_1.BackColor = SystemColors.Control;
            btn_pause_1.ForeColor = SystemColors.ControlText;
            btn_pause_1.Location = new Point(259, 17);
            btn_pause_1.Name = "btn_pause_1";
            btn_pause_1.Size = new Size(94, 29);
            btn_pause_1.TabIndex = 3;
            btn_pause_1.Text = "Pause";
            btn_pause_1.UseVisualStyleBackColor = false;
            btn_pause_1.Click += btn_pause_1_Click;
            // 
            // timer_1
            // 
            timer_1.Interval = 10;
            timer_1.Tick += timer_1_Tick;
            // 
            // tb_mouse_1
            // 
            tb_mouse_1.BackColor = SystemColors.Control;
            tb_mouse_1.Location = new Point(1119, 17);
            tb_mouse_1.Name = "tb_mouse_1";
            tb_mouse_1.Size = new Size(125, 27);
            tb_mouse_1.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(975, 20);
            label1.Name = "label1";
            label1.Size = new Size(138, 20);
            label1.TabIndex = 5;
            label1.Text = "Mouse coordinates:";
            // 
            // tc
            // 
            tc.Controls.Add(tabPage1);
            tc.Controls.Add(tabPage2);
            tc.Controls.Add(tabPage3);
            tc.Controls.Add(tabPage4);
            tc.Controls.Add(tabPage5);
            tc.Dock = DockStyle.Bottom;
            tc.Location = new Point(0, 0);
            tc.Name = "tc";
            tc.SelectedIndex = 0;
            tc.Size = new Size(1262, 913);
            tc.TabIndex = 6;
            tc.SelectedIndexChanged += tc_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(tb_mouse_1);
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(btn_pause_1);
            tabPage1.Controls.Add(tb_input_1);
            tabPage1.Controls.Add(btn_start_1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1254, 880);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btn_edges_2);
            tabPage2.Controls.Add(btn_dev_2);
            tabPage2.Controls.Add(panel2);
            tabPage2.Controls.Add(tb_mouse_2);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(btn_pause_2);
            tabPage2.Controls.Add(btn_start_2);
            tabPage2.Controls.Add(tb_input_2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1254, 880);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_edges_2
            // 
            btn_edges_2.Location = new Point(370, 17);
            btn_edges_2.Name = "btn_edges_2";
            btn_edges_2.Size = new Size(94, 29);
            btn_edges_2.TabIndex = 14;
            btn_edges_2.Text = "Edges";
            btn_edges_2.UseVisualStyleBackColor = true;
            btn_edges_2.Click += btn_edges_2_Click;
            // 
            // btn_dev_2
            // 
            btn_dev_2.Location = new Point(481, 17);
            btn_dev_2.Name = "btn_dev_2";
            btn_dev_2.Size = new Size(94, 29);
            btn_dev_2.TabIndex = 13;
            btn_dev_2.Text = "Dev";
            btn_dev_2.UseVisualStyleBackColor = true;
            btn_dev_2.Click += btn_dev_2_Click;
            // 
            // panel2
            // 
            panel2.Location = new Point(3, 54);
            panel2.Name = "panel2";
            panel2.Size = new Size(1248, 823);
            panel2.TabIndex = 12;
            panel2.Paint += panel2_Paint;
            panel2.MouseMove += panel2_MouseMove;
            // 
            // tb_mouse_2
            // 
            tb_mouse_2.BackColor = SystemColors.Control;
            tb_mouse_2.Location = new Point(1119, 17);
            tb_mouse_2.Name = "tb_mouse_2";
            tb_mouse_2.Size = new Size(125, 27);
            tb_mouse_2.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(975, 21);
            label2.Name = "label2";
            label2.Size = new Size(138, 20);
            label2.TabIndex = 9;
            label2.Text = "Mouse coordinates:";
            // 
            // btn_pause_2
            // 
            btn_pause_2.BackColor = SystemColors.Control;
            btn_pause_2.ForeColor = SystemColors.ControlText;
            btn_pause_2.Location = new Point(259, 17);
            btn_pause_2.Name = "btn_pause_2";
            btn_pause_2.Size = new Size(94, 29);
            btn_pause_2.TabIndex = 10;
            btn_pause_2.Text = "Pause";
            btn_pause_2.UseVisualStyleBackColor = false;
            btn_pause_2.Click += btn_pause_2_Click;
            // 
            // btn_start_2
            // 
            btn_start_2.BackColor = SystemColors.Control;
            btn_start_2.ForeColor = SystemColors.ControlText;
            btn_start_2.Location = new Point(148, 17);
            btn_start_2.Name = "btn_start_2";
            btn_start_2.Size = new Size(94, 29);
            btn_start_2.TabIndex = 11;
            btn_start_2.Text = "Start";
            btn_start_2.UseVisualStyleBackColor = false;
            btn_start_2.Click += btn_start_2_Click;
            // 
            // tb_input_2
            // 
            tb_input_2.ForeColor = SystemColors.WindowText;
            tb_input_2.Location = new Point(8, 17);
            tb_input_2.Name = "tb_input_2";
            tb_input_2.Size = new Size(125, 27);
            tb_input_2.TabIndex = 7;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label3);
            tabPage3.Controls.Add(tb_mouse_3);
            tabPage3.Controls.Add(panel3);
            tabPage3.Controls.Add(btn_pause_3);
            tabPage3.Controls.Add(tb_input_3);
            tabPage3.Controls.Add(btn_start_3);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1254, 880);
            tabPage3.TabIndex = 5;
            tabPage3.Text = "3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(975, 20);
            label3.Name = "label3";
            label3.Size = new Size(138, 20);
            label3.TabIndex = 11;
            label3.Text = "Mouse coordinates:";
            // 
            // tb_mouse_3
            // 
            tb_mouse_3.BackColor = SystemColors.Control;
            tb_mouse_3.Location = new Point(1119, 17);
            tb_mouse_3.Name = "tb_mouse_3";
            tb_mouse_3.Size = new Size(125, 27);
            tb_mouse_3.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLightLight;
            panel3.Dock = DockStyle.Bottom;
            panel3.ForeColor = SystemColors.ControlDarkDark;
            panel3.Location = new Point(3, 54);
            panel3.Name = "panel3";
            panel3.Size = new Size(1248, 823);
            panel3.TabIndex = 6;
            panel3.Paint += panel3_Paint;
            panel3.MouseMove += panel3_MouseMove;
            // 
            // btn_pause_3
            // 
            btn_pause_3.BackColor = SystemColors.Control;
            btn_pause_3.ForeColor = SystemColors.ControlText;
            btn_pause_3.Location = new Point(259, 17);
            btn_pause_3.Name = "btn_pause_3";
            btn_pause_3.Size = new Size(94, 29);
            btn_pause_3.TabIndex = 9;
            btn_pause_3.Text = "Pause";
            btn_pause_3.UseVisualStyleBackColor = false;
            btn_pause_3.Click += btn_pause_3_Click;
            // 
            // tb_input_3
            // 
            tb_input_3.ForeColor = SystemColors.WindowText;
            tb_input_3.Location = new Point(8, 17);
            tb_input_3.Name = "tb_input_3";
            tb_input_3.Size = new Size(125, 27);
            tb_input_3.TabIndex = 7;
            // 
            // btn_start_3
            // 
            btn_start_3.BackColor = SystemColors.Control;
            btn_start_3.ForeColor = SystemColors.ControlText;
            btn_start_3.Location = new Point(148, 17);
            btn_start_3.Name = "btn_start_3";
            btn_start_3.Size = new Size(94, 29);
            btn_start_3.TabIndex = 8;
            btn_start_3.Text = "Start";
            btn_start_3.UseVisualStyleBackColor = false;
            btn_start_3.Click += btn_start_3_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(btn_edges_4);
            tabPage4.Controls.Add(btn_dev_4);
            tabPage4.Controls.Add(label4);
            tabPage4.Controls.Add(tb_mouse_4);
            tabPage4.Controls.Add(panel4);
            tabPage4.Controls.Add(btn_pause_4);
            tabPage4.Controls.Add(tb_input_4);
            tabPage4.Controls.Add(btn_start_4);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1254, 880);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // btn_edges_4
            // 
            btn_edges_4.Location = new Point(370, 17);
            btn_edges_4.Name = "btn_edges_4";
            btn_edges_4.Size = new Size(94, 29);
            btn_edges_4.TabIndex = 19;
            btn_edges_4.Text = "Edges";
            btn_edges_4.UseVisualStyleBackColor = true;
            btn_edges_4.Click += btn_edges_4_Click;
            // 
            // btn_dev_4
            // 
            btn_dev_4.Location = new Point(481, 17);
            btn_dev_4.Name = "btn_dev_4";
            btn_dev_4.Size = new Size(94, 29);
            btn_dev_4.TabIndex = 18;
            btn_dev_4.Text = "Dev";
            btn_dev_4.UseVisualStyleBackColor = true;
            btn_dev_4.Click += btn_dev_4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(975, 20);
            label4.Name = "label4";
            label4.Size = new Size(138, 20);
            label4.TabIndex = 17;
            label4.Text = "Mouse coordinates:";
            // 
            // tb_mouse_4
            // 
            tb_mouse_4.BackColor = SystemColors.Control;
            tb_mouse_4.Location = new Point(1119, 17);
            tb_mouse_4.Name = "tb_mouse_4";
            tb_mouse_4.Size = new Size(125, 27);
            tb_mouse_4.TabIndex = 16;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlLightLight;
            panel4.Dock = DockStyle.Bottom;
            panel4.ForeColor = SystemColors.ControlDarkDark;
            panel4.Location = new Point(3, 54);
            panel4.Name = "panel4";
            panel4.Size = new Size(1248, 823);
            panel4.TabIndex = 12;
            panel4.Paint += panel4_Paint;
            panel4.MouseMove += panel4_MouseMove;
            // 
            // btn_pause_4
            // 
            btn_pause_4.BackColor = SystemColors.Control;
            btn_pause_4.ForeColor = SystemColors.ControlText;
            btn_pause_4.Location = new Point(259, 17);
            btn_pause_4.Name = "btn_pause_4";
            btn_pause_4.Size = new Size(94, 29);
            btn_pause_4.TabIndex = 15;
            btn_pause_4.Text = "Pause";
            btn_pause_4.UseVisualStyleBackColor = false;
            btn_pause_4.Click += btn_pause_4_Click;
            // 
            // tb_input_4
            // 
            tb_input_4.ForeColor = SystemColors.WindowText;
            tb_input_4.Location = new Point(8, 17);
            tb_input_4.Name = "tb_input_4";
            tb_input_4.Size = new Size(125, 27);
            tb_input_4.TabIndex = 13;
            // 
            // btn_start_4
            // 
            btn_start_4.BackColor = SystemColors.Control;
            btn_start_4.ForeColor = SystemColors.ControlText;
            btn_start_4.Location = new Point(148, 17);
            btn_start_4.Name = "btn_start_4";
            btn_start_4.Size = new Size(94, 29);
            btn_start_4.TabIndex = 14;
            btn_start_4.Text = "Start";
            btn_start_4.UseVisualStyleBackColor = false;
            btn_start_4.Click += btn_start_4_Click;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1254, 880);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "5";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // timer_2
            // 
            timer_2.Interval = 10;
            timer_2.Tick += timer_2_Tick;
            // 
            // timer_3
            // 
            timer_3.Interval = 5;
            timer_3.Tick += timer_3_Tick;
            // 
            // timer_4
            // 
            timer_4.Interval = 10;
            timer_4.Tick += timer_4_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1262, 913);
            Controls.Add(tc);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            tc.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox tb_input_1;
        private Button btn_start_1;
        private Button btn_pause_1;
        private System.Windows.Forms.Timer timer_1;
        private TextBox tb_mouse_1;
        private Label label1;
        private TabControl tc;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel2;
        private TextBox tb_mouse_2;
        private Label label2;
        private Button btn_pause_2;
        private Button btn_start_2;
        private TextBox tb_input_2;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage3;
        private Label label3;
        private TextBox tb_mouse_3;
        private Panel panel3;
        private Button btn_pause_3;
        private TextBox tb_input_3;
        private Button btn_start_3;
        private System.Windows.Forms.Timer timer_2;
        private System.Windows.Forms.Timer timer_3;
        private Button btn_dev_2;
        private Button btn_edges_2;
        private Label label4;
        private TextBox tb_mouse_4;
        private Panel panel4;
        private Button btn_pause_4;
        private TextBox tb_input_4;
        private Button btn_start_4;
        private Button btn_edges_4;
        private Button btn_dev_4;
        private System.Windows.Forms.Timer timer_4;
    }
}