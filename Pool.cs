using System.Collections.Generic;
using UnityEngine;

namespace PM {

	public class Pool<T> where T : MonoBehaviour {
		
		private Stack<T> stack;
		private string namePool;
		public delegate T CreateObjectDelegate();
		public CreateObjectDelegate m_buildMethod;
		
		//build constructor
		public Pool(string namePool, int size, CreateObjectDelegate buildMethod) {
			this.namePool = "(Pool)" + namePool;
			PoolManager.Instance.CreateObjectPool(this.namePool);

			this.stack = new Stack<T>();
			this.m_buildMethod = buildMethod;
			
			
			for (int i = 0; i < size; i++) {
				T objectPoolObj = this.m_buildMethod();
				this.Store(objectPoolObj);
			}

	
			PoolManager.Instance.AddPool(this.namePool, this);
		}

		//Get element
		public T Get(bool create=true) {
			if (stack.Count == 0) {
				if (create) {
					return m_buildMethod();
				} else return null;
			} else return stack.Pop();
		}

		//Save element
		public void Store(T obj) {
			GameObject poolInScene = PoolManager.Instance.GetObjectPool(namePool);
			obj.transform.SetParent(poolInScene.transform);
			stack.Push(obj);
		}

		public string GetNamePool () {
			return this.namePool;
		}
	}
}

