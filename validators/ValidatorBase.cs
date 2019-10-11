using System;
using System.Linq;
using System.Text;

namespace validators
{

    public class RegonValidator : IValidator
    {
        public bool IsValid(string number)
        {
            RegonValidatorBase regonValidator = RegonValidatorFactory.Create(number.Length);

            return regonValidator.IsValid(number);
        }


        internal class RegonValidatorFactory
        {
            public static RegonValidatorBase Create(int length)
            {
                switch(length)
                {
                    case 7: return new Regon7Validator();
                    case 9: return new Regon9Validator();
                    case 14: return new Regon14Validator();
                    default: throw new NotSupportedException();
                }
            }
        }

        internal abstract class RegonValidatorBase : ValidatorBase
        {
            protected override int CheckControl(int sumControl) => 10 - sumControl % 10;

        }

        internal class Regon7Validator : RegonValidatorBase
        {
            protected override byte[] Weights => new byte[] { 2, 3, 4, 5, 6, 7 };
        }

        internal class Regon9Validator : RegonValidatorBase
        {
            protected override byte[] Weights => new byte[] { 8, 9, 2, 3, 4, 5, 6, 7 };
        }

        internal class Regon14Validator : RegonValidatorBase
        {
            protected override byte[] Weights => new byte[] { 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 };
        }
    }

    

    public class PeselValidator : ValidatorBase
    {
        protected override byte[] Weights => new byte[] { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
        protected override int CheckControl(int sumControl) => 10 - sumControl % 10;
    }

    public class NIPValidator : ValidatorBase
    {
        protected override byte[] Weights => new byte[] { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
        protected override int CheckControl(int sumControl)  => sumControl % 11;
    }

    public interface IValidator
    {
        bool IsValid(string number);
    }

    public abstract class ValidatorBase : IValidator
    {
        private int CalculateSumControl(byte[] numbers, byte[] weights) => numbers
            .Take(numbers.Length - 1)
            .Select((number, index) => new { number, index })
            .Sum(n => n.number * weights[n.index]);

        protected abstract byte[] Weights { get; }

        protected abstract int CheckControl(int sumControl);

        private byte[] ToByteArray(string input) => input
                                                    .ToCharArray()
                                                    .Select(c => byte.Parse(c.ToString()))
                                                    .ToArray();
        
        public bool IsValid(string number)
        {
            if (!number.All(Char.IsDigit))
            {
                throw new FormatException($"Number must have only digits");
            }

            if (number.Length != Weights.Length + 1)
            {
                throw new FormatException($"Number must have {Weights.Length} digits");
            }

            byte[] numbers = ToByteArray(number);

            int controlSum = CalculateSumControl(numbers, this.Weights);

            System.Diagnostics.Trace.WriteLine($"sum control {controlSum}");

            int controlNum = CheckControl(controlSum);

            System.Diagnostics.Trace.WriteLine($"divide modulo {controlNum}");


			if (controlNum == 10)
			{
				controlNum = 0;
			}

			return controlNum == numbers.Last();
        }
    }
}
