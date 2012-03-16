/************************************************************************
 * SqlWhereBuilder.js
 * 
 *  A SQL Where Clause Builder user interface control as a
 *  javascript, client-side object
 *
 *  This script was initially created to support an ASP.NET server control
 *  but it may be used purely as a client-side object as well.
 *
 *  written by Mike Ellison, 25-November-2004
 *
 ************************************************************************
 *  Copyright (c) 2004 Mike Ellison.  All rights reserved.
 *  
 *  Redistribution and use in source and binary forms, with or without 
 *  modification, are permitted provided that the following conditions are met:
 *  
 *    * Redistributions of source code must retain the above copyright notice, 
 *      this list of conditions and the following disclaimer. 
 *  	
 *    * Redistributions in binary form must reproduce the above copyright notice, 
 *      this list of conditions and the following disclaimer in the documentation 
 *  	and/or other materials provided with the distribution.
 *  	
 *    * The name of the author may not be used to endorse or promote products 
 *      derived from this software without specific prior written permission. 
 *  
 *  THIS SOFTWARE IS PROVIDED BY THE AUTHOR "AS IS" AND ANY EXPRESS OR IMPLIED 
 *  WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF 
 *  MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
 *  IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT, 
 *  INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
 *  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, 
 *  DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY 
 *  OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
 *  NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, 
 *  EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *  
 ************************************************************************/



/************************************************************************
 * style display defaults
 ************************************************************************/
 sqlwb_DISPLAY_TABLE_STYLE     = "border: 1px solid #999999;";	      // style attribute for display (outer-most) table
 sqlwb_DISPLAY_TABLE_PADDING   = "4"                                  // padding attribute for display table
 sqlwb_DISPLAY_TABLE_SPACING   = "0"                                  // spacing attribute for display table
 sqlwb_DISPLAY_TABLE_BORDER    = "0"                                  // border attribute for display table
 sqlwb_FORM_COLOR              = "#CCCCCC";                           // condition entry form background color
 sqlwb_BUTTON_STYLE            = "font-size: 8pt;";                   // style attribute for the condition buttons
 sqlwb_ADDBUTTON_TEXT          = "Add";                               // text for the condition Add button
 sqlwb_UPDATEBUTTON_TEXT       = "Update";                            // text for the condition Update button
 sqlwb_CANCELBUTTON_TEXT       = "Cancel";                            // text for the condition Cancel button 

 sqlwb_EDITBUTTONS_STYLE       = "font-size: 10pt; cursor:pointer;"   // style for the delete & edit buttons
 sqlwb_EDITBUTTONS_COLOR       = "#CCCCCC";                           // normal background color for delete & edit buttons
 sqlwb_EDITBUTTONS_HILITECOLOR = "#999999";                           // hilite background color for delete & edit buttons
 sqlwb_EDITBUTTON_TEXT         = "&nbsp;>>&nbsp;";                    // text for the condition edit button
 sqlwb_DELETEBUTTON_TEXT       = "&nbsp;X&nbsp;";                     // text for the condition delete button
 
 sqlwb_CONDITIONDISPLAY_STYLE  = "font-size: 10pt; padding: 2px;"     // style for the display of a single condition
 sqlwb_CONDITIONCELL_STYLE     = "border: 1px solid #CCCCCC; padding:2px;" // style for the cell of a single condition
 sqlwb_NOCONDITIONS_TEXT       = "No conditions specified."           // text to display when no conditions have been added
 sqlwb_NOCONDITIONS_STYLE      = "font-size: 10pt;"                   // style to display when no conditions have been added


/************************************************************************
 * Utility Functions
 ************************************************************************/
 
 // SQLWB_GetElement - return the element with the given id
 function SQLWB_GetElement(elemid)
 {
   return document.getElementById(elemid);
 }

 // SQLWB_GetSQLWBObject - return a SQLWB_SqlWhereBuilder object with the given div id;
 //                      - use a helper array to keep track
 sqlwb_BuilderObjects = new Array();
 function SQLWB_GetSQLWBObject(id)
 {
   for (var i=0; i<sqlwb_BuilderObjects.length; i++)
   {
     if (sqlwb_BuilderObjects[i].divId == id) return sqlwb_BuilderObjects[i];
   }
   return null;
 }


 // SQLWB_SetDropdownValue -- set the selectedIndex of the given dropdown object to match the given value
 function SQLWB_SetDropdownValue(dd, val)
 {
   for (var i=0; i<dd.options.length; i++)
   {
     if (dd.options[i].value == val)
     {
       dd.selectedIndex = i;
       return i;
     }
   }
   dd.selectedIndex = 0;
   return 0;
 }

 // SQLWB_StringInArray -- return the index number if the given string is found in the array, otherwise -1
 function SQLWB_StringInArray(s, a)
 {
   var sComp;
   for (var i=0; i<a.length; i++)
   {
     sComp = a[i];
     if (s.toLowerCase() == sComp.toLowerCase() ) return i;
   }
   return -1;
 }
 
 
 // SQLWB_GetRadioByNameAndValue -- return the radio object (if exists) given the name of its group and its value within the group
 function SQLWB_GetRadioByNameAndValue(name, value)
 {
   var e = document.getElementsByName(name);
   for (var i=0; i<e.length; i++)
   {
     if ( (e[i].type == "radio") && (e[i].value == value) ) return e[i];
   }
   
   return null;
 }
          
 // given a radio element, return its label (defined through a <label> tag)
 function SQLWB_GetLabelForRadio(elem)
 {
   var e = document.getElementsByTagName("label");
   for (var i=0; i<e.length; i++)
   {
     if (e[i].htmlFor == elem.id)
     {
        for (var j=0; j<e[i].childNodes.length; j++)
        {
            if (e[i].childNodes[j].nodeType == 3) //text type
            {
                return e[i].childNodes[j].nodeValue;
            }
        }
     }
   }
   
   // still here?  no <label> for this radio then
   return null;
 }                         

