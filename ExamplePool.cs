using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PM;

public class ExamplePool : MonoBehaviour {

	public GameObject obj;
	// Use this for initialization
	void Awake () {
		Pool<ObjectPool> poolObject = new Pool<ObjectPool>("CubesPool", 10,  delegate() {
			GameObject objIns = Instantiate(obj) as GameObject;
			objIns.SetActive(false);
    		return objIns.GetComponent<ObjectPool>();
		});

		ObjectPool aux = poolObject.Get();
		aux.GetExample();
		StartCoroutine(WaitAndSave(aux, poolObject));
	}

	IEnumerator WaitAndSave(ObjectPool aux, Pool<ObjectPool> poolObject) {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(5);
		Debug.Log("ObjectPool guardado");
		poolObject.Store(aux);
    }
}
