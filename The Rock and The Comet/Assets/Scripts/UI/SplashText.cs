using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashText : MonoBehaviour
{

    public GameObject[] splash;
    public float wait;
    [SerializeField] GameObject introCanvas;
    [SerializeField] GameObject spawn;
    public bool isRunning;
    public LevelSwitcher switcher;
    public bool textMoving;
    // Start is called before the first frame update
    void Start()
    {
        isRunning = false;
        textMoving = false;
    }

    public void startRunning()
    {
        
        introCanvas.SetActive(true);
        StartCoroutine(TextScroll(wait));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && isRunning)
        {
            StartCoroutine(Fade());
        }
    }

    IEnumerator TextScroll(float wait)
    {
        if (!textMoving) {
            textMoving = true;
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                splash[0].GetComponent<Image>().color = new Color(.046f, .0456f, .0566f, i);
                yield return null;
            }
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                splash[1].GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
            yield return new WaitForSeconds(1.2f);
            //first text fades in
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                splash[2].GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
            yield return new WaitForSeconds(wait);
            //first text fades out
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                splash[2].GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
            yield return new WaitForSeconds(1.2f);
            //second text fades in
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                splash[3].GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
            yield return new WaitForSeconds(wait);
            //second text fades out
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                splash[3].GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
            yield return new WaitForSeconds(1.2f);
            //third text fades in
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                splash[4].GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
            yield return new WaitForSeconds(wait - 1);
            //fourth text fades in
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                splash[5].GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
            yield return new WaitForSeconds(wait);
            //third and fourth text fades out
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                splash[4].GetComponent<Image>().color = new Color(1, 1, 1, i);
                splash[5].GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
            yield return new WaitForSeconds(1.2f);
            //controls and 'continue' instructions fade in
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                splash[6].GetComponent<Image>().color = new Color(1, 1, 1, i);
                splash[7].GetComponent<Image>().color = new Color(1, 1, 1, i);
                yield return null;
            }
            isRunning = true;
        }
        

    }

    IEnumerator Fade()
    {
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            splash[1].GetComponent<Image>().color = new Color(1, 1, 1, i);
            splash[6].GetComponent<Image>().color = new Color(1, 1, 1, i);
            splash[7].GetComponent<Image>().color = new Color(1, 1, 1, i);
            yield return null;
        }
        switcher.surfaceLevel();
    }
}
