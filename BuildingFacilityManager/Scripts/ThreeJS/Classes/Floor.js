class Floor {

    constructor(width, length, elevation, id, label) {
        this.width = width;
        this.length = length;
        this.elevation = elevation;
        this.id = id;
        this.label = label;
    }

    create() {
        let meshFloor = Helper.getBox(this.length, 0.2, this.width, floorMaterial);
        meshFloor.name = "MeshFloor"

        meshFloor.position.y = this.elevation;

        return meshFloor;
    }
}