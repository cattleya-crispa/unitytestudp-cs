using System.Collections;
using System.Collections.Generic;
//↑上の二つのusingは使わないから本当はいらないよ。
using UnityEngine;
//Moveと言うクラスで書いてくよ
public class Move : MonoBehaviour
{
	//Objectを動かすスピードを4にする。
	//このスピードはpublicで定義してあるからInspectorで変更できるよ。
	public float speed = 4.0f;

	// Update is called once per frame
	void Update()
	{
		//Unity内にインプットされているupを使って矢印の上を押すとその方向に動くよ。
		if (Input.GetKey("up"))
		{
			//場所は押した分だけ前に進んで話すと止まるよ。
			transform.position += transform.forward * speed * Time.deltaTime;
		}
		//これは下。
		if (Input.GetKey("down"))
		{
			transform.position -= transform.forward * speed * Time.deltaTime;
		}
		//これは右。
		if (Input.GetKey("right"))
		{
			transform.position += transform.right * speed * Time.deltaTime;
		}
		//これは左。
		if (Input.GetKey("left"))
		{
			transform.position -= transform.right * speed * Time.deltaTime;
		}
	}


}