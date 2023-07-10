$(document).ready(function () {
    $(window).on('beforeunload', function () {
        $('#Loader').show();
    });

    $('#Loader').hide();
    $(window).bind("pageshow", function (event) {
        $('#Loader').hide();
    });

    $('body').on('click', '.actionlink', function (e) {
        e.preventDefault();
        var Url = $(this).attr('href');
        var Parent = $(this).attr('Parent');
        var Perview = $(this).attr('Perview');
        var Func = $(this).attr('Func');
        Loading();
        LoadUrl(Url, Parent, Perview, Func);
    });


    $('body').on('submit', 'form.ajaxForm', function (e) {
        e.preventDefault();
        $(this).submit(function (e) {
            var form = $(this);
            var Func = form.attr('Func');
            var Perview = form.attr('Perview');
            var FormParent = form.attr('Parent');
            var ResetForm = form.attr('Reset');
            if (!ResetForm) { ResetForm = true; } else { ResetForm = false; }
            form.ajaxSubmit({
                resetForm: ResetForm,
                beforeSend: function (formData, jqForm, options) {
                    Loading();
                },
                uploadProgress: function (event, position, total, percentComplete) {
                    Loading(percentComplete + '%');
                },
                complete: function (result) {
                    if (FormParent) {
                        if (Perview === 'Append') {
                            $(FormParent).append(result.responseText);
                        } else {
                            $(FormParent).html(result.responseText);
                        }
                    }

                    if (Func) {
                        eval(Func);
                    }

                    Loaded();
                }
            });
            return false;
        });
    });