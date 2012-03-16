<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Auction.aspx.cs" MasterPageFile="~/Site.master"  Inherits="Auction" %>
  

   <%@ Register src="org_Products.ascx" tagname="orgProducts" tagprefix="uc1" %>
  



            <asp:Content ID="Content1" ContentPlaceHolderID="Headers" runat="Server"> </asp:Content>
            <asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="Server">
                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"> 
                    <ContentTemplate> 
                 <%--   <%= Message %>--%><meta http-equiv="Content-Type" content="text/html; charset=utf-8" /><title>Non Profit</title><link href="app_themes/yekatheme/style.css" rel="stylesheet" type="text/css" /><style type="text/css">
                    .secondnav_strip ul li{background:url('App_Themes/YekaTheme/images/nav_seperator.jpg') no-repeat right 50%;}
                    .body_parttwo{          background:#580000 url(<%= ResolveUrl("App_Themes/YekaTheme/images/bodyseperator.jpg") %>  no-repeat 50% top; }           
           #footer{background:url(<%= ResolveUrl("App_Themes/YekaTheme/images/footerbg.jpg") %>) repeat-x;
            }
            .footer_container{
            background: url(<%= ResolveUrl("App_Themes/YekaTheme/images/footer.jpg") %>) no-repeat center top;
            }
            .box{background:url(<%= ResolveUrl("App_Themes/YekaTheme/images/box.jpg") %>) no-repeat; 
            }
            .box_one{background:url(<%= ResolveUrl("App_Themes/YekaTheme/images/box.jpg") %>) no-repeat; 
            }
            .iconbg{background: url(<%= ResolveUrl("App_Themes/YekaTheme/images/facebookbg.jpg") %>) no-repeat; 
            }
            .greyboxtop{background: url(<%= ResolveUrl("App_Themes/YekaTheme/images/boxtop.jpg") %>) no-repeat 50% top; 
            }
            .greyboxtopmid{background:url(<%= ResolveUrl("App_Themes/YekaTheme/images/boxback.jpg") %>) no-repeat;
            }
            .greyboxbottom{background: url(<%= ResolveUrl("App_Themes/YekaTheme/images/boxbottom.jpg") %>)no-repeat 50% bottom;
            }
            .white_heading{background:url(<%= ResolveUrl("App_Themes/YekaTheme/images/arrow.jpg") %>) no-repeat left 50%;
            }
          .greyboxseperator{background: url(<%= ResolveUrl("App_Themes/YekaTheme/images/dottedseperator.jpg") %>) no-repeat 50% bottom;
            } 
            .whitebox{background:url(<%= ResolveUrl("App_Themes/YekaTheme/images/whitebox_bg.jpg") %>) repeat-y; 
            }
            
            .greybox{background:url(<%= ResolveUrl("App_Themes/YekaTheme/images/boxbg.jpg") %>) repeat-y;
width:266px;
float:left;
}
            
            .whiteboxtop{background: url(<%= ResolveUrl("App_Themes/YekaTheme/images/boxtop.jpg") %>) no-repeat 50% top; 
            }   
               .whiteboxbottom{background: url(<%= ResolveUrl("App_Themes/YekaTheme/images/whitebox_bottom.jpg") %>)  no-repeat 50% bottom; 
            }   
            .logo{
            font-family:Arial, Helvetica, sans-serif;
            font-size:13px;
            color:#434343;
            text-decoration:none;
            font-weight:bold;
            border-top:1px solid #dbdbdb;
            border-collapse:collapse;
            }
                  
                .greybox{
            background:url('App_Themes/YekaTheme/images/boxbg.jpg') repeat-y;
            width:266px;
            float:left;
            }
  
               .greyboxseperator{
background: url('App_Themes/YekaTheme/images/dottedseperator.jpg') no-repeat 50% bottom;
width:222px;
float:left;left:0px; margin-left:15px; padding-left:30px;
height:1px;
margin:10px 0px;
}   
                     
                    </style><div id="body_container">
  
  
  
  
    <div id="left_container">
      <div class="read_cross"> <img src="imgs/cross.gif" alt="" /><a href="#" class="denote"></a><a href="#" class="about_org">About this Organization</a></div>
      <div class="did_u_know">
        <h2>Did You Know</h2>
       
      <p  id="dvKnow" >     <textarea runat="server" cols="15" rows="40" id="txtarKnow"></textarea></p> 
      
      <%-- 
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam euismod orci sed ipsum ornare gravida. Ut nulla eros, tempus non malesuada eu, ornare at diam. Suspendisse dolor neque, accumsan vitae pretium id, adipiscing id nisi. Vestibulum ligula odio, rutrum quis tristique nec, dictum id lacus. Mauris pharetra odio sed diam vehicula sed semper lacus aliquet. Integer viverra convallis luctus. Maecenas eget orci eget neque porta ultrices. Proin dolor nibh, bibendum tempor commodo a, elementum nec metus. Nulla quis rutrum quam. Aliquam erat volutpat.</p>
        <p> Suspendisse dolor neque, accumsan vitae pretium id, adipiscing id nisi. Vestibulum ligula odio, rutrum quis tristique nec, dictum id lacus. Mauris pharetra odio sed diam vehicula sed semper lacus aliquet. Integer viverra convallis luctus. Maecenas eget orci eget neque porta ultrices. Proin dolor nibh, bibendum tempor commodo a, elementum nec metus.</p>
