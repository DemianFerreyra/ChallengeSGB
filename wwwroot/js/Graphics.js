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
    console.log(data.periods);
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

    //highchart por periodo y sexo
    console.log(data.byPeriodAndSex);
    Highcharts.chart('perPeriodAndSexContainer', {
        chart: {
            type: 'line'
        },
        title: {
            text: 'Promedio de peliculas vistas por periodo. Divididas segun el sexo de los usuarios'
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
        series: data.byPeriodAndSex.map(basedOnSex => basedOnSex)
    });
}

function GetData(data) {
    let periodsString = [];
    let periods = [];
    let byAge = [];
    let bySex = [];
    let periodsBasedOnSex = [];

    //conseguimos la informacion de cada periodo y su promedio
    data.moviesPerPeriod.forEach(byPeriodData => {
        periods.push(
            {
                "period": byPeriodData.period,
                "data": byPeriodData.moviesSeen
            }
        )
        periodsString.push(byPeriodData.period);
    })
    data.moviesByAge.forEach(byAgeData => byAge.push(["edad: " + byAgeData.reference, byAgeData.value]))
    data.moviesBySex.forEach(bySexData => bySex.push(["sexo: " + bySexData.reference, bySexData.value]))
    data.moviesPerPeriodAndSex.forEach(byPeriodAndSexData => {
        let newValues = [];
        byPeriodAndSexData.moviesPerPeriod.forEach(moviesPerPeriod => {
            newValues.push(moviesPerPeriod.moviesSeen)
        })
        periodsBasedOnSex.push({
            "name": byPeriodAndSexData.sex,
            "data": newValues
        })
    })

    return {
        "periods": periods,
        "byAge": byAge,
        "bySex": bySex,
        "byPeriodAndSex": periodsBasedOnSex
    };
}