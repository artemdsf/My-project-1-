using UnityEngine;

public class Unit : MonoBehaviour
{
	[SerializeField] private Transform _basePoint;
	[SerializeField] private Transform _bagPoint;
	[SerializeField] private float _speed = 5f;
	
	private ResourcesGenerator _resourcesGenerator;
	private Base _targetBase;
	private Resource _targetResource;
	private Resource _resource;

	public void Init(ResourcesGenerator resourcesGenerator, Base targetBase)
	{
		_resourcesGenerator = resourcesGenerator;
		_targetBase = targetBase;
	}

	public void SetTargetResource(Resource targetResource)
	{
		_targetResource = targetResource;
	}

	private void Update()
	{
		if (_targetResource != null)
		{
			MoveToResource();
		}
		else if (_resource != null)
		{
			MoveToBase();
		}
	}

	private void MoveToResource()
	{
		if (MoveToTarget(_targetResource.transform.position))
		{
			_resource = _targetResource;
			_targetResource = null;
			_resource.transform.SetParent(transform);
			_resource.transform.position = _bagPoint.position;

			_resourcesGenerator.TakeResource(_resource);
		}
	}

	private void MoveToBase()
	{
		if (MoveToTarget(_basePoint.transform.position))
		{
			_targetBase.Unchain(this);
			Destroy(_resource.gameObject);
			_resource = null;
		}
	}

	private bool MoveToTarget(Vector3 target)
	{
		Vector3 vectorToTarget = target - transform.position;
		Vector3 moveOffset = vectorToTarget.normalized * Time.deltaTime * _speed;

		if (moveOffset.magnitude > vectorToTarget.magnitude)
		{
			transform.position = target;
			return true;
		}

		transform.position += moveOffset;
		return false;
	}
}
