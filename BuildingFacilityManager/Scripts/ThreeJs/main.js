//import{Window} from '/BuildingArchElements/Window.js';
//import {Wall} from '/BuildingArchElements/Wall.js';
//import{Door} from '/BuildingArchElements/Door.js';
//import{Beam} from '/BuildingArchElements/Beam.js';
//import{Axis} from '/BuildingArchElements/Axis.js';
//import{Column} from '/BuildingArchElements/Column.js';
//import{Plane} from '/BuildingArchElements/Plane.js';
//import{Skin} from './Skin.js';


function init() { 
                                              //Scene
                                                                                    
    var scene = new THREE.Scene(); //creating the scene object 

                                                //Point Light

    var pointLight = getPointLight(0.7); // we gave intensity equal to 1 then add it in the scene down
    pointLight.position.y = 5; //changing the position of the light from the default place (origin)
    pointLight.intensity = 5;   
    scene.add(pointLight); 

                                             //Light Sphere
                                          
    var sphere = getSphere (0.15); //we called the func of the light and then we gonna add it to scene
    pointLight.add(sphere); //the sphere object inside the light object  
    

                                             //Camera
                                              
    var camera = new THREE.PerspectiveCamera(45,window.innerWidth / window.innerHeight,1,1000,);
    camera.position.x = 800;
    camera.position.y = 800;
    camera.position.z = 800;
    camera.lookAt ( new THREE.Vector3 (0, 0, 0) ); //lookat could take scene and position

                                     // creating Plane from down function (not moduled yet)
    var plane = getPlane(800); //4 here is for the size 
    plane.name = 'plane-1';
    plane.rotation.x = Math.PI / 2; //this is for the rotation of the plane around x axis and then we concert it to degree as the used angles is rad
    //plane.rotation.y = 1; //we wrote it for the scene rotation effect
    plane.position.x= -100
    plane.position.z= 300

    scene.add(plane);
                                            
                                        //Skin

    let mapText= new Skin("Textures_Samples/crate0_diffuse2.png");
    let mapTextLoad = mapText.load();

    let bumpMapText = new Skin("Textures_Samples/crate0_bump2.png");
    let bumpMapTextLoad = bumpMapText.load();

    let normalMapText = new Skin("Textures_Samples/crate0_normal2.png");
    let normalMapTextLoad = normalMapText.load();

    


                                    // creating the Wall from wall module
    let wall1 = new Wall(25,25,5,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let wall1Mesh = wall1.draw();
    wall1Mesh.name="wall1"
    wall1Mesh.position.y=25;
    wall1Mesh.position.x=25;

    scene.add(wall1Mesh);
    console.log(wall1Mesh);

                                    //creating small column from column module
    let column1 = new Column(6,45,6,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let column1Mesh = column1.draw();
    column1Mesh.name="column1"
    column1Mesh.position.x=-200;
    column1Mesh.position.y=22.5;
    scene.add(column1Mesh);


    let column2 = new Column(6,45,6,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let column2Mesh = column2.draw();
    column2Mesh.name="column2"
    column2Mesh.position.x=-200;
    column2Mesh.position.z=90;
    column2Mesh.position.y=22.5;
    scene.add(column2Mesh);

    let column3 = new Column(6,45,6,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let column3Mesh = column3.draw();
    column3Mesh.name="column3"
    column3Mesh.position.x=-200;
    column3Mesh.position.z=150;
    column3Mesh.position.y=22.5;
    scene.add(column3Mesh);



    let column4 = new Column(6,45,6,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let column4Mesh = column4.draw();
    column4Mesh.name="column4"
    column4Mesh.position.x=-200;
    column4Mesh.position.z=173;
    column4Mesh.position.y=22.5;
    scene.add(column4Mesh);




    let column5 = new Column(6,40,6,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let column5Mesh = column5.draw();
    column5Mesh.name="column1"
    column5Mesh.position.x=-200;
    column5Mesh.position.z=227;
    column5Mesh.position.y=22.5;
    scene.add(column5Mesh);



    let column6 = new Column(6,45,6,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let column6Mesh = column6.draw();
    column6Mesh.name="column1"
    column6Mesh.position.x=-200;
    column6Mesh.position.z=281;
    column6Mesh.position.y=22.5;
    scene.add(column6Mesh);



    let column7 = new Column(6,45,6,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let column7Mesh = column7.draw();
    column7Mesh.name="column7"
    column7Mesh.position.x=-200;
    column7Mesh.position.z=335;
    column7Mesh.position.y=22.5;
    scene.add(column7Mesh);



    let column8 = new Column(6,45,6,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let column8Mesh = column8.draw();
    column8Mesh.name="column8"
    column8Mesh.position.x=-200;
    column8Mesh.position.z=389;
    column8Mesh.position.y=22.5;
    scene.add(column8Mesh);


    let column9 = new Column(6,45,6,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let column9Mesh = column9.draw();
    column9Mesh.name="column9"
    column9Mesh.position.x=-200;
    column9Mesh.position.z=443;
    column9Mesh.position.y=22.5;
    scene.add(column9Mesh);


    let column10 = new Column(6,45,6,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let column10Mesh = column10.draw();
    column10Mesh.name="column10"
    column10Mesh.position.x=-200;
    column10Mesh.position.z=497;
    column10Mesh.position.y=22.5;
    scene.add(column10Mesh);


    let colum11 = new Column(6,45,6,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let column11Mesh = colum11.draw();
    column11Mesh.name="column11"
    column11Mesh.position.x=-200;
    column11Mesh.position.z=556;
    column11Mesh.position.y=22.5;
    scene.add(column11Mesh);


    let column12 = new Column(6,45,6,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let column12Mesh = column12.draw();
    column12Mesh.name="column8"
    column12Mesh.position.x=-200;
    column12Mesh.position.z=616;
    column12Mesh.position.y=22.5;
    scene.add(column12Mesh);



    let column13 = new Column(6,45,6,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let column13Mesh = column13.draw();
    column13Mesh.name="column8"
    column13Mesh.position.x=-200;
    column13Mesh.position.z=649.5;
    column13Mesh.position.y=22.5;
    scene.add(column13Mesh);

    let column14 = new Column(6,45,6,mapTextLoad,bumpMapTextLoad,normalMapTextLoad)
    let column14Mesh = column14.draw();
    column14Mesh.name="column14"
    column14Mesh.position.x=-200;
    column14Mesh.position.z=681.5;
    column14Mesh.position.y=22.5;
    scene.add(column14Mesh);


                                    //Creating axis
                                        // y-Axis
    var material = new THREE.LineBasicMaterial( { color: 0x00FF37 } );
    var geometry = new THREE.Geometry();
    geometry.vertices.push(new THREE.Vector3( -300, 0, 0) );
    geometry.vertices.push(new THREE.Vector3( 300, 0, 0) );
    

    var Yaxis1 = new THREE.Line( geometry, material );
    scene.add( Yaxis1 );

    var Yaxis2 = new THREE.Line( geometry, material );
    Yaxis2.position.z=90;
    scene.add( Yaxis2 );

    var Yaxis3 = new THREE.Line( geometry, material );
    Yaxis3.position.z=150;
    scene.add( Yaxis3 );

    var Yaxis4 = new THREE.Line( geometry, material );
    Yaxis4.position.z=173;
    scene.add( Yaxis4 );

    var Yaxis5 = new THREE.Line( geometry, material );
    Yaxis5.position.z=227;
    scene.add( Yaxis5 );

    var Yaxis6 = new THREE.Line( geometry, material );
    Yaxis6.position.z=281;
    scene.add( Yaxis6 );

    var Yaxis7 = new THREE.Line( geometry, material );
    Yaxis7.position.z=335;
    scene.add( Yaxis7 );

    var Yaxis8 = new THREE.Line( geometry, material );
    Yaxis8.position.z=389;
    scene.add( Yaxis8 );

    var Yaxis9= new THREE.Line( geometry, material );
    Yaxis9.position.z=443;
    scene.add( Yaxis9 );

    var Yaxis10 = new THREE.Line( geometry, material );
    Yaxis10.position.z=497;
    scene.add( Yaxis10 );

    var Yaxis11 = new THREE.Line( geometry, material );
    Yaxis11.position.z=526;
    scene.add( Yaxis11 );

    var Yaxis12 = new THREE.Line( geometry, material );
    Yaxis12.position.z=556;
    scene.add( Yaxis12 );

    var Yaxis13 = new THREE.Line( geometry, material );
    Yaxis13.position.z=616;
    scene.add( Yaxis13 );

    var Yaxis14 = new THREE.Line( geometry, material );
    Yaxis14.position.z=649.5;
    scene.add( Yaxis14 );

    var Yaxis15 = new THREE.Line( geometry, material );
    Yaxis15.position.z=681.5;
    scene.add( Yaxis15 );

                                        //x-Axis



    var material = new THREE.LineBasicMaterial( { color: 0x00FF37 } );
    var geometry = new THREE.Geometry();
    geometry.vertices.push(new THREE.Vector3( 0, 0, -50) );
    geometry.vertices.push(new THREE.Vector3( 0, 0, 700) );
    
    var Xaxis2 = new THREE.Line( geometry, material );
    Xaxis2.position.x=-200
    scene.add( Xaxis2 );

    var Xaxis3 = new THREE.Line( geometry, material );
    Xaxis3.position.x=-131
    scene.add( Xaxis3 );

    var Xaxis4 = new THREE.Line( geometry, material );
    Xaxis4.position.x=-71
    scene.add( Xaxis4 );

    var Xaxis5 = new THREE.Line( geometry, material );
    Xaxis5.position.x=-41
    scene.add( Xaxis5 );

    var Xaxis6 = new THREE.Line( geometry, material );
    Xaxis6.position.x= 19
    scene.add( Xaxis6 );

    var Xaxis7 = new THREE.Line( geometry, material );
    Xaxis7.position.x=73
    scene.add( Xaxis7 );

    var Xaxis8 = new THREE.Line( geometry, material );
    Xaxis8.position.x=127
    scene.add( Xaxis8 );

    var Xaxis10 = new THREE.Line( geometry, material );
    Xaxis10.position.x=181
    scene.add( Xaxis10 );

    var Xaxis11 = new THREE.Line( geometry, material );
    Xaxis11.position.x=235
    scene.add( Xaxis11 );

    var Xaxis12 = new THREE.Line( geometry, material );
    Xaxis12.position.x=270
    scene.add( Xaxis12 );


    //------------------------------------------------Templates------------------------------------
 
    var loader3 = new THREE.OBJLoader();
    // load a resource
   
    loader3.load('/Scripts/ThreeJs/OBJformat/chairDesk.obj',
    function ( chairDesk ) {chairDesk.position.set(1, 0, 1); scene.add( chairDesk );});








    var loader = new THREE.OBJLoader();
    // load a resource
    loader.load('/Scripts/ThreeJs/OBJformat/loungeDesignSofaCorner.obj',
    function ( loungeDesignSofaCorner ) {scene.add( loungeDesignSofaCorner );});

    var loader = new THREE.OBJLoader();
    // load a resource
    loader.load('/Scripts/ThreeJs/OBJformat/desk.obj',
    function ( desk ) {desk.position.set(0, 0, 0); scene.add( desk);});


    var loader = new THREE.OBJLoader();
    // load a resource
    loader.load('/Scripts/ThreeJs/OBJformat/bathroomSink.obj',
    function ( bathroomSink ) {bathroomSink.position.set(1.7, .3, 1.5); scene.add( bathroomSink );});

    var loader = new THREE.OBJLoader();
    // load a resource
    loader.load('/Scripts/ThreeJs/OBJformat/laptop.obj',
    function ( laptop ) {laptop.position.set(0,0.4,0); scene.add( laptop );});


    var loader1= new THREE.OBJLoader();
    // load a resource
    loader1.load('/Scripts/ThreeJs/OBJformat/trashcan.obj',
    function ( trashcan ) {trashcan.position.set(5,0.2,5);trashcan.scale.set(10,10,10); scene.add( trashcan );});

    var loader = new THREE.OBJLoader();
    // load a resource
    loader.load('/Scripts/ThreeJs/OBJformat/wall.obj',
    function ( wall ) {wall.position.set(-150,0,1.3); wall.rotation.set(0,90,0); wall.scale.set(50,50,50); scene.add( wall );});
    
    var loader2 = new THREE.OBJLoader();
    // load a resource
    loader2.load('/Scripts/ThreeJs/OBJformat/sample.obj',
    function ( sample) {sample.position.set(0,0.4,0); scene.add( sample);});
    console.log(loader2);

                                             //dat.GUI
    var gui = new dat.GUI();                    

                                            //Light folder

    var boxPointLight = gui.addFolder('Light');
    boxPointLight.add(pointLight, 'intensity', 0 ,3); //pass the object you want to control the properties of it and the property name and optionally the range >> min and max alue of that property
    boxPointLight.add(pointLight.position, 'y', 0, 7); //we declared the y ass we used the position property then the range


                                            //Position folder

    // var boxPosition = gui.addFolder('Box Position');
    // boxPosition.add(box.position, 'x', -5, 5 );
    // boxPosition.add(box.position, 'y', 1, 5 );
    // boxPosition.add(box.position, 'z', -5, 5 );

                                            //Dimensions folder

    // var boxDim = gui.addFolder('Box Dimensions'); //this is the name of the folder in the control
    // boxDim.add(box.scale, 'x', 0, 3).name('Width').listen();
    // boxDim.add(box.scale, 'z', 0, 3).name('Length').listen();
    // boxDim.add(box.scale, 'y', 0, 3).name('Height').listen();
    // boxDim.add(box.material, 'wireframe').listen();  //this enable the wire option 
  
                                                //Renderer
                                              

    var renderer = new THREE.WebGLRenderer();
    renderer.setSize( window.innerWidth, window.innerHeight );
    renderer.setClearColor( 'rgb (120, 120, 120)' );
    document.getElementById('webgl').appendChild( renderer.domElement );



                                           //DomEvent

    // var domEvents = new THREEx.DomEvents(camera, renderer.domElement) 
    // domEvents.addEventListener(trashcan, 'click', function(event){
    //     return url, linkify;
    //     //alert("You Clicked on the box!");
    // }, false)

    //                                     //Backend Links 
    // var trashcanUrl = 'https://dictionary.cambridge.org/dictionary/english/plane'
    // var linkify	= THREEx.Linkify(domEvents, trashcan, trashcanUrl, true)

                            
    // var boxUrl	= 'https://www.merriam-webster.com/dictionary/box'
    // var linkify	= THREEx.Linkify(domEvents, box, boxUrl, true)
    // //box.scale.x+=

    //                                     //Mosue Over

    // domEvents.addEventListener(box, 'mouseover', function(event){
    //     return action;
    // }, false)           
    // var action = function runEvent(e)  {
    //     console.log('eventtype'+e.type);
    // }                              
    // instantiate a loader

                                        //Controls Orbit Control
                                  
    var controls = new THREE.OrbitControls(camera, renderer.domElement); //use the camera and the renderer as args and the nwe will pass this  var  in the update 
    controls.enableKeys =true; //enabling keyboard
    controls.enableZoom =true; //enabling zoom by mouse


                                        //Calling the functions
    update( renderer,scene, camera, controls ); //calling the function with the same arguments and the renderer object   

    return scene;
}

                                           //Plane Funtion             

function getPlane(size) {
    var geometry = new THREE.PlaneGeometry(size, size); //specify geometry //size here is the width and the depth 
    var material = new THREE.MeshPhongMaterial({color: 'rgb (120, 120, 120)', side: THREE.DoubleSide});
    var mesh = new THREE.Mesh(geometry,material);
    return mesh;
}

                                           //Light Sphere Funtion             

function getSphere(size)   { //the anly arg of the light func
    var geometry = new THREE.SphereGeometry(size, 24, 24); //specify geometry 
    var material = new THREE.MeshBasicMaterial({color: 'rgb (255, 255, 255)'}); //meshbasic to be self animated object
    var mesh = new THREE.Mesh(geometry,material,);
    return mesh; //after returning the mesh and declaring the scene in a variable we will be able to see the scene object in the console 
}

function getPointLight(intensity) { //the intensity arg is for the single point light 
    var light = new THREE.PointLight(0xffffff, intensity); //point light takes 2 args >> color & intensity
    return light;
}

                                           //Update Funtion             

function  update(renderer, scene, camera, controls) {
    renderer.render(scene,camera);
    controls.update(); //calling the update method on the controls object
    requestAnimationFrame(function() {update(renderer, scene, camera, controls);})  //using the same argumentswith a call back function and this will be the update functon  (being called bac)
}


    let Assets;

var scene = init();
