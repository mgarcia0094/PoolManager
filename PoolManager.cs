using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PM {

	//SINGLETON
	public class PoolManager {
	
		private static PoolManager instance = null;
		private PoolManager() {}
		
		private static Dictionary<string, System.Object> pools = new Dictionary<string,System.Object>();

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

		//SINGLETON
		public static PoolManager Instance {
			get {
				if (instance == null) instance = new PoolManager();
				return instance;
			}
		}

	}
}
