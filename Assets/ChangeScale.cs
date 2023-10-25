using UnityEngine;

public class ChangeScale : MonoBehaviour
{
	[SerializeField] private float _growthSpeed = 0.1f;

	void Update()
	{
		transform.localScale += new Vector3(_growthSpeed, _growthSpeed, _growthSpeed) * Time.deltaTime;
	}
}