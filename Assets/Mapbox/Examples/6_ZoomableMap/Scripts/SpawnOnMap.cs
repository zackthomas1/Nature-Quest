namespace Mapbox.Examples
{
	using UnityEngine;
	using Mapbox.Utils;
	using Mapbox.Unity.Map;
	using Mapbox.Unity.MeshGeneration.Factories;
	using Mapbox.Unity.Utilities;
	using System.Collections.Generic;

    public class SpawnOnMap : MonoBehaviour
	{
		[SerializeField]
		AbstractMap _map;

		[SerializeField]
		[Geocode]
		string[] _locationStrings;
		Vector2d[] _locations;

		[SerializeField]
		float _spawnScale = 100f;

		[SerializeField]
		GameObject _markerPrefab;

		List<GameObject> _spawnedObjects;

		void Start()
		{
            Debug.Log($"Instantiating prefab: {_markerPrefab.name}");

            _locations = new Vector2d[_locationStrings.Length];
			_spawnedObjects = new List<GameObject>();
			for (int i = 0; i < _locationStrings.Length; i++)
			{
				var locationString = _locationStrings[i];
				_locations[i] = Conversions.StringToLatLon(locationString);

                var instance = Instantiate(_markerPrefab);
                Vector3 spawnPos = _map.GeoToWorldPosition(_locations[i], true);

                // Debug check
                var settings = instance.GetComponent<SpawnSettings>();
                if (settings != null)
                {
                    Debug.Log($"Applying Y offset: {settings.yOffset} to instance {instance.name}");
                    spawnPos.y += settings.yOffset;
                }
                else
                {
                    Debug.LogWarning($"No SpawnSettings found on {instance.name}");
                }

                instance.transform.localPosition = spawnPos;

                instance.transform.localPosition = spawnPos;
                instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
				var oakTreePointer = instance.GetComponent<OakTreePointer>();
				if (oakTreePointer != null)
				{
    				oakTreePointer.eventPos = _locations[i];
					oakTreePointer.eventID = i + 1;
				}
				_spawnedObjects.Add(instance);
			}
		}

		private void Update()
		{
			int count = _spawnedObjects.Count;
			for (int i = 0; i < count; i++)
			{
				var spawnedObject = _spawnedObjects[i];
				var location = _locations[i];
				
                Vector3 updatedPos = _map.GeoToWorldPosition(location, true);

                // Apply optional Y offset
                var settings = spawnedObject.GetComponent<SpawnSettings>();
                if (settings != null)
                {
                    updatedPos.y += settings.yOffset;
                }

                spawnedObject.transform.localPosition = updatedPos;
                spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
			}
		}
	}
}