using UnityEngine;
using System.Collections;

public class JingleObject : MonoBehaviour {
	//The original vertices
	private Vector3[] v3BaseVertices;
	//The objects mesh
	private Mesh meshObjectsMesh;

	//Initialise class
	void Start () {
		//Get the mesh of this object
		meshObjectsMesh = GetComponent<MeshFilter>().mesh;
		//Set the original vertices
		v3BaseVertices = meshObjectsMesh.vertices;
	}

	// Update is called once per frame
	void Update () {
		//The new vertices
		Vector3[] v3Vertices = new Vector3[v3BaseVertices.Length];
		//Random values to move the axis by and create the jingle
		float fScaleX = Random.value/20 ;
		float fScaleY = Random.value/20 ;
		float fScaleZ = Random.value/20 ;
		//loop through each vertex
		for (var i=0;i<v3Vertices.Length;i++)
		{
			//Get the next vertex
			Vector3 v3Vertex= v3BaseVertices[i];
			//Make a change to each of the coordinates of this vertex
			v3Vertex.x += fScaleX;
			v3Vertex.y += fScaleY;
			v3Vertex.z += fScaleZ;
			//Add the new vertex to our new array
			v3Vertices[i] = v3Vertex;
		}
		//Set the new array as the mesh vertex array
		meshObjectsMesh.vertices = v3Vertices;
		//We can ask the engine to recalculate the normals  
		//of the mesh, the normals are the surfaces that are rendered.                          meshObjectsMesh.RecalculateNormals();

		//We have to call RecalculateBounds to make sure
		//that the triangles from the vertex relationships
		//are recalculated correctly
		meshObjectsMesh.RecalculateBounds();
	}
}