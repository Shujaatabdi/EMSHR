var _Selector;
var FillCbo =JSON.parse( '{"Category":"","Department":"","Designation":"","Shifts":"","Policy":""}');
FillCbo.Category = CboCategory;
FillCbo.Department = CboDepartment;
FillCbo.Designation = CboDesignation;
FillCbo.Shifts = CboShift;
FillCbo.Policy = CboPolicy;

function CboCategory(PCboName)
{
    _Selector = PCboName;
    CallByAjaxWithoutParameter("category.aspx", _MethodType, "LoadCateg", OnSuccessFillCbo)
}

function CboDepartment(PCboName)
{
    _Selector = PCboName;
    CallByAjaxWithoutParameter("Department.aspx", _MethodType, "LoadDepartment", OnSuccessFillCbo)
}

function CboDesignation(PCboName)
{
    _Selector = PCboName;
    CallByAjaxWithoutParameter("Designation.aspx", _MethodType, "LoadDesignation", OnSuccessFillCbo)
}
function CboPolicy(PCboName) {
    _Selector = PCboName;
    CallByAjaxWithoutParameter("Policy.aspx", _MethodType, "LoadPolicy", OnSuccessFillCbo)
}

function CboShift(PCboName)
{
    _Selector = PCboName;
    CallByAjaxWithoutParameter("shifts.aspx", _MethodType, "LoadShift", OnSuccessFillCbo)
}

function OnSuccessFillCbo(response)
{
  //  alert(response.d);
    var listItems = "";
    var jsonData =JSON.parse(response.d);
    for (var i = 0; i < jsonData.length; i++) {
        listItems += "<option value='" + jsonData[i].ID + "'>" + jsonData[i].Name + "</option>";
    }
    $("#"+_Selector).html(listItems);
}