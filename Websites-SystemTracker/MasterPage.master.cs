using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
	string dbrole = null;
	string Dbuser = null;
	protected void Page_Load(object sender, EventArgs e)
	{
		
		dbrole = Session["dbrole"].ToString();
		if (Session["User"].ToString() != "null")
		{
			Dbuser = Session["User"].ToString();
			aWelcome.InnerText = "'Welcome, " + Dbuser+"'";
		}
		
		if (dbrole == "1")
		{
			//Tickets,Ticket Creation
			lnkTicket.Visible = true;
			lnkT.Visible = true;
			lbllogout.Visible = true;
			lnklogin.Visible = false;

		}
		else if (dbrole == "2")
		{
			//SEtickets
			lnkSE.Visible = true;
			lbllogout.Visible = true;
			lnklogin.Visible = false;

		}

		else if (dbrole == "3")
		{
			//SEtickets
			lnkHOD.Visible = true;
			lbllogout.Visible = true;
			lnklogin.Visible = false;

		}

		else if (dbrole == "4")
		{
			//SEtickets
			lnkP.Visible = true;
			lbllogout.Visible = true;
			lnklogin.Visible = false;

		}

		else if (dbrole == "0")
		{
			//user creation , Admin Tickets
			lnkTicket.Visible = true;
			lnkusers.Visible = true;
			lnkAT.Visible = true;
			lbllogout.Visible = true;
			lnklogin.Visible = false;


		}
		
		
	}

	protected void lbllogout_Click(object sender, EventArgs e)
	{
		try
		{
			lnkTicket.Visible = false;
			lnklogin.Visible = true;
			Session.Clear();
			Session.Abandon();
			lnkusers.Visible = false;
			lnkAT.Visible = false;
			lnkSE.Visible = false;
			lnkTicket.Visible = false;
			lnkT.Visible = false;
			lnklogin.Visible = true;


			Response.Redirect("Login.aspx", false);
		}
		catch (Exception ex)
		{

			throw ex;
		}
		
		
			
	
	}

	
}
