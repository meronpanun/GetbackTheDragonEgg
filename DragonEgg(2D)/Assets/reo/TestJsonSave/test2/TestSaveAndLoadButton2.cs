using UnityEngine;

namespace App.SaveSystem
{
    /// <summary>
    /// データのセーブとロード、デリート機能を持つボタン用関数群
    /// </summary>
    public class SaveAndLoadButton : MonoBehaviour
    {
        public void Save()
        {
            var saveData = SavedDataStore.SaveData;
            SaveAndLoadSystem<SaveData>.Save(saveData);
        }

        public void Load()
        {
            var loadedData = SaveAndLoadSystem<SaveData>.Load() ?? new SaveData();
            SavedDataStore.SaveData = loadedData;
            SavedDataStore.onLoadEvent?.Invoke();
        }

        public void Delete()
        {
            SaveAndLoadSystem<SaveData>.Delete();
        }
    }
}