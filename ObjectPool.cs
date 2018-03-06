using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

	public void GetExample() {
		this.transform.parent = null;
		Debug.Log("Me estás utilizando");
	}
}
