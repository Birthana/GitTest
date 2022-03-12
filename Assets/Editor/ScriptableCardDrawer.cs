using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomPropertyDrawer(typeof(Effect), true)]
[CanEditMultipleObjects]
public class ScriptableCardDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        EditorGUI.PropertyField(position, property, new GUIContent("Effect"));
        if (property.objectReferenceValue == null)
            return;
        ScriptableObject data = property.objectReferenceValue as ScriptableObject;
        SerializedObject so = new SerializedObject(data);
        SerializedProperty prop = so.GetIterator();
        float y = position.y + EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

        EditorGUI.indentLevel++;

        if (prop.NextVisible(true))
        {
            do
            {
                if (prop.name == "m_Script") continue;
                EditorGUI.PropertyField(new Rect(position.x, y, position.width, position.height), prop);
                y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            } while (prop.NextVisible(false));
        }

        if (GUI.changed)
            so.ApplyModifiedProperties();

        EditorGUI.indentLevel--;

        EditorGUI.EndProperty();
    }
}
