// -----------------------------------------------------------------------
// <copyright file="Setting.cs"
//     project="BusinessLogic"
//     solution="PurchaseSalesInventory"
//     company="武汉科尔创新软件技术有限公司">
//     Copyright (c) KEERTECH. All rights reserved.
// </copyright>
// <author>TuB</author>
// <created>2012-02-24</created>
// <summary></summary>
// -----------------------------------------------------------------------

using System;
using Csla;
using MySql.Data.MySqlClient;

namespace BusinessLogic.Print
{
    /// <summary>
    /// 表示系统设置的类
    /// </summary>
    [Serializable]
    public class PrintSetting : BusinessBase<PrintSetting>
    {
        #region  Business Methods

        private static PropertyInfo<string> IdProperty = RegisterProperty<string>(r => r.Id, "标识号");
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }

        private static PropertyInfo<string> PrintLableProperty = RegisterProperty<string>(r => r.PrintLable, "标签内容");
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string PrintLable
        {
            get { return GetProperty(PrintLableProperty); }
            set { SetProperty(PrintLableProperty, value); }
        }

        private static PropertyInfo<string> PrintTextProperty = RegisterProperty<string>(r => r.PrintText, "打印内容");
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string PrintText
        {
            get { return GetProperty(PrintTextProperty); }
            set { SetProperty(PrintTextProperty, value); }
        }

        private static PropertyInfo<int> XProperty = RegisterProperty<int>(r => r.X, "X轴");
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public int X
        {
            get { return GetProperty(XProperty); }
            set { SetProperty(XProperty, value); }
        }

        private static PropertyInfo<int> YProperty = RegisterProperty<int>(r => r.Y, "Y轴");
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public int Y
        {
            get { return GetProperty(YProperty); }
            set { SetProperty(YProperty, value); }
        }

        private static PropertyInfo<string> FontProperty = RegisterProperty<string>(r => r.Font, "字体");
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Font
        {
            get { return GetProperty(FontProperty); }
            set { SetProperty(FontProperty, value); }
        }

        private static PropertyInfo<float> FontSizeProperty = RegisterProperty<float>(r => r.FontSize, "字号");
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public float FontSize
        {
            get { return GetProperty(FontSizeProperty); }
            set { SetProperty(FontSizeProperty, value); }
        }

        #endregion

        #region  Validation Rules

        /// <summary>
        /// Adds the business rules.
        /// </summary>
        protected override void AddBusinessRules()
        {
            //ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, NameProperty);
            //ValidationRules.AddRule(Csla.Validation.CommonRules.StringMaxLength,
            //                        new Csla.Validation.CommonRules.MaxLengthRuleArgs(NameProperty, 255));

            //ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, ValueProperty);
            //ValidationRules.AddRule(Csla.Validation.CommonRules.StringMaxLength,
            //                        new Csla.Validation.CommonRules.MaxLengthRuleArgs(ValueProperty, 255));

            //ValidationRules.AddRule(Csla.Validation.CommonRules.StringMaxLength,
            //                new Csla.Validation.CommonRules.MaxLengthRuleArgs(DescriptionProperty, 255));
        }

        #endregion

        #region  Authorization Rules

        /// <summary>
        /// Adds the authorization rules.
        /// </summary>
        protected override void AddAuthorizationRules()
        {
            // add AuthorizationRules here
        }

        /// <summary>
        /// Adds the object authorization rules.
        /// </summary>
        protected static void AddObjectAuthorizationRules()
        {
            // add object-level authorization rules here
        }

        #endregion

        #region  Factory Methods

        internal static PrintSetting NewSetting()
        {
            return DataPortal.CreateChild<PrintSetting>();
        }

        internal static PrintSetting GetSetting(Csla.Data.SafeDataReader dataReader)
        {
            return DataPortal.FetchChild<PrintSetting>(dataReader);
        }

        private PrintSetting()
        {
            /* require use of factory methods */
        }

        #endregion

        #region  Data Access

        private void Child_Fetch(Csla.Data.SafeDataReader dataReader)
        {
            using (BypassPropertyChecks)
            {
                Id = dataReader.GetString("Id");
                PrintLable = dataReader.GetString("PrintLable");
                PrintText = dataReader.GetString("PrintText");
                X = dataReader.GetInt32("x");
                Y = dataReader.GetInt32("y");
                Font = dataReader.GetString("Font");
                FontSize = dataReader.GetFloat("FontSize");
            }
        }

        private void Child_Insert(MySqlConnection cn)
        {
            using (BypassPropertyChecks)
            {
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "insert into t_printsetting (id, PrintLable, PrintText,x,y,font) values (@id, @PrintLable, @PrintText,@x,@y,@font);";
                    //cm.Parameters.AddWithValue("@id", GetProperty(IdProperty));
                    cm.Parameters.AddWithValue("@PrintLable", GetProperty(PrintLableProperty));
                    cm.Parameters.AddWithValue("@PrintText", GetProperty(PrintTextProperty));
                    cm.Parameters.AddWithValue("@x", GetProperty(XProperty));
                    cm.Parameters.AddWithValue("@y", GetProperty(YProperty));
                    cm.Parameters.AddWithValue("@font", GetProperty(FontProperty));
                    cm.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    cm.ExecuteNonQuery();
                }
            }
        }

        private void Child_Update(MySqlConnection cn)
        {
            using (BypassPropertyChecks)
            {
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "update t_printsetting set PrintLable = @PrintLable, PrintText = @PrintText ,x = @x,y = @y,font = @font where id = @id";
                    cm.Parameters.AddWithValue("@id", GetProperty(IdProperty));
                    cm.Parameters.AddWithValue("@PrintLable", GetProperty(PrintLableProperty));
                    cm.Parameters.AddWithValue("@PrintText", GetProperty(PrintTextProperty));
                    cm.Parameters.AddWithValue("@x", GetProperty(XProperty));
                    cm.Parameters.AddWithValue("@y", GetProperty(YProperty));
                    cm.Parameters.AddWithValue("@font", GetProperty(FontProperty));
                    
                    cm.ExecuteNonQuery();
                }
            }
        }

        private void Child_DeleteSelf(MySqlConnection cn)
        {
            using (var cm = cn.CreateCommand())
            {
                cm.CommandText = "delete from [t_printsetting] where [id] = @id";
                cm.Parameters.AddWithValue("@id", Id);
                cm.ExecuteNonQuery();
            }
        }

        #endregion

        
    }
}