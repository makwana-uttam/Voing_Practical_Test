using System;
using System.Collections.Generic;

namespace VoingPractical.Model
{
    public class Class1
    {
    }

    public class Error
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class Response<T>
    {
        public bool IsSucceed { get; set; }
        public List<Error> Errors { get; set; }
        public T ReturnObject { get; set; }
    }
}
