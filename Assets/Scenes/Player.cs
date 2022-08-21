using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	/// <summary>状態表示用テキストオブジェクト。</summary>
	[SerializeField] private Text TextState;

	// 一定時間ごとに呼ばれます
	void FixedUpdate()
	{
		// キーボードの情報を取得
		var keyboard = Keyboard.current;

		// スプライトの移動処理
		if (keyboard.leftArrowKey.isPressed)
		{
			transform.Translate(-0.1f, 0, 0, Space.World);
		}
		if (keyboard.rightArrowKey.isPressed)
		{
			transform.Translate(0.1f, 0, 0, Space.World);
		}
		if (keyboard.upArrowKey.isPressed)
		{
			transform.Translate(0, 0.1f, 0, Space.World);
		}
		if (keyboard.downArrowKey.isPressed)
		{
			transform.Translate(0, -0.1f, 0, Space.World);
		}
	}

	/// <summary>衝突した瞬間に呼ばれます。</summary>
	/// <param name="partner">衝突した相手のコリジョン情報。</param>
	private void OnCollisionEnter2D(Collision2D partner)
	{
		TextState.text = $"OnCollisionEnter2D : {partner.collider.tag} {DateTime.Now:HH:mm:ss.fff}{Environment.NewLine}{TextState.text}";
	}

	/// <summary>衝突している間呼ばれます。ただしスリープモードになった場合は呼ばれません。</summary>
	/// <param name="partner">衝突した相手のコリジョン情報。</param>
	private void OnCollisionStay2D(Collision2D partner)
	{
		TextState.text = $"OnCollisionStay2D : {partner.collider.tag} {DateTime.Now:HH:mm:ss.fff}{Environment.NewLine}{TextState.text}";
	}

	/// <summary>衝突状態でなくなったタイミングで呼ばれます。</summary>
	/// <param name="partner">衝突した相手のコリジョン情報。</param>
	private void OnCollisionExit2D(Collision2D partner)
	{
		TextState.text = $"OnCollisionExit2D : {partner.collider.tag} {DateTime.Now:HH:mm:ss.fff}{Environment.NewLine}{TextState.text}";
	}
}
