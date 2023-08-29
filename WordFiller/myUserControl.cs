using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Word = Microsoft.Office.Interop.Word;

namespace WordFiller
{
    public partial class myUserControl : UserControl
    {
        private Random rnd = new Random();
        private List<Tuple<TableLayoutPanel, Label, TextBox>> FillRows;
        private List<Tuple<TableLayoutPanel, Button, TextBox, Button>> AddRows;
        private List<Tuple<string, Color>> Params;
        private List<Tuple<string, Word.Range>> ParamsRange;
        private bool _colorMode;
        public bool colorMode
        {
            get { return this._colorMode; }
            set { _colorMode = value; Globals.Ribbons.ControllerRibbon.UpdateRibbonColor(value); }
        }

        private ArrayOfData Datas;
        public myUserControl()
        {
            InitializeComponent();
            FillRows = new List<Tuple<TableLayoutPanel, Label, TextBox>>();
            AddRows = new List<Tuple<TableLayoutPanel, Button, TextBox, Button>>();
            Params = new List<Tuple<string, Color>>();
            ParamsRange = new List<Tuple<string, Word.Range>>();
            Datas = new ArrayOfData();
            XmlSerializer xs = new XmlSerializer(typeof(ArrayOfData));
            if (!File.Exists("C:\\ProgramData\\Storage.xml"))
            {
                FileStream tmp = File.Create("C:\\ProgramData\\Storage.xml");
                tmp.Close();
            } else
            {
                using (FileStream stream = File.OpenRead("C:\\ProgramData\\Storage.xml"))
                {
                    try
                    {
                        Datas = xs.Deserialize(stream) as ArrayOfData;
                        initializeData(Datas);
                    } catch (Exception ex)
                    {
                        stream.Close();
                        FileStream tmp = File.Create("C:\\ProgramData\\Storage.xml");
                        tmp.Close();
                    }
                }
            }
        }
        
        private void initializeData(ArrayOfData datas)
        {
            foreach (Data data in datas.Items)
            {
                if (data.fileName == Globals.ThisAddIn.getFileName())
                {
                    foreach (var str in data.ParamsString.Select((value, i) => new { i, value }))
                    {
                        Globals.ThisAddIn.setRange(data.ParamsRangeStart[str.i], data.ParamsRangeEnd[str.i]);
                        bool used = false;
                        foreach (Tuple<string, Color> tuple in Params)
                        {
                            if (str.value == tuple.Item1)
                            {
                                used = true;
                            }
                        }
                        if (!used)
                        {
                            Params.Add(new Tuple<string, Color>(str.value, Color.FromArgb(data.ParamsColor[str.i])));
                            addAddRow(str.value, Params.Last().Item2, data.ParamsNumber[Params.Count - 1]);
                            addFillRow(str.value, Params.Last().Item2);
                        }
                        ParamsRange.Add(new Tuple<string, Word.Range>(str.value, Globals.ThisAddIn.getRange()));
                    }
                    FillTextBox();
                    ApplyAllColors();
                    Globals.ThisAddIn.setRange(0, 0);
                }
            }
        }

