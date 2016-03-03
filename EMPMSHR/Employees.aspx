<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="EMPMSHR.Employees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var _PageName = "Employees.aspx";
        var _MethodType = "POST";
        var _ID;
        var _Sorting = "1";
        var _SortAs = "Asc";
        var _RecordPP = "10";
        var _PageNo = "1";
        var _RecordCount = "0";
        var _Rowcount = "0";
        var PageCount = "0";
        $(function () { LoadEmployee(); });
        function LoadCbos()
        {
           FillCbo.Category("CboCategory");
           FillCbo.Department("CboDepartment");
           FillCbo.Designation("CboDesignation");
           FillCbo.Shifts("CboShift");
           FillCbo.Policy("CboPolicy");
        }
        function LoadEmployee() {
            _MethodName = LoadEmployee;
            var pval = '{ "PageNo" :"' + _PageNo + '","RecordPerPage":"' + _RecordPP + '","SortBy":"' + _Sorting + '","SortAs":"' + _SortAs + '","SearchBy":"0","SearchVal":"0" }';
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "GetAllEmpPaging", OnSuccessLoadData);
        }

        function Edit_Click(EmpID) {
            //alert(ShftID);
            _ID = EmpID;
            var pval = '{ "PageNo" :"0","RecordPerPage":"12","SortBy":"0","SortAs":"0","SearchBy":"0","SearchVal":"0","Extra" : [{"Pname":"@ID","Pval":"' + EmpID + '"}] }';
            alert(pval);
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "GetEmpByID", OnSuccessLoadDataForEdit)

        }

        function OnSuccessLoadDataForEdit(response)
        {
            $("#Tbl").hide();
            $("#ADDN").appendTo("#container");
            $("#ADDN").show();
            $('#BtnEditSave').show();
            $('#Btnsaved').hide();

            var ss = JSON.parse(response.d.replace('[', '').replace(']', ''));

            $('#TxtFName').val(ss.FirstName);
            $('#TxtLName').val(ss.LastName);
            $('#TxtCode').val(ss.Code);
            $('#TxtFatherName').val(ss.FatherName);
            $('#CboGender').val(ss.Gender);
            $('#TxtPic').val(ss.Picture);
            $('#TxtCNIC').val(ss.CNIC);
            $('#TxtTAXHST').val(ss.TAXHST);
            $('#CboDepartment').val(ss.DeptID);
            $('#CboDesignation').val(ss.DesignationID);
            $('#CboShift').val(ss.ShiftID);
            $('#CboCategory').val(ss.CategoryID);
            $('#CboPolicy').val(ss.PolicyID);
            $('#TxtSalary').val();
            
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
            headerTr$.append($('<th/>').html("Delete"));
            $(Selc).append(headerTr$);

            return columnSet;
        }

        function BtnAddNew_OnClick()
        {
            LoadCbos();
            $('#Tbl').slideUp("Slow");
            $('#ADDN').show();
        }

        function BtnViewEmployee_OnClick()
        {
            $('#ADDN').slideUp("Slow");
            $('#Tbl').show("Slow");
        }

        function BtnSave_OnClick()
        {
            var pval = '{ "DeptID" :"' + $('#CboDepartment').val() + '","DesignationID":"' + $('#CboDesignation').val() + '","ShiftID":"' + $('#CboShift').val() + '","CategoryID":"' + $('#CboCategory').val() + '","FirstName":"' + $('#TxtFName').val() + '","LastName":"' + $('#TxtLName').val() + '","Code":"' + $('#TxtCode').val() + '","FatherName":"' + $('#TxtFatherName').val() + '","Gender":"' + $('#CboGender').val() + '","Picture":"' + $('#TxtPic').val() + '","CNIC":"' + $('#TxtCNIC').val() + '","TaxHst":"' + $('#TxtTAXHST').val() + '","PolicyID":"' + $('#CboPolicy').val() + '","Salary":"' + $('#TxtSalary').val() + '"}';
            // var sd = json.parse(pval);
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "AddNew", OnSuccessSave)
        }

        function BtnEditSave_OnClick()
        {
            var pval = '{ "ID" :"' + _ID + '","DeptID" :"' + $('#CboDepartment').val() + '","DesignationID":"' + $('#CboDesignation').val() + '","ShiftID":"' + $('#CboShift').val() + '","CategoryID":"' + $('#CboCategory').val() + '","FirstName":"' + $('#TxtFName').val() + '","LastName":"' + $('#TxtLName').val() + '","Code":"' + $('#TxtCode').val() + '","FatherName":"' + $('#TxtFatherName').val() + '","Gender":"' + $('#CboGender').val() + '","Picture":"' + $('#TxtPic').val() + '","CNIC":"' + $('#TxtCNIC').val() + '","TaxHst":"' + $('#TxtTAXHST').val() + '","PolicyID":"' + $('#CboPolicy').val() + '","Salary":"' + $('#TxtSalary').val() + '"}';
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "SaveForEdit", OnSuccessSave)
        }

        function OnSuccessSave(response)
        {
            var result = JSON.parse(response.d);
            alertpopup("Header", result.Msg, "Footer", "0");
        }

     //   $('#TxtPostalCode').datepicker();
    </script>
    <script src="Content/FillCbos.js"></script>
    <script src="Content/paging.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <br />
    <br /><br /><br />
    <div class="panel">
    <div><input type="button" id="BtnAddnew" onclick="BtnAddNew_OnClick()" class="btn btn-primary" value="Add New" /><input type="button" id="BtnViewComapny" onclick="BtnViewEmployee_OnClick()" class="btn btn-primary" value="View Employees" /></div>
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
                                        <option value="3">Company Type
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
    <div id="Tbl">
            <div class="panel panel-primary">
            <div class="panel-heading">
                <div class="row">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-11">
                        <div class="text-right">
                            <button type="button" class="btn btn-danger btn-sm" onclick="LoadBranch()" ><i class="glyphicon glyphicon-refresh"></i></button>
                        </div>
                    </div>
                </div>
                </div>
                <div  style="overflow-x:auto">
                <table class="table table-striped table-hover" id="DvTbl">
                </table>
                </div>

            <div class="panel-footer">
                    <div id="includedContent">

                    </div>

            </div>

        </div>

        

    </div>
        <div id="ADDN" style="display:none">
            <div class="panel panel-primary">
                <div class="panel-heading">Employee</div>
                <div class="panel-body">
                    <fieldset>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <label class="control-label">First Name :</label>
                        </div>
                        <div class="col-lg-2">
                            <div class="input-group">
                                <input class="form-control input-sm" type="text" id="TxtFName" />
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger"></i></span>
                            </div>
                        </div>

                        <div class="col-lg-2">
                            <label class="control-label">Last Name:</label>
                        </div>  
                        <div class="col-lg-2">
                            <div class="input-group">
                                <input class="form-control input-sm" type="text" id="TxtLName" />
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                            </div>
                        </div>


                    </div>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <label class="control-label">Code :</label>
                        </div>
                        <div class="col-lg-2">
                            <div class="input-group">
                                <input class="form-control input-sm" type="text" id="TxtCode" />
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger"></i></span>
                            </div>
                        </div>

                        <div class="col-lg-2">
                            <label class="control-label">Father Name:</label>
                        </div>  
                        <div class="col-lg-2">
                            <div class="input-group">
                                <input class="form-control input-sm" type="text" id="TxtFatherName" />
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                            </div>
                        </div>


                    </div>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <label class="control-label">Gender :</label>
                        </div>
                        <div class="col-lg-2">
                            <div class="input-group">
                                <input class="form-control input-sm" type="text" id="CboGender" />
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger"></i></span>
                            </div>
                        </div>

                        <div class="col-lg-2">
                            <label class="control-label">Picture:</label>
                        </div>  
                        <div class="col-lg-2">
                            <div class="input-group">
                                <input class="form-control input-sm" type="text" id="TxtPic" />
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                            </div>
                        </div>


                    </div>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <label class="control-label">CNIC :</label>
                        </div>
                        <div class="col-lg-2">
                            <div class="input-group">
                                <input class="form-control input-sm" type="text" id="TxtCNIC" />
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger"></i></span>
                            </div>
                        </div>

                        <div class="col-lg-2">
                            <label class="control-label">TAXHST :</label>
                        </div>  
                        <div class="col-lg-2">
                            <div class="input-group">
                                <input class="form-control input-sm" type="text" id="TxtTAXHST" />
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                            </div>
                        </div>


                    </div>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <label class="control-label">Department :</label>
                        </div>
                        <div class="col-lg-2">
                            <div class="input-group">
                                <select class="form-control input-sm" id="CboDepartment">      </select>
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger"></i></span>
                            </div>
                        </div>

                        <div class="col-lg-2">
                            <label class="control-label">Desgination :</label>
                        </div>  
                        <div class="col-lg-2">
                            <div class="input-group">
                                <select class="form-control input-sm" id="CboDesignation">      </select>
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                            </div>
                        </div>


                    </div>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <label class="control-label">Shift :</label>
                        </div>
                        <div class="col-lg-2">
                            <div class="input-group">
                                <select class="form-control input-sm" id="CboShift"><option>1</option>      </select>
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger"></i></span>
                            </div>
                        </div>

                        <div class="col-lg-2">
                            <label class="control-label">Category :</label>
                        </div>  
                        <div class="col-lg-2">
                            <div class="input-group">
                                <select class="form-control input-sm" id="CboCategory">      </select>
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                            </div>
                        </div>


                    </div>
                        <div class="form-group">
                            <div class="col-lg-2">
                                <label class="control-label">Policy :</label>
                            </div>
                            <div class="col-lg-2">
                                <div class="input-group">
                                    <select class="form-control input-sm" id="CboPolicy">
                                        <option>1</option>
                                    </select>
                                    <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger"></i></span>
                                </div>
                            </div>
                        <div class="col-lg-2">
                            <label class="control-label">Salary :</label>
                        </div>  
                        <div class="col-lg-2">
                            <div class="input-group">
                                <input class="form-control input-sm" type="text" id="TxtSalary" />
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                            </div>
                        </div>

                        </div>
                    <div class="form-group">
                        <div class="col-lg-12 text-right">
                            <button class="btn btn-primary" type="button" id="Btnsaved" onclick="BtnSave_OnClick()">SAVE &nbsp<i class="glyphicon glyphicon-save"></i></button>
                            <button class="btn btn-success" type="button" id="BtnEditSave" onclick="BtnEditSave_OnClick()">SAVE &nbsp<i class="glyphicon glyphicon-edit"></i></button>
                             <button class="btn btn-danger" type="button" id="BtnCancel" onclick="BtnCancel_OnClick()">Cance &nbsp<i class="glyphicon glyphicon-remove"></i></button>
                            </div>
                    </div>
                </fieldset>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
