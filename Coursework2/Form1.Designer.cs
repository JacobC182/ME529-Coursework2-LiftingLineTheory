namespace Coursework2
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
            this.SolveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.spanBox = new System.Windows.Forms.TextBox();
            this.chordBox = new System.Windows.Forms.TextBox();
            this.taperBox = new System.Windows.Forms.TextBox();
            this.liftCurveBox = new System.Windows.Forms.TextBox();
            this.angleBox = new System.Windows.Forms.TextBox();
            this.washoutBox = new System.Windows.Forms.TextBox();
            this.zeroLiftBox = new System.Windows.Forms.TextBox();
            this.DragBox = new System.Windows.Forms.TextBox();
            this.LiftBox = new System.Windows.Forms.TextBox();
            this.A7Box = new System.Windows.Forms.TextBox();
            this.A5Box = new System.Windows.Forms.TextBox();
            this.A3Box = new System.Windows.Forms.TextBox();
            this.A1Box = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InfoButton = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SolveButton
            // 
            this.SolveButton.Location = new System.Drawing.Point(695, 5);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(75, 40);
            this.SolveButton.TabIndex = 0;
            this.SolveButton.Text = "Solve";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(448, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Span";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Root Chord";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Taper Ratio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Lift Curve Slope";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Alpha (zero-lift)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(427, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Washout";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(391, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Angle of Attack";
            // 
            // spanBox
            // 
            this.spanBox.Location = new System.Drawing.Point(481, 71);
            this.spanBox.Name = "spanBox";
            this.spanBox.Size = new System.Drawing.Size(100, 23);
            this.spanBox.TabIndex = 9;
            // 
            // chordBox
            // 
            this.chordBox.Location = new System.Drawing.Point(481, 100);
            this.chordBox.Name = "chordBox";
            this.chordBox.Size = new System.Drawing.Size(100, 23);
            this.chordBox.TabIndex = 10;
            // 
            // taperBox
            // 
            this.taperBox.Location = new System.Drawing.Point(481, 129);
            this.taperBox.Name = "taperBox";
            this.taperBox.Size = new System.Drawing.Size(100, 23);
            this.taperBox.TabIndex = 11;
            // 
            // liftCurveBox
            // 
            this.liftCurveBox.Location = new System.Drawing.Point(481, 158);
            this.liftCurveBox.Name = "liftCurveBox";
            this.liftCurveBox.Size = new System.Drawing.Size(100, 23);
            this.liftCurveBox.TabIndex = 12;
            // 
            // angleBox
            // 
            this.angleBox.Location = new System.Drawing.Point(481, 245);
            this.angleBox.Name = "angleBox";
            this.angleBox.Size = new System.Drawing.Size(100, 23);
            this.angleBox.TabIndex = 15;
            // 
            // washoutBox
            // 
            this.washoutBox.Location = new System.Drawing.Point(481, 216);
            this.washoutBox.Name = "washoutBox";
            this.washoutBox.Size = new System.Drawing.Size(100, 23);
            this.washoutBox.TabIndex = 14;
            // 
            // zeroLiftBox
            // 
            this.zeroLiftBox.Location = new System.Drawing.Point(481, 187);
            this.zeroLiftBox.Name = "zeroLiftBox";
            this.zeroLiftBox.Size = new System.Drawing.Size(100, 23);
            this.zeroLiftBox.TabIndex = 13;
            // 
            // DragBox
            // 
            this.DragBox.Location = new System.Drawing.Point(670, 216);
            this.DragBox.Name = "DragBox";
            this.DragBox.ReadOnly = true;
            this.DragBox.Size = new System.Drawing.Size(100, 23);
            this.DragBox.TabIndex = 21;
            // 
            // LiftBox
            // 
            this.LiftBox.Location = new System.Drawing.Point(670, 187);
            this.LiftBox.Name = "LiftBox";
            this.LiftBox.ReadOnly = true;
            this.LiftBox.Size = new System.Drawing.Size(100, 23);
            this.LiftBox.TabIndex = 20;
            // 
            // A7Box
            // 
            this.A7Box.Location = new System.Drawing.Point(670, 158);
            this.A7Box.Name = "A7Box";
            this.A7Box.ReadOnly = true;
            this.A7Box.Size = new System.Drawing.Size(100, 23);
            this.A7Box.TabIndex = 19;
            // 
            // A5Box
            // 
            this.A5Box.Location = new System.Drawing.Point(670, 129);
            this.A5Box.Name = "A5Box";
            this.A5Box.ReadOnly = true;
            this.A5Box.Size = new System.Drawing.Size(100, 23);
            this.A5Box.TabIndex = 18;
            // 
            // A3Box
            // 
            this.A3Box.Location = new System.Drawing.Point(670, 100);
            this.A3Box.Name = "A3Box";
            this.A3Box.ReadOnly = true;
            this.A3Box.Size = new System.Drawing.Size(100, 23);
            this.A3Box.TabIndex = 17;
            // 
            // A1Box
            // 
            this.A1Box.Location = new System.Drawing.Point(670, 71);
            this.A1Box.Name = "A1Box";
            this.A1Box.ReadOnly = true;
            this.A1Box.Size = new System.Drawing.Size(100, 23);
            this.A1Box.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(641, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 15);
            this.label9.TabIndex = 28;
            this.label9.Text = "CD";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(643, 190);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 15);
            this.label10.TabIndex = 27;
            this.label10.Text = "CL";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(643, 161);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 15);
            this.label11.TabIndex = 26;
            this.label11.Text = "A7";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(643, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "A5";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(643, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 15);
            this.label13.TabIndex = 24;
            this.label13.Text = "A3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(643, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 15);
            this.label14.TabIndex = 23;
            this.label14.Text = "A1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(508, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Inputs";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(690, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 20);
            this.label15.TabIndex = 30;
            this.label15.Text = "Outputs";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 258);
            this.panel1.TabIndex = 36;
            // 
            // InfoButton
            // 
            this.InfoButton.Location = new System.Drawing.Point(695, 300);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(75, 40);
            this.InfoButton.TabIndex = 37;
            this.InfoButton.Text = "Info";
            this.InfoButton.UseVisualStyleBackColor = true;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(579, 75);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 15);
            this.label16.TabIndex = 38;
            this.label16.Text = "(metres)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(579, 102);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 15);
            this.label17.TabIndex = 39;
            this.label17.Text = "(metres)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(579, 160);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 15);
            this.label18.TabIndex = 41;
            this.label18.Text = "(/rad)";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(579, 132);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 15);
            this.label19.TabIndex = 40;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(579, 220);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 15);
            this.label20.TabIndex = 43;
            this.label20.Text = "(degrees)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(579, 190);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 15);
            this.label21.TabIndex = 42;
            this.label21.Text = "(degrees)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(579, 248);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 15);
            this.label22.TabIndex = 45;
            this.label22.Text = "(degrees)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.InfoButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DragBox);
            this.Controls.Add(this.LiftBox);
            this.Controls.Add(this.A7Box);
            this.Controls.Add(this.A5Box);
            this.Controls.Add(this.A3Box);
            this.Controls.Add(this.A1Box);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.angleBox);
            this.Controls.Add(this.washoutBox);
            this.Controls.Add(this.zeroLiftBox);
            this.Controls.Add(this.liftCurveBox);
            this.Controls.Add(this.taperBox);
            this.Controls.Add(this.chordBox);
            this.Controls.Add(this.spanBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SolveButton);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 400);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "Form1";
            this.Text = "Lifting Line Theory Calculator - Coursework 2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SolveButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox spanBox;
        private TextBox chordBox;
        private TextBox taperBox;
        private TextBox liftCurveBox;
        private TextBox angleBox;
        private TextBox washoutBox;
        private TextBox zeroLiftBox;
        private TextBox DragBox;
        private TextBox LiftBox;
        private TextBox A7Box;
        private TextBox A5Box;
        private TextBox A3Box;
        private TextBox A1Box;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label8;
        private Label label15;
        private Panel panel1;
        private Button InfoButton;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
    }
}