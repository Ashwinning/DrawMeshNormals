using UnityEngine;
using System.Collections;

public class DrawMeshNormals : MonoBehaviour {

	public float normalWidth = 0.005f;
	public float normalLength = 0.05f;

	void Start()
	{
		//Get Mesh
		Mesh mesh = this.gameObject.GetComponent<MeshFilter> ().mesh;


		//For every face in the mesh, get it's normals
		foreach (Vector3 normal in mesh.normals)
		{

			//print ("Normal = " + transform.TransformPoint(normal) + " length = " + transform.TransformPoint(normal * normalLength));

			//Create a new GameObject
			GameObject lineHolder = new GameObject();
			//lineHolder.transform.position = transform.TransformPoint (normal);
			//Create a Linerenderer component for this
			LineRenderer line = lineHolder.AddComponent<LineRenderer> ();
			line.useWorldSpace = true;
			//Set Linerenderer properties
			line.material = new Material(Shader.Find("Particles/Additive"));
			//line.SetColors(Color.white, Color.white);
			line.SetWidth(normalWidth, normalWidth);
			line.SetVertexCount (2);
			Vector3 position = transform.TransformPoint(normal);
			//Set the position for the first point in line to the middle
			line.SetPosition(0, position);
			//Set the position of the second point in line
			line.SetPosition (1, transform.TransformPoint(normal * normalLength));

		}
	}



}