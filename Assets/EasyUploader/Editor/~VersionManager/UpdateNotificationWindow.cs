using UnityEditor;
using UnityEngine;

public class UpdateNotificationWindow : EditorWindow
{
    private string versionInfo;
    private string richTextInfo;

    public static void ShowWindow(string version, string richText)
    {
        UpdateNotificationWindow window = (UpdateNotificationWindow)EditorWindow.GetWindow(typeof(UpdateNotificationWindow));
        window.versionInfo = version;
        window.richTextInfo = richText;
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("New Version Available: " + versionInfo, EditorStyles.boldLabel);
        GUILayout.TextArea(richTextInfo, GUILayout.ExpandHeight(true));
    }
}
