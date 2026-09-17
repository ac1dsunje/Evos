using System;
using System.Collections.Generic;
using System.Reflection;
using _Game.Scripts.ECS;
using _Game.Scripts.ECS.Components;
using FFS.Libraries.StaticEcs.Unity.Editor;
using UnityEditor;

namespace Editor
{
    public class GameEcsView : StaticEcsView<GameWorld, EntityProvider, EventProvider>
    {
        [MenuItem("Window/StaticECS/OpenView")]
        public static void OpenWindow()
        {
            EnsureEntityNameColumn();
            var window = GetWindow<GameEcsView>();
            window.Show();
            window.Focus();
        }

        private static void EnsureEntityNameColumn()
        {
            Type configType = typeof(StaticEcsViewConfig);
            PropertyInfo activeProperty = configType.GetProperty("Active", BindingFlags.Static | BindingFlags.NonPublic);

            if (activeProperty == null)
                return;

            object config = activeProperty.GetValue(null);

            if (config == null)
                return;

            MethodInfo getOrCreateMethod = configType.GetMethod("GetOrCreate", BindingFlags.Instance | BindingFlags.NonPublic);

            if (getOrCreateMethod == null)
                return;

            object worldSettings = getOrCreateMethod.Invoke(config, new object[] { typeof(GameWorld).FullName });

            if (worldSettings == null)
                return;

            object entities = GetFieldValue(worldSettings, "entities");

            if (entities == null)
                return;

            List<string> componentColumns = GetStringList(entities, "componentColumns");
            List<string> showTableDataTypes = GetStringList(entities, "showTableDataTypes");
            List<string> tagColumns = GetStringList(entities, "tagColumns");

            if (componentColumns == null || showTableDataTypes == null || tagColumns == null)
                return;

            tagColumns.Clear();
            MoveValueToStart(componentColumns, NameComponent.EditorFullName);
            AddValue(showTableDataTypes, NameComponent.EditorFullName);
            MethodInfo saveMethod = configType.GetMethod("Save", BindingFlags.Instance | BindingFlags.NonPublic);

            if (saveMethod != null)
            {
                saveMethod.Invoke(config, null);
            }
        }

        private static object GetFieldValue(object owner, string fieldName)
        {
            FieldInfo field = owner.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Public);

            if (field == null)
                return null;

            return field.GetValue(owner);
        }

        private static List<string> GetStringList(object owner, string fieldName)
        {
            return GetFieldValue(owner, fieldName) as List<string>;
        }

        private static void MoveValueToStart(List<string> values, string value)
        {
            values.Remove(value);
            values.Insert(0, value);
        }

        private static void AddValue(List<string> values, string value)
        {
            if (!values.Contains(value))
            {
                values.Add(value);
            }
        }
    }
}
