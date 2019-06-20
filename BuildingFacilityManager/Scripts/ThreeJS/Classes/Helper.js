// materials
var floorMaterial = new THREE.MeshBasicMaterial({
    color: 0x555555
})
var roomMaterial = new THREE.MeshBasicMaterial({
    color: '#00FFEA'
})
//var Stories = [],
//    rooms = [],
//    assets = [];

class Helper {
    static getBox(w, h, d, material) {
        var box = new THREE.BoxGeometry(w, h, d);
        var mesh = new THREE.Mesh(box, material);
        mesh.castShadow = true;

        return mesh;
    }


}

class Point2D{
    constructor(x,z) {
        this.x = x;
        this.z = z;
    }
}