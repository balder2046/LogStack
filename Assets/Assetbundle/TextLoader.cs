using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class TextLoader : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }

    string GetAssetBundlePath(string path)
    {
        return Path.Combine(Application.streamingAssetsPath, path);
    }

    string LoadTextNotInEditor(string path)
    {
        path = GetAssetBundlePath(path);
        AssetBundle bundle = AssetBundle.LoadFromFile(path);
        TextAsset obj = (TextAsset)bundle.mainAsset;
        string text = Encoding.UTF8.GetString(obj.bytes);
        return  text;
    }

    public string forceLoad(string path)
    {
        AssetBundle bundle = AssetBundle.LoadFromFile(path);
        TextAsset obj = (TextAsset)bundle.LoadAsset("Assets/Test/plot.txt");
        string text = Encoding.UTF8.GetString(obj.bytes);
        return  text;
    }

    public string LoadText(string path)
    {
        TextAsset textRes = null;
        #if UNITY_EDITOR
        // 专门处理windows 的情况
        path = path.Replace("\\", "/");
        textRes = (TextAsset)UnityEditor.AssetDatabase.LoadAssetAtPath(path, typeof(TextAsset));
        return textRes.text;
        #else
        // 
        path = GetAssetBundlePath(path);
        #endif
        return "";

    }
}