--%></div>
    </div>
    
    
       <%--  <a   runat="server" id="A2"  href="#"  onclick="window.open('BuyCredits.aspx','','scrollbars=yes,menubar=no,height=560,width=650,resizable=no,toolbar=no,location=no,status=no');
                        "  title="Buy Credits">
                        Buy Credits</a>--%>
    
    
    <div id="right_container">
      
      
      <div class="top_row">
        <ul class="links">
          <li class="first"><a href="#">AMERICAN RED CROSS</a></li>
          <li><a href="#">AUCTIONS</a></li>
          <li><a href="#">IPOD TOUCH</a></li>
        </ul>
        <p>You have <a href="#"  onclick="window.open('BuyCredits.aspx','','scrollbars=yes,menubar=no,height=560,width=650,resizable=no,toolbar=no,location=no,status=no');
                        " ><em> <em    class="spn_cover" id="spn_credits_cover" ></em>  <em  id="spncredits" ></em></em> </a> available credits. (<a href="#"    onclick="window.open('BuyCredits.aspx','','scrollbars=yes,menubar=no,height=560,width=650,resizable=no,toolbar=no,location=no,status=no')"        >Purchase Credits</a>) </p>
        <br />
        <p>Confused? <a href="#">Click here</a></p>
      </div>
     
     
      <div class="title_row">
        <h2  ><%=bigTitle%></h2>
        <a href="#" class="read_all">&nbsp;&lt; Back To Search Results</a>&nbsp;| &nbsp; <a href="#" class="read_all">&nbsp;Browse All Red Cross Items ></a></div>
    
    
    
    
      <div class="prodcts_details">
        
        <div class="col1">
        
        
        
          <div class="large_view">          
           <div style="   overflow:hidden; " align="center"><a id="lnkFullImage" href='<%=LinkToFullImage %>' rel="lightbox" title='<%=ImageDesc %>'
                                                    rev="" class="">                                                 
                                                   <img id="imgMediumImage" style=" border:solid  0px pink;" src='<%=MediumImageUrl %>' alt='<%=ImageDesc %>'  height="439"/></a>
                                                   </div> 
                                                   
         <%-- <img id="Img1" src="imgs/img01.jpg" alt="" /> --%><img  src=" " alt="" /><div class="top_strip"><span class="icons">
               <img src='imgs/social_icons.gif' alt="" width="174" height="26" border="0" /></a><%--<img src="imgs/social_icons.gif" alt="" />--%></span><a href="#" class="large_views"></a>
               
               </div>
          </div>
            
            
            
            
            
            
             <asp:ListView ID="iqimagesThumb"   runat="server">
                                   
                                       <LayoutTemplate>
                                        <asp:PlaceHolder id="itemPlaceholder" runat="server" /> 
                                    </LayoutTemplate>
                                   
                                  
                                    <ItemTemplate>
                                  
                                     <%--   <div style=" width:80px;   float:left;  ">--%>
                                          
                              <ul class="thumbs"> <li>
                                            <a href='<%# Eval("FullImageUrl") %>'  title='<%# Eval("ImageDesc") %>'
                                                rev="" class="styleLightBox" >
                                                <img class="img2" 
                                              <%--  style=" border:solid 2px white; padding-right:0px;  max-height:80px;  max-width:63px; min-height:80px; min-width:63px;"  --%>
                                                
                                                id="imgThumb<%# Eval("Id") %>" src='<%# Eval("ThumbImageUrl") %>' alt='Deal <%# Eval("ImageDesc") %>'
                                                    
                                                
                                                
                                                
                                                
                                                onmouseover='javascript:changeMainImage("<%# Eval("MediumImageUrl") %>","<%# Eval("FullImageUrl") %>");' /></a>
                                                </li> </ul>
                                    </ItemTemplate>
                                 
                                 
                            </asp:ListView>

            
            
            
         <%--
          <ul class="thumbs">
            <li><a href="#"><img src="images/thumb10.jpg" alt="" /></a></li>
            <li><a href="#"><img src="images/thumb10.jpg" alt="" /></a></li>
            <li><a href="#"><img src="images/thumb10.jpg" alt="" /></a></li>
            <li class="last"><a href="#"><img src="images/thumb10.jpg" alt="" /></a></li>
          </ul>--%>
          
          
          
          
          
          
          
          
          <%--width:100%; float:left; padding:20px 0 0 0;  
             <div class="prodcts_details">--%>
          
              <div   class="prodcts_details"  style=" font-size:larger; position:absolute; visibility:hidden;" id="dvSoldout"  ></div>
                 <div   class="prodcts_details" >
          
          
          <ul class="details">
            <li class="link1"><a href="#" onclick="javascript:watchlog('<%=  auction_id  %>')"   >Watch<br />
                
  Item</a></li>
            <li class="link2"><a href="#"    id="A1"    onclick="dimlights();"> 
 
                
  Dim <br />  Lights</a></li>
              
              
              
              
            <li class="link3"><a href="#">Email <br />
 Item</a></li>
            <li class="link4"><a href="#">Print <br />
  Page</a></li>
            <li class="link5"><a href="#">Contact<br />  
  Seller</a></li>
            <li class="link6"><a href="#">Help <br />
  Me</a></li>
          </ul></div>
        </div>
        
          
          
          
          
          <%--
          <ul class="details">
            <li class="link1"><a href="#" onclick="javascript:watchlog('<%=  auction_id  %>')"   >Watch<br />
                
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Item</a></li>
            <li class="link2"><a href="#"    id="dimlights"    onclick="dimlights();">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim <br />&nbsp;&nbsp;&nbsp;&nbsp; Lights</a></li>
              
              
              
              
            <li class="link3"><a href="#">Email <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Item</a></li>
            <li class="link4"><a href="#">Print <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Page</a></li>
            <li class="link5"><a href="#">Contact<br />&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Seller</a></li>
            <li class="link6"><a href="#">Help <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me</a></li>
          </ul>
        </div>
        --%>
        
        
        
        
        
        
        
        
        <div   style="position:relative;" > 
        
        
        
         <input type="hidden" id="counterx"    />   
        
        
                <input id="MediumImageUrl1" type="hidden"/><input id="MediumImageUrl2" type="hidden"/><input id="MediumImageUrl3" type="hidden"/><input id="FullImageUrl1" type="hidden"/><input id="FullImageUrl2" type="hidden"/><input id="FullImageUrl3" type="hidden"/><div class="bid_col">
          <p>TIME REMAINING:</p>
        <%--  <p     id="countbox" class="timer"><%--1:02:03</p> --%>
          
            <p     id="countbox" class="timer"> </p>
          <p>CURRENT PRICE:</p>
          <p id="CurrentBidPrice"  class="price"><%--$24.23--%></p>
         <%-- <p> <asp:Label ID="lblShipping" runat="server"  class="price" ForeColor="" 
                                  Text=""></asp:Label><%--+ $7.99 Shipping FedEx 2nd Day- </p>--%>
         
         <%--  <p   ID="lblShipping" runat="server"  class="price" >             </p>--%>
               <p      ID="lblHandling" runat="server"  class="price" >               </p>
               
              
              
              
              
             
                
                     
               
               
          <a href="#"   id="bidbtn"       onclick= "  javascript:setBids('<%= auction_id %>'); return false; " class="btn"></a>
      
         
         
          <p>Funds go to the <br />
 &nbsp;&nbsp;&nbsp;&nbsp; American Red Cross <%=  org_name  %></p>
          <h5>Current Highest Bidder</h5>
          <h6 id="HighestBidder"><%--ilovecharity102--%></h6>
        </div>
       
       
       </div>
       
        <div style="position:absolute;">   <em      id="bidbtnCredits"   class="price" style="position:absolute; left:-9999px;     " ><span  >Please purchase more credits<br /> to enable bidding </span>  </em>
               
                   <em      id="bidbtnWinner"   class="price" style="position:absolute; left:-9999px;  margin-left:10px;   " > 
                   
                  Congraulations <span id="HighestBidder1"> </span>   you are a winner !!!        </em>
    </div>
          <div>
        <%--<div class="col3">
          <h3>BIDDING LOG</h3>--%>
          
          
          
          
            </div>
          
          
          
          
          
          
          
          <div  class="col3">
          <h3>BIDDING LOG</h3>
         <%-- <div class="sub_col1">
           <%-- <ul class="p_lists">
              <li><a href="#">ilovechartiy1...</a><span>$24.23</span></li>
              <li><a href="#">Seven4Seven</a><span>$24.23</span></li>
              <li><a href="#">Tiawanarex</a><span>$24.23</span></li>
              <li><a href="#">Ashleylarow</a><span>$24.23</span></li>
              <li><a href="#">sunnysideup</a><span>$24.23</span></li>
              <li><a href="#">letmekno112</a><span>$24.23</span></li>
            </ul>- 
            <img src="imgs/scroll.gif" alt="" /> </div>           
            
          <h3 class="top_padd">SPONSORED BY</h3>
          
          <div class="sub_col1 spons">
            <p> Mr. Michael Avis<br />
              <a href="www.aviselectronics.com">www.aviselectronics.com</a></p>
            <p>Mr. Rachel Blanche<br />
              <a href="www.artfinishing.com">www.artfinishing.com</a></p>
            <h5>SPONSOR A<br />
              PRODUCT</h5>
          </div>
        </div>
          --%>
          
          
          
          
          
          
          
          
          
          
          
          
          
          
          
          
          
          
          
          
          <div     class="sub_col1">
             <ul id="dvbidders" style="height:140px;" class="p_lists">
                     
         
            <%--  <li><a href="#">ilovechartiy1...</a><span>$24.23</span></li>
              <li><a href="#">Seven4Seven</a><span>$24.23</span></li>
              <li><a href="#">Tiawanarex</a><span>$24.23</span></li>
              <li><a href="#">Ashleylarow</a><span>$24.23</span></li>
              <li><a href="#">sunnysideup</a><span>$24.23</span></li>
              <li><a href="#">letmekno112</a><span>$24.23</span></li>--%>
            </ul>
        <%--    <img src="imgs/scroll.gif" alt="" />--%>
            
            </div>
         
         
         
          <h3 class="top_padd">SPONSORED BY</h3>
          
         
          
          
          
          
          <div  id="dvsponsors"   class="sub_col1 spons" style="overflow:hidden;" >
          
           
          
          
           <%-- <p>&nbsp;Mr. Michael Avis<br />
              <a href="www.aviselectronics.com">www.aviselectronics.com</a></p>
            <p>Mr. Rachel Blanche<br />
              <a href="www.artfinishing.com">www.artfinishing.com</a></p>--%>
           
              
              
          </div>
        <%--  #right_container .prodcts_details .col3 h5 { background-color:#ea8024; font-size:14px; line-height:16px; color:#fff; font-weight:normal; text-transform:uppercase; text-align:center; padding:9px 0 10px 0; float:left; width:100%; }
