/*
'=====================================================
' Project:      Seifert SampleWebsite
' Programmer:   Derek Souers
' File:         Referrer.cs
' Created:      09/03/09
' Last Updated: 09/23/09
'
'=====================================================
*/

using System;
using System.Data;
using System.Web;
using System.Web.UI;

using System.Data.SqlClient;
 

/// <summary>
/// Summary description for Referrer
/// </summary>
public class Referrer
{
  
    //--------------------------------------------------------------------
    // Function:	GetTotalUnusedCredits()
    // Desc:		
    // Receives:	Guid, int(updated), int(updated)
    // Returns:		bool
    //--------------------------------------------------------------------
     
    //      @opt  varchar(1),			 
    //@orgID int  ,
    //    @orgTitle varchar(50) ,
    //    @orgFunct varchar(50) ,	
    //    @orgDesc varchar(150) ,
    //@orgTaxID  varchar(50) ,
    //@orgEmail  varchar(100) ,	
    //@orgPaypal  varchar(20) ,	
    //@orgLogo  varchar(20) ,
    //@orgStatus   varchar(10)  



    //orgid      ,
    // location    ,
    // description    ,
    // quantity     , 	 
    //shippngCost     ,
    // condition   ,
    // title   ,
    //catID    ,
    // startDate    ,
    // endDate   ,
    //soldDate    





    //@prm varchar(1),
    // @itemID   int      ,
    //@orgid  int   , 
    //@catID int   ,
    // @location varchar (150)  ,
    // @description varchar (200)  ,
    // @quantity int   ,
    // @quantityHold int  ,
    // @quantityToShipped int   ,
    // @quantityInStore int   ,


    // @quantityInPennybid int   ,
    // @quantityInAuction int   ,
    // @quantitySold int   ,
    // @shippngCost int   ,
    // @condition varchar (50)  ,
    // @title varchar (100)  ,
	
    // @startDate datetime   ,
    // @endDate datetime   ,
    // @soldDate datetime   
    //@opt varchar(1), 


    //        @itemID  INT, 
    //        @catID  int ,
    //    @orgID  int






    public int get_orders(string commandName, string prm, int auctionid,int orgid, int buyerid, int ordr_CreditCardInfoID, 
        int ordr_BillingAddressID,
                int ordr_ShippingAddressID, string ordr_Status,
                 String ordr_Type
                )


    {



        SqlParameter[] commandParameters = new SqlParameter[9];



        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@auctionid", auctionid);

        commandParameters[2] = new SqlParameter("@orgid", orgid);
        commandParameters[3] = new SqlParameter("@buyerid", buyerid);
        commandParameters[4] = new SqlParameter("@ordr_CreditCardInfoID", ordr_CreditCardInfoID); 
      
     commandParameters[5] = new SqlParameter("@ordr_BillingAddressID", ordr_BillingAddressID);
     commandParameters[6] = new SqlParameter("@ordr_ShippingAddressID", ordr_ShippingAddressID);

     commandParameters[7] = new SqlParameter("@ordr_Status", ordr_Status);
     commandParameters[8] = new SqlParameter("@ordr_Type", ordr_Type);



     string tname = "";


     return RunStoredProc(commandName, commandParameters);

    }








