﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Dot.Utility.Exceptions
{
    /// <summary>
    /// 引用的异常信息
    /// </summary>
    [Serializable]
    public class ReferencedException : iWSException
    {
       
         public ReferencedException(string message) : base(message)
        {
        }

        public ReferencedException(string message,Exception ex)
            : base(message,ex)
        {
        }

        public ReferencedException()
            : base()
        {
        }

        public ReferencedException(SerializationInfo serializationInfo,StreamingContext context)
            : base(serializationInfo,context)
        {
        }
    }
}