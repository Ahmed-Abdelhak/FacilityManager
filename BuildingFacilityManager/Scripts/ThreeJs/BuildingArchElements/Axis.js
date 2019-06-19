         class Axis 

{



    // let firstVectors = [-300,0,0];
    // let secondVectors = [300,0,0];
    // let color = 0xFF0000 ;
    // let sara = drawLine(color , firstVectors , secondVectors);
    // sara.position.x=90;
    // sara.position.y=90;
    // sara.position.z=90;
    // scene.add(sara);

    drawAxis(color , firstVectors , secondVectors)
    {

        var material = new THREE.LineBasicMaterial( { color: color} );
        var geometry = new THREE.Geometry();
        var [v1,v2,v3]=firstVectors ;
        var [v4,v5,v6]=secondVectors ;
        geometry.vertices.push(new THREE.Vector3( v1, v2, v3) );
        geometry.vertices.push(new THREE.Vector3( v4, v5, v6) );
        var mesh = new THREE.Line( geometry, material );
        return mesh;
    }


}