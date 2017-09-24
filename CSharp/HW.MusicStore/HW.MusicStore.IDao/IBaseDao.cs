using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW.MusicStore.Models;

namespace HW.MusicStore.IDao
{
    public interface IBaseDao<T> where T:BaseEntity
    {
        /// <summary>
        /// 向数据库插入一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Insert(T entity);

        /// <summary>
        /// 使用事务的方式向数据库插入一条数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool Insert(T entity, DbTransaction transaction);

        /// <summary>
        /// 通过条件删除数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        bool DeleteByCondition(string condition);

        /// <summary>
        /// 使用事务的方式通过条件删除数据
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool DeleteByCondition(string condition, DbTransaction transaction);

        /// <summary>
        /// 采用事务方式，通过条件传入参数，删除数据
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="transaction"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        bool DeleteByCondition(string condition, DbTransaction transaction, IDbDataParameter[] parameters);

        /// <summary>
        /// 通过指定关键字删除数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool DeleteByKey(string key);

        /// <summary>
        /// 采用事务方式删除指定关键字数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool DeleteByKey(string key, DbTransaction transaction);

        /// <summary>
        /// 针对某条数据进行更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        bool Update(T entity, string primaryKey);

        /// <summary>
        /// 采用SQL语句进行更新
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        bool Update(CommandType commandType, string sql);

        /// <summary>
        /// 采用事务方式进行更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="primaryKey"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool Update(T entity, string primaryKey, DbTransaction transaction);

        /// <summary>
        /// 采用事务方式用SQL语句进行更新
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="sql"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool Update(CommandType commandType, string sql, DbTransaction transaction);

        /// <summary>
        /// 通过条件进行查找数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        IEnumerable<T> Find(string condition);

        /// <summary>
        /// 采用条件和参数的方式进行查询数据
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<T> Find(string condition, IDbDataParameter[] parameters);

        /// <summary>
        /// 查找指定的Key的数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T FindById(int key);

        /// <summary>
        /// 查找指定的Key的数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T FindById(string key);

        /// <summary>
        /// 通过多个主键查询数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        IEnumerable<T> FindByIds(string ids);

        /// <summary>
        /// 查找最后一条数据
        /// </summary>
        /// <returns></returns>
        T FindLast();

        /// <summary>
        /// 查找第一条数据
        /// </summary>
        /// <returns></returns>
        T FindFirst();

        /// <summary>
        /// 通过条件查询单条数据
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        T FindSingle(string condition);

        /// <summary>
        /// 通过条件和参数查询单个数据
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        T FindSingle(string condition, IDbDataParameter[] parameters);

        /// <summary>
        /// 查找所有数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// 获取最大ID
        /// </summary>
        /// <returns></returns>
        int GetMaxId();

        /// <summary>
        /// 获取记录条数
        /// </summary>
        /// <returns></returns>
        int GetRecordCount();

        /// <summary>
        /// 通过条件查询满足条件的数据条数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        int GetRecordCount(string condition);
    }
}
