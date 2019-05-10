using UnityEngine;

namespace GS
{
    /// <summary>平台相关</summary>
    public static class Platform
    {
#if UNITY_EDITOR
        public static string StreamingAssetsPath = Application.streamingAssetsPath;
        public static string PersistentAssetsPath = Application.dataPath + "/PersistentAssets";
        public static string CacheCurrentDirectoryPath = System.IO.Directory.GetCurrentDirectory();
#elif UNITY_STANDALONE_WIN
        public static string StreamingAssetsPath = Application.streamingAssetsPath;
        public static string PersistentAssetsPath = Application.dataPath + "/PersistentAssets";
        public static string CacheCurrentDirectoryPath = Application.dataPath + "/PersistentAssets";
#elif UNITY_IPHONE
        public static string StreamingAssetsPath = Application.streamingAssetsPath;
        public static string PersistentAssetsPath = Application.persistentDataPath;
        public static string CacheCurrentDirectoryPath = Application.persistentDataPath;
#elif UNITY_ANDROID
        public static string StreamingAssetsPath = Application.streamingAssetsPath;
        public static string PersistentAssetsPath = Application.persistentDataPath;
        public static string CacheCurrentDirectoryPath = Application.persistentDataPath;
#endif
    }
}
