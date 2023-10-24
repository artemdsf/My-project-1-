using UnityEngine;

public class SphereMovement : MonoBehaviour
{
	[SerializeField] private float _speed = 5.0f;

	void Update()
	{
		transform.Translate(_speed * Time.deltaTime * Vector3.forward);
	}
}
