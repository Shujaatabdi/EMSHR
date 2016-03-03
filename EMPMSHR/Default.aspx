<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EMPMSHR.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
      ////  var myList = [{ "name": "abc", "age": 50 },
      //        { "age": "25", "hobby": "swimming" },
      //        { "name": "xyz", "hobby": "programming" }];
        function ss() {
          //  alert("sdf");
            //var text = '{ "employees" : [' +
            //'{ "firstName":"John" , "lastName":"Doe" },' +
            //'{ "firstName":"Anna" , "lastName":"Smith" },' +
            //'{ "firstName":"Peter" , "lastName":"Jones" } ],"RecordCount":"14","Recordperpage":"5"}';

            //var obj = JSON.parse(text);
            //alert( obj.employees[0].firstName);
            //alert(obj.RecordCount);
            //alert(obj.Recordperpage);
            var _PageName = "Default.aspx";
            var _MethodType = "POST";
            // @CompID
            var pval = '{ "PageNo" :"50","RecordPerPage":"12","SortBy":"12","SortAs":"12","SearchBy":"12","SearchVal":"12","Extra" : [{"Pname":"@CompID","Pval":"2"}] }';
            //var sd = JSON.parse(pval);
            
           // alert(ss.Extra[1].Pname);
            //CallByAjaxWithoutParameter(_PageName, _MethodType, "LoadData", OnSuccessLoadData)
            CallByAjaxWithParameter("data", pval, _PageName, _MethodType, "GetCompByID", OnSuccessLoadData)
        }

        function OnSuccessLoadData(response)
        {
            var myList = JSON.parse(response.d);
           // alert(response.d);
            buildHtmlTable("#DvTbl", myList);
        }

        // Builds the HTML Table out of myList.
        function buildHtmlTable(selector, myList) {
            var columns = addAllColumnHeaders(selector, myList);

            for (var i = 0 ; i < myList.length ; i++) {
                var row$ = $('<tr/>');
                for (var colIndex = 0 ; colIndex < columns.length ; colIndex++) {
                    var cellValue = myList[i][columns[colIndex]];
                    if (cellValue == null) { cellValue = ""; }
                    row$.append($('<td/>').html(cellValue));
                }
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
                       // alert(key);
                        columnSet.push(key);
                        headerTr$.append($('<th/>').html(key));
                    }
                }
            }
            $(Selc).append(headerTr$);

            return columnSet;
        }
        // Adds a header row to the table and returns the set of columns.
        // Need to do union of keys from all records as some records may not contain
        // all records

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <h1>EMS-HR</h1>
        <p class="lead">EMS-HR is a HR related Employee Management System.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
        <input type="button" value="btn" onclick="ss();" />
    </div>
    <div class="row">


        <div class="col-lg-3 col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="glyphicon glyphicon-comment fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="fa-3x">26</div>
                            <div>New Comments!</div>
                        </div>
                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left">View Details</span>
                        <span class="pull-right"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>


        <div class="col-lg-3 col-md-6">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="glyphicon glyphicon-comment fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="fa-3x">26</div>
                            <div>New Comments!</div>
                        </div>
                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left">View Details</span>
                        <span class="pull-right"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>


        <div class="col-lg-3 col-md-6">
            <div class="panel panel-warning">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="glyphicon glyphicon-comment fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="fa-3x">26</div>
                            <div>New Comments!</div>
                        </div>
                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left">View Details</span>
                        <span class="pull-right"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>

        <div class="col-lg-3 col-md-6">
            <div class="panel panel-danger">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-xs-3">
                            <i class="glyphicon glyphicon-comment fa-5x"></i>
                        </div>
                        <div class="col-xs-9 text-right">
                            <div class="fa-3x">26</div>
                            <div>New Comments!</div>
                        </div>
                    </div>
                </div>
                <a href="#">
                    <div class="panel-footer">
                        <span class="pull-left">View Details</span>
                        <span class="pull-right"><i class="glyphicon glyphicon-circle-arrow-right"></i></span>
                        <div class="clearfix"></div>
                    </div>
                </a>
            </div>
        </div>

    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">
            <div class="panel-heading">Table</div>

                <table class="table table-striped table-hover" id="DvTbl">
                </table>
            <div class="panel-footer">
                <span ><button class="btn btn-danger btn-sm" ><i class="glyphicon glyphicon-step-backward"></i></button></span>
                <span ><button class="btn btn-danger btn-sm" ><i class="glyphicon glyphicon-backward"></i></button></span>
                <span ><input type="text" class="text-danger" /></span>
                <span ><button class="btn btn-danger btn-sm" ><i class="glyphicon glyphicon-forward"></i></button></span>
                <span ><button class="btn btn-danger btn-sm" ><i class="glyphicon glyphicon-step-forward"></i></button></span>
                <div class="clearfix"></div>
            </div>

        </div>
        </div>
        

    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <div class="chat-panel panel panel-default">
                        <div class="panel-heading">
                            <i class="glyphicon check-circle text-danger"></i>
                            Chat
                            <div class="btn-group pull-right">
                                <button type="button" class="btn btn-default btn-xs dropdown-toggle" data-toggle="dropdown">
                                    <i class="glyphicon glyphicon-chevron-down"></i>
                                </button>
                                <ul class="dropdown-menu slidedown">
                                    <li>
                                        <a href="#">
                                            <i class="glyphicon glyphicon-refresh" ></i> Refresh
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">
                                            <i class="fa fa-check-circle fa-fw"></i> Available
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">
                                            <i class="fa fa-times fa-fw"></i> Busy
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">
                                            <i class="fa fa-clock-o fa-fw"></i> Away
                                        </a>
                                    </li>
                                    <li class="divider"></li>
                                    <li>
                                        <a href="#">
                                            <i class="fa fa-sign-out fa-fw"></i> Sign Out
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>

        </div>
    </div>
    </div>
</asp:Content>
