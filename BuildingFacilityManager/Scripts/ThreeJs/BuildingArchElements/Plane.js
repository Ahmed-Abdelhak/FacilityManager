 class Plane

{
    constructor(size)
    {
        this.size=size;
    }

    draw()
    {
        let geometry= new THREE.PlaneGeometry(this.size,this.size);
        let material= new THREE.MeshPhongMaterial({color:0xff0000,  side: THREE.DoubleSide});
        let mesh = new THREE.Mesh(geometry,material);
        return mesh;
    }      
}
