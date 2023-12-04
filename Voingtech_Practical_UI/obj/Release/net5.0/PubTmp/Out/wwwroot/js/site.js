// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    var apiurl = "https://voingapi.azurewebsites.net/api/Registration/AddRegistration";
    //var apiurl = "https://localhost:44382/api/Registration/AddRegistration";

    $("#btnregister").unbind("click").click(function () {
        if ($('#registrationForm').valid()) {
            submit_registration();
        }
    });

    $("#btnclear").unbind("click").click(function () {
        clearform();
    });

    function submit_registration() {
        startLoading();
        var requestData = {
            FullName: $.trim($('#txtfullname').val()),
            Email: $.trim($('#txtemail').val()),
            Password: $.trim($('#txtpsw').val())
        };
        $.ajax({
            type: "POST",
            contentType: "application/json;",
            url: apiurl,
            async: true,
            data: JSON.stringify(requestData),
            success: function (data) {
                if (data) {
                    if (data) {
                        if (data.isSucceed) {
                            window.location.href = "/dashboard";
                        }
                        clearform();
                    }
                }
                endLoading();
            },
            error: function (result) {
                endLoading();
                console.log(result);
            }
        });
    }

    function clearform() {
        $("#txtfullname").val('');
        $("#txtemail").val('');
        $("#txtpsw").val('');
    }

    function startLoading() {
        $(".loader-img").show();
    }

    function endLoading() {
        $(".loader-img").hide();
    }
});