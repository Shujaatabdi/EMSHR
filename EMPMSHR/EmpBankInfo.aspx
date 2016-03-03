<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="EmpBankInfo.aspx.cs" Inherits="EMPMSHR.EmpBankInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $('#BtnEditSave').hide();
            $('#Btnsaved').show();

        });
        var _PageName = "EmpBankInfo.aspx";
        var _MethodType = "POST";
        var _EmpBankInfoID;
        var _Sorting = "1";
        var _SortAs = "Asc";
        var _RecordPP = "10";
        var _PageNo = "1";
        var _RecordCount = "0";
        var _Rowcount = "0";
        var PageCount = "0";
        var _MethodName = LoadEmpBankInfo;

        function LoadEmpBankInfo() {
           

            //use this line if you want to send any additional paramert that required on Stored procedure level
            // var pval = '{ "PageNo" :"50","RecordPerPage":"12","SortBy":"12","SortAs":"12","SearchBy":"12","SearchVal":"12","Extra" : [{"Pname":"@CompID","Pval":"2"}] }';
            // if you want to get all records then use this line as it has no extra parameter at the end......
            //_MethodName = LoadShift;
            var pval = '{ "PageNo" :"' + _PageNo + '","RecordPerPage":"' + _RecordPP + '","SortBy":"' + _Sorting + '","SortAs":"' + _SortAs + '","SearchBy":"0","SearchVal":"0" }';
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "GetEmpBankInfoForPaging", OnSuccessLoadData);

        }
        function LoadAllEmpBankInfo() {

            CallByAjaxWithoutParameter(_PageName, _MethodType, "LoadEmpBankInfo", OnSuccessLoadAllData);

        }

        function Edit_Click(EmpBankInfoID) {


            _EmpBankInfoID = EmpBankInfoID;

            var pval = '{ "PageNo" :"0","RecordPerPage":"12","SortBy":"0","SortAs":"0","SearchBy":"0","SearchVal":"0","Extra" : [{"Pname":"@ID","Pval":"' + _EmpBankInfoID + '"}] }';
            //var pval = '{ "ID":"' + DeductionID + '"}';
            alert(pval);
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "GetEmpBankInfoByID", OnSuccessLoadDataForEdit)

           // alert(pval);
           // alert(333);
        }

        function Delete_Click(EmpBankInfoID) {

            var pval = '{ "ID":"' + EmpBankInfoID + '"}';
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "DeleteEmpBankInfo", OnSuccessSave);
            //  LoadDepartment();
        }

        function OnSuccessLoadDataForEdit(response) {
            alert(response.d);
            $("#Tbl").hide();
            $("#DivAddN").appendTo("#Container");
            $("#DivAddN").show();
            $('#BtnEditSave').show();
            $('#Btnsaved').hide();





            var Nval = response.d.replace('[', '').replace(']', '');
            var ss = JSON.parse(Nval);
            //$.each(ss[0], function (key, value) {
            //    alert(key+ " - "+ value);
            //});
            //alert(ss.TimeOut);


            $('#TxtEmpID').val(ss.EmpID);
            $('#TxtBankName').val(ss.BankName);
            $('#TxtBranch').val(ss.Branch);
            $('#TxtAccNo').val(ss.AccountNo);
            $('#TxtAccTitle').val(ss.AccountTitle);

            //$('#DDLHours option:selected').val(tm[0].val);
            //$('#DDLMints option:selected').val(tm[1].val);

            //$('#DDL2Hours option:selected').val(tmo[0].val);
            //$('#DDL2Mints option:selected').val(tmo[1].val);

        }

        function OnSuccessLoadData(response) {
            alert(2);
            var v1 = response.d.split("@@");

            var rc = JSON.parse(v1[1]);
            alert(response.d);

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
                row$.append($('<td/>').html('<a href="javascript:Edit_Click(' + myList[i][columns[0]] + ');" >Edit</a>'));
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
            headerTr$.append($('<th/>').html("EDIT"));
            headerTr$.append($('<th/>').html("DELETE"));
            $(Selc).append(headerTr$);

            return columnSet;
        }

        function BtnAddNew_OnClick() {

            $('#TxtEmpID').val('');
            $('#TxtBankName').val('');
            $('#TxtBranch').val('');
            $('#TxtAccNo').val('');
            $('#TxtAccTitle').val('');
   
            $("#Tbl").hide();
            $("#DivAddN").appendTo("#Container");
            $("#DivAddN").show()
            $('#BtnEditSave').hide();
            $('#Btnsaved').show();
        }

        function BtnViewComapny_OnClick() {



            $("#DivAddN").hide();

            $("#Tbl").appendTo("#Container");

            $("#Tbl").show();
            LoadEmpBankInfo();
        }

        function BtnSave_OnClick() {

            var pval = '{ "EmpID":"' + $('#TxtEmpID').val() + '","BankName":"' + $('#TxtBankName').val() + '","Branch":"' + $('#TxtBranch').val() + '","AccountNo":"' + $('#TxtAccNo').val() + '","AccountTitle":"' + $('#TxtAccTitle').val() + '"}';

            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "EmpBankInfoAdd", OnSuccessSave);

        }

        function OnSuccessSave(response) {
            var result = JSON.parse(response.d);

            alertpopup("Header", result.Msg, "Footer", "0");
        }

        function BtnEditSave_OnClick() {

            var pval = '{"ID" :"' + _EmpBankInfoID + '", "EmpID" :"' + $('#TxtEmpID').val() + '", "BankName" :"' + $('#TxtBankName').val() + '", "Branch" :"' + $('#TxtBranch').val() + '", "AccountNo" :"' + $('#TxtAccNo').val() + '", "AccountTitle" :"' + $('#TxtAccTitle').val() + '"}';

            var sd = JSON.parse(pval);
            sd = JSON.parse(pval);
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "EditEmpBankInfo", OnSuccessSave)
            // LoadDepartment();
        }
        function BtnCancel_OnClick() {

            $('#TxtEmpID').val('');//#DDLHours
            $('#TxtBankName').val('');
            $('#TxtBranch').val('');
            $('#TxtAccNo').val('');
            $('#TxtAccTitle').val('');
        }
    </script>
    <script src="Content/paging.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdnShiftID" runat="server" />
    <br />

    <br /><br /><br />
    <div class="panel">
        <div><input type="button" id="BtnAddnew" onclick="BtnAddNew_OnClick()" class="btn btn-primary" value="Add New" /><input type="button" id="BtnViewComapny" onclick="    BtnViewComapny_OnClick()" class="btn btn-primary" value="View EmpBankInfo" /></div>
        <div id="TblsEARCH" style="display: none">
            <div class="row">
                <div class="col-lg-6"></div>
                <div class="col-lg-6">
                    <div class="col-lg-3">
                        <p style="align-items: baseline">Search By :</p>
                    </div>
                    <div class="col-lg-4">
                        <select id="CboSb" class="form-control input-sm">

                            <option value="2">
                                Name
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
            <div class="panel-heading">EmpBankInfo Add</div>
            <div class="panel-body">
                <div>
                    <fieldset>
                        <div class="form-group">
                            <div class="col-lg-2">
                                <label class="control-label">EmpLID :</label>
                            </div>

                            <div class="col-lg-2">
                                <div class="input-group">
                                    <input class="form-control input-sm" type="text" id="TxtEmpID" />
                                    <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <label class="control-label">BankName :</label>
                            </div>

                            <div class="col-lg-2">
                                <div class="input-group">
                                    <input class="form-control input-sm" type="text" id="TxtBankName" />
                                    <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-lg-2">
                                <label class="control-label">Branch :</label>
                            </div>

                            <div class="col-lg-2">
                                <div class="input-group">
                                    <input class="form-control input-sm" type="text" id="TxtBranch" />
                                    <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <label class="control-label">AccountNO :</label>
                            </div>

                            <div class="col-lg-2">
                                <div class="input-group">
                                    <input class="form-control input-sm" type="text" id="TxtAccNo" />
                                    <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-2">
                                <label class="control-label">AccounTitle :</label>
                            </div>

                            <div class="col-lg-2">
                                <div class="input-group">
                                    <input class="form-control input-sm" type="text" id="TxtAccTitle" />
                                    <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
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
                            <button type="button" class="btn btn-danger btn-sm" onclick="LoadEmpBankInfo()"><i class="glyphicon glyphicon-refresh"></i></button>
                        </div>
                    </div>
                </div>
            </div>
            <table class="table table-striped table-hover" id="DvTbl">
                <tr>
                    <th>
                        <div>ID</div>
                    </th>

                    <th>
                        <div>EmpID</div>
                    </th>
                    <th>
                        <div>BankName</div>
                    </th>

                    <th>
                        <div>Branch</div>
                    </th> 
                    <th>
                        <div>AccountNo</div>
                    </th>

                    <th>
                        <div>AccounTitle</div>
                    </th>
                   
                </tr>
                <tr>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </table>
            <div class="panel-footer">
                <div id="includedContent">
                </div>

            </div>

        </div>



    </div>

</asp:Content>
