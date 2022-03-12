using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CardEffectEditor : EditorWindow
{
    public Card card;

    [MenuItem("Tools/CardEffectEditor")]
    public static void OpenWindow()
    {
        GetWindow<CardEffectEditor>("Card Effect Builder");
    }

    private void OnGUI()
    {
        minSize = new Vector2(500, 200);
        ScriptableObject target = this;
        SerializedObject so = new SerializedObject(target);
        SerializedProperty cardProperty = so.FindProperty("card");
        EditorGUILayout.PropertyField(cardProperty, true);

        if(GUILayout.Button("Create Effects"))
        {
            CreateEffects();
        }

        so.ApplyModifiedProperties();
    }

    private void CreateEffects()
    {
        List<Effect> newEffects = new List<Effect>();
        foreach (Effect effect in card.effects)
        {
            ScriptableObject saveObj = ScriptableObject.CreateInstance(effect.GetType());
            AssetDatabase.CreateAsset(saveObj, $"Assets/ScriptableObjects/Effect/{card.name}_{effect.GetType()}.asset");
            newEffects.Add((Effect)saveObj);
        }
        card.effects = newEffects;
    }
}
