using System;
using System.IO;
using UnityEngine;

namespace App.SaveSystem
{
    public static class SaveAndLoadSystem<T> where T : class, new()
    {
        private const string FolderName = "SaveData";

        public static void Save(T data)
        {
            var jsonData = JsonUtility.ToJson(data); // json形式に変換

            using (var sw = new StreamWriter(GetPath(data), false)) // 上書き(データがないなら新規作成)
            {
                try
                {
                    sw.Write(jsonData); // セーブ
                    Debug.Log($"Saved {data.GetType().Name} : \n{jsonData}"); // debugonly
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }

        public static T Load()
        {
            var data = new T();
            try
            {
                using (var fs = new FileStream(GetPath(data), FileMode.OpenOrCreate))
                {
                    using (var sr = new StreamReader(fs))
                    {
                        var jsonData = sr.ReadToEnd();
                        Debug.Log($"Loaded {data.GetType().Name} : \n{jsonData}"); // debugonly
                        data = JsonUtility.FromJson<T>(jsonData);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return null;
            }
            return data;
        }
        public static void Delete()
        {
            File.Delete(GetPath(new T())); // 指定したパスのファイルを削除
            Debug.Log($"Delete SaveData");
        }

    private static string GetPath(T data)
        {
            var directoryPath = Application.persistentDataPath + "\\" + FolderName;
            Directory.CreateDirectory(directoryPath); // 指定したパスにフォルダがないなら, フォルダを新規作成
            return directoryPath + $"\\{data.GetType().Name}" + ".json";
        }
    }
}