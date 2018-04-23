var ctx = document.getElementById("myChart").getContext('2d');

var scatterChart = new Chart(ctx, {
    type: 'scatter',
    data: {
        datasets: [{
            label: 'Cluster 1',
            backgroundColor: 'green',
            borderWidth: 0,
            pointRadius: 5,
            data: [{
                x: -10,
                y: 0,
            }, {
                x: 0,
                y: 10
            }, {
                x: 10,
                y: 5
            }]
        }, {
            label: 'Cluster 2',
            backgroundColor: 'red',
            borderWidth: 0,
            pointRadius: 5,
            data: [{
                x: 10,
                y: 20
            }, {
                x: 15,
                y: 10
            }]
        }]
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
        }
    }
});