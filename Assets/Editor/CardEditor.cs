using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(Card))]
public class CardEditor : Editor
{
    /*
    SerializedProperty trigger;
    SerializedProperty mpCost;
    SerializedProperty effect;

    ScriptableObject saveObj;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        trigger = serializedObject.FindProperty("trigger");
        mpCost = serializedObject.FindProperty("MPCost");
        effect = serializedObject.FindProperty("effect");
        
        EditorGUILayout.PropertyField(trigger, new GUIContent("Trigger"));
        EditorGUILayout.PropertyField(mpCost, new GUIContent("MPCost"));
        EditorGUILayout.PropertyField(effect, new GUIContent("Effect"));

        Card card = (Card)target;
        Effect eff = card.effect;

        if (saveObj == null && eff != null)
        {
            saveObj = AssetDatabase.LoadAssetAtPath($"Assets/ScriptableObjects/Effect/{card.name}_{eff.GetType()}.asset", eff.GetType()) as ScriptableObject;
        }

        if (saveObj == null && eff != null)
        {
            saveObj = ScriptableObject.CreateInstance(eff.GetType());
            AssetDatabase.CreateAsset(saveObj, $"Assets/ScriptableObjects/Effect/{card.name}_{eff.GetType()}.asset");
        }

        if (saveObj != null)
        {
            Editor innerEditor = EffectEditor.CreateEditor(saveObj);
            innerEditor.DrawDefaultInspector();
        }

        serializedObject.ApplyModifiedProperties();
    }
    */
}
