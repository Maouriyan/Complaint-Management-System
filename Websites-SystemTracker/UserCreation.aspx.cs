using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Data.OleDb;
//using System.Linq;

public partial class UserCreation : System.Web.UI.Page
{
	string ConStr = string.Empty;
	SqlConnection Conn = null;
	
	SqlConnection Con = null;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			DropDown_Binding();
		}
	}
	protected void DropDown_Binding()
	{ //DropDown Binding  on Roles
		try
		{
			ConStr = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
			Conn = new SqlConnection(ConStr);
			Conn.Open();
			string query = "select * from RoleTable";
			SqlDataAdapter adpt = new SqlDataAdapter(query, Conn);
			DataTable dt = new DataTable();
			adpt.Fill(dt);
			DrpRole.DataSource = dt;
			DrpRole.DataBind();
			DrpRole.DataTextField = "Role_Desc";
			DrpRole.DataValueField = "Role_ID";
			DrpRole.DataBind();
		}
		catch (Exception)
		{

			throw;
		}
	}

	protected void btnCreate_Click(object sender, EventArgs e)
	{ //Inserting into table
		try
		{
			ConStr = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
			Con = new SqlConnection(ConStr);
			Con.Open();
			string Update_query = "INSERT INTO[dbo].[EndUser](User_ID,[Password],[Full Name],[Email],[Role])VALUES('" + txtboxUserId.Text + "','" + txtboxPassword.Text + "','" + txtboxName.Text + "','" + txtboxEmail.Text + "','" + DrpRole.Text + "')";
			SqlCommand cmd = new SqlCommand(Update_query, Con);
			cmd.ExecuteNonQuery();
			Con.Close();
			lblMessage.Text = "User Created";
		}
		catch (Exception ex)
		{
			string err  = ex.Message;

			if (err.Contains("duplicate"))
				{
				err = "D";

			}

			switch (err)
			{

				case "D":
					{
						lblMessage.Text = "Please Check and Insert Again";
						break;
					}


				default: lblMessage.Text = err;

					break;
			}
		}
		

	}


	protected void btnUpload_Click(object sender, EventArgs e)
	{ //Bulk upload using  Excel Sheet
		OleDbConnection connection = null;
			DbDataReader dr = null;
		if (FileUpload1.HasFile)
		{
			try
			{
				string path = string.Concat(Server.MapPath(FileUpload1.FileName));
				FileUpload1.SaveAs(path);

				// Connection String to Excel Workbook

				//string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
				string excelConnectionString = string.Format(ConfigurationManager.ConnectionStrings["GetExcel"].ConnectionString, path);
				 connection = new OleDbConnection();
				connection.ConnectionString = excelConnectionString;
				OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
				connection.Open();
				// Create DbDataReader to Data Worksheet
				dr = command.ExecuteReader();

				// SQL Server Connection String
				ConStr = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
				Conn = new SqlConnection(ConStr);
				Conn.Open();
				// Bulk Copy to SQL Server 
				SqlBulkCopy bulkInsert = new SqlBulkCopy(ConStr);
				bulkInsert.DestinationTableName = "EndUser";
				bulkInsert.WriteToServer(dr);
				lblMessage.Text = "Bulk Upload Complete";
				Conn.Close();
			}
			catch (Exception ex)
			{
				lblMessage.Text = ex.Message;
			}
			finally
			{
				connection.Close();
				dr.Close();
			}
		}
	}
}