--%>
           
           <h5 class="top_padd" style="overflow:hidden;" >
            
            <a     href="#"    onclick="javascript:sponsor('<%= auction_id%>');"   >&nbsp;SPONSOR A<br />
                                PRODUCT
  </a> 
              </h5>
          
          
          
        
           </div>
        
        
        
        
        
        
        <div id="bottom_row" class="bottom_row">
          <div class="discription">
            <h2>Description</h2>
            <p id="Description" runat="server">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam euismod orci sed ipsum ornare gravida. Ut nulla eros, tempus non malesuada eu, ornare at diam. Suspendisse dolor neque, accumsan vitae pretium id, adipiscing id nisi. Vestibulum ligula odio, rutrum quis tristique nec, dictum id lacus. Mauris pharetra odio sed diam vehicula sed semper lacus aliquet. Integer viverra convallis luctus. Maecenas eget orci eget neque porta ultrices. Proin dolor nibh, bibendum tempor commodo a, elementum nec metus. Nulla quis rutrum quam. Aliquam erat volutpat. </p>
            <p>&nbsp;Mauris faucibus neque a nulla porttitor in lobortis orci pulvinar. In hac habitasse platea dictumst. Ut lobortis, eros hendrerit laoreet fringilla, velit leo imperdiet arcu, ut cursus erat dui non justo. Aenean pulvinar blandit justo, eu sodales est aliquet et. Pellentesque aliquet, mauris quis eleifend blandit, justo arcu gravida lorem, id hendrerit ligula purus sed felis. Praesent vel dolor eu felis ultricies pulvinar vitae nec felis. Fusce nec consectetur quam. Proin eu urna tortor. Etiam fermentum iaculis leo, vel convallis neque porttitor ut. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus id sollicitudin nisi. </p>
          </div>
          
          
          
          
          
          <div class="sub_col2">
            <h3>WHAT’S INCLUDED</h3>
            <ul>
              <li id="iteminc1"  runat="server" >Otterbox Defender Case</li>
              <li id="iteminc2"  runat="server" >Earbuds</li>
              <li id="iteminc3"  runat="server" >1 Year Apple Care</li>
              <li id="iteminc4"  runat="server" >Workout Arm Band</li>
              <li id="iteminc5"  runat="server" >External Speakers</li>              
              <li id="Li1"  runat="server" >External Speakers</li>
            </ul>
          </div>
          
          
          
          
          
          
          
          
          
          
          
          
          
        </div>
      </div>
    </div>
  
  
  
  
    <div id="home_page">
      <div id="auction_row" class="border_none">
        <h2>Ongoing Red Cross Auctions</h2>
        <a class="all_r_cross" href="#">Browse All Red Cross Items ></a><div class="auction_clear"></div>
        <ul >
         
         
             <uc1:orgProducts ID="orgProducts2" runat="server" />
         
         
         <%-- <li><img src="images/thumb01.jpg" alt="" /><h3>Ipod Touch 4th Generation + Protective Case</h3>
            <p class="timer">1:02:03</p>
            <p class="price">$24.23</p>
            <a href="#" class="btn"></a> </li>
          <li><img src="images/thumb02.jpg" alt="" /><h3>Ipod Touch 4th Generation + Protective Case</h3>
            <p class="timer">1:02:03</p>
            <p class="price">$24.23</p>
            <a href="#" class="btn"></a> </li>
          <li><img src="images/thumb03.jpg" alt="" /><h3>Ipod Touch 4th Generation + Protective Case</h3>
            <p class="timer">1:02:03</p>
            <p class="price">$24.23</p>
            <a href="#" class="btn"></a> </li>
          <li><img src="images/thumb04.jpg" alt="" /><h3>Ipod Touch 4th Generation + Protective Case</h3>
            <p class="timer">1:02:03</p>
            <p class="price">$24.23</p>
            <a href="#" class="btn"></a> </li>--%>
        </ul>
      </div>
    </div>
  </div>
  
  
  
  
  
  
  <input type="hidden" id="Hidden1"    />                       
                                                      <input type="hidden" id="Hidden2"    />            
                                                      <input type="hidden" id="Hidden3"    />            
                                                    
  
  
        
        
        
        
         <div id="dvsponsorItem" style=" visibility:hidden; width:50px; height:60px;" >
               
               <span>Number of credits: <input id="ncredits" type="text" /> </span>
               
           
               
               </div>
        
        
           <asp:TextBox ID="txtBidamount" runat="server"  Visible="false" Font-Bold="true" ForeColor="" 
                                  Text=""></asp:TextBox>
                                  
        
        
         
                                  
        
        
        
        <asp:Label    runat="server" ID="lblSold"  ></asp:Label> 
        
        
        
        
                         <asp:Label runat="server"  Visible="false" ID="lblCartPrice" ></asp:Label> 
        
        
        
         
                                                   
        
        
        
       <div id="dvlstCreditLog"   ></div> 
        
        
         <asp:Label runat="server" ID="lblCreditsUsed"  Visible="false" ></asp:Label>   
                                                   
                                                    <asp:Label runat="server" Visible="false" ID="lblMoneySpent" ></asp:Label> 
                                                   
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
       <%-- <div style=" border:solid 1px white; width:100%; height:2020;  position:relative;" > 
          
         
          <div  id="dvKnow"  class="body_partone_inner"  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; style=" border:solid 1px white; width:51px; height:459px;  float:left; top: 0px; left: 0px;" >
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <p>Did You Know?</p>
       <%--    <textarea runat="server" cols="50" rows="100" id="txtarKnow"> </textarea>- </div>
        
       <%-- <div    class="body_partone_inner" style=" border:solid 1px white; width:1280;  position:relative;" >
        
        
        
        
        
        
        
        
        
        
                        <div runat="server" id="body_partone_1"  style=" border:solid 0px pink;position:relative;"   class="body_partone_1">
                 
                <input id="prefex1d"  name="prefex1" type="hidden"  value='<asp:Literal   runat="server" ID="prefexD"></asp:Literal>'   /><%-- <div style="   overflow:hidden; " align="center"><a id="lnkFullImage" href='<%=LinkToFullImage %>' rel="lightbox" title='<%=ImageDesc %>'
                                                    rev="" class="styleLightBox">
                                                    
                                                    
                                                 
                                                   <img id="imgMediumImage" style=" border:solid  0px pink;" src='<%=MediumImageUrl %>' alt='<%=ImageDesc %>'  height="439"/></a>
                                                   
                                                       
                                                   </div> - <div   style=" border:solid 0px pink;" align="center"><a href="#">
                <img src='<%= ResolveUrl("App_Themes/YekaTheme/images/zoom.jpg") %>' alt="" width="174" height="26" border="0" /></a></div>

 
                 
                 
                 <input type="hidden"  /><%--  <asp:HyperLink runat="server"   OnClick="buyCredits" Text="Buy Now" />       </p>
