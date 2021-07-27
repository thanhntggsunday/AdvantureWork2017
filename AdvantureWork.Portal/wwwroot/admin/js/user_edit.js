jQuery(document).ready(function () {
    var userId = jQuery('#user-id').data('value-id');

    getUserById(userId);

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
                    set_form_value(data.resultObj);
                }

               
            },
            error: function (data) {
                console.log(data);
            }
        });
    }


});

