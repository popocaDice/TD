using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour
{
	public GameObject icon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnMouseDown()
	{
		icon.GetComponent<DragnDropTurret>().Reactivate();
		Destroy(gameObject);
	}
}
