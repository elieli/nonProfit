using System;
using System.Data;
using System.Collections;

using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;   
//using System.Web.HttpRequest;
 
using System.Drawing;
using System.Xml;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
/// <summary>
/// Summary description for clsPages
/// </summary>
public class clsPages
{ 
    string strPhysicalPath = ""  ;
    public ArrayList arll = new ArrayList();
    public ArrayList allPages = new ArrayList();
        public string[] arn = { "DIimgID", "DInextpage", "DIdonatename", "DIimagesrc", "DIAmount", "DIImgPhotoSrc", "DRIdonateText" };

     public string[] ara = null;

     public string page  ;
     public string paths  ;
     public string[] donateImgPhoto = new string[55];
     public string[] donateimagesrc = new string[55];
     public string[] donateImgPhotoSrc = new string[55];
     public string[] donateImgNpage = new string[55];
     public string[] donateImgText = new string[55];
     public string[] donateImgAmt = new string[55];
     public string[] donateImgNumber = new string[55];
     public string[] donateImgName = new string[55];


    XmlDocument HomeSettings = new XmlDocument();

    
    
    
    
    public clsPages(string pager , string path)
    {
        paths = path; page = pager;
        ArrayList aaa = xmlToarray(false);
      

        TableImg_Load(aaa);
	}



   
    
    
    
    
    
    
    protected void TableImg_Load(ArrayList aaa)
    {
        messages.script = "";


        for (int indx = 0; indx <= aaa.Count - 1; indx++)
        {

            ArrayImg_Load(aaa, indx);
            
        }
    }









    protected void ArrayImg_Load(ArrayList aaa, int indx)
    {

        ArrayList arl = (ArrayList)(((array_list)aaa[indx]).arl);
        

        donateImgNumber = arl.Count > 0 ? (string[])arl[0] : donateImgNumber;
        donateImgNpage = arl.Count > 0 ? (String[])arl[1] : donateImgNpage;
        donateImgName = arl.Count > 0 ? (String[])arl[2] : donateImgName;

        donateimagesrc = arl.Count > 0 ? (String[])arl[3] : donateimagesrc;
        donateImgAmt = arl.Count > 0 ? (String[])arl[4] : donateImgAmt;
        donateImgPhotoSrc = arl.Count > 0 ? (String[])arl[5] : donateImgPhotoSrc;
      

        donateImgText = arl.Count > 0 ? (String[])arl[6] : donateImgText;


        if (indx == 0)
        {
          //////////////  messages.cnt = find(donateImgNumber);

        }

 


    }














