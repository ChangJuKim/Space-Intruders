using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CardData))]
public class CardDataEditor : Editor
{
    private static List<System.Type> _availableTypes;
    private static GUIContent[] _dropDownOptions;

    static CardDataEditor()
    {
        _availableTypes = GetTypes((t) => typeof(ICardEffect).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract).ToList();
        _dropDownOptions = _availableTypes.Select(t => new GUIContent(t.Name)).ToArray();
    }

    public override void OnInspectorGUI()
    {
        CardData myCard = (CardData)target;

        DrawDefaultInspector();

        this.serializedObject.Update();
        var prop = this.serializedObject.FindProperty("effect");

        if (prop == null)
        {
            Debug.LogError("CardData does not have property \"effect\"");
        }
        else if ((prop.isExpanded = EditorGUILayout.Foldout(prop.isExpanded, prop.displayName)))
        {
            EditorGUI.indentLevel++;
            int index = GetIndexOf(_availableTypes, (t) => GetUnityFormattedFullTypeName(t) == prop.managedReferenceFullTypename);
            EditorGUI.BeginChangeCheck();
            index = EditorGUILayout.Popup(index, _dropDownOptions);
            if (EditorGUI.EndChangeCheck())
            {
                var tp = index >= 0 ? _availableTypes[index] : null;
                var obj = tp != null ? System.Activator.CreateInstance(tp) : null;
                prop.managedReferenceValue = obj;
                this.serializedObject.ApplyModifiedProperties();
            }
            if (prop.hasChildren)
            {
                while (prop.NextVisible(true))
                {
                    EditorGUILayout.PropertyField(prop);
                }
            }

            EditorGUI.indentLevel--;
        }


        this.serializedObject.ApplyModifiedProperties();

    }

    public static IEnumerable<System.Type> GetTypes(System.Func<System.Type, bool> predicate)
    {
        foreach (var assemb in System.AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var tp in assemb.GetTypes())
            {
                if (predicate == null || predicate(tp)) yield return tp;
            }
        }
    }

    public static int GetIndexOf(IList<System.Type> lst, System.Func<System.Type, bool> predicate)
    {
        for (int i = 0; i < lst.Count; i++)
        {
            if (predicate(lst[i])) return i;
        }
        return -1;
    }

    public static string GetUnityFormattedFullTypeName(System.Type tp)
    {
        return string.Format("{0} {1}", tp.Assembly.GetName().Name, tp.FullName);
    }
}
