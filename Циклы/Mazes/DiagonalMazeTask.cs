namespace Mazes
{
	public static class DiagonalMazeTask
	{
		public static void MoveOut(Robot robot, int width, int height)
		{
            while (robot.X != width - 2 && robot.Y != height - 2)
                if (width > height)
                    MoveOneDiagonalStep(robot, (width - 2) / (height - 2), 1);
                else 
					MoveOneDiagonalStep(robot, 1, (height - 2) / (width - 2));

            if (width > height)
				MoveRight(robot, (width - 2) / (height - 2));
			else 
				MoveDown(robot, (height - 2) / (width - 2));
		}

		private static void MoveOneDiagonalStep(Robot robot, int stepCountRight, int stepCountDown)
		{
			if (stepCountRight > stepCountDown)
			{
				MoveRight(robot, stepCountRight);
				MoveDown(robot, stepCountDown);
			}
			else
			{
				MoveDown(robot, stepCountDown);
				MoveRight(robot, stepCountRight);				
			}
		}

		private static void MoveDown(Robot robot, int stepCount)
		{
			for (int i = 0; i < stepCount; i++)
				robot.MoveTo(Direction.Down);
		}

		private static void MoveRight(Robot robot, int stepCount)
		{
			for (int i = 0; i < stepCount; i++)
				robot.MoveTo(Direction.Right);
		}
	}
}