using System.Data.SqlClient;

namespace CRUDMVC.Models
{
    public class StudentDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public StudentDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConection"));
        }


        public List<Student> GetStudent()
        {
            List<Student> students = new List<Student>();
            string qry = "select * from Student";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student student = new Student();
                    student.Roll_No = Convert.ToInt32(dr["Roll_No"]);
                    student.Sname = dr["Sname"].ToString();
                    student.City = dr["City"].ToString();
                    student.SPercentage = Convert.ToInt32(dr["SPercentage"]);

                    students.Add(student);
                }
            }
            con.Close();
            return students;
        }
        public Student GetStudentbyRollNo(int Roll_No)
        {
           
            Student student=new Student();
            string qry = "select * from Student where Roll_No=@Roll_No";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Roll_No", Roll_No);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    student.Roll_No = Convert.ToInt32(dr["Roll_No"]);
                    student.Sname = dr["Sname"].ToString();
                    student.City = dr["City"].ToString();
                    student.SPercentage = Convert.ToInt32(dr["SPercentage"]);
                }
            }
            con.Close();
            return student;
        }
        public int AddStudent(Student student)
        {
            int result = 0;
            string qry = "insert into Student values(@SName,@City,@SPercentage)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Sname", student.Sname);
            cmd.Parameters.AddWithValue("@City", student.City);
            cmd.Parameters.AddWithValue("@SPercentage", student.SPercentage);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateStudent(Student student)
        {
            int result = 0;
            string qry = "update Student set Sname=@Sname,City=@City,SPercentage=@SPercentage where Roll_No=@Roll_No";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Sname", student.Sname);
            cmd.Parameters.AddWithValue("@City", student.City);
            cmd.Parameters.AddWithValue("@SPercentage", student.SPercentage);
            cmd.Parameters.AddWithValue("@Roll_No", student.Roll_No);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int Roll_No)
        {
            int result = 0;
            string qry = "delete from Student where Roll_No=@Roll_No";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Roll_No", Roll_No);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}