/************************************************************************
 * SqlWhereBuilder object - main control
 ************************************************************************/
 // PopulateValueEntryDiv method - setup the valueEntryDiv controls to reflect the given condition's values
 function SQLWB_SqlWhereBuilder_PopulateValueEntryDiv(cond)
 {
     for (var i=0; i<cond.values.length; i++)
     {
       var obj = SQLWB_GetElement(cond.values[i].name);
       
       if ((obj == null) || (obj.type == "radio"))
       {
         // if the object isn't found through its ID, it may be a radio
         // identified by name instead
         // IE seems to handle this differently than other browsers, returning
         // the first of a radio group in the event we have a radio type;
         // take this into consideration as well.
         obj = SQLWB_GetRadioByNameAndValue(cond.values[i].name, cond.values[i].value);
       }


       if (obj != null) 
       {
         switch(obj.nodeName.toLowerCase())
         {
           case "select":
             SQLWB_SetDropdownValue(obj, cond.values[i].value);
             break;
         
           case "input":
             // get the type attribute
             var attType = obj.getAttribute("type");

             // test the type?
             switch (attType.toLowerCase())
             {
               case "text":
                 obj.value = cond.values[i].value;
                 break;


               case "radio":
                 obj.checked = true;
                 break;

             }

             break;
         } 
         
       }
     }
 }

 // GetCurrentValues_Recursive - recursive function supporting GetCurrentValues()
 function SQLWB_GetCurrentValues_Recursive(values, nodes)
 {
   for (var i=0; i<nodes.length; i++)
   {
     if (nodes[i].nodeType == 1)   // html element?
     {
       // get attributes
       var attType = nodes[i].getAttribute("type");
       var attId   = nodes[i].getAttribute("id");
       var attName = nodes[i].getAttribute("name");

       switch(nodes[i].nodeName.toLowerCase())
       {
         case "select":
           values.push(new SQLWB_Value(attId, nodes[i].options[nodes[i].selectedIndex].value, nodes[i].options[nodes[i].selectedIndex].text));
           break;
         
         case "input":
           // test the type?
           switch (attType.toLowerCase())
           {
             case "text":
             //hack for asb autosugest box
             if(attId == "ctl00_ContentPlaceHolder1_Events_asbEvents")
             {
                var asbValueNode = document.getElementById("ctl00_ContentPlaceHolder1_Events_asbEvents_SelectedValue");
                values.push(new SQLWB_Value(attId, asbValueNode.value, nodes[i].value));
             }
             else
             {
               values.push(new SQLWB_Value(attId, nodes[i].value));
             }
               break;

           
             case "radio":
               if (nodes[i].checked)
               {
                 var lbl = SQLWB_GetLabelForRadio(nodes[i]);
                 if (lbl == null)
                   values.push(new SQLWB_Value(attName, nodes[i].value));
                 else
                   values.push(new SQLWB_Value(attName, nodes[i].value, lbl));
               }
               
               break;
           }

           break;
       } 
     }
     
     // any child nodes?
     if (nodes[i].hasChildNodes)
        SQLWB_GetCurrentValues_Recursive(values, nodes[i].childNodes);
   }

 }

 // GetCurrentValues method - return a value array from fields on the form as an array
 function SQLWB_SqlWhereBuilder_GetCurrentValues()
 {
   var values = new Array();
   var nodes=this.divValueEntry.childNodes;
   SQLWB_GetCurrentValues_Recursive(values, nodes);
   return values;
 }


 // AssociateValueEntryDiv method - associate the specified <div> as a value entry item available to this builder object
 function SQLWB_SqlWhereBuilder_AssociateValueEntryDiv(divId)
 { 
   if ( SQLWB_StringInArray(divId, this.valueEntryDivList) == -1 ) 
   {
     var div = SQLWB_GetElement(divId);
     div.style.display = "none";
     this.valueEntryDivList.push(divId);
   }
 }

 
 // DefineOperatorList method - create an operators list which will then be associated with a field
 function SQLWB_SqlWhereBuilder_DefineOperatorList(id, arr)
 {
   // for each operator, make sure the valueEntryArray is associated with the sqlwb control
   for (var i=0; i<arr.length; i++)
   {
     this.AssociateValueEntryDiv(arr[i].valueEntryDiv);
   }
   this.OperatorLists.push(new SQLWB_OperatorList(id, arr));
 }

 // DefineField method - define a field to be included in the dropdown list
 function SQLWB_SqlWhereBuilder_DefineField(id, text, opListId)
 {
   this.fieldList.push(new SQLWB_Field(id, text, opListId));
 }

 // InitializeForm method - initialize the fields dropdown list and setup the form
 function SQLWB_SqlWhereBuilder_InitializeForm()
 {
   this.ddFields.options.length = 0;
   for (var i = 0; i<this.fieldList.length; i++)
   {
     this.ddFields.options[i] = new Option(this.fieldList[i].text, this.fieldList[i].id);
   }

   if (this.editIndex == -1)
   {
     this.ddFields.selectedIndex = 0;
     this.ListOperatorsForField();
     if (this.conditions.length > 0)
       this.divAndOr.style.display = "inline";
     else
       this.divAndOr.style.display = "none";
   }
   else
   {
     var cond = this.conditions[this.editIndex];

     // display the andOr dropdown?
     if (this.editIndex != 0 )
     {
       this.divAndOr.style.display = "inline";
       SQLWB_SetDropdownValue(this.ddAndOr, cond.andOr);
     }
     else
       this.divAndOr.style.display = "none";     

     // set the current field
     SQLWB_SetDropdownValue(this.ddFields, cond.field.id);
     this.ListOperatorsForField();

     // set the current operator
     SQLWB_SetDropdownValue(this.ddOperators, cond.operator.id);
     this.DisplayValueEntryForOperator()

     // set the current values in the valueEntry div  
     this.PopulateValueEntryDiv(cond);
   
     
   }

 }


 // DispayValueEntryForOperator method - when the operator changes, change the valueEntry div
 function SQLWB_SqlWhereBuilder_DisplayValueEntryForOperator()
 {
   var op = this.GetCurrentOperator();

   if (this.lastValueEntryId != op.valueEntryDiv)
   {
     this.lastValueEntryId = op.valueEntryDiv;
     var div = SQLWB_GetElement(op.valueEntryDiv);
     this.divValueEntry.innerHTML = div.innerHTML;
   }
 }


 // ListOperatorsForField method - initialize the operators dropdown list depending on the selected field
 function SQLWB_SqlWhereBuilder_ListOperatorsForField()
 {
   var opList = this.GetCurrentOperatorList();
   if (this.lastOpListId != opList.id) 
   {
     // change the opList; 
     this.lastOpListId = opList.id;

     this.ddOperators.options.length = 0;   
     for (var i=0; i<opList.operators.length; i++)
     {
       this.ddOperators.options[i] = new Option(opList.operators[i].text, opList.operators[i].id);
     }

     this.ddOperators.selectedIndex = 0;
     this.lastValueEntryId = "";
     this.DisplayValueEntryForOperator();
   }

 }

 // GetFieldById
 function SQLWB_SqlWhereBuilder_GetFieldById(fieldId)
 {
    for (var i=0; i<this.fieldList.length; i++)
    {
      if (this.fieldList[i].id == fieldId) return this.fieldList[i];
    }
    return null;
 }
 
 

 // GetCurrentField method - return the currently selected field object
 function SQLWB_SqlWhereBuilder_GetCurrentField()
 {
   var fieldIndex = this.ddFields.selectedIndex;
   return this.fieldList[fieldIndex];    
 }

 
 // GetOperatorListById - return an operator list given its id
 function SQLWB_SqlWhereBuilder_GetOperatorListById(opListId)
 {
   for (var i=0; i<this.OperatorLists.length; i++)
   {
     if (this.OperatorLists[i].id == opListId)
     {
       return this.OperatorLists[i];
     }
   }
   
   return null;
 }

 // GetCurrentOperatorList method - return the operator list object associated with the selected field
 function SQLWB_SqlWhereBuilder_GetCurrentOperatorList()
 {
   var fieldIndex = this.ddFields.selectedIndex;
   var opListId = this.fieldList[fieldIndex].OperatorListId;
   return this.GetOperatorListById(opListId);
 }
 
 
 // GetOperatorById - given a field Id and operatorId, return the operator object
 function SQLWB_SqlWhereBuilder_GetOperatorById(fieldId, operatorId)
 {
    var field = this.GetFieldById(fieldId);
    var opList = this.GetOperatorListById(field.OperatorListId);
    for (var i=0; i<opList.operators.length; i++)
    {
      if (opList.operators[i].id == operatorId)
      {
        return opList.operators[i];
      }
    }
    return null;
 }
 
 
 // GetCurrentOperator method - return the currently selected operator as an object
 function SQLWB_SqlWhereBuilder_GetCurrentOperator()
 {
   var opIndex = this.ddOperators.selectedIndex;
   var opValue = this.ddOperators[opIndex].value;

   var opList = this.GetCurrentOperatorList();
   for (var i = 0; i<opList.operators.length; i++)
   {
     if (opList.operators[i].id == opValue)
     {
       return opList.operators[i];
     }
   }
   
   return null;
 }


  


 // AddCondition method - add the condition to the conditions list
 function SQLWB_SqlWhereBuilder_AddCondition(cond)
 {
   this.conditions.push(cond);
 }

 // ReplaceConditionAtIndex method - replace the condition at index with the one supplied
 function SQLWB_SqlWhereBuilder_ReplaceConditionAtIndex(index, newCond)
 {
   this.conditions[index] = newCond;
 }

 // GetConditionFromForm method - decipher the form values to construct a condition object
 function SQLWB_SqlWhereBuilder_GetConditionFromForm()
 {
   var field = this.GetCurrentField();
   var operator = this.GetCurrentOperator();
   var values = this.GetCurrentValues();
   var andOr;
   if ((this.editIndex == -1 && this.conditions.length > 0) || (this.editIndex > 0))
     andOr = this.ddAndOr.options[this.ddAndOr.selectedIndex].value;
   else
     andOr = "";
     
   
   var cond = new SQLWB_Condition(field, operator, values, andOr);
   return cond;
}


 // AddConditionFromForm method - add the condition as specified in the form to the conditions list
 function SQLWB_SqlWhereBuilder_AddConditionFromForm()
 {

   cond = this.GetConditionFromForm();
   this.AddCondition(cond);

   // update the conditions display
   this.UpdateConditionsDisplay();

   // make sure the and/or dropdown displays
   this.divAndOr.style.display = "inline";
   
 }

 // UpdateConditionFromForm method - update the current editIndex condition as specified in the form
 function SQLWB_SqlWhereBuilder_UpdateConditionFromForm()
 {

   cond = this.GetConditionFromForm();
   this.ReplaceConditionAtIndex(this.editIndex, cond);

   // update the conditions display
   this.UpdateConditionsDisplay();
   
 }



 // RemoveCondition method - remove the condition with the given index number from the list
 function SQLWB_SqlWhereBuilder_RemoveCondition(index)
 {
  for (var i=index; i<this.conditions.length-1; i++)
  {
    this.conditions[i] = this.conditions[i+1];            
  }
  this.conditions.length = this.conditions.length-1;

  if (this.conditions.length > 0)
    this.conditions[0].andOr = "";
  else
    this.divAndOr.style.display = "none";

 

  this.UpdateConditionsDisplay();   
 }

 

 // EditCondition method - set the editIndex to the given index, setting up the form for edit mode
 function SQLWB_SqlWhereBuilder_EditCondition(index)
 {
  this.editIndex = index;
  this.UpdateConditionsDisplay();   
 }

 // ResetFormToAddMode method - on a cancel or update of a condition, reset the form so it is in add mode
 function SQLWB_SqlWhereBuilder_ResetFormToAddMode()
 {
   this.editIndex = -1;
   this.UpdateConditionsDisplay();
   this.ConstructForm();
   this.InitializeForm();
 }
 

 // EditCancel method - cancel the edit mode, return to add without saving changes
 function SQLWB_SqlWhereBuilder_EditCancel()
 {
  this.ResetFormToAddMode();   
 }

 // EditUpdate method - save changes to the current condition, then reset to add mode
 function SQLWB_SqlWhereBuilder_EditUpdate()
 {
  this.UpdateConditionFromForm();
  this.ResetFormToAddMode();   
 }


 // UpdateConditionsDisplay method - display the conditions in the conditions list
 function SQLWB_SqlWhereBuilder_UpdateConditionsDisplay()
 {
    var sButtons;
    var sData;
    var sAndOr;
    var sTable = "<table width='100%' style='border-collapse: collapse;' cellpadding='0' cellspacing='0' >"

    var sEditButtonsClass = (this.editButtonsClass == "" ? "" : " class=\"" + this.editButtonsClass + "\"");
    var sEditButtonsStyle = (this.editButtonsStyle == "" ? "" : " style=\"" + this.editButtonsStyle + "\"");
    var sConditionDisplayClass = (this.conditionDisplayClass == "" ? "" : " class=\"" + this.conditionDisplayClass + "\"");
    var sConditionDisplayStyle = (this.conditionDisplayStyle == "" ? "" : " style=\"" + this.conditionDisplayStyle + "\"");
    var sConditionCellClass = (this.conditionCellClass == "" ? "" : " class=\"" + this.conditionCellClass + "\"");
    var sConditionCellStyle = (this.conditionCellStyle == "" ? "" : " style=\"" + this.conditionCellStyle + "\"");
    var sNoConditionsClass = (this.noConditionsClass == "" ? "" : " class=\"" + this.noConditionsClass + "\"");
    var sNoConditionsStyle = (this.noConditionsStyle == "" ? "" : " style=\"" + this.noConditionsStyle + "\"");
    

    for (var i=0; i<this.conditions.length; i++)
    {                            
      sAndOr = this.conditions[i].andOr;
      sData = "<td width=\"100%\"" + sConditionDisplayClass + sConditionDisplayStyle + ">" + sAndOr + " " + this.conditions[i].FriendlyDisplay() + "</td>";

      if (this.editIndex == -1)
      {
        sButtons = "<td " + sEditButtonsClass + sEditButtonsStyle + " bgcolor=\"" + this.editButtonsColor + "\" align='center' onclick='SQLWB_RemoveButton_Click(\"" + this.divId + "\"," + i + ");' onmouseover='this.style.backgroundColor=\"" + this.editButtonsHiliteColor + "\";' onmouseout='this.style.backgroundColor=\"" + this.editButtonsColor + "\";'>" + this.deleteButtonText + "</td>"
                 + "<td " + sEditButtonsClass + sEditButtonsStyle + " bgcolor=\"" + this.editButtonsColor + "\" align='center' onclick='SQLWB_EditButton_Click(\"" + this.divId + "\"," + i + ");' onmouseover='this.style.backgroundColor=\"" + this.editButtonsHiliteColor + "\";' onmouseout='this.style.backgroundColor=\"" + this.editButtonsColor + "\";'>" + this.editButtonText + "</td>"

        sRow = "<table cellpadding='2' cellspacing='0'>"
        + " <tr>"
        + sButtons
        + "   <td>&nbsp</td>"
        + sData
        + "   <td>&nbsp</td>"
        + " </tr>"
        + "</table>"
      }
      else
      {
        if (i == this.editIndex)
        {
          sRow = "<div id=\"" + this.divId + "_editRecord\"></div>";
        }
        else
        {
          sRow = "<table cellpadding='2' cellspacing='0'>"
               + " <tr>"
               + "   <td>&nbsp</td>"
               + sData
               + "   <td>&nbsp</td>"
               + " </tr>"
               + "</table>"
        }
    
      }

      sTable = sTable + "<tr><td" + sConditionCellClass + sConditionCellStyle + ">" + sRow + "</td></tr>";
    }
        
    var div = this.divConditions;
    if (this.conditions.length == 0)
      div.innerHTML = "<table><tr><td width=\"100%\"" + sNoConditionsClass + sNoConditionsStyle + ">" + this.noConditionsText + "</td></tr></table>";
    else
      div.innerHTML = sTable + "</table>";


    if (this.editIndex != -1)
    {
      // clear the add form
      this.divForm.innerHTML = ""

      // recreate the form as an edit form in the editRecord div
      this.ConstructForm();
      this.InitializeForm();

    }
    
    // for communicating information back to ASP.NET --
    // output the current set of conditions and the translated where clause
    // to hidden form elements
    if (this.hiddenConditionsXml != null)
    {
      this.hiddenConditionsXml.value = escape(this.SerializeConditions());
    }
    //if (this.hiddenTranslatedWhereClause != null)
    //  this.hiddenTranslatedWhereClause.value = escape(this.GetWhereClause());
 }


 // ConstructForm method - construct the form used for data entry in the given div; if editIndex is -1 treat as an Add form;
 //                        if index is >=0, treat as an edit form for the given indexed condition
 function SQLWB_SqlWhereBuilder_ConstructForm()
 {
    var divId = this.divId;
    var div = (this.editIndex == -1 ? this.divForm : SQLWB_GetElement(this.divId + "_editRecord"));

    var sFormTable = "<table style=\"border-collaspse: collapse; border: 1px solid black;\""
                   + " width=\"100%\" cellspacing=\"0\" cellpadding=\"4\">"
                   + " <tr valign=\"top\"><td width=\"100%\" bgcolor=\"" + this.formColor + "\">"
                   + " <div id=\"" + divId + "_andOrDiv\" style=\"display:none;\"><select id=\"" + divId + "_andOr\"><option value=\"and\">and</option><option value=\"or\">or</option></select>&nbsp;</div>"
                   + " <select id=\"" + divId + "_fields\"    onchange='SQLWB_Field_Change(\"" + divId + "\");' ></select>"
                   + " <select id=\"" + divId + "_operators\" onchange='SQLWB_Operator_Change(\"" + divId + "\");'></select>"
                   + " <div id=\"" + divId + "_valueEntry\" style=\"display:inline;\"></div>"
                   + " <div id=\"" + divId + "_entryButtons\" style=\"display:inline;\"></div>"
                   + "</td></tr></table>";

    div.innerHTML = sFormTable;

    // set references to the dropdowns & valuEntry div
    this.ddFields        = SQLWB_GetElement(divId + "_fields");
    this.ddOperators     = SQLWB_GetElement(divId + "_operators");
    this.divValueEntry   = SQLWB_GetElement(divId + "_valueEntry");
    this.divEntryButtons = SQLWB_GetElement(divId + "_entryButtons");
    this.divAndOr        = SQLWB_GetElement(divId + "_andOrDiv");
    this.ddAndOr         = SQLWB_GetElement(divId + "_andOr");

    this.lastOpListId = "";
    this.lastValueEntryId = "";

    // setup the Add/Update/Cancel button styles
    var sButtons;
    var sButtonClass = (this.buttonsClass == "" ? "" : " class=\"" + this.buttonsClass + "\"");
    var sButtonStyle = (this.buttonsStyle == "" ? "" : " style=\"" + this.buttonsStyle + "\"");

    if (this.editIndex == -1)
    {
       sButtons = "<input type=\"button\" onclick='SQLWB_AddButton_Click(\"" + divId + "\");'" 
                + sButtonClass + sButtonStyle + " value=\"" + this.addButtonText + "\">";
    }
    else
    {
       sButtons = "<input type=\"button\" onclick='SQLWB_UpdateButton_Click(\"" + divId + "\");'" 
                     + sButtonClass + sButtonStyle + " value=\"" + this.updateButtonText + "\">"
                     + "<input type=\"button\" onclick='SQLWB_CancelButton_Click(\"" + divId + "\");'" 
                     + sButtonClass + sButtonStyle + " value=\"" + this.cancelButtonText + "\">";
    }

    this.divEntryButtons.innerHTML = sButtons;
 }


 // SerializeConditions method - serialize the conditions as an Xml chunk
 function SQLWB_SqlWhereBuilder_SerializeConditions()
 {
    var sXml = "<conditions>";
    
    for (var i=0; i<this.conditions.length; i++)
    {
      sXml = sXml + this.conditions[i].Serialize();
    }
    
    sXml = sXml + "</conditions>";
    
    return sXml;
 }
 

 //////////////////////////////////////////////////////////////////////////////////////////////////
 // GetWhereClause method - the whole reason we're doing this...
 //                       - return a complete SQL Where clause given the current set of conditions
 //                       - without the word "WHERE" (gives more flexibility for its use)
 //////////////////////////////////////////////////////////////////////////////////////////////////
 
 function SQLWB_SqlWhereBuilder_GetWhereClause()
 {
   var sReturn = "";
   for (var i=0; i<this.conditions.length; i++)
   {
     sReturn = sReturn + this.conditions[i].TranslateToSQL();
   }
   return sReturn;
 } 


 // Initialize method -- set up the control using whatever has been established as formatting parameters
 function SQLWB_SqlWhereBuilder_Initialize()
 {
 
   // setup a display table in the div
   var sClass = (this.mainClass == "" ? "" : " class=\"" + this.mainClass + "\"");
   var sStyle = (this.mainStyle == "" ? "" : " style=\"" + this.mainStyle + "\"");
   var sPadding = (this.padding == "" ? "" : " cellpadding=\"" + this.padding + "\"");
   var sSpacing = (this.spacing == "" ? "" : " cellspacing=\"" + this.spacing + "\"");
   var sBorder  = (this.border  == "" ? "" : " border=\"" + this.border + "\"");

   var sTable = "<table" + sClass + sStyle + sPadding + sSpacing + sBorder + ">"
              + "  <tr valign='top'>"
              + "    <td>"
              + "      <div id=\"" + this.divId + "_conditions\">"
              + "      </div>"
              + "    </td>"
              + "  </tr>"
              + "  <tr valign='top'>"
              + "    <td>"
              + "      <div id=\"" + this.divId + "_form\">"
              + "      </div>"
              + "    </td>"
              + "  </tr>"
              + "</table>";
              //+ "<input type=\"hidden\" id=\"" + this.divId + "_conditionsXml\">"
              //+ "<input type=\"hidden\" id=\"" + this.divId + "_translatedWhereClause\">";

    this.divObj.innerHTML = sTable;

    // get references to the conditions & form divs
    this.divConditions = SQLWB_GetElement(this.divId + "_conditions");
    this.divForm       = SQLWB_GetElement(this.divId + "_form");
    
    // these would be added by ASP.NET 
    this.hiddenConditionsXml = SQLWB_GetElement(this.divId + "_conditionsXml");
    //this.hiddenTranslatedWhereClause = SQLWB_GetElement(this.divId + "_translatedWhereClause");

    // construct the form (add mode)
    this.ConstructForm();

    // update the conditions
    this.UpdateConditionsDisplay();

 }


 // constructor; takes a required <div> id as a parameter

 function SQLWB_SqlWhereBuilder(divId)
 {
   // initial object creation
   this.divId             = divId;
   this.divObj            = SQLWB_GetElement(divId);
   this.fieldList         = new Array();  // list of objects for populating the field dropdown
   this.OperatorLists    = new Array();  // each field has an operator list for the operator dropdown; contains a list of the available operator lists
   this.valueEntryDivList = new Array();  // each operator associates to a value entry <div> tag; contains a list of valueEntry <divs> available for operators
   this.conditions        = new Array();  // list of added conditions
   this.editIndex         = -1;           // defaults to Add mode


   // setup initial style defaults   
   this.mainClass               = "";
   this.mainStyle               = sqlwb_DISPLAY_TABLE_STYLE;
   this.padding                 = sqlwb_DISPLAY_TABLE_PADDING;
   this.spacing                 = sqlwb_DISPLAY_TABLE_SPACING;
   this.border                  = sqlwb_DISPLAY_TABLE_BORDER;
   this.formColor               = sqlwb_FORM_COLOR;
   this.buttonClass             = "";
   this.buttonStyle             = sqlwb_BUTTON_STYLE;
   this.addButtonText           = sqlwb_ADDBUTTON_TEXT;
   this.updateButtonText        = sqlwb_UPDATEBUTTON_TEXT;
   this.cancelButtonText        = sqlwb_CANCELBUTTON_TEXT;
   this.editButtonsClass        = "";
   this.editButtonsStyle        = sqlwb_EDITBUTTONS_STYLE;
   this.editButtonsColor        = sqlwb_EDITBUTTONS_COLOR;
   this.editButtonsHiliteColor  = sqlwb_EDITBUTTONS_HILITECOLOR;
   this.editButtonText          = sqlwb_EDITBUTTON_TEXT;
   this.deleteButtonText        = sqlwb_DELETEBUTTON_TEXT;
   this.conditionDisplayClass   = "";
   this.conditionDisplayStyle   = sqlwb_CONDITIONDISPLAY_STYLE;
   this.conditionCellClass      = "";
   this.conditionCellStyle      = sqlwb_CONDITIONCELL_STYLE;
   this.noConditionsClass       = "";
   this.noConditionsStyle       = sqlwb_NOCONDITIONS_STYLE;
   this.noConditionsText        = sqlwb_NOCONDITIONS_TEXT;

    // add this object to our reference array so we can get it back later
    sqlwb_BuilderObjects.push(this);
 }

 


 // wire methods as prototypes

 SQLWB_SqlWhereBuilder.prototype.Initialize                   = SQLWB_SqlWhereBuilder_Initialize;
 SQLWB_SqlWhereBuilder.prototype.PopulateValueEntryDiv        = SQLWB_SqlWhereBuilder_PopulateValueEntryDiv;
 SQLWB_SqlWhereBuilder.prototype.AssociateValueEntryDiv       = SQLWB_SqlWhereBuilder_AssociateValueEntryDiv;
 SQLWB_SqlWhereBuilder.prototype.DefineOperatorList          = SQLWB_SqlWhereBuilder_DefineOperatorList;
 SQLWB_SqlWhereBuilder.prototype.DefineField                  = SQLWB_SqlWhereBuilder_DefineField;
 SQLWB_SqlWhereBuilder.prototype.ConstructForm                = SQLWB_SqlWhereBuilder_ConstructForm;
 SQLWB_SqlWhereBuilder.prototype.InitializeForm               = SQLWB_SqlWhereBuilder_InitializeForm;
 SQLWB_SqlWhereBuilder.prototype.ListOperatorsForField        = SQLWB_SqlWhereBuilder_ListOperatorsForField;
 SQLWB_SqlWhereBuilder.prototype.DisplayValueEntryForOperator = SQLWB_SqlWhereBuilder_DisplayValueEntryForOperator;
 SQLWB_SqlWhereBuilder.prototype.GetCurrentOperatorList      = SQLWB_SqlWhereBuilder_GetCurrentOperatorList;
 SQLWB_SqlWhereBuilder.prototype.GetCurrentOperator           = SQLWB_SqlWhereBuilder_GetCurrentOperator;
 SQLWB_SqlWhereBuilder.prototype.GetCurrentField              = SQLWB_SqlWhereBuilder_GetCurrentField;
 SQLWB_SqlWhereBuilder.prototype.GetCurrentValues             = SQLWB_SqlWhereBuilder_GetCurrentValues;
 SQLWB_SqlWhereBuilder.prototype.AddCondition                 = SQLWB_SqlWhereBuilder_AddCondition;
 SQLWB_SqlWhereBuilder.prototype.GetConditionFromForm         = SQLWB_SqlWhereBuilder_GetConditionFromForm;
 SQLWB_SqlWhereBuilder.prototype.AddConditionFromForm         = SQLWB_SqlWhereBuilder_AddConditionFromForm;
 SQLWB_SqlWhereBuilder.prototype.UpdateConditionFromForm      = SQLWB_SqlWhereBuilder_UpdateConditionFromForm;
 SQLWB_SqlWhereBuilder.prototype.UpdateConditionsDisplay      = SQLWB_SqlWhereBuilder_UpdateConditionsDisplay;
 SQLWB_SqlWhereBuilder.prototype.RemoveCondition              = SQLWB_SqlWhereBuilder_RemoveCondition;
 SQLWB_SqlWhereBuilder.prototype.EditCondition                = SQLWB_SqlWhereBuilder_EditCondition;
 SQLWB_SqlWhereBuilder.prototype.ResetFormToAddMode           = SQLWB_SqlWhereBuilder_ResetFormToAddMode;
 SQLWB_SqlWhereBuilder.prototype.EditCancel                   = SQLWB_SqlWhereBuilder_EditCancel;
 SQLWB_SqlWhereBuilder.prototype.EditUpdate                   = SQLWB_SqlWhereBuilder_EditUpdate;
 SQLWB_SqlWhereBuilder.prototype.ReplaceConditionAtIndex      = SQLWB_SqlWhereBuilder_ReplaceConditionAtIndex;
 SQLWB_SqlWhereBuilder.prototype.GetWhereClause               = SQLWB_SqlWhereBuilder_GetWhereClause;
 SQLWB_SqlWhereBuilder.prototype.SerializeConditions          = SQLWB_SqlWhereBuilder_SerializeConditions;
 SQLWB_SqlWhereBuilder.prototype.GetFieldById                 = SQLWB_SqlWhereBuilder_GetFieldById;
 SQLWB_SqlWhereBuilder.prototype.GetOperatorListById         = SQLWB_SqlWhereBuilder_GetOperatorListById;
 SQLWB_SqlWhereBuilder.prototype.GetOperatorById              = SQLWB_SqlWhereBuilder_GetOperatorById;

