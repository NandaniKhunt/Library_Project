//$(document).on("change", "#currentpagenumber", function (e) {

//    e.preventDefault();
//    var action = $(this).attr("data-url");
//    var thisObject = $(this);
//    if (parseInt(thisObject.val()) > parseInt(thisObject.attr("total-page"))) {
//        $(this).addClass('pagination-box-red');
//    }
//    else {
//        if (action != "#" && action != null && action != undefined && action.trim() != "") {
//            var form = $($(this).closest("form"));
//            var target = $(this).closest(".table-target");
//            $.ajax({
//                url: action,
//                type: "POST",
//                data: form.serialize() + "&page=" + thisObject.val() + "&sortby=" + thisObject.attr("table-sortby") + "&pagerow=" + thisObject.attr("item-page"),
//                cache: false,
//                beforeSend: function () {

//                },
//                success: function (data) {
//                    $(target).html(data);
//                    $.validator.unobtrusive.parse("form");
//                },
//                complete: function () {
//                    // $(target).RemoveLoader();
//                },
//                error: function () {
//                    // $(target).RemoveLoader();
//                }
//            })
//        }
//    }
//});
$(document).on("click", "#btnSearch", function (e) {
    e.preventDefault();
    var form = $($(this).closest("form"));
    var action = $(this).attr("action-url");
    if (action != "#" && action != null && action != undefined && action.trim() != "") {
        var target = $(this).attr("target-id");
        $.ajax({
            url: action,
            type: "POST",
            data: form.serialize(),
            cache: false,
            beforeSend: function () {

            },
            success: function (data) {
                $(target).html(data);
                $.validator.unobtrusive.parse("form");
            },
            complete: function () {
                // $(target).RemoveLoader();
            },
            error: function () {
                // $(target).RemoveLoader();
            }
        })
    }
});
$(document).on("change", "#AllChecked", function (e) {
    e.preventDefault();
    if ($(this).prop('checked'))
        $('.custom-checked-change').prop('checked', true);
    else
        $('.custom-checked-change').prop('checked', false);
});
$(document).on("change", ".custom-checked-change", function (e) {
    e.preventDefault();
    $('#AllChecked').prop('checked', false);
});
$(document).on("click", ".pager-link a", function (e) {
    e.preventDefault();
    //e.stopPropagation();
    var form = $($(this).closest("form"));
    var action = $(this).attr("href");
    var thisObject = $(this);
    if (action != "#" && action != null && action != undefined && action.trim() != "") {
        var target = $(this).closest(".master-pager").parent().find(".table").attr("target");
        $.ajax({
            url: action,
            type: "POST",
            data: form.serialize() + "&page=" + thisObject.attr("data-page") + "&sortby=" + thisObject.attr("table-sortby") + "&pagerow=" + thisObject.attr("item-page"),
            cache: false,
            beforeSend: function () {

            },
            success: function (data) {
                $(target).html(data);
                $.validator.unobtrusive.parse("form");
            },
            complete: function () {
                // $(target).RemoveLoader();
            },
            error: function () {
                // $(target).RemoveLoader();
            }
        })
    }
})

$(document).on("click", ".custom-sorting", function (e) {
    e.preventDefault();
    var action = $(this).attr("data-url");
    if (action != "#" && action != null && action != undefined && action.trim() != "") {
        var form = $($(this).closest("form"));
        var target = $(this).closest("table").attr("target");
        $.ajax({
            url: action,
            type: "POST",
            data: form.serialize() + "&sortby=" + $(this).attr("data-sortby") + " " + $(this).attr("aria-sort") + "&pagerow=" + $(this).attr("item-page"),
            cache: false,
            beforeSend: function () {

            },
            success: function (data) {
                $(target).html(data);

            },
            complete: function () {
                // $(target).RemoveLoader();
            },
            error: function () {
                // $(target).RemoveLoader();
            }
        })
    }
});
$(document).on("click", ".btn-delete", function (e) {
    e.preventDefault();
    var delelemodal = $("#confimation-modal");
    delelemodal.modal("show");
    delelemodal.find(".modal-title").html("Confirm");
    delelemodal.find(".modal-body").html('<p><strong>Are you sure want to delete?</strong></p>');
    delelemodal.find(".btnlink").attr("href",$(this).attr("href"));
});
String.prototype.replaceAll = function (str1, str2, ignore) {
    return this.replace(new RegExp(str1.replace(/([\/\,\!\\\^\$\{\}\[\]\(\)\.\*\+\?\|\<\>\-\&])/g, "\\$&"), (ignore ? "gi" : "g")), (typeof (str2) == "string") ? str2.replace(/\$/g, "$$$$") : str2);
};
$.fn.CenterLoader = function () {
    var height = $(this).outerHeight() + "px";
    var width = $(this).outerWidth() + "px";
    var top = $(this).offset().top + "px";
    var left = $(this).offset().left + "px";
    var centerTop = Math.max(0, $(this).outerHeight() / 2) + "px";
    var centerLeft = Math.max(0, $(this).outerWidth() / 2) + "px";
    var loadingContain = "<div style='position:absolute;height:" + height + ";width:" + width + ";background:#ccc;z-index:10;top:" + top + ";left:" + left + ";opacity:0.7' id='loader-image'><div style='position:absolute;top:" + centerTop + ";left:" + centerLeft + ";color:white;height: 28px;width: 28px;' class='loader-style'></div></div>";
    $("body").append(loadingContain);
}
$.fn.RemoveLoader = function () {
    $("#loader-image").remove();
}

$.fn.RefreshCenter = function () {
    var height = $(this).outerHeight() + "px";
    var width = $(this).outerWidth() + "px";
    var top = $(this).offset().top + "px";
    var left = $(this).offset().left + "px";
    var centerTop = Math.max(0, $(this).outerHeight() / 2) + "px";
    var centerLeft = Math.max(0, $(this).outerWidth() / 2) + "px";
    var loadingContain = "<div style='position:absolute;height:" + height + ";width:" + width + ";background:#ccc;z-index:100;top:" + top + ";left:" + left + ";opacity:0.7' id='refresh-image'><div style='position:absolute;top:" + centerTop + ";left:" + centerLeft + ";color:white;height: 28px;width: 28px;' class='loader-style'><button class='btn btn-info btn-circle' type='button' id='btnrefresh'><i class='fa fa-refresh'></i></button></div></div>";
    $("body").append(loadingContain);
}

$(document).on("click", "#btnrefresh", function (e) {
    window.location.href = window.location.href;
});