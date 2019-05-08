using GS.AssetBundlePacker;
using System.Collections;
using UnityEngine;

namespace GS
{
    /// <summary>协同执行器</summary>
    public class CoroutineExecutor : MonoBehaviour
    {
        /// <summary>回调函数</summary>
        public System.Action DoneCallback;

        // Use this for initialization
        void Start()
        {
            //此层次下的所有对象禁止被删除
            DontDestroyOnLoad(transform.gameObject);
        }

        /// <summary>执行</summary>
        void Do(AsyncOperation ao, System.Action callback)
        {
            DoneCallback = callback;
            StartCoroutine(_WaitForDone(ao));
        }

        IEnumerator _WaitForDone(AsyncOperation ao)
        {
            if (ao != null)
            {
                while (!ao.isDone)
                    yield return null;
            }

            if (DoneCallback != null)
                DoneCallback();

            Destroy(this.gameObject);
        }

        /// <summary>执行</summary>
        void Do(IEnumerator routine, System.Action callback)
        {
            DoneCallback = callback;
            StartCoroutine(_WaitForDone(routine));
        }
        IEnumerator _WaitForDone(IEnumerator routine)
        {
            if (routine != null)
            {
                yield return routine;
            }

            if (DoneCallback != null)
                DoneCallback();

            Destroy(this.gameObject);
        }

        /// <summary>执行</summary>
        void Do(SceneLoadRequest req, System.Action callback)
        {
            DoneCallback = callback;
            StartCoroutine(_WaitForDone(req));
        }
        IEnumerator _WaitForDone(SceneLoadRequest req)
        {
            if (req != null)
            {
                while (!req.IsDone)
                    yield return null;
            }

            if (DoneCallback != null)
                DoneCallback();

            Destroy(this.gameObject);
        }

        public static void Create(AsyncOperation ao, System.Action callback)
        {
            GameObject go = new GameObject();
            CoroutineExecutor executor = go.AddComponent<CoroutineExecutor>();
            if (executor != null)
            {
                executor.Do(ao, callback);
            }
        }

        public static void Create(IEnumerator routine, System.Action callback)
        {
            GameObject go = new GameObject();
            CoroutineExecutor executor = go.AddComponent<CoroutineExecutor>();
            if (executor != null)
            {
                executor.Do(routine, callback);
            }
        }

        public static void Create(SceneLoadRequest req, System.Action callback)
        {
            GameObject go = new GameObject();
            CoroutineExecutor executor = go.AddComponent<CoroutineExecutor>();
            if (executor != null)
            {
                executor.Do(req, callback);
            }
        }

    }
}
