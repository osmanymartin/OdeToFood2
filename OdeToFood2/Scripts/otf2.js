
$(function () {

    var ajaxFormSubmit = function () {
        $form = $(this);

        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize()
        }

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-otf2-target"));
            $target.replaceWith(data);
        });

        return false;
    };



    $("form[data-otf2-ajax='true']").submit(ajaxFormSubmit);

});