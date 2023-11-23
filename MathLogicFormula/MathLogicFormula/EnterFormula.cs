using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathLogicFormula
{
    public partial class EnterFormula : Form
    {
        public string Formula;
        public EnterFormula()
        {
            InitializeComponent();
        }
        private void OKButton_Click_1(object sender, EventArgs e)
        {
            Formula = FormulaTextbox.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
