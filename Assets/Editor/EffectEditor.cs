using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EffectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        if (target == null || serializedObject == null)
            return;
        SerializedProperty prop = serializedObject.GetIterator();
        if (prop.NextVisible(true))
        {
            do
            {
                if (prop.name == "m_Script") continue;
                EditorGUILayout.PropertyField(prop, new GUIContent(prop.name));
            } while (prop.NextVisible(false));
        }
        serializedObject.ApplyModifiedProperties();
    }
}
