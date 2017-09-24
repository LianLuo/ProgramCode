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

        public InternalDbSession(IDbConnection conn)
        {
            this.m_DbConnection = conn;
        }

        private IDbCommand DBCommand { get; set; }

        public bool IsInTransaction { get; private set; }

        private void CheckDisposed()
        {
            if (this.m_Disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
        }

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
