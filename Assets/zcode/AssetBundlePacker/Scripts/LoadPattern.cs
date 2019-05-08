using UnityEngine;

namespace zcode.AssetBundlePacker
{
    /// <summary>加载方式</summary>
    public enum emLoadPattern
    {
        /// <summary>以AssetBundle的方式加载</summary>
        AssetBundle,
        /// <summary>以Resoureces目录下的资源加载</summary>
        Original,
#if UNITY_EDITOR
        /// <summary>本地资源加载方式（提供Editor下本地资源加载，主要用于开发阶段）</summary>
        EditorAsset,
#endif
        /// <summary>尝试以AssetBundle的方式加载， 失败再使用Resoureces目录下的资源加载,处于Editor模式下则以本地资源加载方式加载</summary>
        All,
    }

    public interface ILoadPattern
    {
        /// <summary>I资源加载方式</summary>
        emLoadPattern ResourcesLoadPattern { get; }

        /// <summary>I场景加载方式</summary>
        emLoadPattern SceneLoadPattern { get; }
    }

    /// <summary>默认的加载模式</summary>
    public class DefaultLoadPattern : ILoadPattern
    {

        /// <summary>资源加载方式</summary>
        public emLoadPattern ResourcesLoadPattern
        {
            get
            {
                Debug.Log("获取资源加载方式");
#if UNITY_EDITOR
                return emLoadPattern.EditorAsset;
#else
                return emLoadPattern.All;
#endif

            }
        }

        /// <summary>场景加载方式</summary>
        public emLoadPattern SceneLoadPattern
        {
            get
            {
#if UNITY_EDITOR
                return emLoadPattern.EditorAsset;
#else
                return emLoadPattern.All;
#endif
            }
        }
    }

    /// <summary>仅加载AssetBundle</summary>
    public class AssetBundleLoadPattern : ILoadPattern
    {

        /// <summary>资源加载方式</summary>
        public emLoadPattern ResourcesLoadPattern { get { return emLoadPattern.AssetBundle; } }

        /// <summary>场景加载方式</summary>
        public emLoadPattern SceneLoadPattern { get { return emLoadPattern.AssetBundle; } }
    }

    /// <summary>仅加载Resources目录下原始资源</summary>
    public class OriginalResourcesLoadPattern : ILoadPattern
    {
        /// <summary>资源加载方式</summary>
        public emLoadPattern ResourcesLoadPattern { get { return emLoadPattern.Original; } }

        /// <summary>场景加载方式</summary>
        public emLoadPattern SceneLoadPattern { get { return emLoadPattern.Original; } }
    }
}
