using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StudentManagement
{
    public partial class AddStudent : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if Edit Mode
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    LoadStudent(id);

                    btnSave.Visible = false;     // Hide Save for edit mode
                    btnUpdate.Visible = true;    // Show Update button
                }
                else
                {
                    btnSave.Visible = true;      // Show Save in Add mode
                    btnUpdate.Visible = false;   // Hide Update in Add mode
                }
            }
        }

        // --------------------- ADD STUDENT (INSERT) ---------------------
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "INSERT INTO Students (Name, Email, Mobile, City) VALUES(@Name, @Email, @Mobile, @City)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            // Redirect to list after adding
            Response.Redirect("ViewStudents.aspx");
        }

        // --------------------- LOAD STUDENT FOR EDIT ---------------------
        private void LoadStudent(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "SELECT * FROM Students WHERE StudentId = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtName.Text = dr["Name"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                    txtMobile.Text = dr["Mobile"].ToString();
                    txtCity.Text = dr["City"].ToString();
                }
            }
        }

        // --------------------- UPDATE STUDENT DATA ---------------------
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = @"UPDATE Students 
                                 SET Name=@Name, Email=@Email, Mobile=@Mobile, City=@City
                                 WHERE StudentId=@Id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@City", txtCity.Text);
                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            // Redirect back to list after update
            Response.Redirect("ViewStudents.aspx");
        }
    }
}