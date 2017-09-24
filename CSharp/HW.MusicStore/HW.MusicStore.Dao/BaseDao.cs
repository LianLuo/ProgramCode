using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HW.MusicStore.IDao;
using HW.MusicStore.Models;

namespace HW.MusicStore.Dao
{
    public class BaseDao<T>:IBaseDao<T> where T:BaseEntity,new()
    {
        #region Fields
        private bool isDescending;
        protected string primaryKey;
        protected string selectedFields;
        protected string sortField;
        protected string tableName;
        #endregion

        #region Properties

        public bool IsDescending
        {
            get { return this.isDescending; }
            set { isDescending = value; }
        }

        public string PrimaryKey
        {
            get { return primaryKey; }
        }

        protected string SelectedFields
        {
            get { return selectedFields; }
            set { selectedFields = value; }
        }

        public string SortField
        {
            get { return sortField; }
            set { sortField = value; }
        }

        public string TableName
        {
            get { return tableName; }
        }

        #endregion

        #region constructor

        public BaseDao()
        {
            this.sortField = "ID";
            this.selectedFields = "*";
            this.isDescending = true;
        }

        public BaseDao(string tableName, string primaryKey)
        {
            this.sortField = "ID";
            this.selectedFields = "*";
            this.isDescending = true;
            this.tableName = tableName;
            this.primaryKey = primaryKey;
        }
        #endregion

        protected virtual T DataReaderToEntity(IDataReader reader)
        {
            T local = Activator.CreateInstance<T>();

            PropertyInfo[] propertyInfos = local.GetType().GetProperties();

            foreach (PropertyInfo info in propertyInfos)
            {
                try
                {
                    if (reader[info.Name].ToString() != "")
                    {
                        info.SetValue(local,reader[info.Name]??"",null);
                    }
                }
                catch { }
            }

            return local;
        }

        protected virtual Hashtable GetHashEntity(T entity)
        {
            Hashtable hashtable = new Hashtable();
            PropertyInfo[] propertyInfos = entity.GetType().GetProperties();
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                object obj = propertyInfos[i].GetValue(entity, null);
                obj = obj ?? DBNull.Value;
                if (!hashtable.ContainsKey(propertyInfos[i].Name))
                {
                    hashtable.Add(propertyInfos[i].Name,obj);
                }
            }
            return hashtable;
        }

        public bool Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(T entity, DbTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByCondition(string condition)
        {
            return this.DeleteByCondition(condition, null);
        }

        public bool DeleteByCondition(string condition, DbTransaction transaction)
        {
            return this.DeleteByCondition(condition, transaction, null);
        }

        public bool DeleteByCondition(string condition, DbTransaction transaction, IDbDataParameter[] parameters)
        {
            string query = string.Format("DELETE FROM {0} WHERE {1}",this.tableName,condition);

            InternalDbSession session = DataFactory.CreateDatabase();
            int result = session.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool DeleteByKey(string key)
        {
            throw new NotImplementedException();
        }

        public bool DeleteByKey(string key, DbTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity, string primaryKey)
        {
            throw new NotImplementedException();
        }

        public bool Update(CommandType commandType, string sql)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity, string primaryKey, DbTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public bool Update(CommandType commandType, string sql, DbTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(string condition)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(string condition, IDbDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public T FindById(int key)
        {
            throw new NotImplementedException();
        }

        public T FindById(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindByIds(string ids)
        {
            throw new NotImplementedException();
        }

        public T FindLast()
        {
            throw new NotImplementedException();
        }

        public T FindFirst()
        {
            throw new NotImplementedException();
        }

        public T FindSingle(string condition)
        {
            throw new NotImplementedException();
        }

        public T FindSingle(string condition, IDbDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public int GetMaxId()
        {
            throw new NotImplementedException();
        }

        public int GetRecordCount()
        {
            throw new NotImplementedException();
        }

        public int GetRecordCount(string condition)
        {
            throw new NotImplementedException();
        }
    }
}