/************************************************************************
 * Operator object - defines a single comparison operator
 ************************************************************************/
 // methods


 // Constructor
 function SQLWB_Operator(id, text, valueEntryDiv, sqlTemplate)
 {
   this.id = id;
   this.text = text;
   this.valueEntryDiv = valueEntryDiv;
   this.sqlTemplate = sqlTemplate;
 }

 // wire methods as prototypes




/************************************************************************
 * OperatorList object - defines a list of comparison operators to be 
                          associated with a field
 ************************************************************************/
 // methods


 // Constructor
  function SQLWB_OperatorList(id, arr)
  {
    this.id = id;
    this.operators = arr;
  }

 // wire methods as prototypes




/************************************************************************
 * Field object - defines a field to be included in the fields dropdownlist
 ************************************************************************/
 // methods


 // Constructor
  function SQLWB_Field(id, text, OperatorListId)
  {
    this.id = id;
    this.text = text;
    this.OperatorListId = OperatorListId;
  }


 // wire methods as prototypes



/************************************************************************
 * Condition object - defines a single condition added to the conditions list
 ************************************************************************/
 // methods
 // FriendlyDisplay method - return a string for a friendly display of this condition object
 function SQLWB_Condition_FriendlyDisplay()
 {
   var vals = new Array()
   for (var i=0; i<this.values.length; i++) { vals.push(this.values[i].friendlyValue) }
   return this.field.text + " " + this.operator.text + " " + vals.join(", ");
 }

 // TranslateToSQL method - return a SQL equivalent of the given condition
 function SQLWB_Condition_TranslateToSQL()
 {
   var pattern;
   var sPattern;
   var sReturn = this.operator.sqlTemplate;
   var sValue;

   // replace the field indicator with the fieldId
   pattern = /#FIELD#/ig;
   sReturn = sReturn.replace(pattern, this.field.id);

   for (var i=0; i<this.values.length; i++)
   {
     // replace the value name indicator with the value
     pattern = new RegExp("#" + this.values[i].name + "#", "ig") 
     // within the value, replace any single quote with two single quotes
     sValue = this.values[i].value.replace("'", "''");
     sReturn = sReturn.replace(pattern, sValue) 
   }

   if (this.andOr != "")
     return " " + this.andOr + " " + sReturn;
   else
     return sReturn;

 }

 // Serialize method - serialize this condition to Xml
 function SQLWB_Condition_Serialize()
 {
   var sXml = "<condition"
            + " field=\"" + this.field.id + "\""
            + " operator=\"" + this.operator.id + "\""
            + " andOr=\"" + this.andOr + "\""
            + ">"
            + "<values>";
            
   for (var i=0; i<this.values.length; i++)
   {
     sXml = sXml + this.values[i].Serialize();
   }
  
   sXml = sXml + "</values></condition>";
   return sXml;
 }


 // Constructor
 function SQLWB_Condition(field, operator, values, andOr)
 {
   this.field = field;
   this.operator = operator;
   this.values = values;
   this.andOr  = andOr;
 }

 // wire methods as prototypes
 SQLWB_Condition.prototype.FriendlyDisplay = SQLWB_Condition_FriendlyDisplay;
 SQLWB_Condition.prototype.TranslateToSQL  = SQLWB_Condition_TranslateToSQL;
 SQLWB_Condition.prototype.Serialize       = SQLWB_Condition_Serialize;

