using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour
{
	public GameObject icon;

	private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		anim.SetInteger("Angle", (int)(transform.rotation.eulerAngles.z/90));
    }

	private void OnMouseDown()
	{
		icon.GetComponent<DragnDropTurret>().Reactivate();
		Destroy(gameObject);
	}
}
