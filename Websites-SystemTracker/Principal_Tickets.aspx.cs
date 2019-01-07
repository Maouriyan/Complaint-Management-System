using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;



public partial class Principal_Tickets : System.Web.UI.Page
{
	string ConStr = string.Empty;
	SqlCommand cmd = null;
	SqlConnection Conn = null;


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			gvbind();
		}
	}
	protected void gvbind()
	{
		ConStr = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
		Conn = new SqlConnection(ConStr);
		Conn.Open();
		SqlCommand cmd = new SqlCommand("Select * from Ticket where HOD_Approval='Approved' order by Created_on ASC", Conn);
		SqlDataAdapter da = new SqlDataAdapter(cmd);
		DataSet ds = new DataSet();
		da.Fill(ds); //Filling data set with values returned from query
		Conn.Close();
		if (ds.Tables[0].Rows.Count > 0)
		{
			gridPTview.DataSource = ds;
			gridPTview.DataBind();
		}
		else
		{
			ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
			gridPTview.DataSource = ds;
			gridPTview.DataBind();
			int columncount = gridPTview.Rows[0].Cells.Count;
			gridPTview.Rows[0].Cells.Clear();
			gridPTview.Rows[0].Cells.Add(new TableCell());
			gridPTview.Rows[0].Cells[0].ColumnSpan = columncount;
			gridPTview.Rows[0].Cells[0].Text = "No Records Found";
		}
	}
	protected void gridPTview_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		ConStr = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
		Conn = new SqlConnection(ConStr);
		GridViewRow row = (GridViewRow)gridPTview.Rows[e.RowIndex];
		Label lbldeleteid = (Label)row.FindControl("lblID"); //Deleting based on id
		Conn.Open();
		SqlCommand cmd = new SqlCommand("delete FROM Ticket where Ticket_ID='" + Convert.ToInt32(gridPTview.DataKeys[e.RowIndex].Value.ToString()) + "'", Conn);
		cmd.ExecuteNonQuery();
		Conn.Close();
		gvbind(); //Re-binding
		Response.Redirect("Principal_Tickets.aspx", false);//Navigation to page
	}
	protected void gridPTview_RowEditing(object sender, GridViewEditEventArgs e)
	{

		gridPTview.EditIndex = e.NewEditIndex; //Edition based on Index
		gvbind();
	}
	protected void gridPTview_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		ConStr = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
		Conn = new SqlConnection(ConStr);
		int Ticketid = Convert.ToInt32(gridPTview.DataKeys[e.RowIndex].Value.ToString());
		GridViewRow row = (GridViewRow)gridPTview.Rows[e.RowIndex];
		Label lblID = (Label)row.FindControl("Tkid");
		//Getting values of Status and Assigned
		DropDownList Status = (gridPTview.Rows[e.RowIndex].FindControl("Status") as DropDownList);
		//DropDownList ddlAsgn = (gridPTview.Rows[e.RowIndex].FindControl("ddlAsgn") as DropDownList);
		DropDownList Principal_Approval = (gridPTview.Rows[e.RowIndex].FindControl("Principal_Approval") as DropDownList);

		Conn.Open();
		//string asgn = ddlAsgn.SelectedItem.Text;
		//	updating the table with new selected item
		cmd = new SqlCommand("update Ticket set Principal_Approval='" + Principal_Approval.SelectedItem.Text + "'where Ticket_ID='" + Ticketid + "'", Conn);
		cmd.ExecuteNonQuery();

		Conn.Close();

		gvbind();
		Response.Redirect("Principal_Tickets.aspx", false);

	}

	private void SendEmail(string asgn)
	{

		String sqlQuery = string.Empty;
		SqlDataReader reader = null;
		SqlCommand command = null;
		string dbemail = string.Empty;
		string ConStr = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;

		sqlQuery = "select User_ID,Email from [EndUser]  Where  User_ID='" + asgn + "' ";
		SqlConnection Conn = new SqlConnection(ConStr);
		Conn.Open();

		command = new SqlCommand(sqlQuery, Conn);


		reader = command.ExecuteReader();


		while (reader.Read())

		{
			dbemail = reader["Email"].ToString();

		}

		// Specify the from and to email address
		MailMessage mailMessage = new MailMessage("missionred1@gmail.com", dbemail);
		// Specify the email body

		string emailbody = "New Ticket Assigned To You";
		mailMessage.Body = emailbody;
		// Specify the email Subject
		mailMessage.Subject = "New Ticket";

		// Specify the SMTP server name and post number
		SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
		// Specify your gmail address and password
		smtpClient.Credentials = new System.Net.NetworkCredential()
		{
			UserName = "missionred1@gmail.com",
			Password = "test123456"
		};
		// Gmail works on SSL, so set this property to true
		smtpClient.EnableSsl = true;
		// Finall send the email message using Send() method
		smtpClient.Send(mailMessage);
		//throw new NotImplementedException();

	}

	protected void gridPTview_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{

		gridPTview.PageIndex = e.NewPageIndex;
		gvbind();
	}
	protected void gridPTview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		gridPTview.EditIndex = -1;
		gvbind();
	}

	protected void gridPTview_OnRowDataBound(object sender, GridViewRowEventArgs e)
	{//Binding values on Row
		try
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{


				if (e.Row.RowType == DataControlRowType.DataRow && gridPTview.EditIndex == e.Row.RowIndex)
				{
					//DropDownList ddlAsgn = (DropDownList)e.Row.FindControl("ddlAsgn");
					//ddlAsgn.DataSource = DropDown_Status_Binding("SELECT EID,User_ID from EndUser where Role='2'");
					//ddlAsgn.DataTextField = "User_ID";
					//ddlAsgn.DataValueField = "EID";
					//ddlAsgn.DataBind();

				}

			}

		}
		catch (Exception ex)
		{

			throw ex;
		}
	}

	protected DataTable DropDown_Status_Binding(string query)
	{ //Get vales from query and return to OnRowDataBound
		try
		{
			ConStr = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
			Conn = new SqlConnection(ConStr);
			Conn.Open();

			SqlDataAdapter adpt = new SqlDataAdapter(query, Conn);
			DataTable dt = new DataTable();
			adpt.Fill(dt);
			return dt;
		}
		catch (Exception)
		{

			throw;
		}
	}


}