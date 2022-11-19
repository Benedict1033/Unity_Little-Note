using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Image))]
public class flash : MonoBehaviour
{
    [Header("General")]
    [Range(0, 1)] [SerializeField] float _startingAlpha = 0;
    [SerializeField] float _secondsForOneFlash = 2f;

    public GameObject[] obj;

   
    private void Start()
    {
        obj[0].SetActive(false);
        obj[1].SetActive(false);

        //Crop();
        Invoke("Crop", 0.1f);
        Invoke("cameraHide", 0.2f);
        Invoke("screenShot", 0.3f);

        
        //Invoke("Flash", 0.31f);
        Invoke("nextScene", 0.35f);
    }

    void Crop() {
        obj[2].SetActive(true);
    }

    void cameraHide() {
        obj[3].SetActive(false);
    }

    void screenShot() {
        obj[4].SetActive(true);
    }
    void nextScene()
    {
        SceneManager.LoadScene("Date");
    }

    public float SecondsForOneFlash
    {
        get { return _secondsForOneFlash; }
        private set
        {
            if (value < 0)
            {
                value = 0;
            }
            _secondsForOneFlash = value;
        }
    }
    [Range(0, 1)]
    [SerializeField] float _minAlpha = 0f;
    public float MinAlpha
    {
        get { return _minAlpha; }
        private set
        {
            _minAlpha = Mathf.Clamp(value, 0, 1);
        }
    }
    [Range(0, 1)]
    [SerializeField] float _maxAlpha = 1f;
    public float MaxAlpha
    {
        get { return _maxAlpha; }
        private set
        {
            _maxAlpha = Mathf.Clamp(value, 0, 1);
        }
    }

    // events
    public event Action OnStop = delegate { };
    public event Action OnCycleStart = delegate { };
    public event Action OnCycleComplete = delegate { };

    Coroutine _flashRoutine = null;
    Image _flashImage;




    #region Initialization
    private void Awake()
    {
        _flashImage = GetComponent<Image>();
        // initial state
        SetAlphaToDefault();

      
    }

    #endregion

    #region Public Functions
    public void Flash()
    {
        if (_secondsForOneFlash <= 0) { return; }    // 0 speed wouldn't make sense

        if (_flashRoutine != null)
        {
            StopCoroutine(_flashRoutine);
        }
        _flashRoutine = StartCoroutine(FlashOnce(SecondsForOneFlash, MinAlpha, MaxAlpha));
    }

    public void Flash(float secondsForOneFlash, float minAlpha, float maxAlpha)
    {
        if (_secondsForOneFlash <= 0) { return; }    // 0 speed wouldn't make sense

        MinAlpha = minAlpha;
        MaxAlpha = maxAlpha;

        if (_flashRoutine != null)
        {
            StopCoroutine(_flashRoutine);
        }
        _flashRoutine = StartCoroutine(FlashLoop(secondsForOneFlash, MinAlpha, MaxAlpha));

    }

    #endregion

    #region Private Functions
    IEnumerator FlashOnce(float secondsForOneFlash, float minAlpha, float maxAlpha)
    {

        // half the flash time should be on flash in, the other half for flash out
        float flashInDuration = secondsForOneFlash / 2;
        float flashOutDuration = secondsForOneFlash / 2;

        OnCycleStart.Invoke();
        // flash in
        for (float t = 0f; t <= flashInDuration; t += Time.deltaTime)
        {
            Color newColor = _flashImage.color;
            newColor.a = Mathf.Lerp(minAlpha, maxAlpha, t / flashInDuration);
            _flashImage.color = newColor;
            yield return null;
        }
        // flash out
        for (float t = 0f; t <= flashOutDuration; t += Time.deltaTime)
        {
            Color newColor = _flashImage.color;
            newColor.a = Mathf.Lerp(maxAlpha, minAlpha, t / flashOutDuration);
            _flashImage.color = newColor;
            yield return null;
        }

        OnCycleComplete.Invoke();
    }

    IEnumerator FlashLoop(float secondsForOneFlash, float minAlpha, float maxAlpha)
    {
        // half the flash time should be on flash in, the other half for flash out
        float flashInDuration = secondsForOneFlash / 2;
        float flashOutDuration = secondsForOneFlash / 2;
        // start the flash cycle
        while (true)
        {
            OnCycleStart.Invoke();
            // flash in
            for (float t = 0f; t <= flashInDuration; t += Time.deltaTime)
            {
                Color newColor = _flashImage.color;
                newColor.a = Mathf.Lerp(minAlpha, maxAlpha, t / flashInDuration);
                _flashImage.color = newColor;
                yield return null;
            }
            // flash out
            for (float t = 0f; t <= flashOutDuration; t += Time.deltaTime)
            {
                Color newColor = _flashImage.color;
                newColor.a = Mathf.Lerp(maxAlpha, minAlpha, t / flashOutDuration);
                _flashImage.color = newColor;
                yield return null;
            }

            OnCycleComplete.Invoke();
        }
    }

    private void SetAlphaToDefault()
    {
        Color newColor = _flashImage.color;
        newColor.a = _startingAlpha;
        _flashImage.color = newColor;
    }

    private void SetNewFlashValues(float secondsForOneFlash, float minAlpha, float maxAlpha)
    {
        SecondsForOneFlash = secondsForOneFlash;
        MinAlpha = minAlpha;
        MaxAlpha = maxAlpha;
    }
    #endregion
}