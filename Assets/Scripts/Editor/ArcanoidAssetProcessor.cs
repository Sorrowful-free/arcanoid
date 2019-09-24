using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class ArcanoidAssetProcessor:AssetPostprocessor
    {
        private const string RESOURCES_PATH = "Assets/Resources";
        private const string PREFAB_EXTENTION = ".prefab";
        private const string RESOURCES_NAMES_FILE_PATH = "Scripts/ResourcesNames.generated.cs";
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets,
            string[] movedFromAssetPaths)
        {
            var allPrefabsInResources = AssetDatabase.GetAllAssetPaths()
                .Where(e => e.StartsWith(RESOURCES_PATH) && e.EndsWith(PREFAB_EXTENTION)).Select(e=>e.Substring(RESOURCES_PATH.Length+1).Replace(PREFAB_EXTENTION,""));
            GenerateReosurcesFileCS(allPrefabsInResources.ToArray());
        }

        private static void GenerateReosurcesFileCS(string[] prefabs)
        {
            if(prefabs.Length <=0)
                return;
            var prefabsNamesStrings = prefabs.Select(e =>
                "\t\t\tpublic const string " + (e.ToUpper()
                    .Replace("\\", "_")
                    .Replace("/", "_")
                    .Replace(" ","_")) + " = \"" + e + "\";");
            var fileString = "namespace DefaultNamespace\n" +
                             "{\n" +
                             "\tpublic static class ResourcesNames\n" +
                             "\t{\n" +
                             "\t\tpublic static class PrefabsNames\n" +
                             "\t\t{\n" +
                             string.Join("\n",prefabsNamesStrings) +"\n"+
                             "\t\t}\n" +
                             "\t}\n" +
                             "}\n";
            File.WriteAllText(Path.Combine(Application.dataPath,RESOURCES_NAMES_FILE_PATH),fileString);
        }
    }
}