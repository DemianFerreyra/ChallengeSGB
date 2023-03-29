function GetMoviesSeenPerPeriod(data) {
    let periods = [];
    data.forEach(data => {

        if (periods.Find(period => period.period == data.periodo)) {
            periods.Find(period => period.period == data.periodo).data += data.cantidadPeliculas;
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

    console.log(periods);
    return periods;
}
export { GetMoviesSeenPerPeriod };