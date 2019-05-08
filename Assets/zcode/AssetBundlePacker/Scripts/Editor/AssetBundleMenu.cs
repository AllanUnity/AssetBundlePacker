using GS.AssetBundlePacker;
using UnityEditor;

namespace GS
{
    /// <summary>AssetBundle相关菜单项</summary>
    public class AssetBundleMenu 
    {
        protected AssetBundleMenu() { }

        #region Step 1
        [MenuItem("AssetBundle/Step-1 打包AssetBundle", false, 51)]
        static void BuildAssetBundle_Step1()
        {
            AssetBundleBuildWindow.Open();
        }
        #endregion

        #region Step 2
        [MenuItem("AssetBundle/Step-2 配置AssetBundle", false, 52)]
        static void OpenAssetBundleBrowse_Step2()
        {
            AssetBundleBrowseWindow.Open();
        }
        #endregion

        #region Step 3
        [MenuItem("AssetBundle/Step-3 配置AssetBundle资源包", false, 53)]
        static void OpenAssetBundlePack_Step3()
        {
            ResourcesPackageWindow.Open();
        }
        #endregion
    }
}