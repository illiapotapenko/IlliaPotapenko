using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class TextController : MonoBehaviour
{
    public Image startText;
    public Image pickUpKey;
    public Image findExit;
    public Image findKey;

    private float animationDuration = 2f;
    private float offsetY = 400;

    void Start()
    {
        StartCoroutine(ShowTextWithDelay(startText));
    }

    public IEnumerator ShowTextWithDelay(Image textImage)
    {
        Show(textImage);

      yield return new WaitForSeconds(3);

        Hide(textImage);
    }

    public void ShowText(Image textImage)
    {
        Vector3 startPosition = textImage.rectTransform.position;
        Vector3 endPosition = startPosition + new Vector3(0, offsetY, 0);

        textImage.transform.DOMove(endPosition, 0.5f).SetRelative().SetDelay(animationDuration);
        textImage.transform.DOMove(startPosition, 0.5f);
    }

    public void Show(Image textImage)
    {
        textImage.gameObject.SetActive(true);
    }

    public void Hide(Image textImage)
    {
        textImage.gameObject.SetActive(false);
    }
}
