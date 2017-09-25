using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.MusicStore.Dao
{
    public class InternalDbSession : IDisposable
    {
        private readonly IDbConnection m_DbConnection;
        private IDbTransaction m_DbTransaction;
        private bool m_Disposed;

        /// <summary>
        /// 初始化InternalDbSession
        /// </summary>
        /// <param name="conn"></param>
        public InternalDbSession(IDbConnection conn)
        {
            this.m_DbConnection = conn;
        }

        private IDbCommand DBCommand { get; set; }

        /// <summary>
        /// 是否开启事务
        /// </summary>
        public bool IsInTransaction { get; private set; }

        /// <summary>
        /// 检查对象是否已经释放
        /// </summary>
        private void CheckDisposed()
        {
            if (this.m_Disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }

        /// <summary>
        /// 激活连接
        /// </summary>
        private void Activate()
        {
            this.CheckDisposed();

            if (this.m_DbConnection.State == ConnectionState.Broken)
            {
                this.m_DbConnection.Close();
            }
            if (this.m_DbConnection.State == ConnectionState.Closed)
            {
                this.m_DbConnection.Open();
            }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Complete()
        {
            if (this.IsInTransaction)
            {
                if (m_DbConnection.State == ConnectionState.Open)
                {
                    m_DbConnection.Close();
                }
            }
        }

        /// <summary>
        /// 开启事务
        /// </summary>
        public void BeginTransaction()
        {
            this.Activate();
            this.m_DbTransaction = m_DbConnection.BeginTransaction();
            this.IsInTransaction = true;
        }

        public void BeginTransaction(IsolationLevel il)
        {
            this.Activate();
            this.m_DbTransaction = m_DbConnection.BeginTransaction(il);
            this.IsInTransaction = true;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void CommitTransaction()
        {
            if (!this.IsInTransaction)
            {
                throw new Exception("Current session does not open transaction.");
            }

            this.m_DbTransaction.Commit();
            this.m_DbTransaction.Dispose();
            this.IsInTransaction = false;
            this.Complete();
        }
        /// <summary>
        /// 事务回滚
        /// </summary>
        public void RollbackTransaction()
        {
            if (!this.IsInTransaction)
            {
                throw new Exception("Current session does not open transaction.");
            }
            this.m_DbTransaction.Rollback();
            this.m_DbTransaction.Dispose();
            this.IsInTransaction = false;
            this.Complete();
        }
        /// <summary>
        /// 快速读取数据
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(string cmdText, IDbDataParameter[] parameters)
        {
            return this.ExecuteReader(cmdText, parameters, CommandBehavior.Default, CommandType.Text);
        }

        public IDataReader ExecuteReader(string cmdText, IDbDataParameter[] parameters, CommandType cmdType)
        {
            return this.ExecuteReader(cmdText, parameters, CommandBehavior.Default, cmdType);
        }

        public IDataReader ExecuteReader(string cmdText, IDbDataParameter[] parameters, CommandBehavior behavior)
        {
            return this.ExecuteReader(cmdText, parameters, behavior, CommandType.Text);
        }

        public IDataReader ExecuteReader(string cmdText, IDbDataParameter[] parameters, CommandBehavior behavior,
            CommandType cmdType)
        {
            this.CheckDisposed();
#if DEBUG
            
#endif
            IDbCommand cmd = this.DBCommand;
            this.PrepareCommand(cmd,cmdText,parameters,cmdType);
            this.Activate();
            IDataReader reader = cmd.ExecuteReader(behavior);
            cmd.Parameters.Clear();
            return reader;
        }

        /// <summary>
        /// 受影响行数
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdText, IDbDataParameter[] parameters)
        {
            return this.ExecuteNonQuery(cmdText, parameters, CommandType.Text);
        }

        public int ExecuteNonQuery(string cmdText, IDbDataParameter[] parameters, CommandType cmdType)
        {
            this.CheckDisposed();
#if DEBUG
            System.Diagnostics.Debug.WriteLine("");
#endif
            try
            {
                IDbCommand cmd = this.DBCommand;
                this.PrepareCommand(cmd, cmdText, parameters, cmdType);
                this.Activate();
                int result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return result;
            }
            finally
            {
                this.Complete();
            }
        }

        /// <summary>
        /// 返回查询的单行单列
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object ExecuteScalar(string cmdText, IDbDataParameter[] parameters)
        {
            return this.ExecuteScalar(cmdText, parameters,CommandType.Text);
        }

        public object ExecuteScalar(string cmdText, IDbDataParameter[] parameters,CommandType cmdType)
        {
            this.CheckDisposed();
#if DEBUG
         System.Diagnostics.Debug.WriteLine("");
#endif
            try
            {
                IDbCommand cmd = this.DBCommand;
                this.PrepareCommand(cmd, cmdText, parameters, cmdType);
                this.Activate();
                object result = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return result;
            }
            finally
            {
                this.Complete();
            }
        }

        /// <summary>
        /// 准备数据
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="parameters">参数集</param>
        /// <param name="commandType">操作类型</param>
        private void PrepareCommand(IDbCommand cmd, string cmdText, IDbDataParameter[] parameters, CommandType commandType)
        {
            cmd.CommandText = cmdText;
            cmd.CommandType = commandType;
            if (this.IsInTransaction)
            {
                cmd.Transaction = this.m_DbTransaction;
            }
            if (parameters != null)
            {
                foreach (IDbDataParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        public void Dispose()
        {
            if (this.m_Disposed)
            {
                return;
            }
            if (this.m_DbTransaction != null)
            {
                if (this.IsInTransaction)
                {
                    try
                    {
                        this.m_DbTransaction.Rollback();
                    }
                    catch { }
                }

                this.m_DbTransaction.Dispose();
                this.m_DbTransaction = null;
                this.IsInTransaction = false;
            }
            if (this.DBCommand != null)
            {
                this.DBCommand.Dispose();
                this.DBCommand = null;
            }

            if (this.m_DbConnection != null)
            {
                this.m_DbConnection.Dispose();
            }
            this.m_Disposed = true;
        }
    }
}
