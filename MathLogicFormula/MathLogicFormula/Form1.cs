using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Diagnostics;

namespace MathLogicFormula
{
    public partial class Form1 : Form
    {
        private string CurrentFormula;      //Текущая формула
        private bool Valid = false;         //Корректность
        private bool TreeCreated = false;   //Создано ли дерево
        private bool TesnOtricApplied = false; //Применены ли тесные отрицания
        public Form1()
        {
            InitializeComponent();
        }
        //Test Change
        private void generateFormulaToolStripMenuItem_Click(object sender, EventArgs e) //Генерация формулы
        {
            var form = new Generator();
            DialogResult dr = form.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                CurrentFormula = form.Formula;
                FormBox.Text = CurrentFormula;
                FormulaTree.Nodes.Clear();
                Valid = false;
                TreeCreated = false;
                TesnOtricApplied = false;
            }
        }

        private void checkValidityToolStripMenuItem_Click(object sender, EventArgs e) //Проверка формула или нет
        {
            if (string.IsNullOrEmpty(CurrentFormula))
            {
                MessageBox.Show("Enter Formula!");
                Valid = false;
                TreeCreated = false;
                TesnOtricApplied = false;
            }
            else
            {
                if (CheckFormula(CurrentFormula) == true)
                {
                    Valid = true;
                    MessageBox.Show("Formula Is Correct");
                }
                else
                {
                    Valid = false;
                    MessageBox.Show("Formula Is Incorrect");
                }
            }
        }

        private bool CheckFormula (string s) //Проверка формулы на корректность
        {
            if (string.IsNullOrEmpty(s))    //пустая строка - не формула
            {
                return false;
            }
            if (s.Length == 1 && char.IsLetter(s[0]))   //случай с единичным символом - должна быть переменная
            {
                return true;
            }
            else     //не единичная длина формулы
            {
                if (s[0] == '(' && s[s.Length - 1] == ')')  //если формула не состоит только из переменной, она обернута в скобки
                {
                    if (s[1] == '!')   //случай с отрицанием
                    {
                        return CheckFormula(s.Substring(2, s.Length - 3));
                    }
                    else // случай с операциями внутри скобки
                    {
                        int BracketCnt = 0; //проверка по балансу скобок
                        for (int i = 1; i<s.Length - 1; i++)
                        {
                            if (s[i] == '(')
                            {
                                BracketCnt++;
                            }
                            if (s[i] == ')')
                            {
                                BracketCnt--;
                            }
                            //если найдена операция с верным балансом скобок, проверка левой и правой частей
                            if ((s[i]== '|' || s[i] == '&' || s[i] == '>') && (BracketCnt == 0))
                            {
                                string sFirst = s.Substring(1, i - 1);
                                string sSecond = s.Substring(i + 1, s.Length - 2 - i);
                                return (CheckFormula(sFirst) && CheckFormula(sSecond));
                            }
                        }   
                        //если операции с верным балансом скобок не найдено, формула неверна
                        return false;
                    }
                }
                else //если не обернута в скобки, то формула неверна
                {
                    return false;
                }
            }
        }
        private void enterFormulaToolStripMenuItem_Click(object sender, EventArgs e) //Ввод формулы
        {
            var form = new EnterFormula();
            DialogResult dr = form.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                CurrentFormula = form.Formula;
                FormBox.Text = CurrentFormula;
                FormulaTree.Nodes.Clear();
                Valid = false;
                TreeCreated = false;
                TesnOtricApplied = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) //Выход
        {
            this.Close();
        }

