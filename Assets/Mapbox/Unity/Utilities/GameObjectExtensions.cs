using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions
{
	public static void Destroy(this Object obj, bool deleteAsset = false)
	{
		if (Application.isEditor && !Application.isPlaying)
		{
			GameObject.DestroyImmediate(obj, deleteAsset);
		}
		else
		{
			GameObject.Destroy(obj);
		}
	}


    /// <summary>
    /// Returns the full hierarchy path of this GameObject, e.g. "Canvas/UI/Panel/MyButton".
    /// </summary>
    public static string GetHierarchyPath(this GameObject go)
    {
        string path = go.name;
        Transform t = go.transform.parent;
        while (t != null)
        {
            path = t.name + "/" + path;
            t = t.parent;
        }
        return path;
    }
}