--%><%-- <div   id="BuyCredits"  style=" width:250px; height:350px;"    >
                
                
                </div>
 <div   style="  width:500px;  padding-left:2px; left:0px; margin-left:42px; position:absolute;"> 
                 
               <%-- <div style="  float:left;  position:relative;   top:13px;    "> 
                <asp:ImageButton  ID="ImgBtnOvleft"    CommandName="ImgBtnOvleft" CommandArgument="left"  OnCommand="otherView" runat="server" src="App_Themes/YekaTheme/images/leftarrow.jpg"   SkinID="iqViewOtherrightarrow"      height="73" alt="jomadeals"  class="img2"/>
                </div>- <div style="float:left;   position:relative;  "  > 
               

                   <%-- <asp:ListView ID="iqimagesThumb"   runat="server">
                                   
                                       <LayoutTemplate>
                                        <asp:PlaceHolder id="itemPlaceholder" runat="server" /> 
                                    </LayoutTemplate>
                                   
                                  
                                    <ItemTemplate>
                                  
                                        <div style=" width:80px;   float:left;  ">
                                            <a href='<%# Eval("FullImageUrl") %>'  title='<%# Eval("ImageDesc") %>'
                                                rev="" class="styleLightBox" >
                                                <img class="img2" 
                                                style=" border:solid 2px white; padding-right:0px;  max-height:80px;  max-width:63px; min-height:80px; min-width:63px;"  
                                                
                                                id="imgThumb<%# Eval("Id") %>" src='<%# Eval("ThumbImageUrl") %>' alt='Deal <%# Eval("ImageDesc") %>'
                                                    
                                                
                                                
                                                onmouseover='javascript:changeMainImage("<%# Eval("MediumImageUrl") %>","<%# Eval("FullImageUrl") %>");' /></a></div>
                                    </ItemTemplate>
                                 
                                 
                            </asp:ListView>
 </div>

                     <%--  <div style="  float:left;   top:13px;  padding-top:10px; padding-left:1px;  "> 
                    <asp:ImageButton  ID="ImgBtnOvright" runat="server" src='App_Themes/YekaTheme/images/rightarrow.jpg'  OnCommand="otherView"  CommandArgument="right"  SkinID="iqViewOtherrightarrow"       height="73" alt="jomadeals"  />
                    </div>-- <%-- style='<%# Eval("style") %>; display:block; border:solid 2px black; width:12px; height:12px;'>-- <div  style="    float:left;   padding-left:34px;  position:relative;   clear:left;">

 

                    <asp:DataList ID="lvDisplayVariations"  RepeatColumns="8"  RepeatDirection="Horizontal"   OnItemDataBound="lvDisplayVariations_OnItemDataBound"  runat="server" GroupItemCount="3" 
                                                        onitemcommand="lvDisplayVariations_ItemCommand">
                                    <ItemTemplate>
                                    <div style=" float:left;  padding:8px 8px 8px 8px;">
                                    <input runat="server"  
                                            id="hdnIndex" type="hidden"   /><a    href='#'    ><div  id="vv" 
                                            runat="server"  class='<%# Eval("CSSClass") %>'    
                                              
                                            style='  display:block; border:solid 2px black; width:12px; height:12px;'> 
                                                
                                            </div>
                                           </a>

                                            <asp:LinkButton   runat="server" Visible="false"   OnClick= "lvItemCommand" 
                                                       ID="btnChangeVariation" Width="32" Height="32"  CommandName="ChangeVariation" 
                                                       CommandArgument='<%# Eval("ItemGuid") %>' ><div class='<%# Eval("CSSClass") %>' 
                                                       style='display:block; border:solid 2px black;  '></div>
                                            </asp:LinkButton><br /><br />
                                      </ItemTemplate>

                </asp:DataList>

                  </div>
                 
                 
                 
                 
                 
                 
                          </div>
                 
                  </div>- 
                 
                 
                 
                 <div  style="  border:solid 1px green;float:left; " class="body_partone_2">
                 
                 
                 
                 
                 
                 
                 <div class="box1_one"> 
                 
                <h1 class="headingone"   > <asp:Label CssClass="headingone" ID="lblProductTitles" runat="server"   
                                              ></asp:Label></h1>

                <div class="">
                <%--<div runat="server" id="box1_one" class="box1_one">
               
               
               
                <p class="normaltext_bold">Retail Price : </p> 
                <p style=" vertical-align:baseline; padding-top:1px;"   class="normaltext_bold">Sale Price :</p>
                <p style=" padding-top:6px;"  class="normaltext_bold">You Save : </p>
                 <h2  class="normaltext_bold"  runat="server" id="freeship" ></b><b></b>Free Shipping<b></b></h2> 
                   </div>- <div style=" position:relative;" class="box1_two">
                    <p class="normaltext_bold">
                        <asp:Label ID="lblRetailPrice" runat="server" Text="" ForeColor="#3C3C3C" Font-Size="10pt" Font-Bold="true"></asp:Label>
                    </p>
                   
                      <p class="normaltext_bold">
                         <%-- <p class="normaltext_bold">End Date : </p>    <asp:Label ID="lblEndDate" runat="server" Text="" ForeColor="#3C3C3C" Font-Size="10pt" Font-Bold="true"></asp:Label>
                          <p>
                          </p>-  <%-- <p class="red_normaltext_bold">
                              Start Bid Price
                           <span style="text-align:right;">    <asp:Label ID="lblStartBidPrice" runat="server" Font-Bold="true" 
                                  ForeColor="" Text=""></asp:Label></span>
                          </p>-- <p class="red_normaltext_bold">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Current Bid Price
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblCurrentBidPrice"   runat="server" Font-Bold="true" 
                                  ForeColor="" Text=""></asp:Label>
                                  <%--  <input id="CurrentBidPrice" type="text" /></p>--%>
                          <%--<p class="red_normaltext_bold">
                              Condition
                              <asp:Label ID="lblCondition" runat="server" Font-Bold="true" ForeColor="" 
                                  Text=""></asp:Label>
                          </p>-- <p class="red_normaltext_bold">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Handling time
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblHandling" runat="server" Font-Bold="true" ForeColor="" 
                                  Text=""></asp:Label>
                          </p>
                          <p class="red_normaltext_bold">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Shipping Cost
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                              
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
                        <%--  <p class="red_normaltext_bold">
                              Auction Type
                              <asp:Label ID="lblAuctiontype" runat="server" Font-Bold="true" ForeColor="" 
                                  Text=""></asp:Label>
                          </p>-- <p  style="visibility:hidden";>&nbsp;class="red_normaltext_bold">
                              Bid Amount
                              
                              
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

