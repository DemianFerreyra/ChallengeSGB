$(document).ready(function () {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: "http://localhost:5243/encuestas/promedy?json=true",
        error: function () {
            console.log("error");
            alert("Ocurrio un error a la hora de mostrar los datos requeridos");
        },
        success: function (data) {
            console.log(data);
            DrawMoviesPerPeriod(GetMoviesSeenPerPeriod(data));
        }
    })
});

function DrawMoviesPerPeriod(data) {
    Highcharts.chart('container', {
        chart: {
            type: 'line'
        },
        title: {
            text: 'Promedio de peliculas vistas por periodo'
        },
        xAxis: {
            categories: data.map(data => data.period)
        },
        yAxis: {
            title: {
                text: 'Peliculas vistas'
            }
        },
        plotOptions: {
            line: {
                dataLabels: {
                    enabled: true
                },
                enableMouseTracking: false
            }
        },
        series: [{
            name: 'Promedio de peliculas vistas',
            data: data.map(period => period.data)
        }]
    });
}

function GetMoviesSeenPerPeriod(data) {
    let periods = [];
    data.forEach(data => {

        if (periods.find(period => period.period == data.periodo)) {
            periods.find(period => period.period == data.periodo).data += data.cantidadPeliculas;
        }
        else {
            periods.push(
                {
                    "period": data.periodo,
                    "data": data.cantidadPeliculas
                }
            )
        }
    })
    return periods;
}