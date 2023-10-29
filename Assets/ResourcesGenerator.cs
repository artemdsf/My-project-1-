using Mono.Cecil;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesGenerator : MonoBehaviour
{
	[SerializeField] private List<Transform> _spawnPoints = new();
	[SerializeField] private GameObject _resourcePrefab;
	[SerializeField] private Transform _resourcesParent;
	[SerializeField] private int _startResourcesCount;

	public int ResourcesCount => _resources.Count;

	private List<Transform> _freeSpawnPoints = new();
	private List<Resource> _resources = new();

	public void SpawnResourceUI()
	{
		SpawnResource();
	}
	
	public void TakeResource(Resource resource)
	{
		_freeSpawnPoints.Add(resource.SpawnPoint);
		resource.SpawnPoint = null;
	}

	public Resource FindResource(Vector3 start)
	{
		if (_resources.Count == 0)
			return null;

		Resource nearestResource = null;

		foreach (Resource resource in _resources)
		{
			if (nearestResource == null || DistanceToResource(resource, start) < DistanceToResource(nearestResource, start))
			{
				nearestResource = resource;
			}
		}

		_resources.Remove(nearestResource);

		return nearestResource;
	}

	private float DistanceToResource(Resource resource1, Vector3 start)
	{
		return (resource1.transform.position - start).magnitude;
	}

	private bool SpawnResource()
	{
		if (_freeSpawnPoints.Count > 0)
		{
			Transform resourcePoint = _freeSpawnPoints[Random.Range(0, _freeSpawnPoints.Count)];
			GameObject resourceGameObject = Instantiate(_resourcePrefab, resourcePoint.position, Quaternion.identity, _resourcesParent);
			Resource resource = resourceGameObject.GetComponent<Resource>();
			resource.SpawnPoint = resourcePoint;

			_resources.Add(resource);
			_freeSpawnPoints.Remove(resourcePoint);

			return true;
		}

		return false;
	}

	private void Awake()
	{
		_freeSpawnPoints = new List<Transform>(_spawnPoints);
	}

	private void Update()
	{
		
	}

	private void Start()
	{
		for (int i = 0; i < _startResourcesCount; i++)
		{
			SpawnResource();
		}
	}
}
