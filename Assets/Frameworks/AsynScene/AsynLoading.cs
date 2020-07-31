using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
namespace AsynLoading
{
    public class AsynLoading : MonoBehaviour
    {

        private AsyncOperation op;
        private static string LoadingName;
        void Start()
        {
            Resources.UnloadUnusedAssets();
            StartCoroutine(StartLoadingRealTime(LoadingName));
        }

        public static void LoadScene(string name)
        {
            LoadingName = name;
            AsynSceneListener.dispatchEvent(AsynSceneEvent.StartLoadSence, null);
            Application.LoadLevel("Loading");

        }

        /// <summary>
        /// 固定时间加载完成
        /// </summary>
        /// <param name="scene"></param>
        /// <returns></returns>
        private IEnumerator StartLoadingFixTime(string scene)
        {
            float tempTime = Time.time;
            int displayProgress = 0;
            int toProgress = 100;
            op = Application.LoadLevelAsync(scene);
            op.allowSceneActivation = false;
            while (displayProgress < toProgress)
            {
                displayProgress += 2;
                AsynSceneListener.dispatchEvent(AsynSceneEvent.UpdatePregress, (float)displayProgress / 100f);
                yield return new WaitForEndOfFrame();
            }
            if (displayProgress > 99)
            {
                op.allowSceneActivation = true;
            }

            Debug.Log("Time:" + (Time.time - tempTime));

        }

        /// <summary>
        /// 真实时间加载场景完成(小场景会一瞬间加载完成）
        /// </summary>
        /// <param name="scene"></param>
        /// <returns></returns>
        private IEnumerator StartLoadingRealTimeImmediately(string scene)
        {
            op = Application.LoadLevelAsync(scene);
            op.allowSceneActivation = false;
            while (op.progress < 0.9f)
            {
                AsynSceneListener.dispatchEvent(AsynSceneEvent.UpdatePregress, (float)op.progress / 100f);
                yield return new WaitForEndOfFrame();
            }
            AsynSceneListener.dispatchEvent(AsynSceneEvent.UpdatePregress, 1f);
            yield return new WaitForEndOfFrame();
            op.allowSceneActivation = true;

        }

        private IEnumerator StartLoadingRealTime(string scene)
        {
            op = Application.LoadLevelAsync(scene);
            op.allowSceneActivation = false;
            int displayProgress = 0;
            int toProgress = 0;
            while (op.progress < 0.9f)
            {
                toProgress = (int)(op.progress * 100);
                while (displayProgress < toProgress)
                {
                    displayProgress += 2;
                    AsynSceneListener.dispatchEvent(AsynSceneEvent.UpdatePregress, (float)displayProgress / 100f);
                }
                yield return new WaitForEndOfFrame();
            }

            toProgress = 100;
            while (displayProgress < toProgress)
            {
                displayProgress += 2;
                AsynSceneListener.dispatchEvent(AsynSceneEvent.UpdatePregress, (float)displayProgress / 100f);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();
            op.allowSceneActivation = true;

        }

    }
}
