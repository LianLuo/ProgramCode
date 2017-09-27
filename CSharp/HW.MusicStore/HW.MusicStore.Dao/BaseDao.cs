using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
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

        protected virtual Hashtable GetHashByEntity(T entity)
        {
            Hashtable hashtable = new Hashtable();
            PropertyInfo[] propertyInfos = entity.GetType().GetProperties();
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                object obj = propertyInfos[i].GetValue(entity, null);
                obj = obj ?? DBNull.Value;
                if (!hashtable.ContainsKey(propertyInfos[i].Name))
                {
                    hashtable.Add(propertyInfos[i].Name, obj);
                }
            }
            return hashtable;
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

        private IEnumerable<T> GetList(string sql, IDbDataParameter[] parameters)
        {
            T item = default(T);
            List<T> list = new List<T>();
            InternalDbSession session = DataFactory.CreateDatabase();
            using (IDataReader reader = session.ExecuteReader(sql, parameters))
            {
                while (reader.Read())
                {
                    item = this.DataReaderToEntity(reader);
                    list.Add(item);
                }
            }
            return list;
        }

        public bool Insert(T entity)
        {
            return this.Insert(entity, null);
        }

        public bool Insert(T entity, DbTransaction transaction)
        {
            if (entity == null)
            {
                return false;
            }
            Hashtable hashtable = this.GetHashByEntity(entity);
            return Insert(hashtable, transaction);
        }

        public bool Insert(Hashtable recordField, IDbTransaction transaction)
        {
            return Insert(recordField, tableName, transaction);
        }

        public bool Insert(Hashtable recordField, string targetTable, IDbTransaction transaction)
        {
            bool flag = false;
            if (recordField != null && recordField.Count >= 1)
            {
                IDbDataParameter[] values = DataFactory.GetParameters(recordField.Count);
                string fields = string.Empty;
                string vals = string.Empty;
                IEnumerator enumerator = recordField.Keys.GetEnumerator();
                for (int i = 0; enumerator.MoveNext(); i++)
                {
                    string currentKey = enumerator.Current.ToString();
                    fields += string.Format("[{0}],", currentKey);
                    vals += string.Format("@{0}", currentKey);
                    object obj = recordField[currentKey] ?? DBNull.Value;
                    if ((obj is DateTime) && (Convert.ToDateTime(obj) <= Convert.ToDateTime("1753-1-1")))
                    {
                        obj = DBNull.Value;
                    }
                    values[i] = DataFactory.GetParameter(string.Format("@{0}", currentKey), obj);
                }

                fields = fields.Trim(new char[] {','});
                vals = vals.Trim(new char[] {','});
                string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", targetTable, fields, vals);
                InternalDbSession session = DataFactory.CreateDatabase();
                flag = session.ExecuteNonQuery(sql, values) > 0;
            }
            return flag;
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
            string condition = string.Format("{0}=@ID", this.primaryKey);
            SQLiteParameter parameter = new SQLiteParameter("@ID", key);
            return this.DeleteByCondition(condition, null, new SQLiteParameter[] {parameter});
        }

        public bool DeleteByKey(string key, DbTransaction transaction)
        {
            string condition = string.Format("{0}={1}", this.primaryKey, key);
            return this.DeleteByCondition(condition, transaction);
        }

        public bool Update(T entity, string primaryKey)
        {
            return Update(entity, primaryKey, null);
        }

        public bool Update(CommandType commandType, string sql)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity, string primaryKey, DbTransaction transaction)
        {
            if (entity == null)
            {
                return false;
            }
            Hashtable hashtable = GetHashByEntity(entity);
            return Update(hashtable, transaction);
        }

        public bool Update(Hashtable recordFields, IDbTransaction transaction)
        {
            bool flag = false;
            if (recordFields != null && recordFields.Count >= 1)
            {
                string fields = string.Empty;
                string vals = string.Empty;
                IDbDataParameter[] values = DataFactory.GetParameters(recordFields.Count);
                IEnumerator enumerator = recordFields.Keys.GetEnumerator();
                for (int i = 0; enumerator.MoveNext(); i++)
                {
                    string current = enumerator.Current.ToString();
                    fields += string.Format("[{0}]=@{0},", current);
                    object obj = recordFields[current] ?? DBNull.Value;
                    values[i] = DataFactory.GetParameter(string.Format("@{0}", current), obj);
                }
                string sql = string.Format("UPDATE {0} SET {1} WHERE {2} = @ID", tableName,
                    fields.Trim(new char[] {','}), primaryKey);
                InternalDbSession session = DataFactory.CreateDatabase();
                flag = session.ExecuteNonQuery(sql, values) > 0;
            }
            return flag;
        }

        public bool Update(CommandType commandType, string sql, DbTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(string condition)
        {
            string sql = string.Format("SELECT {0} FROM {1} WHERE {2} ORDER BY {3} {4}", this.selectedFields,
                this.tableName, condition, this.sortField, this.isDescending ? "DESC" : "ASC");

            return this.GetList(sql, null);
        }

        public IEnumerable<T> Find(string condition, IDbDataParameter[] parameters)
        {
            string sql = string.Format("SELECT {0} FROM {1} WHERE {2} ORDER BY {3} {4}", this.selectedFields,
                this.tableName, condition, this.sortField, this.isDescending ? "DESC" : "AES");
            return this.GetList(sql, parameters);
        }

        public T FindById(int key)
        {
            return this.FindById(key.ToString());
        }

        public T FindById(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return default(T);
            }
            string query = string.Format("SELECT {0} FROM {1} WHERE {2} = @ID", this.selectedFields, this.tableName,
                this.primaryKey);
            IDbDataParameter parameter = new SQLiteParameter("@ID", key);
            InternalDbSession session = DataFactory.CreateDatabase();
            T local = default(T);
            using (IDataReader reader = session.ExecuteReader(query, new IDbDataParameter[] {parameter}))
            {
                if (reader.Read())
                {
                    local = this.DataReaderToEntity(reader);
                }
            }
            return local;
        }

        public IEnumerable<T> FindByIds(string ids)
        {
            string condition = string.Format("{0} in ({1})", this.primaryKey, ids);
            return Find(condition);
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
            T local = default(T);
            IEnumerable<T> list = this.Find(condition);
            if (list.Any())
            {
                local = list.FirstOrDefault();
            }
            return local;
        }

        public T FindSingle(string condition, IDbDataParameter[] parameters)
        {
            T local = default(T);
            IEnumerable<T> list = this.Find(condition, parameters);
            if (list.Any())
            {
                local = list.FirstOrDefault();
            }
            return local;
        }

        public IEnumerable<T> FindAll()
        {
            string sql = string.Format("SELECT {0} FROM {1} ORDER BY {2} {3}", this.selectedFields, this.tableName,
                this.sortField, this.isDescending ? "DESC" : "AES");
            return this.GetList(sql, null);
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
