using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Tickets : System.Web.UI.Page
{
	
	string ConStr = string.Empty;

	protected void Page_Load(object sender, EventArgs e)
	{
		
		if (!IsPostBack) { 
			Ticket_Bind();
		}



	}

	protected void TktCreate_Click(object sender, EventArgs e)
	{

		Response.Redirect("TicketCreation.aspx",false);
		
	}
	public void Ticket_Bind()
	{//Binding Based on User Id
		
		SqlConnection Conn = null;
		try
		{
			

			ConStr = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
			Conn = new SqlConnection(ConStr);
			Conn.Open();

			SqlCommand cmd = new SqlCommand("Select* from Ticket where User_ID='" + Session["User"].ToString() + "'", Conn);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			Conn.Close();
			if (ds.Tables[0].Rows.Count > 0)
			{
				GridTicket.DataSource = ds;
				GridTicket.DataBind();
			}
			else
			{
				ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
				GridTicket.DataSource = ds;
				GridTicket.DataBind();
				int columncount = GridTicket.Rows[0].Cells.Count;
				GridTicket.Rows[0].Cells.Clear();
				GridTicket.Rows[0].Cells.Add(new TableCell());
				GridTicket.Rows[0].Cells[0].ColumnSpan = columncount;
				GridTicket.Rows[0].Cells[0].Text = "No Records Found";
			}
		}
		catch (Exception ex)
		{

			throw ex;
		}

		finally
		{
			Conn.Close();
		}
	}

	protected void gridSEview_RowEditing(object sender, GridViewEditEventArgs e)
	{
		GridTicket.EditIndex = e.NewEditIndex;
		Ticket_Bind();
	}
	protected void gridSEview_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		DateTime dt = DateTime.Now;
	   SqlConnection Conn = null;
		ConStr = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
		Conn = new SqlConnection(ConStr);
		int Ticketid = Convert.ToInt32(GridTicket.DataKeys[e.RowIndex].Value.ToString());
		GridViewRow row = (GridViewRow)GridTicket.Rows[e.RowIndex];
		Label lblID = (Label)row.FindControl("Tkid");
		TextBox lblSD = (GridTicket.Rows[e.RowIndex].FindControl("Service_Desc") as TextBox);
		DropDownList Status = (GridTicket.Rows[e.RowIndex].FindControl("Status") as DropDownList);

		GridTicket.EditIndex = -1;
		Conn.Open();

		SqlCommand cmd = new SqlCommand("update Ticket set Status='" + Status.SelectedItem.Text + "',Service_Desc='"+ lblSD.Text+"'where Ticket_ID ='" + Ticketid + "'", Conn);
		cmd.ExecuteNonQuery();
		if (Status.SelectedItem.Text == "Completed")
		{//If completed Generate Completed Time
			SqlCommand commnd = new SqlCommand("update Ticket set Completed_on='"+ dt+ "' where  Ticket_ID='" + Ticketid + "'", Conn);
			commnd.ExecuteNonQuery();

		}
		Conn.Close();
		Ticket_Bind();
		
	}
	protected void gridSEview_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		GridTicket.PageIndex = e.NewPageIndex;
		Ticket_Bind();
		
	}
	protected void gridSEview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		GridTicket.EditIndex = -1;
		Ticket_Bind();
	}
}