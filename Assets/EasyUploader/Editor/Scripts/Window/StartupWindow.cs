using UnityEditor;
using UnityEngine;
using System.IO;
using static labels;
using static styles;

/*

public class StartupWindow : EditorWindow
{
    private Texture2D backgroundImage;
    private string version;
    private string[] languages = { "English", "日本語"};
    private int selectedLanguageIndex;
    private string settingsPath = "Assets/EasyUploader/settings.json";

    [InitializeOnLoad]
    public class Startup
    {
        static Startup()
        {
            EditorApplication.delayCall += () =>
            {
                // EasyUploaderWindow.Init();
                ShowWindow();
            };
        }
    }

    public class EasyUploaderWindow
    {
        [MenuItem("Easy Avatar Uploader for VRChat/Open EasyUploader_forVRC")]
        public static void Init()
        {
            EditorWindow window = EditorWindow.GetWindow(typeof(EasyUploader_forVRC));
            window.Show();
            window.maximized = true; // 最大化
        }
    }

    private void OnEnable()
    {
        // ウィンドウのサイズを設定
        minSize = new Vector2(800, 600);
        maxSize = new Vector2(800, 600);

        backgroundImage = AssetDatabase.LoadAssetAtPath<Texture2D>(@"Assets\EasyUploader\Editor\Resources\images\Welcome.jpg");

        // 言語設定を読み込む
        LoadLanguageSetting();
    }

    [MenuItem("Easy Avatar Uploader for VRChat/Welcome")]
    public static void ShowWindow()
    {
        StartupWindow window = (StartupWindow)EditorWindow.GetWindow(typeof(StartupWindow));
        window.Show();
    }

    void OnGUI()
    {
        // 背景として画像を描画
        if (backgroundImage != null)
        {
            GUI.DrawTexture(new Rect(0, 0, maxSize.x, maxSize.y), backgroundImage, ScaleMode.StretchToFill);
        }

        styles.Initialize();

        GUILayout.BeginArea(new Rect(position.width * 0.7f, position.height * 0.5f, position.width * 0.2f, position.height * 0.5f));

        // 言語のドロップダウン
        GUILayout.Label(labels.Changelng, styles.h2Style);
        int prevSelectedLanguage = selectedLanguageIndex;
        selectedLanguageIndex = EditorGUILayout.Popup(selectedLanguageIndex, languages);
        if (prevSelectedLanguage != selectedLanguageIndex)
        {
            SaveLanguageSetting();
            
            // 言語の更新
            labels.UpdateLanguage();
            helps.UpdateLanguage();
            msgs.UpdateLanguage();
        }


        // Startボタンを表示
        if (GUILayout.Button("Start", styles.MainButtonStyle))
        {
            EasyUploaderWindow.Init();
            Close();
        }

        string pathToPackageJson = @"Assets\EasyUploader\package.json";

        if (File.Exists(pathToPackageJson))
        {
            string jsonContent = File.ReadAllText(pathToPackageJson);
            PackageInfo packageInfo = JsonUtility.FromJson<PackageInfo>(jsonContent);
            GUILayout.Label("Version: " + packageInfo.version, styles.h2Style);
        }

        GUILayout.EndArea();
    }

    private void SaveLanguageSetting()
    {
        File.WriteAllText(settingsPath, $"{{ \"language\": \"{languages[selectedLanguageIndex]}\" }}");
    }

    private void LoadLanguageSetting()
    {
        if (File.Exists(settingsPath))
        {
            string jsonContent = File.ReadAllText(settingsPath);
            var settings = JsonUtility.FromJson<LanguageSetting>(jsonContent);
            selectedLanguageIndex = System.Array.IndexOf(languages, settings.language);
        }
    }

    [System.Serializable]

    private class PackageInfo
    {
        public string version;
    }

    [System.Serializable]
    private class LanguageSetting
    {
        public string language;
    }
}

*/