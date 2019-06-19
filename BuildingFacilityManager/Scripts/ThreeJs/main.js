// import{Window} from '/BuildingArchElements/Window.js';
// import{Wall} from '/BuildingArchElements/Wall.js';
// import{Door} from '/BuildingArchElements/Door.js';
// import{Beam} from '/BuildingArchElements/Beam.js';
// import{Axis} from '/BuildingArchElements/Axis.js';
// import{Column} from '/BuildingArchElements/Column.js';
// import{Plane} from '/BuildingArchElements/Plane.js';
// import{Skin} from './Skin.js';


function init() { 
                                              //Scene
                                                                                    
    var scene = new THREE.Scene(); //creating the scene object 

                                                //Point Light

    var pointLight = getPointLight(1.4); // we gave intensity equal to 1 then add it in the scene down
    pointLight.position.y = 5; //changing the position of the light from the default place (origin)
    pointLight.intensity = 1.4;   
    scene.add(pointLight); 

                                             //Light Sphere
                                          
    var sphere = getSphere (0.15); //we called the func of the light and then we gonna add it to scene
    pointLight.add(sphere); //the sphere object inside the light object  
    

                                             //Camera                       
    var camera = new THREE.PerspectiveCamera(45,window.innerWidth / window.innerHeight,1,1000,);
    camera.position.x = 50;
    camera.position.y = 50;
    camera.position.z = 50;
    camera.lookAt ( new THREE.Vector3 (0, 0, 0) ); //lookat could take scene and position



                            //grid
    var size = 20;
    var divisions = 40;
    var gridHelper = new THREE.GridHelper( size, divisions);
    scene.add( gridHelper );


    // GridHelper(size=10, divisions=10,colorGrid=0x00FF37)


                                     // creating Plane from down function (not moduled yet)
    var plane = getPlane(800); //4 here is for the size 
    plane.name = 'plane-1';
    plane.rotation.x = Math.PI / 2; //this is for the rotation of the plane around x axis and then we concert it to degree as the used angles is rad
    //plane.rotation.y = 1; //we wrote it for the scene rotation effect
    plane.position.x= -100
    plane.position.z= 300

    // scene.add(plane);

    
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
    renderer.setClearColor( 'rgb (250, 250, 250)' );
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

    scene.background = new THREE.Color( 0xaaaaaa );

    // input from hussein
    let floor = new Floor(8,6,3,1,'floor1');
    let floor2 = new Floor(10,8,7,2,'floor2');
    let floor3 = new Floor(8,8,11,3,'floor3');

    floors.push(floor)
    floors.push(floor2)
    floors.push(floor3)

    let position1 =new Point2D(0,0)
    let room1=new Room(2,1.5,1.2,position1,1,1,"room1")
    let room2=new Room(2,1.5,1.2,position1,2,2,"room2")
    let room3=new Room(2,1.5,1.2,position1,3,3,"room3")
    rooms.push(room1)
    rooms.push(room2)
    rooms.push(room3)

    // draw elements
    for(let i=0;i<floors.length;i++)
    {
       let mesh= floors[i].create();
       scene.add(mesh) 
    }
    for(let i=0;i<rooms.length;i++)
    {
       let mesh= rooms[i].create();
       scene.add(mesh) 
    }


    //scene.add(floor.create())

    
    //scene.add(room1.create())








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

var scene = init();
