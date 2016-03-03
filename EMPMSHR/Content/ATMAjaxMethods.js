var GlobalPageClose = "1";


    function CallByAjaxWithParameter(ParameterName, ParameterValue, pageName, callType, methodName, successCallback) {
 //   Showpopup("Please Wait..");
        var loc = pageName;
        loc = (loc.substr(loc.length - 1, 1) == "/") ? loc + pageName : loc;
        $.ajax({
            type: callType,
            url: loc + "/" + methodName,
            data: '{' + ParameterName + ': ' + JSON.stringify(ParameterValue) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d == "TimeOut")
                {
  //                  hidepopup();
                    alert("Your Session is Expired, Please Refresh this Page!");
                    window.location.assign("http://localhost:2473/");
                }
                else
                {
                   // alert(successCallback);

                    successCallback(response)
  //                  hidepopup();
                }
            },
            failure: function(response) {
  //              hidepopup();
                alert(response.d);
                
            },
            error: function(response) {
  //              hidepopup();
                alert(response.d + " Somthing Wrong " + loc);
            }
        });
    }

    function CallByAjaxWithParameterForAuthentication(ParameterName, ParameterValue, pageName, callType, methodName, successCallback) {
    
    var loc = pageName;
    loc = (loc.substr(loc.length - 1, 1) == "/") ? loc + pageName : loc;
    $.ajax({
        type: callType,
        url: loc + "/" + methodName,
        data: '{' + ParameterName + ': ' + JSON.stringify(ParameterValue) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.d == "TimeOut") {
                hidepopup();
                alert("Your Session is Expired, Please Refresh this Page!");
                window.location.assign("http://localhost:2473/");
            }
            else {
                //alert(successCallback);

                successCallback(response)
      //          hidepopup();
            }
        },
        failure: function (response) {
        //    hidepopup();
            alert(response.d);

        },
        error: function (response) {
          //  hidepopup();
            alert(response.d + " Somthing Wrong " + loc);
        }
    });
}
    function CallByAjaxWithoutParameter(pageName, callType, methodName, successCallback) {
       var loc = pageName;
       loc = (loc.substr(loc.length - 1, 1) == "/") ? loc + pageName : loc;
     //  alert(loc + "/" + methodName);
       $.ajax({
           type: callType,
           url: loc + "/" + methodName,
           contentType: "application/json; charset=utf-8",
           dataType: "json",
           success: function (response) {
               if (response.d == "TimeOut") {
                   alert("Your Session is Expired, Please Refresh this Page!");
                   window.location.assign("http://localhost:2473/");
               }
               else {
                   //alert(successCallback);
                   successCallback(response);
               }
           },
           failure: function (response) {
               alert(response.d);
           },
           error: function (response) {
               alert(response.d + " Somthing Wrong " + loc);
           }
       });

    }

    function ToggleObject(ObjectID)
    {
        var Obj = document.getElementById(ObjectID);
        $(Obj).toggle("slow");
        if (Obj.style.display == "block") {
            //Obj.style.display = "none";
            
        }
        else {
            //Obj.style.display = "block";
           
            
        }
    }
    function ShowObject(ObjectID) {
        var Obj = document.getElementById(ObjectID);
        $(Obj).css('opacity', 0)
  .slideDown('slow')
  .animate(
    { opacity: 1,
      overflowY: 'scroll !important'
    },
    { queue: false, duration: 'slow' }
  );

    }
    function HideObject(ObjectID) {
        var Obj = document.getElementById(ObjectID);
        $(Obj).css('opacity', 1)
         .slideUp('slow')
            .animate(
            { opacity: 0,
              overflowY: 'scroll !important'
            },
    { queue: false, duration: 'slow' }
  );
        }

    function FillCheckBox(xml,SourceDataTableName, TargetHTMLTableName, CheckBoxValueField, CheckBoxTextField,CheckBoxTextName) {
            var Roles = xml.find(SourceDataTableName);
            var tableRef = document.getElementById(TargetHTMLTableName);
            document.getElementById(TargetHTMLTableName).innerHTML = "";
            $.each(Roles, function() {
                var Role = $(this);
                var tableRow = tableRef.insertRow();
                var tableCell = tableRow.insertCell();

                var checkBoxRef = document.createElement('input');
                var labelRef = document.createElement('label');
                checkBoxRef.type = 'checkbox';
                checkBoxRef.name = CheckBoxTextName;
                labelRef.innerHTML = $(this).find(CheckBoxTextField).text();
                checkBoxRef.value = $(this).find(CheckBoxValueField).text();

                tableCell.appendChild(checkBoxRef);
                tableCell.appendChild(labelRef);

            });
        }
    function chkCBSAuth(UID,_pageName,actionName,successCallback ) {
            var xml = "<Table>";
            xml += "<UserID>" + UID + "</UserID>";
            xml += "<PageName>" + _pageName + "</PageName>";
            xml += "<ActionName>" + actionName + "</ActionName>";
            xml += "</Table>";
            CallByAjaxWithParameterForAuthentication('AuthData', xml, 'chkAuthPage.aspx', _MethodType, "getUserCredentials", successCallback);
    }

    function alertpopup(Header, Msg, footer, NewPageURL) {
        $('#defaultalert').modal('toggle');
        $('#defaultalert').fadeIn(1);
        // $('#basicModal').modal(options);
        $('.modal-header').text('');
        $('.modal-header').append(Header);
        $('.modal-body').text('');
        $('.modal-body').append(Msg);
        if (footer == "blank") {
            $('.modal-footer').html("");
        }
        $('#btnPopCancel').click(function () {
            // alert(GlobalPageClose);
            if (NewPageURL == "0") {
                $('#btnPopCancel').attr("data-dismiss", "modal");
            } else {
                window.location.replace(NewPageURL);
            }
        });
    }


       