        private void createTreeToolStripMenuItem_Click(object sender, EventArgs e) //Дерево строится только для корректных формул
        {
            if (Valid == true)
            {
                FormulaTree.Nodes.Clear();
                PopulateTree(CurrentFormula, null);
                FormulaTree.ExpandAll();
                TreeCreated = true;
            }
            else
            {
                MessageBox.Show("Check if the formula is correct first!");
            }
        }      
        private void PopulateTree(string s, TreeNode parent) //Построение дерева по формуле
        {
            if (parent == null) //нулевой стартовый нод
            {
                if (s.Length == 1) //т.к. формула корректна
                {
                    FormulaTree.Nodes.Add(s);
                }
                else //т.к. формула корректна, то есть 2 случая - внешнее отрицание и операция
                {
                    if (s[1] == '!') //отрицание
                    {
                        TreeNode StartNode = FormulaTree.Nodes.Add("!");
                        PopulateTree(s.Substring(2, s.Length - 3), StartNode);
                    }
                    else //операция
                    {
                        int BracketCnt = 0; //проверка по балансу скобок
                        string sFirst = "", sSecond= "", sOperation= "";
                        for (int i = 1; i < s.Length - 1; i++)
                        {
                            if (s[i] == '(')
                            {
                                BracketCnt++;
                            }
                            if (s[i] == ')')
                            {
                                BracketCnt--;
                            }
                            //если найдена операция с верным балансом скобок, проверка левой и правой частей
                            if ((s[i] == '|' || s[i] == '&' || s[i] == '>') && (BracketCnt == 0))
                            {
                                sOperation = s[i].ToString();
                                sFirst = s.Substring(1, i - 1);
                                sSecond = s.Substring(i + 1, s.Length - 2 - i);
                                break;
                            }
                        }
                        TreeNode StartNode = FormulaTree.Nodes.Add(sOperation);
                        PopulateTree(sFirst, StartNode);
                        PopulateTree(sSecond, StartNode);
                    }
                }           
            }
            else //случай когда стартовый нод ненулевой
            {
                if (s.Length == 1)
                {
                    parent.Nodes.Add(s);
                }
                else
                {
                    if (s[1] == '!')
                    {
                        TreeNode tn = parent.Nodes.Add("!");
                        PopulateTree(s.Substring(2, s.Length - 3), tn);
                    }
                    else
                    {
                        int BracketCnt = 0; //проверка по балансу скобок
                        string sFirst = "", sSecond = "", sOperation = "";
                        for (int i = 1; i < s.Length - 1; i++)
                        {
                            if (s[i] == '(')
                            {
                                BracketCnt++;
                            }
                            if (s[i] == ')')
                            {
                                BracketCnt--;
                            }
                            //если найдена операция с верным балансом скобок, проверка левой и правой частей
                            if ((s[i] == '|' || s[i] == '&' || s[i] == '>') && (BracketCnt == 0))
                            {
                                sOperation = s[i].ToString();
                                sFirst = s.Substring(1, i - 1);
                                sSecond = s.Substring(i + 1, s.Length - 2 - i);
                                break;
                            }
                        }
                        TreeNode tn = parent.Nodes.Add(sOperation);
                        PopulateTree(sFirst, tn);
                        PopulateTree(sSecond, tn);
                    }
                }
            }
        }

        private void dNFToolStripMenuItem_Click(object sender, EventArgs e) //приведение к ДНФ (если приведено к тесным отр)
        {
            if (TreeCreated && TesnOtricApplied)
            {
                RiseOR();
            }
        }

        private void cNFToolStripMenuItem_Click(object sender, EventArgs e) //приведение к КНФ (если приведено к тесным отр)
        {
            if (TreeCreated && TesnOtricApplied)
            {
                RiseAND();
            }
        }
        private void RiseOR()   //Поднять все дизъюнкции выше конъюнкций - для ДНФ
        {
            FindOR(FormulaTree.Nodes[0]);
            FormulaTree.ExpandAll();
            transformedTextbox.Text = GetFormulaFromTreeView(FormulaTree.Nodes[0]);
        }

        private void FindOR(TreeNode CurNode)   //поиск |
        {
            switch (CurNode.Text)  //проверяем нод
            {
                case "|":        //если |
                    if (CurNode.Parent == null || CurNode.Parent.Text == "|")   //если его родитель пустой, т.е. это верхний нод - запуск поиска от детей
                    {
                        FindOR(CurNode.Nodes[0]);
                        FindOR(CurNode.Nodes[1]);
                    }
                    else //это не верхний нод
                    {                                   
                        while (CurNode.Parent.Text == "&") //до тех пор пока его родитель = & (других не может быть ввиду применения алгоритма тесных отрицаний)
                        {                                  //если родитель |, то мы закончили работу, можно снова идти вниз - вызов FindOR
                            TreeNode ParentNode = CurNode.Parent;   //родительский нод на который будем подниматься
                            TreeNode F1 = CurNode.Nodes[0];     
                            TreeNode F2 = CurNode.Nodes[1];

                            int index = ParentNode.Nodes.IndexOf(CurNode);
                            TreeNode F3 = ParentNode.Nodes[(index + 1) % 2]; //F3 - соседний по индексу нод с CurNode
                            TreeNode CopyF3 = (TreeNode)F3.Clone();

                            ParentNode.Text = "|";      //родительский нод становится |
                            ParentNode.Nodes.Clear();   //очищение нодов
                            ParentNode.Nodes.Add("&");  //потомки становятся &F1F3 и &F2F3
                            ParentNode.Nodes.Add("&");

                            TreeNode LeftParNode = ParentNode.Nodes[0];
                            TreeNode RightParNode = ParentNode.Nodes[1];

                            LeftParNode.Nodes.Add(F1);
                            LeftParNode.Nodes.Add(F3);
                            RightParNode.Nodes.Add(F2);
                            RightParNode.Nodes.Add(CopyF3);

                            CurNode = ParentNode;           //текущий нод = тот на котором сейчас |

                            if (CurNode.Parent == null || CurNode.Parent.Text == "|")     //если он стал верхним (или уперся в такой же) - все хорошо, запускаем поиск вниз
                            {
                                FindOR(CurNode.Nodes[0]);
                                FindOR(CurNode.Nodes[1]);
                                break;
                            }
                        }
                    }                  
                    break;

                case "&":
                    FindOR(CurNode.Nodes[0]);
                    FindOR(CurNode.Nodes[1]);
                    break;

                default:
                    break;
            }

        }

