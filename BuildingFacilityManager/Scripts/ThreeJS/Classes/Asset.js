class Asset {
    constructor(id, label, assetType, spaceId, spaces, stories) {
        this.id = id;
        this.label = label;
        this.assetType = assetType;
        this.spaceId = spaceId;
        this.space = (spaces.find(e => e.id == this.spaceId));
        this.story = (stories.find(e => e.id == this.space.storeyId));

        this.level = this.story.level;
        this.positionX = this.space.positionX;
        this.positionY = this.space.positionY;

        this.width = this.space.width * Math.random();
        this.length = this.space.length * Math.random();
    }

    create() {
        let strObject;
        let x = this.positionX;
        let z = this.positionY;
        let level = this.level * 9;
        let shiftX = this.length;
        let shiftY = this.width;


        let objLoader = new THREE.OBJLoader();
        let path;
        switch (this.assetType) {
            case 1:
                path = "\\Scripts\\ThreeJS\\OBJformat\\chair.obj";
                break;
            case 2:
                path = "\\Scripts\\ThreeJS\\OBJformat\\chairDesk.obj";
                break;
            case 3:
                path = "\\Scripts\\ThreeJS\\OBJformat\\desk.obj";
                break;
            case 4:
                path = "\\Scripts\\ThreeJS\\OBJformat\\table.obj";
                break;
            case 5:
                path = "\\Scripts\\ThreeJS\\OBJformat\\laptop.obj";
                break;
            case 6:
                path = "\\Scripts\\ThreeJS\\OBJformat\\televisionModern.obj";
                break;
        }

        objLoader.load(path, function (obj) {
            var objMaterial = new THREE.MeshStandardMaterial({
                color: 'rgb(200, 200, 200)'
            });
           
            obj.traverse(function (child) {
                child.material = objMaterial;
                child.name = 'asset';
                objMaterial.roughness = 0.5;
                objMaterial.metalness = 0.5;
                strObject = child;
            });

            obj.scale.x = 2;
            obj.scale.y = 2;
            obj.scale.z = 2;
            obj.position.x = x + shiftX;
            obj.position.y = level;
            obj.position.z = z + shiftY;
            scene.add(obj);
            return obj;
        });

    }
}


