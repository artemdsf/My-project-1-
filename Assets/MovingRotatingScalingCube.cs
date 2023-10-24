using UnityEngine;

public class MovingRotatingScalingCube : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 2.0f;
	[SerializeField] private float _rotationSpeed = 45.0f;
	[SerializeField] private float _growthSpeed = 0.05f;

	void Update()
	{
		transform.Translate(_moveSpeed * Time.deltaTime * Vector3.forward);
		transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.up);
		transform.localScale += _growthSpeed * Time.deltaTime * Vector3.one;
	}
}
