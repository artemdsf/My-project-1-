using Mono.Cecil;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
	[SerializeField] private List<Unit> _units = new();
	[SerializeField] private ResourcesGenerator _generator;
	[SerializeField] private TMP_Text _resourcesCountTMPText;
	[SerializeField] private string _resourcesCountText;

	private List<Unit> _freeUnits = new();
	private int _resourcesCount = 0;

	public void Unchain(Unit unit)
	{
		_resourcesCount++;
		_freeUnits.Add(unit);
		UpdateUI();
	}

	private void Awake()
	{
		_freeUnits = new List<Unit>(_units);
		UpdateUI();

		foreach (Unit unit in _freeUnits)
		{
			unit.Init(_generator, this);
		}
	}

	private void Update()
	{
		if (_freeUnits.Count > 0 && _generator.ResourcesCount > 0)
		{
			Scavenge();
		}
	}

	private void UpdateUI()
	{
		_resourcesCountTMPText.text = $"{_resourcesCountText} {_resourcesCount}";
	}

	private void Scavenge()
	{
		Unit unit = _freeUnits[0];
		Resource resource = _generator.FindResource(unit.transform.position);
		unit.SetTargetResource(resource);
		_freeUnits.Remove(unit);
	}
}
