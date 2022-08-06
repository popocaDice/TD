using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scrolling3DText : MonoBehaviour
{
	public float scrollSpeed, maxHeight;

	private RectTransform trans;

    // Start is called before the first frame update
    void Start()
    {
		trans = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
		trans.sizeDelta += Vector2.up * scrollSpeed;

		if (trans.sizeDelta.y > maxHeight || Input.GetMouseButtonDown(0)) Next();
    }

	void Next()
	{
		SceneManager.LoadScene("SampleScene");
	}
}