/************************************************************************
 * Value object - defines a name/value pair 
 ************************************************************************/
 // methods
 function SQLWB_Value_Serialize()
 {
   var sXml = "<value name=\"" + this.name + "\""
                + " value=\"" + this.value.replace(/"/g, '&quot;') + "\""
                + " friendlyValue=\"" + this.friendlyValue.replace(/"/g, '&quot;') + "\" />";
   
   return sXml;
 }

 // Constructor
 function SQLWB_Value(name, value, friendlyValue)
 {
   this.name = name;
   this.value = value;
   this.friendlyValue = (friendlyValue == undefined ? value : friendlyValue);     
 }

 // wire methods as prototypes
 SQLWB_Value.prototype.Serialize = SQLWB_Value_Serialize;


/************************************************************************
 * Events triggered through form actions
 ************************************************************************/

 // SQLWB_Field_Change - occurs when an item has been selected from the fields dropdown in the form
 function SQLWB_Field_Change(divId)
 {
   var sqlwb = SQLWB_GetSQLWBObject(divId);
   sqlwb.ListOperatorsForField();
 }


 // SQLWB_Operator_Change - occurs when an item has been selected from the operators dropdown in the form
 function SQLWB_Operator_Change(divId)
 {
   var sqlwb = SQLWB_GetSQLWBObject(divId);
   sqlwb.DisplayValueEntryForOperator();
 }


 // SQLWB_AddButton_Click - occurs when editing a condition, the cancel button is clicked
 function SQLWB_AddButton_Click(divId)
 {
   var sqlwb = SQLWB_GetSQLWBObject(divId);
   sqlwb.AddConditionFromForm();
 }

 // SQLWB_UpdateButton_Click - occurs when editing a condition, the cancel button is clicked
 function SQLWB_UpdateButton_Click(divId)
 {
   var sqlwb = SQLWB_GetSQLWBObject(divId);
   sqlwb.EditUpdate();
 }

 // SQLWB_CancelButton_Click - occurs when editing a condition, the cancel button is clicked
 function SQLWB_CancelButton_Click(divId)
 {
   var sqlwb = SQLWB_GetSQLWBObject(divId);
   sqlwb.EditCancel();
 }

 // SQLWB_EditButton_Click - occurs when viewing a condition, the edit button is clicked
 function SQLWB_EditButton_Click(divId, index)
 {
   var sqlwb = SQLWB_GetSQLWBObject(divId);
   sqlwb.EditCondition(index);
 }

 // SQLWB_RemoveButton_Click - occurs when viewing a condition, the remove button is clicked
 function SQLWB_RemoveButton_Click(divId, index)
 {
   var sqlwb = SQLWB_GetSQLWBObject(divId);
   sqlwb.RemoveCondition(index);
 }

