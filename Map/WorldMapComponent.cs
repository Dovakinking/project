using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]

public class WorldMapComponent : MonoBehaviour
{

	[SerializeField] private Transform target; // ������� ������ (�����, ���� � �.�.)
	[SerializeField] private bool useRotation; // ���� ������ � ���� �������, ����� �������� ��� ��������, ���� ������� ������
	private RectTransform rectTransform;

	void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
	}

	void LateUpdate()
	{
		if (useRotation)
		{
			float angle = 180+Mathf.Atan2(target.forward.z, target.forward.x) * Mathf.Rad2Deg;
			rectTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}

		rectTransform.localPosition = WorldMap.TransformPosition(target.position);
	}
}