    public DataSet getItems(string commandName, string prm,int buyerid, int itemid, int orgid, int catID, string location,
   string description, int quantity, int shippngCost, string condition, string title,
        DateTime startDate, DateTime endDate, DateTime soldDate, String auctiontype,int auctionid
    )
    {

        int  quantityHold=0;
           int  quantityInStore=0;
           int  quantityInPennybid=0;
             int   quantityInAuction=0;
             int quantitySold = 0;
        int quantityToShipped = 0;
        int buyitNow = 0;

        String payPalemail = "";
        String imgPath = "";
        String handlingTime ="";
        string tname = "";
       //// int buyerid = custs().buyerID;
       
             SqlParameter[] commandParameters = new SqlParameter[23];


             switch (commandName)
        {
            case    "get_Items" :

                     switch (prm)

                     {case "C" :

                             tname = "ShoppingCart";
                             break;
                         //default :
                         //    tname = "ShoppingCart";
                         //    break;

            

             }
               // String auctiontype = "";

                commandParameters = new SqlParameter[9];
                commandParameters[0] = new SqlParameter("@opt", prm);
                commandParameters[1] = new SqlParameter("@itemID", itemid);
        
                commandParameters[2] = new SqlParameter("@catID", catID);     
                commandParameters[3] = new SqlParameter("@orgID", orgid);
                commandParameters[4] = new SqlParameter("@auctiontype",  auctiontype);
                commandParameters[5] = new SqlParameter("@itemAuctionID", auctionid);
                commandParameters[6] = new SqlParameter("@count", 0);
                commandParameters[7] = new SqlParameter("@title", title);
                commandParameters[8] = new SqlParameter("@buyerid", buyerid);

                     // 'S' , 22 , 18 ,12,'standard',2
                break;



            case "getItems":


        commandParameters = new SqlParameter[20];

        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@itemID", itemid);
        commandParameters[2] = new SqlParameter("@orgID", orgid);
        commandParameters[3] = new SqlParameter("@catID", catID);
        commandParameters[4] = new SqlParameter("@location", location);

        commandParameters[5] = new SqlParameter("@description", description);
        commandParameters[6] = new SqlParameter("@quantity", quantity);
        commandParameters[7] = new SqlParameter("@quantityHold", quantityHold);
        commandParameters[8] = new SqlParameter("@quantityToShipped", quantityToShipped);

        commandParameters[9] = new SqlParameter("@quantityInPennybid", quantityInPennybid);

        commandParameters[10] = new SqlParameter("@quantityInStore", quantityInStore);

        commandParameters[11] = new SqlParameter("@quantityInAuction", quantityInAuction);

        commandParameters[12] = new SqlParameter("@quantitySold", quantitySold);





        commandParameters[13] = new SqlParameter("@shippngCost", shippngCost);
        commandParameters[14] = new SqlParameter("@condition", condition);
        commandParameters[15] = new SqlParameter("@title", title);



        commandParameters[16] = new SqlParameter("@startDate", startDate);




        commandParameters[17] = new SqlParameter("@endDate", endDate);



        commandParameters[18] = new SqlParameter("@soldDate", soldDate);

        commandParameters[19] = new SqlParameter("@buyitNow", buyitNow);



        commandParameters[20] = new SqlParameter("@payPalemail", payPalemail);

        commandParameters[21] = new SqlParameter("@handlingTime", handlingTime);
        commandParameters[22] = new SqlParameter("@imgPath", imgPath);
         

        break;
                     
        }                    

             return RunStoredProcDS(commandName, commandParameters, tname);
    }







    public int set_Items(string commandName, string prm, int itemid, int itemAuctionID, int buyerID, int storeID,
        int quantity, int quantityAllocated, int shipping, Decimal startBidPrice, Decimal currentBidPrice, int soldAmount,
        int   buyitNow  ,int percentAllocated    ,int amountAllocated     ,int  soldFixedBid   ,   string condition,  int  returnDays,
        String returnPolicy, DateTime startTime, DateTime endTime, DateTime soldTime, string paypalEmail, String handlingTime,
        string imgPath, String auctiontype, string imgCentertxt1, string imgCentertxt2, string imgCentertxt3, string imgCentertxt4, string itemsIncluded)
    
