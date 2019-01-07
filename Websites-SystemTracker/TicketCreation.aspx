<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TicketCreation.aspx.cs" Inherits="TicketCreation" MasterPageFile="~/MasterPage.master"%>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript">

		function SysNoValidate() {
			
			var SysNo = document.getElementById("<%=txtboxSystemNo.ClientID %>").value;
			var LabNo = document.getElementById("<%=txtboxLabNo.ClientID %>").value;
			var Desc = document.getElementById("<%=txtboxTktDesc.ClientID %>").value;

			if (LabNo == "") {
				document.getElementById("<%=lblError.ClientID %>").innerHTML = "Enter Lab Number";
				return false;
			}
			if (SysNo == "") {

				document.getElementById("<%=lblError.ClientID %>").innerHTML = "Enter System Number";
				return false;
			}
				

				if (SysNo == "") {
					document.getElementById("<%=lblError.ClientID %>").innerHTML = "Enter System Number";
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
			width: 833px;
			text-decoration: underline;
			margin-top: -5px;
			padding: 15px;
		}
	</style>
			<table>

			<tr>
				<th colspan="2" class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong><span class="auto-style3">
					
						&nbsp;Ticket Creation
					</span></strong></th>

			</tr>
			<tr>
				<td colspan="2" class="auto-style5"><asp:Label ID="lblError" runat="server" CssClass="error" Height="16px" Width="251px"></asp:Label></td>

			</tr>
			<tr>
				<td colspan="2"><asp:Label ID="lblMessage" runat="server"></asp:Label></td>
				
			</tr>
			<tr>
				<td>
					<asp:Label ID="lblLabNo" runat="server" Text="Lab Number"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtboxLabNo" runat="server" ></asp:TextBox><a class="error">*</a></td>

			</tr>
			<tr>
				<td>
					<asp:Label ID="lblSystemNo" runat="server" Text="System Number"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtboxSystemNo" runat="server" Text=""></asp:TextBox><a class="error">*</a></td>
			<td><asp:Label ID="sysvald" runat="server" ></asp:Label></td>
			</tr>
				
			
		

			<tr>
				<td>
					<asp:Label ID="lblTktDesc" runat="server" Text="Ticket Description"></asp:Label></td>
				<td>
					<asp:TextBox ID="txtboxTktDesc" runat="server" ></asp:TextBox></td>
			</tr>

			
			<tr>
				<td colspan="2" >
					<asp:Button ID="btnCreate" runat="server" Text="Create" OnClientClick="javascript:return SysNoValidate();" OnClick="btnCreate_Click" />
				</td>

			</tr>
				</table>
	</asp:Content>


