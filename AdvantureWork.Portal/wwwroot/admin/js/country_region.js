jQuery(document).ready(function () {
    var currentPage = 1;
    // Paging
    jQuery(document).on('click', '.footerContent a', function (e) {
        e.preventDefault();
        var pageNo = parseInt(jQuery(this).data("value"));
        var countryName = jQuery('#txtCountryName').val();
        currentPage = pageNo;

        fetchData(currentPage, countryName);
    });

    jQuery(document).on('click', '#btnSearch', function (e) {
        e.preventDefault();
        var countryName = jQuery('#txtCountryName').val();
        fetchData(1, countryName);
    });

    //function DisplayLookup() {
    //    $('#mdLookup').modal('show');
    //    //Load data for page 1 first time
    //    fetchData(1);

    // };

    $('#showLookup').click(function () {
        $('#mdLookup').modal('show');
        //Load data for page 1 first time
        fetchData(1);
    });

    jQuery("#btnOkSelect").click(function () {
        getCountrySelected();
        jQuery("#mdLookup").modal('hide');

    });

    var jQueryloading = "<div id='divLoading' class='loading'>Please wait...</div>";

    //Fetch Data
    function fetchData(pageNo, countryName = "") {
        //Create loading panel
        var url = DOMAIN + 'Admin/Lookup/GetCountryRegion';
        // $('input[name="radioSelect"]:checked').val();
        // $('#tr-AF').find('td');

        // jQuery('#updatePanel').prepend(jQueryloading);


        //Ajax call for fetch data from WEB Api
        jQuery.ajax({
            url: url,
            type: 'GET',
            data: { PageNo: pageNo, CountryName: countryName },
            dataType: 'json',
            contentType: "application/json",
            success: function (data) {
                // generate html and Load data
                var jQuerytable = jQuery('<table/>').addClass('table table-responsive table-striped table-bordered col-md-12');
                var jQueryheader = jQuery('<thead/>').html('<tr><th class="col-md-1" style="background-color: Green;color: White">Name</th> <th class="col-md-4" style="background-color: Green;color: White">CountryRegionCode</th> <th class="col-md-4" style="background-color: Green;color: White">Select</th></tr>');
                jQuerytable.append(jQueryheader);

                var htmlArrTr = "<tr><td><b>Select</b></td> <td><b>Name</b></td> <td><b>CountryRegionCode</b></td> </tr>";

                //table  body
                jQuery.each(data.data, function (i, emp) {
                    var htmlTr = '<tr id="tr-{0}"/>';
                    htmlTr = htmlTr.replace('{0}', emp.countryRegionCode);

                    var jQueryrow = jQuery(htmlTr);
                    var htmlRadioButton = '<input type="radio" id="{0}" name="radioSelect" value="{1}">'
                    htmlRadioButton = htmlRadioButton.replace("{0}", emp.countryRegionCode);
                    htmlRadioButton = htmlRadioButton.replace("{1}", emp.countryRegionCode);

                    //jQueryrow.append(jQuery('<td/>').html(emp.Name).addClass('col-md-4'));                   
                    //jQueryrow.append(jQuery('<td/>').html(emp.CountryRegionCode).addClass('col-md-4'));  
                    //jQueryrow.append(jQuery('<td/>').html(htmlRadioButton).addClass('col-md-1'));

                    jQuerytable.append(jQueryrow);

                    var strRow = '<tr id="tr-{0}">';
                    strRow = strRow.replace('{0}', emp.countryRegionCode);
                    strRow = strRow + '<td>' + htmlRadioButton + '</td>' + '<td>' + emp.name + '</td>' + '<td>' + emp.countryRegionCode + '</td>' ;

                    htmlArrTr += strRow;
                });

                //table footer (for paging content)
                var totalPage = parseInt(data.pagesTotal);
                //var jQueryfooter = jQuery('<tr/>');
                //var jQueryfooterTD = jQuery('<td/>').attr('colspan', 2).addClass('footerContent');
                               
                var htmlaStyle = 'style="text-decoration:none" href="#"';
                var firstPage = '<a {0} data-value="{1}">&lt;&lt;&nbsp;First</a>';
                var prevPage = '<a {0} data-value="{1}">&lt;&lt;&nbsp;Prev</a>';
                var nextPage = '<a {0} data-value="{1}">Next&nbsp;&gt;</a>';
                var lastPage = '<a {0} data-value="{1}">Last&nbsp;&gt;&gt;</a>';

                if (pageNo > 1) {

                    firstPage = firstPage.replace("{0}", htmlaStyle);
                    prevPage = prevPage.replace("{0}", htmlaStyle);
                }
                else {
                    firstPage = '<label {0} data-value="{1}">&lt;&lt;&nbsp;First</label>';
                    prevPage = '<label {0} data-value="{1}">&lt;&nbsp;Prev</label>';

                    firstPage = firstPage.replace("{0}", "");
                    prevPage = prevPage.replace("{0}", "");
                }

                if (pageNo < totalPage) {
                    nextPage = nextPage.replace("{0}", htmlaStyle);
                    lastPage = lastPage.replace("{0}", htmlaStyle);
                }
                else {
                    nextPage = '<label {0} data-value="{1}">Next&nbsp;&gt;</label>';
                    lastPage = '<label {0} data-value="{1}">Last&nbsp;&gt;&gt;</label>';

                    nextPage = nextPage.replace("{0}", "");
                    lastPage = lastPage.replace("{0}", "");
                }

                firstPage = firstPage.replace("{1}", 1);
                prevPage = prevPage.replace("{1}", pageNo - 1);
                nextPage = nextPage.replace("{1}", pageNo + 1);
                lastPage = lastPage.replace("{1}", totalPage);

                jQuery('#divFirst').html(firstPage);
                jQuery('#divPrev').html(prevPage);
                jQuery('#divNext').html(nextPage);
                jQuery('#divLast').html(lastPage);

                jQuery('#currentPage').val(pageNo);
                jQuery('#lblTotalPage').html('/ ' + totalPage);

                // jQuery('#updatePanel').html(jQuerytable);

                jQuery('#tblData').html(htmlArrTr);
            },
            error: function (data) {
                console.log('Error! Please try again.');
            }
        }).done(function () {
            //remove loading panel after ajax call complete
            // jQueryloading.remove();
            $("#divLoading").remove();
        });
    }
});

function getCountrySelected() {
    try {
        var crId = jQuery('input[name="radioSelect"]:checked').val();
        var arrCells = jQuery('#tr-' + crId).find('td');
        // arrCells[0].innerText
        jQuery('#country').val(arrCells[1].innerHTML);
        jQuery('#country-region-code').val(arrCells[2].innerHTML);

        if (jQuery('#country-dis') != undefined && jQuery('#country-dis') != null) {
            jQuery('#country-dis').val(arrCells[1].innerHTML);
            jQuery('#country-region-code-dis').val(arrCells[2].innerHTML);
        }
    } catch (e) {
        console.log(e);
    }
   
}