    {
        int quantityHold = 0;
        int quantityInStore = 0;
        int quantityInPennybid = 0;
        int quantityInAuction = 0;
        int quantityToShipped = 0;

        int quantitySold = 0;

        SqlParameter[] commandParameters = new SqlParameter[0 ];

        if (commandName == "get_itemMaster")
        {
          commandParameters = new SqlParameter[26];

        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@itemID", itemid);
        commandParameters[2] = new SqlParameter("@orgid", buyerID);
        commandParameters[3] = new SqlParameter("@location", "");
        commandParameters[4] = new SqlParameter("@description", returnPolicy);

        commandParameters[5] = new SqlParameter("@quantity", quantity);
        commandParameters[6] = new SqlParameter("@quantityHold", quantityAllocated);
        commandParameters[7] = new SqlParameter("@quantityToShipped", quantityInStore);

             commandParameters[8] = new SqlParameter("@quantityInStore", quantityInStore);
        commandParameters[9] = new SqlParameter("@quantityInPennybid", quantityInPennybid);
        commandParameters[10] = new SqlParameter("@quantityInAuction", currentBidPrice);
            commandParameters[11] = new SqlParameter("@quantitySold", currentBidPrice);
            commandParameters[12] = new SqlParameter("@shippingCost", shipping);
        commandParameters[13] = new SqlParameter("@condition", "");

        commandParameters[14] = new SqlParameter("@title", condition);
        commandParameters[15] = new SqlParameter("@catID", itemAuctionID);
        commandParameters[16] = new SqlParameter("@startDate", startTime);
        commandParameters[17] = new SqlParameter("@endDate", endTime);
        commandParameters[18] = new SqlParameter("@soldDate", soldTime); 

        commandParameters[19] = new SqlParameter("@handlingTime", handlingTime);
        commandParameters[20] = new SqlParameter("@itemsIncluded", itemsIncluded);
            commandParameters[21] = new SqlParameter("@img1", imgCentertxt1);
            commandParameters[22] = new SqlParameter("@img2", imgCentertxt2);

            commandParameters[23] = new SqlParameter("@img3", imgCentertxt3);
            commandParameters[24] = new SqlParameter("@img4", imgCentertxt4);
      
            
            commandParameters[25] = new SqlParameter("@id", 0);
        commandParameters[25].Direction = ParameterDirection.Output;
        RunStoredProc(commandName, commandParameters);

        return   (int)  Convert.ToInt16( commandParameters[25].Value);



        }

        else{

        commandParameters = new SqlParameter[25];

        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@itemID", itemid);
        commandParameters[2] = new SqlParameter("@itemAuctionID", itemAuctionID);
        commandParameters[3] = new SqlParameter("@buyerID", buyerID);
        commandParameters[4] = new SqlParameter("@storeID", storeID);

        commandParameters[5] = new SqlParameter("@quantity", quantity);
        commandParameters[6] = new SqlParameter("@quantityAllocated", quantityAllocated);
        commandParameters[7] = new SqlParameter("@shipping", shipping);
        commandParameters[8] = new SqlParameter("@startBidPrice", startBidPrice);
        commandParameters[9] = new SqlParameter("@currentBidPrice", currentBidPrice);





        commandParameters[10] = new SqlParameter("@soldAmount", soldAmount);
        commandParameters[11] = new SqlParameter("@percentAllocated", percentAllocated);
        commandParameters[12] = new SqlParameter("@amountAllocated", amountAllocated);
        commandParameters[13] = new SqlParameter("@soldFixedBid", soldFixedBid);
        commandParameters[14] = new SqlParameter("@condition", condition);

        commandParameters[15] = new SqlParameter("@returnDays", returnDays);
        commandParameters[16] = new SqlParameter("@returnPolicy", returnPolicy);
        commandParameters[17] = new SqlParameter("@startTime", startTime);
        commandParameters[18] = new SqlParameter("@endTime", endTime);
        commandParameters[19] = new SqlParameter("@soldTime", soldTime);



        commandParameters[20] = new SqlParameter("@buyitNow", buyitNow);
        commandParameters[21] = new SqlParameter("@paypalEmail", paypalEmail);
        commandParameters[22] = new SqlParameter("@handlingTime", handlingTime);
        commandParameters[23] = new SqlParameter("@imgPath", imgPath);
        commandParameters[24] = new SqlParameter("@auctiontype", auctiontype);
         
        
        return RunStoredProc(commandName, commandParameters);
        }

    }

      




    public int setItems(string commandName, string prm, int itemid, int orgid, int catID, string location,
   string description, int quantity, int shippngCost, string condition, string title,  
        DateTime startDate, DateTime endDate, DateTime soldDate
    )
    {
        int quantityHold = 0;
        int quantityInStore = 0;
        int quantityInPennybid = 0;
        int quantityInAuction = 0;
        int quantityToShipped = 0;
  
        int quantitySold = 0;
        int buyitNow = 0;

        String payPalemail = "";
        String imgPath = "";
        String handlingTime = "";


        SqlParameter[] commandParameters = new SqlParameter[23];

        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@itemID", itemid);
        commandParameters[2] = new SqlParameter("@orgID", orgid);
        commandParameters[3] = new SqlParameter("@catID", catID);
        commandParameters[4] = new SqlParameter("@location", location);

        commandParameters[5] = new SqlParameter("@description", description); 
        commandParameters[6] = new SqlParameter("@quantity", quantity);
        commandParameters[7] = new SqlParameter("@quantityHold", quantityHold);
        commandParameters[8] = new SqlParameter("@quantityToShipped", quantityToShipped);

        commandParameters[9] = new SqlParameter("@quantityInPennybid", quantityInPennybid);

        commandParameters[10] = new SqlParameter("@quantityInStore", quantityInStore);

        commandParameters[11] = new SqlParameter("@quantityInAuction", quantityInAuction);

        commandParameters[12] = new SqlParameter("@quantitySold", quantitySold);





        commandParameters[13] = new SqlParameter("@shippngCost", shippngCost);
        commandParameters[14] = new SqlParameter("@condition", condition);
        commandParameters[15] = new SqlParameter("@title", title);



        commandParameters[16] = new SqlParameter("@startDate", startDate);


        commandParameters[17] = new SqlParameter("@endDate", endDate);



        commandParameters[18] = new SqlParameter("@soldDate", soldDate);



        commandParameters[19] = new SqlParameter("@buyitNow", buyitNow);

        commandParameters[20] = new SqlParameter("@payPalemail", payPalemail);

        commandParameters[21] = new SqlParameter("@handlingTime", handlingTime);
        commandParameters[22] = new SqlParameter("@imgPath", imgPath);
         
    
        return RunStoredProc(commandName, commandParameters);


    }




