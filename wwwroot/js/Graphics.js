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
    //highchart por periodo
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

    //highchart por edad
    Highcharts.chart('perAgeContainer', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Promedio de peliculas vistas segun edad'
        },
        xAxis: {
            type: 'category',
            labels: {
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Promedio'
            }
        },
        legend: {
            enabled: false
        },
        series: [{
            name: 'Series vistas',
            data: data.byAge.map(data => data),
            dataLabels: {
                enabled: true,
                rotation: -90,
                color: '#FFFFFF',
                align: 'right',
                format: '{point.y:.1f}', // one decimal
                y: 10, // 10 pixels down from the top
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        }]
    });

    //highchart por sexo
    Highcharts.chart('perSexContainer', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Promedio de peliculas vistas segun el genero del usuario'
        },
        xAxis: {
            type: 'category',
            labels: {
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Promedio'
            }
        },
        legend: {
            enabled: false
        },
        series: [{
            name: 'Series vistas',
            data: data.bySex.map(data => data),
            dataLabels: {
                enabled: true,
                rotation: -90,
                color: '#FFFFFF',
                align: 'right',
                format: '{point.y:.1f}', // one decimal
                y: 10, // 10 pixels down from the top
                style: {
                    fontSize: '13px',
                    fontFamily: 'Verdana, sans-serif'
                }
            }
        }]
    });

}

function GetData(data) {
    console.log(data);
    let periods = [];
    let byAge = [];
    let bySex = [];

    //conseguimos la informacion de cada periodo y su promedio
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
    data.moviesByAge.forEach(data => byAge.push(["edad: " + data.reference, data.value]))
    data.moviesBySex.forEach(data => bySex.push(["sexo: " + data.reference, data.value]))

    return {
        "periods": periods,
        "byAge": byAge,
        "bySex": bySex
    };
}