using UnityEngine;
using System.Collections;

public static class GitHubVersionFetcher
{
    private const string RepositoryURL = "https://api.github.com/repos/{ユーザ名}/{リポジトリ名}/releases/latest";

    public static IEnumerator FetchLatestVersion(System.Action<string> callback)
    {
        using (WWW www = new WWW(RepositoryURL))
        {
            yield return www;
            if (string.IsNullOrEmpty(www.error))
            {
                var json = www.text;
                var latestVersion = JsonUtility.FromJson<GitHubRelease>(json);
                callback?.Invoke(latestVersion.tag_name);
            }
            else
            {
                Debug.LogError("Failed to fetch the latest version: " + www.error);
            }
        }
    }

    [System.Serializable]
    private class GitHubRelease
    {
        public string tag_name;
        // ... その他の必要なフィールド
    }
}
