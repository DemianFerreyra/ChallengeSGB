$(document).ready(function () {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        url: "http://localhost:5243/encuestas/promedy?json=true",
        error: function () {
            alert("Ocurrio un error a la hora de mostrar los datos requeridos");
        },
        success: function (data) {
            DrawMovies(GetData(data));
        }
    })
});

function DrawMovies(data) {
    console.log(data);
    Highcharts.chart('perPeriodContainer', {
        chart: {
            type: 'line'
        },
        title: {
            text: 'Promedio de peliculas vistas por periodo'
        },
        xAxis: {
            categories: data.periods.map(data => data.period)
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
            data: data.periods.map(period => period.data)
        }]
    });

    Highcharts.chart('perAgeContainer', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: 'Browser market shares in March, 2022',
            align: 'left'
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        accessibility: {
            point: {
                valueSuffix: '%'
            }
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: false
                },
                showInLegend: true
            }
        },
        series: [{
            name: 'Brands',
            colorByPoint: true,
            data: [{
                name: 'Chrome',
                y: 74.77,
                sliced: true,
                selected: true
            }, {
                name: 'Edge',
                y: 12.82
            }, {
                name: 'Firefox',
                y: 4.63
            }, {
                name: 'Safari',
                y: 2.44
            }, {
                name: 'Internet Explorer',
                y: 2.02
            }, {
                name: 'Other',
                y: 3.28
            }]
        }]
    });

}

function GetData(data) {
    console.log(data);
    let periods = [];
    let byAge = [];
    data.moviesPerPeriod.forEach(data => {
        console.log(data);
        if (periods.find(period => period.period == data.period)) {
            periods.find(period => period.period == data.period).data += data.moviesPerPeriod.moviesSeen;
        }
        else {
            periods.push(
                {
                    "period": data.period,
                    "data": data.moviesSeen
                }
            )
        }
    })
    return {
        "periods": periods
    };
}