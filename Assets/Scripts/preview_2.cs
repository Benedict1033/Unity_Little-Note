using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections;

public class preview_2 : MonoBehaviour
{
    [SerializeField]
    Image image;
    //public Image image2;
    string[] files = null;
    int whichScreenShotIsShown = 0;

    private string ssPath;


    private void Start()
    {
        Invoke("wait", 0.5f);
    }

    void wait()
    {

#if UNITY_EDITOR_OSX
        ssPath = Application.persistentDataPath + "/";
#elif UNITY_ANDROID
        ssPath = Application.persistentDataPath.Substring(0, Application.persistentDataPath.IndexOf("Android")) + "/DCIM/LittleNote/";
#endif
        files = Directory.GetFiles(ssPath);

        DirectoryInfo di = new DirectoryInfo(ssPath);
        // Get a reference to each file in that directory.
        FileInfo[] fiArr = di.GetFiles();
        // Display the names and sizes of the files.

        foreach (FileInfo f in fiArr)
            whichScreenShotIsShown++;

        Now();

    }
    void GetPictureAndShowIt()
    {
        string pathToFile = files[whichScreenShotIsShown];
        Texture2D texture = GetScreenshotImage(pathToFile);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
        image.GetComponent<Image>().sprite = sp;


        if (Distance.howmany == 2)
        {
      //      string pathToFile2 = files[whichScreenShotIsShown - 1];
      //      Texture2D texture2 = GetScreenshotImage(pathToFile);
      //      Sprite sp2 = Sprite.Create(texture2, new Rect(0, 0, texture2.width, texture2.height),
      //new Vector2(0.5f, 0.5f));
      //      image2.GetComponent<Image>().sprite = sp2;
     

        }
        else { }

    }

    Texture2D GetScreenshotImage(string filePath)
    {
        Texture2D texture = null;
        byte[] fileBytes;
        if (File.Exists(filePath))
        {
            fileBytes = File.ReadAllBytes(filePath);
            texture = new Texture2D(2, 2, TextureFormat.RGB24, false);
            texture.LoadImage(fileBytes);
        }
        return texture;
    }


    public void Now()
    {
        if (files.Length > 0)
        {
            whichScreenShotIsShown = files.Length - 1;
            GetPictureAndShowIt();

        }
    }

}
