using UnityEditor;
using UnityEngine;
using System.Collections;

[InitializeOnLoad]
public class StartupVersionChecker
{
    static StartupVersionChecker()
    {
        EditorApplication.update += CheckVersion;
    }

    private static void CheckVersion()
    {
        EditorApplication.update -= CheckVersion;

        string currentVersion = PackageVersionReader.GetCurrentVersion();
        GitHubVersionFetcher.FetchLatestVersion((latestVersion) =>
        {
            if (latestVersion != currentVersion)
            {
                UpdateNotificationWindow.ShowWindow(latestVersion, "ここにリッチテキスト形式の更新情報を追加");
            }
        });
    }
}
