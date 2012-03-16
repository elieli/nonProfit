using System;
using System.Data;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;

namespace Lib
{
	/// <summary>
	/// Summary description for lib.
	/// </summary>
    public class lib 
	{
		/// <summary>
		///	generate html block Spacer
		/// </summary>
		/// <param name="width">spacer's width</param>
		/// <param name="height">spacer's height</param>
		/// <returns>html code for required spacer</returns>
		public static string Spacer(int width, int height)
		{
			return "<div style=\"width:"+width.ToString()+
				"px; height:"+height.ToString()+"px\"><spacer type=\"block\" width=\""+
				width.ToString()+"\" height=\""+height.ToString()+"\"/></div>";
		}

		public static string ShowCreditNumber(string cnum)
		{
			return "*".PadLeft(cnum.Length-((cnum.Length>=16)?4:0),'*')+((cnum.Length>=16)?cnum.Substring(cnum.Length-4,4):"");
		}

		public static ICollection CreateMonths() 
		{
			DataTable dt = new DataTable();
			DataRow dr;
 
			dt.Columns.Add(new DataColumn("Value", typeof(string)));
			dt.Columns.Add(new DataColumn("Text", typeof(string)));
 
			dr = dt.NewRow();
			dr[0] = "";
			dr[1] = "--- Month ---";
			dt.Rows.Add(dr);

			for (int i = 0; i <= 11; i++) 
			{
				dr = dt.NewRow();
 
				dr[0] = (i+1).ToString();
				dr[1] = DateTimeFormatInfo.InvariantInfo.MonthNames[i];
				dt.Rows.Add(dr);
			}
 
			DataView dv = new DataView(dt);
			return dv;
		}

		public static ICollection CreateYears(int dFrom, int dTo, int dStep) 
		{
			DataTable dt = new DataTable();
			DataRow dr;
 
			dt.Columns.Add(new DataColumn("Value", typeof(string)));
			dt.Columns.Add(new DataColumn("Text", typeof(string)));
 
			dr = dt.NewRow();
			dr[0] = "";
			dr[1] = "--- Year ---";
			dt.Rows.Add(dr);

			if (dStep>0)
				for (int i=(int)DateTime.Today.Year+dFrom;i<(int)DateTime.Today.Year+dTo;i+=dStep) 
				{
					dr = dt.NewRow();
 
					dr[0] = i.ToString();
					dr[1] = i.ToString();
					dt.Rows.Add(dr);
				}
			else 
				for (int i=(int)DateTime.Today.Year+dFrom;i>(int)DateTime.Today.Year+dTo;i+=dStep) 
				{
					dr = dt.NewRow();
 
					dr[0] = i.ToString();
					dr[1] = i.ToString();
					dt.Rows.Add(dr);
				}
 
			DataView dv = new DataView(dt);
			return dv;
		}