    public int setForum(string commandName, string prm,
                               int forumid, int item_AuctionID, int orgID, int buyerID, string forumMessage, string messageType, string messageSeneder, DateTime forumdate)
    {
        SqlParameter[] commandParameters = new SqlParameter[9];


        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@forumid", forumid);
        commandParameters[2] = new SqlParameter("@item_AuctionID", item_AuctionID);
 
        commandParameters[3] = new SqlParameter("@orgID", orgID);
        commandParameters[4] = new SqlParameter("@buyerID", buyerID);
        commandParameters[5] = new SqlParameter("@forumMessage", forumMessage);
        commandParameters[6] = new SqlParameter("@messageType", messageType);
        commandParameters[7] = new SqlParameter("@messageSeneder", messageSeneder);
        commandParameters[8] = new SqlParameter("@forumdate", forumdate);

        RunStoredProc(commandName, commandParameters);


        return 4;

    }









    public DataSet getForum(string commandName, string prm,
                               int forumid, int item_AuctionID, int orgID, int buyerID, string forumMessage, string messageType, string messageSeneder, DateTime forumdate)
    {
        SqlParameter[] commandParameters = new SqlParameter[9];


        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@forumid", forumid);
        commandParameters[2] = new SqlParameter("@item_AuctionID", item_AuctionID);

        commandParameters[3] = new SqlParameter("@orgID", orgID);
        commandParameters[4] = new SqlParameter("@buyerID", buyerID);
        commandParameters[5] = new SqlParameter("@forumMessage", forumMessage);
        commandParameters[6] = new SqlParameter("@messageType", messageType);
        commandParameters[7] = new SqlParameter("@messageSeneder", messageSeneder);
        commandParameters[8] = new SqlParameter("@forumdate", forumdate);

        string tname = "";


        return RunStoredProcDS(commandName, commandParameters, tname);
    }






    public DataSet getLogins(string commandName, string prm, 
 string orgEmail, string orgPassword)
  
    {
        SqlParameter[] commandParameters = new SqlParameter[3];

     
        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@userID", orgEmail);
        commandParameters[2] = new SqlParameter("@pwd", orgPassword);

        string tname = "";

         
        return RunStoredProcDS(commandName, commandParameters,tname);  
    }





    public DataSet getOrgs(string commandName, string prm, int id, string orgTitle, string orgFunct, string orgDesc,
   string orgTaxID, string orgEmail, string orgPaypal, string orgLogo, string orgStatus, string orgVideo 
    )
    {
        SqlParameter[] commandParameters = new SqlParameter[14];
        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@orgID", id);
        commandParameters[2] = new SqlParameter("@orgTitle", orgTitle);
        commandParameters[3] = new SqlParameter("@orgFunct", orgFunct);
        commandParameters[4] = new SqlParameter("@orgDesc", orgDesc);
        commandParameters[5] = new SqlParameter("@orgTaxID", id);
        commandParameters[6] = new SqlParameter("@orgEmail", orgEmail);
        commandParameters[7] = new SqlParameter("@orgPaypal", orgPaypal);
        commandParameters[8] = new SqlParameter("@orgLogo", orgLogo);
        commandParameters[9] = new SqlParameter("@orgStatus", orgStatus);
        commandParameters[10] = new SqlParameter("@orgVideo", orgVideo);
        commandParameters[11] = new SqlParameter("@orgUserid", "");
        commandParameters[12] = new SqlParameter("@orgPwd", "");
        commandParameters[13] = new SqlParameter("@id", id);
        commandParameters[13].Direction = ParameterDirection.Output;
        string tname = "";

         
        return RunStoredProcDS(commandName, commandParameters,tname);  
    }







