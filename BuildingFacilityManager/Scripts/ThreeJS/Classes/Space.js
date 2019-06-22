class Space {
    constructor (width, length, height, positionX, positionY, storeyId, id, label, stories) {
        this.width = width;
        this.length = length;
        this.wallsHeight = height;
        this.positionX = positionX;
        this.positionY = positionY;

        this.storeyId = storeyId;
        this.id = id;
        this.label = label;
       
        this.level = (stories.find(e => e.id == this.storeyId)).level * 9;

    }

    create() {


        let objRoom = new THREE.Object3D();

        let w1 = Helper.getBox(this.length, this.wallsHeight, 0.2, roomMaterial);
        let w3 = Helper.getBox(this.length, this.wallsHeight, 0.2, roomMaterial);

        let w2 = Helper.getBox(0.2, this.wallsHeight, this.width - 0.4, roomMaterial);
        let w4 = Helper.getBox(0.2, this.wallsHeight, this.width - 0.4, roomMaterial);



        w1.position.z = this.positionY + this.width * 0.5 - 0.1;
        w3.position.z = this.positionY - this.width * 0.5 + 0.1;

        w1.position.x = this.positionX;
        w3.position.x = this.positionX;

        w2.position.x = this.positionX + this.length * 0.5 - 0.1;
        w4.position.x = this.positionX - this.length * 0.5 + 0.1;

        w2.position.z = this.positionY;
        w4.position.z = this.positionY;


        objRoom.add(w1);
        objRoom.add(w2);
        objRoom.add(w3);
        objRoom.add(w4);

        objRoom.name = "MeshRoom";
        objRoom.position.y = this.wallsHeight * 0.5 + this.level;
        objRoom.position.z = 0.5 * this.width;
        objRoom.position.x = 0.5 * this.length;


        return objRoom;
    }

    //toJson() {
    //    let spaces = [];
    //    let mySpace =
    //    {
    //        "id": this.id,
    //        "label": this.label,
    //        'elevation': this.elevation,
    //        'positionX': this.position.x,
    //        'positionY': this.position.z,
    //        'width': this.width,
    //        'length': this.length,
    //        'wallsHeight': this.height,


    //    }
    //    spaces.push(mySpace);
    //    return spaces;
    //}
}