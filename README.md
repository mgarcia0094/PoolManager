Example of use:

Pool<Object> objectPool = new Pool<Object>("ExamplePoolObject", delegate(){
    GameObject newObject = Instantiate(ObjectPrefab) as GameObject;
    Object objectComponent = newObject.GetComponent<ExampleComponent>();
    return newObject;
});

objectPool.Get();; //get element of pool
//or
PoolManager.Instance.GetPool("ExamplePoolObject").Get();
