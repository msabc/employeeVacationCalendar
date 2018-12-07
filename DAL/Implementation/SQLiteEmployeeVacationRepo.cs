using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;

namespace DAL
{
    public class SQLiteEmployeeVacationRepo : IEmployeeVacationRepo
    {
        private const string connectionString = @"Data Source=C:\Users\Matija\source\repos\calendar\DAL\Data\employeeVacations.db;Version=3;";

        public int DeleteEmployeeVacation(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "delete from EmployeeVacation where IDEmployeeVacation = " + id.ToString();

                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                return -1;
            }
        }

        public ICollection<EmployeeVacation> GetEmployeeVacations()
        {
            try
            {
                ICollection<EmployeeVacation> employees = new List<EmployeeVacation>();

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "select * from EmployeeVacation";

                        SQLiteDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            //int sth1 = int.Parse(reader["IDEmployeeVacation"].ToString());
                            //string name1 = reader["EmployeeName"].ToString();
                            //string name2 = reader["EmployeeLastName"].ToString();
                            //DateTime dt1 = UnixTimeStampToDateTime(int.Parse(reader["From"].ToString()));
                            //var sth1 = int.Parse(reader["IDEmployeeVacation"].ToString());
                            //var sth2 = reader["EmployeeName"].ToString();
                            //var sth3 = reader["EmployeeLastName"].ToString();
                            //var sth4 = Enum.Parse<VacationType>(reader["Leave"].ToString());
                            //var sth5 = UnixTimeStampToDateTime(int.Parse(reader[4].ToString()));
                            //var sth6 = UnixTimeStampToDateTime(int.Parse(reader[5].ToString()));

                            employees.Add(new EmployeeVacation(
                                int.Parse(reader["IDEmployeeVacation"].ToString()),
                                reader["EmployeeName"].ToString(),
                                reader["EmployeeLastName"].ToString(),
                                Enum.Parse<VacationType>(reader[4].ToString()),
                                UnixTimeStampToDateTime(int.Parse(reader["DateFrom"].ToString())), 
                                UnixTimeStampToDateTime(int.Parse(reader["DateTo"].ToString()))));
                        }
                    }
                }

                return employees;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }

        public EmployeeVacation InsertEmployeeVacation(EmployeeVacation employeeVacation)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "insert into EmployeeVacation('EmployeeName','EmployeeLastName','DateFrom','DateTo') values( " +
                            "'" + employeeVacation.EmployeeFirstName + "', " +
                            "'" + employeeVacation.EmployeeLastName + "', " +
                                  DateTimeToUnixTimeStamp(employeeVacation.From) + ", " + DateTimeToUnixTimeStamp(employeeVacation.To) + ");";

                        cmd.ExecuteNonQuery();

                        return employeeVacation;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                return null;
            }
        }

        public int UpdateEmployeeVacation(EmployeeVacation employeeVacation)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "update EmployeeVacation " +
                            "set EmployeeName = '" + employeeVacation.EmployeeFirstName + "', " +
                            "EmployeeLastName = '" + employeeVacation.EmployeeLastName + "', " +
                            "Leave = " + (int) employeeVacation.Leave + ", " +
                            "DateFrom = " + DateTimeToUnixTimeStamp(employeeVacation.From) + ", " +
                            "DateTo = " + DateTimeToUnixTimeStamp(employeeVacation.To) + 
                            " where IDEmployeeVacation = " + employeeVacation.IDEmployeeVacation + ";";

                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// <para>Since SQLite uses INTEGER as a datetime data type (seconds passed since Jan 1st 1970), </para>
        /// <para>this method is used to convert to <see cref="DateTime"/> object from a <see cref="int"/> object.</para>
        /// </summary>
        /// <param name="unixTimeStamp">Seconds passed since Jan 1st 1970</param>
        /// <returns><see cref="DateTime"/></returns>
        private DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        /// <summary>
        /// <para>Since SQLite uses INTEGER as a datetime data type (seconds passed since Jan 1st 1970), </para>
        /// <para>this method is used to convert to <see cref="int"/> object from a <see cref="DateTime"/> object.</para>
        /// </summary>
        /// <param name="unixTimeStamp">A <see cref="DateTime"/> object</param>
        /// <returns><see cref="int"/></returns>
        private int DateTimeToUnixTimeStamp(DateTime dateTime) => (int) dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
    }
}
