using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

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
}
