using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLoad : MonoBehaviour {

	// Use this for initialization
    List<AssetBundle> bundles = new List<AssetBundle>();
	void Start () {
        string basepath = "/Users/Balder/work/Unity/LogStack/Assets/outasset/assetbundle/res/";
        bundles.Add(AssetBundle.LoadFromFile(basepath + "500016.png"));
        bundles.Add(AssetBundle.LoadFromFile(basepath + "test1"));
        for (int i =0; i < bundles.Count; ++i)
        {
          //  Object[] objs = bundles[i].LoadAllAssets();
        //    Debug.Log(objs[0].name);
        }
        AssetBundle myLoadedAssetBundle = AssetBundle.LoadFromFile("/Users/Balder/work/Unity/LogStack/Assets/outasset/assetbundle/scene");
        string[] scenePaths = myLoadedAssetBundle.GetAllScenePaths();
        Debug.Log(scenePaths[0]);
        UnityEngine.SceneManagement.SceneManager.LoadScene(scenePaths[0]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
