using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Music
{
    ///
    /// Beat = 1/4 음표 하나 기준
    /// 4분의 4박자 기준으로 한 마디는 4beat.
    ///

    public enum NoteType
    {
        One,
        Long,
        Sync
    }

    public enum CheckType
	{
		Blue,
        Green,
        Red
    }

    public enum GenPos
	{
		Left,
        Right,
        Down
	}

    public class Note
    {
        public float _beat;          // 비트
        public float _checkTime;
        public NoteType _type;
        public CheckType _check;
		public GenPos _genPos;
        
        public Note(float beat, NoteType type, CheckType check, GenPos pos)
        {
            _beat = beat;
            _checkTime = 0.1f;
            _type = type;
            _check = check;
			_genPos = pos;
        }

        public void SetCheckTime(float time)
        {
            _checkTime = time;
        }
    }

    public class Pattern
    {
        //public string _name;       // 패턴 이름
        public float _startBeat;     // 시작 비트

        public float _totalBeat;     // 총 비트
        public List<Note> _notes;

        public Pattern(List<Note> notes)
        {
            //_name = name;
            //_startBeat = startBeat;
            _notes = notes;
            _totalBeat = notes.Select(x => x._beat).ToArray().Sum();
        }
    }

	public class Action
    {
        public float _startBeat;     // 시작 비트

		public Pattern _pattern;

		public Action(int startBeat, Pattern pattern)
        {
            _startBeat = startBeat;
			_pattern = pattern;
        }
    }

    /// <summary>
    /// Base music sheet.
    ///
    /// 클래스를 상속한 다음에
    /// Init 함수에서 패턴들을 초기화하고
    /// 시트를 완성해야함.
    /// </summary>
    public class BaseMusicSheet
    {
        public float _bpm;
        public float _beatSecond;

        //public Dictionary<string, Pattern> _patterns;
		public List<Action> _sheet1;      
		public List<Action> _sheet2;
		public List<Action> _sheet3;

        public virtual void Setup()
        {
        }

        public void Init()
        {
            Setup();

            _beatSecond = 1.0f / (_bpm / 60.0f);

            for (int i = 0; i < _sheet1.Count; i++)
            {
				for (int j = 0; j < _sheet1[i]._pattern._notes.Count(); j++)
                {
					_sheet1[i]._pattern._notes[j]._checkTime = ((_sheet1[i]._startBeat + _sheet1[i]._pattern._notes[j]._beat) * _beatSecond);
                }
            }

            for (int i = 0; i < _sheet2.Count; i++)
            {
				for (int j = 0; j < _sheet2[i]._pattern._notes.Count; j++)
				{
                    _sheet2[i]._pattern._notes[j]._checkTime = ((_sheet2[i]._startBeat + _sheet2[i]._pattern._notes[j]._beat) * _beatSecond);
                }
            }

            for (int i = 0; i < _sheet3.Count; i++)
            {
				for (int j = 0; j < _sheet3[i]._pattern._notes.Count; j++)
				{
                    _sheet3[i]._pattern._notes[j]._checkTime = ((_sheet3[i]._startBeat + _sheet3[i]._pattern._notes[j]._beat) * _beatSecond);
                }
            }
        }
    }
}