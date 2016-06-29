/// <reference path="bootstrap.js" />
/// <reference path="bootstrap.min.js" />
/// <reference path="jquery-1.10.2.intellisense.js" />
/// <reference path="jquery-1.10.2.js" />
/// <reference path="jquery-1.10.2.min.js" />
/// <reference path="jquery-1.9.1.intellisense.js" />
/// <reference path="jquery-1.9.1.js" />
/// <reference path="jquery-1.9.1.min.js" />
/// <reference path="modernizr-2.6.2.js" />

$(document).ready(addEventFormInit);


function addEventFormInit() {
    $('#ajax_addEvent').submit(onFormSubmit)
}

function onFormSubmit(event) {
    console.log("BEGIN AJAX");

    var formData = {
        'notificationEvent': $('#NotificationEvent').val(),
        'notificationEnable': $('#NotificationEnable').val()
    };

    $.ajax({
        type: 'POST',
        url: $('#ajax_addEvent').attr('action'),
        data: formData,
        dataType: 'html'
    })
    .done(onAjaxDone);

    console.log("SENT AJAX");
    confirm.log(formData);

    event.preventDefault();
}

function onAjaxDone(data)
{
    var content = '<div class="alert alert-success"><strong>Success!</strong> Indicates a successful or positive action.</div>';
    $("#ajax_addEvent").before(content);
    console.log("FINISH AJAX");
}