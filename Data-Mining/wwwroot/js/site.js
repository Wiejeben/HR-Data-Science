var ctx = document.getElementById("myChart").getContext('2d');

var scatterChart = new Chart(ctx, {
    type: 'scatter',
    data: {
        datasets: window.datasets
    },
    options: {
        scales: {
            xAxes: [{
                type: 'linear',
                position: 'bottom'
            }]
        },
        legend: {
            labels: {
                fontSize: 20,
            }
        },
        animation: {
            duration: 0
        }
    }
});