<asp:TextBox ID="txtBidamount" runat="server" Font-Bold="true" ForeColor="" 
                                  Text=""></asp:TextBox>
                                  
                                  <input id="Bidamount" type="text" /></p> 
                         <%-- <p class="red_normaltext_bold">
                              Return Days
                              <asp:Label ID="lblReturndays" runat="server" Font-Bold="true" ForeColor="" 
                                  Text=""></asp:Label>
                          </p>--%><%-- <p class="red_normaltext_bold">
                              Buy it Now $
                              <asp:Label ID="lblBuyitNow" runat="server" Font-Bold="true" ForeColor="" 
                                  Text=""></asp:Label>
                          </p>--%><%-- <p class="normaltext_bold">
                              <asp:Label ID="lblYouSave" runat="server" Font-Bold="True" Font-Size="10pt" 
                                  ForeColor="#3C3C3C" Text=""></asp:Label>
                          </p>-- <p class="normaltext_bold">
                          </p>
                          <%--<div style="left:0px; margin-left:0px; position:relative;">
                              <asp:Panel ID="pChildItems" runat="server" visible="false">
                                  <div>
                                      <div align="right" style="float:left;">
                                          <span style="color: #3C3C3C; font-size: 10pt; font-weight: bold;">Color:</span></div>
                                      <span>&nbsp;</span><div align="left" style="float:left;">
                                          <asp:Panel ID="pStyleDisplayVariations" runat="server" visible="false">
                                          </asp:Panel>
                                          <asp:DropDownList ID="ddDisplayVariations" runat="server" AutoPostBack="true" 
                                              class="normaltext_bold" EnableViewState="true" Height="25px" 
                                              onselectedindexchanged="ddDisplayVariations_SelectedIndexChanged" Width="152px">
                                          </asp:DropDownList>
                                      </div>
                                      <div style=" top:0px; margin-top:35px;  padding-top:10px;  position:relative; left:0px; margin-left:-123px;">
                                          <asp:ImageButton ID="btnBuyNowChild" runat="server" alt="jomadeals" border="0" 
                                              class="img4" CommandArgument='<%# Eval("ItemGuid").ToString() %>' 
                                              CommandName="BuyNow" height="28" 
                                              ImageUrl="App_Themes/YekaTheme/images/buynow.jpg" 
                                              onclick="btnBuyNowChild_Click" Text="Buy Now" width="147" />
                                      </div>
                                  </div>
                                  <div>
                                      <div style="float:left;">
                                          <asp:Image ID="Image1" runat="server" ImageAlign="AbsMiddle" SkinID="iqSoldOut" 
                                              Visible="false" />
                                      </div>
                                  </div>
                              </asp:Panel>
                          </div>- <table  id = visible="false">
                              <tr ID="trNormalItem" runat="server" valign="middle" visible="false">
                                  <td>
                                      <asp:Image ID="imagesoldOuta" runat="server" ImageAlign="AbsMiddle" 
                                          SkinID="iqSoldOut" Visible="false" />
                                  </td>
                              </tr>
                              <tr ID="trOutofStocka" runat="server" valign="middle" visible="false">
                                  <td align="left" valign="middle">
                                      <br />
                                  </td>
                              </tr>
                          </table>
                       
                       
                       
                       
                       
                       
                       
                       
                       
                       
                       
                       
                         <%-- <div ID="trOutofStock"   runat="server" 
                              style=" z-index:100;  top:0px; margin-top:30px; left:0px; margin-left:-140px;  width:290px; background-color: #F7FEBA; border: solid 1px black; padding: 4px 4px 4px 4px;">
                              You waited too long, and now we’re sold out. You must be devastated. At least 
                              you can hold on to the hope that tomorrow we’ll have another awesome luxury deal 
                              on the table. Now wipe your tears and go buy yourself a cookie. You’ll feel 
                              better tomorrow.
                          </div>- <div><h1>
                          
                          <div  style=" font-size:larger; visibility:hidden;" id="dvSoldout"  >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Sold To&nbsp; <p id="highestbidder"> </p>&nbsp;&nbsp;&nbsp;&nbsp; Congradulations!!!
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Image ID="Image1" runat="server"  ImageAlign="AbsMiddle" SkinID="iqSoldOut" 
                                      /></div>   
                                  <h1>
                                  
                                  </h1>
                             
                          </div>
                          
                   
                         
                          <div visible="false" ><h1><asp:Label    runat="server" ID="lblSold"  ></asp:Label>    </h1>  
                              <asp:Image ID="imagesoldOut"    runat="server" ImageAlign="AbsMiddle" 
                                  SkinID="iqSoldOut" Visible="false" />
                          </div>
                          
                   
                   
                   
                    </div>

                    </div>
                    
                    
                    
                
                    
                    
                    
                    
                    
   
   
   
   <%--
                   <asp:ImageButton id="btnBuyNow" runat="server"     ImageUrl="App_Themes/YekaTheme/images/buynow.jpg" CommandName="BuyNow" CssClass="img4"
                        CommandArgument='<%# Eval("ItemGuid").ToString() %>' onclick="btnBidNow_Click"  ></asp:ImageButton>
                 - </div>


 <div class="box1_one "> 
 
 
    <%--<div id="hdnTimer"  style="visibility:hidden;" runat="server"   >     </div>     
                   <div id="hdnTimer1"  style="visibility:hidden;"  runat="server"   >     </div>     
                   <div id="hdnTimer2"   style="visibility:hidden;" runat="server"   >     </div>  
              <div id="hdnTimer3"   style="visibility:hidden;" runat="server"   >     </div>     
             
                  <div id="dvAuction"   style="visibility:hidden;" runat="server"   >     </div>     
             
                  <div id="dvBuyer"   style="visibility:hidden;" runat="server"   >     </div>     
                   <div id="hdnamount"   style="visibility:hidden;" runat="server"   >     </div>     - <h4>  <asp:Button runat="server"  Visible="false" Text="Refresh" ID="btnRefresh" />  </h4>
                    
                        <%-- <p>  <a href="#"  id="dimlights"  value="DIM LIGHTS " type="button"   onclick="dimlights();">DIM LIGHTS</a> </p>
                 -- <input id="totNbids" type="hidden" /><div style=" font-size:large; text-align:center;" > <p>&nbsp;Price  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; 
                 
                 <asp:Label runat="server" ID="lblCartPrice" ></asp:Label> 
                    <%--  <input id="CartPrice" type="text" />-- </p> </div>
                    
                    
                   
                    
                       <div style=" text-align:center;" ><p>&nbsp;Shipping &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 
                           
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                           
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%--<asp:Label ID="lblShipping" runat="server" Font-Bold="true" ForeColor="" 
                                  Text=""></asp:Label>-- </p>  </div>
                       <br /><br />
                 
 
 
                       <div style=" text-align:center ;" ><h2>&nbsp;Current Highest Bidder</h2>&nbsp;&nbsp; &nbsp;&nbsp; 
                           
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <p><%--  <asp:Label ID="lblHighestBidder" runat="server" Font-Bold="true" ForeColor="" 
                                  Text=""></asp:Label>-- ><%--  <input id="HighestBidder" type="text" />-- ></p>  </div>
                       
 
 
 
 
 </div>




                     <div class="day"  id="day"  runat="server"  style="   
                    <span class="heading_small"><%=DateTime.Today.Date%></span><br />
                          
                      
 
                    
                    <span class="heading"><b>Penny Bidding</b></span><br />
                    
                    
                    
                    
                    
                    
                    
          
             
             
         
             
             
                    
                    <span class="heading_grey">Time Left: </span><divclass="heading_red">
                   <%-- <div  id="countbox" style="font-size:  15pt; color: Red; font-family: Arial Black;
                                                                            display: inline">
                    </div>--%><%--<script type="text/javascript">
  GetCount();
  </script>
  -- </div>

 
                
                <div style="height:10px; width:2px; "></div>
                
                  <div  id="dvBid">
                  <%--<input type="button" value="GEVALDIKKKKKK" onclick= "javascript:GetCount();return false; " />
                   
                   
                   
                     <input type="button" value="GEVALCAPTURE" onclick= "javascript:capture();return false; " />
               
                    -- <span class="heading_small"    style="background-image:url(App_Themes/YekaTheme/images/buynow.jpg);"           ><%--<input type="button" value="BID" onclick= "  javascript:setBids('<%= auction_id %>'); return false; " />--%><%--  <asp:ImageButton runat="server" AlternateText="Bidder"  Visible="false"  CommandName='bid'  OnClientClick=" javascript:setBids('<%=items().AuctionID %>');;return false;  "  ImageUrl="App_Themes/YekaTheme/images/buynow.jpg"  id="btnBidder"   ></asp:ImageButton></span><br />
                -- </div>                   
                
                 
                </div> 
   
                
                
                
                

                                     <div   id="dvCreditLog" class="body_partone_3"  style=" float:left; border:solid 1px brown; width:250px;  height:350px;"    >
                                                    
                                                   <p  runat="server" style="padding-left:25px;clear:left;"   id="pOtherViews" class="normaltext_bold">
                                                       
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; you have a total of &nbsp <span  id="spncredits" ></span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Other Views



