using UnityEngine;

public class ChangeRotation : MonoBehaviour
{
	[SerializeField] private float _rotationSpeed = 30.0f;

	void Update()
	{
		transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.up);
	}
}
