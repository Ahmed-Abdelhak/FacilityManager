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

        meshFloor.position.y = this.level * 9;
        meshFloor.position.z = this.width * 0.5;
        meshFloor.position.x = this.length * 0.5;


        return meshFloor;
    }
}