using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        TextLoader loader = gameObject.AddComponent<TextLoader>();
        string text = loader.forceLoad("Assets/outasset/plot.plot");
        Debug.Log(text);
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    public void OnTest(string content)
    {
        LogSystem.inst.LogWithStack(content);
    }

    string testParam = "";
    string nowString = "";

    void OnGUI()
    {
        Rect rect;
        rect = new Rect(0, 0, 200, 50);
        nowString = GUI.TextField(rect, nowString);
        rect.yMax += 100;
        rect.yMin += 100;
        if (GUI.Button(rect, "submit"))
        {
            testParam = nowString;
            OnTest(testParam);
        }



    }
}
