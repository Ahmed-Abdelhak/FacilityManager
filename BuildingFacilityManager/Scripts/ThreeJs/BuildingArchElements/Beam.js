 class Beam

{
    constructor(width,length,depth,mapSkin,bumpMapSkin,normalMapSkin)
    {
        this.width=width;
        this.length=length;
        this.depth=depth;
        this.mapSkin=mapSkin;
        this.bumpMapSkin=bumpMapSkin;
        this.normalMapSkin=normalMapSkin;
    }

    draw()
    {
        let geometry= new THREE.BoxGeometry(this.width,this.length,this.depth);
        let material= new THREE.MeshPhongMaterial({color:0xffffff, map:this.mapSkin, bumpMap:this.bumpMapSkin, normalMap:this.normalMapSkin});
        let mesh=new THREE.Mesh(geometry,material);
        return mesh;
    }      
}
