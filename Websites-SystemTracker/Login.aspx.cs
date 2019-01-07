using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
	string ConStr = string.Empty;
	SqlConnection Conn = null;

	protected void Page_Load(object sender, EventArgs e)
	 {
		if (!IsPostBack)
		{
			Session["dbrole"] = "xx"; //Setting Default value to Role in Session
			Session["User"] = "null"; //Setting Default value to User in Session
		}	

	}


	protected void btnLogin_Click(object sender, EventArgs e)
	{
		try
		{
			String sqlQuery = string.Empty; // Intialising New Query
			SqlDataReader reader = null;    // Reader to Read data
			SqlCommand command = null;      // Command to execute
											//To store Reader values
			string Dbuser = string.Empty;  
			string dbpass = string.Empty;
			string dbrole = string.Empty;
			//Connection string from Web.config
			ConStr = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
			//Query to get UserID and Password from Table
			sqlQuery = "select * from [EndUser]  Where User_ID='" + txtboxUserId.Text + "' and Password='" + txtboxPassword.Text + "' ";
			Conn = new SqlConnection(ConStr);
			Conn.Open();
			command = new SqlCommand(sqlQuery, Conn);
			reader = command.ExecuteReader();
			//Reading Values
			while (reader.Read())
			{
				Dbuser = reader["User_ID"].ToString();
				dbpass = reader["Password"].ToString();
				dbrole = reader["Role"].ToString();
			}
			if (txtboxUserId.Text == Dbuser && txtboxPassword.Text == dbpass)
			{
				Session["dbrole"] = dbrole; //Assigning read values to session values
				Session["User"] = Dbuser;
				switch (dbrole)//Navigation Bases on Role number
				{
					case "0":
						{
							///Admin page
							Response.Redirect("AdminTickets.aspx",false);
							break;
						}
					case "1":
						{///End user page
							Response.Redirect("Tickets.aspx",false);
							break;
						}
					case "2":
						{
							///Service Engnieer page
							Response.Redirect("SEtickets.aspx",false);
							break;
						}
					case "3":
						{
							///HOD page
							Response.Redirect("HOD_Tickets.aspx", false);
							break;
						}
					case "4":
						{
							///Principal page
							Response.Redirect("Principal_Tickets.aspx", false);
							break;
						}
					default:
						break;
				}		


			}
			else
			{
				lblError.Text = "Incorrect ID/Password";
			}
		}
		catch (Exception ex)
		{

			lblError.Text =ex.Message;
		}

	}
	
}