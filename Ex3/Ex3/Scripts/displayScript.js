function point(x, y) {
    this.x = x;
    this.y = y;
}

var points = [];

var canv = document.getElementById("mapCanvas"),
    ctx = canv.getContext("2d");

var background = new Image();
console.log(background.src);


var setSizes = function () {
    canv.width = window.innerWidth;
    canv.height = window.innerHeight;
}

ctx.clear = function () {
    canvwidth = canv.clientWidth;
    canvheight = canv.clientHeight;
    ctx.drawImage(background, 0, 0, canvwidth, canvheight);
}

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

background.onload = function () {
    document.addEventListener("resize", draw);
    document.addEventListener("load", draw);

    console.log("test");

    if (frequency > 0) {
        setInterval(onTimer, frequency * 1000);
    } else {
        onTimer();
    }

    if (time > 0) {
        setTimeout(function () { clearInterval() }, time * 1000);
    }
}