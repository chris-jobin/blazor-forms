using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Components.Forms.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StringLengthAttribute : Attribute, IFormAttribute
    {
        public string ErrorMessage { get; set; }
        public int MaxLength { get; set; }
        public int MinLength { get; set; }
        public int Length { get; set; }

        public StringLengthAttribute(int max) : this(max, 0, 0)
        { }
        public StringLengthAttribute(int max = 0, int min = 0, int length = 0) : this("Invalid length.", max, min, length)
        { }
        public StringLengthAttribute(string errorMessage, int max, int min, int length) 
        {
            if (max < 0)
                throw new ArgumentOutOfRangeException("MaxLength cannot be negative.");
            if (min < 0)
                throw new ArgumentOutOfRangeException("MinLength cannot be negative.");
            if (length < 0)
                throw new ArgumentOutOfRangeException("Length cannot be negative.");
            if (min > max)
                throw new ArgumentOutOfRangeException("MinLength cannot be bigger than MaxLength.");
            if (length > 0 && (max > 0 || min > 0))
                throw new Exception("Cannot specify MaxLength or MinLength with Length.");

            ErrorMessage = errorMessage;
            MaxLength = max;
            MinLength = min;
            Length = length;
        }

        public string? GetErrorMessage(object? value)
        {
            if (value is null) 
                return null;
            
            if (value is string)
            {
                var stringValue = (string)value;
                var stringLength = stringValue.Length;

                if (Length > 0 && stringLength != Length)
                    return ErrorMessage;
                if (MaxLength > 0 && stringLength > MaxLength)
                    return ErrorMessage;
                if (MinLength > 0 && stringLength < MinLength)
                    return ErrorMessage;
            }

            return null;
        }
    }
}
