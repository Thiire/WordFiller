namespace WordFiller
{
    partial class ControllerRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public ControllerRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Office.Tools.Ribbon.RibbonDropDownItem ribbonDropDownItemImpl1 = this.Factory.CreateRibbonDropDownItem();
            this.MainTab = this.Factory.CreateRibbonTab();
            this.affichageGroup = this.Factory.CreateRibbonGroup();
            this.extensionToggle = this.Factory.CreateRibbonToggleButton();
            this.couleurGroup = this.Factory.CreateRibbonGroup();
            this.colorButton = this.Factory.CreateRibbonToggleButton();
            this.printGroup = this.Factory.CreateRibbonGroup();
            this.printButton = this.Factory.CreateRibbonButton();
            this.saveButton = this.Factory.CreateRibbonButton();
            this.repareGroup = this.Factory.CreateRibbonGroup();
            this.repareButton = this.Factory.CreateRibbonButton();
            this.docGroup = this.Factory.CreateRibbonGroup();
            this.docDropDown = this.Factory.CreateRibbonDropDown();
            this.newColorButton = this.Factory.CreateRibbonButton();
            this.MainTab.SuspendLayout();
            this.affichageGroup.SuspendLayout();
            this.couleurGroup.SuspendLayout();
            this.printGroup.SuspendLayout();
            this.repareGroup.SuspendLayout();
            this.docGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Groups.Add(this.affichageGroup);
            this.MainTab.Groups.Add(this.couleurGroup);
            this.MainTab.Groups.Add(this.printGroup);
            this.MainTab.Groups.Add(this.repareGroup);
            this.MainTab.Groups.Add(this.docGroup);
            this.MainTab.Label = "WordFiller";
            this.MainTab.Name = "MainTab";
            // 
            // affichageGroup
            // 
            this.affichageGroup.Items.Add(this.extensionToggle);
            this.affichageGroup.Label = "Affichage";
            this.affichageGroup.Name = "affichageGroup";
            // 
            // extensionToggle
            // 
            this.extensionToggle.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.extensionToggle.Label = "Afficher l\'extension";
            this.extensionToggle.Name = "extensionToggle";
            this.extensionToggle.OfficeImageId = "MarkPageAsRead";
            this.extensionToggle.ShowImage = true;
            this.extensionToggle.SuperTip = "affiche ou non l\'extension WordFiller";
            this.extensionToggle.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.extensionToggle_Click);
            // 
            // couleurGroup
            // 
            this.couleurGroup.Items.Add(this.colorButton);
            this.couleurGroup.Items.Add(this.newColorButton);
            this.couleurGroup.Label = "Couleur";
            this.couleurGroup.Name = "couleurGroup";
            // 
            // colorButton
            // 
            this.colorButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.colorButton.Enabled = false;
            this.colorButton.Label = "Colorier les paramètres";
            this.colorButton.Name = "colorButton";
            this.colorButton.OfficeImageId = "InkColorMoreColorsDialog";
            this.colorButton.ShowImage = true;
            this.colorButton.SuperTip = "afficher ou non les couleurs des différents paramètres";
            this.colorButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.colorButton_Click);
            // 
            // printGroup
            // 
            this.printGroup.Items.Add(this.printButton);
            this.printGroup.Items.Add(this.saveButton);
            this.printGroup.Label = "Fichier";
            this.printGroup.Name = "printGroup";
            // 
            // printButton
            // 
            this.printButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.printButton.Enabled = false;
            this.printButton.Label = "Imprimer";
            this.printButton.Name = "printButton";
            this.printButton.OfficeImageId = "FilePrintPreview";
            this.printButton.ShowImage = true;
            this.printButton.SuperTip = "Imprime le document actuel";
            this.printButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.printButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.saveButton.Enabled = false;
            this.saveButton.Label = "Sauvegarder";
            this.saveButton.Name = "saveButton";
            this.saveButton.OfficeImageId = "ExportSavedExports";
            this.saveButton.ShowImage = true;
            this.saveButton.SuperTip = "sauvegarde le document actuel";
            this.saveButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.saveButton_Click);
            // 
            // repareGroup
            // 
            this.repareGroup.Items.Add(this.repareButton);
            this.repareGroup.Label = "Réparation";
            this.repareGroup.Name = "repareGroup";
            // 
            // repareButton
            // 
            this.repareButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.repareButton.Label = "Réparer le fichier";
            this.repareButton.Name = "repareButton";
            this.repareButton.OfficeImageId = "MacroSecurity";
            this.repareButton.ShowImage = true;
            this.repareButton.SuperTip = "Supprime les sauvegarde de l\'extension pour ce fichier";
            this.repareButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.repareButton_Click);
            // 
            // docGroup
            // 
            this.docGroup.Items.Add(this.docDropDown);
            this.docGroup.Label = "Document géré";
            this.docGroup.Name = "docGroup";
            // 
            // docDropDown
            // 
            ribbonDropDownItemImpl1.Label = "[Aucun]";
            this.docDropDown.Items.Add(ribbonDropDownItemImpl1);
            this.docDropDown.Label = "Documents";
            this.docDropDown.Name = "docDropDown";
            this.docDropDown.OfficeImageId = "DatabaseDocumenter";
            this.docDropDown.ShowImage = true;
            this.docDropDown.SuperTip = "Permet d\'ouvrir rapidement les documents géré par l\'extension";
            this.docDropDown.SelectionChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.docDropDown_SelectionChanged);
            // 
            // newColorButton
            // 
            this.newColorButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.newColorButton.Enabled = false;
            this.newColorButton.Label = "Nouvelle palette";
            this.newColorButton.Name = "newColorButton";
            this.newColorButton.OfficeImageId = "ArtisticEffectsDialog";
            this.newColorButton.ShowImage = true;
            this.newColorButton.SuperTip = "Imprime le document actuel";
            this.newColorButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.newColorButton_Click);
            // 
            // ControllerRibbon
            // 
            this.Name = "ControllerRibbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.MainTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.ControllerRibbon_Load);
            this.MainTab.ResumeLayout(false);
            this.MainTab.PerformLayout();
            this.affichageGroup.ResumeLayout(false);
            this.affichageGroup.PerformLayout();
            this.couleurGroup.ResumeLayout(false);
            this.couleurGroup.PerformLayout();
            this.printGroup.ResumeLayout(false);
            this.printGroup.PerformLayout();
            this.repareGroup.ResumeLayout(false);
            this.repareGroup.PerformLayout();
            this.docGroup.ResumeLayout(false);
            this.docGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab MainTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup affichageGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton extensionToggle;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup couleurGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton colorButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup printGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton printButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton saveButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup repareGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton repareButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup docGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown docDropDown;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton newColorButton;
    }

    partial class ThisRibbonCollection
    {
        internal ControllerRibbon ControllerRibbon
        {
            get { return this.GetRibbon<ControllerRibbon>(); }
        }
    }
}
