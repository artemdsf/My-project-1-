using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
	[SerializeField] private List<Material> _materials;
	[SerializeField] private List<Renderer> _objectsToChangeMaterial;

	public Transform SpawnPoint;

	private int _materialIndex;

	private void Start()
	{
		if (_materials == null)
		{
			Debug.LogWarning("ћатериалы не настроены или некорректный индекс начального материала.");
			return;
		}

		_materialIndex = Random.Range(0, _materials.Count);

		foreach (Renderer renderer in _objectsToChangeMaterial)
		{
			renderer.material = _materials[_materialIndex];
		}
	}
}
