using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePair<T1,T2>
{
    public T1 value1;
    public T2 value2;

    public SimplePair(T1 t1,T2 t2)
    {
        value1 = t1;
        value2 = t2;
    }
}

[System.Serializable]
public class SimplePairWithGameObjectVector2 : SimplePair<GameObject, Vector2>
{
    public SimplePairWithGameObjectVector2(GameObject obj,Vector2 pos): base(obj,pos) { }
}
