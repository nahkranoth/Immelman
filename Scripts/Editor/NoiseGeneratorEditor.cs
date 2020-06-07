using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NoiseGenerator))]
public class NoiseGeneratorEditor : Editor
{

    static Texture2D txt;

    private float txtSize = 128f;

    NoiseGenerator myTarget;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        myTarget = (NoiseGenerator)target;
        myTarget.slice = EditorGUILayout.Slider(myTarget.slice, 0, 1);

        if (GUILayout.Button("Generate"))
        {
            Generate();
        }

        if(txt == null) txt = new Texture2D(128, 128);
        GUILayout.Label(txt);
    }

    public void Generate()
    {
        for(int x = 0; x < txtSize; x++)
        {
            for (int y = 0; y < txtSize; y++)
            {
                var clr = myTarget.Noise(x / txtSize, y / txtSize);
                txt.SetPixel(x, y, new Color(clr, clr, clr, 1f) );
            }
        }
        txt.Apply();
    }
}
