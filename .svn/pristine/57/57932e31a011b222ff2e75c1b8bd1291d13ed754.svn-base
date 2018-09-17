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

namespace BusinessLogic.Configuration
{
    /// <summary>
    /// 表示系统设置的类
    /// </summary>
    [Serializable]
    public class Setting : BusinessBase<Setting>
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

        private static PropertyInfo<string> NameProperty = RegisterProperty<string>(r => r.Name, "名称");
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }

        private static PropertyInfo<string> ValueProperty = RegisterProperty<string>(r => r.Value, "值");
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value
        {
            get { return GetProperty(ValueProperty); }
            set { SetProperty(ValueProperty, value); }
        }

        private static PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(r => r.Description, "描述");
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description
        {
            get { return GetProperty(DescriptionProperty); }
            set { SetProperty(DescriptionProperty, value); }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        public override string ToString()
        {
            return Name;
        }

        #endregion

        #region  Validation Rules

        /// <summary>
        /// Adds the business rules.
        /// </summary>
        protected override void AddBusinessRules()
        {
            
        }

        #endregion

        #region  Authorization Rules

        /// <summary>
        /// Adds the authorization rules.
        /// </summary>
        protected void AddAuthorizationRules()
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

        
        internal static Setting NewSetting()
        {
            return DataPortal.CreateChild<Setting>();
        }

        internal static Setting GetSetting(Csla.Data.SafeDataReader dataReader)
        {
            return DataPortal.FetchChild<Setting>(dataReader);
        }

        private Setting()
        {
            /* require use of factory methods */
        }

        #endregion

        #region  Data Access

        private void Child_Fetch(Csla.Data.SafeDataReader dataReader)
        {
            using (BypassPropertyChecks)
            {
                Id = dataReader.GetString("ID");
                Name = dataReader.GetString("Name");
                Value = dataReader.GetString("Value");
                Description = dataReader.GetString("Description");
            }
        }

        private void Child_Insert(MySqlConnection cn)
        {
            using (BypassPropertyChecks)
            {
                using (var cm = cn.CreateCommand())
                {
                    cm.CommandText =
                        "insert into t_Setting (id,Name, Value, Description) values (@name, @value, @description);Select last_insert_rowid();";
                    cm.Parameters.AddWithValue("@id", Guid.NewGuid().ToString());
                    cm.Parameters.AddWithValue("@name", GetProperty(NameProperty));
                    cm.Parameters.AddWithValue("@value", GetProperty(ValueProperty));
                    cm.Parameters.AddWithValue("@description", GetProperty(DescriptionProperty));
                    Id = cm.ExecuteScalar().ToString();
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
                        "update t_Setting set Name = @name, Value = @value, Description = @description where id = @Id";
                    cm.Parameters.AddWithValue("@name", Name);
                    cm.Parameters.AddWithValue("@value", Value);
                    cm.Parameters.AddWithValue("@description", Description);
                    cm.Parameters.AddWithValue("@Id", Id);
                    cm.ExecuteNonQuery();
                }
            }
        }

        private void Child_DeleteSelf(MySqlConnection cn)
        {
            using (var cm = cn.CreateCommand())
            {
                cm.CommandText = "delete from t_Setting where Id = @Id";
                cm.Parameters.AddWithValue("@Id", Id);
                cm.ExecuteNonQuery();
            }
        }

        #endregion

        
    }
}