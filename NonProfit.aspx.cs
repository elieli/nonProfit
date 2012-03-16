using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class NonProfit : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Code for the Countdown timer
        DateTime dtNow = DateTime.Now;
        DateTime dtFuture = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, 23, 59, 59);
        //DateTime dtFuture = new DateTime(2009, 10, 12, 14, 59, 59);

        TimeSpan ts = dtFuture.Subtract(dtNow);

        long amount = (long)ts.TotalMilliseconds;

        /////////////////////// lblDay.Text = dtNow.ToString("ddd, MMMM dd, yyyy");

        string code = @"<script language=""javascript"" type=""text/javascript"">
             <!--
             //start
             //######################################################################################
             // Author: ricocheting.com
             // For: public release (freeware)
             // Date: 4/24/2003 (update: 5/15/2009)
             // Description: displays the amount of time until the dateFuture entered below.
             //###################################
             amount=" + amount + @";
             function GetCount(){
             
             if(amount < 0)
             {
                // time is already past, reload the page with the new deal
                window.location.reload(true);
             }
             else
             {
                // date is still good
                 days=0;hours=0;mins=0;secs=0;out="""";
                 var tempAmount = Math.floor(amount/1000);
                 days=Math.floor(tempAmount/86400);
                 tempAmount=tempAmount%86400;
                 hours=Math.floor(tempAmount/3600);
                 tempAmount=tempAmount%3600;
                 mins=Math.floor(tempAmount/60);//minutes
                 tempAmount=tempAmount%60;
                 secs=Math.floor(tempAmount);//seconds
                 if(days != 0)s
                 {
                    out += pad(days.toString(),'0').toString() + "":"";
                 }
                 if(days != 0 || hours != 0)
                 {
                    out += pad(hours.toString(),'0').toString() + "":"";
                 }
                 if(days != 0 || hours != 0 || mins != 0)
                 {
                        out += pad(mins.toString(),'0').toString() + "":"";}
                        out += pad(secs.toString(),'0').toString();
                        document.getElementById('countbox').innerHTML=out;
                        setTimeout(""GetCount()"", 1000);
                        amount=amount-1000;
                }
             }

             window.onload=GetCount;
             function pad(val, ch)
             {
                if (val<10)
                return ch+val;
                return val;
             }
             // -->
             </script>";

        ClientScriptManager csm = Page.ClientScript;

        csm.RegisterStartupScript(Page.GetType(), "timer", code, false);

    }
}
//action="https://payments.ebay.com/ws/eBayISAPI.dll?CheckoutProcessor&cartid=98180196202&ryp_cpm_continue=true&rp=-886693885" method="post" name="pageForm">





// https://www.paypal.com/subscriptions/business=nora%40paypal.com&item_name=Baseball+Hat+Monthly&item_number=123&image_url=https%3A//www.yoursite.com/logo.gif&no_shipping=1&return=http%3A//www.yoursite.com/thankyou.htm&cancel_return=http%3A//www.yoursite.com/cancel.htm&no_note=1&a1=0.00&p1=1&t1=W&a2=5.00&p2=2&t2=M&a3=50.00&p3=1&t3=Y&src=1&sra=1& srt=5&no_note=1&custom=customcode&invoice=invoicenumber&usr_manage=1