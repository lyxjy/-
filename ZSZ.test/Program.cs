using CaptchaGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.common;
using log4net;
using Quartz.Impl;
using Quartz.Spi;
using Quartz;
using System.Data.SqlClient;
using System.Data;

namespace ZSZ.test
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string code = CommonHelp.GenerateCaptchaCode(4);
           // Console.WriteLine(code);
            using (MemoryStream ms = ImageFactory.GenerateImage(code, 60, 100, 20, 6))
            using (FileStream fs = File.OpenWrite(@"D:\test.jpg"))
            {
                ms.CopyTo(fs);
            }
            */

            /*
            //加载app.config里面的配置信息
            log4net.Config.XmlConfigurator.Configure();
            ILog logger = LogManager.GetLogger(typeof(Program));
            logger.Debug("调试程序！");
            logger.Warn("编译程序！");
            logger.Error("编译失败！");
           */

            /*
            Quartz.IScheduler sched = new StdSchedulerFactory().GetScheduler();
            JobDetailImpl jdBossReport = new JobDetailImpl("jdTest", typeof(TestJob));
            IMutableTrigger triggerBossReport = CronScheduleBuilder.DailyAtHourAndMinute(11,
            12).Build();//每天 11:12 执行一次
            triggerBossReport.Key = new TriggerKey("triggerTest");
            sched.ScheduleJob(jdBossReport, triggerBossReport);
            sched.Start();
            */
            using (SqlConnection conn = new SqlConnection("server=100.100.9.29;database=SXCRM_MSCRM;uid=sa;pwd=sxp@ssw0rd"))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();    //打开数据库的连接
                    cmd.CommandText = "select * from oausertask where finisheddata is null";
                    DataTable dt = new DataTable();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                    DataRow drow = (DataRow)dt.Rows[0];
                    Console.WriteLine(dt.Rows.Count);
                    Console.WriteLine(drow[3]);
                }
            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
