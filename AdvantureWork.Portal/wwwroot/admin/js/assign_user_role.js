var arrayRoleIdsForAssign = [];

//members

function getAllMembers() {
    var url = DOMAIN + "Admin/UserRole/GetJsonAllUser"
    $.ajax(
        {
            url: url,
            type: "GET",

            data: JSON.stringify({}),
            contentType: "application/json",
            //contentType: "application/x-www-form-urlencoded",
            dataType: 'json',

            success: function (result) {
               
                displayMembers(result.data);
            }, error: function (err) {
                console.log(err);
            }
        }
    );
}


jQuery(document).ready(function ($) {

    $('#btnAssignRole').click(function () {
        // Reset table:
        $('#roles-assign').empty();
        jQuery("#modal-title-id").html("Assign role");
        jQuery("#edit-flag").val("INSERT");  

        getAllMembers();
        getAllRolesForAssign();

    });
    // Assign role to employees:
    $('#saveAssignRolesToEmps').click(function () {
        let arrEmpsId = [];

        for (let index = 0; index < comboTreePluginSelectedItems.length; index++) {
            const element = comboTreePluginSelectedItems[index];

            arrEmpsId.push(element.id);

        }
        let formIsValid = validateAssignRoleForm();
        if (formIsValid) {
            assignRoleToEmployees(arrEmpsId, arrayRoleIdsForAssign);
        }

    });

});


function BuilArrayMemberForAssignRole(memberRows) {
    let arrayMembers = [];

    if (memberRows !== null) {
        for (let index = 0; index < memberRows.length; index++) {
            const element = memberRows[index];

            let mObject = {};
            mObject.id = element.id;

            if (element.fullName != null && element.fullName != undefined) {
                mObject.title = element.fullName;

                if (element.email !== null) {
                    mObject.title = mObject.title + " (" + element.email + ")";
                }
            }
            else {
                mObject.title = element.Email;
            }
           

            arrayMembers.push(mObject);

        }
    }

    return arrayMembers;
}


function getAllRolesForAssign() {
    var url = DOMAIN + "Admin/UserRole/GetJsonAllRole";
    $.ajax(
        {
            url: url,
            type: "GET",
            data: JSON.stringify({}),
            contentType: "application/json",
            dataType: 'json',
            success: function (result) {

                let trOfTable = "";
                for (let index = 0; index < result.data.length; index++) {
                    const element = result.data[index];

                    let stringCheckbox = builHtmlOfCheckboxForAssign(element, arrayRoleIdsForAssign);
                    stringCheckbox = "<td>" + stringCheckbox + "</td>"
                    trOfTable = trOfTable + stringCheckbox;

                    if ((index + 1) % 4 == 0) {
                        trOfTable = "<tr>" + trOfTable + "<tr/>";
                        $('#roles-assign').append(trOfTable);
                        trOfTable = "";
                    }
                    else {
                        if (index == result.data.length - 1) {
                            let div = (index + 1) % 4;
                            let del = 4 - div;

                            for (let j = 1; j <= del; j++) {
                                trOfTable = trOfTable + "<td></td>"
                            }

                            trOfTable = "<tr>" + trOfTable + "<tr/>";

                            $('#roles-assign').append(trOfTable);
                            trOfTable = "";

                        }
                        else {

                        }

                    }
                    // $('#roles-assign').append(stringCheckbox);
                }

            }, error: function (err) {
                console.log(err);
            }
        }
    );
}

var comboTree1 = undefined;


function displayMembers(result) {
    let arrMembers = BuilArrayMemberForAssignRole(result);
    comboTree1 = $('#members-id').comboTree({
        source: arrMembers,
        isMultiple: true,
        cascadeSelect: false

    });

}

