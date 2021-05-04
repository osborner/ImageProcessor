function getOffsets2 (id) {
    var element = document.getElementById(id);
    var boundingBox = element.getBoundingClientRect();
    return {
        x: boundingBox.left,
        y: boundingBox.top
    };
}