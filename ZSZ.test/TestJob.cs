using Common.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.test
{
    public class TestJob : IJob
    {
      public  void  Execute(IJobExecutionContext context)
        {
            try {
                Console.WriteLine("任务执行了" + DateTime.Now);
                SqlConnection conn = new SqlConnection();
                conn.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           



        }
    }
}
