<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Shifts.aspx.cs" Inherits="EMPMSHR.Shifts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $('#BtnEditSave').hide();
            $('#Btnsaved').show();
            $('#ddlHoli').hide();
        });
        var _PageName = "Shifts.aspx";
        var _MethodType = "POST";
        var _ShftID;
        var _Sorting = "1";
        var _SortAs = "Asc";
        var _RecordPP = "10";
        var _PageNo = "1";
        var _RecordCount = "0";
        var _Rowcount = "0";
        var PageCount = "0";
        var _MethodName = LoadShift;


        function LoadShift() {

            
            //use this line if you want to send any additional paramert that required on Stored procedure level
            // var pval = '{ "PageNo" :"50","RecordPerPage":"12","SortBy":"12","SortAs":"12","SearchBy":"12","SearchVal":"12","Extra" : [{"Pname":"@CompID","Pval":"2"}] }';
            // if you want to get all records then use this line as it has no extra parameter at the end......
            //_MethodName = LoadShift;
            var pval = '{ "PageNo" :"' + _PageNo + '","RecordPerPage":"' + _RecordPP + '","SortBy":"' + _Sorting + '","SortAs":"' + _SortAs + '","SearchBy":"0","SearchVal":"0" }';
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "GetShftByID", OnSuccessLoadData)
        }

        function AddVal(cbo)
        {
            var vday, add = 0;
            vday = $('#DDLHolidays').val();
            alert(vday);
            //var d = $('#DDLHolidays option:selected').val();
            //var dt = $('#DDLHolidays option:selected').text();
            var table = document.getElementById("DvTblHoli");

            //alert(table.rows.count);
            $('#DvTblHoli tr').each(function (i, row) {
                
                $cells = $(row).children();
                $cells.each(function (c, cell) {
                    $('#DvTblHoli tr').add(cell);
                    alert(c);
                    if(c==2)
                    {
                        if (vday == $(cell).text())
                        {
                            alert($(cell).text());
                            add = -1;
                        }
                        else
                        {
                            if (add != -1)
                            {
                                add = 1;
                            }
                            
                        }
                    }

                    

                });
            });

            if (add == 1)
            {
                $('#DvTblHoli').append("<tr id=><td></td><td></td><td>"+vday+"</td><td></td></tr>");
            }

            ////for (var i = 0; i = table.rows.count ; i++)
            ////{
            ////    //iterate through rows
            ////    //rows would be accessed using the "row" variable assigned in the for loop



            ////    //id++;

            ////    for (var j = 0;j = table[i].cells.count; j++)
            ////    {
            ////        //iterate through columns
            ////        //columns would be accessed using the "col" variable assigned in the for loop
            ////        alert(table.rows[i].cells[j].textContent);

                    
            ////    }
            ////}
//           


            LoadShift();
        }
        function Edit_Click(ShftID)
        {
            //alert(ShftID);
            _ShftID = ShftID;
            var pval = '{ "PageNo" :"0","RecordPerPage":"12","SortBy":"0","SortAs":"0","SearchBy":"0","SearchVal":"0","Extra" : [{"Pname":"@ID","Pval":"' + ShftID + '"}] }';
            alert(pval);
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "GetShftForEdit", OnSuccessLoadDataForEdit)
            
        }

        function Delete_Click(ShftID)
        {
            alert(ShftID);
            var pval = '{ "ID":"' + ShftID + '"}';
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "Delete", OnSuccessSave);
            LoadShift();
        }

        function OnSuccessLoadDataForEdit(response)
        {
            $("#Tbl").hide();
            $("#DivAddN").appendTo("#Container");
            $("#DivAddN").show();
            $('#BtnEditSave').show();

            //$('#DvTblHoli').show();
            //$('#ddlHoli').show();

            $('#Btnsaved').hide();
            $('#BtnAddHoli').show();

            $('#DvTblHoli').show();
            //$('#DvTblHoli').empty();
           //DvTblHoli

            alert(response.d);
            var Tbls = response.d.split("@@");
            var Nval = Tbls[0].replace('[', '').replace(']', '');
            var ss = JSON.parse(Nval);
            //$.each(ss[0], function (key, value) {
            //    alert(key+ " - "+ value);
            //});
            //alert(ss.TimeOut);

            //var holi = ss.Holiday.split(":");

            var tm = ss.TimeIN.split(":");
            // tm.append(ss.TimeOut.split(":"));
            var tmo = ss.TimeOut.split(":");
            $('#TxtShiftName').val(ss.Name);
            $('#TxtShiftCode').val(ss.Code);
            $('#DDLHours').val(tm[0]);
            $('#DDLMints').val(tm[1]);

            $('#DDL2Hours').val(tmo[0]);
            $('#DDL2Mints').val(tmo[1]);


            
           

            // alert(ss.Holiday);
            $('#DDLHolidays').val(ss.Holiday);
            //$('#DvTbl').val(holi);
            
            buildHtmlTableForHolidays("#DvTblHoli", JSON.parse(Tbls[1]));
            //var str = ss.Holiday;
            //var temp = new Array();
            //// this will return an array with strings "1", "2", etc.
            //temp = str.split(",");

            //$.each(temp, function (i) {
            //    alert(temp[i]);
            //    //$('#DvTblHoli').append("<tr id=" + temp[i] + "><td id=" + temp[i] + ">" + temp[i] + "</td><td><p id=" + temp[i] + " style='display:none'>" + temp[i] + "</p><a href=javascript:Remove_Click(\'" + temp[i] + "\')>Remove</a></td></tr>");
            //    $('#DvTblHoli').append("<tr>this is test</tr>");
            //});
            //$('#DvTblHoli').show();
            //$.each(temp, function () {

               
            //    var companytype = $(this);
            //    alert(companytype.text());
            //    $("#DvTblHoli").append($("<option></option>").val(temp).html(companytype));
            //    var d = $('#DDLHolidays option:selected').val();
            //    alert(d);

            //    var dt = $('#DDLHolidays option:selected').text();
            //    alert(dt);
            //    $('#DvTblHoli').append("<tr id=" + id + "><td id=" + d + ">" + dt + "</td><td><p id=" + id + " style='display:none'>" + d + "</p><a href=javascript:Remove_Click(\'" + id + "\')>Remove</a></td></tr>");
            //});

            //$('#DDLHours option:selected').val(tm[0].val);
            //$('#DDLMints option:selected').val(tm[1].val);

            //$('#DDL2Hours option:selected').val(tmo[0].val);
            //$('#DDL2Mints option:selected').val(tmo[1].val);
            alert(99);
           // getHolidays();
        }
        function getHolidays()
        {
            alert(_ShftID);
            
            var pval = '{ "ID":"' + _ShftID + '"}';
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "getHolidays", OnSuccessgetHolidays);
            
        }
        function OnSuccessgetHolidays(response)
        {
            alert(response.d);
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

        function buildHtmlTableForHolidays(selector, myList) {
            var columns = addAllColumnHeadersForholidays(selector, myList);

            for (var i = 0 ; i < myList.length ; i++) {
                var row$ = $('<tr/>');
                for (var colIndex = 0 ; colIndex < columns.length ; colIndex++) {
                    var cellValue = myList[i][columns[colIndex]];
                    if (cellValue == null) { cellValue = ""; }
                    row$.append($('<td/>').html(cellValue));
                }
                
                row$.append($('<td/>').html('<a href="javascript:Remove_Click(' + myList[i][columns[0]] + ');" >Remove</a>'));
                $(selector).append(row$);
            }
        }

        function addAllColumnHeadersForholidays(Selc, myList) {
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
            headerTr$.append($('<th/>').html("Remove"));
            $(Selc).append(headerTr$);

            return columnSet;
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

        function BtnAddNew_OnClick()
        {
            $('#TxtShiftName').val('');
            $('#TxtShiftCode').val('');//#DDLHours
            $('#DDLHours').val('00');//#DDLHours
            $('#DDLMints').val('00');
            $('#DDL2Hours').val('00');
            $('#DDL2Mints').val('00');
            
            $("#Tbl").hide();
            $("#DivAddN").appendTo("#Container");
            $("#DivAddN").show()
            $('#BtnEditSave').hide();
            $('#ddlHoli').hide();
            $('#Btnsaved').show();
            $('#BtnAddHoli').hide();
        }

        function BtnViewComapny_OnClick()
        {
            $("#DivAddN").hide();            
            $("#Tbl").appendTo("#Container");
            $("#Tbl").show();
            LoadShift();
        }

        function BtnSave_OnClick()
        {

            var pval = '{ "ShiftName" :"' + $('#TxtShiftName').val() + '","ShiftCode":"' + $('#TxtShiftCode').val() + '","TimeIn":"' + $('#DDLHours option:selected').val() + ':' + $('#DDLMints option:selected').val() + '","TimeOut":"' + $('#DDL2Hours option:selected').val() + ':' + $('#DDL2Mints option:selected').val() + '"}';
            
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "ShiftAdd", OnSuccessSave);
            alert(pval);
        }

        function OnSuccessSave(response)
        {
            var result = JSON.parse(response.d);
            
            alertpopup("Header", result.Msg, "Footer","0");
        }

        function BtnEditSave_OnClick()
        {
            var v2 = "";
            var holidays = "";
            $('#DvTblHoli tr').each(function () {
                // var v1 = $(this).find("td:eq(0)").text();
                v2 = $(this).find("td:eq(1)").find('p').text();
                holidays += + v2 + ",";
               
            });
            holidays = holidays.substring(0, holidays.length - 1)
            alert("holidays : " + holidays);
            
            var pval = '{"ID" :"' + _ShftID + '", "ShiftName" :"' + $('#TxtShiftName').val() + '","ShiftCode":"' + $('#TxtShiftCode').val() + '","TimeIn":"' + $('#DDLHours option:selected').val() + ':' + $('#DDLMints option:selected').val() + '","TimeOut":"' + $('#DDL2Hours option:selected').val() + ':' + $('#DDL2Mints option:selected').val() + '","Holiday":"' + holidays + '"}';
           // alert(pval);
             var sd = JSON.parse(pval);
            sd = JSON.parse(pval);
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "EditSave", OnSuccessSave)
            alert(1221);
            LoadShift();
        }
        function BtnCancel_OnClick()
        {
            $('#TxtShiftName').val('');
            $('#TxtShiftCode').val('');//#DDLHours
            $('#DDLHours').val('00');//#DDLHours
            $('#DDLMints').val('00');
            $('#DDL2Hours').val('00');
            $('#DDL2Mints').val('00');//DDLHolidays
            $('#DDLHolidays').val('00');
            LoadShift();
        }
        var id=0;
        function BtnAddHoli_OnClick()
        {
           // var Table = $('#DvTblHoli');
          // $('#DvTblHoli').show();
            //alert("dsd");
            ////$('#DvTblHoli').empty();
            $('#ddlHoli').show();//DvTblHoli
//            var d = $('#DDLHolidays option:selected').val();
            //var dt = $('#DDLHolidays option:selected').text();
           
            //id++;
           // $('#DvTblHoli').append("<tr id=" + id + "><td id=" + d + ">" + dt + "</td><td><p id=" + id + " style='display:none'>" + d + "</p><a href=javascript:Remove_Click(\'" + id + "\')>Remove</a></td></tr>");
            
            $('#BtnAddHoli').hide();
        }
        //function Remove_Click(Rowid) {
        //    $('#' + Rowid).remove();
        //    alert(RowId);
        //}myList[i][columns[0]]
        


    </script>
    <script src="Content/paging.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdnShiftID" runat="server" />
    <br />

    <br /><br /><br />
    <div class="panel">
        <div><input type="button" id="BtnAddnew" onclick="BtnAddNew_OnClick()" class="btn btn-primary" value="Add New" /><input type="button" id="BtnViewComapny" onclick="BtnViewComapny_OnClick()" class="btn btn-primary" value="View Shifts" /></div>
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
                                        <option value="3">Shift Type
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
        <div class="panel-heading">Shift Add</div>
        <div class="panel-body">
            <div>
                <fieldset>
                    <div class="form-group">
                        <div class="col-lg-2">
                            <label class="control-label">Shift Name :</label>
                        </div>
                        <div class="col-lg-2">
                            <div class="input-group">
                                <input class="form-control input-sm" type="text" id="TxtShiftName" />
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger"></i></span>
                            </div>
                        </div>

                        <div class="col-lg-2">
                            <label class="control-label">Shift Code :</label>
                        </div>
                        <div class="col-lg-2">
                            <div class="input-group">
                                <input class="form-control input-sm" type="text" id="TxtShiftCode" />
                                <span class="input-group-addon input-sm"><i class="glyphicon glyphicon-star text-danger small"></i></span>
                            </div>
                        </div>
                    </div>
                        <div class="form-group">
                        <div class="col-lg-2">
                            <label class="control-label">Shift TimeIn :</label>
                        </div> 
                        <div class="col-lg-2" style="width:190px;">
                            <div class="input-group">
                                <select name="DDLHours" class=" form-control input-sm" id="DDLHours" style="width:68px;">
                                    <option value="00">00</option>
                                    <option value="01">01</option>
                                    <option value="02">02</option>
                                    <option value="03">03</option>
                                    <option value="04">04</option>
                                    <option value="05">05</option>
                                    <option value="06">06</option>
                                    <option value="07">07</option>
                                    <option value="08">08</option>
                                    <option value="09">09</option>
                                    <option value="10">10</option>
                                    <option value="11">11</option>
                                    <option value="12">12</option>
                                    <option value="13">13</option>
                                    <option value="14">14</option>
                                    <option value="15">15</option>
                                    <option value="16">16</option>
                                    <option value="17">17</option>
                                    <option value="18">18</option>
                                    <option value="19">19</option>
                                    <option value="20">20</option>
                                    <option value="21">21</option>
                                    <option value="22">22</option>
                                    <option value="23">23</option>

                                </select>
                                <select class=" form-control input-sm" id="DDLMints" style="width:68px;">
                                    <option value="00">00</option>
                                    <option value="01">01</option>
                                    <option value="02">02</option>
                                    <option value="03">03</option>
                                    <option value="04">04</option>
                                    <option value="05">05</option>
                                    <option value="06">06</option>
                                    <option value="07">07</option>
                                    <option value="08">08</option>
                                    <option value="09">09</option>
                                    <option value="10">10</option>
                                    <option value="11">11</option>
                                    <option value="12">12</option>
                                    <option value="13">13</option>
                                    <option value="14">14</option>
                                    <option value="15">15</option>
                                    <option value="16">16</option>
                                    <option value="17">17</option>
                                    <option value="18">18</option>
                                    <option value="19">19</option>
                                    <option value="20">20</option>
                                    <option value="21">21</option>
                                    <option value="22">22</option>
                                    <option value="23">23</option>
                                    <option value="24">24</option>
                                    <option value="25">25</option>
                                    <option value="26">26</option>
                                    <option value="27">27</option>
                                    <option value="28">28</option>
                                    <option value="29">29</option>
                                    <option value="30">30</option>
                                    <option value="31">31</option>
                                    <option value="32">32</option>
                                    <option value="33">33</option>
                                    <option value="34">34</option>
                                    <option value="35">35</option>
                                    <option value="36">36</option>
                                    <option value="37">37</option>
                                    <option value="38">38</option>
                                    <option value="39">39</option>
                                    <option value="40">40</option>
                                    <option value="41">41</option>
                                    <option value="42">42</option>
                                    <option value="43">43</option>
                                    <option value="44">44</option>
                                    <option value="45">45</option>
                                    <option value="46">46</option>
                                    <option value="47">47</option>
                                    <option value="48">48</option>
                                    <option value="49">49</option>
                                    <option value="50">50</option>
                                    <option value="51">51</option>
                                    <option value="52">52</option>
                                    <option value="53">53</option>
                                    <option value="54">54</option>
                                    <option value="55">55</option>
                                    <option value="56">56</option>
                                    <option value="57">57</option>
                                    <option value="58">58</option>
                                    <option value="59">59</option>


                                </select>
                            </div>
                        </div>

                        <div class="col-lg-2">
                            <label class="control-label">Shift TimeOut :</label>
                        </div> 
                            <div class="col-lg-2" style="width:190px;">
                            <div class="input-group">
                                <select class=" form-control input-sm" id="DDL2Hours" style="width:68px;">
                                    <option value="00">00</option>
                                    <option value="01">01</option>
                                    <option value="02">02</option>
                                    <option value="03">03</option>
                                    <option value="04">04</option>
                                    <option value="05">05</option>
                                    <option value="06">06</option>
                                    <option value="07">07</option>
                                    <option value="08">08</option>
                                    <option value="09">09</option>
                                    <option value="10">10</option>
                                    <option value="11">11</option>
                                    <option value="12">12</option>
                                    <option value="13">13</option>
                                    <option value="14">14</option>
                                    <option value="15">15</option>
                                    <option value="16">16</option>
                                    <option value="17">17</option>
                                    <option value="18">18</option>
                                    <option value="19">19</option>
                                    <option value="20">20</option>
                                    <option value="21">21</option>
                                    <option value="22">22</option>
                                    <option value="23">23</option>

                                </select>
                                <select class=" form-control input-sm" id="DDL2Mints" style="width:68px;">
                                    <option value="00">00</option>
                                    <option value="01">01</option>
                                    <option value="02">02</option>
                                    <option value="03">03</option>
                                    <option value="04">04</option>
                                    <option value="05">05</option>
                                    <option value="06">06</option>
                                    <option value="07">07</option>
                                    <option value="08">08</option>
                                    <option value="09">09</option>
                                    <option value="10">10</option>
                                    <option value="11">11</option>
                                    <option value="12">12</option>
                                    <option value="13">13</option>
                                    <option value="14">14</option>
                                    <option value="15">15</option>
                                    <option value="16">16</option>
                                    <option value="17">17</option>
                                    <option value="18">18</option>
                                    <option value="19">19</option>
                                    <option value="20">20</option>
                                    <option value="21">21</option>
                                    <option value="22">22</option>
                                    <option value="23">23</option>
                                    <option value="24">24</option>
                                    <option value="25">25</option>
                                    <option value="26">26</option>
                                    <option value="27">27</option>
                                    <option value="28">28</option>
                                    <option value="29">29</option>
                                    <option value="30">30</option>
                                    <option value="31">31</option>
                                    <option value="32">32</option>
                                    <option value="33">33</option>
                                    <option value="34">34</option>
                                    <option value="35">35</option>
                                    <option value="36">36</option>
                                    <option value="37">37</option>
                                    <option value="38">38</option>
                                    <option value="39">39</option>
                                    <option value="40">40</option>
                                    <option value="41">41</option>
                                    <option value="42">42</option>
                                    <option value="43">43</option>
                                    <option value="44">44</option>
                                    <option value="45">45</option>
                                    <option value="46">46</option>
                                    <option value="47">47</option>
                                    <option value="48">48</option>
                                    <option value="49">49</option>
                                    <option value="50">50</option>
                                    <option value="51">51</option>
                                    <option value="52">52</option>
                                    <option value="53">53</option>
                                    <option value="54">54</option>
                                    <option value="55">55</option>
                                    <option value="56">56</option>
                                    <option value="57">57</option>
                                    <option value="58">58</option>
                                    <option value="59">59</option>

                                </select>
                            </div>
                        </div>

                    </div>
                    <div class="form-group" id="ddlHoli">
                        <div class="col-lg-2">
                            <label class="control-label">Holidays :</label>
                        </div>
                        <div class="col-lg-2" style="width:190px;">
                            <div class="input-group">
                                
                                <select class=" form-control" id="DDLHolidays">
                                    <option value="0">Text</option>
                                    <option value="1">Monday</option>
                                    <option value="2">Tuesday</option>
                                    <option value="3">Wednesday</option>
                                    <option value="4">Thurday</option>
                                    <option value="5">Friday</option>
                                    <option value="6">Saturday</option>
                                    <option value="7">Sunday</option>
                                </select>
                                <span class="input-group-addon input-sm"><button type="button" class="btn btn-primary" onclick="AddVal(this)" id="BtnAddHoloidayToList" ></button></span>
                            </div>

                        </div>

                    </div>
                    <table class="table table-striped table-hover" id="DvTblHoli">
                    
                    </table> 
                    <div class="form-group">
                        <div class="col-lg-12 text-right">
                            <button class="btn btn-primary" type="button" id="Btnsaved" onclick="BtnSave_OnClick()">SAVE &nbsp<i class="glyphicon glyphicon-save"></i></button>
                            <button class="btn btn-success" type="button" id="BtnEditSave" onclick="BtnEditSave_OnClick()">Update &nbsp<i class="glyphicon glyphicon-edit"></i></button>
                             <button class="btn btn-danger" type="button" id="BtnCancel" onclick="BtnCancel_OnClick()">Cance &nbsp<i class="glyphicon glyphicon-remove"></i></button>
                            
                    <div class="text-left">
                         <button class="btn btn-primary" type="button" id="BtnAddHoli" onclick="BtnAddHoli_OnClick()">Add Holiday &nbsp<i class="glyphicon glyphicon-save"></i></button> 
                    </div>
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
                            <button type="button" class="btn btn-danger btn-sm" onclick="LoadShift()" ><i class="glyphicon glyphicon-refresh"></i></button>
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