		public static ICollection CreateCountries() 
		{
			
			DataTable dt = new DataTable();
			DataRow dr;
 
			dt.Columns.Add(new DataColumn("Value", typeof(string)));
			dt.Columns.Add(new DataColumn("Text", typeof(string)));
 
			dr = dt.NewRow();
			dr[0] = "";
			dr[1] = "--- Select ---";
			dt.Rows.Add(dr);

			#region AddCountries	
			dr=dt.NewRow();dr[0]="AF";dr[1]="Afghanistan";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AL";dr[1]="Albania";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="DZ";dr[1]="Algeria";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AS";dr[1]="American Samoa";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AD";dr[1]="Andorra";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AO";dr[1]="Angola";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AI";dr[1]="Anguilla";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AQ";dr[1]="Antarctica";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AG";dr[1]="Antigua And Barbuda";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AR";dr[1]="Argentina";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AM";dr[1]="Armenia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AW";dr[1]="Aruba";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AU";dr[1]="Australia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AT";dr[1]="Austria";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AZ";dr[1]="Azerbaijan";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BS";dr[1]="Bahamas";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BH";dr[1]="Bahrain";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BD";dr[1]="Bangladesh";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BB";dr[1]="Barbados";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BY";dr[1]="Belarus";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BE";dr[1]="Belgium";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BZ";dr[1]="Belize";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BJ";dr[1]="Benin";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BM";dr[1]="Bermuda";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BT";dr[1]="Bhutan";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BO";dr[1]="Bolivia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BA";dr[1]="Bosnia And Herzegovina";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BW";dr[1]="Botswana";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BV";dr[1]="Bouvet Island";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BR";dr[1]="Brazil";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="IO";dr[1]="British Indian Ocean";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BN";dr[1]="Brunei Darussalam";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BG";dr[1]="Bulgaria";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BF";dr[1]="Burkina Faso";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="BI";dr[1]="Burundi";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="KH";dr[1]="Cambodia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CM";dr[1]="Cameroon";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CA";dr[1]="Canada";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CV";dr[1]="Cape Verde";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="KY";dr[1]="Cayman Islands";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CF";dr[1]="Central African Rep.";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="td";dr[1]="Chad";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CL";dr[1]="Chile";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CN";dr[1]="China";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CX";dr[1]="Christmas Island";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CC";dr[1]="Cocos (Keeling) Islands";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CO";dr[1]="Colombia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="KM";dr[1]="Comoros";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CG";dr[1]="Congo";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CK";dr[1]="Cook Islands";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CR";dr[1]="Costa Rica";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CI";dr[1]="Cote D'Ivoire";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="hr";dr[1]="Croatia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CU";dr[1]="Cuba";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CY";dr[1]="Cyprus";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CZ";dr[1]="Czech Republic";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="DK";dr[1]="Denmark";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="DJ";dr[1]="Djibouti";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="DM";dr[1]="Dominica";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="DO";dr[1]="Dominican Republic";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TP";dr[1]="East Timor";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="EC";dr[1]="Ecuador";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="EG";dr[1]="Egypt";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SV";dr[1]="El Salvador";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GQ";dr[1]="Equatorial Guinea";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="ER";dr[1]="Eritrea";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="EE";dr[1]="Estonia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="ET";dr[1]="Ethiopia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="FK";dr[1]="Falkland Islands";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="FO";dr[1]="Faroe Islands";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="FJ";dr[1]="Fiji";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="FI";dr[1]="Finland";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="FR";dr[1]="France";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GF";dr[1]="French Guiana";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="PF";dr[1]="French Polynesia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TF";dr[1]="French Southern Terr.";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GA";dr[1]="Gabon";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GM";dr[1]="Gambia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GE";dr[1]="Georgia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="DE";dr[1]="Germany";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GH";dr[1]="Ghana";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GI";dr[1]="Gibraltar";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GR";dr[1]="Greece";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GL";dr[1]="Greenland";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GD";dr[1]="Grenada";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GP";dr[1]="Guadeloupe";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GU";dr[1]="Guam";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GT";dr[1]="Guatemala";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GN";dr[1]="Guinea";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GW";dr[1]="Guinea-Bissau";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GY";dr[1]="Guyana";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="HT";dr[1]="Haiti";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="HM";dr[1]="Heard Island";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="HN";dr[1]="Honduras";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="HK";dr[1]="Hong Kong";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="HU";dr[1]="Hungary";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="IS";dr[1]="Iceland";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="IN";dr[1]="India";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="ID";dr[1]="Indonesia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="IR";dr[1]="Iran";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="IQ";dr[1]="Iraq";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="IE";dr[1]="Ireland";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="IL";dr[1]="Israel";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="IT";dr[1]="Italy";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="JM";dr[1]="Jamaica";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="JP";dr[1]="Japan";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="JO";dr[1]="Jordan";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="KZ";dr[1]="Kazakstan";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="KE";dr[1]="Kenya";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="KI";dr[1]="Kiribati";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="KP";dr[1]="Korea, Democratic";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="KR";dr[1]="Korea, Republic Of";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="KW";dr[1]="Kuwait";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="KG";dr[1]="Kyrgyzstan";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="LA";dr[1]="Lao";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="LV";dr[1]="Latvia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="LB";dr[1]="Lebanon";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="LS";dr[1]="Lesotho";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="LR";dr[1]="Liberia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="LY";dr[1]="Libyan Arab Jamahiriya";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="LI";dr[1]="Liechtenstein";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="LT";dr[1]="Lithuania";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="LU";dr[1]="Luxembourg";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MO";dr[1]="Macau";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MK";dr[1]="Macedonia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MG";dr[1]="Madagascar";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MW";dr[1]="Malawi";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MY";dr[1]="Malaysia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MV";dr[1]="Maldives";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="ML";dr[1]="Mali";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MT";dr[1]="Malta";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MH";dr[1]="Marshall Islands";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MQ";dr[1]="Martinique";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MR";dr[1]="Mauritania";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MU";dr[1]="Mauritius";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="YT";dr[1]="Mayotte";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MX";dr[1]="Mexico";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="FM";dr[1]="Micronesia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MD";dr[1]="Moldova, Republic Of";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MC";dr[1]="Monaco";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MN";dr[1]="Mongolia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MS";dr[1]="Montserrat";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MA";dr[1]="Morocco";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MZ";dr[1]="Mozambique";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MM";dr[1]="Myanmar";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="NA";dr[1]="Namibia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="NR";dr[1]="Nauru";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="NP";dr[1]="Nepal";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="NL";dr[1]="Netherlands";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AN";dr[1]="Netherlands Antilles";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="NC";dr[1]="New Caledonia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="NZ";dr[1]="New Zealand";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="NI";dr[1]="Nicaragua";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="NE";dr[1]="Niger";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="NG";dr[1]="Nigeria";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="NU";dr[1]="Niue";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="NF";dr[1]="Norfolk Island";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="MP";dr[1]="Northern Mariana Islands";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="NO";dr[1]="Norway";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="OM";dr[1]="Oman";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="PK";dr[1]="Pakistan";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="PW";dr[1]="Palau";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="PS";dr[1]="Palestinian Territory";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="PA";dr[1]="Panama";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="PG";dr[1]="Papua New Guinea";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="PY";dr[1]="Paraguay";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="PE";dr[1]="Peru";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="PH";dr[1]="Philippines";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="PN";dr[1]="Pitcairn";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="PL";dr[1]="Poland";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="PT";dr[1]="Portugal";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="PR";dr[1]="Puerto Rico";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="QA";dr[1]="Qatar";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="RE";dr[1]="Reunion";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="RO";dr[1]="Romania";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="RU";dr[1]="Russian Federation";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="RW";dr[1]="Rwanda";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SH";dr[1]="Saint Helena";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="KN";dr[1]="Saint Kitts And Nevis";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="LC";dr[1]="Saint Lucia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="PM";dr[1]="Saint Pierre";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="VC";dr[1]="Saint Vincent";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="WS";dr[1]="Samoa";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SM";dr[1]="San Marino";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="ST";dr[1]="Sao Tome And Principe";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SA";dr[1]="Saudi Arabia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SN";dr[1]="Senegal";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SC";dr[1]="Seychelles";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SL";dr[1]="Sierra Leone";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SG";dr[1]="Singapore";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SK";dr[1]="Slovakia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SI";dr[1]="Slovenia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SB";dr[1]="Solomon Islands";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SO";dr[1]="Somalia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="ZA";dr[1]="South Africa";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GS";dr[1]="South Georgia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="ES";dr[1]="Spain";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="LK";dr[1]="Sri Lanka";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SD";dr[1]="Sudan";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SR";dr[1]="Suriname";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SJ";dr[1]="Svalbard And Jan Mayen";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SZ";dr[1]="Swaziland";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SE";dr[1]="Sweden";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CH";dr[1]="Switzerland";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="SY";dr[1]="Syrian Arab Republic";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TW";dr[1]="Taiwan";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TJ";dr[1]="Tajikistan";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TZ";dr[1]="Tanzania";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TH";dr[1]="Thailand";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TG";dr[1]="Togo";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TK";dr[1]="Tokelau";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TO";dr[1]="Tonga";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TT";dr[1]="Trinidad And Tobago";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TN";dr[1]="Tunisia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TR";dr[1]="Turkey";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TM";dr[1]="Turkmenistan";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TC";dr[1]="Turks And Caicos Islands";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="TV";dr[1]="Tuvalu";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="UG";dr[1]="Uganda";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="UA";dr[1]="Ukraine";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="AE";dr[1]="United Arab Emirates";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="GB";dr[1]="United Kingdom";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="US";dr[1]="United States";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="UY";dr[1]="Uruguay";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="UM";dr[1]="US Min Outlying Islands";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="UZ";dr[1]="Uzbekistan";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="VU";dr[1]="Vanuatu";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="VA";dr[1]="Vatican City State";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="VE";dr[1]="Venezuela";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="VN";dr[1]="Viet Nam";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="VG";dr[1]="Virgin Islands, British";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="VI";dr[1]="Virgin Islands, U.S.";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="WF";dr[1]="Wallis And Futuna";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="EH";dr[1]="Western Sahara";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="YE";dr[1]="Yemen";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="YU";dr[1]="Yugoslavia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="CD";dr[1]="Zaire";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="ZM";dr[1]="Zambia";dt.Rows.Add(dr);
			dr=dt.NewRow();dr[0]="ZW";dr[1]="Zimbabwe";dt.Rows.Add(dr);
			#endregion

			DataView dv = new DataView(dt);
			return dv;
		}

