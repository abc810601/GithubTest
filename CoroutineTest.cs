using UnityEngine;
using System.Collections;

public class CoroutineTest : MonoBehaviour {
	int count =0;
	// Use this for initialization
	void Start () {
		StartCoroutine ("Count");
	}

	IEnumerator Count (){
		IEnumerator empty = myEmpty ();
		while (empty.MoveNext()) {
			yield return new WaitForEndOfFrame();
		}

		GameObject myObject = empty.Current as GameObject;
		ObjectProperty (myObject);

	}

	IEnumerator myEmpty(){
		while (count<100) {
			yield return null;
			count++;
			print (count+"%");
		}

		yield return new GameObject ("empty"); 
	}

	void ObjectProperty(GameObject myObject){

		myObject.transform.position = new Vector3 (0, 0, 0);
		GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		cube.transform.parent = myObject.transform;

		print ("all is done!");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
