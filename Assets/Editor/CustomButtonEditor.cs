using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(CustomButton))]
public class CustomButtonEditor : ButtonEditor
{
    private SerializedProperty _clickSound;
    private SerializedProperty _onSprite;
    private SerializedProperty _offSprite;
    private SerializedProperty _initialState;

    protected override void OnEnable()
    {
        base.OnEnable();

        _clickSound = serializedObject.FindProperty("_clickSound");
        _onSprite = serializedObject.FindProperty("_onSprite");
        _offSprite = serializedObject.FindProperty("_offSprite");
        _initialState = serializedObject.FindProperty("_isInitialOn");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        EditorGUILayout.PropertyField(_clickSound);
        EditorGUILayout.PropertyField(_onSprite);
        EditorGUILayout.PropertyField(_offSprite);
        EditorGUILayout.PropertyField(_initialState);

        serializedObject.ApplyModifiedProperties();
    }
}