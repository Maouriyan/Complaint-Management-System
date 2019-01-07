using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;



public partial class SEtickets : System.Web.UI.Page
{
	string ConStr = string.Empty;
	SqlConnection Conn = null;
	string dbuser = null;
	protected void Page_Load(object sender, EventArgs e)
	{
		if (Session["User"]!= null)
		{
			dbuser = Session["User"].ToString();
			
		}
		if (!IsPostBack)
		{
			gvbind();
		}
	}
	protected void gvbind()
	{ //Binding based on which Engineer it is assigned to
		try
		{
			ConStr = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
			Conn = new SqlConnection(ConStr);
			Conn.Open();

			SqlCommand cmd = new SqlCommand("select * FROM Ticket where Assigned_TO = '" + dbuser + "'", Conn);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();
			da.Fill(ds);
			Conn.Close();

			if (ds.Tables[0].Rows.Count > 0)
			{
				gridSEview.DataSource = ds;
				gridSEview.DataBind();
			}
			else
			{
				ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
				gridSEview.DataSource = ds;
				gridSEview.DataBind();
				int columncount = gridSEview.Rows[0].Cells.Count;
				gridSEview.Rows[0].Cells.Clear();
				gridSEview.Rows[0].Cells.Add(new TableCell());
				gridSEview.Rows[0].Cells[0].ColumnSpan = columncount;
				gridSEview.Rows[0].Cells[0].Text = "No Records Found";
			}
		}
		catch (Exception)
		{

			LblMessage.Text = "";
			
		}
		
	}
	
	protected void gridSEview_RowEditing(object sender, GridViewEditEventArgs e)
	{
		
		gridSEview.EditIndex = e.NewEditIndex;
		gvbind();
	}
	protected void gridSEview_RowUpdating(object sender, GridViewUpdateEventArgs e)
	{
		ConStr = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
		Conn = new SqlConnection(ConStr);
		int Ticketid = Convert.ToInt32(gridSEview.DataKeys[e.RowIndex].Value.ToString());
		GridViewRow row = (GridViewRow)gridSEview.Rows[e.RowIndex];
		Label lblID = (Label)row.FindControl("Tkid");
		DropDownList Status = (gridSEview.Rows[e.RowIndex].FindControl("Status") as DropDownList);
	  
		gridSEview.EditIndex = -1;
		Conn.Open();
		if (Status.Text == "Completed")
		{//Service Engineer cannot status to completed
			Status.Visible = false;
			System.Windows.Forms.MessageBox.Show("Cannot Change to Completed");
			Response.Redirect("SEtickets.aspx", false);
			
		}
		else { 
		SqlCommand cmd = new SqlCommand("update Ticket set Status='" + Status.SelectedItem.Text + "'where Ticket_ID='" + Ticketid + "'", Conn);
		cmd.ExecuteNonQuery();
		Conn.Close();
		gvbind();
		}
	}
	protected void gridSEview_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		gridSEview.PageIndex = e.NewPageIndex;
		gvbind();
	}
	protected void gridSEview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
	{
		gridSEview.EditIndex = -1;
		gvbind();
	}

	
}