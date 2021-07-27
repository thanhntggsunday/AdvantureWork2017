var dataTable = {};

jQuery(document).ready(function () {
    console.log("This is user.js");

    //jQuery("#btnAddEmp").click(function () {
    //    jQuery("#user_modal").modal();
    //    jQuery("#edit-flag").val("INSERT");
    //});

    //jQuery("#user_modal").on("hidden.bs.modal", function () {
    //    // do something…
    //    reset_form_value();

    //    jQuery('.userform span.error-inline').remove();
    //    jQuery('.userform input').removeClass("is-invalid");
    //});

    jQuery("#btnAddEmp").click(function () {
        var url = '/Admin/Users/Create';

        window.location.replace(url);
    });

    jQuery("#user_modal").on("hidden.bs.modal", function () {
        // do something…
        reset_form_value();

        jQuery('.userform span.error-inline').remove();
        jQuery('.userform input').removeClass("is-invalid");
    });


});

function showEditForm(userId) {

    //jQuery("#user_modal").modal();
    //jQuery("#edit-flag").val("EDIT");

    //getUserById(userId);

    var url = '/Admin/Users/Edit?userId=' + userId;

    window.location.replace(url);

}


$(document).ready(function () {
    //---$('#reservation').val("");
    var urlGetPaging = DOMAIN + 'Admin/Users/GetAllPaging';

    dataTable = $('#tbl_users').DataTable({
        "processing": true,
        "serverSide": true,
        "paging": true,
        "pageLength": 5,
        "lengthMenu": [[5, 10, 20, 50, 500], [5, 10, 20, 50, 500]],
        'searching': true,
        "ordering": false,
        "info": true,
        "autoWidth": false,
        "responsive": true,
        "ajax": {
            "url": urlGetPaging,
            "type": "GET",
            'data': function (data) {

            },
            "dataSrc": function (json) {
                json.draw = json.draw;
                json.recordsTotal = json.recordsTotal;
                json.recordsFiltered = json.recordsFiltered;

                // Reset allEmpIdArrayOnPage:
                allEmpIdArrayOnPage = [];
                empIdArraySelected = [];

                if (json.data != null && json.data != undefined) {

                    for (var i = 0, ien = json.data.length; i < ien; i++) {
                        let edit = "<button class='btn-edit-emp' onclick=\"showEditForm('" + json.data[i].id + "')\">" + "Edit" + "</button>";
                        let editEmployeeRole = "<button class='btn-edit-erole' onclick=\"deleteUser('" + json.data[i].id + "')\">" + "Delete" + "</button>";
                        json.data[i].edit = edit + " " + editEmployeeRole;

                        let cssIcon = "";
                        //image
                        if (json.data[i].avatar == "" || json.data[i].avatar == undefined || json.data[i].avatar == null) {
                            json.data[i].avatar = "/admin/img/no-img.jpg";
                        }
                        let ImageUrl = `<img alt = 'No photo'  src="` + json.data[i].avatar + `" height = '50px' width = '50px' alt = 'error' />`;
                        json.data[i].avatar = ImageUrl;

                        // link to display detail employee:
                        if (json.data[i].fullName == null) {
                            json.data[i].fullName = "";
                        }
                        let employeeDetail = `<a href='#' onclick="showDetailsForm('` + json.data[i].id + `')">` + json.data[i].fullName + `</a>`
                        json.data[i].fullName = employeeDetail;

                    }
                }

                return json.data;
            }
        },
        "columns":
            [
                {
                    "title": "Avatar", "data": "avatar", "orderable": false
                },

                {
                    "title": "Full-name", "data": "fullName", "orderable": false
                },
                {

                    "title": "Email", "data": "email", "orderable": false
                },
                {

                    "title": "Action", "data": "edit", "orderable": false
                }

            ]

    });

});




function deleteUser(userId) {
    console.log("deleting user");
    var r = confirm("Your are delete user selected ?");
    if (r == true) {
        var url = DOMAIN + "Admin/Users/Delete";

        jQuery.ajax({
            url: url,
            type: "POST", 
            dataType: "json",   
            data: { Id: userId },                  
            success: function (data) {
                console.log(data);
                // Update for check permission:
                if (data.Data == 'ACCESS_DENIED') {
                    var url = DOMAIN + "AdminError/Index";
                    window.location.replace(url);
                }
                else {
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

function showDetailsForm(userId) {

    jQuery("#user_modal").modal();
    jQuery("#edit-flag").val("EDIT");
    jQuery("input").prop('disabled', true);

    getUserById(userId);

}

function getUserById(userId) {
    var url = DOMAIN + "Admin/Users/GetById";

    jQuery.ajax({
        url: url,
        type: "GET",
        dataType: "json",
        data: { Id: userId },
        contentType: "application/json",

        success: function (data) {
            console.log(data);
            // Update for check permission:
            if (data.Data == 'ACCESS_DENIED') {
                var url = DOMAIN + "AdminError/Index";
                window.location.replace(url);
            }
            else {
                jQuery("#user_modal").modal();
                set_form_value(data);
            }


        },
        error: function (data) {
            console.log(data);
        }
    });
}
