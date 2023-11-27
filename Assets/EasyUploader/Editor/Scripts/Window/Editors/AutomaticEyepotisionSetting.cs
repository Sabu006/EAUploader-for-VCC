using UnityEditor;
using UnityEngine;
using System.IO;
using System.Collections.Generic;
using static styles;

namespace EAUploaderEditors
{
    public class AutomaticEyepotisionSetting : EditorWindow
    {
        private static readonly string Windowname = "Automatic Eye Position Setting"; // ウィンドウの名前を定義
        private string selectedFolderPath = string.Empty;
        private Vector2 scrollPosition;
        private GameObject selectedVrcAvatar;
        private Dictionary<string, Texture2D> vrchatAvatarsWithPreview;
        public static void Open()
        {
            AutomaticEyepotisionSetting window = (AutomaticEyepotisionSetting)EditorWindow.GetWindow(typeof(AutomaticEyepotisionSetting), false, Windowname);
            window.Show();
            window.maximized = true;
        }

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();

            // 左側のUI
            GUILayout.BeginVertical(GUILayout.MaxWidth(position.width / 2));

            // フォルダ選択ボタン
            if (GUILayout.Button("フォルダー選択", MainButtonStyle))
            {
                selectedFolderPath = EditorUtility.OpenFolderPanel("フォルダーを選択", "", "");
            }

            // フォルダのパスを表示
            EditorGUILayout.LabelField("選択されたフォルダー:", selectedFolderPath);

            // モデルインポートボタン
            if (!string.IsNullOrEmpty(selectedFolderPath) && GUILayout.Button("Import Models from Folder"))
            {
                ImportModelsFromFolder(selectedFolderPath);
            }

            // 更新ボタン
            if (GUILayout.Button("リスト更新", SubButtonStyle))
            {
                vrchatAvatarsWithPreview = CustomPrefabUtility.GetVrchatAvatarList();
            }

            // VRC Avatarの一覧表示
            GUILayout.Label($"対象アバター: {vrchatAvatarsWithPreview?.Count ?? 0} 件", EditorStyles.boldLabel);
            scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(position.width / 2), GUILayout.Height(800));
            foreach (var kvp in vrchatAvatarsWithPreview)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Box(kvp.Value, GUILayout.Width(64), GUILayout.Height(64));
                GUILayout.Label(Path.GetFileNameWithoutExtension(kvp.Key));
                
                // View Positionのダミー表示
                GUILayout.Label("View Position: (0, 0, 0)"); // ここは実際の値に置き換える
                
                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();

            GUILayout.EndVertical();

            // 右側のUI
            GUILayout.BeginVertical();
            // ... 右側のUIのコード ...

            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
        }

        private void ImportModelsFromFolder(string folderPath)
        {
            string[] unityPackageFiles = Directory.GetFiles(folderPath, "*.unitypackage", SearchOption.AllDirectories);

            foreach (string packageFile in unityPackageFiles)
            {
                // Unityパッケージの存在確認は直接ファイルシステムで行います
                if (File.Exists(packageFile))
                {
                    AssetDatabase.ImportPackage(packageFile, false);
                }
            }
        }
    }
}