        private void addAddRow(string label, Color color, string textboxCount)
        {
            AddRows.Add(new Tuple<TableLayoutPanel, Button, TextBox, Button>(new TableLayoutPanel(), new Button(), new TextBox(), new Button()));

            AddRows.Last().Item2.AutoSize = true;
            AddRows.Last().Item2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            AddRows.Last().Item2.Dock = System.Windows.Forms.DockStyle.Fill;
            AddRows.Last().Item2.Location = new System.Drawing.Point(7, 3);
            AddRows.Last().Item2.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            AddRows.Last().Item2.Name = "AddFirstButton" + AddRows.Count;
            AddRows.Last().Item2.Size = new System.Drawing.Size(54, 28);
            AddRows.Last().Item2.TabIndex = 1;
            AddRows.Last().Item2.Text = '[' + label + ']';
            AddRows.Last().Item2.UseVisualStyleBackColor = true;
            AddRows.Last().Item2.Click += this.AddSelectedText;

            AddRows.Last().Item3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            AddRows.Last().Item3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            AddRows.Last().Item3.Location = new System.Drawing.Point(71, 7);
            AddRows.Last().Item3.Name = "AddRowCountTextBox" + AddRows.Count;
            AddRows.Last().Item3.ReadOnly = true;
            AddRows.Last().Item3.Size = new System.Drawing.Size(44, 20);
            AddRows.Last().Item3.TabIndex = 3;
            AddRows.Last().Item3.Text = textboxCount;
            AddRows.Last().Item3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            AddRows.Last().Item4.AutoSize = true;
            AddRows.Last().Item4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            AddRows.Last().Item4.Dock = System.Windows.Forms.DockStyle.Left;
            AddRows.Last().Item4.Location = new System.Drawing.Point(125, 3);
            AddRows.Last().Item4.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            AddRows.Last().Item4.Name = "AddRowDeleteButton" + AddRows.Count;
            AddRows.Last().Item4.Size = new System.Drawing.Size(64, 28);
            AddRows.Last().Item4.TabIndex = 2;
            AddRows.Last().Item4.Text = "Supprimer";
            AddRows.Last().Item4.UseVisualStyleBackColor = true;
            AddRows.Last().Item4.Click += this.DeleteRow;

            AddRows.Last().Item1.AutoSize = true;
            AddRows.Last().Item1.BackColor = color;
            AddRows.Last().Item1.ColumnCount = 3;
            AddRows.Last().Item1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            AddRows.Last().Item1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            AddRows.Last().Item1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            AddRows.Last().Item1.Controls.Add(AddRows.Last().Item4, 2, 0);
            AddRows.Last().Item1.Controls.Add(AddRows.Last().Item2, 0, 0);
            AddRows.Last().Item1.Controls.Add(AddRows.Last().Item3, 1, 0);
            AddRows.Last().Item1.Dock = System.Windows.Forms.DockStyle.Fill;
            AddRows.Last().Item1.Location = new System.Drawing.Point(10, 3);
            AddRows.Last().Item1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            AddRows.Last().Item1.Name = "AddRowLayoutPanel" + AddRows.Count;
            AddRows.Last().Item1.RowCount = 1;
            AddRows.Last().Item1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            AddRows.Last().Item1.Size = new System.Drawing.Size(196, 34);
            AddRows.Last().Item1.TabIndex = 0;

            this.AddRowLayoutPanel.Controls.Add(AddRows.Last().Item1, 0, AddRows.Count);
            this.AddRowLayoutPanel.RowCount = AddRows.Count + 1;
            this.AddRowLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        }

