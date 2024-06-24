using FizzBuzz.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzBuzz.Services
{
    public class FizzBuzzService : IFizzBuzz
    {
        public Task<string> GetFizzBuzz(string? number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return Task.FromResult("Invalid Item");
            }
            if (!int.TryParse(number, out int outNum))
            {
                return Task.FromResult("Invalid Item");
            }
            if (outNum % 3 == 0 && outNum % 5 == 0)
            {
                return Task.FromResult("FizzBuzz");
            }
            else if (outNum % 3 == 0)
            {
                return Task.FromResult("Fizz");
            }
            else if (outNum % 5 == 0)
            {
                return Task.FromResult("Buzz");
            }
            else
            {
                return Task.FromResult($"Number {outNum} is not divisible by 3 or 5");
            }
        }
    }
}
