var cluster = document.getElementById("cluster");
if (cluster) {
    var ctx = cluster.getContext('2d');

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
                    fontColor: '#333333'
                }
            },
            animation: {
                duration: 0 // general animation time
            },
            hover: {
                animationDuration: 0 // duration of animations when hovering an item
            },
            responsiveAnimationDuration: 0 // animation duration after a resize
        }
    });
}