function assignRoleToEmployees(arrEmpsId, arrRolesId) {
    var url = DOMAIN + "Admin/UserRole/AssignUserRole";
    var strArrayEmpIds = arrEmpsId.join(';');
    var strArrayRoleIds = arrRolesId.join(';');

    $.ajax(
        {
            url: url,
            type: "POST",

            data: JSON.stringify({
                UserIds: strArrayEmpIds,
                RoleNames: strArrayRoleIds              
            }),
            contentType: "application/json",      
            dataType: 'json',
            success: function (result) {
                console.log(result);

                //check permission:
                if (result == 'ACCESS_DENIED') {
                    var url = DOMAIN + "AdminError/Index";
                    window.location.replace(url);
                } else {
                    if (result.returnStatus == true) {
                        $('#modal-lg-assign-role').modal().hide();
                        resetAssignRoleForm();
                        window.location.reload(true);
                    }
                }                

            },
            error: function (err) {
                console.log(err);
            }
        }
    );
}

function validateAssignRoleForm() {
    let spanTagError = `<span class="error">{0}</span> <br/>`;
    let messageRequiredSelectEmployees = "Please selected employee!";
    let messageForRequiredSelectRole = "Please selected role!";
    let color = "red";

    let isValid = true;
    let flag = jQuery("#edit-flag").val();


    if (comboTreePluginSelectedItems.length == 0 && flag == "INSERT") {

        document.getElementById("msg-member").innerHTML = messageRequiredSelectEmployees;
        document.getElementById("msg-member").style.color = color;

        isValid = false;
    }
    else {
        document.getElementById("msg-member").innerHTML = "";
    }

    if (arrayRoleIdsForAssign.length == 0) {

        document.getElementById("msg-role").innerHTML = messageForRequiredSelectRole;
        document.getElementById("msg-role").style.color = color;

        isValid = false;
    }
    else {
        document.getElementById("msg-role").innerHTML = "";
    }

    return isValid;

}

$(document).ready(function () {
    $('#closeAssignModal').click(function () {
        // do something…
        resetAssignRoleForm();

    })
});


function resetAssignRoleForm() {
    arrayRoleIdsForAssign = [];
    comboTreePluginSelectedItems = [];
    document.getElementById("msg-member").innerHTML = "";
    document.getElementById("msg-role").innerHTML = "";

    let tagMembersId = `<input type="text" id="members-id" class="col-md-12" placeholder="Select" />`;

    $("#div-members").empty();
    $("#div-members").append(tagMembersId);
    // Reset table:
    $('#roles-assign').empty();
    jQuery("#edit-flag").val("--");
    jQuery("#closeAssignModal").show();
    jQuery("#saveAssignRolesToEmps").show();

}


function builHtmlOfCheckboxForAssign(item, arrayRoleIdsForAssign) {
    var htmlCheckbox = "";

    if (arrayRoleIdsForAssign.indexOf(item.name) > -1) {
        htmlCheckbox = `<label style="font-weight:normal;" class="checkbox-inline new-select">
          <input  type="checkbox" class="checkbox-assign" id = "{0}" value="{1}" checked = "checked"> <span> {2}</span></label> &nbsp; &nbsp;`;
    }
    else {
        htmlCheckbox = `<label style="font-weight:normal;" class="checkbox-inline new-select">
          <input  type="checkbox" class="checkbox-assign" id = "{0}" value="{1}"> <span> {2}</span></label> &nbsp; &nbsp;`;

    }

    htmlCheckbox = htmlCheckbox.replace("{0}", item.name);
    htmlCheckbox = htmlCheckbox.replace("{1}", item.name);
    htmlCheckbox = htmlCheckbox.replace("{2}", item.name);

    return htmlCheckbox;

}

$(document).ready(function () {

    getRolesWhenSelectCheckboxForAssign();


});

