using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Practice.Connection;
using System.Data.SqlClient;
using System.Data;

namespace Practice
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DisplayGridView();
                DropDown();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DBConnection _connection = new DBConnection();
            string _query = "Insert into account(firstname, lastname) VALUES (@firstname, @lastname)";
            if (_connection.ConnectionOpen() == true)
            {

                using (_connection._command = new SqlCommand(_query, _connection._connect))
                {

                    _connection._command.Parameters.AddWithValue("@firstname", firstname.Text);
                    _connection._command.Parameters.AddWithValue("@lastname", lastname.Text);
                    _connection._command.ExecuteNonQuery();
                    _connection.ConnectioClose();
                    //      Response.Write("<script>alert('Success')</script>");
                    DisplayGridView();
                }
            }

            else
            {

                Response.Write("<script>alert('Fail')</script>");
            }

        }

        public void DisplayGridView()
        {
            DBConnection _connection = new DBConnection();
            string _query = "SELECT * FROM account";
            if (_connection.ConnectionOpen() == true)
            {

                using (_connection._command = new SqlCommand(_query, _connection._connect))
                {

                    GridView1.DataSource = _connection._command.ExecuteReader();
                    GridView1.DataBind();
                    // ListView1.DataSource = _connection._command.ExecuteReader();
                    // ListView1.DataBind();

                    _connection.ConnectioClose();


                }
            }

            else
            {

                Response.Write("<script>alert('Fail')</script>");
            }
        }

        public void DropDown()
        {
            DBConnection _connection = new DBConnection();
            string _query = "SELECT * FROM account";
            if (_connection.ConnectionOpen() == true)
            {

                using (_connection._command = new SqlCommand(_query, _connection._connect))
                {


                    SqlDataReader _rdr = _connection._command.ExecuteReader();
                    DropDownList1.DataSource = _rdr;

                    DropDownList1.DataTextField = "account_id";
                    DropDownList1.DataValueField = "account_id";
                    DropDownList1.DataBind();
                    // ListView1.DataSource = _connection._command.ExecuteReader();
                    // ListView1.DataBind();

                    _connection.ConnectioClose();


                }
            }

            else
            {

                Response.Write("<script>alert('Fail')</script>");
            }
        }

        protected void DropDownSelect(object sender, EventArgs e)
        {

            DBConnection _connection = new DBConnection();
            string _query = "SELECT * FROM account where account_id =@account_id ";
            if (_connection.ConnectionOpen() == true)
            {

                using (_connection._command = new SqlCommand(_query, _connection._connect))
                {

                    _connection._command.Parameters.AddWithValue("@account_id", DropDownList1.SelectedValue.ToString());
                    SqlDataReader _rdr = _connection._command.ExecuteReader();


                    if (_rdr.Read())
                    {
                        firstname.Text = _rdr["firstname"].ToString();
                        lastname.Text = _rdr["lastname"].ToString();
                    }
                    DisplayGridViewNEW();
                    // ListView1.DataSource = _connection._command.ExecuteReader();
                    // ListView1.DataBind();

                    _connection.ConnectioClose();


                }
            }

            else
            {

                Response.Write("<script>alert('Fail')</script>");
            }

        }






        public void DisplayGridViewNEW()
        {
            DBConnection _connection = new DBConnection();
            string _query = "SELECT * FROM account where account_id =@account_id ";
            if (_connection.ConnectionOpen() == true)
            {

                using (_connection._command = new SqlCommand(_query, _connection._connect))
                {
                    _connection._command.Parameters.AddWithValue("@account_id", DropDownList1.SelectedValue.ToString());

                    SqlDataAdapter _adp = new SqlDataAdapter(_connection._command);
                    DataTable _table = new DataTable();
                    _adp.Fill(_table);
                    GridView1.DataSource = _table;
                    GridView1.DataBind();
                    // ListView1.DataSource = _connection._command.ExecuteReader();
                    // ListView1.DataBind();

                    _connection.ConnectioClose();


                }
            }

            else
            {

                Response.Write("<script>alert('Fail')</script>");
            }
        }

        protected void SelectRow(object sender, EventArgs e)
        {
            GridViewRow _row = GridView1.SelectedRow;

            firstname.Text = _row.Cells[2].Text.ToString();


                }

        protected void RowDelete(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow _row = GridView1.SelectedRow;


            string _x = e.Keys["account_id"].ToString();
            string _xy = GridView1.DataKeys[e.RowIndex].Value.ToString();
            int _y = Convert.ToInt32(_xy);
            DBConnection _connection = new DBConnection();
            string _query = "Delete from account where account_id = @account_id";
            if (_connection.ConnectionOpen() == true)
            {

                using (_connection._command = new SqlCommand(_query, _connection._connect))
                {

                    _connection._command.Parameters.AddWithValue("@account_id", _y);
                   
                    _connection._command.ExecuteNonQuery();
                    _connection.ConnectioClose();
                    //      Response.Write("<script>alert('Success')</script>");
                    DisplayGridView();
                }
            }

            else
            {

                Response.Write("<script>alert('Fail')</script>");
            }

        }

  
    }
}