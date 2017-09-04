using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;

namespace QuartzScheduler.Learn.Dao
{
    public static class SchedulerManager
    {
        private static ISchedulerFactory factory = null;
        private static IScheduler scheduler = null;

        static SchedulerManager()
        {
            factory = new StdSchedulerFactory();
            scheduler = factory.GetScheduler();
            scheduler.Start();
        }

        /// <summary>
        /// 添加Job，并且以周期的形式运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobName"></param>
        /// <param name="cronTime"></param>
        /// <param name="jobData"></param>
        /// <returns></returns>
        public static DateTimeOffset AddJob<T>(string jobName, string cronTime, string jobData) where T : IJob
        {
            IJobDetail jobDetail = JobBuilder.Create<T>().WithIdentity(jobName, jobName + "_Group").UsingJobData("jobData", jobData).Build();
            ICronTrigger cronTrigger = new CronTriggerImpl(jobName + "_CronTrigger", jobName + "_TriggerGroup", cronTime);
            return scheduler.ScheduleJob(jobDetail, cronTrigger);
        }

        /// <summary>
        /// 添加Job，并且以周期的形式运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobName"></param>
        /// <param name="cronTime"></param>
        /// <returns></returns>
        public static DateTimeOffset AddJob<T>(string jobName, string cronTime) where T : IJob
        {
            return AddJob<T>(jobName, cronTime, null);
        }

        /// <summary>
        /// 添加Job，并且以周期的形式运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobName"></param>
        /// <param name="simpleTime">毫秒</param>
        /// <returns></returns>
        public static DateTimeOffset AddJob<T>(string jobName, int simpleTime) where T : IJob
        {
            return AddJob<T>(jobName, DateTime.UtcNow.AddMilliseconds(1), TimeSpan.FromMilliseconds(simpleTime));
        }

        /// <summary>
        /// 添加Job，并且以周期的形式运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobName"></param>
        /// <param name="startTime"></param>
        /// <param name="simpleTime">毫秒</param>
        /// <returns></returns>
        public static DateTimeOffset AddJob<T>(string jobName, DateTimeOffset startTime, int simpleTime) where T : IJob
        {
            return AddJob<T>(jobName, startTime, TimeSpan.FromMilliseconds(simpleTime));
        }

        /// <summary>
        /// 添加Job，并且以周期的形式运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobName"></param>
        /// <param name="startTime"></param>
        /// <param name="simpleTime"></param>
        /// <returns></returns>
        public static DateTimeOffset AddJob<T>(string jobName, DateTimeOffset startTime, TimeSpan simpleTime) where T : IJob
        {
            return AddJob<T>(jobName, startTime, simpleTime, new Dictionary<string, object>());
        }

        /// <summary>
        /// 添加Job，并且以周期的形式运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobName"></param>
        /// <param name="startTime"></param>
        /// <param name="simple">毫秒</param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset AddJob<T>(string jobName, DateTimeOffset startTime, int simple, string key, object value) where T : IJob
        {
            Dictionary<string, object> map = new Dictionary<string, object>();
            map.Add(key, value);
            return AddJob<T>(jobName, startTime, TimeSpan.FromMilliseconds(simple), map);
        }

        /// <summary>
        /// 添加Job，并且以周期的形式运行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jobName"></param>
        /// <param name="startTime"></param>
        /// <param name="simple"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public static DateTimeOffset AddJob<T>(string jobName, DateTimeOffset startTime, TimeSpan simple, Dictionary<string, object> map) where T : IJob
        {
            IJobDetail jobDetail = JobBuilder.Create<T>().WithIdentity(jobName, jobName + "_Group").Build();
            jobDetail.JobDataMap.PutAll(map);
            ISimpleTrigger trigger = new SimpleTriggerImpl(jobName + "_SimpleTrigger", jobName + "_TriggerGroup", startTime, null, SimpleTriggerImpl.RepeatIndefinitely, simple);
            return scheduler.ScheduleJob(jobDetail, trigger);
        }

        /// <summary>
        /// 修改触发器时间，需要Job名，以及修改结果
        /// </summary>
        /// <param name="jobName"></param>
        /// <param name="cronTime"></param>
        public static void UpdateTime(string jobName, string cronTime)
        {
            TriggerKey key = new TriggerKey(jobName + "_CronTrigger", jobName + "_TriggerGroup");
            CronTriggerImpl cronTrigger = scheduler.GetTrigger(key) as CronTriggerImpl;
            cronTrigger.CronExpression = new CronExpression(cronTime);
            scheduler.RescheduleJob(key, cronTrigger);
        }

        /// <summary>
        /// 修改触发器时间，需要Job名，以及修改结果
        /// </summary>
        /// <param name="jobName"></param>
        /// <param name="simpleTime"></param>
        public static void UpdateTime(string jobName, int simpleTime)
        {
            UpdateTime(jobName,TimeSpan.FromMinutes(simpleTime));
        }

        /// <summary>
        /// 修改触发器时间，需要Job名以及修改结果。
        /// </summary>
        /// <param name="jobName"></param>
        /// <param name="simpleTime"></param>
        public static void UpdateTime(string jobName, TimeSpan simpleTime)
        {
            TriggerKey key = new TriggerKey(jobName + "_SimpleTrigger", jobName + "_TriggerGroup");
            SimpleTriggerImpl trigger = scheduler.GetTrigger(key) as SimpleTriggerImpl;
            trigger.RepeatInterval = simpleTime;
            scheduler.RescheduleJob(key, trigger);
        }

        /// <summary>
        /// 暂停所有的Job
        /// </summary>
        public static void PauseAll()
        {
            scheduler.PauseAll();
        }

        /// <summary>
        /// 暂停某个Job
        /// </summary>
        /// <param name="jobName"></param>
        public static void PauseOne(string jobName)
        {
            JobKey key = new JobKey(jobName, jobName + "_Group");
            scheduler.PauseJob(key);
        }

        /// <summary>
        /// 恢复所有Job
        /// </summary>
        public static void ResumeAll()
        {
            scheduler.ResumeAll();
        }

        /// <summary>
        /// 删除Job
        /// 删除功能Quartz提供了很多。
        /// </summary>
        /// <param name="jobName"></param>
        public static void DeleteJob(string jobName)
        {
            JobKey key = new JobKey(jobName, jobName + "_Group");
            scheduler.DeleteJob(key);
        }

        /// <summary>
        /// 下载定时器
        /// </summary>
        /// <param name="waitFroJobsToComplete"></param>
        public static void Shutdown(bool waitFroJobsToComplete)
        {
            scheduler.Shutdown(waitFroJobsToComplete);
        }
    }
}
