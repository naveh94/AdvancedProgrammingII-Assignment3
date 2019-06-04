
// Struct for Point
function point(x, y) {
    this.x = x;
    this.y = y;
}

// Points array for holding the points we already recieved.
var points = [];

// Setting the canvas.
var canv = document.getElementById("mapCanvas"),
    ctx = canv.getContext("2d");

// Setting the background.
var background = new Image();

// function for setting the Canvas' size
var setSizes = function () {
    canv.width = window.innerWidth;
    canv.height = window.innerHeight;
}

// function for printing the background on the canvas (clearing the canvas).
ctx.clear = function () {
    canvwidth = canv.clientWidth;
    canvheight = canv.clientHeight;
    ctx.drawImage(background, 0, 0, canvwidth, canvheight);
}

    // function for drawing the last point recieved,
    // and a line that goes throgh all the points in points array.
var draw = function () {
    setSizes();
    ctx.clear();
    if (points.length > 0) {
        var i = points.length - 1,
            normalX = canv.width * points[i].x,
            normalY = canv.height * points[i].y;
        ctx.fillStyle = "blue";
        ctx.beginPath();
        ctx.arc(normalX, normalY, 10, 0, 2 * Math.PI);
        ctx.closePath();
        ctx.fill();
        ctx.fillStyle = "red";
        ctx.beginPath();
        ctx.arc(normalX, normalY, 5, 0, 2 * Math.PI);
        ctx.closePath();
        ctx.fill();
        ctx.strokeStyle = "red";
        ctx.lineWidth = 3;
        ctx.lineCap = "round";
        ctx.beginPath();
        for (; i >= 0; i--) {
            ctx.lineTo(normalX, normalY);
            normalX = canv.width * points[i].x,
                normalY = canv.height * points[i].y;
        }
        ctx.lineTo(normalX, normalY);
        ctx.stroke();
    }
}