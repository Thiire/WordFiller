using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using System.Drawing;
using System.Xml.Serialization;
using Microsoft.Office.Interop.Word;
using System.Data;
using System.IO;

namespace WordFiller
{
    public partial class ThisAddIn
    {
        private List<Tuple<int, Microsoft.Office.Tools.CustomTaskPane, myUserControl>> _windowsController;
        private List<string> filesName;
        private List<string> filesFullName;
        public myUserControl myUserController
        {
            get { return getUserController(); }
        }
        public bool myControllerVisible
        {
            get { return getWindowControllerVisible(); }
            set { setWindowControllerVisible(); }
        }

        private Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.DocumentBeforeSave += this.WorkBeforeSave;
            this.Application.DocumentBeforePrint += this.WorkBeforePrint;
            Globals.Ribbons.ControllerRibbon.UpdateRibbonEnabled(null);
            this._windowsController = new List<Tuple<int, Microsoft.Office.Tools.CustomTaskPane, myUserControl>>();
            this.filesName = new List<string>();
            this.filesFullName = new List<string>();

            this.Application.DocumentChange += new Word.ApplicationEvents4_DocumentChangeEventHandler(OpenedDocument);
            this.Application.DocumentOpen += new Word.ApplicationEvents4_DocumentOpenEventHandler(WorkWithDocument);

            ((Word.ApplicationEvents4_Event)this.Application).NewDocument += new Word.ApplicationEvents4_NewDocumentEventHandler(WorkWithDocument);
        }

        private myUserControl getUserController()
        {
            foreach (Tuple<int, Microsoft.Office.Tools.CustomTaskPane, myUserControl> tuple in this._windowsController)
            {
                if (tuple.Item1 == this.Application.ActiveWindow.Hwnd)
                {
                    return tuple.Item3;
                }
            }
            return null;
        }

        private bool setWindowControllerVisible()
        {
            foreach (Tuple<int, Microsoft.Office.Tools.CustomTaskPane, myUserControl> tuple in this._windowsController)
            {
                if (tuple.Item1 == this.Application.ActiveWindow.Hwnd)
                {
                    tuple.Item2.Visible = !tuple.Item2.Visible;
                    Globals.Ribbons.ControllerRibbon.UpdateRibbonVisible(tuple.Item2.Visible);
                    Globals.Ribbons.ControllerRibbon.UpdateRibbonEnabled(tuple.Item3);
                    return tuple.Item2.Visible;
                }
            }
            setupCustomPane(true);
            Globals.Ribbons.ControllerRibbon.UpdateRibbonEnabled(this._windowsController.Last().Item3);
            return true;
        }

        private bool getWindowControllerVisible()
        {
            foreach (Tuple<int, Microsoft.Office.Tools.CustomTaskPane, myUserControl> tuple in this._windowsController)
            {
                if (tuple.Item1 == this.Application.ActiveWindow.Hwnd)
                {
                    Globals.Ribbons.ControllerRibbon.UpdateRibbonVisible(tuple.Item2.Visible);
                    Globals.Ribbons.ControllerRibbon.UpdateRibbonEnabled(tuple.Item3);
                    return tuple.Item2.Visible;
                }
            }
            return false;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            
        }

        public void saveDocument()
        {
            //this.Application.ActiveWindow.Document.Save();
        }

        public void printDocument()
        {
            Word.Dialog dlg = Application.Dialogs[Word.WdWordDialog.wdDialogFilePrint];
            dlg.Show();
        }

