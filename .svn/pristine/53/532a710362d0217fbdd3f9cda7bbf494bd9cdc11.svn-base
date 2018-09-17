using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

//using MonitorMain.ToolView;
using ICSharpCode.FormsDesigner.Gui;


namespace MonitorMain
{
    public partial class ToolWindow : UserControl
    {
        
        private ButtonItem _buttonItem = new ButtonItem();
        private ButtonItem _selectionbuttonItem = new ButtonItem();
        private string fileName;
        private ButtonItem chkmenuedit = new ButtonItem();
        private bool isEdit = false;
        private TextBoxItem menutext = new TextBoxItem();
        private string _type;

        public ToolWindow(string Type)
        {
            InitializeComponent();
            InitToolBox(Type);
            
            menutext.KeyDown += new KeyEventHandler(menutext_KeyDown);
        }

       

        

        #region 初始化菜单
        /// <summary>
        /// 初始化工具箱
        /// </summary>
        private void InitToolBox(string Type)
        {
            #region 添加ToolBox

            _type = Type;
            if (Type == "S")
            {
                //加载工具箱结构文档 
                fileName = Application.StartupPath + @"\CONFIG\SMenu.config";
            }
            else
            {
                //加载工具箱结构文档
                fileName = Application.StartupPath + @"\CONFIG\BMenu.config";
            }
            
            //通过文件加载菜单
            ToolboxBar.LoadDefinition(fileName);
            InitButtonItemEvent();
            #endregion
        }

        private void InitButtonItemEvent()
        {
            foreach (SideBarPanelItem paneitem in ToolboxBar.Panels)
            {
                foreach (ButtonItem buttonitem in paneitem.SubItems)
                {
                    buttonitem.MouseDown += new MouseEventHandler(buttonItem_MouseDown);
                    buttonitem.MouseMove += new MouseEventHandler(buttonItem_MouseMove);
                    buttonitem.DoubleClick += new EventHandler(_buttonItem_DoubleClick);
                    buttonitem.Click += new EventHandler(buttonitem_Click);
                    buttonitem.PopupClose +=new EventHandler(buttonitem_PopupClose);
                    if (buttonitem.Name.ToLower() == "menuedit")
                    {
                        buttonitem.SubItems[0].Click += new EventHandler(ToolWindow_Click);
                    }
                }

            }

        }

        #endregion
        

        #region 普通菜单操作

        void _buttonItem_DoubleClick(object sender, EventArgs e)
        {
            if (isEdit)
            {
                menutext.Text = ((ButtonItem)sender).Text;
                ((ButtonItem) sender).SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {menutext});
                menutext.TextBoxWidth = ((ButtonItem)sender).Size.Width;
                
            }
            else
            {
                if (_type == "S")
                {
                    FJMainForm.Instance.CreateNewDocument(menutext.Name = ((ButtonItem) sender).Name,
                                                          menutext.Text = ((ButtonItem) sender).Text,
                                                          menutext.Tag = ((ButtonItem) sender).Tag);
                }
                else
                {
                    BHMainForm.Instance.CreateNewDocument(menutext.Name = ((ButtonItem)sender).Name,
                                                          menutext.Text = ((ButtonItem)sender).Text,
                                                          menutext.Tag = ((ButtonItem)sender).Tag);
                }
            }
        }

        void buttonItem_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(_selectionbuttonItem.Name, DragDropEffects.Copy);
            }

        }


        void buttonItem_MouseDown(object sender, MouseEventArgs e)
        {
            _selectionbuttonItem = (ButtonItem)sender;
        }

        #endregion
             
              
        #region 系统菜单编辑操作

        void ToolWindow_Click(object sender, EventArgs e)
        {
            getSysCommand((ButtonItem)sender);
        }

        void menutext_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ((ButtonItem)menutext.Parent).Text = menutext.Text;
            }
        }


        void buttonitem_Click(object sender, EventArgs e)
        {
            if (((ButtonItem)sender).SubItems.Count > 0)
                ((ButtonItem)sender).Expanded = true;
        }
      
        private void getSysCommand(BaseItem menuitem)
        {
            switch (menuitem.Name.ToLower())
            {
                case "menueditstate":
                    //关闭编辑功能保存菜单
                    if (((ButtonItem)menuitem).Checked)
                    {
                        fileName = Application.StartupPath + @"\CONFIG\Menu.config";
                        ((ButtonItem)menuitem).Checked = !((ButtonItem)menuitem).Checked;
                        EditorMenu();
                        ToolboxBar.SaveDefinition(fileName);
                        ModifyDefinition();
                        AddButtonItemEvent();
                    }
                    //开启编辑功能改变菜单操作功能
                    else
                    {
                        EditorMenu();
                        FJMainForm.Instance.Message(menuitem, "菜单拖动功能已改为编辑菜单顺序！");
                        FJMainForm.Instance.SetLog("已转换成菜单编辑功能");
                        ((ButtonItem)menuitem).Checked = !((ButtonItem)menuitem).Checked;
                        RemoveButtonItemEvent();
                    }
                    isEdit = ((ButtonItem)menuitem).Checked;
                    break;

            }
        }

        void buttonitem_PopupClose(object sender, EventArgs e)
        {
            if (((ButtonItem)sender).SubItems.Count > 0)
            {
                if (((ButtonItem)sender).SubItems[0] is TextBoxItem)
                {
                    ((ButtonItem)sender).SubItems.Clear();

                }
            }
            this.Refresh();
        }

        private void AddButtonItemEvent()
        {
            foreach (SideBarPanelItem paneitem in ToolboxBar.Panels)
            {
                foreach (ButtonItem buttonitem in paneitem.SubItems)
                {
                    buttonitem.MouseDown += new MouseEventHandler(buttonItem_MouseDown);
                    buttonitem.MouseMove += new MouseEventHandler(buttonItem_MouseMove);
                }
            }
        }

        private void RemoveButtonItemEvent()
        {
            foreach (SideBarPanelItem paneitem in ToolboxBar.Panels)
            {
                foreach (ButtonItem buttonitem in paneitem.SubItems)
                {
                    buttonitem.MouseDown -= new MouseEventHandler(buttonItem_MouseDown);
                    buttonitem.MouseMove -= new MouseEventHandler(buttonItem_MouseMove);
                }
            }
        }

        private void EditorMenu()
        {
            ToolboxBar.AllowUserCustomize = !ToolboxBar.AllowUserCustomize;
        }

        //文件保存乱码的修改
        private void ModifyDefinition()
        {
            fileName = Application.StartupPath + @"\Config\Menu.config";
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNodeList nodes = doc.DocumentElement["items"].ChildNodes;
            foreach (XmlNode node in nodes)
            {
                node.Attributes["assembly"].InnerText = "DevComponents.DotNetBar2, PublicKeyToken=e116d99a00eca71b";
                if (node.FirstChild.Name == "subitems")
                {
                    foreach (XmlNode subnode in node.FirstChild.ChildNodes)
                    {
                        subnode.Attributes["assembly"].InnerText =
                            "DevComponents.DotNetBar2, PublicKeyToken=e116d99a00eca71b";

                        if (subnode.FirstChild.Name == "subitems")
                        {
                            foreach (XmlNode subsubnode in subnode.FirstChild.ChildNodes)
                            {
                                subsubnode.Attributes["assembly"].InnerText =
                            "DevComponents.DotNetBar2, PublicKeyToken=e116d99a00eca71b";
                            }
                        }
                    }
                }

            }
            doc.Save(fileName);

        }

#endregion
    }
}