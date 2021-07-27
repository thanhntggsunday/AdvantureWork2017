var dataTable = {};

jQuery(document).ready(function () {
    console.log("This is role.js");

    jQuery("#btnAddRole").click(function () {
        jQuery("#role_modal").modal();
        jQuery("#edit-flag").val("INSERT");
    });

    jQuery("#role_modal").on("hidden.bs.modal", function () {
        // do something…
        reset_form_value();

        jQuery('.roleform span.error-inline').remove();
        jQuery('.roleform input').removeClass("is-invalid");
    });

});

function save_user() {
    var is_edit = jQuery("#edit-flag").val();
    if (is_edit == "EDIT") {
        var url = DOMAIN + "Admin/Roles/Edit";
        var user = get_form_value();

        jQuery.ajax({
            url: url,
            method: "POST",
            dataType: "json",
            data: user,
            success: function (data) {
                console.log(data);
                // Update for check permission:
                if (data == 'ACCESS_DENIED') {
                    var url = DOMAIN + "AdminError/Index";
                    window.location.replace(url);
                }
                else {
                    reset_form_value();
                    window.location.reload();
                }


            },
            error: function (data) {
                console.log(data);
            }
        });
    } else {
        var url = DOMAIN + "Admin/Roles/Create";
        var user = get_form_value();

        if (user.Id == null || user.Id == undefined || user.Id == '') {
            user.Id = 0;
        }

        jQuery.ajax({
            url: url,
            method: "POST",
            dataType: "json",
            data: user,
            success: function (data) {
                console.log(data);
                // Update for check permission:
                if (data == 'ACCESS_DENIED') {
                    var url = DOMAIN + "AdminError/Index";
                    window.location.replace(url);
                }
                else {
                    reset_form_value();
                    window.location.reload();
                }


            },
            error: function (data) {
                console.log(data);
            }
        });
    }
}

function get_form_value() {
    var appRole = {};

    appRole.Id = jQuery("#id").val();
    appRole.Name = jQuery("#name").val();
    appRole.Description = jQuery("#description").val();

    return appRole;
}

function reset_form_value() {

    jQuery("input").prop('disabled', false);
    jQuery("#id").val('');
    jQuery("#name").val('');
    jQuery("#description").val('');

    jQuery("#edit-flag").val("--");
}

function set_form_value(object_value) {

    jQuery("#id").val(object_value.id);
    jQuery("#name").val(object_value.name);
    jQuery("#description").val(object_value.description);

    jQuery("#edit-flag").val("EDIT");
}

jQuery(document).ready(function () {
    jQuery(".roleform").validate({
        rules: {
            full_name: {
                required: true,
            },

            email: {
                required: true,
            }
        },

        messages: {
            name: {
                required: "Please enter Name.",
            },

            description: {
                required: "Please enter Description.",
            }

        },
        errorElement: "span",
        errorClass: "error-inline",
        errorPlacement: function (error, element) {
            error.addClass("invalid-feedback");
            element.closest(".form-group").append(error);
        },
        highlight: function (element, errorClass, validClass) {
            jQuery(element).addClass("is-invalid");
        },
        unhighlight: function (element, errorClass, validClass) {
            jQuery(element).removeClass("is-invalid");
        },
        //Submit Handler Function
        submitHandler: function (form) {
            save_user();
        },
    });
});



$(document).ready(function () {
    //---$('#reservation').val("");
    var urlGetPaging = DOMAIN + 'Admin/Roles/GetAllPaging';

    dataTable = $('#tbl_roles').DataTable({
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
                        let deleteRole = "<button class='btn-edit-erole' onclick=\"deleteRole('" + json.data[i].id + "')\">" + "Delete" + "</button>";
                        json.data[i].edit = edit + " " + deleteRole;

                        let cssIcon = "";

                        // link to display detail employee:
                        if (json.data[i].Name == null) {
                            json.data[i].Name = "";
                        }
                        let employeeDetail = `<a href='#' onclick="showDetailsForm('` + json.data[i].id + `')">` + json.data[i].name + `</a>`
                        json.data[i].name = employeeDetail;


                        if (json.data[i].description == null) {
                            json.data[i].description = "";
                        }

                    }
                }

                return json.data;
            }
        },
        "columns":
            [

                {
                    "title": "Name", "data": "name", "orderable": false
                },
                {

                    "title": "Description", "data": "description", "orderable": false
                },
                {

                    "title": "Action", "data": "edit", "orderable": false
                }

            ]

    });

});


function showEditForm(id) {

    jQuery("#role_modal").modal();
    jQuery("#edit-flag").val("EDIT");

    getRoleById(id);

}

function showDetailsForm(id) {

    jQuery("#role_modal").modal();
    jQuery("#edit-flag").val("EDIT");
    jQuery("input").prop('disabled', true);

    getRoleById(id);

}

function deleteRole(id) {
    console.log("deleting user");
    var r = confirm("Your are delete user selected ?");
    if (r == true) {
        var url = DOMAIN + "Admin/Roles/Delete";

        jQuery.ajax({
            url: url,
            type: "GET",
            dataType: "json",
            data: { Id: id },
            contentType: "application/json",
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

function getRoleById(id) {
    var url = DOMAIN + "Admin/Roles/GetById";

    jQuery.ajax({
        url: url,
        type: "GET",
        dataType: "json",
        data: { Id: id },
        contentType: "application/json",

        success: function (data) {
            console.log(data);
            jQuery("#role_modal").modal();
            set_form_value(data.resultObj);
        },
        error: function (data) {
            console.log(data);
        }
    });
}