		public class linkHelper 
		{
			private string url;
			private string title;

			public linkHelper(string url, string title) 
			{
				this.url = url;
				this.title= title;
			}

			public string Url	
			{
				get { return url; }
				set { url = value; }
			}

			public string Title 
			{
				get { return title; }
				set { title = value; }
			}
		}

		public static DataTable GetPage(DataTable table, int StartIndex, int EndIndex)
		{
			DataTable _Newtable = table.Clone();
			_Newtable.Rows.Clear();

			if( EndIndex > table.Rows.Count )
			{
				EndIndex = table.Rows.Count;
			}
			for(int i = StartIndex -1; i < EndIndex; ++i)
			{
				DataRow _row = _Newtable.NewRow();
				for(int j=0; j < table.Columns.Count; j++)
				{
					_row[j] = table.Rows[i][j];
				}
				_Newtable.Rows.Add(_row);
			}
			
			return _Newtable;
		}

		public static DataView GetPage(DataView list, int startPos, int endPos)
		{
			DataTable tmptable = list.Table.Clone();
			
			int count = 0;
			foreach(DataRowView row in list)
			{
				count++;
				if( count >= startPos && count <= endPos )
				{
					DataRow newRow = tmptable.NewRow();
					for(int i=0; i < tmptable.Columns.Count; ++i)
					{
						newRow[i] = row[i];
					}
					tmptable.Rows.Add(newRow);
				}
			}

			return tmptable.DefaultView;
		}

