using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetbundleExport : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }

    [MenuItem("Assetbundle/Build Text Asset ")]
    public static void BuildTextAsset()
    {
        BuildPipeline.BuildAssetBundles("Assets/outasset", BuildAssetBundleOptions.None, BuildTarget.StandaloneOSXIntel64);   
    }
}
