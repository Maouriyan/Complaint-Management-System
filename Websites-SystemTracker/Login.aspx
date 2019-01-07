<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" MasterPageFile="~/MasterPage.master" %>


	
	<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
		
		<script type="text/javascript">

		function SysNoValidate() {
			
			var UserID = document.getElementById("<%=txtboxUserId.ClientID %>").value;
			var Password = document.getElementById("<%=txtboxPassword.ClientID %>").value;
			

			if (UserID == "") {
				document.getElementById("<%=lblError.ClientID %>").innerHTML = "Enter User ID ";
				return false;
			}
			if (Password == "") {

				document.getElementById("<%=lblError.ClientID %>").innerHTML = "Enter Password";
				return false;
			}
				

				
			

			
		}
	</script>


		<style type="text/css" runat="server">
		table {
			font-family: arial, sans-serif;
			border-collapse: collapse;
			width: 100%;
		}

		td, th {
			border: 1px solid #dddddd;
			text-align: left;
			padding: 8px;
		}

		tr:nth-child(even) {
			background-color: #dddddd;
		}
		.error{
 color:red;
 font-size:medium;
		}
	.auto-style2 {
		color: red;
		font-size: large;
	}
	.auto-style3 {
		font-size: x-large;
		text-decoration: underline;
	}
	.auto-style4 {
		text-align: center;
		width: 382px;
	}
	.auto-style5 {
		text-align: center;
		margin-left: 120px;
		height: 15px;
	}
	.auto-style6 {
		float: left;
		font-size: small;
		line-height: 20px;
		color: red;
		margin-top: -5px;
		padding: 15px;
	}
	.newStyle2 {
		font-family: "Arial Narrow";
	}
	.auto-style7 {
		font-family: "Arial Narrow";
		color: #000000;
	}
			.auto-style8 {
				height: 2px;
				float: left;
				font-size: small;
				line-height: 20px;
				color: #FF3300;
				margin-top: -5px;
				padding: 15px;
			}
	</style>
		


		<table id="loginTbl" runat="server">
			<tr>
				<th colspan="2" class="text-center">&nbsp;<strong><span class="auto-style3">LOGIN</span></strong></th>

			</tr>
			<tr>
				<td colspan="2" class="auto-style5"><asp:Label ID="lblError" runat="server" CssClass="auto-style8" Height="16px" Width="251px"></asp:Label></td>

			</tr>
			<tr>
				<td class="auto-style4">
					<asp:Label ID="lblUserId" runat="server" Text="User Id" CssClass="footer" style="font-family: 'Arial Narrow'"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtboxUserId" runat="server" ></asp:TextBox><a class="error">*</a></td>

			</tr>
			<tr>
				<td class="auto-style4">
					<asp:Label ID="lblPass" runat="server" Text="Password" CssClass="auto-style7"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtboxPassword" runat="server" TextMode="Password"></asp:TextBox><a class="error">*</a></td>
			</tr>

			<tr>
				<td colspan="2" class="text-center" >
					<asp:Button ID="btnLogin" runat="server" Text="Login" OnClientClick="javascript:return SysNoValidate();" OnClick="btnLogin_Click" />
				</td>

			</tr>

		</table>

	</asp:Content>
