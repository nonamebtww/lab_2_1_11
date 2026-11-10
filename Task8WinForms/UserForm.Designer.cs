namespace Task8WinForms {
partial class UserForm {
  private System.ComponentModel.IContainer components = null;

  private System.Windows.Forms.Label labelGreeting;
  private System.Windows.Forms.ListView listFields;
  private System.Windows.Forms.ColumnHeader columnName;
  private System.Windows.Forms.ColumnHeader columnValue;
  private System.Windows.Forms.Button btnClose;

  protected override void Dispose(bool disposing) {
    if (disposing && (components != null)) {
      components.Dispose();
    }

    base.Dispose(disposing);
  }

  #region Windows Form Designer generated code

  /// <summary>
  /// Required method for Designer support - do not modify
  /// the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent() {
    this.labelGreeting = new System.Windows.Forms.Label();
    this.listFields = new System.Windows.Forms.ListView();
    this.columnName = new System.Windows.Forms.ColumnHeader();
    this.columnValue = new System.Windows.Forms.ColumnHeader();
    this.btnClose = new System.Windows.Forms.Button();
    this.SuspendLayout();
    //
    // labelGreeting
    //
    this.labelGreeting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
    this.labelGreeting.Location = new System.Drawing.Point(12, 9);
    this.labelGreeting.Name = "labelGreeting";
    this.labelGreeting.Size = new System.Drawing.Size(460, 40);
    this.labelGreeting.TabIndex = 0;
    this.labelGreeting.Text = "Приветствие";
    this.labelGreeting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
    //
    // listFields
    //
    this.listFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
    this.listFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
      this.columnName,
      this.columnValue});
    this.listFields.FullRowSelect = true;
    this.listFields.GridLines = true;
    this.listFields.HideSelection = false;
    this.listFields.Location = new System.Drawing.Point(12, 52);
    this.listFields.MultiSelect = false;
    this.listFields.Name = "listFields";
    this.listFields.Size = new System.Drawing.Size(460, 300);
    this.listFields.TabIndex = 1;
    this.listFields.UseCompatibleStateImageBehavior = false;
    this.listFields.View = System.Windows.Forms.View.Details;
    //
    // columnName
    //
    this.columnName.Text = "Поле";
    this.columnName.Width = 150;
    //
    // columnValue
    //
    this.columnValue.Text = "Значение";
    this.columnValue.Width = 300;
    //
    // btnClose
    //
    this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
    this.btnClose.Location = new System.Drawing.Point(372, 362);
    this.btnClose.Name = "btnClose";
    this.btnClose.Size = new System.Drawing.Size(100, 27);
    this.btnClose.TabIndex = 2;
    this.btnClose.Text = "Закрыть";
    this.btnClose.UseVisualStyleBackColor = true;
    this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
    //
    // UserForm
    //
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(484, 401);
    this.Controls.Add(this.labelGreeting);
    this.Controls.Add(this.listFields);
    this.Controls.Add(this.btnClose);
    this.MinimumSize = new System.Drawing.Size(400, 300);
    this.Name = "UserForm";
    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    this.Text = "Пользователь";
    this.ResumeLayout(false);
  }

  #endregion
}
}