&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
                    
               <%--       var imgTops = window.opener.document.getElementById(id[1]); //window.opener.document.forms[0].getElementById('imgCenter');
                - <div style="text-align:center;"> <a     href="#" onclick="window.open('BuyCredits.aspx','','scrollbars=yes,menubar=no,height=560,width=650,resizable=no,toolbar=no,location=no,status=no');"  >&nbsp; Buy Now&nbsp; </a>  
</div>
                     
                                                   
                                                   <div style=" border:solid 1px black;" >
                                                   
                                                   <div style=" border:solid 1px black; text-align:center; height:40px; width:250px;"><p>&nbsp; Bidding Log</p>  </div>
                                                   
                                                   
                                                   
                                                   <hr />
                  
                     <%--   <div id="dvbidders" style="border:solid 3px black;float:left; height:100px;  overflow:scroll; width: 271px;">BID LOG   <input id="sponsorid" type="hidden" />
                       
                           <%-- <div id="dvbuyername"  > 
                            </div> <div id="dvbidprice" style="float:right"> 
                            </div> 
                        </div>- 
                  
                 
                  
                  
                  
               
                  
                       <hr />
                                                   
                                                   
                                                   
                                                   
                                                   
                                                   
                                                   
                                                   
                                                   
                                                   
                                                     <div id="dvlstCreditLog" style=" overflow:scroll; border:solid 1px black; padding:5,5,5,5; width:250px; height:200px;" >
                                                     
                                                     
                                                     
                                                     <asp:Repeater  runat="server" id="lstCreditLog"   OnItemDataBound="rptData_ItemDataBound"  >
                                                     <ItemTemplate>
                                                    <div style=" font-size:small;position:relative;" > 
                                                     
                                                     <div style=" border:solid 5px white; font-size:small; text-align:left; float:left ">  
                                                     
                                                 
                                                     <%#DataBinder.Eval(Container.DataItem, "buyer_Name")%>  
                                                   <%--   <%#Eval("")%>-- 
                                                      
                                                      
                                                                                                           
                                                                                                           
                                                                                                           
                                                      
                                                    </div> 
                                                    
                                                        
                                                <div style=" font-size:small float:left; border:solid 5px white;  text-align:right;" >  
                                               
                                                     <%#DataBinder.Eval(Container.DataItem, "bidprice", "{0:C} ")%>  
                                                   
                                                     <%-- <%#Eval("bidamount")%>-- 
                                                      
                                                      
                                                   </div>
                                                   
                                                    <%-- <div style=" font-size:small float:left; border:solid 5px white;  text-align:right;" >  
                                               
                                                     <%#DataBinder.Eval(Container.DataItem, "totalCreditsUsed", "{0:C} ")%>                                                       
                                                      
                                                   </div>
                                                    <div style=" font-size:small float:left; border:solid 5px white;  text-align:right;" >  
                                               
                                                     <%#DataBinder.Eval(Container.DataItem, "totalBidAmount", "{0:C} ")%>                                                       
                                                      
                                                   </div>- 
                                                   
                                         
						
						          
                                                   
                                                     </div> 
                                                    
                                                     </ItemTemplate>
                                                     </asp:Repeater>
                                                   
                                                     </div>
                                                   
                                                   
                                                     
                                                    </div>
                                                    
                                                   
                                                     <div style=" padding-top:19px; border:solid 1px white;" >
                                                   
                                                   
                                                   <%--<div style=" border:solid 3px black; text-align:center; height:40px; width:250px;"><p>  Money Meter</p> </div>
                                                  
                                                      <div style=" border:solid 3px black; width:250px;">
                                                     
                                                    <div>  Credits Used:  <asp:Label runat="server" ID="lblCreditsUsed" ></asp:Label>           </div>   
                                                       <div> Money Spent:  <asp:Label runat="server" ID="lblMoneySpent" ></asp:Label>           </div> 
                                                       
                                                         
                                                         <div> You Have Donated:  <asp:Label runat="server" ID="lblDonated" ></asp:Label>           </div>   
                                                       </div>
                                                    - 
                                                    
                                                    
                             <input type="hidden" id="counterx"    />                       
                                                      <input type="hidden" id="buyerx"    />            
                                                      <input type="hidden" id="pricex"    />            
                                                    
               <%-- <div class="iconbg">
                 <div    onclick="javascript:navto('http://facebook.com/jomashop_com');" class="smallbox">  <img  src="App_Themes/YekaTheme/images/facebook1.jpg"  onclick="javascript:navto('http://facebook.com/jomashop_com');" width="26" height="30" alt="jomadeals" class="img3" /><span onmouseover="this.style.text-decoration='underline'"  style=" padding-left:5px; "> 
                     &nbsp; Facebook </span> </div>
            <div class="smallbox"> <img src="App_Themes/YekaTheme/images/twitter.jpg" onclick="javascript:navto('http://twitter.com/jomashop_com');" width="27" height="30" alt="jomadeals"  class="img3" /><span class="addthis_button_favorites" onmouseover="javascript:this.style.text-decoration='underline'" style=" padding-left:5px; "> 
                &nbsp; Twitter </span> </div>
               <div  style=" position:relative;" class="smallbox">
                <div onmouseover="this.style.text-decoration='underline'"  style=" display:inline">&nbsp; 
                    &nbsp; <a class="addthis_button_favorites"><img style="left:0px; margin-left:2px; position:absolute; " src="App_Themes/YekaTheme/images/bookmark.jpg" width="27" height="23" alt="jomadeals"   class="img3" /> 
                    &nbsp; &nbsp; &nbsp; &nbsp; Bookmark   </a><br />
                   
                      <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js?pub=xa-4a32917b7eef9453"></script>
                 
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; this page</div></div>
               <div class="smallbox">  <img src="App_Themes/YekaTheme/images/email.jpg" onclick="javascript:navto('mailto:orders@jomadeals.com');" width="33" height="30" alt="jomadeals"  class="img3"  /> <div class="addthis_button_email"  onmouseover="this.style.text-decoration='underline'" style=" display:inline;" >
                   &nbsp; &nbsp; Email to <br />
                      &nbsp; &nbsp; a friend</div> 
                   </div>
                          <script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js?pub=xa-4a32917b7eef9453"></script>

                  
                  <div  class="smallbox" style="  float:left; position:relative;  right:0px; margin-right:-30px; font-family:Sans-Serif; min-width:210px; text-decoration:underline; font-size:small; left:0px; margin-left:0px; vertical-align:bottom; bottom:0px; margin-bottom:0px; font-size:small; color:Red;"><a style="color:Red;" href='<%=relLink%>'>
                      Click here to view other products from this brand</a></div>

                  
                </div>
                
                                
                
                
           </div>  -- 
          
                
                
                
                  </div> 
                  
                  
               <div id="dvsponsorItem" style="  width:50px; height:60px;" >
               
               <span>Number of credits: <input id="ncredits" type="text" /> </span>
               
           
               
               </div>
                      
                  
                 
               </div>
                 
                  
                  
                      </div> 
                  
                  
               
                  
                  
               
               
                  <%-- <div>
                    <input type="button" value="Sponsor" onclick="javascript:sponsor('<%=items().AuctionID %>');" />
                     </div>
                    
                    
                        <div id="dvsponsors" style=" overflow:scroll; border:solid 3px black; float:left; height:550px; width: 271px;">Sponsors   <input id="Hidden1" type="hidden" />
                       
                           <%-- <div id="dvsponsorName" > 
                            </div> <div id="dvsponsorAmount" style="float:right"> 
                            </div> 
                        </div>--%>
                  
             <%--  
                   </div> 
               
                </div>
            

