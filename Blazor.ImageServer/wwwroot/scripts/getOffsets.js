var ImageViewer = ImageViewer || {};
ImageViewer.getOffsets = function (id) {
    var element = document.getElementById(id);
    var boundingBox = element.getBoundingClientRect();
    return {
        x: boundingBox.left,
        y: boundingBox.top
    };
}