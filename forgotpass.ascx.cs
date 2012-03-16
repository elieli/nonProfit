namespace Shof.modules
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;
	using System.Collections.Specialized;
	using System.IO;
	using System.Web.Mail;
	using System.Configuration;

	//using D3DM.ECom.BusinessLogic;

	/// <summary>
	///		Summary description for forgotpass.
	/// </summary>
	public partial class forgotpass : System.Web.UI.UserControl
	{
		private string emailNotificationCustomerFrom = (string)ConfigurationSettings.AppSettings.Get("emailNotificationCustomerFrom");
		private string emailNotificationCustomerTo   = (string)ConfigurationSettings.AppSettings.Get("emailNotificationCustomerTo");
		private string emailNotificationCustomerCc   = (string)ConfigurationSettings.AppSettings.Get("emailNotificationCustomerCc");
		private string emailNotificationCustomerBcc  = (string)ConfigurationSettings.AppSettings.Get("emailNotificationCustomerBcc");
		private string emailNotificationVendorFrom = (string)ConfigurationSettings.AppSettings.Get("emailNotificationVendorFrom");
		private string emailNotificationVendorTo   = (string)ConfigurationSettings.AppSettings.Get("emailNotificationVendorTo");
		private string emailNotificationVendorCc   = (string)ConfigurationSettings.AppSettings.Get("emailNotificationVendorCc");
		private string emailNotificationVendorBcc  = (string)ConfigurationSettings.AppSettings.Get("emailNotificationVendorBcc");
		private string emailNotificationWebMasterFrom = (string)ConfigurationSettings.AppSettings.Get("emailNotificationWebMasterFrom");
		private string emailNotificationWebMasterTo   = (string)ConfigurationSettings.AppSettings.Get("emailNotificationWebMasterTo");
		private string emailNotificationWebMasterCc   = (string)ConfigurationSettings.AppSettings.Get("emailNotificationWebMasterCc");
		private string emailNotificationWebMasterBcc  = (string)ConfigurationSettings.AppSettings.Get("emailNotificationWebMasterBcc");

		private bool emailNotification = ((string)ConfigurationSettings.AppSettings.Get("emailNotification")=="yes");
		private string siteName = (string)ConfigurationSettings.AppSettings.Get("siteName");
		private string smtpServer = (string)ConfigurationSettings.AppSettings.Get("smtpServer");

		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorPassword;
		protected System.Web.UI.WebControls.TextBox txtLogin;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorLogin;
		protected System.Web.UI.WebControls.TextBox txtConfirmPassword;
		protected System.Web.UI.WebControls.CompareValidator CompareValidatorConfirmPassword;

		protected void Page_Load(object sender, System.EventArgs e)
		{
		}

		private void btnForgotpass_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (Page.IsValid)
			{
				if (this.emailNotification)
				{
					BLUser wUser = new BLUser();
					wUser.EMail = txtEMail.Text.Trim().ToLower();
					wUser.Retrieve();
					if (wUser.ID>0 && wUser.Enabled)
					{
						StringWriter writer = new StringWriter();
						Server.Execute("email/emailForgotPass.aspx?email="+wUser.EMail, writer);
						string strhtmlbody = writer.ToString();
						//					Response.Write(strhtmlbody);
						//					Response.End();
						MailMessage objMailMessage = new MailMessage();
						objMailMessage.Subject = siteName+": your password";
						objMailMessage.From = this.emailNotificationCustomerFrom;
						objMailMessage.To = wUser.EMail;
						objMailMessage.Cc = this.emailNotificationCustomerCc;
						objMailMessage.Bcc = this.emailNotificationCustomerBcc;
						objMailMessage.Body = strhtmlbody;
						objMailMessage.BodyFormat = MailFormat.Html;
						SmtpMail.SmtpServer = this.smtpServer;
						SmtpMail.Send( objMailMessage );
					}
				}
				Response.Redirect(".?page=login");
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnForgotpass.Click += new System.Web.UI.ImageClickEventHandler(this.btnForgotpass_Click);

		}
		#endregion

	}
}
