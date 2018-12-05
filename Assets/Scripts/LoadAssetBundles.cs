using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadAssetBundles
{

    public static GameObject LoadAssetBundle(string name)
    {
        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(DataController.AssetBundlesPath, name));
        if (myLoadedAssetBundle == null)
        {
            Debug.Log("Failed to load AssetBundle!");
            return null;
        }
        GameObject prefab = myLoadedAssetBundle.LoadAsset<GameObject>(name);
        return prefab;
    }

}
