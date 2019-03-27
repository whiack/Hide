using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeEffect : MonoBehaviour
{
    public float speed = 0.1f;
    public float fullTextSpeed = 2f;
    public string fullText;
    private string currentText = "";

    public AudioSource aud;

    public SceneTransition st;

    public TextAsset ta;

    private void Start()
    {
        string text = ta.text;
        var lines = text.Split("\n"[0]);
        Debug.Log(lines.Length);
        StartCoroutine(ShowText(lines));

    }

    IEnumerator ShowText(string[] s) {

        for (int i = 0; i < s.Length; i++)
        {

            string line = s[i];

            fullText = line;
            for (int j = 0; j < fullText.Length; j++)
            {
                currentText = fullText.Substring(0, j);
                this.GetComponent<Text>().text = currentText;
                aud.Play(0);
                yield return new WaitForSeconds(speed);
            }
            yield return new WaitForSeconds(fullTextSpeed);
        }

        st.OnClick();


    }
}
