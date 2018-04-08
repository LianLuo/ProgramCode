using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using System.Transactions;

namespace HW.LabStore.UT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello");
        }
    }

    public class CourseData
    {
        public async Task AddCourseAsync()
        {
            var connection = new SqlConnection("");
            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Courses (Number,Title) VALUES (@number,@title)";
            await connection.OpenAsync();
            var tx = connection.BeginTransaction();
            try
            {
                cmd.Transaction = tx;
                cmd.Parameters.AddWithValue("", "");
                cmd.Parameters.AddWithValue("", "");
                await cmd.ExecuteNonQueryAsync();
                tx.Commit();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                tx.Rollback();
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }

    public class Utilities
    {
        public static bool AbortTx()
        {
            Console.WriteLine("Abort the Transaction (y/n)?");
            var inputs = Console.ReadLine();
            inputs = inputs ?? "";
            return inputs.ToLower().Equals("y");
        }

        public static void DisplayTransactionInformation(string title, TransactionInformation ti)
        {
            Contract.Requires<ArgumentException>(ti != null);
            Console.WriteLine("{0}\r\nCreation Time:{1}\r\nStatus:{2}\r\nLocal ID:{3}\r\nDistributed ID:{4}", title,
                ti.CreationTime, ti.Status, ti.LocalIdentifier, ti.DistributedIdentifier);
        }
    }
}
