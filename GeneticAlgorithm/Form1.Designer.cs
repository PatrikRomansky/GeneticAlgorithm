namespace GeneticAlgorithm
{
    partial class FormGAWindow
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
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelFitness = new System.Windows.Forms.Label();
            this.labelGeneration = new System.Windows.Forms.Label();
            this.pictureBoxBestInd = new System.Windows.Forms.PictureBox();
            this.pictureBoxTarget = new System.Windows.Forms.PictureBox();
            this.comboBoxControllers = new System.Windows.Forms.ComboBox();
            this.label_controller = new System.Windows.Forms.Label();
            this.selectImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBestInd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Location = new System.Drawing.Point(73, 510);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(111, 39);
            this.buttonStartStop.TabIndex = 40;
            this.buttonStartStop.Text = "START";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSpeed.Location = new System.Drawing.Point(17, 399);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(65, 22);
            this.labelSpeed.TabIndex = 39;
            this.labelSpeed.Text = "Speed:";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(17, 364);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(55, 22);
            this.labelTime.TabIndex = 38;
            this.labelTime.Text = "Time:";
            // 
            // labelFitness
            // 
            this.labelFitness.AutoSize = true;
            this.labelFitness.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFitness.Location = new System.Drawing.Point(17, 438);
            this.labelFitness.Name = "labelFitness";
            this.labelFitness.Size = new System.Drawing.Size(71, 22);
            this.labelFitness.TabIndex = 37;
            this.labelFitness.Text = "Fitness:";
            // 
            // labelGeneration
            // 
            this.labelGeneration.AutoSize = true;
            this.labelGeneration.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGeneration.Location = new System.Drawing.Point(17, 471);
            this.labelGeneration.Name = "labelGeneration";
            this.labelGeneration.Size = new System.Drawing.Size(104, 22);
            this.labelGeneration.TabIndex = 36;
            this.labelGeneration.Text = "Generation:";
            // 
            // pictureBoxBestInd
            // 
            this.pictureBoxBestInd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxBestInd.Location = new System.Drawing.Point(301, 32);
            this.pictureBoxBestInd.Name = "pictureBoxBestInd";
            this.pictureBoxBestInd.Size = new System.Drawing.Size(500, 500);
            this.pictureBoxBestInd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBestInd.TabIndex = 34;
            this.pictureBoxBestInd.TabStop = false;
            // 
            // pictureBoxTarget
            // 
            this.pictureBoxTarget.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxTarget.Location = new System.Drawing.Point(21, 32);
            this.pictureBoxTarget.Name = "pictureBoxTarget";
            this.pictureBoxTarget.Size = new System.Drawing.Size(200, 200);
            this.pictureBoxTarget.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxTarget.TabIndex = 33;
            this.pictureBoxTarget.TabStop = false;
            // 
            // comboBoxControllers
            // 
            this.comboBoxControllers.FormattingEnabled = true;
            this.comboBoxControllers.Location = new System.Drawing.Point(21, 331);
            this.comboBoxControllers.Name = "comboBoxControllers";
            this.comboBoxControllers.Size = new System.Drawing.Size(177, 21);
            this.comboBoxControllers.TabIndex = 32;
            // 
            // label_controller
            // 
            this.label_controller.AutoSize = true;
            this.label_controller.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_controller.Location = new System.Drawing.Point(58, 295);
            this.label_controller.Name = "label_controller";
            this.label_controller.Size = new System.Drawing.Size(93, 22);
            this.label_controller.TabIndex = 31;
            this.label_controller.Text = "Controller";
            // 
            // selectImage
            // 
            this.selectImage.Location = new System.Drawing.Point(51, 248);
            this.selectImage.Name = "selectImage";
            this.selectImage.Size = new System.Drawing.Size(113, 23);
            this.selectImage.TabIndex = 30;
            this.selectImage.Text = "Select image";
            this.selectImage.UseVisualStyleBackColor = true;
            this.selectImage.Click += new System.EventHandler(this.selectImage_Click);
            // 
            // FormGAWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 566);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelFitness);
            this.Controls.Add(this.labelGeneration);
            this.Controls.Add(this.pictureBoxBestInd);
            this.Controls.Add(this.pictureBoxTarget);
            this.Controls.Add(this.comboBoxControllers);
            this.Controls.Add(this.label_controller);
            this.Controls.Add(this.selectImage);
            this.Name = "FormGAWindow";
            this.Text = "Genetic algorithm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBestInd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelFitness;
        private System.Windows.Forms.Label labelGeneration;
        private System.Windows.Forms.PictureBox pictureBoxBestInd;
        private System.Windows.Forms.PictureBox pictureBoxTarget;
        private System.Windows.Forms.ComboBox comboBoxControllers;
        private System.Windows.Forms.Label label_controller;
        private System.Windows.Forms.Button selectImage;
    }
}