<div style="top:30px;  left:50px; height:200px;  border-top:solid 100px  white;"></div>
 

                  <div  style="top:30px;  left:50px; height:500px;  margin-left:150px; border-top:solid 50px white;  margin-top:250px;  " >   
               
               
                <uc1:orgProducts ID="orgProducts2" runat="server" />
                           
                                                    
                                                    

                
                </div>
</div>--%>

                      </ContentTemplate>
                        </asp:UpdatePanel> 
                    </asp:Content>

 <asp:Content ID="Content5" ContentPlaceHolderID="Scripts" Runat="Server"> 
     <!-- Google Code for Watches Remarketing List -->
<%--<script type="text/javascript">
<!--
    var google_conversion_id = 1026211208;
    var google_conversion_language = "en";
    var google_conversion_format = "3";
    var google_conversion_color = "666666";
    var google_conversion_label = "BE3wCOKVrgEQiPuq6QM";
    var google_conversion_value = 0;
//-->
</script>
<script type="text/javascript" src="http://www.googleadservices.com/pagead/conversion.js">
</script>--%>

<script type="text/javascript">





//  window.onload = GetCount();
//    document.onload = GetCount();







  //  function ajaxsender(auid, col, artimer)







    function ajaxvalues(show, val) {

         // alert(val);
        var indx = show.indexOf(val);
         /// alert(indx);
       /// alert(val.substring(indx, indx + 30));
        //     alert(indx);
          var len = show.length - (indx+1)

          var showq = show.substring(indx, indx + len);
       /// alert(showq + "showq");

        var fshow = showq.substring(showq.indexOf('>') + 1, showq.indexOf('<'));
    ///   alert(fshow + "fshow");
        return fshow;
    }





    //    aid =

    function captures() {
        var artimer = new Array();
        for (var cc = 0; cc <= 1; cc++) {

            /// setInterval("capture(" + artimer + ")", 1000);
            
          }
    
     }



     
     
//////////     
//////////       alert(orgProducts2 + '   orgProducts2ID');
//////////      
//////////       var dvlstCreditLogh = document.getElementById("dvlstCreditLog");
 
//////////      alert(lstCreditLogID  + '   ID');
//////////       
//////////       
//////////       alert(dvlstCreditLogh);
//////////        var dvlstCreditLog  =  dvlstCreditLogh  ;
//////////        
//////////        
////////// do{

//////////     dvlstCreditLog = dvlstCreditLog.nextSibling;

//////////     alert('lstCreditLog3');
 
 /// alert (dvlstCreditLog +  '        nextSibling  ' +dvlstCreditLog.innerHTML +' '+ dvlstCreditLog.nodeType);
    //// alert(dvlstCreditLog.nodeValue);



////////     var table = document.getElementById("mytab1");
////////     for (var i = 0, row; row = table.rows[i]; i++) {
////////         //iterate through rows
////////         //rows would be accessed using the "row" variable assigned in the for loop
////////         for (var j = 0, col; col = row.cells[j]; j++) {
////////             //iterate through columns
////////             //columns would be accessed using the "col" variable assigned in the for loop
////////         }
////////     }



//////////} 
////////////////////    while (dvlstCreditLog   && dvlstCreditLog.nodeType!=1)





