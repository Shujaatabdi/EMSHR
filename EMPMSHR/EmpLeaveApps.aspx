<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="EmpLeaveApps.aspx.cs" Inherits="EMPMSHR.EmpLeaveApps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $('#BtnEditSave').hide();
            $('#Btnsaved').show();
            DDLLvType();
            //$(".datep").datepicker();TxtDateFrom
            $("#TxtDateFrom").datepicker();
        });
        var _PageName = "EmpLeaveApps.aspx";
        var _MethodType = "POST";
        var _LvAppID;
        var _Sorting = "1";
        var _SortAs = "Asc";
        var _RecordPP = "10";
        var _PageNo = "1";
        var _RecordCount = "0";
        var _Rowcount = "0";
        var PageCount = "0";
        var _MethodName = DDLLvType();

        //function LoadLeaveApp() {
        //    var pval = '{ "PageNo" :"' + _PageNo + '","RecordPerPage":"' + _RecordPP + '","SortBy":"' + _Sorting + '","SortAs":"' + _SortAs + '","SearchBy":"0","SearchVal":"0" }';
        //    ALERT(pval);
        //    CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "GetLvAppByID", OnSuccessLoadData)
        //}
        //this function use for dropdown of LeaveType name
        function DDLLvType()
        {
            alert(12);
            var pval = '{ "PageNo" :"' + _PageNo + '","RecordPerPage":"' + _RecordPP + '","SortBy":"' + _Sorting + '","SortAs":"' + _SortAs + '","SearchBy":"0","SearchVal":"0" }';
            CallByAjaxWithoutParameter(_PageName, _MethodType, "DDLLvType", OnSuccessGetAllLvTy)
            //ALERT(pval);
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "GetLvAppByID", OnSuccessLoadData)
        }

        function OnSuccessGetAllLvTy(response)
        {
            try {
                alert(response.d);
                var xmlDoc = $.parseXML(response.d);
                var xml = $(xmlDoc);
                var countries = xml.find("Table");

                $("#DDLLvType").empty();
                $("#DDLLvType").append($("<option></option>").val("0").html("Please Select"));
                $.each(countries, function () {
                    var country = $(this);
                    $("#DDLLvType").append($("<option></option>").val(country.find("ID").text()).html(country.find("Name").text()));
                });
                //alert("country");
            }
            catch (ex) {

                alertpopup("", "Function OnSuccessFillDropdown throws exception: " + ex);
            }
        }

        function Edit_Click(LvAppID)
        {
            //alert(ShftID);
            _LvAppID = LvAppID;
            var pval = '{ "PageNo" :"0","RecordPerPage":"12","SortBy":"0","SortAs":"0","SearchBy":"0","SearchVal":"0","Extra" : [{"Pname":"@ID","Pval":"' + LvAppID + '"}] }';
            alert(pval);
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "GetLvAppForEdit", OnSuccessLoadDataForEdit)
            
        }

        function Delete_Click(LvAppID)
        {
            alert(LvAppID);
            var pval = '{ "ID":"' + LvAppID + '"}';
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "Delete", OnSuccessSave);
            DDLLvType();
        }

        function OnSuccessLoadDataForEdit(response)
        {
            $("#Tbl").hide();
            $("#DivAddN").appendTo("#Container");
            $("#DivAddN").show();
            $('#BtnEditSave').show();
            $('#Btnsaved').hide();


            alert(response.d);
            var Nval = response.d.replace('[', '').replace(']', '');
            var ss = JSON.parse(Nval);
            $('#TxtEmpID').val(ss.EmpID);
            $('#DDLLvType').val(ss.LeaveTypeID);
            $('#TxtDateFrom').val(ss.DateFrom);
            $('#TxtDateTo').val(ss.DateTo);
            $('#txtDescription').val(ss.Description);
           
        }

        function OnSuccessLoadData(response) {
            
            var v1 = response.d.split("@@");
            var rc = JSON.parse(v1[1]);
            var myList = JSON.parse(v1[0]);
            $("#DvTbl").empty();
            buildHtmlTable("#DvTbl", myList);

            _Rowcount = rc[0].RecordCount;
            PageCount = Math.ceil(parseInt(_Rowcount) / parseInt(_RecordPP));
            $('#TxtPageNo').val(_PageNo);
            $('#MPageCount').text(PageCount);
            $('#tot').text(_Rowcount);
        }

        function buildHtmlTable(selector, myList) {
            var columns = addAllColumnHeaders(selector, myList);

            for (var i = 0 ; i < myList.length ; i++) {
                var row$ = $('<tr/>');
                for (var colIndex = 0 ; colIndex < columns.length ; colIndex++) {
                    var cellValue = myList[i][columns[colIndex]];
                    if (cellValue == null) { cellValue = ""; }
                    row$.append($('<td/>').html(cellValue));
                }
              //  row$.append($('<td/>').html('<a href="javascript:Edit_Click(' + myList[i][columns[0]] + ');" >Edit</a>'));
                row$.append($('<td/>').html('<a href="javascript:Delete_Click(' + myList[i][columns[0]] + ');" >Delete</a>'));
                $(selector).append(row$);
            }
        }

        function addAllColumnHeaders(Selc, myList) {
            var columnSet = [];
            var headerTr$ = $('<tr/>');

            for (var i = 0 ; i < myList.length ; i++) {
                var rowHash = myList[i];
                for (var key in rowHash) {
                    if ($.inArray(key, columnSet) == -1) {
                        columnSet.push(key);
                        headerTr$.append($('<th/>').html(key));
                    }                    
                }
            }
           // headerTr$.append($('<th/>').html("EDIT"));
            headerTr$.append($('<th/>').html("DELETE"));
            $(Selc).append(headerTr$);

            return columnSet;
        }

        function BtnAddNew_OnClick()
        {
            $('#TxtEmpID').val('');
            $('#DDLLvType').val('');//#DDLHours
            $('#TxtDateFrom').val('');//#DDLHours
            $('#TxtDateTo').val('');
            $('#txtDescription').val('');
            $("#Tbl").hide();
            $("#DivAddN").appendTo("#Container");
            $("#DivAddN").show()
            $('#BtnEditSave').hide();
            $('#Btnsaved').show();
            
        }

        function BtnViewLeaveApp_OnClick()
        {
            $("#DivAddN").hide();            
            $("#Tbl").appendTo("#Container");
            $("#Tbl").show();
            DDLLvType();
        }

        function BtnSave_OnClick()
        {

            var pval = '{ "EmpID" :"' + $('#TxtEmpID').val() + '","LeaveTypeID":"' + $('#DDLLvType option:selected').val() + '","DateFrom":"' + $('#TxtDateFrom').val() + '","DateTo":"' + $('#TxtDateTo').val() + '","Description":"' + $('#txtDescription').val() + '"}';
            alert(pval);
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "LvAppAdd", OnSuccessSave);
            alert(90);
        }

        function OnSuccessSave(response)
        {
            var result = JSON.parse(response.d);
            
            alertpopup("Header", result.Msg, "Footer", "0");
            DDLLvType();
        }

        function BtnEditSave_OnClick()
        {
            
            var pval = '{"ID" :"' + _LvAppID + '","EmpID" :"' + $('#TxtEmpID').val() + '","LeaveTypeID":"' + $('#DDLLvType option:selected').val() + '","DateFrom":"' + $('#TxtDateFrom').val() + '","DateTo":"' + $('#TxtDateTo').val() + '","Description":"' + $('#txtDescription').val() + '"}';
            alert(pval);
             var sd = JSON.parse(pval);
            sd = JSON.parse(pval);
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "EditSave", OnSuccessSave)
            DDLLvType();
        }

        function BtnCancel_OnClick()
        {
            $('#TxtEmpID').val('');
            $('#DDLLvType').val('');//#DDLHours
            $('#TxtDateFrom').val('');//#DDLHours
            $('#TxtDateTo').val('');
            $('#txtDescription').val('');
        }

    </script>
    <script src="Content/paging.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdnShiftID" runat="server" />
    <br />

    <br /><br /><br />
    <div class="panel">
        <div><input type="button" id="BtnAddnew" onclick="BtnAddNew_OnClick()" class="btn btn-primary" value="Add New" /><input type="button" id="BtnViewLeaveApp" onclick="BtnViewLeaveApp_OnClick()" class="btn btn-primary" value="Leaves View " /></div>
        <div id="TblsEARCH" style="display: none">
                        <div class="row">
                            <div class="col-lg-6"></div>
                            <div class="col-lg-6">
                                <div class="col-lg-3">
                                    <p style="align-items: baseline">Search By :</p>
                                </div>
                                <div class="col-lg-4">
                                    <select id="CboSb" class="form-control input-sm">
                                        
                                        <option value="2">Name
                                        </option>
                                        
                                    </select>
                                </div>
                                <div class="col-lg-5">
                                    <div class="input-group">
                                        <input type="text" class="form-control input-sm" placeholder="Search Value" id="SearchVal" />
                                        <span class="input-group-btn">
                                            <button type="button" class="btn btn-sm btn-success" value="Search" onclick="Search()"><i class="glyphicon glyphicon-search"></i></button>
                                        </span>
                                    </div>

                                </div>


                            </div>
                        </div>
                    </div>
        <div id="Container">

        </div>
        
    </div>
    <div id="DivAddN" style="display:none">
        <div class="panel panel-primary">
        <div class="panel-heading">Leave Application Add</div>
        <div class="panel-body">
            <div>
                <fieldset>
                    <div class="form-group">
                           <div class="col-lg-2">
                            <label class="control-label">Emp ID :</label>
                        </div>
                        <div class="col-lg-2">
                            <div class="input-group">
                                <input class="form-control input-sm" type="text" id="TxtEmpID" />
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                            </div>
                        </div>

                        <div class="col-lg-2">
                            <label class="control-label">Leave Type :</label>
                        </div>
                        <div class="col-lg-2">
                            <div class="input-group">
                                <select class=" form-control input-sm" id="DDLLvType" style="width:190px;"><%--name="DDLHours"--%>
                            
                                </select>
                            </div>
                        </div>


                    </div>
                        <div class="form-group">
                            <div class="col-lg-2">
                            <label class="control-label">Date From :</label>
                        </div>
                        <div class="col-lg-2">
                            <div class="input-group">
                                <%--<input class="datep" type="text" id="TxtDateFrom" />--%>
                                <input class="form-control input-sm" type="text" id="TxtDateFrom" />
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                            </div>
                        </div>

                        <div class="col-lg-2">
                            <label class="control-label">Date To :</label>
                        </div> 
                        <div class="col-lg-2" style="width:190px;">
                            <div class="input-group">
                            <input class="form-control input-sm" type="text" id="TxtDateTo" />
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                            </div>
                        </div>

                    </div>

                    <div class="form-group">
                        <div class="col-lg-2">
                            <label class="control-label">Description :</label>
                        </div>
                        <div class="col-lg-2">
                            <div class="input-group">
                                <textarea id="txtDescription"></textarea>
                            </div>
                        </div>
                        </div>
                    <div class="form-group">
                        <div class="col-lg-12 text-right">
                            <button class="btn btn-primary" type="button" id="Btnsaved" onclick="BtnSave_OnClick()">SAVE &nbsp<i class="glyphicon glyphicon-save"></i></button>
                            <button class="btn btn-success" type="button" id="BtnEditSave" onclick="BtnEditSave_OnClick()">Update &nbsp<i class="glyphicon glyphicon-edit"></i></button>
                             <button class="btn btn-danger" type="button" id="BtnCancel" onclick="BtnCancel_OnClick()">Cance &nbsp<i class="glyphicon glyphicon-remove"></i></button>
                            </div>
                    </div>
                </fieldset>
            </div>

        </div>
    </div>
    </div>
    
    <div id="Tbl" style="display:none">


            <div class="panel panel-primary">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-11">
                        <div class="text-right">
                            <button type="button" class="btn btn-danger btn-sm" onclick="LoadLeaveApp()" ><i class="glyphicon glyphicon-refresh"></i></button>
                        </div>
                    </div>
                </div>
                </div>
                <table class="table table-striped table-hover" id="DvTbl">
                    
                </table>
            <div class="panel-footer">
                    <div id="includedContent">

                    </div>

            </div>

        </div>       

    </div>

</asp:Content>

