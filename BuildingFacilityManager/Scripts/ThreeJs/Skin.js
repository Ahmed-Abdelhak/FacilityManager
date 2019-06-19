 class Skin
{
    constructor(columSkinPath)
    {
        this.columSkinPath = columSkinPath;
    }
    load()
    {
       let columSkin = new THREE.TextureLoader().load("Textures_Samples/crate0_bump2.png");
       columSkin.wrapS= THREE.RepeatWrapping;
       columSkin.wrapT = THREE.RepeatWrapping; 
       columSkin.repeat.set(4,4);


       return columSkin;
    }


}

// var texture = new THREE.TextureLoader().load( "textures/water.jpg" );
// texture.wrapS = THREE.RepeatWrapping;
// texture.wrapT = THREE.RepeatWrapping;
// texture.repeat.set( 4, 4 );
