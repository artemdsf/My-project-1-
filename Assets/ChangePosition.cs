using UnityEngine;

public class ChangePosition : MonoBehaviour
{
	[SerializeField] private float _speed = 5.0f;

	void Update()
	{
		transform.Translate(_speed * Time.deltaTime * Vector3.forward);
	}
}
