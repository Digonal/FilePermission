namespace test
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.sscurFooter = new System.Windows.Forms.StatusStrip();
            this.tsslblText = new System.Windows.Forms.ToolStripStatusLabel();
            this.tvwDirectory = new System.Windows.Forms.TreeView();
            this.ilstIcons = new System.Windows.Forms.ImageList(this.components);
            this.ssFooter = new System.Windows.Forms.StatusStrip();
            this.tsslblFilesName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvwFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.msFile = new System.Windows.Forms.MenuStrip();
            this.tsmiNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRenameFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShare = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lvwGroupOrUserName = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.msPrivilege = new System.Windows.Forms.MenuStrip();
            this.tsmiAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.lvwPrivilege = new System.Windows.Forms.ListView();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tstBox = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.sscurFooter.SuspendLayout();
            this.ssFooter.SuspendLayout();
            this.msFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.msPrivilege.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(872, 494);
            this.splitContainer1.SplitterDistance = 682;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.sscurFooter);
            this.splitContainer2.Panel1.Controls.Add(this.tvwDirectory);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ssFooter);
            this.splitContainer2.Panel2.Controls.Add(this.lvwFiles);
            this.splitContainer2.Panel2.Controls.Add(this.msFile);
            this.splitContainer2.Size = new System.Drawing.Size(682, 494);
            this.splitContainer2.SplitterDistance = 209;
            this.splitContainer2.TabIndex = 0;
            // 
            // sscurFooter
            // 
            this.sscurFooter.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sscurFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblText});
            this.sscurFooter.Location = new System.Drawing.Point(0, 472);
            this.sscurFooter.Name = "sscurFooter";
            this.sscurFooter.Size = new System.Drawing.Size(209, 22);
            this.sscurFooter.TabIndex = 1;
            // 
            // tsslblText
            // 
            this.tsslblText.Name = "tsslblText";
            this.tsslblText.Size = new System.Drawing.Size(0, 17);
            // 
            // tvwDirectory
            // 
            this.tvwDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwDirectory.ImageIndex = 0;
            this.tvwDirectory.ImageList = this.ilstIcons;
            this.tvwDirectory.Location = new System.Drawing.Point(0, 0);
            this.tvwDirectory.Name = "tvwDirectory";
            this.tvwDirectory.SelectedImageIndex = 0;
            this.tvwDirectory.Size = new System.Drawing.Size(209, 494);
            this.tvwDirectory.TabIndex = 0;
            this.tvwDirectory.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwDirectory_BeforeExpand);
            this.tvwDirectory.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvwDirectory_AfterExpand);
            this.tvwDirectory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwDirectory_AfterSelect);
            // 
            // ilstIcons
            // 
            this.ilstIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilstIcons.ImageStream")));
            this.ilstIcons.TransparentColor = System.Drawing.SystemColors.Control;
            this.ilstIcons.Images.SetKeyName(0, "disk.png");
            this.ilstIcons.Images.SetKeyName(1, "folder.png");
            this.ilstIcons.Images.SetKeyName(2, "group_or_user.png");
            this.ilstIcons.Images.SetKeyName(3, "privilege.png");
            // 
            // ssFooter
            // 
            this.ssFooter.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ssFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblFilesName});
            this.ssFooter.Location = new System.Drawing.Point(0, 472);
            this.ssFooter.Name = "ssFooter";
            this.ssFooter.Size = new System.Drawing.Size(469, 22);
            this.ssFooter.TabIndex = 2;
            // 
            // tsslblFilesName
            // 
            this.tsslblFilesName.Name = "tsslblFilesName";
            this.tsslblFilesName.Size = new System.Drawing.Size(0, 17);
            // 
            // lvwFiles
            // 
            this.lvwFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvwFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwFiles.FullRowSelect = true;
            this.lvwFiles.LabelEdit = true;
            this.lvwFiles.Location = new System.Drawing.Point(0, 28);
            this.lvwFiles.Name = "lvwFiles";
            this.lvwFiles.Size = new System.Drawing.Size(469, 466);
            this.lvwFiles.SmallImageList = this.ilstIcons;
            this.lvwFiles.TabIndex = 0;
            this.lvwFiles.UseCompatibleStateImageBehavior = false;
            this.lvwFiles.View = System.Windows.Forms.View.Details;
            this.lvwFiles.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvwFiles_AfterLabelEdit);
            this.lvwFiles.ItemActivate += new System.EventHandler(this.lvwFiles_ItemActivate);
            this.lvwFiles.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwFiles_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 260;
            // 
            // msFile
            // 
            this.msFile.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewFile,
            this.tsmiRenameFile,
            this.tsmiDeleteFile,
            this.tsmiShare,
            this.tsmiRefresh});
            this.msFile.Location = new System.Drawing.Point(0, 0);
            this.msFile.Name = "msFile";
            this.msFile.Size = new System.Drawing.Size(469, 28);
            this.msFile.TabIndex = 1;
            this.msFile.Text = "menuStrip1";
            // 
            // tsmiNewFile
            // 
            this.tsmiNewFile.Name = "tsmiNewFile";
            this.tsmiNewFile.Size = new System.Drawing.Size(96, 24);
            this.tsmiNewFile.Text = "新建文件夹";
            this.tsmiNewFile.Click += new System.EventHandler(this.tsmiNewFile_Click);
            // 
            // tsmiRenameFile
            // 
            this.tsmiRenameFile.Name = "tsmiRenameFile";
            this.tsmiRenameFile.Size = new System.Drawing.Size(111, 24);
            this.tsmiRenameFile.Text = "重命名文件夹";
            this.tsmiRenameFile.Click += new System.EventHandler(this.tsmiRenameFile_Click);
            // 
            // tsmiDeleteFile
            // 
            this.tsmiDeleteFile.Name = "tsmiDeleteFile";
            this.tsmiDeleteFile.Size = new System.Drawing.Size(96, 24);
            this.tsmiDeleteFile.Text = "删除文件夹";
            this.tsmiDeleteFile.Click += new System.EventHandler(this.tsmiDeleteFile_Click);
            // 
            // tsmiShare
            // 
            this.tsmiShare.Name = "tsmiShare";
            this.tsmiShare.Size = new System.Drawing.Size(96, 24);
            this.tsmiShare.Text = "共享文件夹";
            this.tsmiShare.Click += new System.EventHandler(this.tsmiShare_Click);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(51, 24);
            this.tsmiRefresh.Text = "刷新";
            this.tsmiRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lvwGroupOrUserName);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lvwPrivilege);
            this.splitContainer3.Size = new System.Drawing.Size(186, 494);
            this.splitContainer3.SplitterDistance = 239;
            this.splitContainer3.TabIndex = 0;
            // 
            // lvwGroupOrUserName
            // 
            this.lvwGroupOrUserName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvwGroupOrUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwGroupOrUserName.LargeImageList = this.ilstIcons;
            this.lvwGroupOrUserName.Location = new System.Drawing.Point(0, 0);
            this.lvwGroupOrUserName.Name = "lvwGroupOrUserName";
            this.lvwGroupOrUserName.Size = new System.Drawing.Size(186, 239);
            this.lvwGroupOrUserName.TabIndex = 0;
            this.lvwGroupOrUserName.UseCompatibleStateImageBehavior = false;
            this.lvwGroupOrUserName.View = System.Windows.Forms.View.Details;
            this.lvwGroupOrUserName.SelectedIndexChanged += new System.EventHandler(this.lvwGroupOrUserName_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "组或用户名";
            this.columnHeader2.Width = 160;
            // 
            // msPrivilege
            // 
            this.msPrivilege.Dock = System.Windows.Forms.DockStyle.None;
            this.msPrivilege.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msPrivilege.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddUser,
            this.tstBox,
            this.tsmiDeleteUser});
            this.msPrivilege.Location = new System.Drawing.Point(0, 0);
            this.msPrivilege.Name = "msPrivilege";
            this.msPrivilege.Size = new System.Drawing.Size(872, 31);
            this.msPrivilege.TabIndex = 1;
            this.msPrivilege.Text = "menuStrip2";
            // 
            // tsmiAddUser
            // 
            this.tsmiAddUser.Name = "tsmiAddUser";
            this.tsmiAddUser.Size = new System.Drawing.Size(81, 27);
            this.tsmiAddUser.Text = "添加账号";
            this.tsmiAddUser.Click += new System.EventHandler(this.tsmiAddUser_Click);
            // 
            // tsmiDeleteUser
            // 
            this.tsmiDeleteUser.Name = "tsmiDeleteUser";
            this.tsmiDeleteUser.Size = new System.Drawing.Size(81, 27);
            this.tsmiDeleteUser.Text = "删除账号";
            this.tsmiDeleteUser.Click += new System.EventHandler(this.tsmiDeleteUser_Click);
            // 
            // lvwPrivilege
            // 
            this.lvwPrivilege.CheckBoxes = true;
            this.lvwPrivilege.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPrivilege.FullRowSelect = true;
            this.lvwPrivilege.LargeImageList = this.ilstIcons;
            this.lvwPrivilege.Location = new System.Drawing.Point(0, 0);
            this.lvwPrivilege.Name = "lvwPrivilege";
            this.lvwPrivilege.Size = new System.Drawing.Size(186, 251);
            this.lvwPrivilege.SmallImageList = this.ilstIcons;
            this.lvwPrivilege.TabIndex = 0;
            this.lvwPrivilege.UseCompatibleStateImageBehavior = false;
            this.lvwPrivilege.View = System.Windows.Forms.View.List;
            this.lvwPrivilege.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwPrivilege_ItemChecked);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(872, 494);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(872, 525);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.msPrivilege);
            // 
            // tstBox
            // 
            this.tstBox.Name = "tstBox";
            this.tstBox.Size = new System.Drawing.Size(100, 27);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 525);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件权限设置器";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.sscurFooter.ResumeLayout(false);
            this.sscurFooter.PerformLayout();
            this.ssFooter.ResumeLayout(false);
            this.ssFooter.PerformLayout();
            this.msFile.ResumeLayout(false);
            this.msFile.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.msPrivilege.ResumeLayout(false);
            this.msPrivilege.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView tvwDirectory;
        private System.Windows.Forms.ListView lvwFiles;
        private System.Windows.Forms.ListView lvwGroupOrUserName;
        private System.Windows.Forms.ListView lvwPrivilege;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.MenuStrip msFile;
        private System.Windows.Forms.MenuStrip msPrivilege;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewFile;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddUser;
        private System.Windows.Forms.ImageList ilstIcons;
        private System.Windows.Forms.StatusStrip ssFooter;
        private System.Windows.Forms.ToolStripStatusLabel tsslblFilesName;
        private System.Windows.Forms.ToolStripMenuItem tsmiRenameFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteUser;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.StatusStrip sscurFooter;
        private System.Windows.Forms.ToolStripStatusLabel tsslblText;
        private System.Windows.Forms.ToolStripMenuItem tsmiShare;
        private System.Windows.Forms.ToolStripTextBox tstBox;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    }
}