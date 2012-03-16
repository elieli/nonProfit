<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pageing.ascx.cs" Inherits="pageing" %>

 
<link rel="stylesheet" type="text/css" href="css/style.css"  />


 



<div class="title_row">
      <%--  <h2>Ipod Touch Auctions</h2>
        <a href="#" class="read_all">Browse All Red Cross Items ></a>
       --%>
       
       
       
       
       
       
       
        <%--<ul class="nav">
          <li><a href="#">< Previous</a></li>
          <li class="active"><a href="#">1</a></li>
          <li><a href="#">2 </a></li>
          <li><a href="#">3 </a></li>
          <li><a href="#">4 </a></li>
          <li><a href="#">5 </a></li>
          <li><a href="#">6 </a></li>
          <li><a href="#">7 </a></li>
          <li><a href="#">8 </a></li>
          <li><a href="#">Next ></a></li>
        </ul>--%>
        <div class="select_row"> <span class="select">  items per page  </span> 
        
        
         <asp:DropDownList  OnSelectedIndexChanged="PageSize"  CssClass=""    runat="server"   AutoPostBack="true"   ID="drplstPageSize" >
             <asp:ListItem  Value="16"   Text="16"></asp:ListItem>
             <asp:ListItem  Value="32"  Text="32"></asp:ListItem>
              <asp:ListItem  Value="64"  Text="64"></asp:ListItem> 
              <asp:ListItem  Value="128" Text="128"></asp:ListItem>  
                </asp:DropDownList>
        
     
        
        </div>
      </div>
    
    
    
    
    
      <div class="prodcts_row">
      
       <div class="title_row">
          <ul class="nav">
            <li>
            
            
     <%--       <a href="#">< Previous  </a>--%>
            
            
            
            
            
            
            <asp:LinkButton  OnClientClick ="javascript:loc('#t1');" runat="server"  
              id="FirstPage"    Text="<<"     OnCommand="NavigationLink_Click" CommandName="First"     />
             <asp:LinkButton runat="server"       id="PreviousPage" Text="< Previous"
        OnCommand="NavigationLink_Click" CommandName="Prev"    />
            
            
            
            
            
            
            
            
          </li>
            <li class="active"><%--<a href="#">1</a>--%>
            
             <asp:DropDownList OnSelectedIndexChanged="CPage" AutoPostBack="true"  runat="server"  ID="drplstCPage" >
                             </asp:DropDownList>
            
         &nbsp  of      &nbsp             <asp:Label id="TotalPages"   
            runat="server" />
       
            
            
            </li>
           <%-- <li><a href="#">2 </a></li>
            <li><a href="#">3 </a></li>
            <li><a href="#">4 </a></li>
            <li><a href="#">5 </a></li>
            <li><a href="#">6 </a></li>
            <li><a href="#">7 </a></li>
            <li><a href="#">8 </a></li>--%>
            <li><%--<a href="#">Next ></a>--%>
            
             <asp:LinkButton runat="server"  

              id="NextPage" Text="Next >"

        OnCommand="NavigationLink_Click" CommandName="Next" 
      />
   
             <asp:LinkButton runat="server" 

              id="LastPage" Text=">>"

        OnCommand="NavigationLink_Click"  OnClientClick ="javascript:loc('#t1');" CommandName="Last" 
      />
            
            
            
            </li>
          </ul>
        </div>
      
      
      
      </div>

















 