    protected ArrayList xmlToarray(bool prm)
    {
        int xx = 0;
        /// Dispose();
        string strPhysicalPath = "";



        arrays arss = new arrays();

        /// ArrayList arll = new ArrayList(arss.arll);

      



        //////////try
        //////////{

        XmlDocument HomeSettings = new XmlDocument();

        // m_pages


        strPhysicalPath = paths;


        ////strPhysicalPath = Request.MapPath("~\\XML\\changeText.xml");
        //messages.xml.Load(strPhysicalPath);


        HomeSettings.Load(strPhysicalPath);















        XmlNodeList CurrNodeaa = HomeSettings.SelectNodes("DonateExl/" + page + "/DonateWall");




        // Donate Wall    0
        string firstname_ = "";


        string name = messages.firstname = firstname_  + " " + messages.lastname;

        string photo = messages.photo;
        string prmm = messages.number;
        string honore = messages.honor;
        string urlsrc = messages.urlsrc;
        string amt = Convert.ToString(messages.amt);



        string[] ar = { "DWlinknumber", "DWdonatename", "DWimagesrc", "DWamt", "DWImgPhotoSrc", "DWdonateText" };

        string[] arr = { honore, name, urlsrc, amt, photo, prmm };
       
        arll = messages.xmlToarrays(HomeSettings, "DonateExl/" + page + "/DonateWall", ar, ar, arll);



         
          







        CurrNodeaa = HomeSettings.SelectNodes("DonateExl/" + page + "/Donateimages");

        //<DInextpage>Default.aspx</DInextpage>
        //  <DIdonatename>Moishe   Moish</DIdonatename>
        //  <DIimagesrc>R1C3.jpg</DIimagesrc>
        //  <DIImgPhotoSrc>images/picChild.gif</DIImgPhotoSrc>
        //  <DIdonateText>donated by Moishe   Moish in honor  of baruch bruch</DIdonateText>
        messages.cnt = 0;

         


         
        urlsrc = "images/pic4.jpg";


        

        arn[6] = "DCIdonateText";

 
        string[] arrns = { "Page3", name, urlsrc, amt, "images/pic2.jpg", honore };
        

        messages.xmlToarrays(HomeSettings, "DonateExl/" + page + "/DonateCenterImg", arn, arrns, arll);

















        string DIimgID = null;
        string DIdonateText = null;

        ////foreach (XmlNode xms in CurrNodeaa)
        ////{
        ////    XmlNodeList CurrNodeC = xms.ChildNodes;
        ////    //  CurrNode =  xm.InnerText;
        ////    CurrNodeC = xms.ChildNodes;



        ////    foreach (XmlNode xmm in CurrNodeC)
        ////    {
        ////        if (xmm.Name == "DIimgID")
        ////        {
        ////            DIimgID = xmm.InnerText == null || xmm.InnerText == "" ? "" : xmm.InnerText;

        ////        }
        ////        if (xmm.Name == "DIdonateText")
        ////        {
        ////            DIdonateText = xmm.InnerText == null || xmm.InnerText == "" ? "" : xmm.InnerText;
        ////            HtmlGenericControl dvText = (HtmlGenericControl)this.FindControl(DIimgID);

        ////            //   HtmlGenericControl dvText = (HtmlGenericControl)this.FindControl("dvText");

        ////            dvText.InnerText = DIdonateText;


        ////        }



        ////    }


        ////}

        //// string[] arns = { "DInextpage", "DIdonatename", "DIimagesrc", "DWamt", "DIImgPhotoSrc", "DTdonateText" };







        name = "eli";
        amt = "10";
        honore = "   donated by Moishe   Moish in honor  of baruch bruch";

        //   DonateRightimages    2

        arn[6] = "DRIdonateText";
        string[] arrrns = { "24", "Page4", name, urlsrc, amt, "images/pic2.jpg", honore };


        messages.xmlToarrays(HomeSettings, "DonateExl/" + page + "/DonateRightimages", arn, arrrns, arll);



        //  DonateLeftimages          3
        arn[6] = "DLIdonateText";
        string[] arnsl = { "24", "Page4", name, urlsrc, amt, "images/pic2.jpg", honore };


        messages.xmlToarrays(HomeSettings, "DonateExl/" + page + "/DonateLeftimages", arn, arnsl, arll);






        //  DonateTopImg            4
        arn[6] = "DTIdonateText";
        string[] arnsDTI = { "24", "Page4", name, urlsrc, amt, "images/pic2.jpg", honore };
        messages.xmlToarrays(HomeSettings, "DonateExl/" + page + "/DonateTopImg", arn, arnsDTI, arll);



        //  DonateTopRightImg             5
        arn[6] = "DTRIdonateText";
        string[] arnsDTRI = { "24", "Page4", name, urlsrc, amt, "images/pic2.jpg", honore };
        messages.xmlToarrays(HomeSettings, "DonateExl/" + page + "/DonateTopRightImg", arn, arnsDTRI, arll);


        //  DonateTopLeftImg                  6
        arn[6] = "DTLIdonateText";
        string[] arnsDTLI = { "24", "Page4", name, urlsrc, amt, "images/pic2.jpg", honore };
        messages.xmlToarrays(HomeSettings, "DonateExl/" + page + "/DonateTopLeftImg", arn, arnsDTLI, arll);






        //  DonateWallIcon        7
        arn[6] = "DWWIdonateText"; arn[6] = "DWWIdonateText";
        string[] arnsDWI = { "24", "Page4", name, urlsrc, amt, "images/pic2.jpg", honore };
        messages.xmlToarrays(HomeSettings, "DonateExl/" + page + "/DonateWallIcon", arn, arnsDWI, arll);





        //  DonateWallIcon1        8
        arn[6] = "DWI2donateText";
        string[] arnsDWI2 = { "24", "Page4", name, urlsrc, amt, "images/pic2.jpg", honore };
        messages.xmlToarrays(HomeSettings, "DonateExl/" + page + "/DonateWallIcon2", arn, arnsDWI2, arll);

        //  DonateWallIcon1       9
        arn[6] = "DWI3donateText";
        string[] arnsDWI3 = { "24", "Page4", name, urlsrc, amt, "images/pic2.jpg", honore };
        messages.xmlToarrays(HomeSettings, "DonateExl/" + page + "/DonateWallIcon3", arn, arnsDWI3, arll);








        //  DonateTopBanner              10

        ///ara = arn;

        arn[6] = "DTBdonateText";
        string[] arnsDTB = { "24", "Page4", name, urlsrc, amt, "images/pic2.jpg", honore };
        messages.xmlToarrays(HomeSettings, "DonateExl/" + page + "/DonateTopBanner", arn, arnsDTB, arll);


        //  DonateSecondBanner                  11
        arn[6] = "DSBdonateText";
        string[] arnsDSB = { "24", "Page4", name, urlsrc, amt, "images/pic2.jpg", honore };
        messages.xmlToarrays(HomeSettings, "DonateExl/" + page + "/DonateSecondBanner", arn, arnsDSB, arll);


        //  DonateThirdBanner                       12
        arn[6] = "DTHBdonateText";
        string[] arnsDTHB = { "24", "Page4", name, urlsrc, amt, "images/pic2.jpg", honore };
        messages.xmlToarrays(HomeSettings, "DonateExl/" + page + "/DonateThirdBanner", arn, arnsDTHB, arll);














        ///   Donate Top Img 13

        arn[6] = "DBBdonateText";


        ///  string[] arns = { "DInextpage", "DIdonatename", "DIimagesrc", "DWamt", "DIImgPhotoSrc", "DCIdonateText" };
        string[] arrnsb = { "Page3", name, urlsrc, amt, "images/pic2.jpg", honore };
        // string[] arrns = { honore, name, urlsrc, amt, prmm, "Tester" };

        messages.xmlToarrays(HomeSettings, "DonateExl/" + page + "/DonateBottomimages", arn, arrnsb, arll);





          

        arraylists arlists = new  arraylists();
        arlists.arlpages = arll;

        allPages.Add(arlists);


         


        return arll;
      

    }







}
public class arraylists
{

    public ArrayList arlpages = new ArrayList();

}