    public DataSet getCats(string commandName, string prm, int id, string orgTitle 
   )
    {
        SqlParameter[] commandParameters = new SqlParameter[3];
        
        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@catID", id);
        commandParameters[2] = new SqlParameter("@catName", orgTitle);
        string tname = "";
        return RunStoredProcDS(commandName, commandParameters,tname);
    }



    public int setCats(string commandName, string prm, int id, string orgTitle
   )
    {
        SqlParameter[] commandParameters = new SqlParameter[3];
        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@catID", id);
        commandParameters[2] = new SqlParameter("@catName", orgTitle);
        return RunStoredProc(commandName, commandParameters);
       
    }









    public int setOrgs(string commandName, string prm, int id, string orgTitle, string orgFunct, string orgDesc,
   string orgTaxID, string orgEmail, string orgPaypal, string orgLogo, string orgStatus, string flashCenter, string orgUserid, string orgPwd)
    {
        SqlParameter[] commandParameters = new SqlParameter[14];

    
        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@orgID", id);
        commandParameters[2] = new SqlParameter("@orgTitle", orgTitle);
        commandParameters[3] = new SqlParameter("@orgFunct", orgFunct);
        commandParameters[4] = new SqlParameter("@orgDesc", orgDesc);
        commandParameters[5] = new SqlParameter("@orgTaxID", orgTaxID);


        commandParameters[6] = new SqlParameter("@orgEmail", orgEmail);




        commandParameters[7] = new SqlParameter("@orgPaypal", orgPaypal);



        commandParameters[8] = new SqlParameter("@orgLogo", orgLogo);


        commandParameters[9] = new SqlParameter("@orgStatus", orgStatus);

        commandParameters[10] = new SqlParameter("@orgVideo", flashCenter);



        commandParameters[11] = new SqlParameter("@orgUserid", orgUserid);
        commandParameters[12] = new SqlParameter("@orgPwd", orgPwd);

        commandParameters[13] = new SqlParameter("@id", id);
        commandParameters[13].Direction = ParameterDirection.Output;
       

         

        RunStoredProc(commandName, commandParameters);




        return (int)Convert.ToInt16(     commandParameters[13].Value == null ? 0 :  commandParameters[13].Value   ) ;


    }







    public int setBuyers(string commandName, string prm, int id, string buyer_Name, string buyer_email, string buyer_paypalAccount,
   int buyer_CreditCardInfoID, int buyer_BillingAddressID, int buyer_ShippingAddressID, int Credits,string password )
    {
        int buyerSessionID = 0;
        bool buyerSaveInfo = false;

        SqlParameter[] commandParameters = new SqlParameter[12];

        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@BuyerID", id);
        commandParameters[2] = new SqlParameter("@buyer_Name", buyer_Name);
        commandParameters[3] = new SqlParameter("@buyer_email", buyer_email);
        commandParameters[4] = new SqlParameter("@buyer_paypalAccount", buyer_paypalAccount);
        commandParameters[5] = new SqlParameter("@buyer_CreditCardInfoID", buyer_CreditCardInfoID);
        commandParameters[6] = new SqlParameter("@buyer_BillingAddressID", buyer_BillingAddressID);
        commandParameters[7] = new SqlParameter("@buyer_ShippingAddressID", buyer_ShippingAddressID);
        commandParameters[8] = new SqlParameter("@buyerSessionID", buyerSessionID);
        commandParameters[9] = new SqlParameter("@buyerSaveInfo", buyerSaveInfo);
        commandParameters[10] = new SqlParameter("@Credits", Credits);
        commandParameters[11] = new SqlParameter("@password", password);

        return RunStoredProc(commandName, commandParameters);

    }











    public DataSet get_watch(string commandName, string prm, int auctionid, int orgID, int buyerID)
    {
        SqlParameter[] commandParameters = new SqlParameter[4];

        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@auctionID", auctionid);
        commandParameters[2] = new SqlParameter("@orgID", orgID);
        commandParameters[3] = new SqlParameter("@buyerID", buyerID);

        string tname = "";


        return RunStoredProcDS(commandName, commandParameters, tname);

    }









    public DataSet get_Sponsors(string commandName, string prm, int auctionid, int amount, int buyerID)
    { 
        SqlParameter[] commandParameters = new SqlParameter[4];

        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@auctionID", auctionid);
        commandParameters[2] = new SqlParameter("@amount", amount);
        commandParameters[3] = new SqlParameter("@buyerID", buyerID);

        string tname = "";


        return RunStoredProcDS(commandName, commandParameters, tname);

    }









