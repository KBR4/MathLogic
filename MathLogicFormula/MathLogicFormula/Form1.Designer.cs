
namespace MathLogicFormula
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.enterFormulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateFormulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkValidityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tesnOtricToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transformFormulaAlgoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dNFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cNFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormulaTree = new System.Windows.Forms.TreeView();
            this.FormBox = new System.Windows.Forms.TextBox();
            this.transformedTextbox = new System.Windows.Forms.TextBox();
            this.equivalencyCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ValTextbox = new System.Windows.Forms.TextBox();
            this.compareTimesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormulaFromTableBox = new System.Windows.Forms.TextBox();
            this.IstBox = new System.Windows.Forms.TextBox();
            this.equivalentCheckDiffAlgosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checKEQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enterFormulaToolStripMenuItem,
            this.generateFormulaToolStripMenuItem,
            this.checkValidityToolStripMenuItem,
            this.createTreeToolStripMenuItem,
            this.tesnOtricToolStripMenuItem,
            this.transformFormulaAlgoToolStripMenuItem,
            this.equivalencyCheckToolStripMenuItem,
            this.compareTimesToolStripMenuItem,
            this.equivalentCheckDiffAlgosToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.checKEQToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1191, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // enterFormulaToolStripMenuItem
            // 
            this.enterFormulaToolStripMenuItem.Name = "enterFormulaToolStripMenuItem";
            this.enterFormulaToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.enterFormulaToolStripMenuItem.Text = "Enter Formula";
            this.enterFormulaToolStripMenuItem.Click += new System.EventHandler(this.enterFormulaToolStripMenuItem_Click);
            // 
            // generateFormulaToolStripMenuItem
            // 
            this.generateFormulaToolStripMenuItem.Name = "generateFormulaToolStripMenuItem";
            this.generateFormulaToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.generateFormulaToolStripMenuItem.Text = "Generate Formula";
            this.generateFormulaToolStripMenuItem.Click += new System.EventHandler(this.generateFormulaToolStripMenuItem_Click);
            // 
            // checkValidityToolStripMenuItem
            // 
            this.checkValidityToolStripMenuItem.Name = "checkValidityToolStripMenuItem";
            this.checkValidityToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.checkValidityToolStripMenuItem.Text = "Check Validity";
            this.checkValidityToolStripMenuItem.Click += new System.EventHandler(this.checkValidityToolStripMenuItem_Click);
            // 
            // createTreeToolStripMenuItem
            // 
            this.createTreeToolStripMenuItem.Name = "createTreeToolStripMenuItem";
            this.createTreeToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.createTreeToolStripMenuItem.Text = "Create Tree";
            this.createTreeToolStripMenuItem.Click += new System.EventHandler(this.createTreeToolStripMenuItem_Click);
            // 
            // tesnOtricToolStripMenuItem
            // 
            this.tesnOtricToolStripMenuItem.Name = "tesnOtricToolStripMenuItem";
            this.tesnOtricToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.tesnOtricToolStripMenuItem.Text = "TesnOtric";
            this.tesnOtricToolStripMenuItem.Click += new System.EventHandler(this.tesnOtricToolStripMenuItem_Click);
            // 
            // transformFormulaAlgoToolStripMenuItem
            // 
            this.transformFormulaAlgoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dNFToolStripMenuItem,
            this.cNFToolStripMenuItem});
            this.transformFormulaAlgoToolStripMenuItem.Name = "transformFormulaAlgoToolStripMenuItem";
            this.transformFormulaAlgoToolStripMenuItem.Size = new System.Drawing.Size(156, 20);
            this.transformFormulaAlgoToolStripMenuItem.Text = "Transform Formula (Algo)";
            // 
            // dNFToolStripMenuItem
            // 
            this.dNFToolStripMenuItem.Name = "dNFToolStripMenuItem";
            this.dNFToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.dNFToolStripMenuItem.Text = "DNF";
            this.dNFToolStripMenuItem.Click += new System.EventHandler(this.dNFToolStripMenuItem_Click);
            // 
            // cNFToolStripMenuItem
            // 
            this.cNFToolStripMenuItem.Name = "cNFToolStripMenuItem";
            this.cNFToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.cNFToolStripMenuItem.Text = "CNF";
            this.cNFToolStripMenuItem.Click += new System.EventHandler(this.cNFToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // FormulaTree
            // 
            this.FormulaTree.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormulaTree.Location = new System.Drawing.Point(0, 93);
            this.FormulaTree.Name = "FormulaTree";
            this.FormulaTree.Size = new System.Drawing.Size(1191, 344);
            this.FormulaTree.TabIndex = 1;
            // 
            // FormBox
            // 
            this.FormBox.Enabled = false;
            this.FormBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBox.Location = new System.Drawing.Point(0, 28);
            this.FormBox.Multiline = true;
            this.FormBox.Name = "FormBox";
            this.FormBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FormBox.Size = new System.Drawing.Size(1191, 59);
            this.FormBox.TabIndex = 2;
            // 
            // transformedTextbox
            // 
            this.transformedTextbox.Enabled = false;
            this.transformedTextbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transformedTextbox.Location = new System.Drawing.Point(0, 443);
            this.transformedTextbox.Multiline = true;
            this.transformedTextbox.Name = "transformedTextbox";
            this.transformedTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.transformedTextbox.Size = new System.Drawing.Size(1191, 63);
            this.transformedTextbox.TabIndex = 3;
            // 
            // equivalencyCheckToolStripMenuItem
            // 
            this.equivalencyCheckToolStripMenuItem.Name = "equivalencyCheckToolStripMenuItem";
            this.equivalencyCheckToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.equivalencyCheckToolStripMenuItem.Text = "Equivalence check";
            this.equivalencyCheckToolStripMenuItem.Click += new System.EventHandler(this.equivalencyCheckToolStripMenuItem_Click);
            // 
            // ValTextbox
            // 
            this.ValTextbox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValTextbox.Location = new System.Drawing.Point(0, 513);
            this.ValTextbox.Multiline = true;
            this.ValTextbox.Name = "ValTextbox";
            this.ValTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ValTextbox.Size = new System.Drawing.Size(1191, 53);
            this.ValTextbox.TabIndex = 4;
            // 
            // compareTimesToolStripMenuItem
            // 
            this.compareTimesToolStripMenuItem.Name = "compareTimesToolStripMenuItem";
            this.compareTimesToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.compareTimesToolStripMenuItem.Text = "CompareDNFTimes";
            this.compareTimesToolStripMenuItem.Click += new System.EventHandler(this.compareTimesToolStripMenuItem_Click);
            // 
            // FormulaFromTableBox
            // 
            this.FormulaFromTableBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormulaFromTableBox.Location = new System.Drawing.Point(0, 572);
            this.FormulaFromTableBox.Multiline = true;
            this.FormulaFromTableBox.Name = "FormulaFromTableBox";
            this.FormulaFromTableBox.Size = new System.Drawing.Size(1191, 55);
            this.FormulaFromTableBox.TabIndex = 5;
            // 
            // IstBox
            // 
            this.IstBox.Location = new System.Drawing.Point(0, 634);
            this.IstBox.Multiline = true;
            this.IstBox.Name = "IstBox";
            this.IstBox.Size = new System.Drawing.Size(1191, 41);
            this.IstBox.TabIndex = 6;
            // 
            // equivalentCheckDiffAlgosToolStripMenuItem
            // 
            this.equivalentCheckDiffAlgosToolStripMenuItem.Name = "equivalentCheckDiffAlgosToolStripMenuItem";
            this.equivalentCheckDiffAlgosToolStripMenuItem.Size = new System.Drawing.Size(156, 20);
            this.equivalentCheckDiffAlgosToolStripMenuItem.Text = "EquivalentCheckDiffAlgos";
            this.equivalentCheckDiffAlgosToolStripMenuItem.Click += new System.EventHandler(this.equivalentCheckDiffAlgosToolStripMenuItem_Click);
            // 
            // checKEQToolStripMenuItem
            // 
            this.checKEQToolStripMenuItem.Name = "checKEQToolStripMenuItem";
            this.checKEQToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.checKEQToolStripMenuItem.Text = "ChecKEQ";
            this.checKEQToolStripMenuItem.Click += new System.EventHandler(this.checKEQToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 677);
            this.Controls.Add(this.IstBox);
            this.Controls.Add(this.FormulaFromTableBox);
            this.Controls.Add(this.ValTextbox);
            this.Controls.Add(this.transformedTextbox);
            this.Controls.Add(this.FormBox);
            this.Controls.Add(this.FormulaTree);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generateFormulaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkValidityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TreeView FormulaTree;
        private System.Windows.Forms.ToolStripMenuItem enterFormulaToolStripMenuItem;
        private System.Windows.Forms.TextBox FormBox;
        private System.Windows.Forms.ToolStripMenuItem createTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transformFormulaAlgoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dNFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cNFToolStripMenuItem;
        private System.Windows.Forms.TextBox transformedTextbox;
        private System.Windows.Forms.ToolStripMenuItem tesnOtricToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equivalencyCheckToolStripMenuItem;
        private System.Windows.Forms.TextBox ValTextbox;
        private System.Windows.Forms.ToolStripMenuItem compareTimesToolStripMenuItem;
        private System.Windows.Forms.TextBox FormulaFromTableBox;
        private System.Windows.Forms.TextBox IstBox;
        private System.Windows.Forms.ToolStripMenuItem equivalentCheckDiffAlgosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checKEQToolStripMenuItem;
    }
}