////////////////////    alert('lstCreditLog7');
////////////////////        
////////////////////            var dvlstCreditLog  =  dvlstCreditLogh  ;
////////////////////            alert('lstCreditLog7   ' + dvlstCreditLog.firstChild.nodeValue);
////////////////////    do{dvlstCreditLog  = dvlstCreditLog.firstChild;
////////////////////        alert(dvlstCreditLog + '        firstChild  ' + dvlstCreditLog.nodeValue + ' ' + dvlstCreditLog.nodeType + ' ' + dvlstCreditLog.nodeName);
//////////////////// 
//////////////////// }
////////////////////    while (dvlstCreditLog   && dvlstCreditLog.nodeType!=1)
//    }    
//    
//    
//}




     function dimlights() {
         //alert('dimlights');
         var home_page = document.getElementById('home_page');
         var bottom_row = document.getElementById('bottom_row');
         var left_container = document.getElementById('left_container');
         var layout = document.getElementById('layout');

          






//         layout.style.backgroundColor = layout.style.backgroundColor == 'black' ? 'white' : 'black';
//         layout.style.color = layout.style.color == 'black' ? 'white' : 'black';


         home_page.style.backgroundColor = home_page.style.backgroundColor == 'black' ? 'white' : 'black';
         home_page.style.color = home_page.style.color == 'black' ? 'white' : 'black';


         bottom_row.style.backgroundColor = bottom_row.style.backgroundColor == 'black' ? 'white' : 'black';
         bottom_row.style.color = bottom_row.style.color == 'black' ? 'white' : 'black';

         left_container.style.backgroundColor = left_container.style.backgroundColor == 'black' ? 'white' : 'black';
         left_container.style.color = left_container.style.color == 'black' ? 'white' : 'black';
     
     
     
     
     
     
     
      dvKnow.style.fontVariant.fontColor = 'white';
      dvKnow.style.fontVariant.big = true ;
      dvKnow.style.fontStyle.fontSize='16px';
     }




         function changeMainImage(medImageUrl, bigImageUrl, productColor) {
             //Set the main image
             var imgMediumImage = document.getElementById("imgMediumImage");

           
            
        //    alert('imgMediumImage  '+  imgMediumImage);
            
             imgMediumImage.src = medImageUrl;
  //alert('imgMediumImage.src  '+  medImageUrl  +'          '+imgMediumImage.src   );
             //Set the full image
             var lnkFullImage = document.getElementById("lnkFullImage");
             lnkFullImage.href = bigImageUrl;

             //Set the remote dropdownlist

         }



         function getamount() {
////             alert('timer');
////             var timer = document.getElementById('hdnTimerClientID')

////             alert(timer);
////             amount = timer.innerHTML.toString();

                     ///alert(amount);
          amount =   getTotBids();
          //alert(amount);
              GetCount();
               
         }

         function getamounts() {
             /////////////  alert('timer');
            ///////////  

             //////////////////  alert(timer);
              

             ///alert(amount);
             return amount;

         }




         function sponsor(auid) {
            
                var spnsr =   prompt("Please enter number of credits you wish to sponsor:" ,"")
 // document.getElementById("msg").innerHTML="Greetings " + fname
            var exp=/^[1-9]*$/ ;
 
             ////////////////   var m = exp.exec(document.demoMatch.subject.value);

                /////////if (m == null || spnsr === null || spnsr == '') { return false; }
                if ( spnsr === null || spnsr == '') { return false; }
//  if (spnsr != '' && spnsr != null) {

//  
//            var  sponsorItem=document.getElementById("dvsponsorItem");
//            document.getElementById("dvsponsorName").innerHTML = "  " + '<%=buyer_names %>';
//             document.getElementById("sponsorAmount").innerHTML = "  " + spnsr;  
//             document.getElementById("sponsorid").innerHTML = "  " + '<%=BuyerID %>';


            //// alert('sponsor' + spnsr);

             var xml = typeof XMLHttpRequest == "undefined" ? new ActiveXObject() : new XMLHttpRequest();

             ///xml.Close

             //////////
             ///alert(xml);
             xml.open("GET", "simpleSponsorPageBtn.aspx?auid=" + auid + "&amt="+spnsr, true);
             ///alert(xml);
             //xml.setRequestHeader("Content-Type", "text/xml");
             xml.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");



             ///alert(xml + '    xml');


             try {
                 xml.send();



                 xml = null;
                 //alert(xml + '    xmlclose');
             }
             catch (ex) {
                 ////////////////////// alert(ex.message);
             } 
    
      
      
      
      
//             simpleSponsorPageBtn.aspx
    }





















         
         
         
         
         
         
         
         
         
         
         
         
         
             
function  getvalue() {
 ////////////////   alert(document.getElementById('hdnIndex'));
 

//////////////////alert ( document.getElementById('hdnIndex')).value;
return document.getElementById('hdnIndex').value;
   
   
   
 
   
   
 
}




function  setvalue(ddlist)
{

    var ddDisplayVariations_client = '';   // ; //   document.getElementById('ddDisplayVariations');

 var ddDisplayVariations =  document.getElementById(ddDisplayVariations_client);
ddDisplayVariations.selectedIndex =ddlist ;
forcePost();

}
           
           
           
//           function forcePost()
//           {
// 
//
//            
//            window.location.reload(); 
//            
//            }




function GetClientId(strid)
{  
     var count=document.getElementsByTagName ('*').length; //<-- gets all elements, instead of Forms as this only returns FORM elements
     var i=0;
     var eleName;
     for (i=0; i < count; i++ )
     {
       eleName=document.getElementsByTagName ('*')[i].id;
       pos = eleName.indexOf(strid);
       
       
       
       
       if(pos>=0)  break;          
     }
    return eleName;
}

//		<add key="ConnectionString" value="Data Source=ELIBARBER-PC\SQLEXPRESS;Initial Catalog=Notik;Integrated Security=SSPI; Max Pool Size=1000;Asynchronous Processing=true; "/>



 





function xobject() {

    if (typeof XMLHttpRequest == "undefined") {
        XMLHttpRequest = function() {
            return new ActiveXObject(navigator.userAgent.indexOf("MSIE 5") >= 0 ? "Microdoft.XMLHTTP" : "Msxml2.XMLHTTP");
        }
    }

    else { return new XMLHttpRequest; }
 }



function gevald    (gevald)      {  alert('val'+gevald);}











function setBids(auid) {

    if (document.getElementById("bidbtn").getAttribute("class") == 'btn') {



        var xml = typeof XMLHttpRequest == "undefined" ? new ActiveXObject() : new XMLHttpRequest();

        ///xml.Close

        //////////
        ////alert(xml);
        xml.open("GET", "simplePageBtn.aspx?auid=" + auid, true);
        ///alert(xml);
        //xml.setRequestHeader("Content-Type", "text/xml");
        xml.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");



        ///alert(xml + '    xml');


        try {
            xml.send();



            xml = null;
            //alert(xml + '    xmlclose');
        }
        catch (ex) {
            ////////////////////// alert(ex.message);
        }
    }

}





////function getBidsAll(auctionid) {

//// 
////      var show =      ajaxsend(auctionid);



////    return show;
////    

////}
//// 
//// 
//// 
////  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  

            function stopCount()
            {

            //alert('stop');
            clearTimeout(  timeout );
             
            }





            
           
           
           



























       
 
 
 
 
 
 
 
 
 
 
 

function navto(url)
{  
 document.location.href=url;
 
}
</script>
<%--
<noscript>
<div style="display:inline;">
<img height="1" width="1" style="border-style:none;" alt="" src="http://www.googleadservices.com/pagead/conversion/1026211208/?label=BE3wCOKVrgEQiPuq6QM&amp;guid=ON&amp;script=0"/>
</div>
</noscript>--%>
 </asp:Content>
 

 