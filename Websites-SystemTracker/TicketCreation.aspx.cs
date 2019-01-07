using System;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;

public partial class TicketCreation : System.Web.UI.Page
{
	string ConStr = string.Empty;
	
	string fuser = null;
	SqlConnection Con = null;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		
	}
	
	
	
	

	protected void btnCreate_Click(object sender, EventArgs e)
	{ //Creating New Ticket by inserting in database and sending email to concerned person(s) 
		try
		{
			ConStr = ConfigurationManager.ConnectionStrings["GetConnection"].ConnectionString;
			
			Con = new SqlConnection(ConStr);
			Con.Open();
			fuser = Session["User"].ToString();
			string Update_query = "INSERT INTO[dbo].[Ticket]([Lab_No],[System_No],User_ID,[Ticket_Desc])VALUES('" + txtboxLabNo.Text + "','" + txtboxSystemNo.Text + "','"+ Session["User"].ToString()+"','" + txtboxTktDesc.Text + "')";
			SqlCommand cmd = new SqlCommand(Update_query, Con);
			cmd.ExecuteNonQuery();
			Con.Close();
			lblMessage.Text = "Ticket Created";
			//SendEmail(fuser);
			
			
		}
		catch (Exception ex)
		{
			


			lblMessage.Text = Convert.ToString(ex);

			
		}

		finally
		{
			Response.Redirect("Tickets.aspx");
		}
	}

	public void SendEmail(string fuser)
	{
		try
		{
			// Specify the from and to email address
			MailMessage mailMessage = new MailMessage("missionred1@gmail.com", "nibirule@gmail.com");
			// Specify the email body
			
			string emailbody = "New Ticket Issued from" + fuser;
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
			
		}
		catch (Exception ex)
		{

			
			lblMessage.Text = ex.Message;
		}
		
	}
	
}