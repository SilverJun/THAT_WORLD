using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgementArea : MonoBehaviour
{
    public SpriteRenderer[] LineSprite;

    public bool _isNote = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Note"))
            return;
        /// 1플레이어는 left blue side
        /// 2플레이어는 down green side
        /// 3플레이어는 right red side

        _isNote = true;

        var note = collision.GetComponent<NoteObject>();

        if (!Input.anyKeyDown || note._isHit)
            return;

        var varTime = Mathf.Abs(note._note._checkTime - note._audio.time);
        var isPerfect = varTime < 0.25f;
        var isRightKeyPressed = false;

        //Debug.Log("Trigger Stay");
        switch (name)
        {
            case "LeftJudge":
                switch (note._note._check)
                {
                    case Music.CheckType.Red:

                        ///JoystickButton0 - X 18
                        ///JoystickButton1 - A 16
                        ///JoystickButton2 - B 17
                        ///JoystickButton3 - Y 19
                        isRightKeyPressed = Input.GetKeyDown(KeyCode.Joystick1Button1);
                        break;

                    case Music.CheckType.Blue:
                        isRightKeyPressed = Input.GetKeyDown(KeyCode.Joystick1Button2);
                        break;

                    case Music.CheckType.Green:
                        isRightKeyPressed = Input.GetKeyDown(KeyCode.Joystick1Button0);
                        break;
                }
                break;

            case "RightJudge":
                switch (note._note._check)
                {
                    case Music.CheckType.Red:
                        isRightKeyPressed = Input.GetKeyDown(KeyCode.Joystick2Button1);
                        break;

                    case Music.CheckType.Blue:
                        isRightKeyPressed = Input.GetKeyDown(KeyCode.Joystick2Button2);
                        break;

                    case Music.CheckType.Green:
                        isRightKeyPressed = Input.GetKeyDown(KeyCode.Joystick2Button0);
                        break;
                }
                break;

            case "DownJudge":
                switch (note._note._check)
                {
                    case Music.CheckType.Red:
                        isRightKeyPressed = Input.GetKeyDown(KeyCode.RightArrow);
                        break;

                    case Music.CheckType.Blue:
                        isRightKeyPressed = Input.GetKeyDown(KeyCode.LeftArrow);
                        break;

                    case Music.CheckType.Green:
                        isRightKeyPressed = Input.GetKeyDown(KeyCode.DownArrow);
                        break;
                }
                break;
        }

        //Debug.Log("key");
        if (!isRightKeyPressed)
            return;

        Camera.main.GetComponent<CameraController>().Shake(0.075f, 5.0f);

        if (isPerfect)
            note._gameStage.OnPerfect(note);
        else
            note._gameStage.OnNotBad(note);

        // 끄기
        note._isCollision = false;

        note._isHit = true;

        GameObject hitParticlePrefab = Resources.Load<GameObject>("Prefab/HitParticle");
        GameObject hitParticleObject = Instantiate(hitParticlePrefab, note.transform.position, note.transform.rotation);
        Destroy(hitParticleObject, hitParticleObject.GetComponent<ParticleSystem>().main.duration);

        Destroy(note.gameObject);
    }
}