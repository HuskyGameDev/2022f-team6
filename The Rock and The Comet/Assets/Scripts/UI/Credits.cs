using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public Animator cometAnimator;
    public Animator bubblesAnimator;
    public bool isRunning;
    Transform textPos;
    public GameObject text;
    public GameObject bgTint;
    public GameObject blackBox;
    // Start is called before the first frame update
    void Start()
    {
        cometAnimator.SetBool("isRunning", false);
        bubblesAnimator.SetBool("goFaster", false);
        transform.position = new Vector3(0, -12, -1);
        StartCoroutine(play(bgTint.GetComponent<Image>(), blackBox.GetComponent<Image>()));
    }

    IEnumerator play(Image img, Image img2)
    {
        for(float i = 1; i>=0; i -= Time.deltaTime)
        {
            img2.color = new Color(.046f, .0456f, .0566f, i);
            yield return null;
        }
        img2.color = new Color(.046f, .0456f, .0566f, 0);
        for (float y = -12; y <= 12; y += Time.deltaTime)
        {
            transform.position = new Vector3(0, y, -1);
            yield return null;
        }
        for(float i = .9f; i>=0; i-= Time.deltaTime)
        {
            img.color = new Color(.046f, .0456f, .0566f, i);
            yield return null;
        }
        img.color = new Color(.046f, .0456f, .0566f, 0);
        yield return new WaitForSeconds(.5f);
        bubblesAnimator.SetBool("goFaster", true);
        yield return new WaitForSeconds(2);
        cometAnimator.SetBool("isRunning", true);
    }

}
