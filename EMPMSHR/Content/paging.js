var _MethodName;

$(function () {
    
    $.ajaxSetup({ async: false });
    $("#includedContent").load("../Content/Navigation.htm");
    $('#TxtPageNo').val(_PageNo);
    $('#MPageCount').text(PageCount);
    $('#tot').text(_Rowcount);
    var input = document.getElementById("SearchVal");
    if (input.addEventListener)
        input.addEventListener("keypress", function (e) {

            if (e.keyCode === 13) {
                // do stuff 
                Search();
                e.preventDefault();
            }
        }, false);
    else if (input.attachEvent)
        input.attachEvent("onkeypress", function (e) {

            if (e.keyCode === 13) {
                // do stuff
                Search();
                return e.returnValue = false;
            }
        });
});


function Myfunc(obj) {
    if (_Sorting == obj) {
        if (_SortAs == "Asc") {
            _SortAs = "Desc";
        }
        else {
            _SortAs = "Asc";
        }
    }
    else {
        _SortAs = "Asc";
    }
    _Sorting = obj;
    _MethodName();
}

function ChangePage(tr) {
    if (tr == "N") {// Move Next
        if (_PageNo < PageCount) {
            _PageNo++;
            $('#TxtPageNo').val(_PageNo);
            _MethodName();
        }
    }
    else if (tr == "P") {//Move Previous
        _PageNo = _PageNo - 1;
        _PageNo = (_PageNo <= 0) ? 1 : _PageNo;
        $('#TxtPageNo').val(_PageNo);
        _MethodName();
    }
    else if (tr == "F") {// Move First
        _PageNo = 1;
        _MethodName();
    }
    else {// Move Last
        _PageNo = $('#MPageCount').text();
        _MethodName();
    }
    // alert(_PageNo);
    return false;
}

function ChangeTargetPage(e) {
   // alert("this is enter");
    if (e.keyCode == 13) {
        _PageNo = $('#TxtPageNo').val();
        // alert(_PageNo);
        if (_PageNo > PageCount || _PageNo < 1) {
            alert("Page Not Exists");
        }
        else { _MethodName(); }

        return false;
    }
}

function Cbo_RecordPP_Change(cbo) {

    //alert($('#Cbo_RecordPP').val());
    _RecordPP = $('#Cbo_RecordPP').val();
    _PageNo = "1";
    _MethodName();

}

function ShowSearch() {
    //  alert($('#TblsEARCH').prop('display'));
    if (_SearchViz == 0) {
        $('#TblsEARCH').show();
        $('#imghidesearch').show();
        $('#imgsearch').hide();
        _SearchViz = 1;
    }
    else {
        $('#TblsEARCH').hide();
        $('#imghidesearch').hide();
        $('#imgsearch').show();
        _SearchViz = 0;
        _MethodName();
    }
}

function mychange() {

    window.location.assign("http://localhost:2473/");
}