<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HOD_Tickets.aspx.cs" Inherits="HOD_Tickets" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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

		.error {
			color: red;
			font-size: medium;
		}
	</style>


	
		<table style="width:100%;">  
        <tr>  
            <td>
		<asp:GridView ID="gridHTview" runat="server"

 AutoGenerateColumns="False" DataKeyNames="Ticket_ID"

 OnPageIndexChanging="gridHTview_PageIndexChanging"
			OnRowCancelingEdit="gridHTview_RowCancelingEdit"
			OnRowDeleting="gridHTview_RowDeleting" OnRowEditing="gridHTview_RowEditing"
			OnRowUpdating="gridHTview_RowUpdating" ShowFooter="true" OnRowDataBound="gridHTview_OnRowDataBound">

			<Columns>  
                        <asp:TemplateField HeaderText="Ticket ID">  
                              
                            <ItemTemplate>  
                                <asp:Label ID="lblTicket_ID" runat="server" Text='<%# Bind("Ticket_ID") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Lab No">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="lblLab_No" runat="server" Text='<%# Bind("Lab_No") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField> 
						<asp:TemplateField HeaderText="System No">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="lblSystem_No" runat="server" Text='<%# Bind("System_No") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
						<asp:TemplateField HeaderText="User ID">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="lblUserID" runat="server" Text='<%# Bind("User_ID") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
						<asp:TemplateField HeaderText="Ticket Desc">  
                             
                            <ItemTemplate>  
                                <asp:Label ID="lblTicket_Desc" runat="server" Text='<%# Bind("Ticket_Desc") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
				<asp:TemplateField HeaderText="Service Desc">  
					 
                            <ItemTemplate>  
                                <asp:Label ID="Ticket_Desc" runat="server" Text='<%# Bind("Service_Desc") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
						<asp:TemplateField HeaderText="Assigned To">  
                            
                            <ItemTemplate>  
                                <asp:Label ID="Assigned_To" runat="server" Text='<%# Bind("Assigned_To") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
						<asp:TemplateField HeaderText="Status">  
                            
                            <ItemTemplate>  
                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
				<asp:TemplateField  HeaderText="Created on" >  
                             
                            <ItemTemplate>  
                                <asp:Label ID="lblCreated" runat="server" Text='<%# Bind("Created_on") %>'></asp:Label>  
                            </ItemTemplate>
					</asp:TemplateField>  
				<asp:TemplateField  HeaderText="Completed on" > 
				<ItemTemplate>  
                                <asp:Label ID="lblCompleted" runat="server" Text='<%# Bind("Completed_on") %>'></asp:Label>  
                            </ItemTemplate>
					</asp:TemplateField>  
				<asp:TemplateField HeaderText="HOD Approval">  
                            <EditItemTemplate>
                        <asp:DropDownList ID="HOD_Approval" runat="server" SelectedValue='<%# Bind("HOD_Approval") %>'>  
                                   
                                    <asp:ListItem>Not Approved</asp:ListItem>  
							<asp:ListItem>Approved</asp:ListItem> 
							
                        </asp:DropDownList>
                    </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="lblHodApp" runat="server" Text='<%# Bind("HOD_Approval") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
				<asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150"/>
                    </Columns>  
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />  
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />  
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />  
                    <RowStyle BackColor="White" ForeColor="#003399" />  
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />  
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />  
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />  
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />  
                    <SortedDescendingHeaderStyle BackColor="#002876" />  
                </asp:GridView>  

			
			</td>  
        </tr>  
    </table>  
</asp:Content>





















		