using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordFiller
{
    public partial class ControllerRibbon
    {
        private bool enabled = false;
        private void ControllerRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        public void UpdateRibbonColor(bool state)
        {
            this.colorButton.Checked = state;
        }

        public void UpdateRibbonVisible(bool state)
        {
            this.extensionToggle.Checked = state;
        }

        public void UpdateRibbonEnabled(object value)
        {
            if (value != null)
            {
                enabled = true;
            } else
            {
                enabled = false;
                this.extensionToggle.Checked = false;
            }
            this.colorButton.Enabled = enabled;
            this.printButton.Enabled = enabled;
            this.saveButton.Enabled = enabled;
            this.newColorButton.Enabled = enabled;
        }

        public void UpdateDocumentsList(string fileName)
        {
            foreach (RibbonDropDownItem item in this.docDropDown.Items)
            {
                if (item.Label != fileName)
                {
                    RibbonDropDownItem tmp = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
                    tmp.Label = fileName;
                    this.docDropDown.Items.Add(tmp);
                    return;
                }
            }
            RibbonDropDownItem tmp2 = Globals.Factory.GetRibbonFactory().CreateRibbonDropDownItem();
            tmp2.Label = fileName;
            this.docDropDown.Items.Add(tmp2);
        }

        private void extensionToggle_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.myControllerVisible = !Globals.ThisAddIn.myControllerVisible;
        }

        private void colorButton_Click(object sender, RibbonControlEventArgs e)
        {
            if (Globals.ThisAddIn.myUserController.colorMode)
            {
                Globals.ThisAddIn.myUserController.RemoveAllColors();
            } else
            {
                Globals.ThisAddIn.myUserController.ApplyAllColors();
            }
        }

        private void printButton_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.printDocument();
        }

        private void saveButton_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.saveDocument();
        }

        private void repareButton_Click(object sender, RibbonControlEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Êtes vous sur de vouloir supprimer les paramètres pour ce fichier ? uniquement a réaliser dans le cas ou l'extension ne marcherais pas", "Attention", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Globals.ThisAddIn.repareDocument();
            }
        }

        private void docDropDown_SelectionChanged(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.openFileFromList(this.docDropDown.SelectedItem.Label);
        }

        private void newColorButton_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.ChangeWindowsColor();
        }
    }
}