        private void RiseAND() //Поднять все конъюнкции выше дизъюнкций - для КНФ
        {
            FindAND(FormulaTree.Nodes[0]);
            transformedTextbox.Text = GetFormulaFromTreeView(FormulaTree.Nodes[0]);
            FormulaTree.ExpandAll();
        }
        private void FindAND(TreeNode CurNode)      //Аналогичная функция для КНФ - не проверялась
        {
            switch (CurNode.Text)  //проверяем нод
            {
                case "&":        //если |
                    if (CurNode.Parent == null || CurNode.Parent.Text == "&")   //если его родитель пустой, т.е. это верхний нод - запуск поиска от детей
                    {
                        FindAND(CurNode.Nodes[0]);
                        FindAND(CurNode.Nodes[1]);
                    }
                    else //это не верхний нод
                    {
                        while (CurNode.Parent.Text == "|") //до тех пор пока его родитель = & (других не может быть ввиду применения алгоритма тесных отрицаний)
                        {                                  //если родитель |, то мы закончили работу, можно снова идти вниз - вызов FindOR
                            TreeNode ParentNode = CurNode.Parent;   //родительский нод на который будем подниматься
                            TreeNode F1 = CurNode.Nodes[0];
                            TreeNode F2 = CurNode.Nodes[1];

                            int index = ParentNode.Nodes.IndexOf(CurNode);
                            TreeNode F3 = ParentNode.Nodes[(index + 1) % 2]; //F3 - соседний по индексу нод с CurNode
                            TreeNode CopyF3 = (TreeNode)F3.Clone();

                            ParentNode.Text = "&";      //родительский нод становится |
                            ParentNode.Nodes.Clear();   //очищение нодов
                            ParentNode.Nodes.Add("|");  //потомки становятся &F1F3 и &F2F3
                            ParentNode.Nodes.Add("|");

                            TreeNode LeftParNode = ParentNode.Nodes[0];
                            TreeNode RightParNode = ParentNode.Nodes[1];

                            LeftParNode.Nodes.Add(F1);
                            LeftParNode.Nodes.Add(F3);
                            RightParNode.Nodes.Add(F2);
                            RightParNode.Nodes.Add(CopyF3);

                            CurNode = ParentNode;           //текущий нод = тот на котором сейчас |

                            if (CurNode.Parent == null || CurNode.Parent.Text == "&")     //если он стал верхним (или уперся в такой же) - все хорошо, запускаем поиск вниз
                            {
                                FindAND(CurNode.Nodes[0]);
                                FindAND(CurNode.Nodes[1]);
                                break;
                            }
                        }
                    }
                    break;

                case "|":
                    FindAND(CurNode.Nodes[0]);
                    FindAND(CurNode.Nodes[1]);
                    break;

                default:
                    break;
            }
        }

