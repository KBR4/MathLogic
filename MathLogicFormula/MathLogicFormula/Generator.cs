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
    public partial class Generator : Form
    {
        private string Variables = "abcdefghjkmnopqrstuvwxyz";
        private string Operations = ">|&";
        private string Neg = "!";
        private Random rnd = new Random();
        public string Formula;
        public Generator()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            int iNumbOperations = (int) OperationsNumeric.Value;
            if (iNumbOperations == 0)
            {
                string s = GetRandomSingleVariable();
                if (rnd.Next(0, 2) == 1)
                {
                    s = "(!" + s + ")";
                }
                ResultBox.Text = s;
                return;
            }
            else
            {
                ResultBox.Text = GenerateFormula(iNumbOperations);
                return;
            }
        }

        private string GenerateFormula (int iNumbOperations)
        {
            if (iNumbOperations == 0)
            {
                string s = GetRandomSingleVariable();

                //раскомментарить + зациклить если хотим создать формулу вида (!(!(...(!(а)))..))
                //if (rnd.Next(0, 2) == 1)
                //{
                //    s = "(!" + s + ")";
                //}
                return s;
            }
            else
            {
                string sOperation = Operations[rnd.Next(0, Operations.Length)].ToString();
                int LeftOperationCount = rnd.Next(0, iNumbOperations);
                int RightOperationCount = iNumbOperations - LeftOperationCount - 1;
                string sLeft = GenerateFormula(LeftOperationCount);
                //рандом отрицания правой части
                if (rnd.Next(0, 2 )==1)
                {
                    sLeft = "(!" + sLeft + ")";
                }
                string sRight = GenerateFormula(RightOperationCount);
                //рандом отрицания левой части
                if (rnd.Next(0, 2) == 1)
                {
                    sRight = "(!" + sRight + ")";
                }
                string sRes = "(" + sLeft + sOperation + sRight + ")";
                //рандом отрицания скобки
                if (rnd.Next(0,2) == 1)
                {
                    sRes = "(!" + sRes + ")";
                }
                return sRes;
            }
        }

        private string GetRandomSingleVariable()
        {
            string s = Variables[rnd.Next(0, Variables.Length)].ToString();
            return s;
            //if (rnd.Next(0, 2) == 0)
            //{
            //    return s;
            //}
            //else
            //{
            //    return "(!" + s + ")";
            //}
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Formula = ResultBox.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
