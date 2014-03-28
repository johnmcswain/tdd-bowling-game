﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling
{
	public enum FrameType { Normal, Spare, Strike }

	public class BowlingFrame
	{
		public FrameType Type { get; set; }
		public int firstRoll = 0;
		public int secondRoll = 0;
	}

	public class BowlingGame
	{
		private int _score = 0;
		private bool _isSecondRoll = false;
		private int _previousScore = 0;
		private bool _spare = false;
		private int _frameCounter = 0;
		private bool _strike = false;
		private BowlingFrame[] _frames = new BowlingFrame[10];

		public void Roll(int pins)
		{
			if (_frameCounter == 10)
			{
				throw new Exception("More than 10 frames");
			}

			BowlingFrame frame;
			if (!_isSecondRoll)
			{
				frame = new BowlingFrame();
				_frames[_frameCounter] = frame;

				if (pins == 10)
				{
					frame.Type = FrameType.Strike;
				}

				frame.firstRoll = pins;
			}
			else
			{
				frame = _frames[_frameCounter];

				if (frame.firstRoll + pins == 10)
				{
					frame.Type = FrameType.Spare;
				}
			}

			_score += pins;

			if (_frameCounter > 0)
			{
				BowlingFrame previousFrame = _frames[_frameCounter - 1];

				if ((previousFrame.Type == FrameType.Spare && !_isSecondRoll) || previousFrame.Type == FrameType.Strike)
				{
					_score += pins;
				}

				if (_frameCounter > 1)
				{
					var previousPreviousFrame = _frames[_frameCounter - 2];

					if (previousPreviousFrame.Type == FrameType.Strike && !_isSecondRoll && previousFrame.Type == FrameType.Strike)
					{
						_score += pins;
					}
				}
			}


			if (frame.Type == FrameType.Strike || _isSecondRoll == true)
			{
				_isSecondRoll = false;
				_frameCounter++;
			}
			else
			{
				_isSecondRoll = true;
			}
		}

		public int Score()
		{
			return _score;
		}
	}
}
