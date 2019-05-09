using UnityEngine;

/// <summary>继承MonoBehaviour的单例</summary>
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    /// <summary>单例实例</summary>
	private static T instance_ = null;
    public static T Instance
    {
        get
        {
            if (instance_ == null)
            {
                instance_ = Object.FindObjectOfType(typeof(T)) as T;
                if (instance_ == null)
                {
                    if (Application.isPlaying)
                    {
                        instance_ = new GameObject("SingletonOf:" + typeof(T).ToString(), typeof(T)).GetComponent<T>();
                        DontDestroyOnLoad(instance_);
                    }
                }
            }
            return instance_;
        }
    }

    /// <summary>创建单例实例</summary>
    public static T CreateSingleton()
    {
        if (instance_ == null)
            Instance.Init();
        return Instance;
    }
    protected virtual void Init()
    {

    }

    /// <summary>确保在程序退出时销毁实例。</summary>
    protected virtual void OnApplicationQuit()
    {
        instance_ = null;
    }
}