        private void addFillRow(string label, Color color)
        {
            FillRows.Add(new Tuple<TableLayoutPanel, Label, TextBox>(new TableLayoutPanel(), new Label(), new TextBox()));

            FillRows.Last().Item2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            FillRows.Last().Item2.AutoSize = true;
            FillRows.Last().Item2.Location = new System.Drawing.Point(10, 7);
            FillRows.Last().Item2.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            FillRows.Last().Item2.Name = "AddRowLabelChild" + FillRows.Count;
            FillRows.Last().Item2.Size = new System.Drawing.Size(29, 13);
            FillRows.Last().Item2.TabIndex = 0;
            FillRows.Last().Item2.Text = label;
            FillRows.Last().Item2.BackColor = Color.White;

            FillRows.Last().Item3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            FillRows.Last().Item3.Location = new System.Drawing.Point(10, 23);
            FillRows.Last().Item3.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            FillRows.Last().Item3.Name = "AddRowTextChildBox" + FillRows.Count;
            FillRows.Last().Item3.Size = new System.Drawing.Size(434, 20);
            FillRows.Last().Item3.TabIndex = 1;

            FillRows.Last().Item1.BackColor = color;
            FillRows.Last().Item1.ColumnCount = 1;
            FillRows.Last().Item1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            FillRows.Last().Item1.Controls.Add(FillRows.Last().Item2, 0, 0);
            FillRows.Last().Item1.Controls.Add(FillRows.Last().Item3, 0, 1);
            FillRows.Last().Item1.Dock = System.Windows.Forms.DockStyle.Fill;
            FillRows.Last().Item1.Location = new System.Drawing.Point(3, 3);
            FillRows.Last().Item1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            FillRows.Last().Item1.Name = "AddRowLayoutChildPanel" + FillRows.Count;
            FillRows.Last().Item1.RowCount = 2;
            FillRows.Last().Item1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            FillRows.Last().Item1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            FillRows.Last().Item1.Size = new System.Drawing.Size(454, 54);
            FillRows.Last().Item1.TabIndex = 0;

            this.FillRowLayoutPanel.Controls.Add(FillRows.Last().Item1, 0, FillRows.Count - 1);
            this.FillRowLayoutPanel.RowCount = FillRows.Count;
            this.FillRowLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            if (AddNewTextBox.Text.Length == 0)
            {
                MessageBox.Show("Veuillez rentrer un paramètre", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (Tuple<string, Color> label in Params)
            {
                if (label.Item1 == AddNewTextBox.Text)
                {
                    MessageBox.Show("Veuillez rentrer un paramètre non existant", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Params.Add(new Tuple<string, Color>(AddNewTextBox.Text, Color.FromArgb(rnd.Next(100, 225), rnd.Next(100, 225), rnd.Next(100, 225))));
            addFillRow(AddNewTextBox.Text, Params.Last().Item2);
            addAddRow(AddNewTextBox.Text, Params.Last().Item2, "0");
            AddNewTextBox.Clear();
        }

        private void RemoveArbitraryRow(TableLayoutPanel panel, int rowIndex)
        {
            if (rowIndex >= panel.RowCount)
            {
                return;
            }

            // delete all controls of row that we want to delete
            for (int i = 0; i < panel.ColumnCount; i++)
            {
                var control = panel.GetControlFromPosition(i, rowIndex);
                panel.Controls.Remove(control);
            }

            // move up row controls that comes after row we want to remove
            for (int i = rowIndex + 1; i < panel.RowCount; i++)
            {
                for (int j = 0; j < panel.ColumnCount; j++)
                {
                    var control = panel.GetControlFromPosition(j, i);
                    if (control != null)
                    {
                        panel.SetRow(control, i - 1);
                    }
                }
            }
            var removeStyle = panel.RowCount - 1;

            if (panel.RowStyles.Count > removeStyle)
                panel.RowStyles.RemoveAt(removeStyle);

            panel.RowCount--;
        }

        private bool isRangeStillValid(string paramsName)
        {
            foreach (Tuple<string, Word.Range> tuple in ParamsRange)
            {
                if (tuple.Item1 == paramsName && tuple.Item2 == null)
                {
                    MessageBox.Show("Paramètre [" + tuple.Item1 + "] est null depuis la dernière modification, merci de corriger en premier lieu cette erreur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void RemoveRange(Word.Range range)
        {
            foreach (Tuple<string, Word.Range> tuple in ParamsRange)
            {
                if ((tuple.Item2.Start >= range.Start && tuple.Item2.End <= range.Start) || (tuple.Item2.Start >= range.End && tuple.Item2.End <= range.End))
                {
                    tuple.Item2.Shading.BackgroundPatternColor = WdColor.wdColorAutomatic;
                    foreach (Tuple<string, Color> label in Params)
                    {
                        if (label.Item1 == tuple.Item1)
                        {
                            AddRows[Params.IndexOf(label)].Item3.Text = (Convert.ToInt32(AddRows[Params.IndexOf(label)].Item3.Text) - 1).ToString();
                            ParamsRange.Remove(tuple);
                            RemoveRange(range);
                            return;
                        }
                    }
                }
                else if ((tuple.Item2.Start >= range.Start && tuple.Item2.Start <= range.End) || (tuple.Item2.End >= range.Start && tuple.Item2.End <= range.End))
                {
                    tuple.Item2.Shading.BackgroundPatternColor = WdColor.wdColorAutomatic;
                    foreach (Tuple<string, Color> label in Params)
                    {
                        if (label.Item1 == tuple.Item1)
                        {
                            AddRows[Params.IndexOf(label)].Item3.Text = (Convert.ToInt32(AddRows[Params.IndexOf(label)].Item3.Text) - 1).ToString();
                            ParamsRange.Remove(tuple);
                            RemoveRange(range);
                            return;
                        }
                    }
                }
            }
        }

        private void RemoveAllRange(string rangeName)
        {
            foreach (Tuple<string, Word.Range> tuple in ParamsRange)
            {
                if (tuple.Item1 == rangeName)
                {
                    tuple.Item2.Shading.BackgroundPatternColor = WdColor.wdColorAutomatic;
                    foreach (Hyperlink hyper in Globals.ThisAddIn.Application.ActiveDocument.Hyperlinks)
                    {
                        if (hyper.ScreenTip == tuple.Item1)
                        {
                            hyper.Delete();
                            break;
                        }
                    }
                    ParamsRange.Remove(tuple);
                    RemoveAllRange(rangeName);
                    return;
                }
            }
        }

        private void DeleteRow(object sender, EventArgs e)
        {
            foreach (Tuple<TableLayoutPanel, Button, TextBox, Button> tuple in AddRows)
            {
                if (tuple.Item4.Equals(sender))
                {
                    if (!isRangeStillValid(Params[AddRows.IndexOf(tuple)].Item1)) return;
                    RemoveArbitraryRow(this.FillRowLayoutPanel, AddRows.IndexOf(tuple));
                    RemoveArbitraryRow(this.AddRowLayoutPanel, AddRows.IndexOf(tuple) + 1);

                    RemoveAllRange(Params[AddRows.IndexOf(tuple)].Item1);
                    Params.Remove(Params[AddRows.IndexOf(tuple)]);
                    FillRows.Remove(FillRows[AddRows.IndexOf(tuple)]);
                    AddRows.Remove(tuple);
                    return;
                }
            }
            foreach (Tuple<TableLayoutPanel, Button, TextBox, Button> tuple in AddRows)
            {
                if (tuple.Item4.Equals(sender))
                {
                    RemoveArbitraryRow(this.FillRowLayoutPanel, AddRows.IndexOf(tuple));
                    RemoveArbitraryRow(this.AddRowLayoutPanel, AddRows.IndexOf(tuple) + 1);

                    RemoveAllRange(Params[AddRows.IndexOf(tuple)].Item1);
                    Params.Remove(Params[AddRows.IndexOf(tuple)]);
                    FillRows.Remove(FillRows[AddRows.IndexOf(tuple)]);
                    AddRows.Remove(tuple);
                    return;
                }
            }
        }

        private bool IsRangeUsed(Word.Range range)
        {
            foreach (Tuple<string, Word.Range> tuple in ParamsRange)
            {
                if ((tuple.Item2.Start >= range.Start && tuple.Item2.End <= range.Start) || (tuple.Item2.Start >= range.End && tuple.Item2.End <= range.End))
                {
                    return true;
                } else if ((tuple.Item2.Start >= range.Start && tuple.Item2.Start <= range.End) || (tuple.Item2.End >= range.Start && tuple.Item2.End <= range.End))
                {
                    return true;
                }
            }
            return false;
        }

        private void AddSelectedText(object sender, EventArgs e)
        {
            if (Globals.ThisAddIn.isSelected())
            {
                foreach (Tuple<TableLayoutPanel, Button, TextBox, Button> tuple in AddRows)
                {
                    if (tuple.Item2.Equals(sender))
                    {
                        if (IsRangeUsed(Globals.ThisAddIn.getRange()))
                        {
                            MessageBox.Show("Vous ne pouvez pas supperposer deux paramètres", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        } else
                        {
                            ParamsRange.Add(Globals.ThisAddIn.getSelected(Params[AddRows.IndexOf(tuple)].Item1));
                            ParamsRange.Last().Item2.Font.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)(Params[AddRows.IndexOf(tuple)].Item2.R + 0x100 * Params[AddRows.IndexOf(tuple)].Item2.G + 0x10000 * Params[AddRows.IndexOf(tuple)].Item2.B);
                            Globals.ThisAddIn.Application.ActiveDocument.Hyperlinks.Add(ParamsRange.Last().Item2, ".\\", Params[AddRows.IndexOf(tuple)].Item1, Params[AddRows.IndexOf(tuple)].Item1);
                            colorMode = true;
                            tuple.Item3.Text = (Convert.ToInt32(tuple.Item3.Text) + 1).ToString();
                            return;
                        }
                    }
                }
                if (IsRangeUsed(Globals.ThisAddIn.getRange()))
                {
                    RemoveRange(Globals.ThisAddIn.getRange());
                }
            }
        }

        private void ChangeParams(string ParamsName, string newName)
        {
            foreach (Tuple<string, Word.Range> tuple in ParamsRange)
            {
                if (!isRangeStillValid(tuple.Item1)) return;
            }
            foreach (Tuple<string, Word.Range> tuple in ParamsRange)
            {
                if (tuple.Item1 == ParamsName)
                {
                    tuple.Item2.Text = newName;
                }
            }
        }

        private void ApplyParamsButton_Click(object sender, EventArgs e)
        {
            foreach (Tuple<TableLayoutPanel, Label, TextBox> tuple in FillRows)
            {
                if (tuple.Item3.Text.Length == 0)
                {
                    MessageBox.Show("Veuillez remplir tous les paramètres avant d'appliquer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            foreach (Tuple<TableLayoutPanel, Label, TextBox> tuple in FillRows)
            {
                ChangeParams(tuple.Item2.Text, tuple.Item3.Text);
            }
        }

        private void updateDatas(Data data)
        {
            foreach (Data item in Datas.Items)
            {
                if (item.fileName == data.fileName)
                {
                    Datas.Items[Datas.Items.IndexOf(item)] = data;
                    return;
                }
            }
            Datas.Items.Add(data);
        }

        public void SaveConfig()
        {
            Data data = new Data(Params, ParamsRange, AddRows, Globals.ThisAddIn.getFileName(), Globals.ThisAddIn.getFullFileName());
            updateDatas(data);
            foreach (Data datatmp in Datas.Items)
            {
                if (datatmp.fileName == Globals.ThisAddIn.getFileName() && Params.Count == 0)
                {
                    Datas.Items.Remove(datatmp);
                    break;
                }
            }
            XmlSerializer xs = new XmlSerializer(typeof(ArrayOfData));
            using (FileStream stream = File.Create("C:\\ProgramData\\Storage.xml"))
            {
                xs.Serialize(stream, Datas);
            }
        }

        public bool RemoveAllColors()
        {
            bool swaped = false;
            colorMode = false;
            foreach (Tuple<string, Word.Range> tuple in ParamsRange)
            {
                if (!isRangeStillValid(tuple.Item1)) return false;
            }
            foreach (Tuple<string, Word.Range> tuple in ParamsRange)
            {
                foreach (Tuple<string, Color> color in Params)
                {
                    if (tuple.Item1 == color.Item1)
                    {
                        tuple.Item2.Font.Shading.BackgroundPatternColor = WdColor.wdColorAutomatic;
                        foreach (Hyperlink hyper in Globals.ThisAddIn.Application.ActiveDocument.Hyperlinks)
                        {
                            if (hyper.ScreenTip == tuple.Item1)
                            {
                                hyper.Delete();
                                break;
                            }
                        }
                        swaped = true;
                    }
                }
                colorMode = false;
            }
            if (!swaped && Params.Count != 0)
            {
                MessageBox.Show("Aucune zone de sélection détecté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        public bool ApplyAllColors()
        {
            bool swaped = false;
            colorMode = false;
            foreach (Tuple<string, Word.Range> tuple in ParamsRange)
            {
                if (!isRangeStillValid(tuple.Item1)) return false;
            }
            foreach (Tuple<string, Word.Range> tuple in ParamsRange)
            {
                foreach (Tuple<string, Color> color in Params)
                {
                    if (tuple.Item1 == color.Item1)
                    {
                        tuple.Item2.Font.Shading.BackgroundPatternColor = (Microsoft.Office.Interop.Word.WdColor)(color.Item2.R + 0x100 * color.Item2.G + 0x10000 * color.Item2.B);
                        Globals.ThisAddIn.Application.ActiveDocument.Hyperlinks.Add(tuple.Item2, ".\\", color.Item1, color.Item1);
                    }
                }
                swaped = true;
                colorMode = true;
            }
            if (!swaped && Params.Count != 0)
            {
                MessageBox.Show("Aucune zone de sélection détecté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        private void FillTextBox()
        {
            foreach (Tuple<TableLayoutPanel, Label, TextBox> tuple in FillRows)
            {
                string text = "";
                foreach (Tuple<string, Word.Range> label in ParamsRange)
                {
                    if (label.Item1 == tuple.Item2.Text)
                    {
                        if (text != null && text.Length == 0)
                        {
                            text = label.Item2.Text;
                        } else if (text == null || text != label.Item2.Text)
                        {
                            text = "";
                            break;
                        }
                    }
                }
                tuple.Item3.Text = text;
            }
        }

        private void ColorParamsButton_Click(object sender, EventArgs e)
        {
            ApplyAllColors();
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
             if (e.TabPageIndex == 0)
            {
                FillTextBox();
            }
        }

        public void clearController()
        {
            DeleteRow(null, null);
        }

        private void AddNewTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                AddNewButton_Click(null, null);
            }
        }
    }
}
