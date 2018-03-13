// Write your JavaScript code.

$(document).ready(function() {

    // Wire up all of the checkboxes to run markCompleted()
    $('.done-checkbox').on('click', function(e) {
        markCompleted(e.target);
    });

    // Wire up the Add button to send the new item to the server
    $('#add-item-button').on('click', addItem);
});
    
function markCompleted(checkbox) {
    checkbox.disabled = true;

    $.post('/Pendiente/MarcarHecho', { id: checkbox.name }, function() {
        var row = checkbox.parentElement.parentElement;
        $(row).addClass('done');
    });
}

function addItem() {
    $('#add-item-error').hide();
    var nuevoPendiente = $('#add-item-title').val();

    $.post('/Pendiente/Agregar', { Pendiente: nuevoPendiente }, function() {
        window.location = '/Pendiente';
    })
    .fail(function(data) {
        if (data && data.responseJSON) {
            var firstError = data.responseJSON[Object.keys(data.responseJSON)[0]];
            $('#add-item-error').text(firstError);
            $('#add-item-error').show();
        }
    });
}
