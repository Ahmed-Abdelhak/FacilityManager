class Room {
    constructor(width, length, height, position, floorId, id, label) {
        this.width = width;
        this.length = length;
        this.height = height;
        this.position = position;
        this.floorId = floorId;
        this.id = id;
        this.label = label;
        this.elevation = (Stories.find(e => e.id == this.floorId)).elevation;
    }

    create() {
        let objRoom = new THREE.Object3D();

         let w1 = Helper.getBox(this.length, this.height, 0.2, roomMaterial);
         let w3 = Helper.getBox(this.length, this.height, 0.2, roomMaterial);

        let w2 = Helper.getBox(0.2, this.height, this.width - 0.4, roomMaterial);
        let w4 = Helper.getBox(0.2, this.height, this.width - 0.4, roomMaterial);

        w1.position.z=this.position.z+this.width*0.5-0.1;
        w3.position.z=this.position.z-this.width*0.5+0.1;

        w2.position.x=this.position.x+this.length*0.5-0.1;
        w4.position.x=this.position.x-this.length*0.5+0.1;




        objRoom.add(w1);
        objRoom.add(w2);
        objRoom.add(w3); 
        objRoom.add(w4);

        objRoom.name = "MeshRoom";
        objRoom.position.y = this.height * 0.5 + this.elevation;
        objRoom.position.x = this.position.x;
        objRoom.position.z = this.position.z;

        return objRoom;
    }
}