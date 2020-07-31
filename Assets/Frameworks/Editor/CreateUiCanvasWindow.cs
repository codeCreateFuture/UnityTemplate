using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
 *   public class UIRoot : MonoBehaviour
    {
        public Transform Bg;
        public Transform Common;
        public Transform PopUp;
        public Transform Forward;
        [SerializeField] private Canvas mRootCanvas;
    }
    */


namespace EditorExtension
{
    /// <summary>
    /// 通过menuItem生成Ui必备组件和为脚本赋值
    /// </summary>
    public class CreateUiCanvasWindow : EditorWindow
    {

        static string UiCanvasName = "UiCanvas";

        [MenuItem("编辑器扩展/1.SetupUiCanvas %u", true)]
        static bool ValidateUIRoot()
        {
            return !GameObject.Find("UiCanvas");
        }

        private string mWidth = "720";
        private string mHeight = "1280";

        private void OnGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("width:", GUILayout.Width(45));
            mWidth = GUILayout.TextField(mWidth);
            GUILayout.Label("x", GUILayout.Width(10));
            GUILayout.Label("height:", GUILayout.Width(50));
            mHeight = GUILayout.TextField(mHeight);
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Generate"))
            {
                var width = float.Parse(mWidth);
                var height = float.Parse(mHeight);

                Setup(width, height);

                Close();
            }
        }

        [MenuItem("编辑器扩展/1.SetupUiCanvas %u")]
        static void SetupUIRoot()
        {
            var window = GetWindow<CreateUiCanvasWindow>();

            window.Show();
        }

        static void Setup(float width, float height)
        {
          
            var canvas = new GameObject(UiCanvasName);
    
            canvas.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

            // CanvasScaler
            var canvasScaler = canvas.AddComponent<CanvasScaler>();

            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(width, height);

            canvas.AddComponent<GraphicRaycaster>();

            canvas.layer = LayerMask.NameToLayer("UI");

            // EventSystem
            var eventSystem = new GameObject("EventSystem");

            eventSystem.transform.SetParent(canvas.transform);

            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
            eventSystem.layer = LayerMask.NameToLayer("UI");

            // Bg
            var bgObj = new GameObject("Bg");
            bgObj.AddComponent<RectTransform>();
            bgObj.transform.SetParent(canvas.transform);
            bgObj.transform.localPosition = Vector3.zero;

           // uirootScript.Bg = bgObj.transform;
            // Common

            var commonObj = new GameObject("Common");
            commonObj.AddComponent<RectTransform>();
            commonObj.transform.SetParent(canvas.transform);
            commonObj.transform.localPosition = Vector3.zero;

            //uirootScript.Common = commonObj.transform;
            // PopUI
            var popUp = new GameObject("PopUp");
            popUp.AddComponent<RectTransform>();
            popUp.transform.SetParent(canvas.transform);
            popUp.transform.localPosition = Vector3.zero;

           // uirootScript.PopUp = popUp.transform;

            // Forward
            var forwardObj = new GameObject("Forward");
            forwardObj.AddComponent<RectTransform>();
            forwardObj.transform.SetParent(canvas.transform);
            forwardObj.GetComponent<RectTransform>().localPosition = Vector3.zero;

         //   uirootScript.Forward = forwardObj.transform;


           // var uirootScriptSerializedObj = new SerializedObject(uirootScript);

            //序列化私有属性
          //  uirootScriptSerializedObj.FindProperty("mRootCanvas").objectReferenceValue = canvas.GetComponent<Canvas>();
          //  uirootScriptSerializedObj.ApplyModifiedPropertiesWithoutUndo();


            // 制作 prefab
            var savedFolder = Application.dataPath + "/Resources";
           // var savedFolder = "Resources";

            if (!Directory.Exists(savedFolder))
            {
                Directory.CreateDirectory(savedFolder);
            }

            var savedFilePath = savedFolder + "/"+ UiCanvasName+".prefab";
            // var savedFilePath = savedFolder;

#if UNITY_2018
            //生成prefab
             PrefabUtility.SaveAsPrefabAssetAndConnect(canvas, savedFilePath, InteractionMode.AutomatedAction);
#endif


            // PrefabUtility.CreatePrefab(savedFilePath, uiRootObj);
        }
    }
}
