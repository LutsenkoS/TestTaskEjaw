using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundles : MonoBehaviour
{

    [MenuItem("Assets/Build Asset Bundles")]
    static void BuildAssetBundles()
    {
        string _assetBundleDirectory = DataController.AssetBundlesPath;
        if (!Directory.Exists(_assetBundleDirectory))
        {
            Directory.CreateDirectory(_assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(_assetBundleDirectory, BuildAssetBundleOptions.None,
            BuildTarget.StandaloneWindows);
    }

   

}
