using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServise
{
    class FuncService
    {
        public List<Person> ReturnPersons()
        {
            string connstring = "Data Source=LENOVO-PC;Initial Catalog=Test;Integrated Security=True";
            string comm = "SELECT * FROM Persons";
            List<Person> pers = new List<Person>();
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                using (SqlCommand command = new SqlCommand(comm, connection))
                {
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);

                        foreach (DataRow dr in dt.Rows)
                        {
                            pers.Add(new Person() { ID = Convert.ToInt32(dr["ID"]), Name = dr["Fname"].ToString(), Fname = dr["Lname"].ToString() });
                        }
                        return pers;
                    }
                }
            }
        }
        public Person Getperson(int id)
        {
            Person us = new Person();

            string connstring = "Data Source=LENOVO-PC;Initial Catalog=Test;Integrated Security=True";
            string strcommand = "SELECT * FROM Persons WHERE ID =@id";
            using (SqlConnection connection = new SqlConnection(connstring))
            {
                using (SqlCommand command = new SqlCommand(strcommand, connection))
                {
                    SqlDataReader reader;
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = id;

                    connection.Open();
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        us.ID = reader.GetInt32(0);
                        us.Name = reader.GetValue(1).ToString();
                        us.Fname = reader.GetValue(2).ToString();

                    }

                    return us;
                }
            }
        }
        public static void InsertNewPerson(Person person)
        {
            string connstring = "Data Source=LENOVO-PC;Initial Catalog=Test;Integrated Security=True";
            string strInsertString = "INSERT INTO Persons (Fname,Lname)VALUES(@name,@lname)";
            using (SqlConnection con = new SqlConnection(connstring))
            {
                using (SqlCommand comm = new SqlCommand(strInsertString, con))
                {
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = person.Name;
                    comm.Parameters.AddWithValue("@lname", SqlDbType.NVarChar).Value = person.Fname;
                    con.Open();
                    comm.ExecuteNonQuery();

                }
            }

        }
        public static void UpdatePerson(Person person)
        {
            string connstring = "Data Source=LENOVO-PC;Initial Catalog=Test;Integrated Security=True";
            string strInsertString = "UPDATE Persons SET Fname = @name,Lname = @lname WHERE ID =@id";
            using (SqlConnection con = new SqlConnection(connstring))
            {
                using (SqlCommand comm = new SqlCommand(strInsertString, con))
                {
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = person.ID;
                    comm.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = person.Name;
                    comm.Parameters.AddWithValue("@lname", SqlDbType.NVarChar).Value = person.Fname;
                    con.Open();
                    comm.ExecuteNonQuery();

                }
            }
        }
        public static void DeletePerson(int id)
        {
            string connstring = "Data Source=LENOVO-PC;Initial Catalog=Test;Integrated Security=True";
            string strInsertString = "DELETE FROM Persons WHERE ID = @id";
            using (SqlConnection con = new SqlConnection(connstring))
            {
                using (SqlCommand comm = new SqlCommand(strInsertString, con))
                {
                    comm.CommandType = CommandType.Text;
                    comm.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = id;

                    con.Open();
                    comm.ExecuteNonQuery();

                }
            }
        }
    }
}
