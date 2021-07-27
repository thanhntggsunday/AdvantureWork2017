var dataTable = {};


$(document).ready(function () {
    //---$('#reservation').val("");
    var urlGetPaging = DOMAIN + 'Admin/Permissions/GetJsonPermissionAllPaging';

    dataTable = $('#tbl_permission').DataTable({
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
               
                // Reset allEmpIdArrayOnPage:
                allEmpIdArrayOnPage = [];
                empIdArraySelected = [];

                if (json.data != null && json.data != undefined) {
                    for (var i = 0, ien = json.data.length; i < ien; i++) {
                        let edit = "<button class='btn-edit' onclick=\"showEditForm('" + json.data[i].roleName + "')\">" + "Edit" + "</button>";
                        let editEmployeeRole = "<button class='btn-edit' onclick=\"deletePermission('" + json.data[i].roleName + "', '" + json.data[i].roleName + "')\">" + "Delete" + "</button>";
                        json.data[i].edit = edit + " " + editEmployeeRole;

                        let cssIcon = "";

                        // link to display detail employee:
                        if (json.data[i].roleName == null) {
                            json.data[i].roleName = "";
                        }
                        let roleName = `<a href='#'>` + json.data[i].roleName + `</a>`
                        json.data[i].roleName = roleName;

                    }
                }               

                return json.data;
            }
        },
        "columns":
            [

                {
                    "title": "RoleName", "data": "roleName", "orderable": false
                },
                {

                    "title": "FunctionId", "data": "functionId", "orderable": false
                },
                {

                    "title": "ActionId", "data": "actionId", "orderable": false
                }

            ]

    });

});


