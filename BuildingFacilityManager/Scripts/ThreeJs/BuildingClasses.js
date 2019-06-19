class Asset {
    constructor(id, position) {
        this.pointAnalysis = pointAnalysis;
        this.type = type;
    }
    create() {
        var strObject;
        var x = this.pointAnalysis.sphere.position.x;
        var y = this.pointAnalysis.sphere.position.y;
        var z = this.pointAnalysis.sphere.position.z;

        // load external geometry
        var objLoader = new THREE.OBJLoader();
        let path;
        switch (this.type) {
        case "fixed":
            path = "/assets/models/str1.obj"
            break;

        case "hinged":
            path = "/assets/models/str2.obj"
            break;

        case "roller":
            path = "/assets/models/str3.obj"
            break;
        }

        objLoader.load(path, function (obj) {
            var objMaterial = new THREE.MeshStandardMaterial({
                color: 'rgb(200, 200, 200)'
            });
            objMaterial.envMap = reflectionCube;

            obj.traverse(function (child) {
                child.material = objMaterial;
                child.name = 'supportsObject';
                objMaterial.roughness = 0.5;
                objMaterial.metalness = 0.5;
                strObject = child;
            });

            obj.scale.x = 0.2;
            obj.scale.y = 0.2;
            obj.scale.z = 0.2;
            obj.position.x = x;
            obj.position.y = y;
            obj.position.z = z;
            scene.add(obj);
            return obj;
        });

    }
}