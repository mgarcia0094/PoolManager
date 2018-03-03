using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PM {

	public class Pool<T> where T : MonoBehaviour {
		
		private Stack<T> stack;
		public delegate T CreateObjectDelegate();
		public CreateObjectDelegate m_buildMethod;
		
		//build constructor
		public Pool(string namePool, int size, CreateObjectDelegate buildMethod) {
			stack = new Stack<T>();
			m_buildMethod = buildMethod;
			for (int i = 0; i < size; i++) {
				T objectPoolObj = buildMethod();
				Store(objectPoolObj);
			}
			PoolManager.Instance.AddPool(namePool, this);
		}

		//Get element
		public T Get(bool create=true) {
			if (stack.Count == 0) {
				if (create) 
					return m_buildMethod();
            	else return null;
			} else return stack.Pop();
		}

		//Save element
		public void Store(T obj) {
			stack.Push(obj);
		}

	}
}

