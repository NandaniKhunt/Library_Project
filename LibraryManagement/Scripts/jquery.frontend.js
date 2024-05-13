$(document).on("click", ".pager-link a", function (e) {
    e.preventDefault();
    //e.stopPropagation();
    var form = $($(this).closest("form"));
    var action = $(this).attr("href");
    var thisObject = $(this);
    if (action != "#" && action != null && action != undefined && action.trim() != "") {
        var target = $(this).closest(".target-load");
        console.log(target);
        $.ajax({
            url: action,
            type: "POST",
            data: form.serialize() + "&page=" + thisObject.attr("data-page") + "&sortby=" + thisObject.attr("table-sortby") + "&pagerow=" + thisObject.attr("item-page"),
            cache: false,
            beforeSend: function () {
                ShowLoadingPanel();
            },
            success: function (data) {
                $(target).html(data);
                $.validator.unobtrusive.parse("form");
                $('html,body').animate({ scrollTop: 0 }, 'slow');
            },
            complete: function () {
                HideLoadingPanel()
            },
            error: function () {
                HideLoadingPanel()
            }
        })
    }
});

$("form").submit(function (e) {
    e.preventDefault();
    var form = $(this);
    var action = form.attr("action");
    if (action != "#" && action != null && action != undefined && action.trim() != "") {
        var target = $(this).attr("target-id");
        $.ajax({
            url: action,
            type: "POST",
            data: form.serialize(),
            cache: false,
            beforeSend: function () {
                ShowLoadingPanel();
            },
            success: function (data) {
                $(target).html(data);
                $.validator.unobtrusive.parse("form");
                HideLoadingPanel();
            },
            complete: function () {
                // $(target).RemoveLoader();
            },
            error: function () {
                HideLoadingPanel();
            }
        })
    }
});
function ShowLoadingPanel() {
    $("#modal-loading").css("display", "block");
    $("#pre-loader").css("display", "block");
}
function HideLoadingPanel() {
    $("#modal-loading").css("display", "none");
    $("#pre-loader").css("display", "none");
}