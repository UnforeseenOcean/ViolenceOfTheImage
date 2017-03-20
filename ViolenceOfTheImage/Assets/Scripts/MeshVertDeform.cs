using UnityEngine;
using System.Collections;

public class MeshVertDeform : MonoBehaviour {

	//Mesh Deforming Parts
	Mesh mesh;
	Vector3[] vertices;
	int currentVertexIndex = -1;
	Vector3 mousePoint;
	private GameObject sceneManager;
	private int clickCount=0;
	public AudioSource myAudioSource;

	//Timer Parts
	public float meshTimer;
	public bool isMeshDeforming;
	public bool canDeform;
	public int clicksToChange;

	public static int bleedLevel=-1;

	private GameObject plane;


	void Start () {
		
		mesh = GetComponent<MeshFilter>().mesh;
		vertices = mesh.vertices;

		meshTimer = -1;
		canDeform = true;

	}

	void OnEnable()
	{
		
	}

	void Update () {

		mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if(Input.GetMouseButtonDown(0)){
				if(!isMeshDeforming){
					isMeshDeforming = true;
				}
				MeshTransform (mousePoint);
			}
			if(Input.GetMouseButtonUp(0)){
				myAudioSource.Stop ();
				currentVertexIndex = -1;
				clickCount++;
			
			}
			if(currentVertexIndex >= 0){
				Vector3 localPos = transform.InverseTransformPoint(mousePoint);
				vertices[currentVertexIndex].Set(localPos.x, localPos.y, localPos.z);
				mesh.vertices = vertices;
				mesh.RecalculateBounds();
				mesh.RecalculateNormals();
			}
			



	}

	void OnDisable()
	{
		
	}

	void FindCurrentVertex(Vector3 point){

	}


	void MeshTransform(Vector3 point){

		int index = 0;
		float shortestDistance = Mathf.Infinity;


		for (int i = 0; i < vertices.Length; i++){

			float distance = Vector3.Distance(transform.TransformPoint(vertices[i]), point);
			if(distance < shortestDistance){
				myAudioSource.Play();
				//Debug.Log(distance);
				index = i;
				shortestDistance = distance;
			}

		}
		currentVertexIndex = index;


	}
}
