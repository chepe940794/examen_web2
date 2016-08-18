$(document).on("ready", function() {

    $('#btnSearch').on('click', function() {
        GetFacturacionById($('#txtIdSearch').val());
    });

    $('#btnCreate').on('click', function() {
        var facturacion = new Object();
        facturacion.Id = $('#txtIdSearch').val();
        facturacion.MontoTotal = $('#txtMontoTotal').val();
        facturacion.SubTotal = $('#txtSubTotal').val();
        facturacion.Detalle = $('#txtDetalle').val();
        CreateFacturacion(JSON.stringify(facturacion));
    });

    GetAll();

});

function GetAll() {

    var item = "";
    $('#tblList tbody').html('');
    $.getJSON('/api/Facturas', function (data) {
        $.each(data, function (key, value) {
            item += "<tr><td>" + value.Id + "</td><td>" + value.MontoTotal + "</td><td>" + value.SubTotal + "</td><td>"
            + value.Detalle + "</td></tr>";
        });
        $('#tblList tbody').append(item);
    });
};

function GetFacturacionById(idFacturacion) {
    var url = '/api/Inventarios/' + idFacturacion;
    $.getJSON(url)
        .done(function (data) {
            $('#txtId').val(data.Id);
            $('#txtMontoTotal').val(data.MontoTotal);
            $('#txtSubTotal').val(data.SubTotal);
            $('#txtDetalle').val(data.Detalle);
        })
        .fail(function (erro) {
            ClearForm();
        });
};


function CreateFacturacion(facturacion) {
    var url = '/api/Facturas/';
    $.ajax({
        url: url,
        type: 'POST',
        data: facturacion,
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            201: function () {
                GetAll();
                ClearForm();
                alert('Facturacion with id: ' + idFacturacion + ' fue actualizado');
            },
            400: function () {
                ClearForm();
                alert('Error');
            }
        }
    });
}