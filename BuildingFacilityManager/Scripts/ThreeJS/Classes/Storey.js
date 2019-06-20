class Storey {

    constructor(width, length, level, id, label) {
        this.width = width;
        this.length = length;
        this.level = level;
        this.id = id;
        this.label = label;
    }

    create() {
        let meshFloor = Helper.getBox(this.length, 0.2, this.width, floorMaterial);
        meshFloor.name = "MeshFloor";       

        meshFloor.position.y = this.level*6;

        return meshFloor;
    }
}