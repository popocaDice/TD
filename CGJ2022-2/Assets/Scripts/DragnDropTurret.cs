using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragnDropTurret : MonoBehaviour
{
	public string dropTag;
	public bool active;

	public GameObject TurretType;

	private Vector3 clicked, origin;
	private Color originalColor;
	private TurretBase turret;

    // Start is called before the first frame update
    void Start()
    {
		origin = transform.position;
		originalColor = GetComponent<SpriteRenderer>().color;
		active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnMouseDown()
	{
		clicked = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//Debug.Log("clicked");
	}

	private void OnMouseDrag()
	{
		if (active) transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + clicked;
	}

	private void OnMouseUp()
	{
		clicked = Vector3.zero;
		transform.position = origin;
		Collider2D[] hit = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		foreach (Collider2D c in hit)
		{
			if (c.tag.Equals(dropTag))
			{
				active = false;
				GetComponent<SpriteRenderer>().color = Color.grey;
				turret = Instantiate(TurretType, c.transform).GetComponent<TurretBase>();
				turret.icon = gameObject;
			}
		}
	}

	public void Reactivate()
	{
		active = true;
		GetComponent<SpriteRenderer>().color = originalColor;
	}
}
