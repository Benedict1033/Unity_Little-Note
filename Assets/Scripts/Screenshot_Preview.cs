using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Collections;

public class Screenshot_Preview : MonoBehaviour
{
    [SerializeField]
    Image image;
    string[] files = null;
    int whichScreenShotIsShown = 0;

    private string ssPath;

    public RawImage cropImage;

    private void Update()
    {
        if (cropImage.texture == null)
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
    }

    void GetPictureAndShowIt()
    {
        string pathToFile = files[whichScreenShotIsShown];
        Texture2D texture = GetScreenshotImage(pathToFile);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
            new Vector2(0.5f, 0.5f));
        image.GetComponent<Image>().sprite = sp;
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
            whichScreenShotIsShown = files.Length-1;
            GetPictureAndShowIt();

        }
    }

    public void NextPicture()
    {
        whichScreenShotIsShown += 2;
            GetPictureAndShowIt();
    }

    public void previousScene() => SceneManager.LoadScene("Home");

    public void nextScene()
    {
        SceneManager.LoadScene("Interact");
    }
}
