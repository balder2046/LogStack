using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Text;
using GameFramework;
using System.Threading;
using System.Collections;

public class EditorUtilityDisplayProgressBar : EditorWindow
{
    public float secs = 10f;
    public float startVal = 0f;
    public float progress = 0f;
    [MenuItem("Examples/Progress Bar Usage")]
    static void Init()
    {
        UnityEditor.EditorWindow window = GetWindow(typeof(EditorUtilityDisplayProgressBar));
        window.Show();
    }

    void OnGUI()
    {
       
       
        if (progress < secs)
            EditorUtility.DisplayProgressBar("Simple Progress Bar", "Shows a progress bar for the given seconds", progress / secs);
        else
            EditorUtility.ClearProgressBar();
        progress = (float)(EditorApplication.timeSinceStartup - startVal);
    }

    void OnInspectorUpdate()
    {
        Repaint();
    }
}

public class YieldTask
{
	public YieldTask(IEnumerator _steps)
	{
		steps = _steps;
	}
	IEnumerator steps;
	public string title = "set the title";
	public string info = "detail info";

	public void Update()
	{
		bool suc = true;
		while (suc) {
			suc = steps.MoveNext ();
			if (suc) {
				
			}
			else
			{
				EditorApplication.update = null;
				break;
			}
		}
	}
}


public class ExportAssertBundle
{
	public ExportAssertBundle ()
	{
		
	}
	class NewDepThread
	{
		public int start;
		public int count;
		public int nameStart = 0;
		public List<FileInfo> infoFiles;
		public HashSet<string> setDeps = new HashSet<string>();
		public IEnumerator Run()
		{
			for (int i = 0; i < count; ++i) {
				FileInfo info = infoFiles [i];
				string basestring = info.FullName.Substring (nameStart);
				string[] names = AssetDatabase.GetDependencies (basestring);
				foreach (var val in names)
				{
					setDeps.Add(val);
				}
				float progress = (float)i / count;
				EditorUtility.DisplayProgressBar("正在生成依赖",string.Format("生成 进度{0} / {1}",i,count),progress);

				yield return 0;
			}
			EditorUtility.ClearProgressBar ();
		}

	}
	[MenuItem("Assets/自动设置AB包信息")]
	public static void AutoSettingAllAssetBundleName(){
		List<GameFramework.ResourceInfo> resourceList = ResourceManager.GetAllResources (ResourceType.GENERERAL_AB);
		resourceList.AddRange(ResourceManager.GetScenesResource());
		List<FileInfo> infoAll = new List<FileInfo>();
		for (int i = 0; i < resourceList.Count; i++) {
			GameFramework.ResourceInfo info = resourceList [i];
			List<FileInfo> retInfos = ResourceManager.GeneralFileInfos (resourceList [i]);
			infoAll.AddRange (retInfos);
		}
		Debug.LogFormat("There is {0} items!" ,infoAll.Count);
		int startIndex = Application.dataPath.Length + 1 - 7;
		Debug.LogFormat ("fileinfo 0 is " + infoAll [0].FullName.Substring(startIndex));
		Debug.Log ("Start Get Depence");
		List<FileInfo> depList = new List<FileInfo> ();
	/*	HashSet<string> setDeps = new HashSet<string> ();
		foreach (FileInfo info in infoAll) {
			string assetPath = info.FullName.Substring (startIndex);
			setDeps.Add (assetPath);
			string[] filenames = AssetDatabase.GetDependencies (assetPath);
			foreach (var val in filenames)
			{
				setDeps.Add (val);
			}
		}*/

		{
			
			NewDepThread thread;
			thread = new NewDepThread ();
			thread.start = 0;
			thread.count = infoAll.Count;
			thread.nameStart = Application.dataPath.Length + 1 - 7;
			thread.infoFiles = infoAll;
			YieldTask task = new YieldTask (thread.Run());
			task.title = "信息";
			task.info = "生成信息";
			EditorApplication.update = task.Update;


		}

	//	string[] deps = AssetDatabase.GetDependencies ("Assets\\Fonts\\BossName.prefab");
		//Debug.LogFormat("the depend is {0}",setDeps.Count);

	}
}


