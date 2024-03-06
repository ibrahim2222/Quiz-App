/*google.charts.load("current", { packages: ["corechart"] });
google.charts.setOnLoadCallback(drawChart);
function drawChart() {
    var data = google.visualization.arrayToDataTable([
        ['الإيـرادات', 'يـومي'],
        ['المصـروفـات', 1],
        ['الإيـرادات', 7]
    ]);

    var options = {

        is3D: true,
        width: 500,
        height: 300,
        fontSize: 15,
        direction: 'RTL'
    };

    var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));
    chart.draw(data, options);
}*/

let table = new DataTable("#table", {
    paging: true,
    scrollY: 400,
    ordering: true,
    select: true,
    autoWidth: true,
    searching: true,
    pageLength: 20,
    pagingTag: "button",
    pagingType: "simple_numbers",
});