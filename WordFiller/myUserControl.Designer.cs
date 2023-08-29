namespace WordFiller
{
    partial class myUserControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.Remplir = new System.Windows.Forms.TabPage();
            this.FillLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.FillParamsLabel = new System.Windows.Forms.Label();
            this.FillRowLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ApplyTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ColorParamsButton = new System.Windows.Forms.Button();
            this.ApplyParamsButton = new System.Windows.Forms.Button();
            this.Ajouter = new System.Windows.Forms.TabPage();
            this.AddLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AddSecondLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AddNewLabel = new System.Windows.Forms.Label();
            this.AddNewButton = new System.Windows.Forms.Button();
            this.AddNewTextBox = new System.Windows.Forms.TextBox();
            this.AddContentLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AddRowLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.AddRowNoneLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.NoneButton = new System.Windows.Forms.Button();
            this.AddParamsListLabel = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.Remplir.SuspendLayout();
            this.FillLayoutPanel.SuspendLayout();
            this.ApplyTableLayout.SuspendLayout();
            this.Ajouter.SuspendLayout();
            this.AddLayoutPanel.SuspendLayout();
            this.AddSecondLayoutPanel.SuspendLayout();
            this.AddContentLayoutPanel.SuspendLayout();
            this.AddRowLayoutPanel.SuspendLayout();
            this.AddRowNoneLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.Remplir);
            this.tabControl.Controls.Add(this.Ajouter);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ItemSize = new System.Drawing.Size(110, 18);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(480, 550);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // Remplir
            // 
            this.Remplir.Controls.Add(this.FillLayoutPanel);
            this.Remplir.Location = new System.Drawing.Point(4, 22);
            this.Remplir.Name = "Remplir";
            this.Remplir.Padding = new System.Windows.Forms.Padding(3);
            this.Remplir.Size = new System.Drawing.Size(472, 524);
            this.Remplir.TabIndex = 0;
            this.Remplir.Text = "Remplir";
            this.Remplir.UseVisualStyleBackColor = true;
            // 
            // FillLayoutPanel
            // 
            this.FillLayoutPanel.ColumnCount = 1;
            this.FillLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FillLayoutPanel.Controls.Add(this.FillParamsLabel, 0, 0);
            this.FillLayoutPanel.Controls.Add(this.FillRowLayoutPanel, 0, 1);
            this.FillLayoutPanel.Controls.Add(this.ApplyTableLayout, 0, 2);
            this.FillLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FillLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.FillLayoutPanel.Name = "FillLayoutPanel";
            this.FillLayoutPanel.RowCount = 3;
            this.FillLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.FillLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FillLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.FillLayoutPanel.Size = new System.Drawing.Size(466, 518);
            this.FillLayoutPanel.TabIndex = 0;
            // 
            // FillParamsLabel
            // 
            this.FillParamsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FillParamsLabel.AutoSize = true;
            this.FillParamsLabel.Location = new System.Drawing.Point(10, 6);
            this.FillParamsLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.FillParamsLabel.Name = "FillParamsLabel";
            this.FillParamsLabel.Size = new System.Drawing.Size(66, 13);
            this.FillParamsLabel.TabIndex = 0;
            this.FillParamsLabel.Text = "Paramètres :";
            this.FillParamsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FillRowLayoutPanel
            // 
            this.FillRowLayoutPanel.AutoScroll = true;
            this.FillRowLayoutPanel.AutoSize = true;
            this.FillRowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FillRowLayoutPanel.ColumnCount = 1;
            this.FillRowLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.FillRowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FillRowLayoutPanel.Location = new System.Drawing.Point(3, 28);
            this.FillRowLayoutPanel.Name = "FillRowLayoutPanel";
            this.FillRowLayoutPanel.RowCount = 1;
            this.FillRowLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.FillRowLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.FillRowLayoutPanel.Size = new System.Drawing.Size(460, 60);
            this.FillRowLayoutPanel.TabIndex = 1;
            // 
            // ApplyTableLayout
            // 
            this.ApplyTableLayout.ColumnCount = 2;
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ApplyTableLayout.Controls.Add(this.ColorParamsButton, 1, 0);
            this.ApplyTableLayout.Controls.Add(this.ApplyParamsButton, 0, 0);
            this.ApplyTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ApplyTableLayout.Location = new System.Drawing.Point(0, 488);
            this.ApplyTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.ApplyTableLayout.Name = "ApplyTableLayout";
            this.ApplyTableLayout.RowCount = 1;
            this.ApplyTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ApplyTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ApplyTableLayout.Size = new System.Drawing.Size(466, 30);
            this.ApplyTableLayout.TabIndex = 2;
            // 
            // ColorParamsButton
            // 
            this.ColorParamsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ColorParamsButton.Location = new System.Drawing.Point(243, 3);
            this.ColorParamsButton.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.ColorParamsButton.Name = "ColorParamsButton";
            this.ColorParamsButton.Size = new System.Drawing.Size(75, 24);
            this.ColorParamsButton.TabIndex = 1;
            this.ColorParamsButton.Text = "Couleur";
            this.ColorParamsButton.UseVisualStyleBackColor = true;
            this.ColorParamsButton.Click += new System.EventHandler(this.ColorParamsButton_Click);
            // 
            // ApplyParamsButton
            // 
            this.ApplyParamsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyParamsButton.Location = new System.Drawing.Point(148, 3);
            this.ApplyParamsButton.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.ApplyParamsButton.Name = "ApplyParamsButton";
            this.ApplyParamsButton.Size = new System.Drawing.Size(75, 24);
            this.ApplyParamsButton.TabIndex = 0;
            this.ApplyParamsButton.Text = "Appliquer";
            this.ApplyParamsButton.UseVisualStyleBackColor = true;
            this.ApplyParamsButton.Click += new System.EventHandler(this.ApplyParamsButton_Click);
            // 
            // Ajouter
            // 
            this.Ajouter.Controls.Add(this.AddLayoutPanel);
            this.Ajouter.Location = new System.Drawing.Point(4, 22);
            this.Ajouter.Name = "Ajouter";
            this.Ajouter.Padding = new System.Windows.Forms.Padding(3);
            this.Ajouter.Size = new System.Drawing.Size(472, 524);
            this.Ajouter.TabIndex = 1;
            this.Ajouter.Text = "Ajouter";
            this.Ajouter.UseVisualStyleBackColor = true;
            // 
            // AddLayoutPanel
            // 
            this.AddLayoutPanel.ColumnCount = 1;
            this.AddLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddLayoutPanel.Controls.Add(this.AddSecondLayoutPanel, 0, 0);
            this.AddLayoutPanel.Controls.Add(this.AddContentLayoutPanel, 0, 1);
            this.AddLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.AddLayoutPanel.Name = "AddLayoutPanel";
            this.AddLayoutPanel.RowCount = 2;
            this.AddLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.AddLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddLayoutPanel.Size = new System.Drawing.Size(466, 518);
            this.AddLayoutPanel.TabIndex = 0;
            // 
            // AddSecondLayoutPanel
            // 
            this.AddSecondLayoutPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AddSecondLayoutPanel.ColumnCount = 2;
            this.AddSecondLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddSecondLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.AddSecondLayoutPanel.Controls.Add(this.AddNewLabel, 0, 0);
            this.AddSecondLayoutPanel.Controls.Add(this.AddNewButton, 1, 1);
            this.AddSecondLayoutPanel.Controls.Add(this.AddNewTextBox, 0, 1);
            this.AddSecondLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddSecondLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.AddSecondLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.AddSecondLayoutPanel.Name = "AddSecondLayoutPanel";
            this.AddSecondLayoutPanel.RowCount = 2;
            this.AddSecondLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AddSecondLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.AddSecondLayoutPanel.Size = new System.Drawing.Size(466, 75);
            this.AddSecondLayoutPanel.TabIndex = 0;
            // 
            // AddNewLabel
            // 
            this.AddNewLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddNewLabel.AutoSize = true;
            this.AddNewLabel.Location = new System.Drawing.Point(10, 19);
            this.AddNewLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 5);
            this.AddNewLabel.Name = "AddNewLabel";
            this.AddNewLabel.Size = new System.Drawing.Size(108, 13);
            this.AddNewLabel.TabIndex = 0;
            this.AddNewLabel.Text = "Nouveau Paramètre :";
            this.AddNewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddNewButton
            // 
            this.AddNewButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddNewButton.Location = new System.Drawing.Point(376, 40);
            this.AddNewButton.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.AddNewButton.Name = "AddNewButton";
            this.AddNewButton.Size = new System.Drawing.Size(80, 23);
            this.AddNewButton.TabIndex = 1;
            this.AddNewButton.Text = "Ajouter";
            this.AddNewButton.UseVisualStyleBackColor = true;
            this.AddNewButton.Click += new System.EventHandler(this.AddNewButton_Click);
            // 
            // AddNewTextBox
            // 
            this.AddNewTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddNewTextBox.Location = new System.Drawing.Point(10, 42);
            this.AddNewTextBox.Margin = new System.Windows.Forms.Padding(10, 5, 10, 3);
            this.AddNewTextBox.Name = "AddNewTextBox";
            this.AddNewTextBox.Size = new System.Drawing.Size(346, 20);
            this.AddNewTextBox.TabIndex = 2;
            this.AddNewTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddNewTextBox_KeyPress);
            // 
            // AddContentLayoutPanel
            // 
            this.AddContentLayoutPanel.ColumnCount = 1;
            this.AddContentLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddContentLayoutPanel.Controls.Add(this.AddRowLayoutPanel, 0, 1);
            this.AddContentLayoutPanel.Controls.Add(this.AddParamsListLabel, 0, 0);
            this.AddContentLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddContentLayoutPanel.Location = new System.Drawing.Point(0, 75);
            this.AddContentLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.AddContentLayoutPanel.Name = "AddContentLayoutPanel";
            this.AddContentLayoutPanel.RowCount = 2;
            this.AddContentLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.AddContentLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddContentLayoutPanel.Size = new System.Drawing.Size(466, 443);
            this.AddContentLayoutPanel.TabIndex = 1;
            // 
            // AddRowLayoutPanel
            // 
            this.AddRowLayoutPanel.AutoScroll = true;
            this.AddRowLayoutPanel.AutoSize = true;
            this.AddRowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddRowLayoutPanel.ColumnCount = 1;
            this.AddRowLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddRowLayoutPanel.Controls.Add(this.AddRowNoneLayoutPanel, 0, 0);
            this.AddRowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddRowLayoutPanel.Location = new System.Drawing.Point(3, 28);
            this.AddRowLayoutPanel.Name = "AddRowLayoutPanel";
            this.AddRowLayoutPanel.RowCount = 2;
            this.AddRowLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.AddRowLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.AddRowLayoutPanel.Size = new System.Drawing.Size(460, 80);
            this.AddRowLayoutPanel.TabIndex = 2;
            // 
            // AddRowNoneLayoutPanel
            // 
            this.AddRowNoneLayoutPanel.AutoSize = true;
            this.AddRowNoneLayoutPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AddRowNoneLayoutPanel.ColumnCount = 1;
            this.AddRowNoneLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.AddRowNoneLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.AddRowNoneLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.AddRowNoneLayoutPanel.Controls.Add(this.NoneButton, 0, 0);
            this.AddRowNoneLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddRowNoneLayoutPanel.Location = new System.Drawing.Point(10, 3);
            this.AddRowNoneLayoutPanel.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.AddRowNoneLayoutPanel.Name = "AddRowNoneLayoutPanel";
            this.AddRowNoneLayoutPanel.RowCount = 1;
            this.AddRowNoneLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.AddRowNoneLayoutPanel.Size = new System.Drawing.Size(440, 34);
            this.AddRowNoneLayoutPanel.TabIndex = 0;
            // 
            // NoneButton
            // 
            this.NoneButton.AutoSize = true;
            this.NoneButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NoneButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.NoneButton.Location = new System.Drawing.Point(7, 3);
            this.NoneButton.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.NoneButton.Name = "NoneButton";
            this.NoneButton.Size = new System.Drawing.Size(54, 28);
            this.NoneButton.TabIndex = 0;
            this.NoneButton.Text = "[Aucun]";
            this.NoneButton.UseVisualStyleBackColor = true;
            this.NoneButton.Click += new System.EventHandler(this.AddSelectedText);
            // 
            // AddParamsListLabel
            // 
            this.AddParamsListLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AddParamsListLabel.AutoSize = true;
            this.AddParamsListLabel.Location = new System.Drawing.Point(10, 6);
            this.AddParamsListLabel.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.AddParamsListLabel.Name = "AddParamsListLabel";
            this.AddParamsListLabel.Size = new System.Drawing.Size(110, 13);
            this.AddParamsListLabel.TabIndex = 0;
            this.AddParamsListLabel.Text = "Liste des paramètres :";
            // 
            // myUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(280, 500);
            this.Name = "myUserControl";
            this.Size = new System.Drawing.Size(480, 550);
            this.tabControl.ResumeLayout(false);
            this.Remplir.ResumeLayout(false);
            this.FillLayoutPanel.ResumeLayout(false);
            this.FillLayoutPanel.PerformLayout();
            this.ApplyTableLayout.ResumeLayout(false);
            this.Ajouter.ResumeLayout(false);
            this.AddLayoutPanel.ResumeLayout(false);
            this.AddSecondLayoutPanel.ResumeLayout(false);
            this.AddSecondLayoutPanel.PerformLayout();
            this.AddContentLayoutPanel.ResumeLayout(false);
            this.AddContentLayoutPanel.PerformLayout();
            this.AddRowLayoutPanel.ResumeLayout(false);
            this.AddRowLayoutPanel.PerformLayout();
            this.AddRowNoneLayoutPanel.ResumeLayout(false);
            this.AddRowNoneLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage Remplir;
        private System.Windows.Forms.TabPage Ajouter;
        private System.Windows.Forms.TableLayoutPanel FillLayoutPanel;
        private System.Windows.Forms.Label FillParamsLabel;
        private System.Windows.Forms.TableLayoutPanel AddLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel AddSecondLayoutPanel;
        private System.Windows.Forms.Label AddNewLabel;
        private System.Windows.Forms.Button AddNewButton;
        private System.Windows.Forms.TextBox AddNewTextBox;
        private System.Windows.Forms.TableLayoutPanel FillRowLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel AddContentLayoutPanel;
        private System.Windows.Forms.Label AddParamsListLabel;
        private System.Windows.Forms.TableLayoutPanel AddRowLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel AddRowNoneLayoutPanel;
        private System.Windows.Forms.Button NoneButton;
        private System.Windows.Forms.TableLayoutPanel ApplyTableLayout;
        private System.Windows.Forms.Button ColorParamsButton;
        private System.Windows.Forms.Button ApplyParamsButton;
    }
}
