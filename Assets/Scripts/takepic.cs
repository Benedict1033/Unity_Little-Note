using System.Collections;
using System.IO;
using UnityEngine;

public class takepic : MonoBehaviour
{
    private bool isScreenShot = false;
    private string ssPath;
    private string snFileName;

    string[] files = null;
    long a=1;

    public void Start()
    {
       

        isScreenShot = true;
        OnPostRender();
    }

    public void OnPostRender()
    {
        if (isScreenShot)
        {
            Rect rect = new Rect(0, 0, Screen.width, Screen.height);
            // 先創建一個的空紋理，大小可根據實現需要來設置
            Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);

            // 讀取屏幕像素信息並存儲爲紋理數據，
            screenShot.ReadPixels(rect, 0, 0);
            screenShot.Apply();

            // 然後將這些紋理數據，成一個png圖片文件
            byte[] bytes = screenShot.EncodeToPNG();
            //if (UIGame.instance != null)
            //    UIGame.instance.uiCamera.enabled = true;
            isScreenShot = false;

            StartCoroutine(SaveTexFile(bytes));
        }
    }

    IEnumerator SaveTexFile(byte[] imagebytes)
    {
#if UNITY_EDITOR_OSX
        ssPath = Application.persistentDataPath + "/";
#elif UNITY_ANDROID
        ssPath = Application.persistentDataPath.Substring(0, Application.persistentDataPath.IndexOf("Android")) + "/DCIM/LittleNote/";
#endif

        files = Directory.GetFiles(Application.persistentDataPath + "/", "*.png");

        DirectoryInfo di = new DirectoryInfo(ssPath);
        // Get a reference to each file in that directory.
        FileInfo[] fiArr = di.GetFiles();
        // Display the names and sizes of the files.

        foreach (FileInfo f in fiArr)
            a++;


        snFileName = a + ".png";

       
        

        if (!Directory.Exists(ssPath))
        {
            Directory.CreateDirectory(ssPath);
        }
        File.WriteAllBytes(ssPath + snFileName, imagebytes);//存儲png圖
        yield return new WaitForSeconds(0.1f);
        //UIGame.instance.ShowToast("已保存到相冊");
#if UNITY_ANDROID
        string[] paths = new string[1];
        paths[0] = ssPath + snFileName;
        ScanFile(paths);
#endif
    }

    void ScanFile(string[] path)
    {
      

        using (AndroidJavaClass PlayerActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject playerActivity = PlayerActivity.GetStatic<AndroidJavaObject>("currentActivity");
            using (AndroidJavaObject Conn = new AndroidJavaObject("android.media.MediaScannerConnection", playerActivity, null))
            {
                Conn.CallStatic("scanFile", playerActivity, path, null, null);
            }
        }

          //Application.Quit();
    }
}