		public static string GetMonthName(int month)
		{
			string[] nameMonth = new string[12]{"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
			return nameMonth[month-1];
		}

        public static string GetUPSAddressValidationDescription(float val)
        {
            string result;
            if( val == 1 )
                result = "Exact match.<br/>All parameters you entered are correct and correspond to each other.";
            else if( val >= 0.95 )
                result = "Very close match.<br/>All parameters you entered are correct, but one of them could be missing.";
            else if( val >= 0.9 )
                result = "Close match.<br/>One of parameters you entered can be incorrect. Please, check them up.";
            else if( val >= 0.7 )
                result = "Possible match.<br/>Please, check up parameters you entered.";
            else
                result = "Pure match.<br/>Please, check up parameters you entered. Some or all of them are incorrect.";
            return result;
        }

		public static string GetMyCountry(string longCountryName)
		{
			switch( longCountryName )
			{
				case "ARGENTINA":
					return "AR";
				case "ARMENIA":
					return "AM";
				case "AUSTRALIA":
					return "AU";
				case "AUSTRIA":
					return "AT";
				case "AZERBAIJAN":
					return "AZ";
				case "BELARUS":
					return "BY";
				case "BELGIUM":
					return "BE";
				case "BOLIVIA":
					return "BO";
				case "BRAZIL":
					return "BR";
				case "BULGARIA":
					return "BG";
				case "CANADA":
					return "CA";
				case "CHILE":
					return "CL";
				case "CHINA":
					return "CN";
				case "COLOMBIA":
					return "CO";
				case "CONGO":
					return "CG";
				case "COSTA RICA":
					return "CR";
				case "CYPRUS":
					return "CY";
				case "CZECH REPUBLIC":
					return "CZ";
				case "DENMARK":
					return "DK";
				case "ENGLAND":
					return "GB";
				case "ESTONIA":
					return "EE";
				case "FINLAND":
					return "FI";
				case "FRANCE":
					return "FR";
				case "GERMANY":
					return "DE";
				case "GREECE":
					return "GR";
				case "GUATEMALA":
					return "GT";
				case "HUNGARY":
					return "HU";
				case "INDIA":
					return "IN";
				case "IRELAND":
					return "IE";
				case "ISRAEL":
					return "IL";
				case "ITALY":
					return "IT";
				case "JAPAN":
					return "JP";
				case "KAZAKHSTAN":
					return "KZ";
				case "LATVIA":
					return "LV";
				case "LITHUANIA":
					return "LT";
				case "MOLDOVA":
					return "MD";
				case "MOROCCO":
					return "MA";
				case "NEPAL":
					return "NP";
				case "NETHERLANDS":
					return "NL";
				case "NEW ZELAND":
					return "NZ";
//				case "NORTHERN IRELAND":
//					return "AR";
				case "NORWAY":
					return "NO";
				case "PANAMA":
					return "PA";
				case "PARAGUAY":
					return "PY";
				case "PERU":
					return "PE";
//				case "REPUBLIC OF CRIMEA":
//					return "AR";
				case "ROMANIA":
					return "RO";
				case "RUSSIA":
					return "RU";
//				case "SCOTLAND":
//					return "AR";
				case "SINGAPORE":
					return "SG";
				case "SLOVAKIA":
					return "SK";
				case "SOUTH AFRICA":
					return "ZA";
				case "SPAIN":
					return "ES";
				case "SWEDEN":
					return "SE";
				case "SWITZERLAND":
					return "CH";
				case "THAILAND":
					return "TH";
				case "TUNISIA":
					return "TN";
				case "UKRAINE":
					return "UA";
				case "URUGUAY":
					return "UY";
				case "USA":
					return "US";
				case "UZBEKISTAN":
					return "UZ";
				case "VENEZUELA":
					return "VE";
				default:
					return string.Empty;
			}
		}
		private lib(){}
	}
}