function getRolesWhenSelectCheckboxForAssign() {
    $(document).on("change", "input[class='checkbox-assign']", function () {
        // alert("FECK");

        if (this.checked) {
            console.log("checked role: " + this.value);
            arrayRoleIdsForAssign = addOrRemoveElementInArrayRoles(arrayRoleIdsForAssign, this.value, true);
        }
        else {
            console.log("unchecked role: " + this.value);
            arrayRoleIdsForAssign = addOrRemoveElementInArrayRoles(arrayRoleIdsForAssign, this.value, false);
        }

        let strRoles = arrayRoleIdsForAssign.join(",");

        $("#roles").val(strRoles);
        console.log($("#roles").val());
      
        if (arrayRoleIdsForAssign.length > 0) {

            document.getElementById("msg-role").innerHTML = "";

        }


    });
}

function addOrRemoveElementInArrayRoles(arrayRoleIdsForAssign, roleId, isAdd) {
    var isInclude = false;

    for (let index = 0; index < arrayRoleIdsForAssign.length; index++) {
        const element = arrayRoleIdsForAssign[index];

        if (element == roleId && isAdd == false) {
            arrayRoleIdsForAssign.splice(index, 1);
            index--;
        }
        if (element == roleId && isAdd == true) {
            isInclude = true;
        }

    }

    if (isInclude == false && isAdd == true) {
        arrayRoleIdsForAssign.push(roleId);
    }

    return arrayRoleIdsForAssign;
}

$(document).ready(function () {
    $('#modal-lg-assign-role').on('hidden.bs.modal', function () {
        // do something…
        console.log('cloase assign role modal');
        resetAssignRoleForm();
    })
});


jQuery(document).ready(function () {
    

});


function showDetailsForm(userId) {

    jQuery("#modal-lg-assign-role").modal();
    jQuery("#edit-flag").val("--");
    jQuery("#modal-title-id").html("Details user roles");
    jQuery("#roles-assign").prop('disabled', true);

    jQuery("#closeAssignModal").hide();
    jQuery("#saveAssignRolesToEmps").hide();

    getUserById(userId);

}

function deleteUserRole(userId, roleName) {
    console.log("deleting user role");
    var r = confirm("Your are delete user role selected ?");
    if (r == true) {
        var url = DOMAIN + "Admin/UserRole/Delete";

        jQuery.ajax({
            url: url,
            type: "POST",
            dataType: "json",
            data: JSON.stringify({
                UserIds: userId,
                RoleNames: roleName,
            }),
            contentType: "application/json",
            success: function (data) {
                console.log(data);
                //check permission:
                if (data == 'ACCESS_DENIED') {
                    var url = DOMAIN + "AdminError/Index";
                    window.location.replace(url);
                } else {
                    window.location.reload();
                }              
               
            },
            error: function (data) {
                console.log(data);
            }
        });
    } else {

    }
}

function getUserById(userId) {
    var url = DOMAIN + "Admin/UserRole/GetById";

    jQuery.ajax({
        url: url,
        type: "GET",
        dataType: "json",
        data: { Id: userId },
        contentType: "application/json",

        success: function (data) {
            console.log(data);
            jQuery("#members-id").val(data.resultObj.userName);
            jQuery("#members-id").prop('disabled', true);

            getAllRoleOfUserByUserId(userId);
           
        },
        error: function (data) {
            console.log(data);
        }
    });
}

function showEditForm(userId) {

    jQuery("#modal-lg-assign-role").modal();
    jQuery("#edit-flag").val("EDIT");   
    jQuery("#modal-title-id").html("Edit user roles");

    getUserById(userId);

}

function getAllRoleOfUserByUserId(userId) {
    var url = DOMAIN + "Admin/UserRole/GetJsonAllRoleOfUserByUserId";

    jQuery.ajax({
        url: url,
        type: "GET",
        dataType: "json",
        data: { userId: userId },
        contentType: "application/json",

        success: function (data) {
            console.log(data.data);

            for (var i = 0; i < data.data.length; i++) {
                arrayRoleIdsForAssign.push(data.data[i].name);
            }
            let user = {};
            user.id = userId;
            comboTreePluginSelectedItems.push(user);

            getAllRolesForAssign();
           

        },
        error: function (data) {
            console.log(data.data);
        }
    });
}



