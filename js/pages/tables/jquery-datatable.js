/*$(document).ready(function () {
    $('#ContentPlaceHolder1_Table1').DataTable();

    $('#ContentPlaceHolder1_Table1').each(function () {
        var jTbl = $(this);
        if (jTbl.find("tbody>tr>th").length > 0) {
            jTbl.find("tbody").before("<thead><tr></tr></thead>");
            jTbl.find("thead:first tr").append(jTbl.find("th"));
            jTbl.find("tbody tr:first").remove();
        }
    });
    
});*/

$(function () {
    $('.js-basic-example').DataTable();

    //Exportable table
    $('.js-exportable').DataTable({
        dom: 'Bfrtip',
        buttons: [
            'copy', 'csv', 'excel', 'pdf', 'print'
        ]
    });
});

