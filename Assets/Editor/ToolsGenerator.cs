using System.IO;
using UnityEditor;
using UnityEngine;
using System.Text;
using UnityEditor.PackageManager;

public static class ToolsGenerator
{
    [MenuItem("Tools/Generate package.json")]
    static void Generate()
    {
        string pluginFolder = "Assets/admob-sdk-update-checker";

        string packagePath = Path.Combine(
            Path.GetFullPath(pluginFolder),
            "package.json");

        string company = Sanitize(PlayerSettings.companyName);
        if (string.IsNullOrWhiteSpace(company))
            company = "company";

        string product = Sanitize(PlayerSettings.productName);
        if (string.IsNullOrWhiteSpace(product))
            product = "package";

        string packageName = $"com.{company}.{product}";

        string displayName = string.IsNullOrWhiteSpace(PlayerSettings.productName)
            ? "My Package"
            : PlayerSettings.productName;

        string version = string.IsNullOrWhiteSpace(PlayerSettings.bundleVersion)
            ? "1.0.0"
            : PlayerSettings.bundleVersion;

        string unity = GetUnityVersion();

        string dependencies = GenerateDependencies();

        string json =
        $@"{{
            ""name"": ""{packageName}"",
            ""displayName"": ""{displayName}"",
            ""version"": ""{version}"",
            ""unity"": ""{unity}"",
            ""description"": ""Plugin for Unity."",
            ""author"": {{
                ""name"": ""{PlayerSettings.companyName}""
            }},
            ""dependencies"": {dependencies}
        }}";

        File.WriteAllText(packagePath, json);

        AssetDatabase.Refresh();

        Debug.Log("package.json generated successfully!");
    }

    static string Sanitize(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "";

        value = value.ToLower();

        foreach (char c in Path.GetInvalidFileNameChars())
            value = value.Replace(c.ToString(), "");

        value = value.Replace(" ", "");
        value = value.Replace("_", "");
        value = value.Replace("-", "");

        return value;
    }

    static string GetUnityVersion()
    {
        string[] parts = Application.unityVersion.Split('.');

        return parts.Length >= 2
            ? $"{parts[0]}.{parts[1]}"
            : Application.unityVersion;
    }

    static string GenerateDependencies()
    {
        UnityEditor.PackageManager.PackageInfo[] packages =
            UnityEditor.PackageManager.PackageInfo.GetAllRegisteredPackages();

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("{");

        bool first = true;

        foreach (var p in packages)
        {
            // Lewati package bawaan Unity
            if (p.source == PackageSource.BuiltIn)
                continue;

            if (!first)
                sb.AppendLine(",");

            sb.Append($"    \"{p.name}\": \"{p.version}\"");

            first = false;
        }

        sb.AppendLine();
        sb.Append("  }");

        return sb.ToString();
    }
}