var canvas: HTMLCanvasElement;
var renderer: CanvasRenderingContext2D;

window.onload = function () {
    canvas = document.getElementsByTagName("canvas")[0];
    renderer = canvas.getContext("2d");

    //Draw background
    renderer.fillStyle = 'green';
    renderer.fillRect(0, 0, 480, 480);
    //Draw outline
    renderer.strokeStyle = 'black';
    renderer.strokeRect(0, 0, 480, 480);
}
