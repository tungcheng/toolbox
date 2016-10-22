﻿using UnityEngine;
using System.Collections;

public class qfCameraShake : MonoBehaviour
{
	public float Magnitude = 1.0f;
	public IEnumerator Shake(float duration = 0.2f)
	{
		float elapsed = 0.0f;

		Vector3 originalCamPos = transform.position;

		while (elapsed < duration)
		{

			elapsed += Time.deltaTime;

			float percentComplete = elapsed / duration;
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float y = Random.value * 2.0f - 1.0f;
//			float z = Random.value * 2.0f - 1.0f;
			x *= Magnitude * damper;
			y *= Magnitude * damper;
//			z *= Magnitude * damper;

//			transform.position = new Vector3(x, y, originalCamPos.z);
			transform.position = originalCamPos + new Vector3(x, y,0);
//			transform.position = new Vector3(x, y, z);

			yield return null;
		}

		transform.position = originalCamPos;
	}
}
