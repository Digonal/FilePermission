using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.DirectoryServices;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Management;

namespace test
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender,EventArgs e)
        {
            InitDisplay();//初始化界面
        }

        
        private class IconsIndexes
        {
            public const int FixedDrive = 0; //固定磁盘
            public const int Folder = 1; //文件夹图标
            public const int GroupOrUser = 2; //组或用户
            public const int Privilege = 3; //权限
        }

        #region 菜单功能
        private void  tsmiNewFile_Click(object sender,EventArgs e)
        {
            CreateFile();
        }

        private void tsmiRenameFile_Click(object sender,EventArgs e)
        {
            RenameFile();
        }

        private void tsmiDeleteFile_Click(object sender,EventArgs e)
        {
            DeleteFiles();
        }

        private TreeNode curSelectedNode = null;
        private void tsmiRefresh_Click(object sender, EventArgs e)
        {
            ShowFilesList(fileName);
            LoadChildNodes(curSelectedNode);
        }

        private void lvwFiles_ItemActivate(object sender,EventArgs e)
        {
            Open();
        }


        private void tsmiAddUser_Click(object sender,EventArgs e)
        {
            AddUser(fileName,tstBox.Text);
            if (tstBox.Text != null)
            {
                tstBox.Text = "";
            }
        }

        private string curUser;
        private void tsmiDeleteUser_Click(object sender,EventArgs e)
        {
            curUser = lvwGroupOrUserName.SelectedItems[0].Text;
            DeleteUser(fileName,curUser);
            
        }

        private string curFile;
        private void tsmiShare_Click(object sender,EventArgs e)
        {
            //curFile = lvwFiles.SelectedItems[0].Text;
            //ShareFile(fileName,curFile,null);
        }
        #endregion

        #region 加载文件夹节点
        private void tvwDirectory_AfterSelect(object sender,TreeViewEventArgs e)
        {
            curSelectedNode = e.Node;
            ShowFilesList(e.Node.Tag.ToString());
        }

        private void tvwDirectory_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //在被选中节点展开前，加载被选中节点的子节点
            LoadChildNodes(e.Node);
        }

        private void tvwDirectory_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //在被选中节点展开后，展开该节点
            e.Node.Expand();
        }
        #endregion

        private void lvwFiles_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ShowPrivilege(e.Item.Tag.ToString());
        }

        #region 初始化程序 InitDisplay()
        private void InitDisplay()
        {
            tvwDirectory.Nodes.Clear();

            DriveInfo[] driveInfos = DriveInfo.GetDrives();
            foreach(DriveInfo info in driveInfos)
            {
                TreeNode driveNode = null;
                if (info.DriveType == DriveType.Fixed)
                {
                    driveNode = tvwDirectory.Nodes.Add("本地磁盘(" + info.Name.Split('\\')[0] + ")");
                    driveNode.Tag = info.Name;
                    driveNode.ImageIndex = IconsIndexes.FixedDrive;
                    driveNode.SelectedImageIndex = IconsIndexes.FixedDrive;
                }
            }

            foreach(TreeNode node in tvwDirectory.Nodes)
            {
                LoadChildNodes(node);
            }
        }
        #endregion

        #region 左侧框显示本地磁盘
        private void LoadChildNodes(TreeNode node)
        {
            try
            {
                node.Nodes.Clear();
                DirectoryInfo directoryInfo = new DirectoryInfo(node.Tag.ToString());
                DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();

                foreach(DirectoryInfo info in directoryInfos)
                {
                    TreeNode childNode = node.Nodes.Add(info.Name);
                    childNode.Tag = info.FullName;
                    childNode.ImageIndex = IconsIndexes.Folder;
                    childNode.SelectedImageIndex = IconsIndexes.Folder;
                    childNode.Nodes.Add("");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private string fileName = "";

        #region 新建文件夹
        private void CreateFile()
        {
            try
            {
                int num = 1;
                string path = Path.Combine(fileName, "新建文件夹");
                string newFilePath = path;

                while (Directory.Exists(newFilePath))
                {
                    newFilePath = path + "(" + num + ")";
                    num++;
                }

                Directory.CreateDirectory(newFilePath);
                ListViewItem item = lvwFiles.Items.Add("新建文件夹" + (num == 1 ? "" : "(" + (num - 1) + ")"), IconsIndexes.Folder);

                //真正的路径
                item.Tag = newFilePath;

                //刷新左边的目录树
                LoadChildNodes(curSelectedNode);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 打开文件夹
        private void Open()
        {
            if (lvwFiles.SelectedItems.Count > 0)
            {
                string path = lvwFiles.SelectedItems[0].Tag.ToString();

                try
                {
                        //打开文件夹
                    ShowFilesList(path);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region 删除文件
        private void DeleteFiles()
        {
            if (lvwFiles.SelectedItems.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("确定要删除吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    try
                    {
                        foreach (ListViewItem item in lvwFiles.SelectedItems)
                        {
                            string path = item.Tag.ToString();
                            Directory.Delete(path, true);
                            lvwFiles.Items.Remove(item);
                        }

                        //刷新左边的目录树
                        LoadChildNodes(curSelectedNode);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region 重命名文件
        private void RenameFile()
        {
            if (lvwFiles.SelectedItems.Count > 0)
            {
                //模拟进行编辑标签，实质是为了通过代码触发LabelEdit事件
                lvwFiles.SelectedItems[0].BeginEdit();
            }

        }
        #endregion

        private InheritanceFlags inherits = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
        private PropagationFlags propagats = PropagationFlags.None;

        #region 添加用户/用户组
        private void AddUser(string filePath,string userName) 
        {
            DirectoryInfo dirInfo = new DirectoryInfo(filePath);
            if ((dirInfo.Attributes & FileAttributes.ReadOnly) != 0)
            {
                dirInfo.Attributes = FileAttributes.Normal;
            }
            DirectorySecurity dirSecurity = dirInfo.GetAccessControl();
            dirSecurity.AddAccessRule(new FileSystemAccessRule(userName, FileSystemRights.ReadAndExecute,inherits,propagats, AccessControlType.Allow));
            dirInfo.SetAccessControl(dirSecurity);
            ShowFilesList(filePath);
        }
        #endregion

        #region 删除用户/用户组
        private void DeleteUser(string filePath, string userName)
        {

            DirectoryInfo dirInfo = new DirectoryInfo(filePath);
            if ((dirInfo.Attributes & FileAttributes.ReadOnly) != 0)
            {
                dirInfo.Attributes = FileAttributes.Normal;
            }
            DirectorySecurity dirSecurity = dirInfo.GetAccessControl();
            dirSecurity.SetAccessRuleProtection(true, false);
            dirSecurity.RemoveAccessRule(new FileSystemAccessRule(userName, FileSystemRights.ReadAndExecute,AccessControlType.Allow));
            dirInfo.SetAccessControl(dirSecurity);
            

            foreach (ListViewItem item in lvwGroupOrUserName.SelectedItems)
            {
                lvwGroupOrUserName.Items.Remove(item);
            }
            ShowFilesList(filePath);
        }
        #endregion

        #region 开启文件共享
        //public int ShareFile(string FolderPath, string ShareName, string Description)
        //{
        //    try
        //    {
        //        ManagementClass managementClass = new ManagementClass("Win32_Share");
        //        // Create ManagementBaseObjects for in and out parameters  
        //        ManagementBaseObject inParams = managementClass.GetMethodParameters("Create");
        //        ManagementBaseObject outParams;
        //        // Set the input parameters  
        //        inParams["Description"] = Description;
        //        inParams["Name"] = ShareName;
        //        inParams["Path"] = FolderPath;
        //        inParams["Type"] = 0x0; // Disk Drive  
        //        outParams = managementClass.InvokeMethod("Create", inParams, null);
        //        // Check to see if the method invocation was successful  
        //        if ((uint)(outParams.Properties["ReturnValue"].Value) != 0)
        //        {
        //            throw new Exception("共享失败");
        //        }
        //    }
        //    catch
        //    {
        //        return -1;
        //    }
        //    return 0;
        //}
        #endregion

        #region 检查列表中文件
        private void lvwFiles_AfterLabelEdit(object sender,LabelEditEventArgs e)
        {
            string newName = e.Label;
            ListViewItem selectedItem = lvwFiles.SelectedItems[0];

            //如果名称为空
            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("文件名不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //显示时，恢复原来的标签
                e.CancelEdit = true;
            }
            //标签没有改动
            else if (newName == null)
            {
                return;
            }
            //标签改动了，但是最终还是和原来一样
            else if (newName == selectedItem.Text)
            {
                return;
            }
            //文件名不合法
            else if (!IsValidFileName(newName))
            {
                MessageBox.Show("文件名不能包含下列任何字符:\r\n" + "\t\\/:*?\"<>|", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //显示时，恢复原来的标签
                e.CancelEdit = true;
            }
            else
            {
                Computer myComputer = new Computer();
                if(Directory.Exists(selectedItem.Tag.ToString()))
                {
                    //如果当前路径下有同名的文件夹
                    if (Directory.Exists(Path.Combine(fileName, newName)))
                    {
                        MessageBox.Show("当前路径下有同名的文件夹！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //显示时，恢复原来的标签
                        e.CancelEdit = true;
                    }
                    else
                    {
                        myComputer.FileSystem.RenameDirectory(selectedItem.Tag.ToString(), newName);

                        DirectoryInfo directoryInfo = new DirectoryInfo(selectedItem.Tag.ToString());
                        string parentPath = directoryInfo.Parent.FullName;
                        string newPath = Path.Combine(parentPath, newName);

                        //更新选中项的Tag
                        selectedItem.Tag = newPath;

                        //刷新左边的目录树
                        LoadChildNodes(curSelectedNode);
                    }
                }
            }
        }
        #endregion

        #region 检查文件名是否合法,文件名中不能包含字符\/:*?"<>|
        private bool IsValidFileName(string fileName)
        {
            bool isValid = true;

            //非法字符
            string errChar = "\\/:*?\"<>|";

            for (int i = 0; i < errChar.Length; i++)
            {
                if (fileName.Contains(errChar[i].ToString()))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }
        #endregion

        #region 在中间框中显示文件夹 ShowFilesList()
        public void ShowFilesList(string path)
        {
            lvwFiles.BeginUpdate();
            lvwFiles.Items.Clear();

            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                

                
                foreach (DirectoryInfo dirInfo in directoryInfos)
                {
                    ListViewItem item = lvwFiles.Items.Add(dirInfo.Name, IconsIndexes.Folder);
                    item.Tag = dirInfo.FullName;
                    item.SubItems.Add("文件夹");
                    item.SubItems.Add("");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            fileName = path;
            ShowPrivilege(fileName);
            tsslblFilesName.Text = fileName;
            tsslblText.Text = "只显示文件夹";
            lvwFiles.EndUpdate();
            
        }
        #endregion

        /// <summary>
        /// 权限管理
        /// </summary>
        
        #region 权限管理项
        private AuthorizationRule[] accessRulesArray = null;

        private List<string> privilegeList = new List<string> { "完全控制", "修改", "读取和执行", "列出文件夹内容", "读取", "写入" };

        private List<string> privilegeFlagsList = new List<string> { "FullControl", "Modify", "ReadAndExecute", "ListDirectory", "Read", "Write" };
        
        private List<FileSystemRights> fileSystemRightsList = new List<FileSystemRights> { FileSystemRights.FullControl, FileSystemRights.Modify,
        FileSystemRights.ReadAndExecute, FileSystemRights.ListDirectory, FileSystemRights.Read, FileSystemRights.Write };


        private bool isUpdateCheckBoxes = false;
        
        private int curSelected = 0;
        #endregion
        
        #region 初始化权限界面
        private void ShowPrivilege(string fileName)
        {
            AuthorizationRuleCollection tempAccessRulesCollection = null;
            
            //如果是文件夹
            if (Directory.Exists(fileName))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(fileName);
                tempAccessRulesCollection = dirInfo.GetAccessControl().GetAccessRules(true, true,
                                    typeof(SecurityIdentifier));
            }


            AuthorizationRule[] tempAccessRulesArray = new AuthorizationRule[tempAccessRulesCollection.Count];
            tempAccessRulesCollection.CopyTo(tempAccessRulesArray, 0);

            //去重
            accessRulesArray = UniqAccessRules(tempAccessRulesArray);


            lvwGroupOrUserName.Items.Clear();

            //显示组或用户名列表
            for (int i = 0; i < accessRulesArray.Length; i++)
            {
                ListViewItem item = lvwGroupOrUserName.Items.Add(accessRulesArray[i].IdentityReference.Translate(typeof(NTAccount)).ToString());
                item.Tag = i;
                item.ImageIndex = IconsIndexes.GroupOrUser;
            }

            //初始时默认当前选中的组或用户名为第一项
            lvwGroupOrUserName.HideSelection = false;
            lvwGroupOrUserName.Items[0].Selected = true;

            //显示当前选中的组或用户名对该文件/文件夹具有的权限列表
            ShowPrivilegeList();
        }
        #endregion
        
        #region 按照选中用户显示权限
        private void lvwGroupOrUserName_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (lvwGroupOrUserName.SelectedItems.Count > 0)
            {
                curSelected = (int)lvwGroupOrUserName.SelectedItems[0].Tag;
                ShowPrivilegeList();
            }
        }
        #endregion

        #region 显示当前选中的组或用户名对该文件夹具有的权限列表ShowPrivilegeList()
        private void ShowPrivilegeList()
        {
            isUpdateCheckBoxes = true;

            lvwPrivilege.Items.Clear();

            List<string> privileges = new List<string>((((FileSystemAccessRule)accessRulesArray[curSelected]).FileSystemRights + "").Split(','));
           
            for (int i = 0; i < privilegeList.Count; i++)
            {
                ListViewItem item = lvwPrivilege.Items.Add(privilegeList[i], IconsIndexes.Privilege);
                item.Tag = i;
            }


            for (int i = 0; i < privilegeList.Count; i++)
            {
                if (privileges.Contains(privilegeFlagsList[i]))
                {
                    SetPrivilegeListChecked(privilegeFlagsList[i]);
                }
            }
            
            isUpdateCheckBoxes = false;
        }
        #endregion
        
        #region 具体权限设置
        private void lvwPrivilege_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!isUpdateCheckBoxes)
            {
                if (e.Item.Checked)
                {
                    isUpdateCheckBoxes = true;

                    //设置权限列表中当前选中项和其“包含”的选项的选中状态
                    SetPrivilegeListChecked(privilegeFlagsList[(int)e.Item.Tag]);

                    isUpdateCheckBoxes = false;
                    
                    AddDirectorySecurity(fileName, accessRulesArray[curSelected].IdentityReference.Translate(typeof(NTAccount)).ToString(),
                        fileSystemRightsList[(int)e.Item.Tag], AccessControlType.Allow);
                }
                else
                {
                    isUpdateCheckBoxes = true;

                    SetPrivilegeListUnChecked(privilegeFlagsList[(int)e.Item.Tag]);

                    isUpdateCheckBoxes = false;
                    
                    RemoveDirectorySecurity(fileName, accessRulesArray[curSelected].IdentityReference.Translate(typeof(NTAccount)).ToString(),
                        fileSystemRightsList[(int)e.Item.Tag], AccessControlType.Allow);
                }
            }
        }
        #endregion
        
        #region 根据传入的权限显示权限列表的选中状态SetPrivlegeListChecked()
        private void SetPrivilegeListChecked(string privilege)
        {
            switch (privilege)
            {
                case "FullControl":

                    foreach (ListViewItem item in lvwPrivilege.Items)
                    {
                        item.Checked = true;
                    }

                    //如果是文件，则"列出文件夹内容"不选中
                    if (File.Exists(fileName))
                    {
                        lvwPrivilege.Items[3].Checked = false;
                    }

                    break;

                case "Modify":

                    foreach (ListViewItem item in lvwPrivilege.Items)
                    {
                        if (item.Text == "修改" || item.Text == "读取和执行" || item.Text == "读取" || item.Text == "写入")
                        {
                            item.Checked = true;
                        }
                    }

                    //如果是文件夹, 则再选中"列出文件夹内容"
                    if (Directory.Exists(fileName))
                    {
                        lvwPrivilege.Items[3].Checked = true;
                    }
                    break;

                case "ReadAndExecute":

                    foreach (ListViewItem item in lvwPrivilege.Items)
                    {
                        if (item.Text == "读取和执行" || item.Text == "读取")
                        {
                            item.Checked = true;
                        }
                    }

                    //如果是文件夹, 则再选中"列出文件夹内容"
                    if (Directory.Exists(fileName))
                    {
                        lvwPrivilege.Items[3].Checked = true;
                    }
                    break;

                case "ListDirectory":

                    foreach (ListViewItem item in lvwPrivilege.Items)
                    {
                        if (item.Text == "列出文件夹内容")
                        {
                            item.Checked = true;
                        }
                    }
                    break;

                case "Read":

                    foreach (ListViewItem item in lvwPrivilege.Items)
                    {
                        if (item.Text == "读取")
                        {
                            item.Checked = true;
                        }
                    }

                    //如果是文件夹, 则再选中"列出文件夹内容"
                    if (Directory.Exists(fileName))
                    {
                        lvwPrivilege.Items[3].Checked = true;
                    }

                    break;

                case "Write":

                    foreach (ListViewItem item in lvwPrivilege.Items)
                    {
                        if (item.Text == "写入")
                        {
                            item.Checked = true;
                        }
                    }
                    break;
            }
        }
        #endregion

        #region 根据传入的权限设置权限列表的未选中状态SetPrivilegeListUnChecked()
        private void SetPrivilegeListUnChecked(string privilege)
        {
            switch (privilege)
            {
                case "FullControl":

                    foreach (ListViewItem item in lvwPrivilege.Items)
                    {
                        item.Checked = false;
                    }
                    break;

                case "Modify":

                    foreach (ListViewItem item in lvwPrivilege.Items)
                    {
                        if (item.Text == "修改" || item.Text == "读取和执行" || item.Text == "读取" || item.Text == "写入")
                        {
                            item.Checked = false;
                        }
                    }
                    break;

                case "ReadAndExecute":

                    foreach (ListViewItem item in lvwPrivilege.Items)
                    {
                        if (item.Text == "读取和执行" || item.Text == "读取")
                        {
                            item.Checked = false;
                        }
                    }
                    break;

                case "ListDirectory":

                    foreach (ListViewItem item in lvwPrivilege.Items)
                    {
                        if (item.Text == "列出文件夹内容")
                        {
                            item.Checked = false;
                        }
                    }
                    break;

                case "Read":

                    foreach (ListViewItem item in lvwPrivilege.Items)
                    {
                        if (item.Text == "读取")
                        {
                            item.Checked = false;
                        }
                    }
                    break;

                case "Write":

                    foreach (ListViewItem item in lvwPrivilege.Items)
                    {
                        if (item.Text == "写入")
                        {
                            item.Checked = false;
                        }
                    }
                    break;
            }
        }
        #endregion

        #region 增减权限
        //为指定的账户给指定的目录添加ACL项
        private void AddDirectorySecurity(string dirName, string account, FileSystemRights rights,AccessControlType controlType)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            DirectorySecurity dirSecurity = dirInfo.GetAccessControl(AccessControlSections.All);
            dirSecurity.AddAccessRule(new FileSystemAccessRule(account, rights, controlType));
            dirInfo.SetAccessControl(dirSecurity);
        }


        //为指定的账户给指定的目录移除ACL项
        private void RemoveDirectorySecurity(string dirName, string account, FileSystemRights rights,AccessControlType controlType)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            DirectorySecurity dirSecurity = dirInfo.GetAccessControl();
            dirSecurity.RemoveAccessRule(new FileSystemAccessRule(account, rights, controlType));
            dirInfo.SetAccessControl(dirSecurity);
        }
        #endregion

        #region 去重
        private AuthorizationRule[] UniqAccessRules(AuthorizationRule[] accessRules)
        {
            string preAccount = "";
            string nextAccout;
            List<AuthorizationRule> authorizationRulesList = new List<AuthorizationRule>();

            for (int i = 0; i < accessRules.Length; i++)
            {
                nextAccout = accessRules[i].IdentityReference.Translate(typeof(NTAccount)).ToString();

                //没有发生重复
                if (nextAccout != preAccount)
                {
                    authorizationRulesList.Add(accessRules[i]);
                }

                preAccount = nextAccout;
            }

            return authorizationRulesList.ToArray();
        }
        #endregion

    }
}

