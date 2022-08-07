namespace IllusionSteps
{
	public readonly record struct Unit
	{
		private const int OFFSET = 100;

		private static string WithPathFormat { get; } = "{0} + ({1}/" + OFFSET + ")";

		public static Unit Create(int quotient) => Create(quotient, 0);

		public static Unit Create(int quotient, int remainder) => new(quotient * OFFSET + remainder);

		public Unit(int value) => Value = value;

		public int Value { get; }

		public int Quotient => Value / OFFSET;

		public int Remainder => Value % OFFSET;

		public override string ToString()
		{
			var result = Math.DivRem(Value, OFFSET);

			if (result.Remainder == 0)
			{
				return result.Quotient.ToString();
			}
			else
			{
				return string.Format(WithPathFormat, result.Quotient, result.Remainder);
			}
		}

		public static implicit operator Unit(int value) => Create(value);

		public static explicit operator float(Unit value)
		{
			var result = Math.DivRem(value.Value, OFFSET);

			return result.Quotient + result.Remainder / (float)OFFSET;
		}

		public static explicit operator Unit(float value) => new((int)(value * OFFSET));

		public static explicit operator double(Unit value)
		{
			var result = Math.DivRem(value.Value, OFFSET);

			return result.Quotient + result.Remainder / (double)OFFSET;
		}

		public static explicit operator Unit(double value) => new((int)(value * OFFSET));

		public static Unit operator +(Unit x, Unit y) => new(x.Value + y.Value);

		public static Unit operator -(Unit x, Unit y) => new(x.Value - y.Value);

		public static Unit operator *(Unit x, int y) => new(x.Value * y);

		public static Unit operator *(int x, Unit y) => new(x * y.Value);

		public static Unit operator ++(Unit value) => new(value.Value + OFFSET);

		public static Unit operator --(Unit value) => new(value.Value - OFFSET);
	}
}