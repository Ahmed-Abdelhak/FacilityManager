// Setting the scene

var scene = new THREE.Scene();

// Camera Object

var camera = new THREE.PerspectiveCamera(4, window.innerWidth / window.innerHeight, 0.1, 1000);
camera.position.z = 75;
camera.position.x = 50;
camera.position.y = 50;
camera.lookAt(scene.position);
//camera.updateMatrixWorld();

// Render Object


var renderer = new THREE.WebGLRenderer();
renderer.setSize(window.innerWidth, window.innerHeight);
document.body.appendChild(renderer.domElement);

// var controls = new THREE.OrbitControls(camera, renderer.domElement); //use the camera and the renderer as args and the nwe will pass this  var  in the update 
//     controls.enableKeys =true; //enabling keyboard
//     controls.enableZoom =true; //enabling zoom by mouse


                                //Controls Orbit Control
                                  

  var controls = new THREE.OrbitControls(camera, renderer.domElement); //use the camera and the renderer as args and the nwe will pass this  var  in the update 
  controls.enableKeys =true; //enabling keyboard
  controls.enableZoom =true; //enabling zoom by mouse

// Making the cube

var geometry = new THREE.BoxGeometry(5, 5, 5, 5, 5, 5);
var material = new THREE.MeshDepthMaterial({
  opacity: 0.1,
  blending: THREE.NormalBlending, 
  depthTest: true,

});



var cube = new THREE.Mesh(geometry, material);

scene.add(cube);



// Options to be added to the GUI

var options = {
  velx: 0,
  vely: 0,
  camera: {
    speed: 0.0001
  },
  stop: function() {
    this.velx = 0;
    this.vely = 0;
  },
  reset: function() {
    this.velx = 0.1;
    this.vely = 0.1;
    camera.position.z = 75;
    camera.position.x = 0;
    camera.position.y = 0;
    cube.scale.x = 1;
    cube.scale.y = 1;
    cube.scale.z = 1;
    //cube.material.wireframe = true;
  }
};

// DAT.GUI Related Stuff

var gui = new dat.GUI();

// var cam = gui.addFolder('Camera');
// cam.add(options.camera, 'speed', 0, 0.0010).listen();
// cam.add(camera.position, 'y', 0, 100).listen();
// cam.open();

// var velocity = gui.addFolder('Velocity');
// velocity.add(options, 'velx', -0.2, 0.2).name('X').listen();
// velocity.add(options, 'vely', -0.2, 0.2).name('Y').listen();
// velocity.open();

var box = gui.addFolder('Cube');
box.add(cube.scale, 'x', 0, 3).name('Width').listen();
box.add(cube.scale, 'y', 0, 3).name('Height').listen();
box.add(cube.scale, 'z', 0, 3).name('Length').listen();
box.add(cube.material, 'wireframe').listen();  
box.open();

gui.add(options, 'stop');
gui.add(options, 'reset');

// Rendering the animation   

var render = function() {

  requestAnimationFrame(render);

  var timer = Date.now() * options.camera.speed;
  camera.position.x = Math.cos(timer) * 100;
  camera.position.z = Math.sin(timer) * 100;
  camera.lookAt(scene.position); 
  camera.updateMatrixWorld();

  cube.rotation.x += options.velx;
  cube.rotation.y += options.vely;

  renderer.render(scene, camera);

};
render();