    public DataSet getBuyers(string commandName, string prm, int id, string buyer_Name, string buyer_email, string buyer_password,
   int buyer_CreditCardInfoID, int buyer_BillingAddressID, int buyer_ShippingAddressID, int Credits)
    {
       int  buyerSessionID = 0;
       bool buyerSaveInfo = false;

        SqlParameter[] commandParameters = new SqlParameter[12];

        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@BuyerID", id);
        commandParameters[2] = new SqlParameter("@buyer_Name", buyer_Name);
        commandParameters[3] = new SqlParameter("@buyer_email", buyer_email);
        commandParameters[4] = new SqlParameter("@buyer_paypalAccount", buyer_password); 
        commandParameters[5] = new SqlParameter("@buyer_CreditCardInfoID", buyer_CreditCardInfoID);
        commandParameters[6] = new SqlParameter("@buyer_BillingAddressID", buyer_BillingAddressID);
        commandParameters[7] = new SqlParameter("@buyer_ShippingAddressID", buyer_ShippingAddressID);
        commandParameters[8] = new SqlParameter("@buyerSessionID",  buyerSessionID);
        commandParameters[9] = new SqlParameter("@buyerSaveInfo",  buyerSaveInfo); 
        commandParameters[10] = new SqlParameter("@Credits", Credits);
        commandParameters[11] = new SqlParameter("@password", buyer_password);









        string tname = "";


        return RunStoredProcDS(commandName, commandParameters,tname);  


    }








    public DataSet get_BidsDate(string commandName, string prm, int itemAuctionID, int buyerID, DateTime biddate,
     decimal bidamount,  int credits,
        string soldFixedBid, int fee_per_bid, string auctionType)
    {
        
         int @eturnField = 0;
        
        int  bidid=0;
     

        SqlParameter[] commandParameters = new SqlParameter[11];

        commandParameters[0] = new SqlParameter("@opt", prm);
          commandParameters[1] = new SqlParameter("@bidid", bidid);
        commandParameters[2] = new SqlParameter("@auctionID", itemAuctionID);
        commandParameters[3] = new SqlParameter("@buyerID", buyerID);
        commandParameters[4] = new SqlParameter("@biddate", DateTime.Now);

        commandParameters[5] = new SqlParameter("@bidamount", bidamount);
        commandParameters[6] = new SqlParameter("@credits", credits);




        commandParameters[7] = new SqlParameter("@soldFixedBid", soldFixedBid);
        commandParameters[8] = new SqlParameter("@fee_per_bid", fee_per_bid);
        commandParameters[9] = new SqlParameter("@auctionType", auctionType);
        commandParameters[10] = new SqlParameter("@returnField", @eturnField) ;
       commandParameters[10].Direction = ParameterDirection.Output;
         string tblname="tblspecial";


       return RunStoredProcDS(commandName, commandParameters, tblname);  

       
        }


        
    public decimal get_Bids(string commandName, string prm, int itemAuctionID, int buyerID, DateTime biddate,
     decimal bidamount,  int credits,
        string soldFixedBid, int fee_per_bid, string auctionType)
    {
         
         int @eturnField = 0;
      
        int  bidid=0;
 
        SqlParameter[] commandParameters = new SqlParameter[11];

        commandParameters[0] = new SqlParameter("@opt", prm);
          commandParameters[1] = new SqlParameter("@bidid", bidid);
        commandParameters[2] = new SqlParameter("@auctionID", itemAuctionID);
        commandParameters[3] = new SqlParameter("@buyerID", buyerID);
        commandParameters[4] = new SqlParameter("@biddate", DateTime.Now);

        commandParameters[5] = new SqlParameter("@bidamount", bidamount);
        commandParameters[6] = new SqlParameter("@credits", credits);




        commandParameters[7] = new SqlParameter("@soldFixedBid", soldFixedBid);
        commandParameters[8] = new SqlParameter("@fee_per_bid", fee_per_bid);
        commandParameters[9] = new SqlParameter("@auctionType", auctionType);
        commandParameters[10] = new SqlParameter("@returnField", @eturnField) ;
       commandParameters[10].Direction = ParameterDirection.Output; 
         
 
         return RunStoredProcSc(commandName, commandParameters);

     


    }
     



    public Decimal get_Donations(string commandName, string prm, int orgID, int buyerID, Decimal amount,
       int credits
       )
    {
        string tname = "tblgetcredits";


        SqlParameter[] commandParameters = new SqlParameter[5];

        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@orgID", orgID);
        commandParameters[2] = new SqlParameter("@buyerID", buyerID);
        commandParameters[3] = new SqlParameter("@amount", amount);
        commandParameters[4] = new SqlParameter("@credits", credits);


        return RunStoredProcSc(commandName, commandParameters);



    }









