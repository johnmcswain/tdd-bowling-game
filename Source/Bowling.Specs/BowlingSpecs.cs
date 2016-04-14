using Bowling;
using Bowling.Specs.Infrastructure;

namespace specs_for_bowling
{
	public class when_everything_is_wired_up : concerns
	{
		private bool _itWorked;

		protected override void context()
		{
			_itWorked = true;
		}

		[Specification]
		public void it_works()
		{
			_itWorked.ShouldBeTrue();
		}
	}

	public class when_rolling_all_gutter_balls : concerns
	{
		private Scoreboard _scoreboard;

		protected override void context()
		{
			_scoreboard = new Scoreboard();

			20.times(() => _scoreboard.Record(0));
		}

		[Specification]
		public void the_score_is_zero()
		{
			_scoreboard.Score.ShouldEqual(0);
		}
	}
}