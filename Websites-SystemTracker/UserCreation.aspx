<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserCreation.aspx.cs" Inherits="UserCreation"  MasterPageFile="~/MasterPage.master"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

		
	<script type="text/javascript">

		function SysNoValidate() {

			var UserID = document.getElementById("<%=txtboxUserId.ClientID %>").value;
			var Password = document.getElementById("<%=txtboxPassword.ClientID %>").value;
			var Email = document.getElementById("<%=txtboxEmail.ClientID %>").value;
			var Name = document.getElementById("<%=txtboxName.ClientID %>").value;
			var e = document.getElementById("<%=DrpRole.ClientID%>");
			var strUser1 = e.options[e.selectedIndex].text;
			if (strUser1 == "--Select--") //for text use if(strUser1=="Select")  
			{
				document.getElementById("<%=lblMessage.ClientID %>").innerHTML = "Please select Role";
				return false;
			}

			if (UserID == "") {
				document.getElementById("<%=lblMessage.ClientID %>").innerHTML = "Enter User ID ";
				return false;
			}
			if (Password == "") {

				document.getElementById("<%=lblMessage.ClientID %>").innerHTML = "Enter Password";
				return false;
			}

			if (Email == "") {

				document.getElementById("<%=lblMessage.ClientID %>").innerHTML = "Enter Email";
				return false;
			}

			if (Name == "") {

				document.getElementById("<%=lblMessage.ClientID %>").innerHTML = "Enter Name";
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

		.error {
			color: red;
			font-size: medium;
		}

		tr:nth-child(even) {
			background-color: #dddddd;
		}
		.auto-style1 {
			height: 84px;
		}
		.auto-style2 {
			font-size: x-large;
			text-decoration: underline;
		}
		.auto-style3 {
			float: left;
			height: 66px;
			font-size: x-large;
			line-height: 20px;
			width: 785px;
			text-decoration: underline;
			margin-top: -5px;
			padding: 15px;
		}
		.auto-style4 {
			width: 197px;
			height: 84px;
			text-align: center;
			margin-top: 0px;
		}
		.auto-style5 {
			color: red;
			font-size: x-large;
		}
	</style>



		<table>
			<tr>
				<th colspan="2" class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong><span class="auto-style3">&nbsp;SINGLE USER</span></strong></th>

			</tr>
			<tr>
				<td colspan="2" class="text-center"><strong><asp:Label ID="lblMessage" runat="server" CssClass="auto-style5"></asp:Label></strong></td>

			</tr>
			<tr>
				<td>
					<asp:Label ID="lblUserId" runat="server" Text="User Id"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtboxUserId" runat="server" ></asp:TextBox><a class="error">*</a></td>

			</tr>
			<tr>
				<td>
					<asp:Label ID="lblPass" runat="server" Text="Password"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtboxPassword" runat="server" TextMode="Password"></asp:TextBox><a class="error">*</a></td>
			</tr>

			
			<tr>
				<td>
					<asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtboxEmail" runat="server" TextMode="Email"></asp:TextBox></td>
			</tr>

			<tr>
				<td>
					<asp:Label ID="lblName" runat="server" Text="Full Name"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtboxName" runat="server" ></asp:TextBox><a class="error">*</a></td>
			</tr>

			<tr>
				<td>
					<asp:Label ID="lblRole" runat="server" Text="Role"></asp:Label></td>
				<td>
					<asp:DropDownList ID="DrpRole" runat="server"></asp:DropDownList><a class="error">*</a></td>
			</tr>
			<tr>
				<td colspan="2" >
					<asp:Button ID="btnCreate" runat="server" Text="Create" OnClientClick="javascript:return SysNoValidate();" OnClick="btnCreate_Click" />
				</td>

			</tr>

			

		</table>
	<div>
		<h1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (OR)</h1>
	</div>
	<table>
		<tr>
				<th colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="auto-style2"> </span><strong><span class="auto-style2">Bulk Upload</span></strong></th>

			</tr>
		<tr> 
				<td> <asp:Label ID="lblUpload" runat="server" Text="Upload Using File"></asp:Label></td>
				<td  >
					<asp:FileUpload ID="FileUpload1" runat="server" />
					 <asp:Button ID="Button1" runat="server" Text="Export"  OnClick="btnUpload_Click" />
				</td>
			
			</tr>
	</table>
	

	
	
	</asp:Content>