    public void get_bids(string commandName, string prm, int itemAuctionID, int buyerID, DateTime biddate,
     decimal bidamount, int credits,
        string soldFixedBid, int fee_per_bid, string auctionType)
    {

        int bidid = 0; int @eturnField = 0;
      
        SqlParameter[] commandParameters = new SqlParameter[11];

        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@bidid", bidid);
        commandParameters[2] = new SqlParameter("@auctionID", itemAuctionID);
        commandParameters[3] = new SqlParameter("@buyerID", buyerID);
        commandParameters[4] = new SqlParameter("@biddate", DateTime.Now);

        commandParameters[5] = new SqlParameter("@bidamount", bidamount);
        commandParameters[6] = new SqlParameter("@credits", credits);




        commandParameters[7] = new SqlParameter("@soldFixedBid", soldFixedBid);
        commandParameters[8] = new SqlParameter("@fee_per_bid", fee_per_bid);
        commandParameters[9] = new SqlParameter("@auctionType", auctionType);
        commandParameters[10] = new SqlParameter("@returnField", @eturnField);
        commandParameters[10].Direction = ParameterDirection.Output; 
         


        RunStoredProc(commandName, commandParameters);




    }







    public DataSet get_orgKnow(string commandName, string prm, int orgID, String  orgKnow)
    {
         

        SqlParameter[] commandParameters = new SqlParameter[3];

        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@orgID", orgID);
        commandParameters[2] = new SqlParameter("@orgKnow", orgKnow); 
        return RunStoredProcDS(commandName, commandParameters, "tableName");
         


    }



    public DataSet get_BidsLog(string commandName, string prm, int itemAuctionID, int buyerID, DateTime biddate,
     decimal bidamount, int credits,
        string soldFixedBid, int fee_per_bid, string auctionType)
    {
        int quantityHold = 0;
        int quantityInStore = 0;
        int quantityInPennybid = 0;
        int quantityInAuction = 0;
        int quantityToShipped = 0;
        int @eturnField = 0;
        int quantitySold = 0;
        int bidid = 0;
        // fee_per_bid = 0;

        SqlParameter[] commandParameters = new SqlParameter[11];

        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@bidid", bidid);
        commandParameters[2] = new SqlParameter("@auctionID", itemAuctionID);
        commandParameters[3] = new SqlParameter("@buyerID", buyerID);
        commandParameters[4] = new SqlParameter("@biddate", DateTime.Now);

        commandParameters[5] = new SqlParameter("@bidamount", bidamount);
        commandParameters[6] = new SqlParameter("@credits", credits);




        commandParameters[7] = new SqlParameter("@soldFixedBid", soldFixedBid);
        commandParameters[8] = new SqlParameter("@fee_per_bid", fee_per_bid);
        commandParameters[9] = new SqlParameter("@auctionType", auctionType);
        commandParameters[10] = new SqlParameter("@returnField", @eturnField);
        commandParameters[10].Direction = ParameterDirection.Output; 
         
        return RunStoredProcDS(commandName, commandParameters , "tableName");

    }






    public Decimal get_Credits(string commandName, string prm,   int buyerID, 
       int credits 
       )
    {
        
        int @returnField=0;


        SqlParameter[] commandParameters = new SqlParameter[4];

        commandParameters[0] = new SqlParameter("@opt", prm);
        commandParameters[1] = new SqlParameter("@buyerID", buyerID);
        commandParameters[2] = new SqlParameter("@credits", credits);
        commandParameters[3] = new SqlParameter("@returnField", returnField);
        commandParameters[3].Direction = ParameterDirection.Output;

        return RunStoredProcSc(commandName, commandParameters);



    }







    public void resetdates(string commandName, int auctionid)
      
       
    {

        SqlParameter[] commandParameters = new SqlParameter[1];

        commandParameters[0] = new SqlParameter("@auctionid", auctionid);
        RunStoredProc(commandName, commandParameters);

 


    }