        private void TesnOtric()    //Алгоритм приведения к тесным отрицаниям
        {
            KillImplications(FormulaTree.Nodes[0]);
            //transformedTextbox.Text = GetFormulaFromTreeView(FormulaTree.Nodes[0]);
            DrownNegatives(FormulaTree.Nodes[0]);
            transformedTextbox.Text = GetFormulaFromTreeView(FormulaTree.Nodes[0]);
            FormulaTree.ExpandAll();
            TesnOtricApplied = true;
        }
        private void KillImplications(TreeNode CurNode) //Уничтожение импликаций
        {
            //Считаем что формула построена верно
            if (CurNode.Text == ">")    //для импликации меняем дерево, потом спускаемся
            {
                TreeNode LeftNode = CurNode.Nodes[0];
                TreeNode RightNode = CurNode.Nodes[1];
                CurNode.Text = "|";
                CurNode.Nodes.RemoveAt(0);

                TreeNode ExNode = new TreeNode("!");
                CurNode.Nodes.Insert(0, ExNode);
                ExNode.Nodes.Add(LeftNode);

                //CurNode.Nodes[0] = new TreeNode("!");
                //CurNode.Nodes[0].Nodes.Add(LeftNode);

                KillImplications(LeftNode);
                KillImplications(RightNode);
            }
            else  //для остальных случаев спускаемся по дереву
            {
                if (CurNode.Text == "!")
                {
                    KillImplications(CurNode.Nodes[0]);
                }
                if (CurNode.Text == "&" || CurNode.Text == "|")
                {
                    KillImplications(CurNode.Nodes[0]);
                    KillImplications(CurNode.Nodes[1]);
                }
            }
        }
        private void DrownNegatives(TreeNode CurNode) //Утопление отрицаний
        {
            TreeNode BaseNode = CurNode.Parent; //Родитель текущего нода, если null, то наш нод стартовый
            if (CurNode.Text == "!")    //Если текущий нод = !
            {
                TreeNode NextNode = CurNode.Nodes[0];   //Первый потомок текущего нода (известно, что он единственный)
                switch (NextNode.Text)
                {
                    case "!":   //! -> ! - удаление, переход к следующему
                        TreeNode SkipToNode = NextNode.Nodes[0]; //Нод после ! !
                        if (BaseNode == null)   //Если предок текущего нода пуст (т.е. текущий = стартовый)
                        {
                            FormulaTree.Nodes.RemoveAt(0); //удаляем исходный нод
                            FormulaTree.Nodes.Add(SkipToNode);  //стартовый нод = нод после ! !
                            DrownNegatives(FormulaTree.Nodes[0]);  //от него запускаем операцию снова
                        }
                        else //Предок текущего нода не пуст - BaseNode
                        {
                            int index = BaseNode.Nodes.IndexOf(CurNode);    //находим индекс удаляемого нода

                            BaseNode.Nodes.RemoveAt(index); //удаляем текущий нод
                            BaseNode.Nodes.Insert(index, SkipToNode); //вставляем на то же место нод после ! !
                            DrownNegatives(BaseNode.Nodes[index]); //запускаем операцию от него
                        }
                        break;
                    case "&":   // !& - переход к | ! !
                        TreeNode LeftNode = NextNode.Nodes[0];  //левый нод
                        TreeNode RightNode = NextNode.Nodes[1]; //правый нод
                        NextNode.Text = "|";                    //меняем операцию & -> |

                        NextNode.Nodes.Clear();                 //удаляем все ноды
                        NextNode.Nodes.Add(new TreeNode("!"));  //добавляем ! в левый нод
                        NextNode.Nodes.Add(new TreeNode("!"));  //добавляем ! в правый нод
                        NextNode.Nodes[0].Nodes.Add(LeftNode);  //добавляем к ! предыдущий левый
                        NextNode.Nodes[1].Nodes.Add(RightNode); //добавляем к ! предыдущий правый

                        if (BaseNode == null)                   //если CurNode (который = !) стартовый
                        {
                            FormulaTree.Nodes.RemoveAt(0);          //удаляем его
                            FormulaTree.Nodes.Add(NextNode);        //NextNode = | - стартовый
                            DrownNegatives(NextNode);
                        }
                        else                                    //CurNode = ! не базовый
                        {
                            int index = BaseNode.Nodes.IndexOf(CurNode); //индекс CurNode от базового нода

                            BaseNode.Nodes.RemoveAt(index);            //удаляем CurNode
                            BaseNode.Nodes.Insert(index, NextNode);    //вставляем на это место NextNode
                            DrownNegatives(NextNode);
                        }

                        break;
                    case "|":   // !| переход к & ! ! аналогичен предыдущему
                        TreeNode LeftNode2 = NextNode.Nodes[0];
                        TreeNode RightNode2 = NextNode.Nodes[1];
                        NextNode.Text = "&";

                        NextNode.Nodes.Clear();
                        NextNode.Nodes.Add(new TreeNode("!"));
                        NextNode.Nodes.Add(new TreeNode("!"));
                        NextNode.Nodes[0].Nodes.Add(LeftNode2);
                        NextNode.Nodes[1].Nodes.Add(RightNode2);

                        if (BaseNode == null)
                        {
                            FormulaTree.Nodes.RemoveAt(0);
                            FormulaTree.Nodes.Add(NextNode);
                            DrownNegatives(NextNode);
                        }
                        else
                        {
                            int index = BaseNode.Nodes.IndexOf(CurNode);

                            BaseNode.Nodes.RemoveAt(index);
                            BaseNode.Nodes.Insert(index, NextNode);
                            DrownNegatives(NextNode);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                foreach (TreeNode tn in CurNode.Nodes)
                {
                    DrownNegatives(tn);
                }
            }
        }
        private string GetFormulaFromTreeView(TreeNode tn) //Возврат формулы по дереву
        {
            //нет проверок надежности - ожидание верной формулы
            string s = tn.Text;
            char c = char.Parse(s);
            if (char.IsLetter(c))
            {
                return s;
            }
            if (c == '!')
            {
                return "(" + s + GetFormulaFromTreeView(tn.Nodes[0]) + ")";
            }
            if (c == '&' || c == '|' || c == '>')
            {
                return "(" + GetFormulaFromTreeView(tn.Nodes[0]) + s + GetFormulaFromTreeView(tn.Nodes[1]) + ")";
            }
            return "???";
        }

        private void tesnOtricToolStripMenuItem_Click(object sender, EventArgs e) //привести формулу к виду с тесными отрицаниями
        {
            if (TreeCreated)
            {
                TesnOtric();
            }
        }

        private bool CheckEquivalency(string s1, string s2)
        {
            IEnumerable<char> ie = s1.Distinct();
            int count = 0;
            char[] diffchar = new char[27];                         //их макс кол-во (так как максимум используем 26)
            foreach (char c in ie)
            {
                if (char.IsLetter(c))
                {
                    diffchar[count] = c;
                    count++;
                }
            }

            bool[] Val = new bool[count];
            int[] iAltVal = new int[count];
            bool[] bResults = new bool[(int)Math.Pow(2, count)];
            bool[] bResultsTransformed = new bool[(int)Math.Pow(2, count)];

            bResults[0] = CalculateFormula(s1, Val, diffchar);
            bResultsTransformed[0] = CalculateFormula(s2, Val, diffchar);

            for (int i = 0; i < count; i++)
            {
                FormulaFromTableBox.Text += diffchar[i] + " ";
            }
            FormulaFromTableBox.AppendText("   F1   F2");
            FormulaFromTableBox.AppendText(Environment.NewLine);
            for (int i = 0; i < count; i++)
            {
                FormulaFromTableBox.Text += "0 ";
            }
            FormulaFromTableBox.Text += "   " + Convert.ToInt32(bResults[0]) + "   " + Convert.ToInt32(bResultsTransformed[0]);
            FormulaFromTableBox.AppendText(Environment.NewLine);

            if (bResults[0] != bResultsTransformed[0])
            {
                return false;
            }

            for (int i = 1; i < Math.Pow(2, count); i++)
            {
                if (iAltVal[0] == 0)
                {
                    iAltVal[0] = 1;
                }
                else
                {
                    int j = 0;
                    while (iAltVal[j] == 1)
                    {
                        iAltVal[j] = 0;
                        j++;
                        if (j == count)
                        {
                            break;
                        }
                    }
                    iAltVal[j] = 1;
                }
                for (int j = 0; j < count; j++)
                {
                    if (iAltVal[j] == 0)
                    {
                        Val[j] = false;
                    }
                    else
                    {
                        Val[j] = true;
                    }
                }
                bResults[i] = CalculateFormula(s1, Val, diffchar);
                bResultsTransformed[i] = CalculateFormula(s2, Val, diffchar);

                for (int j = 0; j < count; j++)
                {
                    FormulaFromTableBox.Text += iAltVal[j] + " ";
                }

                FormulaFromTableBox.Text += "   " + Convert.ToInt32(bResults[i]) + "   " + Convert.ToInt32(bResultsTransformed[i]);
                FormulaFromTableBox.AppendText(Environment.NewLine);

                if (bResults[i] != bResultsTransformed[i])
                {
                    return false;
                }
            }
            return true;
        }

        private void equivalencyCheckToolStripMenuItem_Click(object sender, EventArgs e) //проверка эквивалентности исходной формулы и формулы после приведения по алгоритму (деревом)
        {
            IEnumerable<char> ie = CurrentFormula.Distinct();       //получаем все переменные (буквы)
            int count = 0;
            char[] diffchar = new char[27];                         //их макс кол-во (так как максимум используем 26)
            foreach (char c in ie)
            {
                if (char.IsLetter(c))
                {                   
                    diffchar[count] = c;
                    count++;
                }
            }

            string AltFormula = transformedTextbox.Text;            //альтернативная формула (здесь проверка на ее наличие)
            bool[] Val = new bool[count];
            int[] iAltVal = new int[count];
            bool[] bResults = new bool[(int)Math.Pow(2, count)];
            bool[] bResultsTransformed = new bool[(int)Math.Pow(2, count)];
            bool bFlag = true;

            bResults[0] = CalculateFormula(CurrentFormula, Val, diffchar);
            bResultsTransformed[0] = CalculateFormula(AltFormula, Val, diffchar);

            for (int i = 0; i < count; i++)
            {
                ValTextbox.Text += diffchar[i] + " ";
            }
            ValTextbox.AppendText("   F1   F2");
            ValTextbox.AppendText(Environment.NewLine);
            for (int i = 0; i < count; i++)
            {
                ValTextbox.Text += "0 ";
            }
            ValTextbox.Text += "   " + Convert.ToInt32(bResults[0]) + "   " + Convert.ToInt32(bResultsTransformed[0]);
            ValTextbox.AppendText(Environment.NewLine);

            if (bResults[0] != bResultsTransformed[0])
            {
                bFlag = false;
                MessageBox.Show("NOT EQUIVALENT");
            }

            for (int i = 1; i<Math.Pow(2, count); i++)
            {
                if (iAltVal[0] == 0)
                {
                    iAltVal[0] = 1;
                }
                else
                {
                    int j = 0;
                    while (iAltVal[j] == 1)
                    {
                        iAltVal[j] = 0;
                        j++;
                        if (j == count)
                        {
                            break;
                        }
                    }
                    iAltVal[j] = 1;
                }
                for (int j = 0; j<count; j++)
                {
                    if (iAltVal[j] == 0)
                    {
                        Val[j] = false;
                    }
                    else
                    {
                        Val[j] = true;
                    }
                }              
                bResults[i] = CalculateFormula(CurrentFormula, Val, diffchar);
                bResultsTransformed[i] = CalculateFormula(AltFormula, Val, diffchar);

                for (int j = 0; j < count; j++)
                {
                    ValTextbox.Text += iAltVal[j] + " ";
                }

                ValTextbox.Text += "   " + Convert.ToInt32(bResults[i]) + "   " + Convert.ToInt32(bResultsTransformed[i]);
                ValTextbox.AppendText(Environment.NewLine);

                if (bResults[i] != bResultsTransformed[i])
                {
                    bFlag = false;
                    MessageBox.Show("NOT EQUIVALENT");
                    break;
                }
            }
            if (bFlag)
            {
                MessageBox.Show("Формулы эквивалентны");
            }                                 
        }

        private int FindCharInArray(char[] cAr, char c)
        {
            for(int i = 0; i<cAr.Length; i++)
            {
                if (c == cAr[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private bool CalculateFormula(string s, bool[] Val, char[] Chars) //Посчитать значение формулы
        {
            if (string.IsNullOrEmpty(s))    //пустая строка - не формула
            {
                return false;
            }
            if (s.Length == 1 && char.IsLetter(s[0]))   //случай с единичным символом - должна быть переменная
            {
                int index = FindCharInArray(Chars, s[0]);
                return Val[index];
            }
            else     //не единичная длина формулы
            {
                if (s[0] == '(' && s[s.Length - 1] == ')')  //если формула не состоит только из переменной, она обернута в скобки
                {
                    if (s[1] == '!')   //случай с отрицанием
                    {
                        return !CalculateFormula(s.Substring(2, s.Length - 3), Val, Chars);
                    }
                    else // случай с операциями внутри скобки
                    {
                        int BracketCnt = 0; //проверка по балансу скобок
                        for (int i = 1; i < s.Length - 1; i++)
                        {
                            if (s[i] == '(')
                            {
                                BracketCnt++;
                            }
                            if (s[i] == ')')
                            {
                                BracketCnt--;
                            }
                            //если найдена операция с верным балансом скобок, проверка левой и правой частей
                            if ((s[i] == '|' || s[i] == '&' || s[i] == '>') && (BracketCnt == 0))
                            {
                                string sFirst = s.Substring(1, i - 1);
                                string sSecond = s.Substring(i + 1, s.Length - 2 - i);
                                switch (s[i])
                                {
                                    case '|':
                                        return CalculateFormula(sFirst, Val, Chars) || CalculateFormula(sSecond, Val, Chars);
                                    case '&':
                                        return CalculateFormula(sFirst, Val, Chars) && CalculateFormula(sSecond, Val, Chars);
                                    case '>':
                                        return !CalculateFormula(sFirst, Val, Chars) || CalculateFormula(sSecond, Val, Chars);
                                }
                                return false;
                            }
                        }
                        //если операции с верным балансом скобок не найдено, формула неверна
                        return false;
                    }
                }
                else //если не обернута в скобки, то формула неверна
                {
                    return false;
                }
            }
            return false;
        }

        private string GetSumOfChars(List<string> lc, string Oper) //Для создания формул вида a & b & c & d...
        {
            string sRes = "";
            if (lc.Count % 2 == 0)
            {
                List<string> lss = new List<string>();
                for (int i = 0; i<lc.Count; i=i+2)
                {
                    string st = "(" + lc[i] + Oper + lc[i + 1] + ")";
                    lss.Add(st);
                }
                if (lss.Count() > 0)
                {
                    sRes = lss[0];
                }
                for (int i = 1; i<lss.Count; i++)
                {
                    sRes = "(" + sRes + Oper + lss[i] + ")";
                }
            }
            else
            {
                List<string> lss = new List<string>();
                for (int i = 1; i < lc.Count; i = i + 2)
                {
                    string st = "(" + lc[i] + Oper + lc[i + 1] + ")";
                    lss.Add(st);
                }
                sRes = lc[0];
                for (int i = 0; i < lss.Count; i++)
                {
                    sRes = "(" + sRes + Oper + lss[i] + ")";
                }
            }
            return sRes;
        }

        private string GetDNFByFormula(string s) //Получить ДНФ по формуле
        {
            IEnumerable<char> ie = CurrentFormula.Distinct();       //получаем все переменные (буквы)
            int count = 0;
            char[] diffchar = new char[27];                         //их макс кол-во (так как максимум используем 26)
            foreach (char c in ie)
            {
                if (char.IsLetter(c))
                {
                    diffchar[count] = c;
                    count++;
                }
            }

            bool[] Val = new bool[count];
            int[] iAltVal = new int[count];
            bool[] bResults = new bool[(int)Math.Pow(2, count)];
            bool bFlag = true;
            List<string> TotalUsed = new List<string>();

            bResults[0] = CalculateFormula(s, Val, diffchar);
            List<string> UsedVars = new List<string>();

            for (int i = 0; i < count; i++)
            {
                ValTextbox.Text += diffchar[i] + " ";
            }
            ValTextbox.AppendText("   F1");
            ValTextbox.AppendText(Environment.NewLine);
            for (int i = 0; i < count; i++)
            {
                ValTextbox.Text += "0 ";
            }
            ValTextbox.Text += "   " + Convert.ToInt32(bResults[0]);
            ValTextbox.AppendText(Environment.NewLine);


            if (Convert.ToInt32(bResults[0]) == 1)
            {
                for (int j = 0; j < count; j++)
                {
                    if (iAltVal[j] == 0)
                    {
                        UsedVars.Add("(!" + diffchar[j] + ")");
                    }
                    else
                    {
                        UsedVars.Add(diffchar[j].ToString());
                    }
                }
                string t = GetSumOfChars(UsedVars, "&");
                TotalUsed.Add(t);
            }
            
            for (int i = 1; i < Math.Pow(2, count); i++)
            {
                if (iAltVal[0] == 0)
                {
                    iAltVal[0] = 1;
                }
                else
                {
                    int j = 0;
                    while (iAltVal[j] == 1)
                    {
                        iAltVal[j] = 0;
                        j++;
                        if (j == count)
                        {
                            break;
                        }
                    }
                    iAltVal[j] = 1;
                }
                for (int j = 0; j < count; j++)
                {
                    if (iAltVal[j] == 0)
                    {
                        Val[j] = false;
                    }
                    else
                    {
                        Val[j] = true;
                    }
                }
                bResults[i] = CalculateFormula(CurrentFormula, Val, diffchar);
                for (int j = 0; j < count; j++)
                {
                    ValTextbox.Text += iAltVal[j] + " ";
                }
                ValTextbox.Text += "   " + Convert.ToInt32(bResults[i]);
                ValTextbox.AppendText(Environment.NewLine);
                UsedVars = new List<string>();
                if (Convert.ToInt32(bResults[i]) == 1)
                {
                    for (int j = 0; j<count; j++)
                    {
                        if (iAltVal[j] == 0)
                        {
                            UsedVars.Add("(!" + diffchar[j] + ")");
                        }
                        else
                        {
                            UsedVars.Add(diffchar[j].ToString());
                        }
                    }
                    string t = GetSumOfChars(UsedVars, "&");
                    TotalUsed.Add(t);
                }
            }
            return GetSumOfChars(TotalUsed, "|");
        }

        private string GetKNFByFormula(string s)
        {
            IEnumerable<char> ie = CurrentFormula.Distinct();       //получаем все переменные (буквы)
            int count = 0;
            char[] diffchar = new char[27];                         //их макс кол-во (так как максимум используем 26)
            foreach (char c in ie)
            {
                if (char.IsLetter(c))
                {
                    diffchar[count] = c;
                    count++;
                }
            }

            bool[] Val = new bool[count];
            int[] iAltVal = new int[count];
            bool[] bResults = new bool[(int)Math.Pow(2, count)];
            bool bFlag = true;
            List<string> TotalUsed = new List<string>();

            bResults[0] = CalculateFormula(s, Val, diffchar);
            List<string> UsedVars = new List<string>();
            if (Convert.ToInt32(bResults[0]) == 0)
            {
                for (int j = 0; j < count; j++)
                {
                    if (iAltVal[j] == 1)
                    {
                        UsedVars.Add("!" + diffchar[j]);
                    }
                    else
                    {
                        UsedVars.Add(diffchar[j].ToString());
                    }
                }
                string t = GetSumOfChars(UsedVars, "|");
                TotalUsed.Add(t);
            }

            for (int i = 1; i < Math.Pow(2, count); i++)
            {
                if (iAltVal[0] == 0)
                {
                    iAltVal[0] = 1;
                }
                else
                {
                    int j = 0;
                    while (iAltVal[j] == 1)
                    {
                        iAltVal[j] = 0;
                        j++;
                        if (j == count)
                        {
                            break;
                        }
                    }
                    iAltVal[j] = 1;
                }
                for (int j = 0; j < count; j++)
                {
                    if (iAltVal[j] == 0)
                    {
                        Val[j] = false;
                    }
                    else
                    {
                        Val[j] = true;
                    }
                }
                bResults[i] = CalculateFormula(CurrentFormula, Val, diffchar);

                UsedVars = new List<string>();
                if (Convert.ToInt32(bResults[i]) == 1)
                {
                    for (int j = 0; j < count; j++)
                    {
                        if (iAltVal[j] == 1)
                        {
                            UsedVars.Add("!" + diffchar[j]);
                        }
                        else
                        {
                            UsedVars.Add(diffchar[j].ToString());
                        }
                    }
                    string t = GetSumOfChars(UsedVars, "|");
                    TotalUsed.Add(t);
                }
            }
            return GetSumOfChars(TotalUsed, "&");
        }

        private void compareTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ////Время алгоритма через таблицу истинности
            //Stopwatch t = new Stopwatch();
            //t.Start();
            //string s1 = GetDNFByFormula(CurrentFormula);
            //IstBox.Text = s1;
            //t.Stop();
            //TimeSpan ts = t.Elapsed;

            //string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds / 10);

            ////Время алгоритма через дерево
            //Stopwatch t2 = new Stopwatch();
            //t2.Start();

            //FormulaTree.Nodes.Clear();
            //PopulateTree(CurrentFormula, null);
            //FormulaTree.ExpandAll();

            //KillImplications(FormulaTree.Nodes[0]);
            //DrownNegatives(FormulaTree.Nodes[0]);
            //transformedTextbox.Text = GetFormulaFromTreeView(FormulaTree.Nodes[0]);

            //FormulaTree.ExpandAll();
            //RiseOR();
            //t2.Stop();
            //TimeSpan ts2 = t2.Elapsed;

            //string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts2.Hours, ts2.Minutes, ts2.Seconds,
            //    ts2.Milliseconds / 10);
            //MessageBox.Show("Время построения через таблицу истинности: " + elapsedTime1 + ". Время построения через дерево: " + elapsedTime2);
        }//не использовать

        private void equivalentCheckDiffAlgosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stopwatch t = new Stopwatch();
            t.Start();

            FormulaTree.Nodes.Clear();
            PopulateTree(CurrentFormula, null);
            FormulaTree.ExpandAll();

            KillImplications(FormulaTree.Nodes[0]);
            DrownNegatives(FormulaTree.Nodes[0]);
            //transformedTextbox.Text = GetFormulaFromTreeView(FormulaTree.Nodes[0]);

            FormulaTree.ExpandAll();
            RiseOR();

            t.Stop();
            TimeSpan ts = t.Elapsed;

            string elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);


            string s1 = transformedTextbox.Text;

            Stopwatch t2 = new Stopwatch();
            t2.Start();
            string s2 = GetDNFByFormula(CurrentFormula);
            t2.Stop();
            TimeSpan ts2 = t2.Elapsed;
            string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts2.Hours, ts2.Minutes, ts2.Seconds,
                ts2.Milliseconds / 10);
            IstBox.Text = s2;
            if (CheckEquivalency(s1, s2))
            {
                MessageBox.Show("Эквивалентны");
                MessageBox.Show("Время алгоритма через дерево: " + elapsedTime1 + ". Время алгоритма через таблицу истинности: " + elapsedTime2);
            }
            else
            {
                MessageBox.Show("Не эквивалентны");
            }

        }

        private void checKEQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s1 = "(x|y)";
            string s2 = "((x|y)&(z|(!z))";
            if(!CheckEquivalency(s1, s2))
            {
                MessageBox.Show("Не эквивалентны");
            }
        }
    }
}