        public bool isStarted()
        {
            foreach (Tuple<int, Microsoft.Office.Tools.CustomTaskPane, myUserControl> tuple in this._windowsController)
            {
                if (tuple.Item1 == this.Application.ActiveWindow.Hwnd)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isSelected()
        {
            return this.Application.ActiveWindow.Selection != null && this.Application.ActiveWindow.Selection.Range.Text != null;
        }

        public string getFileName()
        {
            return this.Application.ActiveWindow.Document.Name;
        }

        public string getFullFileName()
        {
            return this.Application.ActiveWindow.Document.FullName;
        }

        public Word.Range getRange()
        {
            return this.Application.ActiveWindow.Selection.Range;
        }

        public void setRange(int start, int end)
        {
            this.Application.ActiveWindow.Selection.SetRange(start, end);
        }

        public Tuple<string, Word.Range> getSelected(string paramName)
        {
            if (this.Application.ActiveWindow.Selection != null && this.Application.ActiveWindow.Selection.Range.Text != null)
            {
                return new Tuple<string, Word.Range>(paramName, this.Application.ActiveWindow.Selection.Range);
            }
            return null;
        }

        private void setupCustomPane(bool visible)
        {
            bool used = false;
            foreach (Tuple<int, Microsoft.Office.Tools.CustomTaskPane, myUserControl> tuple in this._windowsController)
            {
                if (tuple.Item1 == this.Application.ActiveWindow.Hwnd)
                {
                    used = true;
                }
            }
            if (!used)
            {
                myUserControl tmp = new myUserControl();
                this._windowsController.Add(new Tuple<int, Microsoft.Office.Tools.CustomTaskPane, myUserControl>(this.Application.ActiveWindow.Hwnd, this.CustomTaskPanes.Add(tmp, "Word Filler"), tmp));
                this._windowsController.Last().Item2.Width = 340;
                this._windowsController.Last().Item2.Visible = visible;
                Globals.Ribbons.ControllerRibbon.UpdateRibbonVisible(this._windowsController.Last().Item2.Visible);
                Globals.Ribbons.ControllerRibbon.UpdateRibbonEnabled(this._windowsController.Last().Item3);
                Globals.Ribbons.ControllerRibbon.UpdateRibbonColor(this._windowsController.Last().Item3.colorMode);
            }
        }

        private bool isFileOpen(string fileName)
        {
            foreach (Window window in this.Application.Windows)
            {
                if (window.Document.Name == fileName)
                    return true;
            }
            return false;
        }

        public void openFileFromList(string fileName)
        {
            if (isFileOpen(fileName))
            {
                MessageBox.Show("Ce fichier est déjà ouvert", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (filesName.Contains(fileName))
            {
                this.Application.Documents.Open(filesFullName[filesName.IndexOf(fileName)], true);
            }
        }

        private void updateFileList()
        {
            ArrayOfData Datas = new ArrayOfData();
            XmlSerializer xs = new XmlSerializer(typeof(ArrayOfData));
            using (FileStream stream = File.OpenRead("C:\\ProgramData\\Storage.xml"))
            {
                try
                {
                    Datas = xs.Deserialize(stream) as ArrayOfData;
                    foreach (Data data in Datas.Items)
                    {
                        if (!filesName.Contains(data.fileName))
                        {
                            filesName.Add(data.fileName);
                            filesFullName.Add(data.fileFullName);
                            Globals.Ribbons.ControllerRibbon.UpdateDocumentsList(data.fileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void OpenedDocument()
        {
            if (this.Application.Documents.Count == this.Application.Windows.Count && this.Application.Documents.Count != 0)
            {
                updateFileList();
                foreach (Tuple<int, Microsoft.Office.Tools.CustomTaskPane, myUserControl> tuple in this._windowsController)
                {
                    if (tuple.Item1 == this.Application.ActiveWindow.Hwnd)
                    {
                        Globals.Ribbons.ControllerRibbon.UpdateRibbonEnabled(tuple.Item3);
                        Globals.Ribbons.ControllerRibbon.UpdateRibbonVisible(tuple.Item2.Visible);
                        Globals.Ribbons.ControllerRibbon.UpdateRibbonColor(tuple.Item3.colorMode);
                        return;
                    }
                }
                Globals.Ribbons.ControllerRibbon.UpdateRibbonEnabled(null);
                Globals.Ribbons.ControllerRibbon.UpdateRibbonColor(false);
            }
        }

        private void WorkWithDocument(Microsoft.Office.Interop.Word.Document Doc)
        {
            try
            {
                bool used = false;
                if (!File.Exists("C:\\ProgramData\\Storage.xml"))
                {
                    FileStream tmp = File.Create("C:\\ProgramData\\Storage.xml");
                    tmp.Close();
                }
                else
                {
                    ArrayOfData Datas = new ArrayOfData();
                    XmlSerializer xs = new XmlSerializer(typeof(ArrayOfData));

                    using (FileStream stream = File.OpenRead("C:\\ProgramData\\Storage.xml"))
                    {
                        try
                        {
                            Datas = xs.Deserialize(stream) as ArrayOfData;
                            foreach (Data data in Datas.Items)
                            {
                                if (data.fileName == getFileName())
                                {
                                    used = true;
                                    break;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                if (used)
                {
                    setupCustomPane(true);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void repareDocument()
        {
            ArrayOfData Datas = new ArrayOfData();
            XmlSerializer xs = new XmlSerializer(typeof(ArrayOfData));

            foreach (Tuple<int, Microsoft.Office.Tools.CustomTaskPane, myUserControl> tuple in this._windowsController)
            {
                if (tuple.Item1 == this.Application.ActiveWindow.Hwnd)
                {
                    this.CustomTaskPanes.Remove(tuple.Item2);
                    this._windowsController.Remove(tuple);
                    Globals.Ribbons.ControllerRibbon.UpdateRibbonEnabled(null);
                    break;
                }
            }
            this.Application.ActiveWindow.Selection.SetRange(Application.ActiveWindow.Document.Content.Start, Application.ActiveWindow.Document.Content.End);
            this.Application.ActiveWindow.Selection.Range.Font.Shading.BackgroundPatternColor = WdColor.wdColorAutomatic;
            this.Application.ActiveWindow.Selection.SetRange(0, 0);

            if (!File.Exists("C:\\ProgramData\\Storage.xml")) {
                FileStream tmp = File.Create("C:\\ProgramData\\Storage.xml");
                tmp.Close();
            } else
            {
                using (FileStream stream = File.OpenRead("C:\\ProgramData\\Storage.xml"))
                {
                    try
                    {
                        Datas = xs.Deserialize(stream) as ArrayOfData;
                        foreach (Data data in Datas.Items)
                        {
                            if (data.fileName == getFileName())
                            {
                                Datas.Items.Remove(data);
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        stream.Close();
                        setupCustomPane(true);
                    }
                }
            }
            Debug.WriteLine(Datas.Items.Count);
            using (FileStream stream = File.Create("C:\\ProgramData\\Storage.xml"))
            {
                xs.Serialize(stream, Datas);
            }
            saveDocument();
        }

        private void WorkBeforeSave(Word.Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            foreach (Tuple<int, Microsoft.Office.Tools.CustomTaskPane, myUserControl> tuple in this._windowsController)
            {
                if (tuple.Item1 == this.Application.ActiveWindow.Hwnd)
                {
                    if (tuple.Item3 == null)
                        return;
                    if (!tuple.Item3.RemoveAllColors())
                    {
                        Cancel = true;
                        return;
                    }
                    tuple.Item3.SaveConfig();
                }
            }
        }

        private void WorkBeforePrint(Word.Document Doc, ref bool Cancel)
        {
            foreach (Tuple<int, Microsoft.Office.Tools.CustomTaskPane, myUserControl> tuple in this._windowsController)
            {
                if (tuple.Item1 != this.Application.ActiveWindow.Hwnd)
                {
                    if (tuple.Item3 == null)
                        return;
                    if (!tuple.Item3.RemoveAllColors())
                    {
                        Cancel = true;
                        return;
                    }
                    tuple.Item3.SaveConfig();
                }
            }
        }

        #region Code généré par VSTO

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }

    [Serializable]
    public class ArrayOfData
    {
        public ArrayOfData()
        {
            Items = new List<Data>();
        }
        [XmlArray(ElementName = "Items")]
        public List<Data> Items { get; set; }
    }

    [Serializable]
    public class Data
    {

        public Data()
        {
            this.fileName = null;
            this.fileFullName = null;
            ParamsString = new List<string>();
            ParamsNumber = new List<string>();
            ParamsColor = new List<int>();
            ParamsRangeStart = new List<int>();
            ParamsRangeEnd = new List<int>();
        }

        public Data(List<Tuple<string, Color>> ParamsCopy, List<Tuple<string, Word.Range>> ParamsRangeCopy, List<Tuple<TableLayoutPanel, Button, TextBox, Button>> AddRows, string name, string fullname)
        {
            this.fileName = name;
            this.fileFullName = fullname;
            ParamsString = new List<string>();
            ParamsNumber = new List<string>();
            ParamsColor = new List<int>();
            ParamsRangeStart = new List<int>();
            ParamsRangeEnd = new List<int>();
            foreach (Tuple<string, Word.Range> tuple in ParamsRangeCopy)
            {
                ParamsString.Add(tuple.Item1);
                foreach (Tuple<string, Color> label in ParamsCopy)
                {
                    if (label.Item1 == tuple.Item1)
                    {
                        ParamsColor.Add(label.Item2.ToArgb());
                        break;
                    }
                }
                ParamsRangeStart.Add(tuple.Item2.Start);
                ParamsRangeEnd.Add(tuple.Item2.End);
            }
            foreach (Tuple<TableLayoutPanel, Button, TextBox, Button> rows in AddRows)
            {
                ParamsNumber.Add(rows.Item3.Text);
            }
        }
        public string fileName;
        public string fileFullName;
        public List<string> ParamsString;
        public List<string> ParamsNumber;
        public List<int> ParamsColor;
        public List<int> ParamsRangeStart;
        public List<int> ParamsRangeEnd;
    }
}