    public   Decimal RunStoredProcSc(string StoredProcedure, System.Data.SqlClient.SqlParameter[] Paramaters)
    {
        Decimal Results;

        string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;     
        System.Data.SqlClient.SqlConnection Conn = new System.Data.SqlClient.SqlConnection(ConnStr);
        System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand(StoredProcedure, Conn);

        if (Paramaters != null)
        {
            Command.Parameters.Clear();
            Command.Parameters.AddRange(Paramaters);
        }
      

            string opt =  Command.Parameters[0].Value.ToString();

        Command.CommandType = System.Data.CommandType.StoredProcedure;


       
      


        //try
        //{
            Conn.Open();

           

           

           
                if   (StoredProcedure == "get_Credits"  &&  opt== "E")
                {
                    SqlDataReader reader = Command.ExecuteReader();
                   // Results = Command.ExecuteNonQuery();

                    int prmvalue = Paramaters[3].Value.ToString() != ""  ? Convert.ToInt16(Paramaters[3].Value.ToString()) : 0;


                    Results = Convert.ToDecimal(prmvalue);

                }
                else{


                    if (StoredProcedure == "get_Bids" && opt != "X" || (StoredProcedure == "get_Credits" && opt == "S") || (StoredProcedure == "get_Donations" && opt == "T")) 
            {


                 
                 Results = Convert.ToDecimal(Command.ExecuteScalar());




            }
            else
            {
                Results = Command.ExecuteNonQuery();
            }
           // Results = Command.ExecuteNonQuery();
        }

        //}
        //finally
        //{
        //    if (Conn.State == System.Data.ConnectionState.Open)
        //        Conn.Close();
        //    Conn.Dispose();
        //}
        return Results;
    }


     


    public   int RunStoredProc(string StoredProcedure, System.Data.SqlClient.SqlParameter[] Paramaters)
    {
        int Results;
         
	          string ConnStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        System.Data.SqlClient.SqlConnection Conn = new System.Data.SqlClient.SqlConnection(ConnStr);
              

        System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand(StoredProcedure, Conn);

        if (Paramaters != null)
        {
            Command.Parameters.Clear();
            Command.Parameters.AddRange(Paramaters);
        }

        Command.CommandType = System.Data.CommandType.StoredProcedure;
        //try
        //{
            Conn.Open();
            
                Results = Command.ExecuteNonQuery();
             
           // Results = Command.ExecuteNonQuery();
        //}
        //finally
        //{
        //    if (Conn.State == System.Data.ConnectionState.Open)
        //        Conn.Close();
        //    Conn.Dispose();
        //}
        return Results;
    }












    public   DateTime RunStoredProcDate(string StoredProcedure, System.Data.SqlClient.SqlParameter[] Paramaters)
    {
        DateTime Results;

        // string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string ConnStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        System.Data.SqlClient.SqlConnection Conn = new System.Data.SqlClient.SqlConnection(ConnStr);


        System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand(StoredProcedure, Conn);

        if (Paramaters != null)
        {
            Command.Parameters.Clear();
            Command.Parameters.AddRange(Paramaters);
        }

        Command.CommandType = System.Data.CommandType.StoredProcedure;
        try
        {
            Conn.Open();

            Results =  (DateTime)   Command.ExecuteScalar();

            // Results = Command.ExecuteNonQuery();
        }
        finally
        {
            if (Conn.State == System.Data.ConnectionState.Open)
                Conn.Close();
            Conn.Dispose();
        }
        return Results;
    }


     

    public   DataSet RunStoredProcDS(string StoredProcedure, System.Data.SqlClient.SqlParameter[] Paramaters, string tblname)
    {
        DataSet ds = new DataSet();

  //  string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    string ConnStr = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

    System.Data.SqlClient.SqlConnection Conn = new System.Data.SqlClient.SqlConnection(ConnStr);
              

 
        System.Data.SqlClient.SqlCommand Command = new System.Data.SqlClient.SqlCommand(StoredProcedure, Conn);


        try
        {


            SqlDataAdapter daD = new SqlDataAdapter(StoredProcedure, Conn);
            /// daD.SelectCommand.CommandTimeout = 790;

            foreach (object prm in Paramaters)
            {
                daD.SelectCommand.Parameters.Add(prm);
            }

            tblname = tblname == "" ? "Table" : tblname;

            ds.Tables.Clear();
            

            /////daD.SelectCommand.Parameters.Add(Paramaters);

            daD.SelectCommand.CommandType = CommandType.StoredProcedure;

            Conn.Open();

            daD.Fill(ds, tblname);

            Conn.Close();
            Conn.Dispose();



        }
        catch (Exception ex) { string err = ex.Message; }


        //catch (Exception ex)
        //}
        //{
        //    ErrMessage = ex.Message;




         
        return ds;
    }










}
