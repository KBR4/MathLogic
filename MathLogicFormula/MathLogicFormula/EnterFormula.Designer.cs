
namespace MathLogicFormula
{
    partial class EnterFormula
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
            this.FormulaTextbox = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FormulaTextbox
            // 
            this.FormulaTextbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormulaTextbox.Location = new System.Drawing.Point(12, 12);
            this.FormulaTextbox.Multiline = true;
            this.FormulaTextbox.Name = "FormulaTextbox";
            this.FormulaTextbox.Size = new System.Drawing.Size(776, 369);
            this.FormulaTextbox.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(704, 398);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(84, 40);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click_1);
            // 
            // EnterFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.FormulaTextbox);
            this.Name = "EnterFormula";
            this.Text = "EnterFormula";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FormulaTextbox;
        private System.Windows.Forms.Button OKButton;
    }
}