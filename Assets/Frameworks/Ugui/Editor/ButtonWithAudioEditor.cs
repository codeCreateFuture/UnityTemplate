using UnityEditor;
using UnityEditor.UI;
[CustomEditor(typeof(ButtonWithAudio))]
[CanEditMultipleObjects]
public class ButtonWithAudioEditor : ButtonEditor
{

    private SerializedObject obj;
    private SerializedProperty enterClip;
    private SerializedProperty clickClip;
    private SerializedProperty exitClip;

    protected override void OnEnable()
    {
        base.OnEnable();
        obj = new SerializedObject(target);
        enterClip = obj.FindProperty("enterClip");
        clickClip = obj.FindProperty("clickClip");
        exitClip = obj.FindProperty("exitClip");

    }



    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();
        obj.Update();
        EditorGUILayout.PropertyField(enterClip);
        EditorGUILayout.PropertyField(clickClip);
        EditorGUILayout.PropertyField(exitClip);
        obj.ApplyModifiedProperties();
    }
}
