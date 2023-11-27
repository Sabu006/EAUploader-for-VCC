using System.IO;
using UnityEngine;

public static class PackageVersionReader
{
    private const string PackagePath = "/package.json";

    public static string GetCurrentVersion()
    {
        string jsonContent = File.ReadAllText(PackagePath);
        var packageInfo = JsonUtility.FromJson<PackageInfo>(jsonContent);
        return packageInfo.version;
    }

    [System.Serializable]
    private class PackageInfo
    {
        public string version;
        // ... その他の必要なフィールド
    }
}
