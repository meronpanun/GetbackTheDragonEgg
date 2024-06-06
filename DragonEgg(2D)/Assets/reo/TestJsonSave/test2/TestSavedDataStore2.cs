using UnityEngine.Events;

namespace App.SaveSystem
{
    /// <summary>
    /// セーブデータを読み込んだもの
    /// </summary>
    public static class SavedDataStore
    {
        public static UnityEvent onLoadEvent = new UnityEvent(); // ロード時に呼ばれるイベント
        public static SaveData SaveData
        {
            get => saveData;
            set => saveData = value;
        }
        private static SaveData saveData = new SaveData();
    }
}