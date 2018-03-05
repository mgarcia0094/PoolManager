using System.Collections.Generic;
using UnityEngine;

namespace PM {
	//SINGLETON
	public class PoolManager {
		
		private GameObject PMInstanceScene = null;
		private static PoolManager instance = null;
		private static Dictionary<string, System.Object> pools = new Dictionary<string,System.Object>();
		private static Dictionary<string, GameObject> gameObjects = new Dictionary<string, GameObject>();
		private PoolManager() {
			if(PMInstanceScene == null) {
				PMInstanceScene = new GameObject();
				PMInstanceScene.name = "(System)PoolManager";
				PMInstanceScene.SetActive(false);
			}
		}

		//AddPool key (name), value (pool)
		public void AddPool(string name, System.Object p) {
			pools.Add(name, p);
		}

		//RemovePool by key
		public void RemovePool(string namePool) {
			pools.Remove(namePool);
		}

		//get pool by key, return null if not exist
		public System.Object GetPool(string namePool) {
			return pools[namePool];
		}

		public GameObject GetPoolManagerScene() {
			return PMInstanceScene;
		}

		//create child in poolmanager's gameobject
		public GameObject CreateObjectPool(string name) {
			if (gameObjects.ContainsKey(name)) return GetObjectPool(name);
			else {
				GameObject aux = new GameObject();
				aux.transform.SetParent(PMInstanceScene.transform);
				aux.SetActive(false);
				aux.name = name;
				gameObjects.Add(name, aux);
				return aux;
			}
		}

		public GameObject GetObjectPool(string name) {
			return gameObjects[name];
		}

		//SINGLETON
		public static PoolManager Instance {
			get {
				if (instance == null) {
					instance = new PoolManager();
				}
				return instance;
			}
		}
	}
}
